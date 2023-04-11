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
       

        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";

        #region GET/SET
       // id, vorsluutgafa, utgafa_titill, vorslustofnun, varsla_heiti, skjalamyndari, skjalm_heiti, staerd, slod, hver_skradi, dags_skrad
        public int ID { get; set; }
        public string vorsluutgafa { get; set; }
        public string utgafa_titill { get; set; }
        public string vorslustofnun { get; set; }
        public string varsla_heiti { get; set; }
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


        #endregion

        public void vista()
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);

            // id, vorsluutgafa, utgafa_titill, vorslustofnun, varsla_heiti, skjalamyndari, skjalm_heiti, staerd, slod, hver_skradi, dags_skrad

            command.Parameters.AddWithValue("@id", this.ID);
            command.Parameters.AddWithValue("@vorsluutgafa", this.vorsluutgafa);
            command.Parameters.AddWithValue("@utgafa_titill", this.utgafa_titill);
            command.Parameters.AddWithValue("@vorslustofnun", this.vorslustofnun);
            command.Parameters.AddWithValue("@varsla_heiti", this.varsla_heiti);
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
            // command.Parameters.AddWithValue("@dags_skrad", this.dags_skrad);

            command.CommandText = "INSERT INTO `dt_vörsluutgafur` SET  `vorsluutgafa`=@vorsluutgafa,`utgafa_titill`=@utgafa_titill,`vorslustofnun`=@vorslustofnun, `varsla_heiti`=@varsla_heiti, `skjalamyndari`=@skjalamyndari,`skjalm_heiti`=@skjalm_heiti, `staerd`=@staerd, `slod`=@slod, `innihald`=@innihald, `timabil`=@timabil, `afharnr`=@afharnr, `MD5`=@MD5, `hver_skradi`=@hver_skradi,`adgangstakmarkanir`=@adgangstakmarkanir, `dags_skrad`=NOW()";

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();

        }

       
    }
}
