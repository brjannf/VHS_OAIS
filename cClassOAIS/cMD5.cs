using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace cClassOAIS
{

    public class cMD5
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
        public int ID { get; set; }
        public string AIP { get; set; }
        public string slod { get; set; }
        public string file { get; set; }
        public string MD5 { get; set; }

        public void vista()
        {

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //  5_4_8_heimildir, 5_4_9_athugasemdir, hver_skráði, dags_skráð, hver_breytti, dags_breytt
            command.Parameters.AddWithValue("@id", this.ID);
            command.Parameters.AddWithValue("@AIP", this.AIP);
            command.Parameters.AddWithValue("@slod", this.slod);
            command.Parameters.AddWithValue("@file", this.file);
            command.Parameters.AddWithValue("@MD5", this.MD5);

            command.CommandText = "INSERT INTO `dt_md5` SET  `AIP`=@AIP,  `slod`=@slod, file=@file, MD5=@MD5, _date=NOW();";

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
        public void eyda(string strAIP)
        {
            string strSQL = string.Format("delete FROM db_oais_admin.dt_md5 d where AIP = '{0}';", strAIP);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
    }
    }  
    
}
