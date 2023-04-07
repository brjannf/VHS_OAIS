using MySql.Data.MySqlClient;
using Mysqlx.Expr;
using MySqlX.XDevAPI.Relational;
using System.Data;
using System.Diagnostics.Metrics;

namespace cClassOAIS
{
    public class cNotandi
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
        #region GET/SET
        public string kennitala { get; set; }
        public string notendanafn { get;  set; }
        public string lykilord { get; set; }
        public string vörslustofnun { get; set; }
        public string nafn { get;  set; }
        public string sidast_innskraning { get; set; }
        public string athugasemdir { get; set; }
        public string hver_skradi { get; set; }
        public string dags_skrad { get; set; }
        public string hver_breytti { get; set; }
        public string dags_breytt { get; set; }
        public int virkur { get; set; }
        public string hlutverk { get; set; }
        public string netfang { get; set; }
        public string heimilisfang { get; set; }

        public string simi { get; set; } 
        #endregion

        public void sækjaNotanda(string strNotandi, string strlykilord)
        {
            string strSQL = string.Format("SELECT * FROM db_oais_admin.dt_notendur d where notendanafn = '{0}' and lykilorð ='{1}' and virkur = 1;", strNotandi, strlykilord);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging,strSQL);
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach(DataRow r in dt.Rows ) 
            {
                //  email, heimilisfang, simi
                this.kennitala = r["kennitala"].ToString();
                this.notendanafn = r["notendanafn"].ToString();
                this.lykilord = r["lykilorð"].ToString();
                this.vörslustofnun =r["vörslustofnun"].ToString();
                this.nafn = r["nafn"].ToString();
                this.virkur = Convert.ToInt32(r["virkur"]);
                this.athugasemdir = r["athugasemdir"].ToString();
                this.sidast_innskraning = r["síðasta_innskráning"].ToString();
                this.hver_skradi = r["hver_skradi"].ToString();
                this.dags_skrad = r["dags_skráð"].ToString();
                this.hver_breytti = r["hver_breytti"].ToString();
                this.dags_breytt = r["dags_breytt"].ToString();
                this.hlutverk = r["hlutverk"].ToString();
                this.netfang = r["email"].ToString();
                this.heimilisfang = r["heimilisfang"].ToString();
                this.simi = r["simi"].ToString();

            }
          
        }

        public void sækjaNotanda(string strKennitla)
        {
            string strSQL = string.Format("SELECT * FROM db_oais_admin.dt_notendur d where kennitala = '{0}';", strKennitla);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                //  email, heimilisfang, simi
                this.kennitala = r["kennitala"].ToString();
                this.notendanafn = r["notendanafn"].ToString();
                this.lykilord = r["lykilorð"].ToString();
                this.vörslustofnun = r["vörslustofnun"].ToString();
                this.nafn = r["nafn"].ToString();
                this.virkur = Convert.ToInt32(r["virkur"]);
                this.athugasemdir = r["athugasemdir"].ToString();
                this.sidast_innskraning = r["síðasta_innskráning"].ToString();
                this.hver_skradi = r["hver_skradi"].ToString();
                this.dags_skrad = r["dags_skráð"].ToString();
                this.hver_breytti = r["hver_breytti"].ToString();
                this.dags_breytt = r["dags_breytt"].ToString();
                this.hlutverk = r["hlutverk"].ToString();
                this.netfang = r["email"].ToString();
                this.heimilisfang = r["heimilisfang"].ToString();
                this.simi = r["simi"].ToString();

            }

        }

        public void sækjaNotandaNot(string strKennitla, string strNotendanafn)
        {
            string strSQL = string.Format("SELECT * FROM dt_notendur d where notendanafn = '{0}' and kennitala != '{1}';", strNotendanafn,strKennitla);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                //  email, heimilisfang, simi
                this.kennitala = r["kennitala"].ToString();
                this.notendanafn = r["notendanafn"].ToString();
                this.lykilord = r["lykilorð"].ToString();
                this.vörslustofnun = r["vörslustofnun"].ToString();
                this.nafn = r["nafn"].ToString();
                this.virkur = Convert.ToInt32(r["virkur"]);
                this.athugasemdir = r["athugasemdir"].ToString();
                this.sidast_innskraning = r["síðasta_innskráning"].ToString();
                this.hver_skradi = r["hver_skradi"].ToString();
                this.dags_skrad = r["dags_skráð"].ToString();
                this.hver_breytti = r["hver_breytti"].ToString();
                this.dags_breytt = r["dags_breytt"].ToString();
                this.hlutverk = r["hlutverk"].ToString();
                this.netfang = r["email"].ToString();
                this.heimilisfang = r["heimilisfang"].ToString();
                this.simi = r["simi"].ToString();

            }

        }

        public void hreinsaHlut()
        {
            this.kennitala = null;
            this.notendanafn = null;
            this.lykilord = null;
            this.vörslustofnun = null;
            this.nafn = null;
            this.virkur = 0;
            this.athugasemdir = null;
            this.sidast_innskraning = null;
            this.hver_skradi = null;
            this.dags_skrad = null;
            this.hver_breytti = null;
            this.dags_breytt = null;
            this.hlutverk = null;
            this.netfang = null;
            this.heimilisfang = null;
            this.simi = null;
        }

        public void vista(string strKennitala)
        {

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //kennitala, notendanafn, lykilorð, vörslustofnun, nafn, virkur, athugasemdir, síðasta_innskráning, hver_skradi, dags_skráð, hver_breytti, dags_breytt, hlutverk, email, heimilisfang, simi
            command.Parameters.AddWithValue("@kennitala", this.kennitala);
            command.Parameters.AddWithValue("@notendanafn", this.notendanafn);
            command.Parameters.AddWithValue("@lykilorð", this.lykilord);
            command.Parameters.AddWithValue("@vörslustofnun", this.vörslustofnun);
            command.Parameters.AddWithValue("@nafn", this.nafn);
            command.Parameters.AddWithValue("@virkur", this.virkur);
            command.Parameters.AddWithValue("@athugasemdir", this.athugasemdir);
            command.Parameters.AddWithValue("@hver_skradi", this.hver_skradi);
            command.Parameters.AddWithValue("@hver_breytti", this.hver_breytti);
            command.Parameters.AddWithValue("@hlutverk", this.hlutverk);
            command.Parameters.AddWithValue("@email", this.netfang);
            command.Parameters.AddWithValue("@heimilisfang", this.heimilisfang);
            command.Parameters.AddWithValue("@simi", this.simi);

            if(strKennitala == null)
            {
                command.CommandText = "REPLACE INTO `dt_notendur` SET  `kennitala`=@kennitala,  `notendanafn`=@notendanafn, `lykilorð`=@lykilorð, `vörslustofnun`=@vörslustofnun, `nafn`=@nafn,`virkur`=@virkur,`athugasemdir`=@athugasemdir,`hver_skradi`=@hver_skradi,`hlutverk`=@hlutverk,`email`=@email,`heimilisfang`=@heimilisfang,`simi`=@simi,`dags_skráð`=NOW();";
            }
            else
            {
                command.CommandText = string.Format("UPDATE `dt_notendur` SET  `kennitala`=@kennitala,  `notendanafn`=@notendanafn, `lykilorð`=@lykilorð, `vörslustofnun`=@vörslustofnun, `nafn`=@nafn,`virkur`=@virkur,`athugasemdir`=@athugasemdir,`hver_breytti`=@hver_breytti,`hlutverk`=@hlutverk,`email`=@email,`heimilisfang`=@heimilisfang,`simi`=@simi,`dags_breytt`=NOW() WHERE kennitala ={0};",strKennitala);
            }
           
            command.ExecuteNonQuery();

            //if (strKennitala == null)
            //{
            //    command.CommandText = string.Format("CREATE USER '{0}'@'localhost' IDENTIFIED BY '{0}'", this.notendanafn, this.lykilord);
            //    command.ExecuteNonQuery();
            //    command.CommandText = string.Format("GRANT ALL PRIVILEGES ON db_oais_admin.* TO '{0}'@'localhost' WITH GRANT OPTION; '", this.notendanafn);
            //    command.ExecuteNonQuery();

            //}
            //else
            //{
            //    {
            //        command.CommandText = string.Format("ALTER USER '{0}'@'localhost' IDENTIFIED BY '{1}';", this.notendanafn, this.lykilord);
            //        command.ExecuteNonQuery();
            //        command.CommandText = string.Format("GRANT ALL PRIVILEGES ON *.* TO '{0}'@'localhost' WITH GRANT OPTION;", this.notendanafn);
            //        command.ExecuteNonQuery();
            //    }
            //}

            //    command.ExecuteNonQuery();


            conn.Dispose();
            command.Dispose();
        }
        public DataTable notendaListi()
        {
            string strSQL = string.Format("SELECT * FROM dt_notendur d order by nafn;");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public void skraInnskra(string strKennitala)
        {
            string strSQL = string.Format("Update dt_notendur set síðasta_innskráning = NOW() where kennitala = '{0}'", strKennitala);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }
    }
}