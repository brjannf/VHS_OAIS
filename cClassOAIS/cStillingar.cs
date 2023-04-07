using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassOAIS
{
    public class cStillingar
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";

       // id, sqluser, sqlpass, sqlversion, curr_computer, verd, skrad_af, dags_skrad, breytt_af, dags_breytt
        public int ID { get; set; }
        public string sqluser { get; set; }
        public string sqlpass { get; set; }
        public string sqlversion { get; set; }
        public string curr_computer { get; set; }
        public int verd { get; set; }
        public string skrad_af { get; set; }
        public string dags_skrad { get; set; }
        public string breytt_af { get; set; }
        public string dags_breytt { get; set; }


        public void getStillingar(string strTolva)
        {
            string strSQL = string.Format("SELECT * FROM dt_stillingar d where curr_computer = '{0}';", strTolva);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                //  email, heimilisfang, simi
                this.ID = Convert.ToInt32( r["id"]);
                this.sqluser = r["sqluser"].ToString();
                this.sqlpass = r["sqlpass"].ToString();
                this.curr_computer = r["curr_computer"].ToString();
                this.verd = Convert.ToInt32(r["verd"]);
                this.skrad_af = r["skrad_af"].ToString();
                this.dags_skrad = r["dags_skrad"].ToString();
                this.dags_skrad = r["dags_skrad"].ToString();
                this.breytt_af = r["breytt_af"].ToString();
                this.dags_breytt = r["dags_breytt"].ToString();
        

            }

        }

        public void vista()
        {

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
        
            command.Parameters.AddWithValue("@id", this.ID);
            command.Parameters.AddWithValue("@sqluser", this.sqluser);
            command.Parameters.AddWithValue("@sqlpass", this.sqlpass);
            command.Parameters.AddWithValue("@sqlversion", this.sqlversion);
            command.Parameters.AddWithValue("@curr_computer", this.curr_computer);
            command.Parameters.AddWithValue("@verd", this.verd);
            command.Parameters.AddWithValue("@skrad_af", this.skrad_af);
            command.Parameters.AddWithValue("@dags_skrad", this.dags_skrad);
            command.Parameters.AddWithValue("@breytt_af", this.breytt_af);
            command.Parameters.AddWithValue("@dags_breytt", this.dags_breytt);

            if(this.ID == 0)
            {
                command.CommandText = "INSERT INTO `dt_stillingar` SET  `sqluser`=@sqluser,  `sqlpass`=@sqlpass, `sqlversion`=@sqlversion, `curr_computer`=@curr_computer, `verd`=@verd,`skrad_af`=@skrad_af,`dags_skrad`=NOW();";
            }
            else
            {
                command.CommandText = string.Format("UPDATE `dt_stillingar` SET `sqluser`=@sqluser, `sqlpass`=@sqlpass, `sqlversion`=@sqlversion, `curr_computer`=@curr_computer, `verd`=@verd,`breytt_af`=@breytt_af,`dags_breytt`=NOW() WHERE id={0};", this.ID);
            }



            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

        public string getSQLversion()
        {
            string strRet = string.Empty;
            string strSQL = "select @@version";
            strRet = MySqlHelper.ExecuteScalar(m_strTenging, strSQL).ToString();
            return strRet;

        }
    }
}
