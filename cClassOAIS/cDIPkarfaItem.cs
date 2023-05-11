using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassOAIS
{
    public class cDIPkarfaItem
    {
      
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
        //id, karfa, skjalID, titill, vorsluutgafa, md5, slod
        public int id { get; set; }
        public int karfa { get; set; }
        public string skjalID { get; set; }
        public string titill { get; set; }
        public string vorsluutgafa { get; set; }
        public string md5 { get; set; }
        public string slod { get; set; }

        public void vista()
        {
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //id, karfa, skjalID, titill, vorsluutgafa, md5, slod
            command.Parameters.AddWithValue("@karfa", this.karfa);
            command.Parameters.AddWithValue("@skjalID", this.skjalID);
            command.Parameters.AddWithValue("@titill", this.titill);
            command.Parameters.AddWithValue("@vorsluutgafa", this.vorsluutgafa);
            command.Parameters.AddWithValue("@md5", this.md5);
            command.Parameters.AddWithValue("@slod", this.slod);


            if (this.id == 0)
            {
                command.CommandText = "REPLACE INTO `dt_item_korfu_dip` SET  `karfa`=@karfa,  `skjalID`=@skjalID, `titill`=@titill,`vorsluutgafa`=@vorsluutgafa,`md5`=@md5,`slod`=@slod; ";
            }
            else
            {
                // command.CommandText = string.Format("UPDATE `dt_notendur` SET  `kennitala`=@kennitala,  `notendanafn`=@notendanafn, `lykilorð`=@lykilorð, `vörslustofnun`=@vörslustofnun, `nafn`=@nafn,`virkur`=@virkur,`athugasemdir`=@athugasemdir,`hver_breytti`=@hver_breytti,`hlutverk`=@hlutverk,`email`=@email,`heimilisfang`=@heimilisfang,`simi`=@simi,`dags_breytt`=NOW() WHERE kennitala ={0};", strKennitala);
            }

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
            if (id == 0)
            {
                var id = MySqlHelper.ExecuteScalar(m_strTenging, "SELECT MAX(id) FROM dt_item_korfu_dip");
                if (id != null)
                {
                    this.karfa = Convert.ToInt32(id);
                }
            }

        }

        public DataTable getKorfuItemDIP(string strKarfa)
        {
            string strSQL = string.Format("SELECT * FROM db_oais_admin.dt_item_korfu_dip d where karfa = {0};", strKarfa);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging,strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
}
