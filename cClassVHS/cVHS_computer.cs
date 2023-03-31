using System.Xml.Linq;
using System.Management;
using System.Security.Principal;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text.Unicode;
using System.Data;

namespace cClassVHS
{
    public class cVHS_computer
    {
        private int computerID;    
        private string computerName;
        private string computerModel;
        private string computerSerial;
        private DriveInfo[] computerDrives;
        //seríal
        //fjöldi diska
        //stærð diska
        private string m_strTenging =  "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";

        public int ID   // property
        {
            get { return computerID; }   // get method
            set { computerID = value; }  // set method
        }
        public string Name   // property
        {
            get { return computerName; }   // get method
            set { computerName = value; }  // set method
        }
        public string Model
        {
            get { return computerModel; }   // get method
            set { computerModel = value; }  // set method
        }
        public string Serial
        {
            get { return computerSerial; }   // get method
            set { computerSerial = value; }  // set method
        }

        public DriveInfo[] Drives
        {
            get { return computerDrives; }   // get method
            set { computerDrives = value; }  // set method
        }
       
        public cVHS_computer() 
        {
            getComputers();
        }

        public DataTable getAllComputers()
        {
            string strSQL = string.Format("SELECT * FROM dt_computer d;");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        private void getComputers()
        {
            this.Name = Environment.MachineName;

            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            //collection to store all management objects

            mc.Options.UseAmendedQualifiers = true;
            
            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    Model = mo["Model"].ToString();
         
               }
            }

            ManagementObjectSearcher searcher =  new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");

            ManagementObjectCollection information = searcher.Get();
            foreach (ManagementObject obj in information)
            {
                string strSerial = string.Empty;
                foreach (PropertyData data in obj.Properties)
                {
                    Serial = data.Value.ToString();
                }
                
            }

            searcher.Dispose();

            Drives = DriveInfo.GetDrives();

        }
      
        public void saveComputer()
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);

            command.Parameters.AddWithValue("@Model", this.Model);
            command.Parameters.AddWithValue("@Name", this.Name);
            command.Parameters.AddWithValue("@Serial", this.Serial);


            command.CommandText = "INSERT INTO `dt_computer` SET `Model`=@Model, `Name`=@Name, `Serial`=@Serial, `Date`=NOW();";
            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
        public bool erVelTil(string strSerial)
        {
            bool bErTil = false;
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            string strSQL = string.Format("SELECT id FROM db_oais_admin.dt_computer d where Serial= '{0}';", Serial);
            var id = MySqlHelper.ExecuteScalar(conn,strSQL);
            if(id != null)
            {
                ID = Convert.ToInt32(id);
                bErTil = true;  
            }
            return bErTil;

        }
    }
}