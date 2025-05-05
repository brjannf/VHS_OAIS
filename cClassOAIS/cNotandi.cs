using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Expr;
using MySqlX.XDevAPI.Relational;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;

namespace cClassOAIS
{
    public class cNotandi
    {
        private string m_strTenging = string.Empty;
        public bool m_bAfrit = false;
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

        private void sækjaTengistreng()
        {
                       
            if (m_bAfrit)
            {
                m_strTenging = ConfigurationManager.ConnectionStrings["connection_afrit"].ConnectionString; 
            }
            else
            {
                m_strTenging = ConfigurationManager.ConnectionStrings["connection_admin"].ConnectionString;
            }
        }
        public void sækjaNotanda(string strNotandi, string strlykilord)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_notendur d where notendanafn = '{0}' and lykilorð ='{1}' and virkur = 1;", strNotandi, strlykilord);
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
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_notendur d where kennitala = '{0}';", strKennitla);
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
        public DataTable getGrunnar()
        {
            m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind;";
            string strSQL = string.Format("SHOW DATABASES like 'DB_OAIS%'; ");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            return ds.Tables[0];
        }
        public void sækjaNotandaNot(string strKennitla, string strNotendanafn)
        {
            sækjaTengistreng();
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
            sækjaTengistreng();

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
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_notendur d order by nafn;");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public void hostRoot()
        {
            sækjaTengistreng();
            string strSQL = "UPDATE mysql.user SET host = '%' WHERE user = 'root'";
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
            strSQL = "FLUSH PRIVILEGES;";
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);

            
        }

        public DataTable getVorsluutgafur()
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM `dt_vörsluutgafur` d;");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getTimabilMidlun()
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT id,heiti_gagangrunns,maltitill, doccreated, doclastwriten FROM dt_midlun d;");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public void upDateTimi(string strCreated, string strChanged, string strID)
        {
            sækjaTengistreng();
            string strSQL = string.Format("UPDATE dt_midlun d set doccreated = '{0}', doclastwriten = '{1}'  where id = {2};", strCreated, strChanged, strID);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }
        public string getTegund(string strUtgafa)
        {
            sækjaTengistreng();
            string strRet = string.Empty;
            string strSQL = string.Format("SELECT distinct tegund_grunns FROM dt_midlun d where vorsluutgafa = '{0}';",strUtgafa);
            var ret = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if(ret != null)
            {
                strRet = ret.ToString();
            }
            return strRet;
        }
        public bool erGagnagrunnur(string strUtgafa)
        {
            sækjaTengistreng();
            bool bRet = false;
            string strSQL = string.Format("SELECT id FROM ds_gagnagrunnar d where vorsluutgafa  = '{0}';", strUtgafa);
            var ret = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if (ret != null)
            {
                bRet = true;
            }
            return bRet;
        }
        public void upDateTegund(string strTegund, string strUtgafa) 
        {
            sækjaTengistreng();
            string strSQL = string.Format("UPDATE  `dt_vörsluutgafur` set tegund = '{0}' WHERE vorsluutgafa = '{1}';", strTegund, strUtgafa);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }
        /// <summary>
        /// Bæti hér við eða breytum dálkum
        /// </summary>
        /// <param name="strKennitala"></param>
        /// 
        public void addExtensionDalk()
        {
            sækjaTengistreng();
            string strSQL = "ALTER TABLE `dt_midlun` ADD COLUMN `extension` VARCHAR(45) AFTER `docinnihald`;";
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        

        }
        public void addHeitiVarsla()
        {
            sækjaTengistreng();
            string strSQL = "ALTER TABLE `dt_item_korfu_dip` ADD COLUMN `heitiVorslu` VARCHAR(250) NOT NULL AFTER `slod`;";
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);

        }
        public void changeIsadgCharSet()
        {
            sækjaTengistreng();
            string strSQL = "ALTER TABLE `db_oais_admin_afrit`.`dt_isadg_skráningar` DROP INDEX `fulltext_allt`,\r\n ADD FULLTEXT INDEX `fulltext_allt`(`3_1_2_titill`, `3_1_5_magn_lýsing`, `3_2_1_heiti_skjalamyndara`, `3_2_3_saga_skjalanna`, `3_3_2_tímaáætlanir`, `3_3_3_fyrirsjáanlegar_viðbætur`, `3_3_4_innri_skipan`, `3_4_2_skilyrði_endurprentun`, `3_4_4_ytri_einkenni`, `3_5_1_tilvist_frumrita`, `3_5_2_tilvist_afrita`, `3_6_1_athugasemdir`, `3_7_1_athugasemdir_skjalavarðar`);";
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
            strSQL = "ALTER TABLE `dt_isadg_skráningar` MODIFY COLUMN `3_3_1_yfirlit_innihald` LONGBLOB DEFAULT NULL COMMENT '3.3.1 Scope and content. Lýsir umfangi og innihaldi skjalasafnsins.'\r\n, CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;";
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);

        }

        public void addTegundGrunns()
        {
            sækjaTengistreng();
            string strSQL = "ALTER TABLE `dt_vörsluutgafur` ADD COLUMN `tegund` VARCHAR(100) AFTER `utgafa_titill`;";
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);

        }

        public void lengthDataDIPDatabase()
        {
            sækjaTengistreng();
            string strSQL = "ALTER TABLE `db_oais_admin`.`dt_karfa_item_gagna_dip` MODIFY COLUMN `sql` VARCHAR(5000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL;";
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);

            strSQL = "ALTER TABLE `db_oais_admin`.`dt_karfa_item_gagna_dip` MODIFY COLUMN `sql` VARCHAR(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n MODIFY COLUMN `heitivorslu` VARCHAR(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL;";
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }

        public void skraInnskra(string strKennitala)
        {
            sækjaTengistreng();
            string strSQL = string.Format("Update dt_notendur set síðasta_innskráning = NOW() where kennitala = '{0}'", strKennitala);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }
    }
}