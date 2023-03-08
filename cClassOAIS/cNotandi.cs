using MySql.Data.MySqlClient;
using System.Data;

namespace cClassOAIS
{
    public class cNotandi
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
        #region GET/SET
        public string kennitala { get; private set; }
        public string notendanafn { get; private set; }
        public string lykilord { get; private set; }
        public int vörslustofnun { get; private set; }
        public string nafn { get; private set; }
        public string sidast_innskraning { get; private set; }
        public string athugasemdir { get; private set; }
        public string hver_skradi { get; private set; }
        public string dags_skrad { get; private set; }
        public string hver_breytti { get; private set; }
        public string dags_breytt { get; private set; }
        public int virkur { get; private set; }
        public string hlutverk { get; private set; }
        public string netfang { get; private set; }
        public string heimilisfang { get; private set; }

        public string simi { get; private set; } 
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
                this.vörslustofnun = Convert.ToInt32(r["vörslustofnun"]);
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
    }
}