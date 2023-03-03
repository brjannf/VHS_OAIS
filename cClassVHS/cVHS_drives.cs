using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace cClassVHS
{
    public class cVHS_drives
    {
        private int iID;
        private int iComputer;
        private string driveName;
        private string driveFormat;
        private string driveLaust;
        private string driveHeild;
        private string driveTegund;
        private int iVirk;
        private DateTime driveframleitt;

        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";

        /// <summary>
        /// smiður eftir að útfæra
        /// </summary>
        /// <param name="iComID"></param>
        public void cHS_drives(int iComID)
        {

        }

        public int ID   // property
        {
            get { return iID; }   // get method
            set { iID = value; }  // set method
        }
        public int comID   // property
        {
            get { return iComputer; }   // get method
            set { iComputer = value; }  // set method
        }
        public string Name
        {
            get { return driveName; }   // get method
            set { driveName = value; }  // set method
        }

        public string Format
        {
            get { return driveName; }   // get method
            set { driveName = value; }  // set method
        }

        public string Laust
        {
            get { return driveLaust; }   // get method
            set { driveLaust = value; }  // set method
        }

        public string Heild
        {
            get { return driveHeild; }   // get method
            set { driveHeild = value; }  // set method
        }

        public string Tegund
        {
            get { return driveTegund; }   // get method
            set { driveTegund = value; }  // set method
        }

        public DateTime Framleitt
        {
            get { return driveframleitt; }   // get method
            set { driveframleitt = value; }  // set method
        }

        public int Virk
        {
            get { return iVirk; }   // get method
            set { iVirk = value; }  // set method
        }

        public void geraVirktOvirkt(int iVirkt, int iID)
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);

            command.CommandText = string.Format("update db_oais_admin.dt_drives set virk = {0} where id = {1};", iVirkt, iID);
            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }


        public void geraVirktOvirkt(int iVirkt, string strNafn)
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            strNafn = strNafn.Replace("\\", "\\\\");
            command.CommandText = string.Format("update db_oais_admin.dt_drives set virk = {0} where nafn ='{1}';", iVirkt, strNafn);
            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

        public void EyðaDrifi(int iID)
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
     
            command.CommandText = string.Format("delete FROM db_oais_admin.dt_drives where id = {0};", iID);
            command.ExecuteNonQuery();
            conn.Dispose();
        }
           
            public void saveDrive(string strDrive)
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //  id, nafn, format, laust, heild, tegund, framleitt
            command.Parameters.AddWithValue("@comID", this.comID);
            command.Parameters.AddWithValue("@nafn", strDrive);
            command.Parameters.AddWithValue("@format", this.Format);
            command.Parameters.AddWithValue("@laust", this.Laust);
            command.Parameters.AddWithValue("@heild", this.Heild);
            command.Parameters.AddWithValue("@tegund", this.Tegund);
            command.Parameters.AddWithValue("@framleitt", this.Framleitt);

            command.Parameters.AddWithValue("@virk", this.Virk);


            command.CommandText = "INSERT INTO `dt_drives` SET  `comID`=@comID,  `nafn`=@nafn, `format`=@format, `laust`=@laust, `heild`=@heild,`tegund`=@tegund,`framleitt`=@framleitt,`virk`=@virk";
            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

        public DataTable driveComputers(int comID)
        {
            string strSQL = string.Format("SELECT * FROM db_oais_admin.dt_drives d where comID = {0} and virk = 1;", comID);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging,strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable driveOvirkComputers()
        {
            string strSQL = string.Format("SELECT * FROM db_oais_admin.dt_drives d where virk = 0;");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
    }
}
