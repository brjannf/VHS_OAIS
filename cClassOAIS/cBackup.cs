using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassOAIS
{
    public class cBackup
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
        public int ID { get; set; }
        public int drifid { get; set; }
        public string  merking { get; set; }
        public string slodAfrit { get; set; }
        public string steard { get; set; }
        public string hvar_geymt { get; set; }
        public string athugasemdir { get; set; }
        public string hvar_afritadi { get; set; }
        public string dagsetning { get; set; }

        public void vista()
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
         
            command.Parameters.AddWithValue("@id", this.ID);
            command.Parameters.AddWithValue("@drifid", this.drifid);
            command.Parameters.AddWithValue("@merking", this.merking);
            command.Parameters.AddWithValue("@slodAfrit", this.slodAfrit);
            command.Parameters.AddWithValue("@steard", this.steard);
            command.Parameters.AddWithValue("@hvar_geymt", this.hvar_geymt);
            command.Parameters.AddWithValue("@athugasemdir", this.athugasemdir);
            command.Parameters.AddWithValue("@hvar_afritadi", this.hvar_afritadi);
            command.Parameters.AddWithValue("@dagsetning", this.dagsetning);

            command.CommandText = "INSERT INTO `dt_backup` SET  `drifid`=@drifid,  `merking`=@merking, slodAfrit=@slodAfrit, steard=@steard, hvar_geymt=@hvar_geymt, athugasemdir=@athugasemdir,  hvar_afritadi=@hvar_afritadi, dagsetning=NOW();";

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

        public DataTable getBackup(int iDrif)
        {
            string strSQL = string.Format("SELECT * FROM dt_backup d Where drifid = {0} order by dagsetning desc", iDrif);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public int getNextBackupID() 
        {
            int iRet = 1;
            string strSQL = "SELECT max(id) as id FROM dt_backup d;";
            var id = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if(id != DBNull.Value)
            {
                iRet = Convert.ToInt32(id) + 1; 
            }
            return iRet;    
        }

        public void createDatabase()
        {  
            string strTenging = "server = localhost; user id = root; Password = ivarBjarkLind;";
            string strSQL = "CREATE DATABASE  IF NOT EXISTS `db_oais_admin` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;";
            MySqlHelper.ExecuteNonQuery(strTenging, strSQL);
        }

        public DataTable getAllDatabases()
        {
            string strSQL = "SELECT schema_name FROM information_schema.schemata WHERE schema_name LIKE 'AVID%_';";
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getDataFromTable(string strTable, string strIDCol, string strID)
        {
            string strSQL = string.Format("SELECT * FROM {0} WHERE {1} IN ({2});", strTable, strIDCol, strID);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
    }
}
