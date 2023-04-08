﻿using cClassOAIS;
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
        public uscGeymsluMidlar()
        {
            InitializeComponent();
            fyllaComputer();
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

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");

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
        private void button1_Click(object sender, EventArgs e)
        {
            //  Backup();
            Restore();
        }
        private void Restore()
        {
            string file = "C:\\temp\\backup.sql";
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
        private void BackupSQL(string strDest)
        {
            string constring = "server = localhost; user id = root; Password = ivarBjarkLind; database = db_oais_admin;"; //gera þetta abastract gegnum stillingar
                                                                                                                          // string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
            string file = strDest;
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
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
                m_lblSerial.Text = "Serial móðurborðs: " + fRow[0]["Serial"].ToString();
                m_lblID.Text = "Auðkenni vélar: " + fRow[0]["ID"].ToString();
                m_lblDate.Text = "Tekinn í notkun: " + fRow[0]["Date"].ToString();

            }

            DataTable dt = drif.driveComputersAllt(Convert.ToInt32(strTag));
            drif.hreinsaHlut();
            drif.getDrif(Convert.ToInt32(dt.Rows[0]["id"]));
            DataTable dtClone = new DataTable();
            if (dt.Rows.Count > 0)
            {
                m_grbDrif.Visible = true;

                dtClone = formatTable(dt);
            }
            else
            {
                m_grbDrif.Visible = false;
            }
            m_dgvDrif.AutoGenerateColumns = false;
            m_dgvDrif.DataSource = dtClone;

            //fylla backup
            m_grbAfritun.Text = string.Format("Afritun af möppu {0} á vél {1}", drif.Nafn, comp.Name);
            fyllaBackuplista();
            string[] strDrives = System.IO.Directory.GetLogicalDrives();
            m_comAfritDrif.DataSource = strDrives;
        }

        private void fyllaBackuplista()
        {
            DataTable dt = backup.getBackup(drif.ID);
            m_dgvBackup.DataSource = formatTableBackup(dt);
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
                row["notad"] = DirSize(difo);
                row["framleitt"] = Convert.ToDateTime(row["framleitt"]);
                dtCloned.ImportRow(row);

                DriveInfo drivo = new DriveInfo(strSlod);
                if (Directory.Exists(strSlod))
                {
                    row["laust"] = drivo.AvailableFreeSpace;
                }
                else
                {
                    row["laust"] = "????";
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


            string strDest = m_comAfritDrif.SelectedItem.ToString() + "\\MHR_BACKUP_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + backup.getNextBackupID(); //má bæta við síðar

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
            flytjaAIPafrit(strAip, drif.Nafn);

            //id, drifid, merking, slodAfrit, steard, hvar_geymt, athugasemdir, hvar_afritadi, dagsetning

            backup.drifid = drif.ID;
            backup.merking = drif.Tegund;
            backup.slodAfrit = strDest;
            backup.steard = m_lStaerd.ToString();
            backup.hvar_geymt = m_comHvarGeymt.SelectedItem.ToString();
            backup.athugasemdir = m_tboAfritATH.Text;
            backup.hvar_afritadi = virkurnotandi.nafn;
            backup.vista();
            fyllaBackuplista();

            string strBackupSQL = strDest + "\\backup _OAIS_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".sql";
            m_lblHvadAfrita.Text = "Afrita gagnagrunn";
            BackupSQL(strBackupSQL);
            MessageBox.Show("Búið");
        }

        private void flytjaAIPafrit(string strDest, string strOrg)
        {

            //Now Create all of the directories
            m_prgBackup.Maximum = Directory.GetDirectories(strOrg, "*", SearchOption.AllDirectories).Length;
            m_prgBackup.Step = 1;
            m_prgBackup.Value = 0;
            m_lblHvadAfrita.Text = "Afrita möppur";
            foreach (string dirPath in Directory.GetDirectories(strOrg, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(strOrg, strDest));
                m_lblHvadAfrita.Text = "Afrita möppu " + (dirPath.Replace(strOrg, strDest));
                m_prgBackup.PerformStep();
                m_lblBackupStatus.Text = string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }

            m_prgBackup.Maximum = Directory.GetFiles(strOrg, "*.*", SearchOption.AllDirectories).Length;
            m_prgBackup.Step = 1;
            m_prgBackup.Value = 0;
            m_lblHvadAfrita.Text = "Afrita skrár";
            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(strOrg, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(strOrg, strDest), true);
                m_lblHvadAfrita.Text = "Afrita skrá " + newPath.Replace(strOrg, strDest);
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
                    MessageBox.Show("Klára þetta manni");
                }
            }
        }
    }
}
