using MySql.Data.MySqlClient;
using System.Data;


namespace cClassOAIS
{
    public class cVorslustofnun
    {

        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
        #region GET/SET
        public int ID { get; private set; }
        public string auðkenni_5_1_1 { get; private set; }
        public string opinbert_heiti_5_1_2 { get; private set; }
        public string erlent_heiti_5_1_3 { get; private set; }
        public string annað_heiti_5_1_4 { get; private set; }
        public string tegund_5_1_5_ { get; private set; }
        public string aðsetur_5_2_1 { get; private set; }
        public string samskiptaleiðir_5_2_2 { get; private set; }
        public string samskiptaaðilar_5_2_3 { get; private set; }
        public string saga_stofnunar_5_3_1 { get; private set; }
        public string landfræðilegt_samhengi_5_3_2 { get; private set; }
        public string stjórnsýsluheimildir_5_3_3 { get; private set; }
        public string stjórnsýsluleg_staða_5_3_4 { get; private set; }
        public string varðveislustefna_5_3_5 { get; private set; }
        public string byggingar_5_3_6 { get; private set; }
        public string skjalaforði_5_3_7 { get; private set; }
        public string útgáfur_5_3_8 { get; private set; }
        public string opnunartímar_5_4_1 { get; private set; }
        public string aðgangsforsendur_5_4_2 { get; private set; }
        public string aðgengi_5_4_3 { get; private set; }
        public string rannsóknarþjónusta_5_5_1 { get; private set; }
        public string afritunarþjónusta_5_5_2 { get; private set; }
        public string almenningssvæði_5_5_3 { get; private set; }
        public string lýsandi_auðkenni_5_6_1 { get; private set; }
        public string einkennandi_heiti_5_6_2 { get; private set; }
        public string reglur_staðlar_5_6_3 { get; private set; }
        public string skráningarstaða_5_6_4 { get; private set; }
        public string skráningarstig_5_6_5 { get; private set; }
        public string dagsetningar_5_6_6 { get; private set; }
        public string tungumál_letur_5_6_7 { get; private set; }
        public string heimildir_5_6_8 { get; private set; }
        public string athugasemdir_5_6_9 { get; private set; }
        public string hver_skráði { get; private set; }
        public string dags_skráð { get; private set; }
        public string hver_breytti { get; private set; }
        public string dags_breytt { get; private set; }
        #endregion

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

    }

   
}
