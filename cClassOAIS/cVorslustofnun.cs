using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.X.XDevAPI.Common;
using System.Data;
using System.Windows.Input;


namespace cClassOAIS
{
    public class cVorslustofnun
    {

        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
        #region GET/SET
        public int ID { get;  set; }
        public string auðkenni_5_1_1 { get;  set; }
        public string opinbert_heiti_5_1_2 { get;  set; }
        public string erlent_heiti_5_1_3 { get; set; }
        public string annað_heiti_5_1_4 { get; set; }
        public string tegund_5_1_5_ { get; set; }
        public string aðsetur_5_2_1 { get; set; }
        public string samskiptaleiðir_5_2_2 { get; set; }
        public string samskiptaaðilar_5_2_3 { get; set; }
        public string saga_stofnunar_5_3_1 { get; set; }
        public string landfræðilegt_samhengi_5_3_2 { get; set; }
        public string stjórnsýsluheimildir_5_3_3 { get; set; }
        public string stjórnsýsluleg_staða_5_3_4 { get; set; }
        public string varðveislustefna_5_3_5 { get; set; }
        public string byggingar_5_3_6 { get; set; }
        public string skjalaforði_5_3_7 { get; set; }
        public string útgáfur_5_3_8 { get; set; }
        public string opnunartímar_5_4_1 { get; set; }
        public string aðgangsforsendur_5_4_2 { get; set; }
        public string aðgengi_5_4_3 { get; set; }
        public string rannsóknarþjónusta_5_5_1 { get; set; }
        public string afritunarþjónusta_5_5_2 { get; set; }
        public string almenningssvæði_5_5_3 { get; set; }
        public string lýsandi_auðkenni_5_6_1 { get; set; }
        public string einkennandi_heiti_5_6_2 { get; set; }
        public string reglur_staðlar_5_6_3 { get; set; }
        public string skráningarstaða_5_6_4 { get; set; }
        public string skráningarstig_5_6_5 { get; set; }
        public string dagsetningar_5_6_6 { get; set; }
        public string tungumál_letur_5_6_7 { get; set; }
        public string heimildir_5_6_8 { get; set; }
        public string athugasemdir_5_6_9 { get; set; }
        public string hver_skráði { get; set; }
        public string dags_skráð { get; set; }
        public string hver_breytti { get; set; }
        public string dags_breytt { get; set; }
        #endregion
        public DataTable getENUMSkraningStaða()
        {
            string strSQL = string.Format("SELECT SUBSTRING(COLUMN_TYPE,5) as gerð FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='db_oais_admin' AND TABLE_NAME='dt_isdiah_vörslustofnanir'AND COLUMN_NAME='5_6_4_skráningarstaða';");
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

        public DataTable getENUMSkraningStig()
        {
            string strSQL = string.Format("SELECT SUBSTRING(COLUMN_TYPE, 5) as gerð FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'db_oais_admin' AND TABLE_NAME = 'dt_isdiah_vörslustofnanir'AND COLUMN_NAME = '5_6_5_skráningarstig'; ");
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

        public void hreinsaHlut()
        {

            this.ID = 0;
            this.auðkenni_5_1_1 = string.Empty;
            this.opinbert_heiti_5_1_2 = string.Empty;
            this.opinbert_heiti_5_1_2 = string.Empty;
            this.erlent_heiti_5_1_3 = string.Empty;
            this.annað_heiti_5_1_4 = string.Empty;
            this.tegund_5_1_5_ = string.Empty;
            this.aðsetur_5_2_1 = string.Empty;
            this.samskiptaleiðir_5_2_2 = string.Empty;
            this.samskiptaaðilar_5_2_3 = string.Empty;
            this.saga_stofnunar_5_3_1 = string.Empty;
            this.landfræðilegt_samhengi_5_3_2 = string.Empty;
            this.stjórnsýsluheimildir_5_3_3 = string.Empty;
            this.stjórnsýsluleg_staða_5_3_4 = string.Empty;
            this.varðveislustefna_5_3_5 = string.Empty;
            this.byggingar_5_3_6 = string.Empty;
            this.skjalaforði_5_3_7 = string.Empty;
            this.útgáfur_5_3_8 = string.Empty;
            this.opnunartímar_5_4_1 = string.Empty;
            this.aðgangsforsendur_5_4_2 = string.Empty;
            this.aðgengi_5_4_3 = string.Empty;
            this.rannsóknarþjónusta_5_5_1 = string.Empty;
            this.afritunarþjónusta_5_5_2 = string.Empty;
            this.almenningssvæði_5_5_3 = string.Empty;
            this.lýsandi_auðkenni_5_6_1 = string.Empty;
            this.einkennandi_heiti_5_6_2 = string.Empty;
            this.reglur_staðlar_5_6_3 = string.Empty;
            this.skráningarstaða_5_6_4 = string.Empty;
            this.skráningarstig_5_6_5 = string.Empty;
            this.dagsetningar_5_6_6 = string.Empty;
            this.tungumál_letur_5_6_7 = string.Empty;
            this.heimildir_5_6_8 = string.Empty;
            this.athugasemdir_5_6_9 = string.Empty;
            this.hver_skráði = string.Empty;
            this.dags_skráð = string.Empty;
            this.hver_breytti = string.Empty;
            this.dags_breytt = string.Empty;
        }   
        public  void getVörslustofnun(string strAuðkenni)
        {
            string strSQL = string.Format("SELECT * FROM db_oais_admin.`dt_isdiah_vörslustofnanir` d where 5_1_1_auðkenni = '{0}';", strAuðkenni);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach (DataRow r in dt.Rows)
            {
         
                this.ID = Convert.ToInt32(r["id"]);
                this.auðkenni_5_1_1 = r["5_1_1_auðkenni"].ToString();
                this.opinbert_heiti_5_1_2 = r["5_1_2_opinbert_heiti"].ToString();
                this.opinbert_heiti_5_1_2 = r["5_1_2_opinbert_heiti"].ToString();
                this.erlent_heiti_5_1_3 = r["5_1_3_erlent_heiti"].ToString();
                this.annað_heiti_5_1_4 = r["5_1_4_annað_heiti"].ToString();
                this.tegund_5_1_5_ = r["5_1_5_tegund"].ToString();
                this.aðsetur_5_2_1 = r["5_2_1_aðsetur"].ToString();
                this.samskiptaleiðir_5_2_2 = r["5_2_2_samskiptaleiðir"].ToString();
                this.samskiptaaðilar_5_2_3 = r["5_2_3_samskiptaaðilar"].ToString();
                this.saga_stofnunar_5_3_1 = r["5_3_1_saga_stofnunar"].ToString();
                this.landfræðilegt_samhengi_5_3_2 = r["5_3_2_landfræðilegt_samhengi"].ToString();
                this.stjórnsýsluheimildir_5_3_3 = r["5_3_3_stjórnsýsluheimildir"].ToString();
                this.stjórnsýsluleg_staða_5_3_4 = r["5_3_4_stjórnsýsluleg_staða"].ToString();
                this.varðveislustefna_5_3_5 = r["5_3_5_varðveislustefna"].ToString();
                this.byggingar_5_3_6 = r["5_3_6_byggingar"].ToString();
                this.skjalaforði_5_3_7 = r["5_3_7_skjalaforði"].ToString();
                this.útgáfur_5_3_8= r["5_3_8_útgáfur"].ToString();
                this.opnunartímar_5_4_1 = r["5_4_1_opnunartímar"].ToString();
                this.aðgangsforsendur_5_4_2 = r["5_4_2_aðgangsforsendur"].ToString();
                this.aðgengi_5_4_3 = r["5_4_3_aðgengi"].ToString();
                this.rannsóknarþjónusta_5_5_1 = r["5_5_1_rannsóknarþjónusta"].ToString();
                this.afritunarþjónusta_5_5_2 = r["5_5_2_afritunarþjónusta"].ToString();
                this.almenningssvæði_5_5_3 = r["5_5_3_almenningssvæði"].ToString();
                this.lýsandi_auðkenni_5_6_1= r["5_6_1_lýsandi_auðkenni"].ToString();
                this.einkennandi_heiti_5_6_2 = r["5_6_2_einkennandi_heiti"].ToString();
                this.reglur_staðlar_5_6_3 = r["5_6_3_reglur_staðlar"].ToString();
                this.skráningarstaða_5_6_4 = r["5_6_4_skráningarstaða"].ToString();
                this.skráningarstig_5_6_5 = r["5_6_5_skráningarstig"].ToString();
                this.dagsetningar_5_6_6 = r["5_6_6_dagsetningar"].ToString();
                this.tungumál_letur_5_6_7 = r["5_6_7_tungumál_letur"].ToString();
                this.heimildir_5_6_8 = r["5_6_8_heimildir"].ToString();
                this.athugasemdir_5_6_9= r["5_6_9_athugasemdir"].ToString();
                this.hver_skráði = r["hver_skráði"].ToString();
                this.dags_skráð = r["dags_skráð"].ToString();
                this.hver_breytti = r["hver_breytti"].ToString();
                this.dags_breytt = r["dags_breytt"].ToString();

            }
        }

        public void vista()
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            // 5_6_6_dagsetningar, 5_6_7_tungumál_letur, 5_6_8_heimildir, 5_6_9_athugasemdir, hver_skráði, dags_skráð, hver_breytti, dags_breytt

            command.Parameters.AddWithValue("@id", this.ID);
            command.Parameters.AddWithValue("@5_1_1_auðkenni", this.auðkenni_5_1_1);
            command.Parameters.AddWithValue("@5_1_2_opinbert_heiti", this.opinbert_heiti_5_1_2);
            command.Parameters.AddWithValue("@5_1_3_erlent_heiti", this.erlent_heiti_5_1_3);
            command.Parameters.AddWithValue("@5_1_4_annað_heiti", this.annað_heiti_5_1_4);
            command.Parameters.AddWithValue("@5_1_5_tegund", this.tegund_5_1_5_);
            command.Parameters.AddWithValue("@5_2_1_aðsetur", this.aðsetur_5_2_1);
            command.Parameters.AddWithValue("@5_2_2_samskiptaleiðir", this.samskiptaleiðir_5_2_2);
            command.Parameters.AddWithValue("@5_2_3_samskiptaaðilar", this.samskiptaaðilar_5_2_3);
            command.Parameters.AddWithValue("@5_3_1_saga_stofnunar", this.saga_stofnunar_5_3_1);
            command.Parameters.AddWithValue("@5_3_2_landfræðilegt_samhengi", this.landfræðilegt_samhengi_5_3_2);
            command.Parameters.AddWithValue("@5_3_3_stjórnsýsluheimildir", this.stjórnsýsluheimildir_5_3_3);
            command.Parameters.AddWithValue("@5_3_4_stjórnsýsluleg_staða", this.stjórnsýsluleg_staða_5_3_4);
            command.Parameters.AddWithValue("@5_3_5_varðveislustefna", this.varðveislustefna_5_3_5);
            command.Parameters.AddWithValue("@5_3_6_byggingar", this.byggingar_5_3_6);
            command.Parameters.AddWithValue("@5_3_7_skjalaforði", this.skjalaforði_5_3_7);
            command.Parameters.AddWithValue("@5_3_8_útgáfur", this.útgáfur_5_3_8);
            command.Parameters.AddWithValue("@5_4_1_opnunartímar", this.opnunartímar_5_4_1);
            command.Parameters.AddWithValue("@5_4_2_aðgangsforsendur", this.aðgangsforsendur_5_4_2);
            command.Parameters.AddWithValue("@5_4_3_aðgengi", this.aðgengi_5_4_3);
            command.Parameters.AddWithValue("@5_5_1_rannsóknarþjónusta", this.rannsóknarþjónusta_5_5_1);
            command.Parameters.AddWithValue("@5_5_2_afritunarþjónusta", this.afritunarþjónusta_5_5_2);
            command.Parameters.AddWithValue("@5_5_3_almenningssvæði", this.almenningssvæði_5_5_3);
            command.Parameters.AddWithValue("@5_6_1_lýsandi_auðkenni", this.lýsandi_auðkenni_5_6_1);
            command.Parameters.AddWithValue("@5_6_2_einkennandi_heiti", this.einkennandi_heiti_5_6_2);
            command.Parameters.AddWithValue("@5_6_3_reglur_staðlar", this.reglur_staðlar_5_6_3);
            command.Parameters.AddWithValue("@5_6_4_skráningarstaða", this.skráningarstaða_5_6_4);
            command.Parameters.AddWithValue("@5_6_5_skráningarstig", this.skráningarstig_5_6_5);
           // command.Parameters.AddWithValue("@5_6_6_dagsetningar", this.dagsetningar_5_6_6);
            command.Parameters.AddWithValue("@5_6_7_tungumál_letur", this.tungumál_letur_5_6_7);
            command.Parameters.AddWithValue("@5_6_8_heimildir", this.heimildir_5_6_8);
            command.Parameters.AddWithValue("@5_6_9_athugasemdir", this.athugasemdir_5_6_9);
            command.Parameters.AddWithValue("@hver_skráði", this.hver_skráði);
            command.Parameters.AddWithValue("@dags_skráð", this.dags_skráð);
            command.Parameters.AddWithValue("@hver_breytti", this.hver_breytti);
            command.Parameters.AddWithValue("@dags_breytt", this.dags_breytt);


                if(this.ID != 0)
                {
                    string strNewDate = string.Format("Breytt: {0} af {1}", DateTime.Now, this.hver_breytti);
                    string strDagsetningar = this.dagsetningar_5_6_6 + Environment.NewLine + strNewDate;
                    command.Parameters.AddWithValue("@5_6_6_dagsetningar", strDagsetningar);
                }
                else
                {
                    string strNewDate = string.Format("Skráð: {0} af {1}", DateTime.Now, this.hver_skráði);
                    command.Parameters.AddWithValue("@5_6_6_dagsetningar", strNewDate);
                }
       
         
            if(this.ID == 0)
            {
                command.CommandText = "INSERT INTO `dt_isdiah_vörslustofnanir` SET  `id`=@id, `5_1_1_auðkenni`=@5_1_1_auðkenni, `5_1_2_opinbert_heiti`=@5_1_2_opinbert_heiti, `5_1_3_erlent_heiti`=@5_1_3_erlent_heiti, `5_1_4_annað_heiti`=@5_1_4_annað_heiti, `5_1_5_tegund`=@5_1_5_tegund, `5_2_1_aðsetur`=@5_2_1_aðsetur, `5_2_2_samskiptaleiðir`=@5_2_2_samskiptaleiðir, `5_2_3_samskiptaaðilar`=@5_2_3_samskiptaaðilar, `5_3_1_saga_stofnunar`=@5_3_1_saga_stofnunar, `5_3_2_landfræðilegt_samhengi`=@5_3_2_landfræðilegt_samhengi, `5_3_3_stjórnsýsluheimildir`=@5_3_3_stjórnsýsluheimildir, `5_3_4_stjórnsýsluleg_staða`=@5_3_4_stjórnsýsluleg_staða, `5_3_5_varðveislustefna`=@5_3_5_varðveislustefna, `5_3_6_byggingar`=@5_3_6_byggingar, `5_3_7_skjalaforði`=@5_3_7_skjalaforði, `5_3_8_útgáfur`=@5_3_8_útgáfur, `5_4_1_opnunartímar`=@5_4_1_opnunartímar, `5_4_2_aðgangsforsendur`=@5_4_2_aðgangsforsendur, `5_4_3_aðgengi`=@5_4_3_aðgengi, `5_5_1_rannsóknarþjónusta`=@5_5_1_rannsóknarþjónusta, `5_5_2_afritunarþjónusta`=@5_5_2_afritunarþjónusta, `5_5_3_almenningssvæði`=@5_5_3_almenningssvæði, `5_6_1_lýsandi_auðkenni`=@5_6_1_lýsandi_auðkenni, `5_6_2_einkennandi_heiti`=@5_6_2_einkennandi_heiti, `5_6_3_reglur_staðlar`=@5_6_3_reglur_staðlar, `5_6_4_skráningarstaða`=@5_6_4_skráningarstaða, `5_6_5_skráningarstig`=@5_6_5_skráningarstig, `5_6_6_dagsetningar`=@5_6_6_dagsetningar, `5_6_7_tungumál_letur`=@5_6_7_tungumál_letur, `5_6_8_heimildir`=@5_6_8_heimildir, `5_6_9_athugasemdir`=@5_6_9_athugasemdir, `hver_skráði`=@hver_skráði, `dags_skráð`=NOW();";
            }
            else
            {
                command.CommandText = "UPDATE `dt_isdiah_vörslustofnanir` SET  `id`=@id, `5_1_1_auðkenni`=@5_1_1_auðkenni, `5_1_2_opinbert_heiti`=@5_1_2_opinbert_heiti, `5_1_3_erlent_heiti`=@5_1_3_erlent_heiti, `5_1_4_annað_heiti`=@5_1_4_annað_heiti, `5_1_5_tegund`=@5_1_5_tegund, `5_2_1_aðsetur`=@5_2_1_aðsetur, `5_2_2_samskiptaleiðir`=@5_2_2_samskiptaleiðir, `5_2_3_samskiptaaðilar`=@5_2_3_samskiptaaðilar, `5_3_1_saga_stofnunar`=@5_3_1_saga_stofnunar, `5_3_2_landfræðilegt_samhengi`=@5_3_2_landfræðilegt_samhengi, `5_3_3_stjórnsýsluheimildir`=@5_3_3_stjórnsýsluheimildir, `5_3_4_stjórnsýsluleg_staða`=@5_3_4_stjórnsýsluleg_staða, `5_3_5_varðveislustefna`=@5_3_5_varðveislustefna, `5_3_6_byggingar`=@5_3_6_byggingar, `5_3_7_skjalaforði`=@5_3_7_skjalaforði, `5_3_8_útgáfur`=@5_3_8_útgáfur, `5_4_1_opnunartímar`=@5_4_1_opnunartímar, `5_4_2_aðgangsforsendur`=@5_4_2_aðgangsforsendur, `5_4_3_aðgengi`=@5_4_3_aðgengi, `5_5_1_rannsóknarþjónusta`=@5_5_1_rannsóknarþjónusta, `5_5_2_afritunarþjónusta`=@5_5_2_afritunarþjónusta, `5_5_3_almenningssvæði`=@5_5_3_almenningssvæði, `5_6_1_lýsandi_auðkenni`=@5_6_1_lýsandi_auðkenni, `5_6_2_einkennandi_heiti`=@5_6_2_einkennandi_heiti, `5_6_3_reglur_staðlar`=@5_6_3_reglur_staðlar, `5_6_4_skráningarstaða`=@5_6_4_skráningarstaða, `5_6_5_skráningarstig`=@5_6_5_skráningarstig, `5_6_6_dagsetningar`=@5_6_6_dagsetningar, `5_6_7_tungumál_letur`=@5_6_7_tungumál_letur, `5_6_8_heimildir`=@5_6_8_heimildir, `5_6_9_athugasemdir`=@5_6_9_athugasemdir, `hver_breytti`=@hver_breytti, `dags_breytt`=NOW() where  `id`=@id;";
            }
   
            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

    }

   
}
