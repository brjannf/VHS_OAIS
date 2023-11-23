using cClassOAIS;
using cClassVHS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIS_ADMIN
{
    public partial class uscGeymsluMidlar : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        cBackup backup = new cBackup();
        cVHS_computer comp = new cVHS_computer();
        cVHS_drives drif = new cVHS_drives();
        DataTable m_dtComputers = new DataTable();
        long m_lStaerd = 0;
        long m_lNotad = 0;
        public uscGeymsluMidlar()
        {
            InitializeComponent();
            fyllaComputer();
            getSize();
         


        }

        private  async Task<long> getSize(string bla = "D:\\AIP")
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(bla);
                if (dirInfo.Exists)
                {

                  m_lNotad = await Task.Run(() => dirInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum(file => file.Length));
                }
            }
            catch (Exception x)
            {

               //throw;
            }
         
            return m_lNotad;
        }

        private void fyllaComputer()
        {
            m_dtComputers = comp.getAllComputers();
            foreach (DataRow dr in m_dtComputers.Rows)
            {
                TreeNode n = new TreeNode(dr["Name"].ToString());

                n.Tag = dr["id"].ToString();
                m_trwTolvur.Nodes.Add(n);
                if (getSerial() == dr["Serial"].ToString())
                {
                    n.BackColor = Color.LightGreen;
                }
                else
                {
                    n.BackColor = Color.LightPink;
                }


            }
        }

        private string getSerial()
        {
            string strRet = string.Empty;
            this.Name = Environment.MachineName;

            //ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ////collection to store all management objects

            //mc.Options.UseAmendedQualifiers = true;

            //ManagementObjectCollection moc = mc.GetInstances();
            //if (moc.Count != 0)
            //{
            //    foreach (ManagementObject mo in mc.GetInstances())
            //    {
            //        strRet = mo["Model"].ToString();

            //    }
            //}

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_bios");

            ManagementObjectCollection information = searcher.Get();
            foreach (ManagementObject obj in information)
            {
                string strSerial = string.Empty;
                foreach (PropertyData data in obj.Properties)
                {
                    strRet = data.Value.ToString();
                }
            }

            searcher.Dispose();
            return strRet;


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
        private void BackupSQL(string strDest, string strDatabase)
        {
            string constring = "server = localhost; user id = root; Password = ivarBjarkLind; database =" + strDatabase + ";"; //gera þetta abastract gegnum stillingar
                                                                                                                          // string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
          
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(strDest);
                            conn.Close();
                            cmd.Dispose();
                            conn.Dispose();
                       
                    }
                }
            }
        }

        private void m_trwTolvur_AfterSelect(object sender, TreeViewEventArgs e)
        {

            string strTag = e.Node.Tag.ToString();

            string strEXP = "id='" + strTag + "'";
            DataRow[] fRow = m_dtComputers.Select(strEXP);

            if (fRow.Length > 0)
            {
                m_lblHeiti.Text = "Heiti vélar: " + fRow[0]["Name"].ToString();
                m_lblModel.Text = "Tegund vélar: " + fRow[0]["Model"].ToString();
                m_lblSerial.Text = "Serial: " + fRow[0]["Serial"].ToString();
                m_lblID.Text = "Auðkenni vélar: " + fRow[0]["ID"].ToString();
                m_lblDate.Text = "Tekinn í notkun: " + fRow[0]["Date"].ToString();

            }
            m_grValinVel.Visible = true;
            Application.DoEvents();
            DataTable dt = drif.driveComputersAllt(Convert.ToInt32(strTag));
            drif.hreinsaHlut();
            drif.getDrif(Convert.ToInt32(dt.Rows[0]["id"]));
            DataTable dtClone = new DataTable();
            if (dt.Rows.Count > 0)
            {
                m_grbDrif.Visible = true;
                //Thread thread = new Thread(new ParameterizedThreadStart(formatTableThreat));
                //thread.Start(dt);


                dtClone = formatTable(dt);
            }
            else
            {
                m_grbDrif.Visible = false;
            }
            m_dgvDrif.AutoGenerateColumns = false;
            m_dgvDrif.DataSource = dtClone;
            m_grbDrif.Visible = true;
            //fylla backup
            m_grbAfritun.Text = string.Format("Afritun af möppu {0} á vél {1}", drif.Nafn, comp.Name);
            fyllaBackuplista();
            string[] strDrives = System.IO.Directory.GetLogicalDrives();
            DataTable dtDrif = new DataTable();
            dtDrif.Columns.Add("drif");
            foreach (string strDrive in strDrives) 
            {
                DataRow row= dtDrif.NewRow();
                row["drif"] = strDrive;
                dtDrif.Rows.Add(row);
                dtDrif.AcceptChanges();
            }
            DataRow rV= dtDrif.NewRow();
            rV["drif"] = "Veldu drif";
            dtDrif.Rows.InsertAt(rV, 0);
            m_comAfritDrif.DisplayMember = "drif";
            m_comAfritDrif.ValueMember = "drif";
            m_comAfritDrif.DataSource = dtDrif;
            m_grbAfritun.Visible = true;
        }

        private void fyllaBackuplista()
        {
            DataTable dt = backup.getBackup(drif.ID);
            m_dgvBackup.DataSource = formatTableBackup(dt);
            m_grbAfritunListi.Text = string.Format("Afrit tekinn ({0})", dt.Rows.Count);
            foreach (DataGridViewRow r in m_dgvBackup.Rows)
            {
                string strDir = r.Cells["colBackSlod"].Value.ToString();
                if (Directory.Exists(strDir))
                {
                    r.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void m_dgvDrif_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colbtnOpna"].Index == e.ColumnIndex)
                {
                    string strSlod = senderGrid.Rows[e.RowIndex].Cells["colSlod"].Value.ToString();

                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(strSlod)
                    {
                        UseShellExecute = true
                    };
                    p.Start();


                }

                if (senderGrid.Columns["colbtnSkoda"].Index == e.ColumnIndex)
                {
                    string drifID = senderGrid.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                    frmFileLoggur frmLoggur = new frmFileLoggur(drifID);
                    frmLoggur.ShowDialog();


                }
            }

        }

        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.1;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }
        private DataTable formatTableBackup(DataTable dt)
        {
            DataTable dtCloned = dt.Clone();
            dtCloned.Columns["steard"].DataType = typeof(string);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);


            }
            foreach (DataRow r in dtCloned.Rows)
            {
                long staerd = (long)Convert.ToDouble(r["steard"]);
                r["steard"] = FormatBytes(staerd);
            }

            return dtCloned;
        }
        public void formatTableThreat(object ob)
        {
            DataTable dt = (DataTable)ob;
            DataTable dtCloned = dt.Clone();
            m_dgvDrif.AutoGenerateColumns = false;
            m_dgvDrif.DataSource = dtCloned;
            m_grbDrif.Visible = true;
        }
        private DataTable formatTable(DataTable dt)
        {
            DataTable dtCloned = dt.Clone();
            dtCloned.Columns["laust"].DataType = typeof(string);
            dtCloned.Columns["heild"].DataType = typeof(string);
            dt.Columns.Add("notad");
            dtCloned.Columns.Add("notad");
            foreach (DataRow row in dt.Rows)
            {
                //long laust = (long)Convert.ToDouble(row["laust"]);
                //long heild = (long)Convert.ToDouble(row["heild"]);
                //row["notad"] = heild - laust;
                string strSlod = row["nafn"].ToString();
                DirectoryInfo difo = new DirectoryInfo(strSlod);



                row["notad"] = m_lNotad; // DirSize(difo);
                row["framleitt"] = Convert.ToDateTime(row["framleitt"]);
                dtCloned.ImportRow(row);

                DriveInfo drivo = new DriveInfo(strSlod);
                if (Directory.Exists(strSlod))
                {
                    row["laust"] = drivo.AvailableFreeSpace;
                }
                else
                {
                    row["laust"] = "na";
                }



            }

            foreach (DataRow r in dtCloned.Rows)
            {
                long laust = (long)Convert.ToDouble(r["laust"]);
                r["laust"] = FormatBytes(laust);
                long heild = (long)Convert.ToDouble(r["heild"]);
                r["heild"] = FormatBytes(heild);
                long notad = (long)Convert.ToDouble(r["notad"]);
                r["notad"] = FormatBytes(notad);


            }
            return dtCloned;
        }

        public static long DirSize(DirectoryInfo d)
        {
            try
            {

                long size = 0;
                // Add file sizes.
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di);
                }
                return size;
            }
            catch (Exception x)
            {
                return -1;
                // throw;
            }
        }

        private void m_btnTakaAfrit_Click(object sender, EventArgs e)
        {
            //1.

            string strDest = m_comAfritDrif.SelectedValue.ToString() + "\\MHR_BACKUP_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + backup.getNextBackupID(); //má bæta við síðar

            if (!Directory.Exists(strDest))
            {
                Directory.CreateDirectory(strDest);
            }
            DirectoryInfo difo = new DirectoryInfo(drif.Nafn);
            string strAip = strDest + "\\" + difo.Name;
            if (!Directory.Exists(strAip))
            {
                Directory.CreateDirectory(strAip);
            }
            CopyFolder( drif.Nafn, strAip);
          //  flytjaAIPafrit(strAip, drif.Nafn, "Afrita");

            //id, drifid, merking, slodAfrit, steard, hvar_geymt, athugasemdir, hvar_afritadi, dagsetning
            DriveInfo drivo = new DriveInfo(m_comAfritDrif.SelectedValue.ToString());
            backup.drifid = drif.ID;
            backup.merking =drivo.VolumeLabel;
            backup.slodAfrit = strDest;
            backup.steard = m_lStaerd.ToString();
            backup.hvar_geymt = m_comHvarGeymt.SelectedItem.ToString();
            backup.athugasemdir = m_tboAfritATH.Text;
            backup.hvar_afritadi = virkurnotandi.nafn;
            backup.vista();
          

            string strBackupSQL = strDest + "\\backup _OAIS_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".sql";
            m_lblHvadAfrita.Text = "Afrita gagnagrunn";
            BackupSQL(strBackupSQL, "db_oais_admin");
           // BackupSQL(strBackupSQL, "avid_sa_18006_filesystem");

            DataTable dt = backup.getAllDatabases();
           
            foreach (DataRow r in dt.Rows)
            {
                string strDatabase = r["SCHEMA_NAME"].ToString(); ;
                m_lblHvadAfrita.Text = "Afrita: " + strDatabase;
                strBackupSQL = strDest + "\\backup _OAIS_" + strDatabase + "_"  + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".sql";
                BackupSQL(strBackupSQL, strDatabase);
              
            }

            fyllaBackuplista();
            MessageBox.Show("Búið");
        }
        //temp redding meðan NAS boxið virkar ekki með flytjAIPafrit
        private void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            m_prgBackup.Maximum = files.Length;
            m_prgBackup.Step = 1;
         //   m_prgBackup.Value = 0;
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest,true);
                m_prgBackup.PerformStep();
                m_lblBackupStatus.Text = string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            m_prgBackup.Maximum = folders.Length;
            m_prgBackup.Step = 1;
        //    m_prgBackup.Value = 0;
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
                m_prgBackup.PerformStep();
                m_lblBackupStatus.Text = string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
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
                m_lStaerd += fifo.Length;
                m_prgBackup.PerformStep();
                m_lblBackupStatus.Text = string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }

        }

        private void m_dgvBackup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colBackBtnOpna"].Index == e.ColumnIndex)
                {
                    string strSlod = senderGrid.Rows[e.RowIndex].Cells["colBackSlod"].Value.ToString();
                    if(Directory.Exists(strSlod))
                    {
                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(strSlod)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                    else
                    {
                        MessageBox.Show("Gleymdirðu að tengja diskinn góurinn?");
                    }
                   
                }
                if (senderGrid.Columns["colBackBtnRestore"].Index == e.ColumnIndex)
                {
                    string strBackup = senderGrid.Rows[e.RowIndex].Cells["colBackSlod"].Value.ToString();
                    string strDagsetning = senderGrid.Rows[e.RowIndex].Cells["colBackDags"].Value.ToString();
                    if (!Directory.Exists(strBackup))
                    {
                        DialogResult result = MessageBox.Show(string.Format("Finn ekki slóðina {0} viltu fletta möppunni upp?", strBackup), "Endurheimt", MessageBoxButtons.YesNo);
                        if(result == DialogResult.Yes)
                        {
                           result = folderBrowserDialog1.ShowDialog();
                            if(result == DialogResult.OK)
                            {
                                endurHeimta(folderBrowserDialog1.SelectedPath, strDagsetning);
                            }

                        }
                    }
                    else
                    {
                        endurHeimta(strBackup, strDagsetning);
                    }
                }
            }
        }

        private void endurHeimta(string strSlod, string strDagsetning)
        {
            //  MessageBox.Show("A") 1. gefa viðvörun

            // backup _OAIS_10_4_2023.sql
            DialogResult result = MessageBox.Show(string.Format("Viltu endursetja kerfið einsog það var {0}. Öll gögn eftir þann tíma hverfa!", strDagsetning), "Endurheimta", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes ) 
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
                string[] strSQLFiles = Directory.GetFiles(strSlod);
                foreach(string str in strSQLFiles)
                {
                    FileInfo fifo = new FileInfo(str);
                    if(fifo.Extension == ".sql")
                    {
                        Restore(str);
                    }
                }
            //    Restore(strBackupfile);
                m_lblHvadAfrita.Text = "Tæmi vörslusvæði";
                Directory.Delete(drif.Nafn, true);
                if (!Directory.Exists(drif.Nafn))
                {
                    Directory.CreateDirectory(drif.Nafn);
                }

                flytjaAIPafrit(drif.Nafn.Replace("AIP", ""), strSlod, "Endurheimta"); //vantar að laga hver er rótin?
                MessageBox.Show("Endurheimt lokið");
            }
     
          
        }

        private void m_dgvBackup_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in m_dgvBackup.Rows)
            {
                string strDir = r.Cells["colBackSlod"].Value.ToString();
                if (Directory.Exists(strDir))
                {
                    r.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }
    }
}
