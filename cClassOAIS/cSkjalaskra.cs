using DocumentFormat.OpenXml.Office2016.Presentation.Command;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassOAIS
{
    public class cSkjalaskra
    {
        private string m_strTenging = string.Empty;
        public bool m_bAfrit = false;
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

        #region GET/SET
        public int ID { get; set; }
        public string vörslustofnun { get; set; }
        public int skjalamyndari { get; set; }
        public int tilheyrir_skráningu { get; set; }
        public string ritskoðun { get; set; }
        public string auðkenni_3_1_1 { get; set; }
        public string titill_3_1_2 { get; set; }
        public string tímabil_3_1_3 { get; set; }
        public string upplýsingastig_3_1_4 { get; set; }
        public string magn_lýsing_3_1_5 { get; set; }
        public string heiti_skjalamyndara_3_2_1 { get; set; }
        public string saga_skjalamyndara_3_2_2 { get; set; }
        public string saga_skjalanna_3_2_3 { get; set; }
        public string afhendingar_tilfærslur_3_2_4 { get; set; }
        public string yfirlit_innihald_3_3_1 { get; set; }
        public string tímaáætlanir_3_3_2 { get; set; }
        public string fyrirsjáanlegar_viðbætur_3_3_3 { get; set; }
        public string innri_skipan_3_3_4 { get; set; }
        public string skilyrði_aðgengi_3_4_1 { get; set; }
        public string skilyrði_endurprentun_3_4_2 { get; set; }
        public string tungumál_3_4_3 { get; set; }
        public string ytri_einkenni_3_4_4 { get; set; }
        public string hjálpargögn_3_4_5 { get; set; }
        public string tilvist_frumrita_3_5_1 { get; set; }
        public string tilvist_afrita_3_5_2 { get; set; }
        public string skyld_skjöl_3_5_3 { get; set; }
        public string útgáfuupplýsingar_3_5_4 { get; set; }
        public string athugasemdir_3_6_1 { get; set; }
        public string athugasemdir_skjalavarðar_3_7_1 { get; set; }
        public string reglur_venjur_3_7_2 { get; set; }
        public string dagsetningar_3_7_3 { get; set; }
        public string hver_skráði { get; set; }
        public string dags_skráð { get; set; }
        public string hver_breytti { get; set; }
        public string dags_breytt { get; set; }
        #endregion

        public void vista()
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
          
           // 3_7_3_dagsetningar, hver_skráði, dags_skráð, hver_breytti, dags_breytt

            command.Parameters.AddWithValue("@id", this.ID);
            command.Parameters.AddWithValue("@vörslustofnun", this.vörslustofnun);
            command.Parameters.AddWithValue("@skjalamyndari", this.skjalamyndari);
            command.Parameters.AddWithValue("@tilheyrir_skráningu", this.tilheyrir_skráningu);
            command.Parameters.AddWithValue("@ritskoðun", this.ritskoðun);
            command.Parameters.AddWithValue("@3_1_1_auðkenni", this.auðkenni_3_1_1);
            command.Parameters.AddWithValue("@3_1_2_titill", this.titill_3_1_2);
            command.Parameters.AddWithValue("@3_1_3_tímabil", this.tímabil_3_1_3);
            command.Parameters.AddWithValue("@3_1_4_upplýsingastig", this.upplýsingastig_3_1_4);
            command.Parameters.AddWithValue("@3_1_5_magn_lýsing", this.magn_lýsing_3_1_5);
            command.Parameters.AddWithValue("@3_2_1_heiti_skjalamyndara", this.heiti_skjalamyndara_3_2_1);
            command.Parameters.AddWithValue("@3_2_2_saga_skjalamyndara", this.saga_skjalamyndara_3_2_2);
            command.Parameters.AddWithValue("@3_2_3_saga_skjalanna", this.saga_skjalanna_3_2_3);
            command.Parameters.AddWithValue("@3_2_4_afhendingar_tilfærslur", this.afhendingar_tilfærslur_3_2_4);
            command.Parameters.AddWithValue("@3_3_1_yfirlit_innihald", this.yfirlit_innihald_3_3_1);
            command.Parameters.AddWithValue("@3_3_2_tímaáætlanir", this.tímaáætlanir_3_3_2);
            command.Parameters.AddWithValue("@3_3_3_fyrirsjáanlegar_viðbætur", this.fyrirsjáanlegar_viðbætur_3_3_3);
            command.Parameters.AddWithValue("@3_3_4_innri_skipan", this.innri_skipan_3_3_4);
            command.Parameters.AddWithValue("@3_4_1_skilyrði_aðgengi", this.skilyrði_aðgengi_3_4_1);
            command.Parameters.AddWithValue("@3_4_2_skilyrði_endurprentun", this.skilyrði_endurprentun_3_4_2);
            command.Parameters.AddWithValue("@3_4_3_tungumál", this.tungumál_3_4_3);
            command.Parameters.AddWithValue("@3_4_4_ytri_einkenni", this.ytri_einkenni_3_4_4);
            command.Parameters.AddWithValue("@3_4_5_hjálpargögn", this.hjálpargögn_3_4_5);
            command.Parameters.AddWithValue("@3_5_1_tilvist_frumrita", this.tilvist_frumrita_3_5_1);
            command.Parameters.AddWithValue("@3_5_2_tilvist_afrita", this.tilvist_afrita_3_5_2);
            command.Parameters.AddWithValue("@3_5_3_skyld_skjöl", this.skyld_skjöl_3_5_3);
            command.Parameters.AddWithValue("@3_5_4_útgáfuupplýsingar", this.útgáfuupplýsingar_3_5_4);
            command.Parameters.AddWithValue("@3_6_1_athugasemdir", this.athugasemdir_3_6_1);
            command.Parameters.AddWithValue("@3_7_1_athugasemdir_skjalavarðar", this.athugasemdir_skjalavarðar_3_7_1);
            command.Parameters.AddWithValue("@3_7_2_reglur_venjur", this.reglur_venjur_3_7_2);
           // command.Parameters.AddWithValue("@3_7_3_dagsetningar", this.dagsetningar_3_7_3);
            command.Parameters.AddWithValue("@hver_skráði", this.hver_skráði);
            command.Parameters.AddWithValue("@dags_skráð", this.dags_skráð);
            command.Parameters.AddWithValue("@hver_breytti", this.hver_breytti);
            command.Parameters.AddWithValue("@dags_breytt", this.dags_breytt);
            


            if (this.ID != 0)
            {
                string strNewDate = string.Format("Breytt: {0} af {1}", DateTime.Now, this.hver_breytti);
                string strDagsetningar = this.dagsetningar_3_7_3 + Environment.NewLine + strNewDate;
                command.Parameters.AddWithValue("@3_7_3_dagsetningar", strDagsetningar);
            }
            else
            {
                string strNewDate = string.Format("Skráð: {0} af {1}", DateTime.Now, this.hver_skráði);
                command.Parameters.AddWithValue("@3_7_3_dagsetningar", strNewDate);
            }
            if(ID == 0) 
            {
                command.CommandText = "INSERT INTO `dt_isadg_skráningar` SET  `vörslustofnun`=@vörslustofnun, `skjalamyndari`=@skjalamyndari, `tilheyrir_skráningu`=@tilheyrir_skráningu, `3_1_1_auðkenni`=@3_1_1_auðkenni, `3_1_2_titill`=@3_1_2_titill, `3_1_3_tímabil`=@3_1_3_tímabil, `3_1_4_upplýsingastig`=@3_1_4_upplýsingastig, `3_1_5_magn_lýsing`=@3_1_5_magn_lýsing, `3_2_1_heiti_skjalamyndara`=@3_2_1_heiti_skjalamyndara, `3_2_2_saga_skjalamyndara`=@3_2_2_saga_skjalamyndara, `3_2_3_saga_skjalanna`=@3_2_3_saga_skjalanna, `3_2_4_afhendingar_tilfærslur`=@3_2_4_afhendingar_tilfærslur, `3_3_1_yfirlit_innihald`=@3_3_1_yfirlit_innihald, `3_3_2_tímaáætlanir`=@3_3_2_tímaáætlanir, `3_3_3_fyrirsjáanlegar_viðbætur`=@3_3_3_fyrirsjáanlegar_viðbætur, `3_3_4_innri_skipan`=@3_3_4_innri_skipan, `3_4_1_skilyrði_aðgengi`=@3_4_1_skilyrði_aðgengi, `3_4_2_skilyrði_endurprentun`=@3_4_2_skilyrði_endurprentun, `3_4_3_tungumál`=@3_4_3_tungumál, `3_4_4_ytri_einkenni`=@3_4_4_ytri_einkenni, `3_4_5_hjálpargögn`=@3_4_5_hjálpargögn, `3_5_1_tilvist_frumrita`=@3_5_1_tilvist_frumrita, `3_5_2_tilvist_afrita`=@3_5_2_tilvist_afrita, `3_5_3_skyld_skjöl`=@3_5_3_skyld_skjöl, `3_5_4_útgáfuupplýsingar`=@3_5_4_útgáfuupplýsingar, `3_6_1_athugasemdir`=@3_6_1_athugasemdir, `3_7_1_athugasemdir_skjalavarðar`=@3_7_1_athugasemdir_skjalavarðar, `3_7_2_reglur_venjur`=@3_7_2_reglur_venjur, `3_7_3_dagsetningar`=@3_7_3_dagsetningar, `hver_skráði`=@hver_skráði, `dags_skráð`=NOW()";
            }
            else
            {
                command.CommandText = "UPDATE `dt_isadg_skráningar` SET  `vörslustofnun`=@vörslustofnun, `skjalamyndari`=@skjalamyndari, `tilheyrir_skráningu`=@tilheyrir_skráningu, `3_1_1_auðkenni`=@3_1_1_auðkenni, `3_1_2_titill`=@3_1_2_titill, `3_1_3_tímabil`=@3_1_3_tímabil, `3_1_4_upplýsingastig`=@3_1_4_upplýsingastig, `3_1_5_magn_lýsing`=@3_1_5_magn_lýsing, `3_2_1_heiti_skjalamyndara`=@3_2_1_heiti_skjalamyndara, `3_2_2_saga_skjalamyndara`=@3_2_2_saga_skjalamyndara, `3_2_3_saga_skjalanna`=@3_2_3_saga_skjalanna, `3_2_4_afhendingar_tilfærslur`=@3_2_4_afhendingar_tilfærslur, `3_3_1_yfirlit_innihald`=@3_3_1_yfirlit_innihald, `3_3_2_tímaáætlanir`=@3_3_2_tímaáætlanir, `3_3_3_fyrirsjáanlegar_viðbætur`=@3_3_3_fyrirsjáanlegar_viðbætur, `3_3_4_innri_skipan`=@3_3_4_innri_skipan, `3_4_1_skilyrði_aðgengi`=@3_4_1_skilyrði_aðgengi, `3_4_2_skilyrði_endurprentun`=@3_4_2_skilyrði_endurprentun, `3_4_3_tungumál`=@3_4_3_tungumál, `3_4_4_ytri_einkenni`=@3_4_4_ytri_einkenni, `3_4_5_hjálpargögn`=@3_4_5_hjálpargögn, `3_5_1_tilvist_frumrita`=@3_5_1_tilvist_frumrita, `3_5_2_tilvist_afrita`=@3_5_2_tilvist_afrita, `3_5_3_skyld_skjöl`=@3_5_3_skyld_skjöl, `3_5_4_útgáfuupplýsingar`=@3_5_4_útgáfuupplýsingar, `3_6_1_athugasemdir`=@3_6_1_athugasemdir, `3_7_1_athugasemdir_skjalavarðar`=@3_7_1_athugasemdir_skjalavarðar, `3_7_2_reglur_venjur`=@3_7_2_reglur_venjur, `3_7_3_dagsetningar`=@3_7_3_dagsetningar, `hver_breytti`=@hver_breytti, `dags_breytt`=NOW() WHERE `ID`=@ID;";
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE `dt_vörsluutgafur` set `innihald` = @3_3_1_yfirlit_innihald, `timabil` = @3_1_3_tímabil, `utgafa_titill` = @3_1_2_titill, `afharnr` = @3_2_4_afhendingar_tilfærslur, `adgangstakmarkanir` = @3_4_1_skilyrði_aðgengi  where `vorsluutgafa`=@3_1_1_auðkenni;";
            }
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                string strBla=  this.yfirlit_innihald_3_3_1;
        
              
            }
            conn.Dispose();
            command.Dispose();


        }
        public void eyða(string strAuðkenni)
        {
            string strSQL = string.Format("DELETE from dt_isadg_skráningar WHERE 3_1_1_auðkenni= '{0}'", strAuðkenni);
            MySqlHelper.ExecuteNonQuery(m_strTenging,strSQL);   
        }
        public void hreinsaHlut()
        {
            this.ID = 0;
            this.vörslustofnun = string.Empty;
            this.skjalamyndari = 0;
            this.tilheyrir_skráningu = 0;
            this.ritskoðun = string.Empty;
            this.auðkenni_3_1_1 = string.Empty;
            this.titill_3_1_2 = string.Empty;
            this.tímabil_3_1_3 = string.Empty;
            this.upplýsingastig_3_1_4 = string.Empty;
            this.magn_lýsing_3_1_5 = string.Empty;
            this.heiti_skjalamyndara_3_2_1 = string.Empty;
            this.saga_skjalamyndara_3_2_2 = string.Empty;
            this.saga_skjalanna_3_2_3 = string.Empty;
            this.afhendingar_tilfærslur_3_2_4 = string.Empty;
            this.yfirlit_innihald_3_3_1 = string.Empty;
            this.tímaáætlanir_3_3_2 = string.Empty;
            this.fyrirsjáanlegar_viðbætur_3_3_3 = string.Empty;
            this.innri_skipan_3_3_4 = string.Empty;
            this.skilyrði_aðgengi_3_4_1 = string.Empty;
            this.skilyrði_endurprentun_3_4_2 = string.Empty;
            this.tungumál_3_4_3 = string.Empty;
            this.ytri_einkenni_3_4_4 = string.Empty;
            this.hjálpargögn_3_4_5 = string.Empty;
            this.tilvist_frumrita_3_5_1 = string.Empty;
            this.tilvist_afrita_3_5_2 = string.Empty;
            this.skyld_skjöl_3_5_3 = string.Empty;
            this.útgáfuupplýsingar_3_5_4 = string.Empty;
            this.athugasemdir_3_6_1 = string.Empty;
            this.athugasemdir_skjalavarðar_3_7_1 = string.Empty;
            this.reglur_venjur_3_7_2 = string.Empty;
            this.dagsetningar_3_7_3 = string.Empty;
            this.hver_skráði = string.Empty;
            this.dags_skráð = string.Empty;
            this.hver_breytti = string.Empty;
            this.dags_breytt = string.Empty;
        }
        public DataTable getGeymsluSkra(string strAuðkenni)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM `dt_isadg_skráningar` d where 3_1_1_auðkenni like '{0}%' order by  3_1_1_auðkenni asc;", strAuðkenni);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public void getSkraning(string strAuðkenni)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM `dt_isadg_skráningar` d where 3_1_1_auðkenni = '{0}'; ", strAuðkenni);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach(DataRow r in dt.Rows) 
                {
                    //id, vörslustofnun, skjalamyndari, tilheyrir_skráningu, ritskoðun, 3_1_1_auðkenni, 3_1_2_titill, 3_1_3_tímabil, 3_1_4_upplýsingastig, 3_1_5_magn_lýsing, 3_2_1_heiti_skjalamyndara, 3_2_2_saga_skjalamyndara, 3_2_3_saga_skjalanna, 3_2_4_afhendingar_tilfærslur, 3_3_1_yfirlit_innihald, 3_3_2_tímaáætlanir, 3_3_3_fyrirsjáanlegar_viðbætur, 3_3_4_innri_skipan, 3_4_1_skilyrði_aðgengi, 3_4_2_skilyrði_endurprentun, 3_4_3_tungumál, 3_4_4_ytri_einkenni, 3_4_5_hjálpargögn, 3_5_1_tilvist_frumrita, 3_5_2_tilvist_afrita, 3_5_3_skyld_skjöl, 3_5_4_útgáfuupplýsingar, 3_6_1_athugasemdir, 3_7_1_athugasemdir_skjalavarðar, 3_7_2_reglur_venjur, 3_7_3_dagsetningar, hver_skráði, dags_skráð, hver_breytti, dags_breytt
                    this.ID = Convert.ToInt32(r["id"]);
                    this.vörslustofnun = r["vörslustofnun"].ToString();
                    this.skjalamyndari = Convert.ToInt32(r["skjalamyndari"]);
                    this.tilheyrir_skráningu = Convert.ToInt32(r["tilheyrir_skráningu"]);
                    this.ritskoðun = r["ritskoðun"].ToString();
                    this.auðkenni_3_1_1 = r["3_1_1_auðkenni"].ToString();
                    this.titill_3_1_2 = r["3_1_2_titill"].ToString();
                    this.tímabil_3_1_3 = r["3_1_3_tímabil"].ToString();
                    this.upplýsingastig_3_1_4 = r["3_1_4_upplýsingastig"].ToString();
                    this.magn_lýsing_3_1_5 = r["3_1_5_magn_lýsing"].ToString();
                    this.heiti_skjalamyndara_3_2_1 = r["3_2_1_heiti_skjalamyndara"].ToString();
                    this.saga_skjalamyndara_3_2_2 = r["3_2_2_saga_skjalamyndara"].ToString();
                    this.saga_skjalanna_3_2_3 = r["3_2_3_saga_skjalanna"].ToString();
                    this.afhendingar_tilfærslur_3_2_4 = r["3_2_4_afhendingar_tilfærslur"].ToString();
                    this.yfirlit_innihald_3_3_1 = r["3_3_1_yfirlit_innihald"].ToString();
                    this.tímaáætlanir_3_3_2 = r["3_3_2_tímaáætlanir"].ToString();
                    this.fyrirsjáanlegar_viðbætur_3_3_3 = r["3_3_3_fyrirsjáanlegar_viðbætur"].ToString();
                    this.innri_skipan_3_3_4 = r["3_3_4_innri_skipan"].ToString();
                    this.skilyrði_aðgengi_3_4_1 = r["3_4_1_skilyrði_aðgengi"].ToString();
                    this.skilyrði_endurprentun_3_4_2 = r["3_4_2_skilyrði_endurprentun"].ToString();
                    this.tungumál_3_4_3 = r["3_4_3_tungumál"].ToString();
                    this.ytri_einkenni_3_4_4 = r["3_4_4_ytri_einkenni"].ToString();
                    this.hjálpargögn_3_4_5 = r["3_4_5_hjálpargögn"].ToString();
                    this.tilvist_frumrita_3_5_1 = r["3_5_1_tilvist_frumrita"].ToString();
                    this.tilvist_afrita_3_5_2 = r["3_5_2_tilvist_afrita"].ToString();
                    this.skyld_skjöl_3_5_3 = r["3_5_3_skyld_skjöl"].ToString();
                    this.útgáfuupplýsingar_3_5_4 = r["3_5_4_útgáfuupplýsingar"].ToString();
                    this.athugasemdir_3_6_1 = r["3_6_1_athugasemdir"].ToString();
                    this.athugasemdir_skjalavarðar_3_7_1 = r["3_7_1_athugasemdir_skjalavarðar"].ToString();
                    this.reglur_venjur_3_7_2 = r["3_7_2_reglur_venjur"].ToString();
                    this.dagsetningar_3_7_3 = r["3_7_3_dagsetningar"].ToString();
                    this.hver_skráði = r["hver_skráði"].ToString();
                    this.dags_skráð = r["dags_skráð"].ToString();
                    this.hver_breytti = r["hver_breytti"].ToString();
                    this.dags_breytt = r["dags_breytt"].ToString();

                }
            }
        }


        public DataTable getKvittun(string strAuðkenni) 
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM `dt_vörsluutgafur` d where vorsluutgafa = '{0}';", strAuðkenni);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getVörsluútgáfur()
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM `dt_vörsluutgafur` d");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getVörsluútgáfurGU()
        {
            sækjaTengistreng();
             string strSQL = string.Format("SELECT * FROM `dt_vörsluutgafur` d where vorsluutgafa not like 'frum%';");
           // string strSQL = string.Format("SELECT d.*, (select distinct tegund_grunns from dt_midlun m where d.vorsluutgafa= m.vorsluutgafa) as tegund FROM `dt_vörsluutgafur` d where vorsluutgafa not like 'frum%';");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getVörsluútgáfurMidlun()
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM `dt_vörsluutgafur` d where eytt = 0 and vorsluutgafa not like 'FRUM%'");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getUpplysingastigENUM()
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT SUBSTRING(COLUMN_TYPE,5) as stig FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='db_oais_admin' AND TABLE_NAME='dt_isadg_skráningar'AND COLUMN_NAME='3_1_4_upplýsingastig';");
            var strengur = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt.Columns.Add("gerd");
            string[] strSplit = strengur.ToString().Split(',');
            foreach (string str in strSplit)
            {
                DataRow r = dt.NewRow();
                string strGerð = str.Replace("(", "");
                strGerð = strGerð.Replace(")", "");
                strGerð = strGerð.Replace("\'", "");
                r["gerd"] = strGerð;
                dt.Rows.Add(r);
                dt.AcceptChanges();

            }

            return dt;
        }
        public string getTimabil(string strFlokkur, string strGrunnur)
        {
            sækjaTengistreng();
            string strRet = string.Empty;
            string strSQL = string.Format("SELECT  concat(min(Year(lastwriten)),'-', max(Year(lastwriten))) as tímabil FROM {1} f where slod REGEXP '\\\\\\\\{0}'", strFlokkur ,strGrunnur + ".filesystem");
            try
            {
                var timabil = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
                if (timabil != null)
                {
                    strRet = timabil.ToString();
                }
            }
            catch (Exception xx) 
            {

                //throw;
            }
            return strRet;
        }
        public string getTimabilMalKerfi(string strGrunnur, string strMalTitill)
        {
              sækjaTengistreng();
            strGrunnur = strGrunnur.Replace(".", "_");

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);

            command.Parameters.AddWithValue("@maltitill", strMalTitill);

            strMalTitill = strMalTitill.Replace("\'", "*"); ;

            string strRet = string.Empty;
            command.CommandText = string.Format("SELECT concat(min(Year(doclastwriten)),'-', max(Year(doclastwriten))) as tímabil FROM dt_midlun d where heiti_gagangrunns = '{0}' and maltitill like '{1}';", strGrunnur, strMalTitill);
            var timabil = command.ExecuteScalar(); // MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if (timabil != null)
            {
                strRet = timabil.ToString();
            }
            conn.Dispose();
            command.Dispose();
            return strRet;
           // string strSQL = string.Format("SELECT concat(min(Year(doclastwriten)),'-', max(Year(doclastwriten))) as tímabil  FROM db_oais_admin.dt_midlun d where heiti_gagangrunns = '{0}' and maltitill = '{1}' ;", strMalTitill, strGrunnur);
               
        }

        public string getSkjalFjoldiMalkerfi(string strFlokkur, string strGrunnur)
        {
            sækjaTengistreng();
            strGrunnur = strGrunnur.Replace(".", "_");
            strFlokkur = strFlokkur.Replace("\'", "\\'");
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);

            command.Parameters.AddWithValue("@flokkur", strFlokkur);

            string strRet = string.Empty;
            command.CommandText = string.Format("SELECT count(*) as fjoldi FROM dt_midlun d where heiti_gagangrunns = '{0}' and maltitill = '{1}';", strGrunnur, strFlokkur);
            try
            {
                var timabil = command.ExecuteScalar(); // MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
                if (timabil != null)
                {
                    strRet = timabil.ToString();
                }
            }
            catch (Exception x)
            {

            //    throw;
            }
            conn.Dispose();
            command.Dispose();
            return strRet;
        }
        public string getSkjalListiiMalkerfi(string strFlokkur, string strGrunnur)
        {
            sækjaTengistreng();
            strGrunnur = strGrunnur.Replace(".", "_");

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);

            command.Parameters.AddWithValue("@flokkur", strFlokkur);

            string strRet = string.Empty;
            command.CommandText = string.Format("SELECT group_concat(concat(doctitill,  extension) SEPARATOR '~') as listi FROM dt_midlun d where heiti_gagangrunns = '{0}' and maltitill = '{1}';", strGrunnur, strFlokkur);
            var timabil = command.ExecuteScalar(); // MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if (timabil != null)
            {
                strRet = timabil.ToString();
            }
            conn.Dispose();
            command.Dispose();
            return strRet;
        }
        public string getSkjalFjoldi(string strFlokkur, string strGrunnur)
        {
            sækjaTengistreng();
            strGrunnur = strGrunnur.Replace(".", "_");

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);

            command.Parameters.AddWithValue("@flokkur", strFlokkur);

            string strRet = string.Empty;
           command.CommandText = string.Format("SELECT count(*) FROM {1} f where slod REGEXP '\\\\\\\\{0}';", strFlokkur, strGrunnur + ".filesystem");
            var timabil = command.ExecuteScalar(); // MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if (timabil != null)
            {
                strRet = timabil.ToString();
            }
            conn.Dispose();
            command.Dispose();
            return strRet;
        }

        public void eydaGeymsluskra(string strAuðkenni)
        {
            sækjaTengistreng();
            string strSQL = string.Format("DELETE FROM `dt_isadg_skráningar`  where 3_1_1_auðkenni like '{0}-%';", strAuðkenni);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);  
        }

        public DataTable getAdgengiENUM()
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT SUBSTRING(COLUMN_TYPE,5) as adgengi FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='db_oais_admin' AND TABLE_NAME='dt_isadg_skráningar'AND COLUMN_NAME='3_4_1_skilyrði_aðgengi';");
            var strengur = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt.Columns.Add("adgengi");
            string[] strSplit = strengur.ToString().Split(',');
            foreach (string str in strSplit)
            {
                DataRow r = dt.NewRow();
                string strGerð = str.Replace("(", "");
                strGerð = strGerð.Replace(")", "");
                strGerð = strGerð.Replace("\'", "");
                r["adgengi"] = strGerð;
                dt.Rows.Add(r);
                dt.AcceptChanges();

            }

            return dt;
        }
    }

}
