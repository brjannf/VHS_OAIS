﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;
using System.Drawing.Imaging;
using MySqlX.XDevAPI.Common;
using System.Xml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System.Configuration;
using K4os.Compression.LZ4.Internal;
using DocumentFormat.OpenXml.InkML;

namespace cClassOAIS
{
    public class cMIdlun
    {
        private string m_strTenging = ConfigurationManager.ConnectionStrings["connection_allt"].ConnectionString; 
        private string m_strTengingOAIS = string.Empty; // "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = db_oais_admin; allow user variables = True; character set = utf8";
        public bool m_bAfrit = false;


        private void sækjaTengistreng()
        {
            if (m_bAfrit)
            {
                m_strTengingOAIS = ConfigurationManager.ConnectionStrings["connection_afrit"].ConnectionString;
            }
            else
            {
                m_strTengingOAIS = ConfigurationManager.ConnectionStrings["connection_admin"].ConnectionString;
            }

        }
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
        public string extension { get; set; }
        public string leitarord { get; set; }
        public string Upphafsdags { get; set; }
        public string Endadags { get; set; }


        public void vista()
        {
            sækjaTengistreng();

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
            command.Parameters.AddWithValue("@extension", this.extension);
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

            command.CommandText = "INSERT INTO `dt_midlun` SET  `vorsluutgafa`=@vorsluutgafa,  `titill_vorsluutgafu`=@titill_vorsluutgafu, heiti_gagangrunns=@heiti_gagangrunns, tegund_grunns=@tegund_grunns, tafla_grunns=@tafla_grunns, vorslustofnun_audkenni=@vorslustofnun_audkenni, vorslustofnun_heiti=@vorslustofnun_heiti, skjalamyndari_audkenni=@skjalamyndari_audkenni, skjalamyndari_heiti=@skjalamyndari_heiti, skjalaskra_timabil=@skjalaskra_timabil,skjalaskra_adgengi=@skjalaskra_adgengi, skjalaskra_afharnr=@skjalaskra_afharnr,skjalaskra_innihald=@skjalaskra_innihald, dalkur_documentid=@dalkur_documentid, documentid=@documentid, dalkur_doctitill=@dalkur_doctitill,doctitill=@doctitill, dalkur_docCreated=@dalkur_docCreated, docCreated=@docCreated, dalkur_docLastWriten=@dalkur_docLastWriten, docLastWriten=@docLastWriten, dalkur_malID=@dalkur_malID,  malID=@malID,  dalkur_malTitill=@dalkur_malTitill,  maltitill=@maltitill, docInnihald=@docInnihald,  extension=@extension,   hver_skradi=@hver_skradi, dags_skrad=NOW();";
            //dalkur_documentid, documentid, dalkur_doctitill, doctitill, dalkur_docCreated, docCreated, dalkur_docLastWriten, docLastWriten, dalkur_malID, malID, dalkur_malTitill, maltitill, docInnihald
            // heiti_gagangrunns=@heiti_gagangrunns, tegund_grunns=@tegund_grunns, tafla_grunns=@tafla_grunns, vorslustofnun_audkenni=@vorslustofnun_audkenni, vorslustofnun_heiti=@vorslustofnun_heiti, skjalamyndari_audkenni=@skjalamyndari_audkenni, skjalamyndari_heiti=@skjalamyndari_heiti, skjalaskra_timabil=@skjalaskra_timabil,skjalaskra_adgengi=@skjalaskra_adgengi, skjalaskra_afharnr=@skjalaskra_afharnr,skjalaskra_innihald=@skjalaskra_innihald, dalkur_documentid=@dalkur_documentid, documentid=@documentid, dalkur_doctitill=@dalkur_doctitill,doctitill=@doctitill, dalkur_docCreated=@dalkur_docCreated, docCreated=@docCreated, dalkur_docLastWriten=@dalkur_docLastWriten, docLastWriten=@docLastWriten, dalkur_malID=@dalkur_malID,  malID=@malID,  dalkur_malTitill=@dalkur_malTitill,  maltitill=@maltitill, docInnihald=@docInnihald,  hver_skradi=@hver_skradi, dags_skrad=NOW();";

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

        public void vistaOneCRM()
        {
            sækjaTengistreng();

            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            // //id, vorsluutgafa, titill_vorsluutgafu, heiti_gagangrunns, tegund_grunns, tafla_grunns, dalkur_grunns, tegund_dalks, gildi_dalks, vorslustofnun_audkenni, vorslustofnun_heiti, skjalamyndari_audkenni, skjalamyndari_heiti, skjalaskra_timabil, skjalaskra_adgengi, skjalaskra_afharnr, skjalaskra_innihald
           
            command.Parameters.AddWithValue("@heiti_gagangrunns", this.heiti_gagangrunns);
            command.Parameters.AddWithValue("@documentid", this.documentid);
            command.Parameters.AddWithValue("@doctitill", this.doctitill);
            command.Parameters.AddWithValue("@docCreated", this.docCreated);
            command.Parameters.AddWithValue("@docLastWriten", this.docLastWriten);
            command.Parameters.AddWithValue("@malID", this.malID);
            command.Parameters.AddWithValue("@maltitill", this.maltitill);
         

            command.CommandText = string.Format("UPDATE `dt_midlun` SET doctitill=@doctitill, docCreated=@docCreated,  docLastWriten=@docLastWriten,  malID=@malID, maltitill=@maltitill  WHERE documentid='{0}' and heiti_gagangrunns='{1}';", this.documentid,this.heiti_gagangrunns);
            //dalkur_documentid, documentid, dalkur_doctitill, doctitill, dalkur_docCreated, docCreated, dalkur_docLastWriten, docLastWriten, dalkur_malID, malID, dalkur_malTitill, maltitill, docInnihald
            // heiti_gagangrunns=@heiti_gagangrunns, tegund_grunns=@tegund_grunns, tafla_grunns=@tafla_grunns, vorslustofnun_audkenni=@vorslustofnun_audkenni, vorslustofnun_heiti=@vorslustofnun_heiti, skjalamyndari_audkenni=@skjalamyndari_audkenni, skjalamyndari_heiti=@skjalamyndari_heiti, skjalaskra_timabil=@skjalaskra_timabil,skjalaskra_adgengi=@skjalaskra_adgengi, skjalaskra_afharnr=@skjalaskra_afharnr,skjalaskra_innihald=@skjalaskra_innihald, dalkur_documentid=@dalkur_documentid, documentid=@documentid, dalkur_doctitill=@dalkur_doctitill,doctitill=@doctitill, dalkur_docCreated=@dalkur_docCreated, docCreated=@docCreated, dalkur_docLastWriten=@dalkur_docLastWriten, docLastWriten=@docLastWriten, dalkur_malID=@dalkur_malID,  malID=@malID,  dalkur_malTitill=@dalkur_malTitill,  maltitill=@maltitill, docInnihald=@docInnihald,  hver_skradi=@hver_skradi, dags_skrad=NOW();";

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

        public void vistaGagnagrunn(string strOrginal)
        {
            sækjaTengistreng();
            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
          //  id, vorsluutgafa, heiti_gagnagrunns, orgina_heiti
            command.Parameters.AddWithValue("@vorsluutgafa", this.vorsluutgafa);
            command.Parameters.AddWithValue("@heiti_gagnagrunns", this.heiti_gagangrunns);
            command.Parameters.AddWithValue("@orgina_heiti", strOrginal);
            command.CommandText = "INSERT INTO `ds_gagnagrunnar` SET  `vorsluutgafa`=@vorsluutgafa,  `heiti_gagnagrunns`=@heiti_gagnagrunns ,  `orginal_heiti`=@orgina_heiti;";

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }

        public void createDatabase(string strNafn)
        {
            sækjaTengistreng();
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
            sækjaTengistreng();
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
        public void insertToTable(string strColumns, DataRow rd, string strDatabase, string strTable, string strTime, string strMetaFunction, string strVörslunumer, string strSlod, bool bOCR, string strHeitiKerfis)
        {
            sækjaTengistreng();
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
              //  return; //taka út þegar ég er búin að setja inn grunninn.
                //keyra hér inn í metadata í dt_midlun
                if (strMetaFunction != string.Empty)
                {
                    strMeta = strMeta.Replace("{", "");
                    strMeta = strMeta.Replace("}", "|");

                    string[] strSplitFunk = strMeta.Split('|');
                    
                    foreach (string str in strSplitFunk)
                    {
                        if (str != string.Empty || str != null)
                        {
                            //********************gera hér undanþágu fyrir gopro**************
                            if(strHeitiKerfis == "GoPro")
                            {
                                if(strTable != "ATTACHMENTS")
                                {
                                    return;
                                }
                            }
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
                                    //************redding þangað til ég fæ skýringu fyrir Ölfus oneCrm

                                    if (iID == 99999992)
                                    {
                                        strSlod = "D:\\AIP\\HARN\\00006\\AVID.HARN.2025001.1\\Documents\\docCollection1\\99999992";

                                    }

                                    string[] strFile = Directory.GetFiles(strSlod);
                                    try
                                    {
                                        //bætti hér við extension
                                        string strSlodExt = strSlod.Replace("AVID", "FRUM");
                                        if(Directory.Exists(strSlodExt))
                                        {
                                            strFile = Directory.GetFiles(strSlodExt);
                                            FileInfo fifo = new FileInfo(strFile[0]);
                                            string strExtension = fifo.Extension;
                                            this.extension = strExtension;
                                        } 
                                        else
                                        {
                                            FileInfo fifo = new FileInfo(strFile[0]);
                                            string strExtension = fifo.Extension;
                                            this.extension = strExtension;
                                        }
                                        strSlod = strSlod.Replace("FRUM", "AVID");
                                        strFile = Directory.GetFiles(strSlod);

                                        if (strFile[0].EndsWith(".tif") && bOCR)
                                        {
                                            //EF skrá er of stór redding 
                                            if (this.heiti_gagangrunns == "AVID_HARN_2025001_1" && iID == 2476)
                                            {
                                                this.docInnihald = "Ekki hægt að OCR lesa";
                                            }
                                            else
                                            {


                                                //  IronOcr.License.LicenseKey = "IRONOCR.HERADSSKJALASAFNARNESINGA.IRO230628.2127.55150-431588DBF0-BQYYUOVYA37ZXLL-2XEVPPBD5UZV-5FPSQUXAGQFB-OVWEAJBHIFDE-M4Y3UJ23L3DV-AFXORJ-LPM5D7MWKTWMUA-IRONOCR.DOTNET.LITE.SUB-UUZG4I.RENEW.SUPPORT.27.JUN.2024";
                                                IronOcr.License.LicenseKey = ConfigurationManager.AppSettings["IronOcr.LicenseKey"];
                                                // ocrLicense();
                                                var Ocr = new IronTesseract();
                                                Ocr.Language = OcrLanguage.Icelandic;
                                                using (var Input = new OcrInput())
                                                {
                                                    // if (!strFile[0].EndsWith("AVID.HKOP.2023024.1\\Documents\\docCollection1\\4\\1.tif")) //vegna náttúrufræðistofu Kópabogs 2023_24
                                                    {
                                                        Input.AddImage(strFile[0]);
                                                        var Result = Ocr.Read(Input);
                                                        this.docInnihald = Result.Text;
                                                        
                                                    }
                                                    //else
                                                    //{
                                                    //    this.docInnihald = "Of langur texti fyrir OCR-lestur";
                                                    //}

                                                }
                                                GC.Collect(); //sjá hvort þetta þolir 
                                            }
                                        }
                                    }
                                    catch (Exception x)
                                    {

                                        //throw;
                                    }
                                  
                                }
                               

                                if (strSplit[0] == "Sagsidentifikation")
                                {
                                    this.malID = strSplit[1];
                                    this.dalkur_malID = strSplit[2];
                                }
                                if (strSplit[0] == "Sagstitel")
                                {
                                    this.maltitill = strSplit[1];
                                    this.dalkur_malTitill= strSplit[2];
                                }

                                if (strSplit[0] == "Dokumenttitel")
                                {
                                    if(strSplit.Length == 2)
                                    {   //eitthvað bogið við titlana eru skrítinn tákn í þeim sem ruglar þetta
                                        this.doctitill = strSplit[0];
                                        this.dalkur_doctitill = strSplit[1];
                                    }
                                    else
                                    {
                                        this.doctitill = strSplit[1];
                                        this.dalkur_doctitill = strSplit[2];
                                    }
                                   
                                }
                                if (strSplit[0] == "Dokumentdato")
                                {
                                    if (strSplit[2] == "date_created")
                                    {
                                        //formatta string í yyyy-mm-dd
                                        this.docCreated = strSplit[1];
                                        this.dalkur_docCreated = strSplit[2];
                                    }
                                    if (strSplit[2] == "lastwriten")
                                    {
                                        //formatta string í yyyy-mm-dd
                                        this.docLastWriten = strSplit[1];
                                        this.dalkur_docLastWriten = strSplit[2];
                                    }
                                    if ((strSplit[2] != "date_created" || strSplit[2] == "lastwriten"))
                                    {
                                        //formatta string í yyyy-mm-dd
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

        //private void ocrLicense()
        //{
        //    IronOcr.License.LicenseKey = "IRONOCR.HERADSSKJALASAFNARNESINGA.IRO230628.2127.55150-431588DBF0-BQYYUOVYA37ZXLL-2XEVPPBD5UZV-5FPSQUXAGQFB-OVWEAJBHIFDE-M4Y3UJ23L3DV-AFXORJ-LPM5D7MWKTWMUA-IRONOCR.DOTNET.LITE.SUB-UUZG4I.RENEW.SUPPORT.27.JUN.2024";
        //}
        public string  ocrCreatePDF(string strTiff, string strPDF)
        {
            //IronOcr.License.LicenseKey = "IRONOCR.HERADSSKJALASAFNARNESINGA.IRO230628.2127.55150-431588DBF0-BQYYUOVYA37ZXLL-2XEVPPBD5UZV-5FPSQUXAGQFB-OVWEAJBHIFDE-M4Y3UJ23L3DV-AFXORJ-LPM5D7MWKTWMUA-IRONOCR.DOTNET.LITE.SUB-UUZG4I.RENEW.SUPPORT.27.JUN.2024";
            IronOcr.License.LicenseKey = ConfigurationManager.AppSettings["IronOcr.LicenseKey"];
            var ocrTesseract = new IronTesseract();
            ocrTesseract.Language = OcrLanguage.Icelandic;
            // var ocrTesseract = new IronTesseract();
            //  ocrTesseract.Configuration.AutoRotateDetectionForRenderSearchablePdf = true;
            ocrTesseract.Configuration.RenderSearchablePdfsAndHocr = true;
            // ocrTesseract.Configuration.RenderHocr = true;
            // ocrTesseract.Configuration.RenderSearchablePdfsAndHoc
            //finna fjölda ramma í tiff
            FrameDimension dimension;
            System.Drawing.Image image = System.Drawing.Image.FromFile(strTiff);
            //System.Drawing.Image image;
            //using (var bmpTemp = new Bitmap(@"C:\temp\4.tif"))
            //{
            //    image = new Bitmap(bmpTemp);
            //}

            dimension = FrameDimension.Page;
            int x = 70;
            int iPages = image.GetFrameCount(dimension);
            //  ocrInput.LoadImageFrame("C:\\temp\\9.tif", 1);
            int[] arr = Enumerable.Range(0, iPages - 1 + 1).ToArray();
            var pageindices = Enumerable.Range(0, iPages - 1 + 1).ToArray();
            if(iPages == 1)
            {
               pageindices =  new int[] {0};
            }
            using OcrInput input = new OcrInput();
            strTiff = strTiff.Replace("\\\\", "\\");
            if(iPages == 1)
            {
                input.LoadImageFrame(strTiff, 0);
            }
            else
            {
                input.LoadImageFrames(strTiff, pageindices);
            }
            
          
          //  input.LoadImageFrames(@"D:\AVID.HARN.2023067.1\ContextDocumentation\docCollection1\3\1.tif", pageindices);


            var ocrResult = ocrTesseract.Read(input);
            FileInfo fifo = new FileInfo(strPDF);
            strPDF = fifo.FullName.Replace(fifo.Extension, ".pdf"); // strPDF.Replace(".tif", ".pdf");
            ocrResult.SaveAsSearchablePdf(strPDF);
            return strPDF;
        }
        public DataTable testFyrirSpurn(string strFyrirspurn, string strDatabase)
        {
            string strTengi = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = "+ strDatabase + "; allow user variables = True; character set = utf8";
            DataSet ds = MySqlHelper.ExecuteDataset(strTengi, strFyrirspurn);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
        public string vistaFyrirSpurn(string strFyrirspurn, string strDatabase, string strNafn, string strLysing, string strID)
        {
            sækjaTengistreng();
            string strREt = "0";
            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
                MySqlCommand command = new MySqlCommand("", conn);
            //id, nafn, fyrirspurn, lysing, gagangrunnur
            command.Parameters.AddWithValue("@nafn", strNafn);
            command.Parameters.AddWithValue("@fyrirspurn", strFyrirspurn);
            command.Parameters.AddWithValue("@lysing", strLysing);
            command.Parameters.AddWithValue("@gagnagrunnur", strDatabase);

            if(strID == "0" || strID == string.Empty)
            {
                command.CommandText = "INSERT INTO `dt_fyrirspurnir` SET  `nafn`=@nafn,`fyrirspurn`=@fyrirspurn,`lysing`=@lysing,`gagnagrunnur`=@gagnagrunnur";
                var id = MySqlHelper.ExecuteScalar(m_strTengingOAIS, "SELECT max(id) FROM dt_fyrirspurnir d ;");
                if (id != DBNull.Value)
                {
                    strREt = id.ToString();
                }

            }
            else
            {
                command.CommandText = "UPDATE`dt_fyrirspurnir` SET  `nafn`=@nafn,`fyrirspurn`=@fyrirspurn,`lysing`=@lysing,`gagnagrunnur`=@gagnagrunnur WHERE id =" + strID + ";" ;
            }

           

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
            return strREt;
        }

        public int leitCount(string strLeitarord)
        {
            sækjaTengistreng();
            string strSQL = string.Empty;

            if (strLeitarord != string.Empty)
            {
                strSQL = string.Format("Select count(*) FROM dt_midlun m WHERE MATCH (doctitill, maltitill, docInnihald, vorslustofnun_heiti,skjalamyndari_heiti,skjalaskra_innihald)AGAINST ('{0}' IN BOOLEAN MODE) ", strLeitarord);
            }
            else
            {
                strSQL = "SELECT count(*) FROM dt_midlun d ";
            }




            if (this.vorslustofnun_audkenni != null)
            {
                if (strLeitarord.Length == 0)
                {
                    strSQL += " WHERE vorslustofnun_audkenni = '" + this.vorslustofnun_audkenni + "' ";
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
            if (this.vorsluutgafa != null)
            {
                if (!strSQL.Contains("WHERE"))  //if (strLeitarord.Length == 0 && this.vorslustofnun_audkenni == null)
                {
                    strSQL += " WHERE vorsluutgafa = '" + this.vorsluutgafa + "' ";
                }
                else
                {
                    strSQL += " AND vorsluutgafa = '" + this.vorsluutgafa + "' ";
                }

            }



            if (this.Upphafsdags != null || this.Endadags != null)
            {
                if (this.Upphafsdags == null && this.Endadags != null)
                {
                    DateTime dtEnd = Convert.ToDateTime(this.Endadags);
                    string strEnd = dtEnd.Year.ToString() + "-" + dtEnd.Month.ToString() + "-" + dtEnd.Day.ToString();

                    if (!strSQL.Contains("WHERE"))
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
                    if (!strSQL.Contains("WHERE")) // (strLeitarord.Length == 0 && this.skjalamyndari_audkenni == null && this.vorslustofnun_audkenni == null)
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

                    if (!strSQL.Contains("WHERE"))
                    {
                        strSQL += " WHERE DATE(docLastWriten) >= '" + strStart + "' AND DATE(docLastWriten) <= '" + strEnd + "' ";
                    }
                    else
                    {
                        strSQL += " AND DATE(docLastWriten) >= '" + strStart + "' AND DATE(docLastWriten) <= '" + strEnd + "' ";
                    }
                }

            }
            if (this.extension != null)
            {
                if (!strSQL.Contains("WHERE"))
                {
                    strSQL += " WHERE extension = '" + this.extension + "' ";
                }
                else
                {
                    strSQL += " AND extension = '" + this.extension + "' ";
                }

            }
            //if (strLeitarord != string.Empty)
            //{
            //    strSQL += "order by score desc;";
            //}
            int iRet = 0;
            var  count = MySqlHelper.ExecuteScalar(m_strTengingOAIS, strSQL);
            if(count != null)
            {
                iRet = Convert.ToInt32(count);  
            }
            ;
            return iRet;
        }
        public DataTable leit(string strLeitarord, string strCountPage, string strPage)
        {
            sækjaTengistreng();
            string strSQL = string.Empty;
            if (strLeitarord != string.Empty)
            {
                strSQL = string.Format("Select MATCH (doctitill, maltitill, docInnihald, vorslustofnun_heiti,skjalamyndari_heiti,skjalaskra_innihald)AGAINST ('{0}' IN BOOLEAN MODE) as score, id, vorsluutgafa, titill_vorsluutgafu, heiti_gagangrunns, tegund_grunns, tafla_grunns, dalkur_documentid, documentid, dalkur_doctitill, concat(doctitill,extension) as doctitill, dalkur_docCreated, docCreated, dalkur_docLastWriten, docLastWriten, dalkur_malID, malID, dalkur_malTitill, maltitill, docInnihald, extension, vorslustofnun_audkenni, vorslustofnun_heiti, skjalamyndari_audkenni, skjalamyndari_heiti, skjalaskra_timabil, skjalaskra_adgengi, skjalaskra_afharnr, skjalaskra_innihald, hver_skradi, dags_skrad  FROM dt_midlun m WHERE MATCH (doctitill, maltitill, docInnihald, vorslustofnun_heiti,skjalamyndari_heiti,skjalaskra_innihald)AGAINST ('{0}' IN BOOLEAN MODE) ", strLeitarord);
            }
           else
            {
                strSQL = "SELECT id, vorsluutgafa, titill_vorsluutgafu, heiti_gagangrunns, tegund_grunns, tafla_grunns, dalkur_documentid, documentid, dalkur_doctitill, concat(doctitill ,extension) as doctitill, dalkur_docCreated, docCreated, dalkur_docLastWriten, docLastWriten, dalkur_malID, malID, dalkur_malTitill, maltitill, docInnihald, extension, vorslustofnun_audkenni, vorslustofnun_heiti, skjalamyndari_audkenni, skjalamyndari_heiti, skjalaskra_timabil, skjalaskra_adgengi, skjalaskra_afharnr, skjalaskra_innihald, hver_skradi, dags_skrad FROM dt_midlun d ";
            }

           

            if (this.vorslustofnun_audkenni != null)
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
            if (this.vorsluutgafa != null)
            {
                if(!strSQL.Contains("WHERE"))  //if (strLeitarord.Length == 0 && this.vorslustofnun_audkenni == null)
                {
                    strSQL += " WHERE vorsluutgafa = '" + this.vorsluutgafa + "' ";
                }
                else
                {
                    strSQL += " AND vorsluutgafa = '" + this.vorsluutgafa + "' ";
                }

            }

          

            if (this.Upphafsdags != null || this.Endadags != null) 
            {
                if(this.Upphafsdags == null && this.Endadags !=null)
                {
                    DateTime dtEnd = Convert.ToDateTime(this.Endadags);
                    string strEnd = dtEnd.Year.ToString() + "-" + dtEnd.Month.ToString() + "-" + dtEnd.Day.ToString();

                    if (!strSQL.Contains("WHERE"))
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
                    if (!strSQL.Contains("WHERE")) // (strLeitarord.Length == 0 && this.skjalamyndari_audkenni == null && this.vorslustofnun_audkenni == null)
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

                    if (!strSQL.Contains("WHERE"))
                    {
                        strSQL += " WHERE DATE(docLastWriten) >= '" + strStart + "' AND DATE(docLastWriten) <= '" + strEnd + "' ";
                    }
                    else
                    {
                        strSQL += " AND DATE(docLastWriten) >= '" + strStart + "' AND DATE(docLastWriten) <= '" + strEnd + "' ";
                    }
                }
               
            }
            if (this.extension != null)
            {
                if (!strSQL.Contains("WHERE"))
                {
                    strSQL += " WHERE extension = '" + this.extension + "' ";
                }
                else
                {
                    strSQL += " AND extension = '" + this.extension + "' ";
                }

            }
            if (strLeitarord!= string.Empty) 
            {
                strSQL += "order by score desc";
            }
            strSQL += string.Format(" limit {0}, {1};", strPage, strCountPage);
          
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS,strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public string leitInnra(string strLeitarord, string strGagnagrunnur) 
        {
            sækjaTengistreng();
            string strRet = string.Empty;
            string strSQL = string.Empty;
            if (strLeitarord.Length != 0)
            {
                strSQL = string.Format("Select group_concat(documentid) as ids FROM dt_midlun m WHERE MATCH (doctitill,docLastWriten,maltitill, docInnihald) AGAINST ('{0}' IN BOOLEAN MODE) and heiti_gagangrunns = '{1}' ", strLeitarord, strGagnagrunnur);
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
            if(this.extension != null)
            {
                strSQL += " AND extension = '" + this.extension + "'";
            }
            var strIDS = MySqlHelper.ExecuteScalar(m_strTengingOAIS,strSQL);
            if(strIDS != null)
            {
                strRet = strIDS.ToString();
            }
            return strRet;
        }

        public DataTable leitInnraDataTable(string strLeitarord, string strGagnagrunnur)
        {
            sækjaTengistreng();
            string strRet = string.Empty;
            string strSQL = string.Empty;
            if (strLeitarord.Length != 0)
            {
                strSQL = string.Format("Select distinct documentid, doctitill, malID,  maltitill  FROM dt_midlun m WHERE MATCH (doctitill,docLastWriten,maltitill, docInnihald)AGAINST ('{0}' IN BOOLEAN MODE) and heiti_gagangrunns = '{1}' order by malID;", strLeitarord, strGagnagrunnur);
            }
            else
            {
                strSQL = string.Format("SELECT distinct documentid , d.* FROM dt_midlun d WHERE  heiti_gagangrunns = '{0}' ", strGagnagrunnur);
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
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }


        /// <summary>
        /// orðmyndir
        /// </summary>
        /// <param name="strDatabase"></param>
        /// <param name="strTegund"></param>
        /// <returns></returns>
        public string ordmyndir(string ord)
        {
            sækjaTengistreng();
            string strRet = string.Empty;
            string strSQL = string.Empty;
            //strSQL = string.Format("SELECT group_concat(beygingarmynd SEPARATOR ' ') as ordmynd FROM ordmyndir.`bin` b where uppflettiord = '{0}'; ", ord);
            strSQL = string.Format("select (SELECT group_concat(beygingarmynd SEPARATOR ' ') as ordmynd FROM ordmyndir.`bin`  where id = b.id) as ordmyndir FROM ordmyndir.`bin` b where beygingarmynd = binary '{0}'; ", ord);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS,strSQL);
            foreach(DataRow r in ds.Tables[0].Rows)
            {
                strRet += r["ordmyndir"].ToString() + " ";
            }
            //var ordmyndir = MySqlHelper.ExecuteScalar(m_strTengingOAIS, strSQL);
            //if(ordmyndir != null) 
            //{
            //    strRet = ordmyndir.ToString();
            //}
            return strRet;
        }
        // private string str
        public string getFyrirspurn(string strDatabase, string strTegund)
        {
            sækjaTengistreng();
            string strRet = string.Empty;
            string strQL = string.Empty;   
          //  if(strTegund == "Málakerfi")
            {

                strQL = string.Format("SELECT fyrirspurn FROM dt_fyrirspurnir d where gagnagrunnur = '{0}' and nafn = '{1}';", strDatabase, strTegund);
            }
            //if(strTegund == "Skráarkerfi")
            //{
            //    strQL = string.Format("SELECT fyrirspurn FROM db_oais_admin.dt_fyrirspurnir d where gagnagrunnur = '{0}' and nafn = 'Get_files_path';", strDatabase);
            //}
           
            var fyrirspurn = MySqlHelper.ExecuteScalar(m_strTengingOAIS, strQL);
            if(fyrirspurn != null)
            {
                strRet = fyrirspurn.ToString();
            }
            return strRet;
        }

        public DataTable getFyrirspurnTemplate(string strKerfi)
        {
            sækjaTengistreng();
            string strRet = string.Empty;
            string strQL = string.Empty;
           strQL = string.Format("SELECT * FROM dt_fyrirspurnir_templet d where kerfi = '{0}';", strKerfi);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS, strQL);
            DataTable dt = ds.Tables[0];
            return dt; 
        }

        public DataTable keyraFyrirspurn(string strSQL, string database)
        {
            sækjaTengistreng();
            string strTengistrengur = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = " + database + "; allow user variables = True; character set = utf8";

            DataSet ds = MySqlHelper.ExecuteDataset(strTengistrengur, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getGagnagrunnaFyrirSpurnir(string strGagnagrunnur)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM dt_fyrirspurnir d where gagnagrunnur = '{0}' order by nr;", strGagnagrunnur);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getMidlunarToflu()
        {
            sækjaTengistreng();
           string strSQL = string.Format("SELECT id, vorsluutgafa, documentid, vorslustofnun_audkenni, skjalamyndari_audkenni FROM dt_midlun d;");
         //   string strSQL = "SELECT * FROM dt_midlun where extension is null;";
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public void uppfæraExtension(string strExtension, string strID)
        {
            sækjaTengistreng();
            string strSQL = string.Format("UPDATE dt_midlun set extension = '{0}' where id = '{1}';", strExtension, strID);
            MySqlHelper.ExecuteNonQuery(m_strTengingOAIS, strSQL);
                 
        }

        public DataTable getGagnagrunnaFyrirSpurnirMidlun(string strGagnagrunnur)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT id, nafn as name, fyrirspurn as queryOriginal, lysing as description, gagnagrunnur as _database FROM db_oais_admin.dt_fyrirspurnir d where gagnagrunnur = '{0}';", strGagnagrunnur);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getGagnagrunna()
        {
            sækjaTengistreng();
            string strSQL = "SELECT * FROM ds_gagnagrunnar d;";
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getExtensions(string strVarsla, string strSkjalm, string strUtgafa)
        {
            sækjaTengistreng();
            string strSQL = string.Empty;
            if(strVarsla == string.Empty && strSkjalm == string.Empty && strUtgafa == string.Empty)
            {
                strSQL = "SELECt distinct extension FROM dt_midlun d  order by extension;";
            }
            if (strVarsla != string.Empty)
            {
                strSQL = string.Format("SELECt distinct extension FROM dt_midlun d  where vorslustofnun_audkenni ='{0}' order by extension ;", strVarsla);
            }
            if(strSkjalm != string.Empty)
            {
                strSQL = string.Format("SELECt distinct extension FROM dt_midlun d  where skjalamyndari_audkenni ='{0}' order by extension ;", strSkjalm);
            }
            if (strUtgafa != string.Empty)
            {
                strSQL = string.Format("SELECt distinct extension FROM dt_midlun d  where vorsluutgafa ='{0}' order by extension ;", strUtgafa);
            }


            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public void eydaFyrirspurnum(string strGagnagrunnur)
        {
            sækjaTengistreng();
            string strSQL = string.Empty;
            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
            MySqlCommand command = new MySqlCommand(strSQL, conn);

            
            command.CommandText = string.Format ("delete FROM dt_fyrirspurnir  where gagnagrunnur = '{0}';", strGagnagrunnur);
            command.ExecuteNonQuery();

            conn.Dispose();
            command.Dispose();
           
        }

        public void eydaMetaOnatadONECRM(string stringVorsluutgafa)
        {
            sækjaTengistreng();
            string strSQL = string.Empty;
            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
            MySqlCommand command = new MySqlCommand(strSQL, conn);


            command.CommandText = string.Format("delete FROM db_oais_admin.dt_midlun d where vorsluutgafa = '{0}'and tafla_grunns != 'tblDocuments'", stringVorsluutgafa);
            command.ExecuteNonQuery();

            conn.Dispose();
            command.Dispose();

        }

        public void dropDatabase(string strGagnagrunnur)
        {
            sækjaTengistreng();
            try
            {
                string strSQL = string.Empty;
                MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
                conn.Open();
                MySqlCommand command = new MySqlCommand(strSQL, conn);


                command.CommandText = string.Format("drop database {0};", strGagnagrunnur);
                command.ExecuteNonQuery();

                conn.Dispose();
                command.Dispose();
            }
            catch (Exception x)
            {

            }

        }

        public void insertFyrirspurn(string strSQL, string strGagnagrunnur)
        {
            string strTengistrengur = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = " + strGagnagrunnur + "; allow user variables = True; character set = utf8";

            MySqlCommand upgCommand = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(strTengistrengur);
            conn.Open();
            upgCommand.Connection = conn;
            upgCommand.CommandText = strSQL;
            upgCommand.ExecuteNonQuery();
          
        }
    
        public void bulkLoad(string strFile)
        {
            string connStr = "server = localhost; user id = root; Password = ivarBjarkLind;";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlBulkLoader bl = new MySqlBulkLoader(conn);
            bl.Local = true;
          //  bl.TableName = "Career";
            bl.FieldTerminator = "\t";
            bl.LineTerminator = "\n";
            bl.FileName = strFile;
            bl.Load();// bl.NumberOfLinesToSkip = 3;
        }
        public void scriptLoad(string strFile) 
        {
            string connStr = "server = localhost; user id = root; Password = ivarBjarkLind; database = db_oais_admin_afrit;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlScript skript = new MySqlScript(conn, File.ReadAllText(strFile));
            skript.Execute();
           

        }

        public void insertAfritFromFile(string strFile)
        { 
            string constring = "server = localhost; user id = root; Password = ivarBjarkLind;";
            MySqlCommand upgCommand = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
            upgCommand.Connection = conn;
            upgCommand.CommandText = File.ReadAllText(strFile);
            upgCommand.ExecuteNonQuery();
        }

        public DataTable getDagSetningAll()
        {
            sækjaTengistreng();
            string strSQL = "SELECT id, doccreated, doclastwriten FROM db_oais_admin.dt_midlun d;;";
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getMidlunRestONECRM(string strUtgafa)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM db_oais_admin.dt_midlun d where vorsluutgafa ='AVID.HARN.2023067.1' and documentid is not  null order by documentid;", strUtgafa);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable málaTitillGOPRO_redding(string strUtgafa)
        {
            sækjaTengistreng();
            string strSQL = string.Format("SELECT * FROM db_oais_admin.dt_midlun d where vorsluutgafa ='AVID.HARN.2023067.1' and documentid is not  null order by documentid;", strUtgafa);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTengingOAIS, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getAttachmentFraDocID(string strID, string strGagnagrunnur)
        {
          //  sækjaTengistreng();
            string strTengistrengur = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = " + strGagnagrunnur + "; allow user variables = True; character set = utf8";
            string strSQL = string.Format("SELECT *  FROM attachments a where documentid = {0};", strID);
            DataSet ds = MySqlHelper.ExecuteDataset(strTengistrengur, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getDaatesFromCases(string strID, string strGagnagrunnur)
        {
            string strTengistrengur = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = " + strGagnagrunnur + "; allow user variables = True; character set = utf8";
            string strSQL = string.Format("SELECT LastModifiedDate, CreationDate FROM cases c where sagid = {0};", strID);
            DataSet ds = MySqlHelper.ExecuteDataset(strTengistrengur, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getDaatesFromDocuments(string strID, string strGagnagrunnur)
        {
            string strTengistrengur = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = " + strGagnagrunnur + "; allow user variables = True; character set = utf8"; sækjaTengistreng();
            string strSQL = string.Format("SELECT CreationDate,MotificationDate From documents d where documentid = {0};", strID);
            DataSet ds = MySqlHelper.ExecuteDataset(strTengistrengur, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getDatesFromEmail(string strID, string strGagnagrunnur)
        {
            string strTengistrengur = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = " + strGagnagrunnur + "; allow user variables = True; character set = utf8";
            string strSQL = string.Format("SELECT CreationDate,MotificationDate From email d where documentid = {0};", strID);
            DataSet ds = MySqlHelper.ExecuteDataset(strTengistrengur, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getDatesFromMemol(string strID, string strGagnagrunnur)
        {
            string strTengistrengur = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = " + strGagnagrunnur + "; allow user variables = True; character set = utf8";
            string strSQL = string.Format("SELECT CreationDate, ModificationDate FROM memo m where documentid = {0}; ", strID);
            DataSet ds = MySqlHelper.ExecuteDataset(strTengistrengur, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getTitillMalsGOPRO(string strID, string strGagnagrunnur)
        {
            string strTengistrengur = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = " + strGagnagrunnur + "; allow user variables = True; character set = utf8";
            string strSQL = string.Format("SELECT concat(Casenumber, ' ', c.subject) as maltitill, c.sagid FROM attachments a, cases c where a.sagid=c.sagid and documentid = {0};", strID);
            DataSet ds = MySqlHelper.ExecuteDataset(strTengistrengur, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
         
        }
        /// <summary>
        /// eftir á redding málID kom ekki rétt inn
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="strGagnagrunnur"></param>
        /// <returns></returns>
        public DataTable getmalIDfromDocument( string strGagnagrunnur)
        {
            string strTengistrengur = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = " + strGagnagrunnur + "; allow user variables = True; character set = utf8";
            string strSQL = string.Format("SELECT a.documentID, a.sagid FROM avid_harn_2023067_1.attachments a, cases c where a.sagid = c.sagid;");
            DataSet ds = MySqlHelper.ExecuteDataset(strTengistrengur, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;

        }

        public void uppFæraMálHeitiGOPRO(string strID, string strTexti,string strSagID, string strGagnaGrunnur)
        {
            sækjaTengistreng();
            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //  id, vorsluutgafa, heiti_gagnagrunns, orgina_heiti
            command.Parameters.AddWithValue("@strTexti", strTexti);

            command.CommandText = string.Format("update  db_oais_admin.dt_midlun set maltitill = @strTexti, malID= '{3}' where documentid = '{1}' and heiti_gagangrunns = '{2}';", strTexti,strID, strGagnaGrunnur, strSagID);

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
        public void uppFæraDateGOPRO(string strID, string strCreated, string strModifiet, string strGagnaGrunnur)
        {
            sækjaTengistreng();
            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //  id, vorsluutgafa, heiti_gagnagrunns, orgina_heiti
            command.Parameters.AddWithValue("@created", strCreated);
            command.Parameters.AddWithValue("@modified", strModifiet);

            command.CommandText = string.Format("update  db_oais_admin.dt_midlun set docCreated =  '{2}' , docLastWriten=  '{3}' where documentid = '{0}' and heiti_gagangrunns = '{1}';", strID, strGagnaGrunnur, strCreated, strModifiet);

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
        public void uppFæraDateGALLT(string strID, string strCreated, string strModifiet)
        {
            sækjaTengistreng();
            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //  id, vorsluutgafa, heiti_gagnagrunns, orgina_heiti
            command.Parameters.AddWithValue("@created", strCreated);
            command.Parameters.AddWithValue("@modified", strModifiet);

            command.CommandText = string.Format("update  db_oais_admin.dt_midlun set docCreated =  '{0}' , docLastWriten=  '{1}' where id = '{2}' ;",  strCreated, strModifiet, strID);

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
        /// <summary>
        /// uppfæra malID hugsanlega vantar í import af gopro
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="strCreated"></param>
        /// <param name="strModifiet"></param>
        public void uppFæraMalIDutrfaDocid(string strDocID, string strMalID, string strGrunnur)
        {
            sækjaTengistreng();
            MySqlConnection conn = new MySqlConnection(m_strTengingOAIS);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
 

            command.CommandText = string.Format("update  db_oais_admin.dt_midlun set malID =  '{0}'  where documentid = '{1}' and heiti_gagangrunns = '{2}' ;", strMalID, strDocID, strGrunnur);

            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();
        }
    }
}
