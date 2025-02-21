using System.Runtime.CompilerServices;
using cClassVHS;
using cClassOAIS;
using MySql.Data.MySqlClient;
using static cClassVHS.cSkyrslur;
using Google.Protobuf.WellKnownTypes;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;

namespace Disaster_recovery
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.BLACK);
        }

        private async void m_btnRecovery_Click(object sender, EventArgs e)
        {

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string resultus = await Task.Run(() =>
                {
                    endurHeimta(folderBrowserDialog1.SelectedPath, folderBrowserDialog1.SelectedPath);
                    return "Endurheimt lokið!";
                });
            }
            //if (result == DialogResult.OK)
            //{
            //    endurHeimta(folderBrowserDialog1.SelectedPath, folderBrowserDialog1.SelectedPath);
            //}
        }
        private void endurHeimta(string strSlod, string strDagsetning)
        {
            //  MessageBox.Show("A") 1. gefa viðvörun

            // backup _OAIS_10_4_2023.sql
            DialogResult result = MessageBox.Show(string.Format("Viltu endursetja kerfið frá þessu afriti {0}. Öll gögn eftir þann tíma hverfa!", strDagsetning), "Endurheimta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string strBackupfile = string.Empty;
                foreach (String str in Directory.GetFiles(strSlod))
                {
                    if (str.EndsWith(".sql"))
                    {
                        strBackupfile = str; 
                        Restore(strBackupfile);
                    }
                }
                m_lblHvadAfrita.Text = "Endurheimti gagangrunn";
                Application.DoEvents();
                cBackup back = new cBackup();
              //  back.createDatabase();
               // Restore(strBackupfile);
                m_lblHvadAfrita.Text = "Tæmi vörslusvæði";
                if (Directory.Exists("D:\\AIP"))
                {
                    Directory.Delete("D:\\AIP", true);
                }
                   
                if (!Directory.Exists("D:\\AIP"))
                {
                    Directory.CreateDirectory("D:\\AIP");
                }

                flytjaAIPafrit("D:\\", strSlod, "Endurheimta"); //vantar að laga hver er rótin?
                MessageBox.Show("Endurheimt lokið");
            }


        }
        private void flytjaAIPafrit(string strDest, string strOrg, string strAðgerð)
        {

            //Now Create all of the directories
            m_prgBackup.Maximum = Directory.GetDirectories(strOrg, "*", SearchOption.AllDirectories).Length;
            m_prgBackup.Step = 1;
            m_prgBackup.Value = 0;
            m_lblHvadAfrita.Text = strAðgerð + " möppur";
            foreach (string dirPath in Directory.GetDirectories(strOrg, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(strOrg, strDest));
                m_lblHvadAfrita.Text = strAðgerð + " möppu " + (dirPath.Replace(strOrg, strDest));
                m_prgBackup.PerformStep();
                m_lblBackupStatus.Text = string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }

            m_prgBackup.Maximum = Directory.GetFiles(strOrg, "*.*", SearchOption.AllDirectories).Length;
            m_prgBackup.Step = 1;
            m_prgBackup.Value = 0;
            m_lblHvadAfrita.Text = strAðgerð + " skrár";
            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(strOrg, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(strOrg, strDest), true);
                m_lblHvadAfrita.Text = strAðgerð + " skrá " + newPath.Replace(strOrg, strDest);
                FileInfo fifo = new FileInfo(newPath);
                //   m_lStaerd += fifo.Length;
                m_prgBackup.PerformStep();
                m_lblBackupStatus.Text = string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }

        }
        private void Restore(string strRestoreFile)
        {
            string file = strRestoreFile;
            string strGrunnur = string.Empty;
            string[] strSplit = file.Split("_");
            string constring = string.Empty;
            cBackup back = new cBackup();
            if (strSplit.Length == 10)
            {
                
               constring = "server = localhost; user id = root; Password = ivarBjarkLind; database = db_oais_admin;";
               back.createDatabase();
            }
            else
            {
               strGrunnur = strSplit[7] + "_" + strSplit[8]+ "_" + strSplit[9] + "_" + strSplit[10];
               constring = "server = localhost; user id = root; Password = ivarBjarkLind; database = " + strGrunnur + ";";
              
               back.createDatabase(strGrunnur);
            }
            // backup _OAIS_avid_haku_2023054_1_23_11_2024.sql
            //string constring = "server = localhost; user id = root; Password = ivarBjarkLind; database = db_oais_admin;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception x)
            {

              //  throw;
            }
        }
    }
}