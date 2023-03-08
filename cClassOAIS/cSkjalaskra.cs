using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassOAIS
{
    public class cSkjalaskra
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
        #region GET/SET
        public int ID { get; private set; }
        public int vörslustofnun { get; private set; }
        public int skjalamyndari { get; private set; }
        public int tilheyrir_skráningu { get; private set; }
        public string ritskoðun { get; private set; }
        public string auðkenn_3_1_1 { get; private set; }
        public string titill_3_1_2 { get; private set; }
        public string tímabil_3_1_3 { get; private set; }
        public string upplýsingastig_3_1_4 { get; private set; }
        public string magn_lýsing_3_1_5 { get; private set; }
        public string heiti_skjalamyndara_3_2_1 { get; private set; }
        public string saga_skjalamyndara_3_2_2 { get; private set; }
        public string saga_skjalanna_3_2_3 { get; private set; }
        public string afhendingar_tilfærslur_3_2_4 { get; private set; }
        public string yfirlit_innihald_3_3_1 { get; private set; }
        public string tímaáætlanir_3_3_2 { get; private set; }
        public string fyrirsjáanlegar_viðbætur_3_3_3 { get; private set; }
        public string innri_skipan_3_3_4 { get; private set; }
        public string skilyrði_aðgengi_3_4_1 { get; private set; }
        public string skilyrði_endurprentun_3_4_2 { get; private set; }
        public string tungumál_3_4_3 { get; private set; }
        public string ytri_einkenni_3_4_4 { get; private set; }
        public string hjálpargögn_3_4_5 { get; private set; }
        public string tilvist_frumrita_3_5_1 { get; private set; }
        public string tilvist_afrita_3_5_2 { get; private set; }
        public string skyld_skjöl_3_5_3 { get; private set; }
        public string útgáfuupplýsingar_3_5_4 { get; private set; }
        public string athugasemdir_3_6_1 { get; private set; }
        public string athugasemdir_skjalavarðar_3_7_1 { get; private set; }
        public string reglur_venjur_3_7_2 { get; private set; }
        public string dagsetningar_3_7_3 { get; private set; }
        public string hver_skráði { get; private set; }
        public string dags_skráð { get; private set; }
        public string hver_breytti { get; private set; }
        public string dags_breytt { get; private set; }
        #endregion
       
    }
}
