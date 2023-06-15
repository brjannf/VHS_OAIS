using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace cClassOAIS
{
    public class cSkjalamyndari
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";


        #region GET/SET
        public int ID { get;set; }
        public string  opinbert_auðkenni { get; set; } 
        public string gerð_5_1_1 { get; set; }
        public string opinbert_heiti_5_1_2 { get;  set; }
        public string erlent_heiti_5_1_3 { get;  set; }
        public string annað_heiti_aðlagað_5_1_4 { get;  set; }
        public string annað_heiti_5_1_5 { get;  set; }
        public string auðkenni_5_1_6 { get;  set; }
        public string tímabil_5_2_1 { get;  set; }
        public string saga_5_2_2 { get;  set; }
        public string staðsetning_5_2_3 { get;  set; }
        public string lagaleg_staða_5_2_4 { get;  set; }
        public string hlutverk_5_2_5 { get;  set; }
        public string tilheyrandi_lög_5_2_6 { get;  set; }
        public string innri_stjórnun_5_2_7 { get;  set; }
        public string almennt_samhengi_5_2_8 { get; set; }
        public string auðkenni_lands_5_4_1 { get; set; }
        public string auðkenni_vörslustofnunar_5_4_2 { get; set; }
        public string reglur_staðlar_5_4_3 { get; set; }
        public string skráningarstaða_5_4_4 { get; set; }
        public string skráningarstig_5_4_5 { get; set; }
        public string dagsetningar_5_4_6 { get;  set; }
        public string tungumál_5_4_7 { get;  set; }
        public string heimildir_5_4_8 { get;  set; }
        public string athugasemdir_5_4_9 { get;  set; }
        public string hver_skráði { get;  set; }
        public string dags_skráð { get;  set; }
        public string hver_breytti { get;  set; }
        public string dags_breytt { get;  set; } 
        #endregion

        public void hreinsaHlut()
        {
            this.ID = 0;
            this.opinbert_auðkenni = string.Empty;
            this.gerð_5_1_1 = string.Empty;
            this.opinbert_heiti_5_1_2 = string.Empty;
            this.erlent_heiti_5_1_3 = string.Empty;
            this.annað_heiti_aðlagað_5_1_4 = string.Empty;
            this.annað_heiti_5_1_5 = string.Empty;
            this.auðkenni_5_1_6 = string.Empty;
            this.tímabil_5_2_1 = string.Empty;
            this.saga_5_2_2 = string.Empty;
            this.staðsetning_5_2_3 = string.Empty;
            this.lagaleg_staða_5_2_4 = string.Empty;
            this.hlutverk_5_2_5 = string.Empty;
            this.tilheyrandi_lög_5_2_6 = string.Empty;
            this.innri_stjórnun_5_2_7 = string.Empty;
            this.almennt_samhengi_5_2_8 = string.Empty;
            this.auðkenni_lands_5_4_1 = string.Empty;
            this.auðkenni_vörslustofnunar_5_4_2 = string.Empty;
            this.reglur_staðlar_5_4_3 = string.Empty;
            this.skráningarstaða_5_4_4 = string.Empty;
            this.skráningarstig_5_4_5 = string.Empty;
            this.dagsetningar_5_4_6 = string.Empty;
            this.tungumál_5_4_7 = string.Empty;
            this.heimildir_5_4_8 = string.Empty;
            this.athugasemdir_5_4_9 = string.Empty;
            this.hver_skráði = string.Empty;
            this.dags_skráð = string.Empty;
            this.hver_breytti = string.Empty;
            this.dags_breytt = string.Empty;
        }
        public void vista()
        {

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
           //  5_4_8_heimildir, 5_4_9_athugasemdir, hver_skráði, dags_skráð, hver_breytti, dags_breytt
            command.Parameters.AddWithValue("@opinbert_auðkenni", this.opinbert_auðkenni);
            command.Parameters.AddWithValue("@5_1_1_gerð", this.gerð_5_1_1);
            command.Parameters.AddWithValue("@5_1_2_opinbert_heiti", this.opinbert_heiti_5_1_2);
            command.Parameters.AddWithValue("@5_1_3_erlent_heiti", this.erlent_heiti_5_1_3);
            command.Parameters.AddWithValue("@5_1_4_annað_heiti_aðlagað", this.annað_heiti_aðlagað_5_1_4);
            command.Parameters.AddWithValue("@5_1_5_annað_heiti", this.annað_heiti_5_1_5);
            command.Parameters.AddWithValue("@5_1_6_auðkenni", this.auðkenni_5_1_6);
            command.Parameters.AddWithValue("@5_2_1_tímabil", this.tímabil_5_2_1);
            command.Parameters.AddWithValue("@5_2_2_saga", this.saga_5_2_2);
            command.Parameters.AddWithValue("@5_2_3_staðsetning", this.staðsetning_5_2_3);
            command.Parameters.AddWithValue("@5_2_4_lagaleg_staða", this.lagaleg_staða_5_2_4);
            command.Parameters.AddWithValue("@5_2_5_hlutverk", this.hlutverk_5_2_5);
            command.Parameters.AddWithValue("@5_2_6_tilheyrandi_lög", this.tilheyrandi_lög_5_2_6);
            command.Parameters.AddWithValue("@5_2_7_innri_stjórnun", this.innri_stjórnun_5_2_7);
            command.Parameters.AddWithValue("@5_2_8_almennt_samhengi", this.almennt_samhengi_5_2_8);
            command.Parameters.AddWithValue("@5_4_1_auðkenni_lands", this.auðkenni_lands_5_4_1);
            command.Parameters.AddWithValue("@5_4_2_auðkenni_vörslustofnunar", this.auðkenni_vörslustofnunar_5_4_2);
            command.Parameters.AddWithValue("@5_4_3_reglur_staðlar", this.reglur_staðlar_5_4_3);
            command.Parameters.AddWithValue("@5_4_4_skráningarstaða", this.skráningarstaða_5_4_4);
            command.Parameters.AddWithValue("@5_4_5_skráningarstig", this.skráningarstig_5_4_5);
        //    command.Parameters.AddWithValue("@5_4_6_dagsetningar", this.dagsetningar_5_4_6);
            command.Parameters.AddWithValue("@5_4_7_tungumál", this.tungumál_5_4_7);
            command.Parameters.AddWithValue("@5_4_8_heimildir", this.heimildir_5_4_8);
            command.Parameters.AddWithValue("@5_4_9_athugasemdir", this.athugasemdir_5_4_9);

            command.Parameters.AddWithValue("@hver_skráði", this.hver_skráði);
            command.Parameters.AddWithValue("@dags_skráð", this.dags_skráð);
            command.Parameters.AddWithValue("@hver_breytti", this.hver_breytti);
            command.Parameters.AddWithValue("@dags_breytt", this.dags_breytt);


            if (this.ID != 0)
            {
                string strNewDate = string.Format("Breytt: {0} af {1}", DateTime.Now, this.hver_breytti);
                string strDagsetningar = this.dagsetningar_5_4_6 + Environment.NewLine + strNewDate;
                command.Parameters.AddWithValue("@5_4_6_dagsetningar", strDagsetningar);
            }
            else
            {
                string strNewDate = string.Format("Skráð: {0} af {1}", DateTime.Now, this.hver_skráði);
                command.Parameters.AddWithValue("@5_4_6_dagsetningar", strNewDate);
            }

            if(this.ID == 0)
            {
                command.CommandText = "INSERT INTO `dt_isaar_skjalamyndarar` SET  `opinbert_auðkenni`=@opinbert_auðkenni,  `5_1_1_gerð`=@5_1_1_gerð, `5_1_2_opinbert_heiti`=@5_1_2_opinbert_heiti, `5_1_3_erlent_heiti`=@5_1_3_erlent_heiti, `5_1_4_annað_heiti_aðlagað`=@5_1_4_annað_heiti_aðlagað,`5_1_5_annað_heiti`=@5_1_5_annað_heiti,`5_1_6_auðkenni`=@5_1_6_auðkenni,`5_2_1_tímabil`=@5_2_1_tímabil,`5_2_2_saga`=@5_2_2_saga,`5_2_3_staðsetning`=@5_2_3_staðsetning,`5_2_4_lagaleg_staða`=@5_2_4_lagaleg_staða,`5_2_5_hlutverk`=@5_2_5_hlutverk,`5_2_6_tilheyrandi_lög`=@5_2_6_tilheyrandi_lög,`5_2_7_innri_stjórnun`=@5_2_7_innri_stjórnun,`5_2_8_almennt_samhengi`=@5_2_8_almennt_samhengi,`5_4_1_auðkenni_lands`=@5_4_1_auðkenni_lands,`5_4_2_auðkenni_vörslustofnunar`=@5_4_2_auðkenni_vörslustofnunar,`5_4_3_reglur_staðlar`=@5_4_3_reglur_staðlar,`5_4_4_skráningarstaða`=@5_4_4_skráningarstaða,`5_4_5_skráningarstig`=@5_4_5_skráningarstig,`5_4_6_dagsetningar`=@5_4_6_dagsetningar,`5_4_7_tungumál`=@5_4_7_tungumál,`5_4_8_heimildir`=@5_4_8_heimildir,`5_4_9_athugasemdir`=@5_4_9_athugasemdir,`hver_skráði`=@hver_skráði, dags_skráð=Now()";
            }
            else
            {
                command.CommandText = "UPDATE `dt_isaar_skjalamyndarar` SET  `opinbert_auðkenni`=@opinbert_auðkenni,  `5_1_1_gerð`=@5_1_1_gerð, `5_1_2_opinbert_heiti`=@5_1_2_opinbert_heiti, `5_1_3_erlent_heiti`=@5_1_3_erlent_heiti, `5_1_4_annað_heiti_aðlagað`=@5_1_4_annað_heiti_aðlagað,`5_1_5_annað_heiti`=@5_1_5_annað_heiti,`5_1_6_auðkenni`=@5_1_6_auðkenni,`5_2_1_tímabil`=@5_2_1_tímabil,`5_2_2_saga`=@5_2_2_saga,`5_2_3_staðsetning`=@5_2_3_staðsetning,`5_2_4_lagaleg_staða`=@5_2_4_lagaleg_staða,`5_2_5_hlutverk`=@5_2_5_hlutverk,`5_2_6_tilheyrandi_lög`=@5_2_6_tilheyrandi_lög,`5_2_7_innri_stjórnun`=@5_2_7_innri_stjórnun,`5_2_8_almennt_samhengi`=@5_2_8_almennt_samhengi,`5_4_1_auðkenni_lands`=@5_4_1_auðkenni_lands,`5_4_2_auðkenni_vörslustofnunar`=@5_4_2_auðkenni_vörslustofnunar,`5_4_3_reglur_staðlar`=@5_4_3_reglur_staðlar,`5_4_4_skráningarstaða`=@5_4_4_skráningarstaða,`5_4_5_skráningarstig`=@5_4_5_skráningarstig,`5_4_6_dagsetningar`=@5_4_6_dagsetningar,`5_4_7_tungumál`=@5_4_7_tungumál,`5_4_8_heimildir`=@5_4_8_heimildir,`5_4_9_athugasemdir`=@5_4_9_athugasemdir,`hver_breytti`=@hver_breytti, dags_breytt=Now() WHERE id=" + this.ID + ";";
                command.ExecuteNonQuery();
                command.CommandText = "UPDATE `dt_vörsluutgafur` set `skjalm_heiti` = @5_1_2_opinbert_heiti where `skjalamyndari`=@5_1_6_auðkenni;";
            }

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
        public DataTable getENUM() 
        {
            string strSQL = string.Format("SELECT SUBSTRING(COLUMN_TYPE,5) as gerð FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='db_oais_admin' AND TABLE_NAME='dt_isaar_skjalamyndarar'AND COLUMN_NAME='5_1_1_gerð';");
            var strengur = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt.Columns.Add("gerd");
            string[] strSplit = strengur.ToString().Split(',');
            foreach(string str in strSplit)
            {
                DataRow r = dt.NewRow();
                string strGerð = str.Replace("(","");
                strGerð = strGerð.Replace(")", "");
                strGerð = strGerð.Replace("\'", "");
                r["gerd"] = strGerð;
                dt.Rows.Add(r);
                dt.AcceptChanges();

            }
          
            return dt;
        }

        public DataTable getENUMSkraningStaða()
        {
            string strSQL = string.Format("SELECT SUBSTRING(COLUMN_TYPE,5) as gerð FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='db_oais_admin' AND TABLE_NAME='dt_isaar_skjalamyndarar'AND COLUMN_NAME='5_4_4_skráningarstaða';");
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

        public DataTable getSkjalamyndaralista()
        {
            string strSQL = "SELECT d.`5_1_2_opinbert_heiti`, d.`id`, 5_1_6_auðkenni FROM db_oais_admin.dt_isaar_skjalamyndarar d order by 5_1_2_opinbert_heiti;";
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getSkjalamyndaralistaGU()
        {
            string strSQL = "SELECT 5_1_6_auðkenni, 5_1_2_opinbert_heiti as heiti,5_1_1_gerð as gerd, 5_2_1_tímabil as timabil, hver_skráði, dags_skráð, 5_4_2_auðkenni_vörslustofnunar, '' as fullskra FROM db_oais_admin.dt_isaar_skjalamyndarar d order by 5_1_2_opinbert_heiti ;";
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getSkjalamyndaraVörslustofnun(string strVarsla)
        {
            string strSQL = string.Format("SELECT 5_1_1_auðkenni, 5_1_2_opinbert_heiti, klasar FROM db_oais_admin.`dt_isdiah_vörslustofnanir` d WHERE 5_1_1_auðkenni = '{0}';",strVarsla);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getENUMSkraningStig()
        {
            string strSQL = string.Format("SELECT SUBSTRING(COLUMN_TYPE, 5) as gerð FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'db_oais_admin' AND TABLE_NAME = 'dt_isaar_skjalamyndarar'AND COLUMN_NAME = '5_4_5_skráningarstig'; ");
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
        public void getSkjalamyndara(string strHeiti)
        {
            string strSQL = string.Format("SELECT * FROM db_oais_admin.dt_isaar_skjalamyndarar d where 5_1_2_opinbert_heiti = '{0}';", strHeiti);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging,strSQL);
            DataTable dt = ds.Tables[0];

            if(dt.Rows.Count > 0) 
            {
                foreach(DataRow r in dt.Rows)
                {
                   this.ID = Convert.ToInt32(r["id"]);
                   this.opinbert_auðkenni = r["opinbert_auðkenni"].ToString();
                   this.gerð_5_1_1= r["5_1_1_gerð"].ToString();
                   this.opinbert_heiti_5_1_2 = r["5_1_2_opinbert_heiti"].ToString();
                   this.erlent_heiti_5_1_3 = r["5_1_3_erlent_heiti"].ToString();
                   this.annað_heiti_aðlagað_5_1_4 = r["5_1_4_annað_heiti_aðlagað"].ToString();
                   this.annað_heiti_5_1_5 = r["5_1_5_annað_heiti"].ToString();
                   this.auðkenni_5_1_6 = r["5_1_6_auðkenni"].ToString();
                   this.tímabil_5_2_1 = r["5_2_1_tímabil"].ToString();
                   this.saga_5_2_2 = r["5_2_2_saga"].ToString();
                   this.staðsetning_5_2_3 = r["5_2_3_staðsetning"].ToString();
                   this.lagaleg_staða_5_2_4 = r["5_2_4_lagaleg_staða"].ToString();
                   this.hlutverk_5_2_5 = r["5_2_5_hlutverk"].ToString();
                   this.tilheyrandi_lög_5_2_6 = r["5_2_6_tilheyrandi_lög"].ToString();
                   this.innri_stjórnun_5_2_7= r["5_2_7_innri_stjórnun"].ToString();
                   this.almennt_samhengi_5_2_8 = r["5_2_8_almennt_samhengi"].ToString();
                   this.auðkenni_lands_5_4_1= r["5_4_1_auðkenni_lands"].ToString();
                   this.auðkenni_vörslustofnunar_5_4_2= r["5_4_2_auðkenni_vörslustofnunar"].ToString();
                   this.reglur_staðlar_5_4_3= r["5_4_3_reglur_staðlar"].ToString();
                   this.skráningarstaða_5_4_4= r["5_4_4_skráningarstaða"].ToString();
                   this.skráningarstig_5_4_5= r["5_4_5_skráningarstig"].ToString();
                   this.dagsetningar_5_4_6 = r["5_4_6_dagsetningar"].ToString();
                   this.tungumál_5_4_7 = r["5_4_7_tungumál"].ToString();
                   this.heimildir_5_4_8 = r["5_4_8_heimildir"].ToString();
                   this.athugasemdir_5_4_9 = r["5_4_9_athugasemdir"].ToString();


                   this.hver_skráði = r["hver_skráði"].ToString();
                   this.dags_skráð = r["dags_skráð"].ToString();
                   this.hver_breytti = r["hver_breytti"].ToString();
                   this.dags_breytt= r["dags_breytt"].ToString();
                }
                
            }

        }

        public void getSkjalamyndaraByAuðkenni(string strAuðkenni)
        {
            string strSQL = string.Format("SELECT * FROM db_oais_admin.dt_isaar_skjalamyndarar d where 5_1_6_auðkenni = '{0}';", strAuðkenni);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    this.ID = Convert.ToInt32(r["id"]);
                    this.opinbert_auðkenni = r["opinbert_auðkenni"].ToString();
                    this.gerð_5_1_1 = r["5_1_1_gerð"].ToString();
                    this.opinbert_heiti_5_1_2 = r["5_1_2_opinbert_heiti"].ToString();
                    this.erlent_heiti_5_1_3 = r["5_1_3_erlent_heiti"].ToString();
                    this.annað_heiti_aðlagað_5_1_4 = r["5_1_4_annað_heiti_aðlagað"].ToString();
                    this.annað_heiti_5_1_5 = r["5_1_5_annað_heiti"].ToString();
                    this.auðkenni_5_1_6 = r["5_1_6_auðkenni"].ToString();
                    this.tímabil_5_2_1 = r["5_2_1_tímabil"].ToString();
                    this.saga_5_2_2 = r["5_2_2_saga"].ToString();
                    this.staðsetning_5_2_3 = r["5_2_3_staðsetning"].ToString();
                    this.lagaleg_staða_5_2_4 = r["5_2_4_lagaleg_staða"].ToString();
                    this.hlutverk_5_2_5 = r["5_2_5_hlutverk"].ToString();
                    this.tilheyrandi_lög_5_2_6 = r["5_2_6_tilheyrandi_lög"].ToString();
                    this.innri_stjórnun_5_2_7 = r["5_2_7_innri_stjórnun"].ToString();
                    this.almennt_samhengi_5_2_8 = r["5_2_8_almennt_samhengi"].ToString();
                    this.auðkenni_lands_5_4_1 = r["5_4_1_auðkenni_lands"].ToString();
                    this.auðkenni_vörslustofnunar_5_4_2 = r["5_4_2_auðkenni_vörslustofnunar"].ToString();
                    this.reglur_staðlar_5_4_3 = r["5_4_3_reglur_staðlar"].ToString();
                    this.skráningarstaða_5_4_4 = r["5_4_4_skráningarstaða"].ToString();
                    this.skráningarstig_5_4_5 = r["5_4_5_skráningarstig"].ToString();
                    this.dagsetningar_5_4_6 = r["5_4_6_dagsetningar"].ToString();
                    this.tungumál_5_4_7 = r["5_4_7_tungumál"].ToString();
                    this.heimildir_5_4_8 = r["5_4_8_heimildir"].ToString();
                    this.athugasemdir_5_4_9 = r["5_4_9_athugasemdir"].ToString();


                    this.hver_skráði = r["hver_skráði"].ToString();
                    this.dags_skráð = r["dags_skráð"].ToString();
                    this.hver_breytti = r["hver_breytti"].ToString();
                    this.dags_breytt = r["dags_breytt"].ToString();
                }

            }

        }

        public void getSkjalamyndara(int id)
        {
            string strSQL = string.Format("SELECT * FROM db_oais_admin.dt_isaar_skjalamyndarar d where id = '{0}';", id);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    this.ID = Convert.ToInt32(r["id"]);
                    this.opinbert_auðkenni = r["opinbert_auðkenni"].ToString();
                    this.gerð_5_1_1 = r["5_1_1_gerð"].ToString();
                    this.opinbert_heiti_5_1_2 = r["5_1_2_opinbert_heiti"].ToString();
                    this.erlent_heiti_5_1_3 = r["5_1_3_erlent_heiti"].ToString();
                    this.annað_heiti_aðlagað_5_1_4 = r["5_1_4_annað_heiti_aðlagað"].ToString();
                    this.annað_heiti_5_1_5 = r["5_1_5_annað_heiti"].ToString();
                    this.auðkenni_5_1_6 = r["5_1_6_auðkenni"].ToString();
                    this.tímabil_5_2_1 = r["5_2_1_tímabil"].ToString();
                    this.saga_5_2_2 = r["5_2_2_saga"].ToString();
                    this.staðsetning_5_2_3 = r["5_2_3_staðsetning"].ToString();
                    this.lagaleg_staða_5_2_4 = r["5_2_4_lagaleg_staða"].ToString();
                    this.hlutverk_5_2_5 = r["5_2_5_hlutverk"].ToString();
                    this.tilheyrandi_lög_5_2_6 = r["5_2_6_tilheyrandi_lög"].ToString();
                    this.innri_stjórnun_5_2_7 = r["5_2_7_innri_stjórnun"].ToString();
                    this.almennt_samhengi_5_2_8 = r["5_2_8_almennt_samhengi"].ToString();
                    this.auðkenni_lands_5_4_1 = r["5_4_1_auðkenni_lands"].ToString();
                    this.auðkenni_vörslustofnunar_5_4_2 = r["5_4_2_auðkenni_vörslustofnunar"].ToString();
                    this.reglur_staðlar_5_4_3 = r["5_4_3_reglur_staðlar"].ToString();
                    this.skráningarstaða_5_4_4 = r["5_4_4_skráningarstaða"].ToString();
                    this.skráningarstig_5_4_5 = r["5_4_5_skráningarstig"].ToString();
                    this.dagsetningar_5_4_6 = r["5_4_6_dagsetningar"].ToString();
                    this.tungumál_5_4_7 = r["5_4_7_tungumál"].ToString();
                    this.heimildir_5_4_8 = r["5_4_8_heimildir"].ToString();
                    this.athugasemdir_5_4_9 = r["5_4_9_athugasemdir"].ToString();


                    this.hver_skráði = r["hver_skráði"].ToString();
                    this.dags_skráð = r["dags_skráð"].ToString();
                    this.hver_breytti = r["hver_breytti"].ToString();
                    this.dags_breytt = r["dags_breytt"].ToString();
                }

            }

        }

        public string næstaAUðkenni()
        {
            string strRet = string.Empty;
            string strSQL = string.Format("SELECT max(id) FROM db_oais_admin.dt_isaar_skjalamyndarar d;");
            var strID = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if(strID == DBNull.Value)
            {
                strRet = "00001";
            }
            else
            {
                int iID = Convert.ToInt32(strID) + 1;
                strRet = iID.ToString("00000");
            }

            return strRet;
        }

        public DataTable utgafurSkjalamyndara(string strAuðkenni)
        {
            string strSQL = string.Format("SELECT * FROM v_vorslustofnun v where skjalamyndari = '{0}';", strAuðkenni);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public int fjoldiVirkarUtgafna(string strAuðkenni)
        {
            int iRet = 0;
            string strSQL = string.Format("SELECT count(0) as fjoldi FROM db_oais_admin.`dt_vörsluutgafur` d where skjalamyndari = '{0}' and eytt = 0;", strAuðkenni);
            var Fjoldi = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if(Fjoldi != null)
            {
                iRet = Convert.ToInt32(Fjoldi);
            }
            return iRet;
        }

        public void eyða(string strAuðkenni)
        {
            string strSQL = string.Format("DELETE from dt_isaar_skjalamyndarar WHERE 5_1_6_auðkenni= '{0}'", strAuðkenni);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }

    }
}
