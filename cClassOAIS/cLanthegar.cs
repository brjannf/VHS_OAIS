using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassOAIS
{
    public class cLanthegar
    {
        private string m_strTenging = string.Empty; //"server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
        public bool m_bAfrit = false;
        private void sækjaTengistreng()
        {
            if (m_bAfrit)
            {
                m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin_afrit; allow user variables = True; character set = utf8";
            }
            else
            {
                m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
            }
        }
        //id, nafn, kennitala, nafn_fyrirtaekis, kennitala_fyrirtaekis, simi, netfang, dags_skrad, skrad_af
        public int id { get; set; }
        public string nafn { get; set; }
        public string kennitala { get; set; }
        public string nafn_fyrirtaekis { get; set; }
        public string kennitala_fyrirtaekis { get; set; }
        public string simi { get; set; }
        public string netfang { get; set; }
        public string dags_skrad { get; set; }
        public string skrad_af { get; set; }

        public void vista()
        {
            sækjaTengistreng();
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //id, nafn, kennitala, nafn_fyrirtaekis, kennitala_fyrirtaekis, simi, netfang, dags_skrad, skrad_af
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@nafn", this.nafn);
            command.Parameters.AddWithValue("@kennitala", this.kennitala);
            command.Parameters.AddWithValue("@nafn_fyrirtaekis", this.nafn_fyrirtaekis);
            command.Parameters.AddWithValue("@kennitala_fyrirtaekis", this.kennitala_fyrirtaekis);
            command.Parameters.AddWithValue("@simi", this.simi);
            command.Parameters.AddWithValue("@netfang", this.netfang);
            command.Parameters.AddWithValue("@skrad_af", this.skrad_af);

            if (this.id == 0)
            {
                command.CommandText = "REPLACE INTO `dt_lanthegar` SET  `nafn`=@nafn,  `kennitala`=@kennitala, `nafn_fyrirtaekis`=@nafn_fyrirtaekis, `kennitala_fyrirtaekis`=@kennitala_fyrirtaekis, `simi`=@simi,`netfang`=@netfang,`skrad_af`=@skrad_af,`dags_skrad`=NOW();";
            }
            else
            {
               // command.CommandText = string.Format("UPDATE `dt_notendur` SET  `kennitala`=@kennitala,  `notendanafn`=@notendanafn, `lykilorð`=@lykilorð, `vörslustofnun`=@vörslustofnun, `nafn`=@nafn,`virkur`=@virkur,`athugasemdir`=@athugasemdir,`hver_breytti`=@hver_breytti,`hlutverk`=@hlutverk,`email`=@email,`heimilisfang`=@heimilisfang,`simi`=@simi,`dags_breytt`=NOW() WHERE kennitala ={0};", strKennitala);
            }
            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();

        }
        public DataTable getLanthegaLista()
        {
            sækjaTengistreng();
            string strSQL = "SELECT * FROM dt_lanthegar d order by nafn;";
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public void getaLanthega(string strID)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_lanthegar d where id = {0};", strID);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                //id, nafn, kennitala, nafn_fyrirtaekis, kennitala_fyrirtaekis, simi, netfang, dags_skrad, skrad_af
                this.id = Convert.ToInt32(r["id"]); 
                this.kennitala = r["kennitala"].ToString();
                this.nafn_fyrirtaekis = r["nafn_fyrirtaekis"].ToString();
                this.kennitala_fyrirtaekis = r["kennitala_fyrirtaekis"].ToString();
                this.nafn = r["nafn"].ToString();
                this.simi = r["simi"].ToString();
                this.netfang = r["netfang"].ToString();
                this.dags_skrad = r["dags_skrad"].ToString();
                this.skrad_af = r["skrad_af"].ToString();
               

            }

        }

    }

}
