using System.Runtime.CompilerServices;
using static OAIS_ADMIN.uscNotandi;
using cClassOAIS;
using MySql.Data.MySqlClient;
using static cClassVHS.cSkyrslur;
using Google.Protobuf.WellKnownTypes;

namespace OAIS_ADMIN
{
    public partial class Form1 : Form
    {
       cNotandi virkurNotandi = new cNotandi();
        public Form1()
        {
            InitializeComponent();
            m_pnlNotandi.BringToFront();
            m_pnlNotandi.Dock = DockStyle.Fill;
            this.Text = "MHR";

        }

      

        private void m_btnInnskra_Click(object sender, EventArgs e)
        {
            innskra();          
        }

        private void innskra()
        {
            m_lblVillaInnSkraning.Visible = false;  
            string strNotandi = m_tboNoterndaNafn.Text;
            string strLykilor� = m_tboLykilOrd.Text;
            virkurNotandi.s�kjaNotanda(strNotandi, strLykilor�);
            if (virkurNotandi.nafn != null)
            {
                m_tacMain.BringToFront();
                m_tacMain.Dock = DockStyle.Fill;
                this.Text = "Velkominn " + virkurNotandi.nafn;
                m_uscInnsetning.virkurnotandi = virkurNotandi;
                uscGagnaUmsjon1.virkurnotandi = virkurNotandi;
                uscGeymsluMidlar1.virkurnotandi = virkurNotandi;
                uscUmsjon1.virkurnotandi = virkurNotandi;
                virkurNotandi.skraInnskra(virkurNotandi.kennitala);
                if (virkurNotandi.hlutverk != "Umsj�narma�ur")
                {
                    m_tacMain.TabPages.Remove(m_tapUmsjon);
                }
                else
                {
                    if(!m_tacMain.Contains(m_tapUmsjon))
                    {
                        m_tacMain.TabPages.Add(m_tapUmsjon);
                    }
                     
                }
                m_tacMain.SelectedTab = m_tapInnsetning;
                this.WindowState = FormWindowState.Maximized;
               
            }
            else
            {
                m_lblVillaInnSkraning.Visible = true;
                m_lblVillaInnSkraning.Text = "Rangt notendanafn e�a lykilor�";
            }
        }

        private void m_tboNoterndaNafn_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                innskra();
            }
            
        }

        private void m_tapUmsjon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_tacMain.SelectedTab == m_tapGagnaUmsjon)
            {
                uscGagnaUmsjon1.endurHressa();
            }
       }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            m_pnlNotandi.BringToFront();
            virkurNotandi.hreinsaHlut();
            m_tboLykilOrd.Text = string.Empty;
            m_tboNoterndaNafn.Text = string.Empty;
            this.Text = "MHR";
        }

        private void m_btnRecovery_Click(object sender, EventArgs e)
        {
         
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if(result == DialogResult.OK) 
            {
                endurHeimta(folderBrowserDialog1.SelectedPath, folderBrowserDialog1.SelectedPath);
            }
        }

        private void endurHeimta(string strSlod, string strDagsetning)
        {
            //  MessageBox.Show("A") 1. gefa vi�v�run

            // backup _OAIS_10_4_2023.sql
            DialogResult result = MessageBox.Show(string.Format("Viltu endursetja kerfi� fr� �essu afriti {0}. �ll g�gn eftir �ann t�ma hverfa!", strDagsetning), "Endurheimta", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string strBackupfile = string.Empty;
                foreach (String str in Directory.GetFiles(strSlod))
                {
                    if (str.EndsWith(".sql"))
                    {
                        strBackupfile = str;
                    }
                }
               m_lblHvadAfrita.Text = "Endurheimti gagangrunn";
                Application.DoEvents();
                cBackup back = new cBackup();
                back.createDatabase();
                Restore(strBackupfile);
                m_lblHvadAfrita.Text = "T�mi v�rslusv��i";
                Directory.Delete("D:\\AIP", true);
                if (!Directory.Exists("D:\\AIP"))
                {
                    Directory.CreateDirectory("D:\\AIP");
                }

                flytjaAIPafrit("D:\\", strSlod, "Endurheimta"); //vantar a� laga hver er r�tin?
                MessageBox.Show("Endurheimt loki�");
            }


        }
        private void flytjaAIPafrit(string strDest, string strOrg, string strA�ger�)
        {

            //Now Create all of the directories
            m_prgBackup.Maximum = Directory.GetDirectories(strOrg, "*", SearchOption.AllDirectories).Length;
            m_prgBackup.Step = 1;
            m_prgBackup.Value = 0;
            m_lblHvadAfrita.Text = strA�ger� + " m�ppur";
            foreach (string dirPath in Directory.GetDirectories(strOrg, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(strOrg, strDest));
                m_lblHvadAfrita.Text = strA�ger� + " m�ppu " + (dirPath.Replace(strOrg, strDest));
                m_prgBackup.PerformStep();
                m_lblBackupStatus.Text = string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }

            m_prgBackup.Maximum = Directory.GetFiles(strOrg, "*.*", SearchOption.AllDirectories).Length;
            m_prgBackup.Step = 1;
            m_prgBackup.Value = 0;
            m_lblHvadAfrita.Text = strA�ger� + " skr�r";
            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(strOrg, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(strOrg, strDest), true);
                m_lblHvadAfrita.Text = strA�ger� + " skr� " + newPath.Replace(strOrg, strDest);
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
            string constring = "server = localhost; user id = root; Password = ivarBjarkLind; database = db_oais_admin;";
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
    }
}