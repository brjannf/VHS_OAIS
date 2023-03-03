using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassVHS
{
    public class cVHS_files
    {
        private int iID;
        private int ifileDrive;
        private string fileEvent;
        private string fileOldName;
        private string fileName;
        private string filePath;
        private long driveLaust;
        private string fileVilla;

        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";

        public int ID   // property
        {
            get { return iID; }   // get method
            set { iID = value; }  // set method
        }
        public int Drive   // property
        {
            get { return ifileDrive; }   // get method
            set { ifileDrive = value; }  // set method
        }
        public string Event
        {
            get { return fileEvent; }   // get method
            set { fileEvent = value; }  // set method
        }
        public string OldName
        {
            get { return fileOldName; }   // get method
            set { fileOldName = value; }  // set method
        }
        public string Name
        {
            get { return fileName; }   // get method
            set { fileName = value; }  // set method
        }
        public string Path
        {
            get { return filePath; }   // get method
            set { filePath = value; }  // set method
        }
        public long Laust
        {
            get { return driveLaust; }   // get method
            set { driveLaust = value; }  // set method
        }
        public string Villa
        {
            get { return fileVilla; }   // get method
            set { fileVilla = value; }  // set method
        }

        public int FjoldiDrif(int iID)
        {
            int iRet = 0;
            string strSQL = string.Format("SELECT count(*) FROM db_oais_admin.dt_files d where drifID = {0};", iID);
            var count = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if(count != null)
            {
                iRet = Convert.ToInt32(count);
            }
            return iRet;
        }
        public void saveFile()
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //  id, nafn, oldNafn, slod, aðgerð, laust, drifID
            command.Parameters.AddWithValue("@nafn", this.Name);
            command.Parameters.AddWithValue("@oldnafn", this.OldName);
            command.Parameters.AddWithValue("@slod", this.Path);
            command.Parameters.AddWithValue("@adgerd", this.Event);
            command.Parameters.AddWithValue("@laust", this.Laust);
            command.Parameters.AddWithValue("@drifID", this.Drive);
            command.Parameters.AddWithValue("@villa", this.Villa);

            command.CommandText = "INSERT INTO `dt_files` SET  `nafn`=@nafn,  `oldnafn`=@oldnafn, `slod`=@slod, `adgerd`=@adgerd, `laust`=@laust,`drifID`=@drifID,`villa`=@villa, DATE=Now()";
            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
    }
}
