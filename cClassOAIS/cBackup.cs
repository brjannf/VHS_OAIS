﻿using MySql.Data.MySqlClient;
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
            if(id != null)
            {
                iRet = Convert.ToInt32(id) + 1; 
            }
            return iRet;    
        }



    }
}