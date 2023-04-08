using ByteSizeLib;
using cClassVHS;
using System.Data;

namespace VHS_OAIS
{

    public partial class Form1 : Form
    {
        DataTable m_dtDrif = new DataTable();
        DataTable m_dtDrifVirk = new DataTable();
        DataTable m_dtDrifOvirk = new DataTable();
        cVHS_computer cComputer = new cVHS_computer();
        cVHS_drives cDrive = new cVHS_drives();
        cVHS_files cFiles = new cVHS_files();
        public Form1()
        {
            InitializeComponent();
            m_dtDrif.Columns.Add("id");
            m_dtDrif.Columns.Add("nafn");
            m_dtDrif.Columns.Add("format");
            m_dtDrif.Columns.Add("laust");
            m_dtDrif.Columns.Add("Heild");
            m_dtDrif.Columns.Add("Tegund");
            m_dtDrif.Columns.Add("Framleitt");
            getComputer();
             
        }

    
        public void getComputer()
        {
           m_dtDrif.Rows.Clear();
          
            if(!cComputer.erVelTil(cComputer.Serial))
            {
                cComputer.saveComputer();
            }

            m_lblHeiti.Text = "Heiti vélar: " + cComputer.Name;  
            m_lblModel.Text = "Model: " + cComputer.Model;
            m_lblSerial.Text = "Serial móðuborðs: " + cComputer.Serial;
            m_lblID.Text = "ID: " + cComputer.ID;

            foreach (DriveInfo difo in cComputer.Drives) 
            {
                DataRow r = m_dtDrif.NewRow();
                r["id"] = 0;
                r["nafn"] = difo.Name;
                r["format"] = difo.DriveFormat;
                r["laust"] = ByteSize.FromBytes(difo.AvailableFreeSpace);
                r["heild"] = ByteSize.FromBytes(difo.TotalSize);
                r["tegund"] = difo.VolumeLabel;
                r["framleitt"] = difo.RootDirectory.CreationTime;
                m_dtDrif.Rows.Add(r);
                m_dtDrif.AcceptChanges();
            }
            m_dtDrifVirk = cDrive.driveComputers(cComputer.ID);
            m_dtDrifOvirk = cDrive.driveOvirkComputers();
            if(m_dtDrifOvirk.Rows.Count > 0) 
            {
                m_grbOvirkDrif.Visible = true;
                m_dtDrifOvirk = cDrive.driveOvirkComputers();
                m_dgvDrifOvirk.DataSource = m_dtDrifOvirk;
            }
            else
            {
                m_grbOvirkDrif.Visible = false;
            }
      
            watch();
            m_dgvDrives.DataSource = m_dtDrif;
            foreach(DataGridViewRow r in m_dgvDrives.Rows)
            {
                string strExpression = "nafn like '" + r.Cells["colDrifNafn"].Value.ToString() + "%'";
                DataRow[] fRow = m_dtDrifVirk.Select(strExpression);
                if(fRow.Length > 0 ) 
                {
                     r.Cells["colDrifNafn"].Value = fRow[0]["nafn"].ToString();
                    r.Cells["colDrifID"].Value = fRow[0]["ID"].ToString();
                    r.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
         
      
        }

       
        private void watch()
        {
            int i = 1;
            foreach(DataRow r in m_dtDrifVirk.Rows)
            {
               if(i == 1)
                {
                    string strSlod = r["nafn"].ToString();
                    fileSystemWatcher1.Path = strSlod;
                    //fileSystemWatcher1.InternalBufferSize= 4096;    
                  
                }
                if(i == 2) 
                {

                    string strSlod = r["nafn"].ToString();
                    fileSystemWatcher2.Path = strSlod;
                }

                i++;
               

            }
        }
    
         private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void m_dgvDrives_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == colDrifVelja.Index) 
            {
                DialogResult result = folderBrowserDialog1.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    
                    if(folderBrowserDialog1.SelectedPath.StartsWith(cComputer.Drives[e.RowIndex].Name))
                    {
                        cDrive.comID = cComputer.ID;
                        m_dtDrifVirk = cDrive.driveComputers(cDrive.comID);
                        cDrive.Nafn = folderBrowserDialog1.SelectedPath;
                        DriveInfo difo = new DriveInfo(cDrive.Nafn);
                        bool bErVirkt = false;
                        int iGamla = 0;
                        string strDrifNafn = m_dgvDrives.Rows[e.RowIndex].Cells["colDrifNafn"].Value.ToString(); //núverandi rótarmappa
                        
                        if(strDrifNafn == folderBrowserDialog1.SelectedPath)
                        {
                            return;
                        }
                        
                        DataTable dt = m_dtDrifOvirk.Copy();
                        dt .Merge(m_dtDrifVirk);
                        foreach(DataRow rr in dt.Rows)
                        {
                            if (rr["nafn"].ToString() == cDrive.Nafn)
                            {
                                cDrive.geraVirktOvirkt(1, Convert.ToInt32(rr["id"]));
                                cDrive.geraVirktOvirkt(0,strDrifNafn);
                                getComputer();
                                return;
                            }
                        }
                        foreach (DataRow row in m_dtDrifVirk.Rows)
                        {
                            if(difo.Name != cDrive.Nafn)
                            {
                                if (row["nafn"].ToString().StartsWith(difo.Name))
                                {
                                    bErVirkt = true;
                                    iGamla = Convert.ToInt32(row["id"]);
                                }
                            }
                        }

                        cDrive.geraVirktOvirkt(0,iGamla);                      
                        cDrive.Format = cComputer.Drives[e.RowIndex].DriveFormat;
                        cDrive.Laust = cComputer.Drives[e.RowIndex].AvailableFreeSpace.ToString();
                        cDrive.Heild = cComputer.Drives[e.RowIndex].TotalSize.ToString();
                        cDrive.Tegund = cComputer.Drives[e.RowIndex].VolumeLabel;
                        cDrive.Framleitt = cComputer.Drives[e.RowIndex].RootDirectory.CreationTime.ToString();
                        cDrive.Virk = 1;
                        cDrive.saveDrive(folderBrowserDialog1.SelectedPath);

                        m_dtDrifVirk = cDrive.driveComputers(cComputer.ID);
                        m_dtDrifOvirk = cDrive.driveOvirkComputers();
                        getComputer();
                        //m_dgvDrifOvirk.AutoGenerateColumns = false;
                        //m_dgvDrives.AutoGenerateColumns = false;
                        //m_dgvDrifOvirk.DataSource= m_dtDrifOvirk;
                        //m_dgvDrives.DataSource = m_dtDrifVirk;

                       
                        foreach (DataGridViewRow r in m_dgvDrives.Rows)
                        {
                            string strExpression = "nafn like '" + r.Cells["colDrifNafn"].Value.ToString() + "%'";
                            DataRow[] fRow = m_dtDrifVirk.Select(strExpression);
                            if (fRow.Length > 0)
                            {
                                r.Cells["colDrifNafn"].Value = fRow[0]["nafn"].ToString();
                                r.DefaultCellStyle.BackColor = Color.LightGreen;
                            }
                        }
                        watch();
                    }
                    else
                    {
                        MessageBox.Show("Vitlaust drif valið, á að vera " + cComputer.Drives[e.RowIndex].Name);
                    }
              

                }
            }
           
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher fsw = sender as FileSystemWatcher;
            cVHS_files file = new cVHS_files();
            file.Path = e.FullPath;
            file.Name = e.Name;
            file.Event = e.ChangeType.ToString();


            DriveInfo difo = new DriveInfo(file.Path);
            file.Laust  = (long) Convert.ToDouble (difo.AvailableFreeSpace);
            string strSelect = "nafn='" + fsw.Path + "'";
            DataRow[] fRow = m_dtDrifVirk.Select(strSelect);
            if (fRow.Length > 0)
            {
                file.Drive = Convert.ToInt32(fRow[0]["id"]);
            }
            else
            {
                file.Drive = 0; //ef þetta klikkar.
            }
        
            file.saveFile();
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher fsw = sender as FileSystemWatcher;
            cVHS_files file = new cVHS_files();
            file.Path = e.FullPath;
            file.Name = e.Name;
            file.Event = e.ChangeType.ToString();
         

            DriveInfo difo = new DriveInfo(file.Path);
            file.Laust =  (long)Convert.ToDouble(difo.AvailableFreeSpace);
            string strSelect = "nafn='" + fsw.Path + "'";
            DataRow[] fRow = m_dtDrifVirk.Select(strSelect);
            if (fRow.Length > 0)
            {
                file.Drive = Convert.ToInt32(fRow[0]["id"]);
            }
            else
            {
                file.Drive = 0; //ef þetta klikkar.
            }
            file.saveFile();
        }

        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher fsw = sender as FileSystemWatcher;
            cVHS_files file = new cVHS_files();
            file.Path = e.FullPath;
            file.Name = e.Name;
            file.Event = e.ChangeType.ToString();


            DriveInfo difo = new DriveInfo(file.Path);
            file.Laust = (long)Convert.ToDouble(difo.AvailableFreeSpace);
            string strSelect = "nafn='" + fsw.Path + "'";
            DataRow[] fRow = m_dtDrifVirk.Select(strSelect);
            if (fRow.Length > 0)
            {
                file.Drive = Convert.ToInt32(fRow[0]["id"]);
            }
            else
            {
                file.Drive = 0; //ef þetta klikkar.
            }
            file.saveFile();
        }

        private void fileSystemWatcher1_Error(object sender, ErrorEventArgs e)
        {
            FileSystemWatcher fsw = sender as FileSystemWatcher;
            cVHS_files file = new cVHS_files();
            file.Villa =  e.GetException().ToString();
            file.Event = "Error";
            file.Name = "Villa";
            file.Path = "Villa";
            DriveInfo difo = new DriveInfo(fsw.Path);
            file.Laust = (long)Convert.ToDouble(difo.AvailableFreeSpace);

            string strSelect = "nafn='" + fsw.Path + "'";
            DataRow[] fRow = m_dtDrifVirk.Select(strSelect);
            if (fRow.Length > 0)
            {
                file.Drive = Convert.ToInt32(fRow[0]["id"]);
            }
            else
            {
                file.Drive = 0; //ef þetta klikkar.
            }
            file.saveFile();
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            FileSystemWatcher fsw = sender as FileSystemWatcher;
            cVHS_files file = new cVHS_files();
            file.Path = e.FullPath;
            file.Name = e.Name;
            file.Event = e.ChangeType.ToString();
            file.OldName = e.OldName;


            DriveInfo difo = new DriveInfo(file.Path);
            file.Laust =  (long)Convert.ToDouble(difo.AvailableFreeSpace);
            string strSelect = "nafn='" + fsw.Path + "'";
            DataRow[] fRow = m_dtDrifVirk.Select(strSelect);
            if (fRow.Length > 0)
            {
                file.Drive = Convert.ToInt32(fRow[0]["id"]);
            }
            else
            {
                file.Drive = 0; //ef þetta klikkar.
            }
            file.saveFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDrif frmDrif = new frmDrif();
            frmDrif.ShowDialog();
        }

        private void m_dgvDrives_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow r in m_dgvDrives.Rows)
            {
                string strExpression = "nafn like '" + r.Cells["colDrifNafn"].Value.ToString() + "%'";
                DataRow[] fRow = m_dtDrifVirk.Select(strExpression);
                if (fRow.Length > 0)
                {
                   // r.Cells["colDrifNafn"].Value = fRow[0]["nafn"].ToString();
                    r.DefaultCellStyle.BackColor = Color.LightGreen;
                   if (e.ColumnIndex == colDrifVelja.Index)
                    {
                        e.Value = "Veldu möppu";
                    }
                }
                else
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                    
                }
            }
        }

        private void m_dgvDrives_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete) 
            {
                int iD = Convert.ToInt32(m_dgvDrives.SelectedRows[0].Cells["colDrifID"].Value);
                int iFjoldi = 0;
                if (iD > 0) 
                {
                    iFjoldi = cFiles.FjoldiDrif(iD); 
                }
                if(iFjoldi> 0) 
                {
                   DialogResult result = MessageBox.Show(string.Format("Það eru {0} færslur á drifi? ekki hægt að eyða - gera drifið óvirkt?", iFjoldi.ToString()),"Eyða drifi", MessageBoxButtons.YesNo);
                    if(DialogResult.Yes == result)
                    {
                        cDrive.geraVirktOvirkt(0, iD);
                        getComputer();
                    }
                }
                else 
                {
                   DialogResult result =  MessageBox.Show("Engar færslur skráðar, eyða drifi", "Eyða drifi", MessageBoxButtons.YesNo);
                   if(DialogResult.Yes == result) 
                   {
                        cDrive.EyðaDrifi(iD);
                        getComputer();
                    }
                }
     
            }
        }

        private void m_dgvDrifOvirk_KeyUp(object sender, KeyEventArgs e)
        {
            int iD = Convert.ToInt32(m_dgvDrifOvirk.SelectedRows[0].Cells["colDrivOvirktID"].Value);
            int iFjoldi = 0;
            if (iD > 0)
            {
                iFjoldi = cFiles.FjoldiDrif(iD);
            }
            if (iFjoldi > 0)
            {
                MessageBox.Show(string.Format("Það eru {0} færslur á drifi? ekki hægt að eyða", iFjoldi.ToString()));
            }
            else
            {
                DialogResult result = MessageBox.Show("Engar færslur skráðar, eyða drifi", "Eyða drifi", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    cDrive.EyðaDrifi(iD);
                    getComputer();
                }
            }
        }
    }
}