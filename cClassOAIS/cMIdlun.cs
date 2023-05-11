using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;
using MySqlX.XDevAPI.Common;
using System.Xml;
using DocumentFormat.OpenXml.Packaging;

namespace cClassOAIS
{
    public class cMIdlun
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind;";
        private string m_strTengingOAIS = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";

      

        public int id { get; set; }
        public string vorsluutgafa { get; set; }
        public string titill_vorsluutgafu { get; set; }
        public string heiti_gagangrunns { get; set; }
        public string tegund_grunns { get; set; }
        public string tafla_grunns { get; set; }
        public string dalkur_grunns { get; set; }
        public string tegund_dalks { get; set; }
        public string gildi_dalks { get; set; }
        public string vorslustofnun_audkenni { get; set; }
        public string vorslustofnun_heiti { get; set; }
        public string skjalamyndari_audkenni { get; set; }
        public string skjalamyndari_heiti { get; set; }
        public string skjalaskra_timabil { get; set; }
        public string skjalaskra_adgengi { get; set; }
        public string skjalaskra_afharnr { get; set; }
        public string skjalaskra_innihald { get; set; }
        public string hver_skradi { get; set; }
        public string dags_skrad { get; set; }
        public string dalkur_documentid { get; set; }
        public string documentid { get; set; }
        public string dalkur_doctitill { get; set; }
        public string doctitill { get; set; }
        public string dalkur_docCreated { get; set; }
        public string docCreated { get; set; }
        public string dalkur_docLastWriten { get; set; }
        public string docLastWriten { get; set; }
        public string dalkur_malID { get; set; }
        public string malID { get; set; }
        public string dalkur_malTitill { get; set; }
        public string maltitill { get; set; }
        public string docInnihald { get; set; }
        public string leitarord { get; set; }
        public string Upphafsdags { get; set; }
        public string Endadags { get; set; }


        public void vista()
        {

            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            // //id, vorsluutgafa, titill_vorsluutgafu, heiti_gagangrunns, tegund_grunns, tafla_grunns, dalkur_grunns, tegund_dalks, gildi_dalks, vorslustofnun_audkenni, vorslustofnun_heiti, skjalamyndari_audkenni, skjalamyndari_heiti, skjalaskra_timabil, skjalaskra_adgengi, skjalaskra_afharnr, skjalaskra_innihald
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@vorsluutgafa", this.vorsluutgafa);
            command.Parameters.AddWithValue("@titill_vorsluutgafu", this.titill_vorsluutgafu);
            command.Parameters.AddWithValue("@heiti_gagangrunns", this.heiti_gagangrunns);
            command.Parameters.AddWithValue("@tegund_grunns", this.tegund_grunns);
            command.Parameters.AddWithValue("@tafla_grunns", this.tafla_grunns);
            //command.Parameters.AddWithValue("@dalkur_grunns", this.dalkur_grunns);
            //command.Parameters.AddWithValue("@tegund_dalks", this.tegund_dalks);
            command.Parameters.AddWithValue("@gildi_dalks", this.gildi_dalks);
            command.Parameters.AddWithValue("@vorslustofnun_audkenni", this.vorslustofnun_audkenni);
            command.Parameters.AddWithValue("@vorslustofnun_heiti", this.vorslustofnun_heiti);
            command.Parameters.AddWithValue("@skjalamyndari_audkenni", this.skjalamyndari_audkenni);
            command.Parameters.AddWithValue("@skjalamyndari_heiti", this.skjalamyndari_heiti);
            command.Parameters.AddWithValue("@skjalaskra_timabil", this.skjalaskra_timabil);
            command.Parameters.AddWithValue("@skjalaskra_adgengi", this.skjalaskra_adgengi);
            command.Parameters.AddWithValue("@skjalaskra_afharnr", this.skjalaskra_afharnr);
            command.Parameters.AddWithValue("@skjalaskra_innihald", this.skjalaskra_innihald);
            command.Parameters.AddWithValue("@hver_skradi", this.hver_skradi);
            command.Parameters.AddWithValue("@dags_skrad", this.dags_skrad);
            command.Parameters.AddWithValue("@dalkur_documentid", this.dalkur_documentid);
            command.Parameters.AddWithValue("@documentid", this.documentid);
            command.Parameters.AddWithValue("@dalkur_doctitill", this.dalkur_doctitill);
            command.Parameters.AddWithValue("@doctitill", this.doctitill);
            command.Parameters.AddWithValue("@dalkur_docCreated", this.dalkur_docCreated);
            command.Parameters.AddWithValue("@docCreated", this.docCreated);
            command.Parameters.AddWithValue("@dalkur_docLastWriten", this.dalkur_docLastWriten);
            command.Parameters.AddWithValue("@docLastWriten", this.docLastWriten);
            command.Parameters.AddWithValue("@dalkur_malID", this.dalkur_malID);
            command.Parameters.AddWithValue("@malID", this.malID);
            command.Parameters.AddWithValue("@dalkur_malTitill", this.dalkur_malTitill);
            command.Parameters.AddWithValue("@maltitill", this.maltitill);
            command.Parameters.AddWithValue("@docInnihald", this.docInnihald);

            //dalkur_documentid, documentid, dalkur_doctitill, doctitill, dalkur_docCreated, docCreated, dalkur_docLastWriten, docLastWriten, dalkur_malID, malID, dalkur_malTitill, maltitill, docInnihald
            command.CommandText = "INSERT INTO `dt_midlun` SET  `vorsluutgafa`=@vorsluutgafa,  `titill_vorsluutgafu`=@titill_vorsluutgafu, heiti_gagangrunns=@heiti_gagangrunns, tegund_grunns=@tegund_grunns, tafla_grunns=@tafla_grunns, vorslustofnun_audkenni=@vorslustofnun_audkenni, vorslustofnun_heiti=@vorslustofnun_heiti, skjalamyndari_audkenni=@skjalamyndari_audkenni, skjalamyndari_heiti=@skjalamyndari_heiti, skjalaskra_timabil=@skjalaskra_timabil,skjalaskra_adgengi=@skjalaskra_adgengi, skjalaskra_afharnr=@skjalaskra_afharnr,skjalaskra_innihald=@skjalaskra_innihald, dalkur_documentid=@dalkur_documentid, documentid=@documentid, dalkur_doctitill=@dalkur_doctitill,doctitill=@doctitill, dalkur_docCreated=@dalkur_docCreated, docCreated=@docCreated, dalkur_docLastWriten=@dalkur_docLastWriten, docLastWriten=@docLastWriten, dalkur_malID=@dalkur_malID,  malID=@malID,  dalkur_malTitill=@dalkur_malTitill,  maltitill=@maltitill, docInnihald=@docInnihald,  hver_skradi=@hver_skradi, dags_skrad=NOW();";

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

        public void createDatabase(string strNafn)
        {
            
            string strSQL = "DROP DATABASE IF EXISTS " + strNafn + ";" + Environment.NewLine;
            strSQL += "CREATE DATABASE " + strNafn + ";";
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }
        public void createTable(string strSQL)
        {
            MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
        }
        public int instertYfirlit(string strVörsluNr, string strTitill)
        {
            int ret = 0;
            string strSQL = string.Empty;
            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
            MySqlCommand command = new MySqlCommand(strSQL, conn);

            command.Parameters.AddWithValue("@vörslunumer", strVörsluNr);
            command.Parameters.AddWithValue("@titill", strTitill);

            command.CommandText = "INSERT INTO `dt_midlun` SET `vörslunumer`=@vörslunumer, `titill`=@titill";
            command.ExecuteNonQuery();
            command.CommandText = "select max(id) from `yfirlit`";
            object o = command.ExecuteScalar();
            if (o != null)
            {
                ret = Convert.ToInt32(o);

            }
            return ret;
        }
        public void insertToTable(string strColumns, DataRow rd, string strDatabase, string strTable, string strTime, string strMetaFunction, string strVörslunumer, string strSlod)
        {

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();


            //   string strSQL = "INSERT INTO " + strDatabase + "." + strTable + " (" + strColumns.Remove(strColumns.Length - 1, 1) + ") VALUES (";
            this.heiti_gagangrunns = strDatabase;
            string strSQL = "INSERT INTO " + strDatabase + "." + strTable + " SET ";
            MySqlCommand command = new MySqlCommand(strSQL, conn);
            string[] strSplit = strColumns.Remove(strColumns.Length - 1, 1).Split(',');

            string strMeta = strMetaFunction;

            //  foreach (DataRow rd in dt.Rows)
            {
                int i = 0;
                string strValues = string.Empty;
                foreach (string str in strSplit)
                {

                    if (str != string.Empty)
                    {
                        if (strTime.ToString().ToLower().Contains(str.ToLower()))
                        {
                            if (rd[i] != DBNull.Value)
                            {
                                //// rd[i] =  TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(rd[i]), TimeZoneInfo.Local);
                                //DateTime strTimi = Convert.ToDateTime(rd[i]);
                                //rd[i] = DateTime.ParseExact(strTimi.ToString(), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
                                rd[i] = rd[i].ToString().Replace("Z", "");
                            }

                        }

                        if (strMetaFunction.Contains(str))
                        {
                            //finna hvaða funkgerð og para við gögn

                            string strGögn = rd[i].ToString();
                            strMeta = strMeta.Replace("~" + str, "~" + strGögn + "~" + str);

                        }
                        // string strGildi = rd[c.ColumnName].ToString();
                        if (rd[i].ToString() == "true")
                        {
                            rd[i] = "1";
                        }
                        if (rd[i].ToString() == "false")
                        {
                            rd[i] = "0";
                        }

                        command.Parameters.AddWithValue("@" + strSplit[i], rd[i]);
                        if (i == 0)
                        {
                            strValues += strSplit[i] + "= @" + strSplit[i];
                        }
                        else
                        {
                            strValues += ", " + strSplit[i] + "= @" + strSplit[i];
                        }

                        i++;
                    }

                }

                strSQL += strValues;

                command.CommandText = strSQL + ";";
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();

                //keyra hér inn í metadata í dt_midlun
                if (strMetaFunction != string.Empty)
                {
                    strMeta = strMeta.Replace("{", "");
                    strMeta = strMeta.Replace("}", "|");

                    string[] strSplitFunk = strMeta.Split('|');
                    
                    foreach (string str in strSplitFunk)
                    {
                        if (str != string.Empty)
                        {
                            // try
                            {
                                strSplit = str.Split('~');
                                if (strSplit[0] == "Dokumentidentifikation")
                                {
                                    this.documentid = strSplit[1];
                                    this.dalkur_documentid = strSplit[2];
                                    int iID = Convert.ToInt32(strSplit[1]);
                                    double dColl = iID / 10000;
                                    if (iID == 10000)
                                    {
                                        dColl = 0;
                                    }
                                    dColl = dColl + 1;
                               
                                    strSlod = strSlod + "\\Documents\\docCollection" + dColl.ToString() + "\\" + iID;
                                    
                                    string[] strFile = Directory.GetFiles(strSlod);
                                    var Ocr = new IronTesseract();
                                    Ocr.Language = OcrLanguage.Icelandic;
                                    using (var Input = new OcrInput())
                                    {
                                        Input.AddImage(strFile[0]);
                                        var Result = Ocr.Read(Input);
                                        this.docInnihald = Result.Text;
                                       
                                    }

                                }
                                if (strSplit[0] == "Dokumenttitel")
                                {
                                    this.doctitill = strSplit[1];
                                    this.dalkur_doctitill= strSplit[2];
                                }
                                if (strSplit[0] == "Dokumentdato")
                                {
                                    if (strSplit[2] == "date_created")
                                    {
                                        this.docCreated = strSplit[1];
                                        this.dalkur_docCreated = strSplit[2];
                                    }
                                    if (strSplit[2] == "lastwriten")
                                    {
                                        this.docLastWriten = strSplit[1];
                                        this.dalkur_docLastWriten = strSplit[2];
                                    }
                                }
                                //eftir að gera málID og MálTitill
                              

                            }
                            //catch { }
                        }
                    }
                    this.vista(); 
                    conn.Dispose();
                    command.Dispose();

                }
            }
        }

        public DataTable testFyrirSpurn(string strFyrirspurn, string strDatabase)
        {
            string strTengi = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = "+ strDatabase + "; allow user variables = True; character set = utf8";
            DataSet ds = MySqlHelper.ExecuteDataset(strTengi, strFyrirspurn);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
        public void vistaFyrirSpurn(string strFyrirspurn, string strDatabase, string strNafn, string strLysing)
        {
            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
                MySqlCommand command = new MySqlCommand("", conn);
            //id, nafn, fyrirspurn, lysing, gagangrunnur
            command.Parameters.AddWithValue("@nafn", strNafn);
            command.Parameters.AddWithValue("@fyrirspurn", strFyrirspurn);
            command.Parameters.AddWithValue("@lysing", strLysing);
            command.Parameters.AddWithValue("@gagangrunnur", strDatabase);

            command.CommandText = "INSERT INTO `dt_fyrirspurnir` SET  `nafn`=@nafn,`fyrirspurn`=@fyrirspurn,`lysing`=@lysing,`gagangrunnur`=@gagangrunnur";

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

        public DataTable leit(string strLeitarord)
        {
            string strSQL = string.Empty;
           if(strLeitarord.Length != 0)
            {
                strSQL = string.Format("Select MATCH (titill_vorsluutgafu, doctitill,docLastWriten,maltitill, docInnihald, vorslustofnun_heiti,skjalamyndari_heiti,skjalaskra_innihald)AGAINST ('{0}' IN BOOLEAN MODE) as score, m.*  FROM dt_midlun m WHERE MATCH (titill_vorsluutgafu, doctitill,docLastWriten,maltitill, docInnihald, vorslustofnun_heiti,skjalamyndari_heiti,skjalaskra_innihald)AGAINST ('{0}' IN BOOLEAN MODE) ", strLeitarord);
            }
           else
            {
                strSQL = "SELECT * FROM dt_midlun d ";
            }
           

            if(this.vorslustofnun_audkenni != null)
            {
                if (strLeitarord.Length == 0)
                {
                    strSQL += " WHERE vorslustofnun_audkenni = '" + this.vorslustofnun_audkenni +"' "; 
                }
                else
                {
                    strSQL += " AND vorslustofnun_audkenni = '" + this.vorslustofnun_audkenni + "' ";
                }
                   
            }

            if (this.skjalamyndari_audkenni != null)
            {
                if (strLeitarord.Length == 0 && this.vorslustofnun_audkenni == null)
                {
                    strSQL += " WHERE skjalamyndari_audkenni = '" + this.skjalamyndari_audkenni + "' ";
                }
                else
                {
                    strSQL += " AND skjalamyndari_audkenni = '" + this.skjalamyndari_audkenni + "' ";
                }

            }
            if(this.Upphafsdags != null || this.Endadags != null) 
            {
                if(this.Upphafsdags == null && this.Endadags !=null)
                {
                    DateTime dtEnd = Convert.ToDateTime(this.Endadags);
                    string strEnd = dtEnd.Year.ToString() + "-" + dtEnd.Month.ToString() + "-" + dtEnd.Day.ToString();

                    if (strLeitarord.Length == 0 && this.skjalamyndari_audkenni == null && this.vorslustofnun_audkenni == null)
                    {
                        strSQL += " WHERE DATE(docLastWriten) <= '" + strEnd + "' ";
                    }
                    else
                    {
                        strSQL += " AND DATE(docLastWriten) <= '" + strEnd + "' ";
                    }
                }
                if (this.Upphafsdags != null && this.Endadags == null)
                {
                    DateTime dtStart = Convert.ToDateTime(this.Upphafsdags);
                    string strStart = dtStart.Year.ToString() + "-" + dtStart.Month.ToString() + "-" + dtStart.Day.ToString();
                    if (strLeitarord.Length == 0 && this.skjalamyndari_audkenni == null && this.vorslustofnun_audkenni == null)
                    {
                        strSQL += " WHERE DATE(docLastWriten) >= '" + strStart + "' ";
                    }
                    else
                    {
                        strSQL += " AND DATE(docLastWriten) >= '" + strStart + "' ";
                    }
                }
                if (this.Upphafsdags != null && this.Endadags != null)
                {
                    DateTime dtEnd = Convert.ToDateTime(this.Endadags);
                    string strEnd = dtEnd.Year.ToString() + "-" + dtEnd.Month.ToString() + "-" + dtEnd.Day.ToString();

                    DateTime dtStart = Convert.ToDateTime(this.Upphafsdags);
                    string strStart = dtStart.Year.ToString() + "-" + dtStart.Month.ToString() + "-" + dtStart.Day.ToString();

                    if (strLeitarord.Length == 0 && this.skjalamyndari_audkenni == null && this.vorslustofnun_audkenni == null)
                    {
                        strSQL += " WHERE DATE(docLastWriten) >= '" + strStart + "' AND DATE(docLastWriten) <= '" + strEnd + "' ";
                    }
                    else
                    {
                        strSQL += " AND DATE(docLastWriten) >= '" + strStart + "' AND DATE(docLastWriten) <= '" + strEnd + "' ";
                    }
                }
            }

            if (strLeitarord!= string.Empty) 
            {
                strSQL += "order by score desc;";
            }
          
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS,strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public string leitInnra(string strLeitarord, string strGagnagrunnur) 
        {
            string strRet = string.Empty;
            string strSQL = string.Empty;
            if (strLeitarord.Length != 0)
            {
                strSQL = string.Format("Select group_concat(documentid) as ids FROM dt_midlun m WHERE MATCH (doctitill,docLastWriten,maltitill, docInnihald)AGAINST ('{0}' IN BOOLEAN MODE) and heiti_gagangrunns = '{1}';", strLeitarord, strGagnagrunnur);
            }
            else
            {
                strSQL = string.Format("SELECT group_concat(documentid) as ids FROM dt_midlun d WHERE  heiti_gagangrunns = '{0}' ", strGagnagrunnur);
            }
            if (this.Upphafsdags != null || this.Endadags != null)
            {
                if (this.Upphafsdags == null && this.Endadags != null)
                {
                    DateTime dtEnd = Convert.ToDateTime(this.Endadags);
                    string strEnd = dtEnd.Year.ToString() + "-" + dtEnd.Month.ToString() + "-" + dtEnd.Day.ToString();

                     strSQL += " AND DATE(docLastWriten) <= '" + strEnd + "' ";
                   
                }
                if (this.Upphafsdags != null && this.Endadags == null)
                {
                    DateTime dtStart = Convert.ToDateTime(this.Upphafsdags);
                    string strStart = dtStart.Year.ToString() + "-" + dtStart.Month.ToString() + "-" + dtStart.Day.ToString();
                    strSQL += " AND DATE(docLastWriten) >= '" + strStart + "' ";
                 
                }
                if (this.Upphafsdags != null && this.Endadags != null)
                {
                    DateTime dtEnd = Convert.ToDateTime(this.Endadags);
                    string strEnd = dtEnd.Year.ToString() + "-" + dtEnd.Month.ToString() + "-" + dtEnd.Day.ToString();

                    DateTime dtStart = Convert.ToDateTime(this.Upphafsdags);
                    string strStart = dtStart.Year.ToString() + "-" + dtStart.Month.ToString() + "-" + dtStart.Day.ToString();
                    
                    strSQL += " AND DATE(docLastWriten) >= '" + strStart + "' AND DATE(docLastWriten) <= '" + strEnd + "' ";
                   
                }
            }
            var strIDS = MySqlHelper.ExecuteScalar(m_strTengingOAIS,strSQL);
            if(strIDS != null)
            {
                strRet = strIDS.ToString();
            }
            return strRet;
        }
       // private string str
        public string getFyrirspurn(string strDatabase)
        {
            string strRet = string.Empty;
            string strQL = "SELECT fyrirspurn FROM db_oais_admin.dt_fyrirspurnir d where gagangrunnur = 'AVID_HMOS_2023001_1' and nafn = 'Get_files_path';"; //harðkóða fyrst vantar smá pælingu
            var fyrirspurn = MySqlHelper.ExecuteScalar(m_strTengingOAIS, strQL);
            if(fyrirspurn != DBNull.Value)
            {
                strRet = fyrirspurn.ToString();
            }
            return strRet;
        }

        public DataTable keyraFyrirspurn(string strSQL, string database)
        {
            string strTengistrengur = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = " + database + "; allow user variables = True; character set = utf8";

            DataSet ds = MySqlHelper.ExecuteDataset(strTengistrengur, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

    }
}
