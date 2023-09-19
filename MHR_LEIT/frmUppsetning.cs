using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cClassOAIS;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

using static cClassVHS.cSkyrslur;

namespace MHR_LEIT
{
    public partial class frmUppsetning : Form
    {
        string m_strUpphaf = string.Empty;
        string m_strEnda = string.Empty;
        cMIdlun mIdlun = new cMIdlun();
        public frmUppsetning()
        {
            InitializeComponent();
            m_btnKeyra.BackColor = Color.LightPink;
            m_btnKeyra.Enabled = false; 
        }

        private void m_btnAfrit_Click(object sender, EventArgs e)
        {
            DialogResult result =  folderBrowserDialog1.ShowDialog();

            if(result == DialogResult.OK) 
            {
                m_strUpphaf=folderBrowserDialog1.SelectedPath;
                m_lblUpphaf.Text = m_strUpphaf;
                m_btnAfrit.BackColor = Color.LightGreen;
                if(m_strEnda .Length > 0 && m_strUpphaf.Length >0)
                {
                    m_btnKeyra.BackColor = Color.LightYellow;
                    m_btnKeyra.Enabled = true;
                }
            }

        }

        private void m_btnVeljaDrif_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                m_strEnda = folderBrowserDialog1.SelectedPath;
                m_lblEnda.Text = m_strEnda;
                m_btnVeljaDrif.BackColor= Color.LightGreen;
                if (m_strEnda.Length > 0 && m_strUpphaf.Length > 0)
                {
                    m_btnKeyra.BackColor = Color.LightYellow;
                    m_btnKeyra.Enabled = true;
                }
            }
        }

        private void m_btnKeyra_Click(object sender, EventArgs e)
        {
            if (m_strUpphaf != string.Empty && m_strEnda != string.Empty)
            {
                //1. Setja upp Meta grunn
                m_lblBuaTil1.BackColor = Color.LightYellow;
                Application.DoEvents();
                string strGrunnur = m_strUpphaf + "\\SQL_META_AFRIT\\OAIS_ADMIN_AFRIT.sql";
                Restore(strGrunnur, string.Empty);
                string strInnsert = m_strUpphaf + "\\SQL_META_AFRIT\\INSERT.sql";
                //2. Keyra inn gögn í Meta grunn
                m_lblBuaTil1.BackColor = Color.LightGreen;
                m_lblKEyraInn2.BackColor = Color.LightYellow;
                Application.DoEvents();
                mIdlun.scriptLoad(strInnsert);
                //3 restor gagangrunn og flytja AIP á rétta stað.
                m_lblKEyraInn2.BackColor = Color.LightGreen;
                Application.DoEvents();
                string strVarsla = m_strUpphaf + "\\Vörsluútgáfur";
                string strAfritEnda = string.Empty;
                string strVorsluutgafur = string.Empty;
                int i = 1;
                if (Directory.Exists(strVarsla))
                {
                    string[] strDir = Directory.GetDirectories(strVarsla);  
                    foreach(string strDir2 in strDir) 
                    {
                        //búa til gagangrunn
                        string[] strGogn = Directory.GetDirectories(strDir2);
                        foreach (string str in strGogn)
                        {
                            if (str.EndsWith("SQL"))
                            {
                                string[] strFile = Directory.GetFiles(str);
                                if (strFile.Length == 1 && strFile[0].EndsWith(".Sql"))
                                {
                                    FileInfo fifo = new FileInfo(strFile[0]);
                                   // m_lblBuaTil1.Text = "Bý til gagnagrunn " + fifo.Name.Replace(fifo.Extension, "");
                                    Application.DoEvents();
                                    m_lblAfrita4.BackColor = Color.LightYellow;
                                    m_lblKEyraGagn3.BackColor = Color.LightYellow;
                                    m_lblKEyraGagn3.Text = m_lblKEyraGagn3.Text + string.Format(" {0}/{1}", i.ToString(), strDir.Length);
                                    Application.DoEvents();
                                    Restore(strFile[0], fifo.Name.Replace(fifo.Extension, ""));
                                }
                            }
                            else
                            {
                                string[] strSplit = str.Split("\\");
                                strAfritEnda = m_strEnda + "\\AIP";
                                if (!Directory.Exists(strAfritEnda))
                                {
                                    Directory.CreateDirectory(strAfritEnda);
                                }
                                strAfritEnda = strAfritEnda + "\\" + strSplit[strSplit.Length - 1];
                                if (!Directory.Exists(strAfritEnda))
                                {
                                    Directory.CreateDirectory(strAfritEnda);
                                }
                                strVorsluutgafur += strSplit[strSplit.Length - 1] + "|";
                                                           
                                m_lblAfrita4.BackColor = Color.LightYellow;
                                m_lblKEyraGagn3.BackColor = Color.LightYellow;
                                m_lblAfrita4.Text = m_lblAfrita4.Text + string.Format(" {0}/{1}", i.ToString(), strDir.Length);
                                Application.DoEvents();
                                CopyFolder(str, strAfritEnda);
                            }
                        }
                       
                    }
                    i++;
                }

                m_lblKEyraGagn3.BackColor = Color.LightGreen;
                m_lblAfrita4.BackColor = Color.LightGreen;
                m_lblUppfæra5.BackColor = Color.LightYellow;
                Application.DoEvents();
                //4 uppfæra slóðir gagnagrunns
                //a. upphafsdrif
                cClassVHS.cVHS_drives drive = new cClassVHS.cVHS_drives();
                drive.m_bAfrit = true;
                drive.uppfæradrifAfrit(m_strEnda + "\\AIP");
                //staðsetning vörsluútgáfna
                cVorsluutgafur utgafur = new cVorsluutgafur();
                utgafur.m_bAfrit = true;
                string[] strSpliter = strVorsluutgafur.Split("|");
                foreach(string str in strSpliter )
                {
                    if(!str.StartsWith("FRUM") && str != string.Empty)
                    {
                        utgafur.getVörsluútgáfu(str);
                        utgafur.slod = m_strEnda + "\\AIP\\" + str;
                        utgafur.vista();
                    }

                }

                m_lblUppfæra5.BackColor = Color.LightGreen;
                m_btnKeyra.BackColor = Color.LightGreen;
                Application.DoEvents();

                DialogResult result = MessageBox.Show("Aðgerð lokið, loka glugga og opna forrit", "Aðgerð lokið");
                if(result == DialogResult.OK)
                {
                    this.Close();
                }
            //   mIdlun.bulkLoad(strInnsert); 
              //  string strScript = File.ReadAllText(strInnsert);

              //  string[] strSplit = strScript.Split(";");

              //  DataTable dtInnsert = new DataTable();
              //  dtInnsert.Columns.Add("keyra");
              //   int i = 0;
              //   foreach(string str in strSplit) 
              //  {
              //      DataRow r = dtInnsert.NewRow();
              //      r["keyra"] = str;
              //      dtInnsert.Rows.Add(r);
              //      dtInnsert.AcceptChanges();
              //      m_lblStatus.Text = string.Format("Les {0}/1{1}", i, strSplit.Length);
              //      Application.DoEvents(); 
              //      i++;

              //  }
             
              //i= 0;
              //  foreach(DataRow rr in dtInnsert.Rows)
              //  {
              //      string strSQL = rr["keyra"].ToString();
              //      mIdlun.insertFyrirspurn(strSQL, "db_oais_admin_afrit");
              //      m_lblStatus.Text = string.Format("Keyri inn {0}/1{1}", i, dtInnsert.Rows.Count);
              //      Application.DoEvents();
              //  }
            }
        }

        private void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            //m_prgBackup.Maximum = files.Length;
            //m_prgBackup.Step = 1;
            //m_prgBackup.Value = 0;
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
                //m_prgBackup.PerformStep();
                //m_lblBackupStatus.Text = file; // string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            //m_prgBackup.Maximum = folders.Length;
            //m_prgBackup.Step = 1;
            //m_prgBackup.Value = 0;
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
                //m_prgBackup.PerformStep();
                //m_lblBackupStatus.Text = folder; // string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }
        }
        private void Restore(string strRestoreFile, string strDataBase)
        {
            string file = strRestoreFile;
            string constring = string.Empty;
            if (strDataBase != string.Empty)
            {
                mIdlun.createDatabase(strDataBase);
                constring = "server = localhost; user id = root; Password = ivarBjarkLind; database = " + strDataBase +";";
            }
            else
            {
                constring = "server = localhost; user id = root; Password = ivarBjarkLind;"; // database = db_oais_admin_afrit;";
            }
          //  constring = "server = localhost; user id = root; Password = ivarBjarkLind;"; // database = db_oais_admin_afrit;";
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

        private void m_lblEnda_Click(object sender, EventArgs e)
        {

        }
    }
}
