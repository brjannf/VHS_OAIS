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
    public class cVorsluutgafur
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

        #region GET/SET
        // id, vorsluutgafa, utgafa_titill, vorslustofnun, varsla_heiti, skjalamyndari, skjalm_heiti, staerd, slod, hver_skradi, dags_skrad
        public int ID { get; set; }
        public string vorsluutgafa { get; set; }
        public string utgafa_titill { get; set; }
        public string vorslustofnun { get; set; }
        public string varsla_heiti { get; set; }
        public string tegund { get; set; }
        public string skjalamyndari { get; set; }
        public string skjalm_heiti { get; set; }
        public long staerd {get; set; }
        public string slod { get; set; }
        public string innihald { get; set; }
        public string timabil { get; set; }
        public string afharnr { get; set; }
        public string MD5 { get; set; }
        public string hver_skradi { get; set; }
        public DateTime dags_skrad { get; set; }
        public string adgangstakmarkanir { get; set; }
        public string eytt { get; set; }
        public string dags_eytt { get; set; }
        public string hver_eytti { get; set; }
        public string midlun { get; set; }
        public string dags_midlad { get; set; }
        public string hver_midladi { get; set; }
        public int frumeintak { get; set; }



        #endregion

        public void vista()
        {
            sækjaTengistreng();
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);

            // id, vorsluutgafa, utgafa_titill, vorslustofnun, varsla_heiti, skjalamyndari, skjalm_heiti, staerd, slod, hver_skradi, dags_skrad

            command.Parameters.AddWithValue("@id", this.ID);
            command.Parameters.AddWithValue("@vorsluutgafa", this.vorsluutgafa);
            command.Parameters.AddWithValue("@utgafa_titill", this.utgafa_titill);
            command.Parameters.AddWithValue("@vorslustofnun", this.vorslustofnun);
            command.Parameters.AddWithValue("@varsla_heiti", this.varsla_heiti);
            command.Parameters.AddWithValue("@tegund", this.tegund);
            command.Parameters.AddWithValue("@skjalamyndari", this.skjalamyndari);
            command.Parameters.AddWithValue("@skjalm_heiti", this.skjalm_heiti);
            command.Parameters.AddWithValue("@staerd", this.staerd);
            command.Parameters.AddWithValue("@slod", this.slod);
            command.Parameters.AddWithValue("@innihald", this.innihald);
            command.Parameters.AddWithValue("@timabil", this.timabil);
            command.Parameters.AddWithValue("@afharnr", this.afharnr);
            command.Parameters.AddWithValue("@MD5", this.MD5);
            command.Parameters.AddWithValue("@hver_skradi", this.hver_skradi);
            command.Parameters.AddWithValue("@adgangstakmarkanir", this.adgangstakmarkanir);
            command.Parameters.AddWithValue("@frumeintak", this.frumeintak);

            // command.Parameters.AddWithValue("@dags_skrad", this.dags_skrad);
            if (this.ID == 0)
            {
                command.CommandText = "INSERT INTO `dt_vörsluutgafur` SET  `vorsluutgafa`=@vorsluutgafa,`utgafa_titill`=@utgafa_titill,`vorslustofnun`=@vorslustofnun, `varsla_heiti`=@varsla_heiti,`tegund`=@tegund, `skjalamyndari`=@skjalamyndari,`skjalm_heiti`=@skjalm_heiti, `staerd`=@staerd, `slod`=@slod, `innihald`=@innihald, `timabil`=@timabil, `afharnr`=@afharnr, `MD5`=@MD5, `hver_skradi`=@hver_skradi,`adgangstakmarkanir`=@adgangstakmarkanir,`frumeintak`=@frumeintak, `dags_skrad`=NOW()";
            }
            else
            {
                command.CommandText = string.Format("UPDATE `dt_vörsluutgafur` SET `utgafa_titill`=@utgafa_titill,`vorslustofnun`=@vorslustofnun, `varsla_heiti`=@varsla_heiti,`tegund`=@tegund, `skjalamyndari`=@skjalamyndari,`skjalm_heiti`=@skjalm_heiti, `staerd`=@staerd, `slod`=@slod, `innihald`=@innihald, `timabil`=@timabil, `afharnr`=@afharnr, `MD5`=@MD5, `hver_skradi`=@hver_skradi,`adgangstakmarkanir`=@adgangstakmarkanir,`frumeintak`=@frumeintak, `dags_skrad`=NOW() WHERE vorsluutgafa='{0}'", this.vorsluutgafa);
            }
            

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();

        }

        public string erGagnagrunnur(string strID)
        {
            sækjaTengistreng();
           string strSQL = string.Format("Select orginal_heiti From ds_gagnagrunnar where vorsluutgafa = '{0}'", strID);
            var bErGagnagrunnur = MySqlHelper.ExecuteScalar( m_strTenging, strSQL);
            if (bErGagnagrunnur == null)
            {
                return string.Empty;
            }
            else
            {
                return bErGagnagrunnur.ToString();
            }
       
        }
        public void getVörsluútgáfu(string strAIP)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM `dt_vörsluutgafur` d where vorsluutgafa = '{0}'; ", strAIP);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach (DataRow r in dt.Rows)
            {
                this.ID = Convert.ToInt32(r["id"]);
                this.vorsluutgafa = r["vorsluutgafa"].ToString();
                this.utgafa_titill = r["utgafa_titill"].ToString();
                this.vorslustofnun = r["vorslustofnun"].ToString();
                this.varsla_heiti = r["varsla_heiti"].ToString();
                this.tegund = r["tegund"].ToString();
                this.skjalamyndari = r["skjalamyndari"].ToString();
                this.skjalm_heiti = r["skjalm_heiti"].ToString();
                this.staerd = (long)Convert.ToDouble(r["staerd"].ToString());
                this.slod = r["slod"].ToString();
                this.innihald = r["innihald"].ToString();
                this.timabil = r["timabil"].ToString();
                this.afharnr = r["afharnr"].ToString();
                this.MD5 = r["MD5"].ToString();
                this.midlun = r["midlun"].ToString();
                this.hver_skradi = r["hver_skradi"].ToString();
                this.adgangstakmarkanir = r["adgangstakmarkanir"].ToString();
                this.frumeintak = Convert.ToInt32(r["frumeintak"].ToString());

            }
        }
        public void merkjaEYtt(string strAuðkenni, int iEytt)
        {
            sækjaTengistreng();
            string strSQL = string.Format("UPDATE dt_vörsluutgafur set eytt='{0}' WHERE vorsluutgafa='{1}'", iEytt, strAuðkenni);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }

        public void midlunEyda(string strAuðkenni)
        {
            sækjaTengistreng();
            string strSQL = string.Format("delete FROM dt_midlun  where vorsluutgafa = '{0}';",  strAuðkenni);
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }
        public void uppFaeraVegnaMidlun()
        {
            sækjaTengistreng();
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);

            command.Parameters.AddWithValue("@vorsluutgafa", this.vorsluutgafa);
            command.Parameters.AddWithValue("@midlun", this.midlun);
            command.Parameters.AddWithValue("@dags_midlad", this.dags_midlad);
            command.Parameters.AddWithValue("@hver_midladi", this.hver_midladi);


            command.CommandText = "UPDATE `dt_vörsluutgafur` SET  `midlun`=@midlun,  `hver_midladi`=@hver_midladi, `dags_midlad`=NOW() WHERE  `vorsluutgafa`=@vorsluutgafa;";

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

        public DataTable  getVorsluUtgafurKlasa(string strAuðkenni)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT id, vorsluutgafa, concat(utgafa_titill, ' ', afharnr) as utgafa_titill , vorslustofnun, varsla_heiti, skjalamyndari, skjalm_heiti, staerd, slod, innihald, timabil, afharnr, MD5, hver_skradi, dags_skrad, adgangstakmarkanir, eytt, dags_eytt, hver_eytti, midlun, dags_midlad, hver_midladi, frumeintak, (SELECT distinct tegund_grunns FROM db_oais_admin.dt_midlun m where m.vorsluutgafa = d.vorsluutgafa) as tegund   FROM  `dt_vörsluutgafur` d where midlun = 1 and vorsluutgafa like 'AVID%' and vorslustofnun in({0});", strAuðkenni);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getVorsluUtgafurLista()
        {
            sækjaTengistreng();
           // string strSQL = string.Format("SELECT distinct d.vorsluutgafa, d.utgafa_titill  FROM `dt_vörsluutgafur` d, dt_midlun m where d.vorsluutgafa = m.vorsluutgafa and d.vorsluutgafa like 'AVID%' order by d.utgafa_titill;");
            string strSQL = string.Format("SELECT distinct d.vorsluutgafa, d.utgafa_titill  FROM `dt_vörsluutgafur` d where d.vorsluutgafa like 'AVID%' order by d.utgafa_titill;");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getVorsluUtgafurLista(string strSkjalam)
        {
            sækjaTengistreng();
           // string strSQL = string.Format("SELECT distinct d.vorsluutgafa, d.utgafa_titill  FROM `dt_vörsluutgafur` d, dt_midlun m where d.vorsluutgafa = m.vorsluutgafa and d.vorsluutgafa like 'AVID%' and skjalamyndari = '{0}' order by d.utgafa_titill;", strSkjalam);
            string strSQL = string.Format("SELECT distinct d.vorsluutgafa, d.utgafa_titill  FROM `dt_vörsluutgafur` d where d.vorsluutgafa like 'AVID%' and skjalamyndari = '{0}' order by d.utgafa_titill;", strSkjalam);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }


        public DataTable getVorsluUtgafurVorslu(string strAuðkenni)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT id, vorsluutgafa, concat(utgafa_titill, ' ', afharnr) as utgafa_titill , vorslustofnun, varsla_heiti, skjalamyndari, skjalm_heiti, staerd, slod, innihald, timabil, afharnr, MD5, hver_skradi, dags_skrad, adgangstakmarkanir, eytt, dags_eytt, hver_eytti, midlun, dags_midlad, hver_midladi, frumeintak, (SELECT distinct tegund_grunns FROM dt_midlun m where m.vorsluutgafa = d.vorsluutgafa) as tegund   FROM `dt_vörsluutgafur` d where midlun = 1 and vorsluutgafa like 'AVID%' and vorslustofnun = '{0}';", strAuðkenni);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
}
