using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassVHS
{
    public class cSkyrslur
    {
       

        public class drif
        {
            
            public int id { get; private set; }
            public int comd { get; private set; }
            public string nafn { get; private set; }
            public string laust { get; private set; }
            public string stæða { get; private set; }
            public string heild { get; private set; }
            public string tegund { get; private set; }
            public string framleitt { get; private set; }

        }
        
        public static DataTable sækjaDrif()
        {
            string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";

            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, string.Format("SELECT * FROM db_oais_admin.dt_drives d;"));
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public static DataTable sækjaFiles()
        {
            string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";

            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, string.Format("SELECT f.id, f.nafn, f.oldNafn, f.slod, f.adgerd, d.laust-f.laust as laust, drifID, DATE, villa FROM dt_files f, dt_drives d where f.drifid = d.id group by Date;"));
            //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

    }
}
