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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIS_ADMIN
{
    public partial class uscGeymsluMidlar : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        cVHS_computer comp = new cVHS_computer();
        DataTable m_dtComputers = new DataTable();  
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
            private void Backup()
        {
            string constring = "server = localhost; user id = root; Password = ivarBjarkLind; database = db_oais_admin;";
           // string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
            string file = "C:\\temp\\backup.sql";
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

            if(fRow.Length> 0 ) 
            {
                m_lblHeiti.Text = "Heiti vélar: " + fRow[0]["Name"].ToString();
                m_lblModel.Text = "Tegund vélar: " + fRow[0]["Model"].ToString();
                m_lblSerial.Text = "Serial móðurborðs: " + fRow[0]["Serial"].ToString();
                m_lblID.Text =  "Auðkenni vélar: " + fRow[0]["ID"].ToString();
                m_lblDate.Text = "Tekinn í notkun: " + fRow[0]["Date"].ToString();

            }

         
            cVHS_drives drif = new cVHS_drives();
            DataTable dt = drif.driveComputersAllt(Convert.ToInt32(strTag));
            DataTable dtClone = new DataTable();
            if(dt.Rows.Count > 0 ) 
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
                row["laust"] = drivo.AvailableFreeSpace;
     
              
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
    }
}
