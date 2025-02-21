using DocumentFormat.OpenXml.Office.PowerPoint.Y2021.M06.Main;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassOAIS
{
    public class cKortlagningar_excel
    {
        //alvöru
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = kortlagning_excel; allow user variables = True; character set = utf8";
       //test
      //  private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = kortlagning_test; allow user variables = True; character set = utf8";

        public int id { get; set; }
        public string Heradsskjalasafn { get; set; }
        public string Audkenni { get; set; }
        public string Sveitarfelag { get; set; }
        public string Afhendingarskyldur_adili { get; set; }
        public string Heiti_kerfis { get; set; }
        public string Heiti_kerfis_ext { get; set; }
        public string Rafraen_sofn { get; set; }
        public string Hlutverk_kerfis { get; set; }
        public string Byrgi_og_umsjon { get; set; }
        public string Skrifstofa_Deild_Starfseining { get; set; }
        public string Tengilidur_skrifstofudeildar_starfseiningar { get; set; }
        public string thjonustuaili_Birgi { get; set; }
        public string Hysingaradili { get; set; }
        public string Tekid_notkun_dags { get; set; }
        public string Tilkynnt_dags { get; set; }
        public string Vardveisla_kerfis { get; set; }
        public string staerd { get; set; }
        public string Notkun_stada { get; set; }
        public string Athugasemdir { get; set; }
        public string Afhendingaar { get; set; }
        public string Noteringar { get; set; }
        //Tilkynnt_dags, Vardveisla_kerfis, staerd, Notkun_stada, Athugasemdir, Afhendingaar, Noteringar
        public DataTable getKortHera(string strHeri)
        {
           // string strSQL = string.Format("SELECT * FROM kortlagning_excel.kortlagning2 k where heradsskjalasafn = '{0}';  ", strHeri);
            string strSQL = string.Format("SELECT * FROM kortlagning2 k where heradsskjalasafn = '{0}';  ", strHeri);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getKortHera()
        {
            // string strSQL = string.Format("SELECT * FROM kortlagning_excel.kortlagning2 k where heradsskjalasafn = '{0}';  ", strHeri);
            string strSQL = string.Format("SELECT * FROM kortlagning2 k;  ");
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public void hreinsaHlut()
        {
            this.id = 0;
            this.Heradsskjalasafn = string.Empty;
            this.Audkenni = string.Empty;
            this.Sveitarfelag = string.Empty;
            this.Afhendingarskyldur_adili = string.Empty;
            this.Heiti_kerfis = string.Empty;
            this.Heiti_kerfis_ext = string.Empty;
            this.Rafraen_sofn = string.Empty;
            this.Hlutverk_kerfis = string.Empty; 
            this.Byrgi_og_umsjon = string.Empty;
            this.Skrifstofa_Deild_Starfseining = string.Empty;
            this.Tengilidur_skrifstofudeildar_starfseiningar = string.Empty;
            this.thjonustuaili_Birgi = string.Empty;
            this.Hysingaradili = string.Empty;
            this.Tekid_notkun_dags = string.Empty;
            this.Tilkynnt_dags = string.Empty;
            this.Vardveisla_kerfis = string.Empty;
            this.staerd = string.Empty; 
            this.Notkun_stada = string.Empty;
            this.Athugasemdir = string.Empty;
            this.Afhendingaar = string.Empty;
            this.Noteringar = string.Empty;
        }

    
        public void eyda(int iID)
        {

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);

            command.CommandText = string.Format("DELETE from `kortlagning2` where id = '{0}'", iID);

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
        public void vista()
        {
           
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //karfa, heiti, lanthegi, hver_skradi, dags_skrad
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@Heradsskjalasafn", this.Heradsskjalasafn);
            command.Parameters.AddWithValue("@Audkenni", this.Audkenni);
            command.Parameters.AddWithValue("@Sveitarfelag", this.Sveitarfelag);
            command.Parameters.AddWithValue("@Afhendingarskyldur_adili", this.Afhendingarskyldur_adili);
            command.Parameters.AddWithValue("@Heiti_kerfis", this.Heiti_kerfis);
            command.Parameters.AddWithValue("@Heiti_kerfis_ext", this.Heiti_kerfis_ext);
            command.Parameters.AddWithValue("@Rafraen_sofn", this.Rafraen_sofn);
            command.Parameters.AddWithValue("@Hlutverk_kerfis", this.Hlutverk_kerfis);
            command.Parameters.AddWithValue("@Byrgi_og_umsjon", this.Byrgi_og_umsjon);
            command.Parameters.AddWithValue("@Skrifstofa_Deild_Starfseining", this.Skrifstofa_Deild_Starfseining);
            command.Parameters.AddWithValue("@Tengilidur_skrifstofudeildar_starfseiningar", this.Tengilidur_skrifstofudeildar_starfseiningar);
            command.Parameters.AddWithValue("@thjonustuaili_Birgi", this.thjonustuaili_Birgi);
            command.Parameters.AddWithValue("@Hysingaradili", this.Hysingaradili);
            command.Parameters.AddWithValue("@Tekid_notkun_dags", this.Tekid_notkun_dags);
            command.Parameters.AddWithValue("@Tilkynnt_dags", this.Tilkynnt_dags);
            command.Parameters.AddWithValue("@Vardveisla_kerfis", this.Vardveisla_kerfis);
            command.Parameters.AddWithValue("@staerd", this.staerd);
            command.Parameters.AddWithValue("@Notkun_stada", this.Notkun_stada);
            command.Parameters.AddWithValue("@Athugasemdir", this.Athugasemdir);
            command.Parameters.AddWithValue("@Afhendingaar", this.Afhendingaar);
            command.Parameters.AddWithValue("@Noteringar", this.Noteringar);
          
            if (this.id == 0)
            {
                command.CommandText = "REPLACE INTO `kortlagning2` SET  `Heradsskjalasafn`=@Heradsskjalasafn,`Audkenni`=@Audkenni,  `Sveitarfelag`=@Sveitarfelag, `Afhendingarskyldur_adili`=@Afhendingarskyldur_adili, `Heiti_kerfis`=@Heiti_kerfis,`Heiti_kerfis_ext`=@Heiti_kerfis_ext,`Rafraen_sofn`=@Rafraen_sofn,`Hlutverk_kerfis`=@Hlutverk_kerfis,`Byrgi_og_umsjon`=@Byrgi_og_umsjon,`Skrifstofa_Deild_Starfseining`=@Skrifstofa_Deild_Starfseining,`Tengilidur_skrifstofudeildar_starfseiningar`=@Tengilidur_skrifstofudeildar_starfseiningar,`thjonustuaili_Birgi`=@thjonustuaili_Birgi,`Hysingaradili`=@Hysingaradili,`Tekid_notkun_dags`=@Tekid_notkun_dags,`Tilkynnt_dags`=@Tilkynnt_dags,`Vardveisla_kerfis`=@Vardveisla_kerfis,`staerd`=@staerd,`Notkun_stada`=@Notkun_stada,`Athugasemdir`=@Athugasemdir,`Afhendingaar`=@Afhendingaar;";
               // command.CommandText = "REPLACE INTO kortlagning_excel.`kortlagning_test` SET  `Heradsskjalasafn`=@Heradsskjalasafn,  `Sveitarfelag`=@Sveitarfelag, `Afhendingarskyldur_adili`=@Afhendingarskyldur_adili, `Heiti_kerfis`=@Heiti_kerfis,`Heiti_kerfis_ext`=@Heiti_kerfis_ext,`Rafraen_sofn`=@Rafraen_sofn,`Hlutverk_kerfis`=@Hlutverk_kerfis,`Byrgi_og_umsjon`=@Byrgi_og_umsjon,`Skrifstofa_Deild_Starfseining`=@Skrifstofa_Deild_Starfseining,`Tengilidur_skrifstofudeildar_starfseiningar`=@Tengilidur_skrifstofudeildar_starfseiningar,`thjonustuaili_Birgi`=@thjonustuaili_Birgi,`Hysingaradili`=@Hysingaradili,`Tekid_notkun_dags`=@Tekid_notkun_dags,`Tilkynnt_dags`=@Tilkynnt_dags,`Vardveisla_kerfis`=@Vardveisla_kerfis,`staerd`=@staerd,`Notkun_stada`=@Notkun_stada,`Athugasemdir`=@Athugasemdir,`Afhendingaar`=@Afhendingaar;";
                // Heiti_kerfis, Heiti_kerfis_ext, Rafraen_sofn, Hlutverk_kerfis, Byrgi_og_umsjon, Skrifstofa_Deild_Starfseining, Tengilidur_skrifstofudeildar_starfseiningar, thjonustuaili_Birgi, Hysingaradili, Tekid_notkun_dags, Tilkynnt_dags, Vardveisla_kerfis, staerd, Notkun_stada, Athugasemdir, Afhendingaar, Noteringar
            }
            else
            {
                command.CommandText = string.Format("UPDATE `kortlagning2` SET  `Heradsskjalasafn`=@Heradsskjalasafn, `Audkenni`=@Audkenni,   `Sveitarfelag`=@Sveitarfelag, `Afhendingarskyldur_adili`=@Afhendingarskyldur_adili, `Heiti_kerfis`=@Heiti_kerfis,`Heiti_kerfis_ext`=@Heiti_kerfis_ext,`Rafraen_sofn`=@Rafraen_sofn,`Hlutverk_kerfis`=@Hlutverk_kerfis,`Byrgi_og_umsjon`=@Byrgi_og_umsjon,`Skrifstofa_Deild_Starfseining`=@Skrifstofa_Deild_Starfseining,`Tengilidur_skrifstofudeildar_starfseiningar`=@Tengilidur_skrifstofudeildar_starfseiningar,`thjonustuaili_Birgi`=@thjonustuaili_Birgi,`Hysingaradili`=@Hysingaradili,`Tekid_notkun_dags`=@Tekid_notkun_dags,`Tilkynnt_dags`=@Tilkynnt_dags,`Vardveisla_kerfis`=@Vardveisla_kerfis,`staerd`=@staerd,`Notkun_stada`=@Notkun_stada,`Athugasemdir`=@Athugasemdir,`Afhendingaar`=@Afhendingaar WHERE id={0};", this.id);
            }

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
    }
}
