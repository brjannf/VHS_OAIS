using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassOAIS
{
    public class cSkjalamyndari
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";


        #region GET/SET
        public int id { get;set; }
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

        public void vista()
        {

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
           // id, opinbert_auðkenni, 5_1_1_gerð, 5_1_2_opinbert_heiti, 5_1_3_erlent_heiti, 5_1_4_annað_heiti_aðlagað, 5_1_5_annað_heiti, 5_1_6_auðkenni, 5_2_1_tímabil, 5_2_2_saga, 5_2_3_staðsetning, 5_2_4_lagaleg_staða, 5_2_5_hlutverk, 5_2_6_tilheyrandi_lög, 5_2_7_innri_stjórnun, 5_2_8_almennt_samhengi, 5_4_1_auðkenni_lands, 5_4_2_auðkenni_vörslustofnunar, 5_4_3_reglur_staðlar, 5_4_4_skráningarstaða, 5_4_5_skráningarstig, 5_4_6_dagsetningar, 5_4_7_tungumál, 5_4_8_heimildir, 5_4_9_athugasemdir, hver_skráði, dags_skráð, hver_breytti, dags_breytt
            command.Parameters.AddWithValue("@opinbert_auðkenni", this.opinbert_auðkenni);
            command.Parameters.AddWithValue("@5_1_1_gerð", this.gerð_5_1_1);
            command.Parameters.AddWithValue("@5_1_2_opinbert_heiti", this.opinbert_heiti_5_1_2);
            command.Parameters.AddWithValue("@5_1_3_erlent_heiti", this.erlent_heiti_5_1_3);
            command.Parameters.AddWithValue("@5_1_4_annað_heiti_aðlagað", this.annað_heiti_aðlagað_5_1_4);
            command.Parameters.AddWithValue("@5_1_5_annað_heiti", this.auðkenni_5_1_6);
            command.Parameters.AddWithValue("@5_1_6_auðkenni", this.auðkenni_5_1_6);

            command.Parameters.AddWithValue("@hver_skráði", this.hver_skráði);

            command.CommandText = "INSERT INTO `dt_isaar_skjalamyndarar` SET  `opinbert_auðkenni`=@opinbert_auðkenni,  `5_1_1_gerð`=@5_1_1_gerð, `5_1_2_opinbert_heiti`=@5_1_2_opinbert_heiti, `5_1_3_erlent_heiti`=@5_1_3_erlent_heiti, `5_1_4_annað_heiti_aðlagað`=@5_1_4_annað_heiti_aðlagað,`5_1_5_annað_heiti`=@5_1_5_annað_heiti,`5_1_6_auðkenni`=@5_1_6_auðkenni,`hver_skráði`=@hver_skráði, dags_skráð=Now()";
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
    }
}
