//using DocumentFormat.OpenXml.Drawing.Charts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace cClassOAIS
{

    public class cMD5
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
        public int ID { get; set; }
        public string AIP { get; set; }
        public string slod { get; set; }
        public string file { get; set; }
        public string MD5 { get; set; }

        public void vista()
        {
            sækjaTengistreng();
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //  5_4_8_heimildir, 5_4_9_athugasemdir, hver_skráði, dags_skráð, hver_breytti, dags_breytt
            command.Parameters.AddWithValue("@id", this.ID);
            command.Parameters.AddWithValue("@AIP", this.AIP);
            command.Parameters.AddWithValue("@slod", this.slod);
            command.Parameters.AddWithValue("@file", this.file);
            command.Parameters.AddWithValue("@MD5", this.MD5);

            command.CommandText = "INSERT INTO `dt_md5` SET  `AIP`=@AIP,  `slod`=@slod, file=@file, MD5=@MD5, _date=NOW();";

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
        public void eyda(string strAIP)
        {
            sækjaTengistreng();
            string strSQL = string.Format("delete FROM db_oais_admin.dt_md5 d where AIP = '{0}';", strAIP);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }
        public string getMD5(string strSlod, string strUtgafa)
        {
            sækjaTengistreng();
            string strRet = string.Empty;
            string strSQL = string.Format("SELECT MD5 FROM dt_md5 d where slod like '%{0}' and AIP = '{1}';", strSlod, strUtgafa);
            var tala = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if(tala != null) 
            {
                strRet = tala.ToString();
            }
            return strRet;
        }
        public string getMD5RegEx(string strSlod, string strUtgafa)
        {
            sækjaTengistreng();
            string strRet = string.Empty;
            int iID = Convert.ToInt32(strSlod);
            double dColl = Convert.ToInt32(iID) / 10000;
            if (iID == 1)
            {
                dColl = 1;
            }
            else
            {
                dColl = dColl + 1;
            }
            string strSQL = string.Format("SELECT MD5 FROM dt_md5 d where AIP = '{1}' and slod regexp 'Documents\\\\\\\\docCollection{2}\\\\\\\\{0}$';", strSlod, strUtgafa, dColl);
            var tala = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if (tala != null)
            {
                strRet = tala.ToString();
            }
            return strRet;
        }

        public DataTable getMD5(string strMD5)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT '' as titill, vorsluutgafa,utgafa_titill, d.slod,v.slod as mappa, d.MD5, d.file FROM dt_md5 d, dt_vörsluutgafur v where d.AIP= v.vorsluutgafa and d.MD5 = '{0}';", strMD5);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public void uppfæraMD5(string strOld,string strNew) 
        {
            sækjaTengistreng();
            string strSQL = string.Format("UPDATE db_oais_admin.dt_md5 set MD5 = '{0}' WHERE MD5 ='{1}'", strNew,strOld);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }
    }  
    
}
