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
    public class cDIPKarfa
    {
        private string m_strTenging = string.Empty; //"server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
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

       
        //karfa, heiti, lanthegi, hver_skradi, dags_skrad
        public int karfa { get; set; }
        public string heiti { get; set; }
        public string lanthegi { get; set; }
        public string hver_skradi { get; set; }
        public string dags_skrad { get; set; }
        public string athugasemdir { get; set; }

        public void vista()
        {
            sækjaTengistreng();
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //karfa, heiti, lanthegi, hver_skradi, dags_skrad
            command.Parameters.AddWithValue("@karfa", this.karfa);
            command.Parameters.AddWithValue("@heiti", this.heiti);
            command.Parameters.AddWithValue("@lanthegi", this.lanthegi);
            command.Parameters.AddWithValue("@hver_skradi", this.hver_skradi);
            command.Parameters.AddWithValue("@dags_skrad", this.dags_skrad);
            command.Parameters.AddWithValue("@athugasemdir", this.athugasemdir);


            if (this.karfa == 0)
            {
                command.CommandText = "REPLACE INTO `dt_karfa_dip` SET  `heiti`=@heiti,  `lanthegi`=@lanthegi, `athugasemdir`=@athugasemdir, `hver_skradi`=@hver_skradi,`dags_skrad`=NOW();";
            }
            else
            {
                 command.CommandText = string.Format("UPDATE `dt_karfa_dip` SET `athugasemdir`=@athugasemdir WHERE karfa ={0};", this.karfa);
            }
           
            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
            if(karfa== 0) 
            {
                var id = MySqlHelper.ExecuteScalar(m_strTenging, "SELECT MAX(karfa) FROM dt_karfa_dip");
                if (id != null)
                {
                    this.karfa = Convert.ToInt32(id);
                }
            }
           
        }
        public void sækjaKörfu(string strKarfa)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_karfa_dip d where karfa = '{0}';", strKarfa);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL );
            DataTable dt = ds.Tables[0];
            foreach(DataRow dr in dt.Rows)
            {
                //  karfa, heiti, lanthegi, hver_skradi, dags_skrad
                this.karfa = Convert.ToInt32(dr["karfa"]);
                this.heiti = dr["heiti"].ToString();
                this.lanthegi = dr["lanthegi"].ToString();
                this.hver_skradi = dr["hver_skradi"].ToString();
                this.dags_skrad = dr["dags_skrad"].ToString();
                this.athugasemdir = dr["athugasemdir"].ToString();
            }
        }
        public DataTable getKorfurDIP()
        {
            sækjaTengistreng();
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, "SELECT * FROM dt_karfa_dip d order by karfa desc; ");
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getKorfurDIPReportDummy()
        {
            sækjaTengistreng();
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, "SELECT karfa, '' lanthegi, '' as vorsluutgafa, '' as skrar, hver_skradi, dags_skrad, athugasemdir FROM dt_karfa_dip d order by karfa desc");
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getKorfurSkrarSkjol(string strKarfa)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_item_korfu_dip d where karfa = {0};", strKarfa);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public string getKorfurSkrarSkjol(string strKarfa, string strvorsluutgafa)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_item_korfu_dip d where karfa = {0} and heitiVorslu = '{1}';", strKarfa, strvorsluutgafa);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            string strRet = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                strRet += dr["titill"].ToString() + Environment.NewLine;
            }
            return strRet;
        }
        public string getKorfurMalSkjol(string strKarfa, string strvorsluutgafa)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_item_korfu_mal_dip d where karfa = {0} and heitiVorslu = '{1}';", strKarfa, strvorsluutgafa);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            string strRet = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                strRet += dr["titill"].ToString() + Environment.NewLine;
            }
            return strRet;
        }
        public string getKorfurGagnSkjol(string strKarfa, string strvorsluutgafa)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_karfa_item_gagna_dip d where karfa = {0} and heitiVorslu = '{1}';", strKarfa, strvorsluutgafa);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            string strRet = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                strRet += dr["leitarskilyrdi"].ToString() + Environment.NewLine;
            }
            return strRet;
        }

        public DataTable getKorfurGagnSkjol(string strKarfa)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_karfa_item_gagna_dip d where karfa = {0};", strKarfa);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getKorfurMalSkjol(string strKarfa)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_item_korfu_mal_dip d where karfa = {0};", strKarfa);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getKorfuLanthega(string strLan)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_karfa_dip d where lanthegi = {0} order by karfa desc;", strLan);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging,strSQL);
            DataTable dt = ds.Tables[0];
            return dt;

        }
        public void hreinsahlut()
        {
            this.karfa = 0;
            this.heiti = null;
            this.lanthegi = null;
            this.hver_skradi = null;
            this.dags_skrad = null;
            this.athugasemdir = null;
        }
    }
}

