using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using cClassOAIS;

namespace MHR_LEIT
{
    public partial class uscPantanir : UserControl
    {
        public cNotandi virkurNotandi = new cNotandi();
        public DataTable m_dtDIPSkra = new DataTable();
        public DataTable m_dtDIPGrunn = new DataTable();
        public DataTable m_dtDIPMal = new DataTable();
        cLanthegar lanþegi = new cLanthegar();
        DataSet m_dsDIPmal = new DataSet();

        string m_strSlodDIP = string.Empty;


        cDIPKarfa karfa = new cDIPKarfa();
        public uscPantanir()
        {
            InitializeComponent();

        }
        public uscPantanir(cNotandi not, DataTable dtSkra, DataTable dtMal, DataTable dtGrunn, DataSet dsMal)
        {
            InitializeComponent();

            virkurNotandi = not;
            karfa.m_bAfrit = virkurNotandi.m_bAfrit;
            lanþegi.m_bAfrit = virkurNotandi.m_bAfrit;
            m_dtDIPSkra = dtSkra;
            m_dtDIPMal = dtMal;
            m_dtDIPGrunn = dtGrunn;
            m_dsDIPmal = dsMal;
            fyllaDIPLista();
            fyllaLanthega();
            fyllaPantanir();

        }

        private void setjaFoldaTaba()
        {
            m_tapPontunSkra.Text = string.Format("Skráakerfi ({0})", m_dtDIPSkra.Rows.Count);
            m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtDIPGrunn.Rows.Count);

            if (m_dsDIPmal.Tables.Count != 0)
            {
                DataTable dtMalAllt = new DataTable();

                for (int i = 0; i < m_dsDIPmal.Tables.Count; i++)
                {
                    if (i == 0)
                        dtMalAllt = m_dsDIPmal.Tables[i].Copy();
                    else
                        dtMalAllt.Merge(m_dsDIPmal.Tables[i]);
                }
                m_tapPontunMalakerfi.Text = string.Format("Málakerfi ({0})", dtMalAllt.Rows.Count);
            }
            else
            {
                m_tapPontunMalakerfi.Text = string.Format("Málakerfi (0)");
            }
        }
        private void fyllaPantanir()
        {

            m_dgvDIPList.AutoGenerateColumns = false;
            m_dgvDIPList.DataSource = m_dtDIPSkra;
            if (m_dsDIPmal.Tables.Count != 0)
            {

                m_dgvDIPmal.AutoGenerateColumns = false;
                DataTable dtMalAllt = new DataTable();

                for (int i = 0; i < m_dsDIPmal.Tables.Count; i++)
                {
                    if (i == 0)
                        dtMalAllt = m_dsDIPmal.Tables[i].Copy();
                    else
                        dtMalAllt.Merge(m_dsDIPmal.Tables[i]);
                }
                m_dgvDIPmal.DataSource = dtMalAllt;
            }
            else
            {

                m_dgvDIPmal.AutoGenerateColumns = false;
                m_dgvDIPmal.DataSource = m_dtDIPMal;// m_dsDIPmal.Tables[0];

            }


            m_dgvDIPGagnagrunnar.AutoGenerateColumns = false;
            m_dgvDIPGagnagrunnar.DataSource = m_dtDIPGrunn;
            setjaFoldaTaba();
        }

        private void fyllaLanthega()
        {
            cLanthegar lanthegi = new cLanthegar();
            lanthegi.m_bAfrit = virkurNotandi.m_bAfrit;
            DataTable dt = lanthegi.getLanthegaLista();
            DataRow r = dt.NewRow();
            r["nafn"] = "Veldu lánþega";
            dt.Rows.InsertAt(r, 0);
            m_comLanthegar.ValueMember = "id";
            m_comLanthegar.DisplayMember = "nafn";
            m_comLanthegar.DataSource = dt;
        }

        private void m_btnKlaraPontun_Click(object sender, EventArgs e)
        {
            //klára gagnagrunnsskraning sidar harðkóða líklega smá

            if (m_comLanthegar.SelectedIndex == 0)
            {
                MessageBox.Show("Vinsamlegast veldu lánþega eða búðu til nýjan");
                return;
            }

            string strExcell = string.Empty;
            string strExcellGagna = string.Empty;
            string strExcelMal = string.Empty;

            DataTable dtExcell = m_dtDIPSkra.Clone();
            DataTable dtExcellGrunnur = m_dtDIPGrunn.Clone();
            DataTable dtExcellMal = new DataTable();
            dtExcellMal.Columns.Add("Mál");

            dtExcellMal.Columns.Add("maltitill");
            dtExcellMal.Columns.Add("Skrá");
            dtExcellMal.Columns.Add("MD5");
            dtExcellMal.Columns.Add("Slóð");


            //Skráarkerfi
            DataTable dtMalAllt = new DataTable();

            for (int ix = 0; ix < m_dsDIPmal.Tables.Count; ix++)
            {
                if (ix == 0)
                    dtMalAllt = m_dsDIPmal.Tables[ix].Copy();
                else
                    dtMalAllt.Merge(m_dsDIPmal.Tables[ix]);
            }
            m_pgbPontun.Maximum = m_dtDIPGrunn.Rows.Count + dtMalAllt.Rows.Count + m_dtDIPSkra.Rows.Count;
            m_pgbPontun.Step = 1;
            m_pgbPontun.Value = 0;

            m_pgbPontun.Visible = true;
            m_lblPontunstatus.Text = string.Format("0/{0}", m_pgbPontun.Maximum);
            m_lblPontunstatus.Visible = true;
            m_tacPontun.SelectedTab = m_tapPontunSkra;
            Application.DoEvents();
            foreach (DataRow r in m_dtDIPSkra.Rows)
            {
                //skrái körfu strax, geri það máski síðar síðar
                if (karfa.karfa == 0)
                {
                    karfa.heiti = m_comLanthegar.Text + " " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                    karfa.lanthegi = m_comLanthegar.SelectedValue.ToString();
                    karfa.hver_skradi = virkurNotandi.nafn;
                    karfa.athugasemdir = m_tboPontunAth.Text;
                    karfa.vista();
                }
                cDIPkarfaItem karfa_item = new cDIPkarfaItem();
                karfa_item.m_bAfrit = virkurNotandi.m_bAfrit;

                string strVorsluutgafa = r["vorsluutgafa"].ToString();
                string strID = r["skjalID"].ToString();
                string strTitill = r["titill"].ToString();

                //finna vörsluútgáfurót
                cVorsluutgafur utgafur = new cVorsluutgafur();
                utgafur.m_bAfrit = virkurNotandi.m_bAfrit;
                utgafur.getVörsluútgáfu(strVorsluutgafa);
                string strSlod = utgafur.slod;
                //er til frumeintak
                bool bFrum = false;
                if (Directory.Exists(strSlod.Replace("AVID", "FRUM")))
                {
                    bFrum = true;
                }
                //finna skrána og flytja

                int iID = Convert.ToInt32(strID);
                double dColl = iID / 10000;
                if (iID == 10000)
                {
                    dColl = 0;
                }
                dColl = dColl + 1;

                strSlod = strSlod + "\\Documents\\docCollection" + dColl.ToString() + "\\" + iID;
                string[] strSkjal = Directory.GetFiles(strSlod);
                if (strSkjal.Length > 0)
                {
                    DriveInfo divo = new DriveInfo(strSlod);

                    //  string strDIProot = divo.Name + "\\DIP";
                    //Hafa dipið ekki í rótinni heldur við hliðinna á AIP-inu
                    cClassVHS.cVHS_drives drive = new cClassVHS.cVHS_drives();
                    drive.m_bAfrit = virkurNotandi.m_bAfrit;
                    string strAIP = drive.driveVirkkComputers();
                    string[] strSplitus = strAIP.Split("\\");
                    strSplitus[strSplitus.Length - 1] = "DIP";
                    string strDIProot = string.Empty; // strAIP.Replace("AIP", "DIP");
                    foreach (string str in strSplitus)
                    {
                        strDIProot += str + "\\";
                    }

                    if (!Directory.Exists(strDIProot))
                    {
                        Directory.CreateDirectory(strDIProot);
                    }
                    string strDIPfolder = strDIProot + "\\" + karfa.karfa + "_" + m_comLanthegar.Text; //ná í þetta síðar með cLanthega
                    if (!Directory.Exists(strDIPfolder))
                    {
                        Directory.CreateDirectory(strDIPfolder);
                    }
                    strExcell = strDIPfolder;
                    m_strSlodDIP = strDIPfolder;
                    strDIPfolder = strDIPfolder + "\\" + utgafur.utgafa_titill; // + " " + utgafur.afharnr;
                    if (!Directory.Exists(strDIPfolder))
                    {
                        Directory.CreateDirectory(strDIPfolder);
                    }
                    strDIPfolder = strDIPfolder + "\\AFRIT- TIFF";
                    if (!Directory.Exists(strDIPfolder))
                    {
                        Directory.CreateDirectory(strDIPfolder);
                    }
                    FileInfo fifo = new FileInfo(strSkjal[0]);
                    string[] strSplit = strTitill.Split(".");

                    string strEndaSkjal = strDIPfolder + "\\" + strSplit[0] + fifo.Extension;
                    File.Copy(strSkjal[0], strEndaSkjal, true);
                    cMD5 md5 = new cMD5();
                    md5.m_bAfrit = virkurNotandi.m_bAfrit;
                    strSplit = strSlod.Split("\\");
                    strID = "\\" + strSplit[strSplit.Length - 1];
                    string strMD5 = md5.getMD5(strID, utgafur.vorsluutgafa);
                    r["slod"] = strEndaSkjal.Replace(strDIProot, "");
                    r["md5"] = strMD5;

                    dtExcell.ImportRow(r);

                    fifo = new FileInfo(strEndaSkjal);
                    karfa_item.karfa = karfa.karfa;
                    karfa_item.skjalID = r["skjalID"].ToString();
                    karfa_item.titill = fifo.Name; // r["titill"].ToString();
                    karfa_item.heitiVorslu = r["heitiVorslu"].ToString();
                    karfa_item.vorsluutgafa = r["vorsluutgafa"].ToString();
                    karfa_item.md5 = strMD5;
                    karfa_item.slod = strEndaSkjal;
                    karfa_item.vista();




                }
                if (bFrum)
                {
                    strSkjal = Directory.GetFiles(strSlod.Replace("AVID", "FRUM"));
                    if (strSkjal.Length > 0)
                    {
                        DriveInfo divo = new DriveInfo(strSlod);

                        string strDIProot = divo.Name + "\\DIP";
                        if (!Directory.Exists(strDIProot))
                        {
                            Directory.CreateDirectory(strDIProot);
                        }
                        string strDIPfolder = strDIProot + "\\" + karfa.karfa + "_" + m_comLanthegar.Text;  //ná í þetta síðar með cLanthega

                        {
                            Directory.CreateDirectory(strDIPfolder);
                        }
                        strDIPfolder = strDIPfolder + "\\" + utgafur.utgafa_titill; // + " " + utgafur.afharnr;
                        if (!Directory.Exists(strDIPfolder))
                        {
                            Directory.CreateDirectory(strDIPfolder);
                        }
                        strDIPfolder = strDIPfolder + "\\Frumgögn";
                        if (!Directory.Exists(strDIPfolder))
                        {
                            Directory.CreateDirectory(strDIPfolder);
                        }

                        string strEndaSkjal = strDIPfolder + "\\" + strTitill;
                        File.Copy(strSkjal[0], strEndaSkjal, true);
                        cMD5 md5 = new cMD5();
                        md5.m_bAfrit = virkurNotandi.m_bAfrit;

                        string[] strSplit = strSlod.Split("\\");
                        strID = "\\" + strSplit[strSplit.Length - 1];
                        string strMD5 = md5.getMD5(strID, utgafur.vorsluutgafa);
                        DataRow rFrum = dtExcell.NewRow();

                        rFrum["skjalID"] = r["skjalID"].ToString();
                        rFrum["titill"] = r["titill"].ToString();
                        rFrum["vorsluutgafa"] = r["vorsluutgafa"].ToString();
                        rFrum["slod"] = strEndaSkjal.Replace(strDIProot, ""); // strSkjal[0];
                        rFrum["md5"] = strMD5;
                        dtExcell.Rows.Add(rFrum);

                        karfa_item.karfa = karfa.karfa;
                        karfa_item.skjalID = r["skjalID"].ToString();
                        karfa_item.titill = r["titill"].ToString();
                        karfa_item.vorsluutgafa = r["vorsluutgafa"].ToString();
                        karfa_item.md5 = strMD5;
                        karfa_item.slod = strEndaSkjal;
                        karfa_item.vista();
                    }

                }

                m_pgbPontun.PerformStep();
                m_lblPontunstatus.Text = string.Format("{0}/{1}", m_pgbPontun.Value, m_pgbPontun.Maximum);
                m_pgbPontun.Visible = true;
                m_lblPontunstatus.Visible = true;

                Application.DoEvents();
            }

            m_tacPontun.SelectedTab = m_tapPontunMalakerfi;
            //Málakerfi
            foreach (DataTable dt in m_dsDIPmal.Tables)
            {

                if (karfa.karfa == 0)
                {
                    karfa.heiti = m_comLanthegar.Text + " " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                    karfa.lanthegi = m_comLanthegar.SelectedValue.ToString();
                    karfa.hver_skradi = virkurNotandi.nafn;
                    karfa.athugasemdir = m_tboPontunAth.Text;
                    karfa.vista();
                }

                //skrái körfu strax, geri það máski síðar síðar
                int iMal = 1;
                string strSagsID = string.Empty;
                int iSkjal = 0;
                foreach (DataRow r in dt.Rows)
                {
                    if (strSagsID != r["malid"].ToString())
                    {
                        if (strSagsID != string.Empty)
                        {
                            iMal++;
                        }

                        strSagsID = r["malid"].ToString();
                    }
                    string strVorsluutgafa = r["gagnagrunnur"].ToString().Replace("_", ".");

                    cVorsluutgafur utgafur = new cVorsluutgafur();
                    utgafur.m_bAfrit = virkurNotandi.m_bAfrit;
                    utgafur.m_bAfrit = virkurNotandi.m_bAfrit;
                    utgafur.getVörsluútgáfu(strVorsluutgafa);
                    string strSlod = utgafur.slod;

                    //DriveInfo divo = new DriveInfo(strSlod);
                    //string strDIProot = divo.Name + "\\DIP";

                    //Hafa dipið ekki í rótinni heldur við hliðinna á AIP-inu
                    cClassVHS.cVHS_drives drive = new cClassVHS.cVHS_drives();
                    drive.m_bAfrit = virkurNotandi.m_bAfrit;
                    string strAIP = drive.driveVirkkComputers();
                    string[] strSplitus = strAIP.Split("\\");
                    strSplitus[strSplitus.Length - 1] = "DIP";
                    string strDIProot = string.Empty; // strAIP.Replace("AIP", "DIP");
                    foreach (string str in strSplitus)
                    {
                        strDIProot += str + "\\";
                    }
                    strDIProot = strDIProot.Remove(strDIProot.Length - 1);

                    if (!Directory.Exists(strDIProot))
                    {
                        Directory.CreateDirectory(strDIProot);
                    }
                    string strDIPfolder = strDIProot + "\\" + karfa.karfa + "_" + m_comLanthegar.Text;  //ná í þetta síðar með cLanthega

                    {
                        Directory.CreateDirectory(strDIPfolder);
                    }
                    strExcelMal = strDIPfolder;


                    //flytja og skrá skrár sem hafa verið valdar
                    strDIPfolder = strDIPfolder + "\\" + utgafur.utgafa_titill; // + " " + utgafur.afharnr;
                    if (!Directory.Exists(strDIPfolder))
                    {
                        Directory.CreateDirectory(strDIPfolder);
                    }
                    string strSkraSlod = r["slod"].ToString() + "\\1.tif"; //þarf að laga síðar trúlega
                    string[] strSplit = r["slod"].ToString().Split("\\");
                    DataSet ds = new DataSet();

                    string strDocIndex = strSlod + "\\Indices\\docIndex.xml";
                    ds.ReadXml(strDocIndex);
                    string strID = strSplit[strSplit.Length - 1];
                    string strExp = "dID= '" + strSplit[strSplit.Length - 1] + "'";
                    DataRow[] fRow = ds.Tables[0].Select(strExp);

                    string strDocTitill = fRow[0]["oFn"].ToString();
                    strSplit = strDocTitill.Split(".");
                    strDocTitill = strSplit[0] + ".tif";

                    string strMalTitill = pathChar(r["maltitill"].ToString());
                    strMalTitill = pathChar(strMalTitill);
                    //breyta hér hafa titill máls í sa
                    if (!Directory.Exists(strDIPfolder + "\\" + "Mál_" + iMal.ToString("00") + "_" + strMalTitill))
                    {
                        Directory.CreateDirectory(strDIPfolder + "\\" + "Mál_" + iMal.ToString("00") + "_" + strMalTitill);
                    }
                    string strDestDoc = strDIPfolder + "\\" + "Mál_" + iMal.ToString("00") + "_" + strMalTitill + "\\" + pathChar(strDocTitill);
                    // oft sama nafnið á skjali í kerfi 
                    if (File.Exists(strDestDoc))
                    {
                        iSkjal++;
                        strSplit = strDestDoc.Split(".");
                        //if(strSplit.Length == 2)
                        //{
                        //    strDestDoc = strDestDoc.Replace(".", "(" + iSkjal + ")."); //vantar að búa til ef fleiri en tvö
                        //}
                        //else
                        //{
                        string strSkjal = strSplit[strSplit.Length - 1].Replace(".", "(" + iSkjal + ").");
                        strDestDoc = strDestDoc.Replace(strSplit[strSplit.Length - 1], strSkjal);
                        //strDestDoc = strDestDoc.Replace(".", "(" + iSkjal + ")."); //vantar að búa til ef fleiri en tvö
                        // }

                    }
                    File.Copy(strSkraSlod, strDestDoc, true);

                    string strDest = strDIPfolder + "\\" + "Mál_" + iMal.ToString("00") + "_" + strMalTitill + "\\" + strMalTitill + ".xlsx";
                    //keyra út upplýsingar um málið
                    cMIdlun mIdlun = new cMIdlun();
                    mIdlun.m_bAfrit = virkurNotandi.m_bAfrit;
                    string strSQL = r["sqlMal"].ToString();
                    DataTable dtUmMal = mIdlun.keyraFyrirspurn(strSQL, r["gagnagrunnur"].ToString());
                    exportExell(dtUmMal, "C:\\temp\\mal.xlsx");
                    File.Copy("C:\\temp\\mal.xlsx", strDest, true);
                    try
                    {
                        File.Delete("C:\\temp\\gagn.xlsx");
                    }
                    catch (Exception x)
                    {

                        // throw;
                    }

                    cMD5 mD5 = new cMD5();
                    mD5.m_bAfrit = virkurNotandi.m_bAfrit;
                    string strMD5 = mD5.getMD5(strID, utgafur.vorsluutgafa);

                    DataRow rr = dtExcellMal.NewRow();
                    rr["Mál"] = "Mál_" + iMal.ToString("00");
                    rr["Skrá"] = strDocTitill;

                    rr["md5"] = strMD5;
                    rr["maltitill"] = r["maltitill"].ToString(); ;

                    rr["Slóð"] = strDestDoc.Replace(strDIProot, "");
                    dtExcellMal.Rows.Add(rr);
                    dtExcellMal.AcceptChanges();

                    cDIPkarfaItem karfa_item = new cDIPkarfaItem();
                    karfa_item.m_bAfrit = virkurNotandi.m_bAfrit;

                    karfa_item.karfa = karfa.karfa;
                    karfa_item.vorsluutgafa = r["gagnagrunnur"].ToString().Replace("_", ".");
                    karfa_item.Fjold_skrar = Convert.ToInt32(r["documentid"]);
                    karfa_item.skjalID = r["documentid"].ToString();
                    karfa_item.md5 = strMD5;
                    karfa_item.slod = strDestDoc;
                    karfa_item.titill = r["titill"].ToString();
                    karfa_item.heitiVorslu = r["heitivorslu"].ToString();
                    karfa_item.maltitill = r["maltitill"].ToString();
                    karfa_item.vistaMalaKerfi();

                    m_pgbPontun.PerformStep();
                    m_lblPontunstatus.Text = string.Format("{0}/{1}", m_pgbPontun.Value, m_pgbPontun.Maximum);
                    m_pgbPontun.Visible = true;
                    m_lblPontunstatus.Visible = true;
                    Application.DoEvents();
                }


            }

            //gagnagrunnur
            int iFjoldi = 0;
            string strTextTXT = string.Empty;
            string strTXTfile = string.Empty;
            m_tacPontun.SelectedTab = m_tapPontunGagnagrunnar;
            Application.DoEvents();
            int iFyrirspurnNr = 0;
            foreach (DataRow rr in m_dtDIPGrunn.Rows)
            {
                if (karfa.karfa == 0)
                {
                    karfa.heiti = m_comLanthegar.Text + " " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                    karfa.lanthegi = m_comLanthegar.SelectedValue.ToString();
                    karfa.hver_skradi = virkurNotandi.nafn;
                    karfa.athugasemdir = m_tboPontunAth.Text;
                    karfa.vista();
                }

                string strSQL = rr["sql"].ToString();
                string strGagnagrunnur = rr["vorsluutgafa"].ToString().Replace(".", "_");
                cMIdlun midlun = new cMIdlun();
                midlun.m_bAfrit = virkurNotandi.m_bAfrit;
                DataTable dt = midlun.keyraFyrirspurn(strSQL, strGagnagrunnur);
                string strVorsluutgafa = rr["vorsluutgafa"].ToString();


                //finna vörsluútgáfurót
                cVorsluutgafur utgafur = new cVorsluutgafur();
                utgafur.m_bAfrit = virkurNotandi.m_bAfrit;
                utgafur.getVörsluútgáfu(strVorsluutgafa);
                string strSlod = utgafur.slod;


                DriveInfo divo = new DriveInfo(strSlod);

                string strDIProot = divo.Name + "\\DIP";
                if (!Directory.Exists(strDIProot))
                {
                    Directory.CreateDirectory(strDIProot);
                }
                string strDIPfolder = strDIProot + "\\" + karfa.karfa + "_" + m_comLanthegar.Text;  //ná í þetta síðar með cLanthega

                {
                    Directory.CreateDirectory(strDIPfolder);
                }

                strExcellGagna = strDIPfolder;
                strDIPfolder = strDIPfolder + "\\" + utgafur.utgafa_titill; // + " " + utgafur.afharnr;
                if (!Directory.Exists(strDIPfolder))
                {
                    Directory.CreateDirectory(strDIPfolder);
                }
                string strDest = strDIPfolder + "\\Fyrirspurn_" + iFjoldi + ".xlsx";
                strTXTfile = strDIPfolder;
                exportExell(dt, "C:\\temp\\gagn.xlsx");
                File.Copy("C:\\temp\\gagn.xlsx", strDest, true);
                try
                {
                    File.Delete("C:\\temp\\gagn.xlsx");
                }
                catch (Exception x)
                {

                    // throw;
                }
                DataRow rGrunn = dtExcellGrunnur.NewRow();
                iFjoldi++;
                ////m_dtDIPGrunn.Columns.Add("Heiti");
                ////m_dtDIPGrunn.Columns.Add("vorsluutgafa");
                ////m_dtDIPGrunn.Columns.Add("leitarskilyrði");
                ////m_dtDIPGrunn.Columns.Add("sql");
                ////m_dtDIPGrunn.Columns.Add("slod");
                rGrunn["Heiti"] = rr["heiti"];
                rGrunn["vorsluutgafa"] = rr["vorsluutgafa"].ToString();
                rGrunn["leitarskilyrdi"] = rr["leitarskilyrdi"].ToString();
                rGrunn["sql"] = rr["sql"].ToString();
                rGrunn["slod"] = strDest.Replace(strDIProot, "");  // strSkjal[0];
                rGrunn["heitivorslu"] = rr["heitivorslu"];

                dtExcellGrunnur.Rows.Add(rGrunn);


                cDIPkarfaItem karfa_item = new cDIPkarfaItem();
                karfa_item.m_bAfrit = virkurNotandi.m_bAfrit;
                karfa_item.karfa = karfa.karfa;
                karfa_item.heiti = rr["heiti"].ToString();
                karfa_item.leitarskilyrdi = rr["leitarskilyrdi"].ToString();
                karfa_item.vorsluutgafa = rr["vorsluutgafa"].ToString();
                karfa_item.sql = rr["sql"].ToString();
                karfa_item.heitiVorslu = rr["heitiVorslu"].ToString();
                karfa_item.slod = strDest;
                karfa_item.vistaGagnagrunn();
                //setja hérna inn "lestumig.txt"
                strTextTXT += "Fyrirspurn_" + iFyrirspurnNr + " Leitarskilyrði: " + rr["leitarskilyrdi"] + "Fjoldi niðurstaðna: " + dt.Rows.Count + Environment.NewLine;

                iFyrirspurnNr++;
                m_pgbPontun.PerformStep();
                m_lblPontunstatus.Text = string.Format("{0}/{1}", m_pgbPontun.Value, m_pgbPontun.Maximum);
                m_pgbPontun.Visible = true;
                m_lblPontunstatus.Visible = true;
                Application.DoEvents();
            }


            //  File.SetAttributes(strExcell, File.GetAttributes(strExcell) & ~FileAttributes.ReadOnly);
            //  exportExell(m_dtDIPSkra, strExcell + "\\Gagnalisti.xlsx");
            if (dtExcell.Rows.Count > 0)
            {
                exportExell(dtExcell, "C:\\temp\\listi.xlsx");
                File.Copy("C:\\temp\\listi.xlsx", strExcell + "\\Skráakerfi.xlsx", true);
                try
                {
                    File.Delete("C:\\temp\\listi.xlsx");
                }
                catch (Exception x)
                {

                    // throw;
                }
            }

            if (dtExcellMal.Rows.Count > 0)
            {

                exportExell(dtExcellMal, "C:\\temp\\malaskra.xlsx");
                File.Copy("C:\\temp\\malaskra.xlsx", strExcelMal + "\\Málaskrár.xlsx", true);
                try
                {
                    File.Delete("C:\\temp\\listi.xlsx");
                }
                catch (Exception x)
                {

                    // throw;
                }
            }

            int i = 0;
            if (dtExcellGrunnur.Rows.Count > 0)
            {
                string strDest = strTXTfile + "\\Fyrirspurn_" + i + ".txt";
                i++;
                //  File.Create(strDest);
                TextWriter txt = new StreamWriter(strDest);
                txt.Write(strTextTXT);
                txt.Close();

                exportExell(dtExcellGrunnur, "C:\\temp\\Grunnar.xlsx");
                File.Copy("C:\\temp\\Grunnar.xlsx", strExcellGagna + "\\Gagnagrunnar.xlsx", true);
                try
                {
                    File.Delete("C:\\temp\\Grunnar.xlsx");
                }
                catch (Exception x)
                {

                    // throw;
                }

            }

            m_dgvDIPList.DataSource = m_dtDIPSkra;

            m_dtDIPSkra.Rows.Clear();
            m_dtDIPGrunn.Rows.Clear();
            m_dtDIPMal.Rows.Clear();
            m_dsDIPmal.Tables.Clear();
            fyllaDIPLista();
            m_trwDIP.SelectedNode = m_trwDIP.Nodes[0];
            karfa.hreinsahlut();

            MessageBox.Show("DIP tilbúið");
            int Fjoldi = m_dtDIPSkra.Rows.Count + m_dtDIPGrunn.Rows.Count + m_dtDIPMal.Rows.Count;
            this.Text = string.Format("Afgreiðsla: {0} skrár óafgreiddar", Fjoldi);
            m_pgbPontun.Visible = false;
            m_lblPontunstatus.Visible = false;
        }

        private string pathChar(string strPath)
        {
            string strRet = strPath;
            strRet = strRet.Replace("<", "_");
            strRet = strRet.Replace(">", "_");
            strRet = strRet.Replace(":", "_");
            strRet = strRet.Replace("\"", "_");
            strRet = strRet.Replace("/", "_");
            strRet = strRet.Replace("\\", "_");
            strRet = strRet.Replace("|", "_");
            strRet = strRet.Replace("?", "_");
            strRet = strRet.Replace("*", "_");
            strRet = strRet.Replace("@", "_");
            strRet = strRet.Replace("!", "_");

            return strRet;

        }
        private void fyllaDIPLista()
        {

            DataTable dt = karfa.getKorfurDIP();

            m_trwDIP.Nodes.Clear();
            foreach (DataRow r in dt.Rows)
            {
                string strText = r["karfa"].ToString() + " " + r["heiti"];
                TreeNode n = new TreeNode(strText);
                n.Tag = r["karfa"];
                m_trwDIP.Nodes.Add(n);

            }
            int iFjoldi = 0;
            if (m_dsDIPmal.Tables.Count != 0)
            {
                DataTable dtMalAllt = new DataTable();

                for (int i = 0; i < m_dsDIPmal.Tables.Count; i++)
                {
                    if (i == 0)
                        dtMalAllt = m_dsDIPmal.Tables[i].Copy();
                    else
                        dtMalAllt.Merge(m_dsDIPmal.Tables[i]);
                }
                iFjoldi = m_dtDIPSkra.Rows.Count + dtMalAllt.Rows.Count + m_dtDIPGrunn.Rows.Count;
            }
            else
            {
                iFjoldi = m_dtDIPSkra.Rows.Count + m_dtDIPGrunn.Rows.Count;
            }
            if (iFjoldi != 0)
            //  if (m_trwDIP.Nodes.Count != 0)
            {
                splitContainer2.Panel1.BackColor = System.Drawing.Color.LightYellow;

                // TreeNode n = new TreeNode("Ópantað");
                if (m_trwDIP.Nodes.Count != 0)
                {
                    if (m_trwDIP.Nodes[0].Text != "Óafgreidd pöntun")
                    {
                        m_trwDIP.Nodes.Insert(0, "Óafgreidd pöntun");
                    }

                }
                else
                {
                    m_trwDIP.Nodes.Insert(0, "Óafgreidd pöntun");
                }

            }
            else
            {
                //m_trwDIP.Nodes.Insert(0, "Óafgreidd pöntun");
                if (m_trwDIP.Nodes.Count != 0)
                {
                    if (m_trwDIP.Nodes[0].Text == "Óafgreidd pöntun")
                    {
                        if (m_trwDIP.Nodes.Count != 0)
                        {
                            m_trwDIP.Nodes.Remove(m_trwDIP.Nodes[0]);
                        }

                    }
                }

                splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            }
            m_btnKlaraPontun.Enabled = true;
            m_btnOpna.Enabled = false;
            m_btnTæma.Enabled = true;
            // m_comLanthegar.SelectedIndex = 0;
            m_lblLanthegi.Visible = false;
            if (m_trwDIP.Nodes.Count != 0)
            {
                m_trwDIP.SelectedNode = m_trwDIP.Nodes[0];
            }
        }
        private void exportExell(System.Data.DataTable tbl, string excelFilePath)
        {
            // try
            {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Microsoft.Office.Interop.Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (var i = 0; i < tbl.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }

                // rows
                for (var i = 0; i < tbl.Rows.Count; i++)
                {
                    // to do: format datetime values before printing
                    for (var j = 0; j < tbl.Columns.Count; j++)
                    {
                        string strBLA = tbl.Rows[i][j].ToString();
                        if (strBLA.Contains("\\"))
                        {
                            string strLink = ".." + strBLA;
                            workSheet.Hyperlinks.Add(workSheet.Cells[i + 2, j + 1], ".." + strBLA, Type.Missing, "Sharifsoft", "www.Sharifsoft.com");
                            //  workSheet.get_Range("c1").Formula = "=HYPERLINK("+ "..\\" +strBLA + ")";
                        }
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }

                // check file path
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        if (File.Exists(excelFilePath))
                        {
                            try
                            {
                                File.Delete(excelFilePath);
                            }
                            catch (Exception x)
                            {


                            }
                        }

                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                        //  MessageBox.Show(String.Format("Exelskjal skráð í VINNUSKJÖL{0}{1}", Environment.NewLine, excelFilePath));
                    }
                    catch (Exception ex)
                    {
                        excelApp.Quit();
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                            + ex.Message);


                    }
                }
                else
                { // no file path is given
                    excelApp.Visible = true;
                }
            }
            //   catch (Exception ex)
            {

                //throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }

        private void m_btnOpna_Click(object sender, EventArgs e)
        {
            if (m_strSlodDIP != string.Empty)
            {
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(m_strSlodDIP)
                {
                    UseShellExecute = true
                };
                p.Start();
            }
        }

        private void m_btnNyrLanthegi_Click(object sender, EventArgs e)
        {
            frmLanthegi lanthegi = new frmLanthegi(virkurNotandi);
            lanthegi.ShowDialog();
            fyllaLanthega();
            m_comLanthegar.SelectedIndex = m_comLanthegar.Items.Count - 1;
        }

        private void m_trwDIP_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //   if(m_trwDIP.Focused)
            {
                if (e.Node.Text == "Óafgreidd pöntun")
                {
                    m_tboPontunAth.Text = string.Empty;
                    m_btnPantAthUpp.Enabled = false;
                    m_lblKarfaNr.Visible = false;
                    m_btnKlaraPontun.Enabled = true;
                    m_btnOpna.Enabled = false;
                    m_btnTæma.Enabled = true;
                    m_comLanthegar.SelectedIndex = 0;
                    m_lblLanthegi.Visible = false;
                    splitContainer2.Panel1.BackColor = System.Drawing.Color.LightYellow;
                    m_dgvDIPList.AutoGenerateColumns = false;
                    m_dgvDIPList.DataSource = m_dtDIPSkra;
                    m_tapPontunSkra.Text = string.Format("Skráakerfi ({0})", m_dtDIPSkra.Rows.Count);

                    if (m_dsDIPmal.Tables.Count != 0)
                    {
                        m_dgvDIPmal.AutoGenerateColumns = false;
                        DataTable dtMalAllt = new DataTable();

                        for (int i = 0; i < m_dsDIPmal.Tables.Count; i++)
                        {
                            if (i == 0)
                                dtMalAllt = m_dsDIPmal.Tables[i].Copy();
                            else
                                dtMalAllt.Merge(m_dsDIPmal.Tables[i]);
                        }
                        m_dgvDIPmal.DataSource = dtMalAllt;
                        m_tapPontunMalakerfi.Text = string.Format("Málakerfi ({0})", dtMalAllt.Rows.Count);
                        m_tacPontun.SelectedTab = m_tapPontunMalakerfi;
                    }
                    else
                    {
                        m_dgvDIPmal.AutoGenerateColumns = false;
                        m_dgvDIPmal.DataSource = m_dtDIPMal;
                        m_tapPontunMalakerfi.Text = string.Format("Málakerfi ({0})", m_dtDIPMal.Rows.Count);
                    }

                    m_dgvDIPGagnagrunnar.AutoGenerateColumns = false;
                    m_dgvDIPGagnagrunnar.DataSource = m_dtDIPGrunn;
                    m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtDIPGrunn.Rows.Count);

                    return;
                }
                m_btnKlaraPontun.Enabled = false;
                m_btnOpna.Enabled = true;
                m_btnTæma.Enabled = false;
                splitContainer2.Panel1.BackColor = System.Drawing.Color.LightGreen;
                string strKarfa = e.Node.Tag.ToString();
                cDIPKarfa karfa = new cDIPKarfa();
                karfa.m_bAfrit = virkurNotandi.m_bAfrit;
                karfa.sækjaKörfu(strKarfa);
                m_comLanthegar.SelectedValue = karfa.lanthegi;
                m_tboPontunAth.Text = karfa.athugasemdir;
                m_lblKarfaNr.Visible = true;
                m_lblKarfaNr.Text = string.Format("Pöntun nr: {0}", karfa.karfa);
                m_btnPantAthUpp.Enabled = true;
                cDIPkarfaItem items = new cDIPkarfaItem();
                items.m_bAfrit = virkurNotandi.m_bAfrit;
                m_btnPantAthUpp.Enabled = true;
                DataTable dt = items.getKorfuItemDIP(strKarfa);
                m_dgvDIPList.AutoGenerateColumns = false;
                m_dgvDIPList.DataSource = items.getKorfuItemDIP(strKarfa);
                if (dt.Rows.Count != 0)
                {
                    m_tacPontun.SelectedTab = m_tapPontunSkra;
                }

                DataTable dtMal = items.getKorfuItemDIPMalakerfi(strKarfa);
                m_dgvDIPmal.AutoGenerateColumns = false;
                m_dgvDIPmal.DataSource = dtMal;
                if (dtMal.Rows.Count != 0)
                {
                    m_tacPontun.SelectedTab = m_tapPontunMalakerfi;
                }
                DataTable dtGrunn = items.getKorfuItemDIPGagnagrunnur(strKarfa);
                m_dgvDIPGagnagrunnar.AutoGenerateColumns = false;
                m_dgvDIPGagnagrunnar.DataSource = dtGrunn;
                if (dtGrunn.Rows.Count != 0)
                {
                    m_tacPontun.SelectedTab = m_tapPontunGagnagrunnar;
                }

                if (dt.Rows.Count > 0)
                {
                    string[] strSplit = dt.Rows[0]["slod"].ToString().Split("\\");
                    bool b = false;
                    int i = 0;
                    m_strSlodDIP = string.Empty;
                    foreach (string str in strSplit)
                    {
                        if (!b)
                        {
                            m_strSlodDIP += str + "\\";
                        }
                        if (str == "DIP")
                        {
                            if (strSplit[i + 1] != string.Empty)
                            {
                                m_strSlodDIP = m_strSlodDIP + "\\" + strSplit[i + 1];
                            }
                            else
                            {
                                m_strSlodDIP = m_strSlodDIP + "\\" + strSplit[i + 2];
                            }
                            b = true;

                        }
                        i++;

                    }
                    //    m_strSlodDIP = strSplit[0] + "\\" + strSplit[2] + "\\" + strSplit[3];

                }
                if (dtGrunn.Rows.Count > 0)
                {
                    string[] strSplit = dtGrunn.Rows[0]["slod"].ToString().Split("\\");
                    bool b = false;
                    int i = 0;
                    m_strSlodDIP = string.Empty;
                    foreach (string str in strSplit)
                    {
                        if (!b)
                        {
                            m_strSlodDIP += str + "\\";
                        }
                        if (str == "DIP")
                        {
                            if (strSplit[i + 1] != string.Empty)
                            {
                                m_strSlodDIP = m_strSlodDIP + "\\" + strSplit[i + 1];
                            }
                            else
                            {
                                m_strSlodDIP = m_strSlodDIP + "\\" + strSplit[i + 2];
                            }
                            b = true;

                        }
                        i++;

                    }
                    //  m_strSlodDIP = strSplit[0] + "\\" + strSplit[2] + "\\" + strSplit[3];

                }
                if (dtMal.Rows.Count > 0)
                {

                    string[] strSplit = dtMal.Rows[0]["slod"].ToString().Split("\\");
                    bool b = false;
                    int i = 0;
                    m_strSlodDIP = string.Empty;
                    foreach (string str in strSplit)
                    {
                        if (!b)
                        {
                            m_strSlodDIP += str + "\\";
                        }
                        if (str == "DIP")
                        {
                            if (strSplit[i + 1] != string.Empty)
                            {
                                m_strSlodDIP = m_strSlodDIP + "\\" + strSplit[i + 1];
                            }
                            else
                            {
                                m_strSlodDIP = m_strSlodDIP + "\\" + strSplit[i + 2];
                            }
                            b = true;

                        }
                        i++;

                    }
                    //  m_strSlodDIP = strSplit[0] + "\\" + strSplit[2] + "\\" + strSplit[3];

                }

                m_tapPontunSkra.Text = string.Format("Skráakerfi ({0})", dt.Rows.Count);
                m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", dtGrunn.Rows.Count);
                m_tapPontunMalakerfi.Text = string.Format("Málakerfi ({0})", dtMal.Rows.Count);
                int iFjoldi = dt.Rows.Count + dtGrunn.Rows.Count + dtMal.Rows.Count;
                m_grbDIP.Text = string.Format("Afgreitt {0}", iFjoldi);


            }

        }

        private void m_btnTæma_Click(object sender, EventArgs e)
        {
            m_dtDIPSkra.Rows.Clear();
            m_dgvDIPList.DataSource = m_dtDIPSkra;
            m_dtDIPGrunn.Rows.Clear();
            m_dgvDIPGagnagrunnar.DataSource = m_dtDIPGrunn;
            m_dtDIPMal.Rows.Clear();

            m_dsDIPmal.Tables.Clear();
            m_dgvDIPmal.DataSource = m_dtDIPMal;
            fyllaDIPLista();
            if (m_comLanthegar.SelectedIndex != 0)
            {
                string strID = m_comLanthegar.SelectedValue.ToString();
                lanþegi.getaLanthega(strID);
                if (lanþegi.id != 0)
                {
                    m_lblLanthegi.Visible = true;
                    m_lblLanthegi.Text = string.Format("Nafn: {0}{1}Kennitala: {2}{1}Stofnun: {3}{1}Kennitala stofnunar: {4}{1}Sími: {5}{1}Netfang: {6}{1}Skráður af: {7}{1}Dagsetning skráningar: {8}", lanþegi.nafn, Environment.NewLine, lanþegi.kennitala, lanþegi.nafn_fyrirtaekis, lanþegi.kennitala_fyrirtaekis, lanþegi.simi, lanþegi.netfang, lanþegi.skrad_af, lanþegi.dags_skrad);
                }
                else
                {
                    m_lblLanthegi.Visible = false;
                }

            }
            m_trwDIP.SelectedNode = m_trwDIP.Nodes[0];
            m_tapPontunSkra.Text = string.Format("Skráakerfi ({0})", m_dtDIPSkra.Rows.Count);
            m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtDIPGrunn.Rows.Count);
            m_tapPontunMalakerfi.Text = string.Format("Málakerfi ({0})", m_dtDIPMal.Rows.Count);
            int iFjoldi = m_dtDIPSkra.Rows.Count + m_dtDIPGrunn.Rows.Count + m_dtDIPMal.Rows.Count;
            m_grbDIP.Text = string.Format("Óafgreitt {0}", iFjoldi);
        }

        private void m_comLanthegar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_comLanthegar.Focused || m_trwDIP.Focused)
            {
                if (m_comLanthegar.SelectedIndex != 0)
                {
                    string strID = m_comLanthegar.SelectedValue.ToString();
                    lanþegi.getaLanthega(strID);
                    if (lanþegi.id != 0)
                    {
                        m_lblLanthegi.Visible = true;
                        m_lblLanthegi.Text = string.Format("Nafn: {0}{1}Kennitala: {2}{1}Stofnun: {3}{1}Kennitala stofnunar: {4}{1}Sími: {5}{1}Netfang: {6}{1}Skráður af: {7}{1}Dagsetning skráningar: {8}", lanþegi.nafn, Environment.NewLine, lanþegi.kennitala, lanþegi.nafn_fyrirtaekis, lanþegi.kennitala_fyrirtaekis, lanþegi.simi, lanþegi.netfang, lanþegi.skrad_af, lanþegi.dags_skrad);
                    }
                    else
                    {
                        m_lblLanthegi.Visible = false;
                    }

                }
            }
        }

        private void m_dgvDIPList_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                switch (senderGrid.Name)
                {
                    case "m_dgvDIPList":
                        if (senderGrid.Columns["colSkraRemove"].Index == e.ColumnIndex)
                        {
                            DialogResult result = MessageBox.Show("Viltu fjarlægja þetta skjal?", "Fjarlægja skjal", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                m_dgvDIPList.Rows.Remove(m_dgvDIPList.Rows[e.RowIndex]);
                                m_dtDIPSkra = (DataTable)m_dgvDIPList.DataSource;
                                m_dtDIPSkra.AcceptChanges();

                            }
                        }
                        if (senderGrid.Columns["colSkraOpna"].Index == e.ColumnIndex)
                        {
                            var p = new Process();
                            string strSlod = string.Empty;
                            string strVorsluutgafa = senderGrid.Rows[e.RowIndex].Cells["colSkraVarslaID"].Value.ToString();
                            cVorsluutgafur utgafur = new cVorsluutgafur();
                            utgafur.m_bAfrit = virkurNotandi.m_bAfrit;
                            utgafur.getVörsluútgáfu(strVorsluutgafa);
                            strSlod = utgafur.slod;


                            string strValid = senderGrid.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                            double dColl = Convert.ToInt32(strValid) / 10000;
                            int iID = Convert.ToInt32(strValid);
                            if (iID == 1)
                            {
                                dColl = 1;
                            }
                            else
                            {
                                dColl = dColl + 1;
                            }
                            strSlod = strSlod + "\\Documents\\docCollection" + dColl.ToString() + "\\" + strValid;

                            string[] strFiles = Directory.GetFiles(strSlod);
                            strSlod = strFiles[0];

                            p.StartInfo = new ProcessStartInfo(strSlod)
                            {
                                UseShellExecute = true
                            };
                            p.Start();
                        }
                        break;

                    case "m_dgvDIPmal":
                        if (senderGrid.Columns["colMalRemove"].Index == e.ColumnIndex)
                        {
                            DialogResult result = MessageBox.Show("Viltu fjarlægja þetta skjal?", "Fjarlægja skjal", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                string strGrunnur = m_dgvDIPmal.Rows[e.RowIndex].Cells["colMalGagnagrunnur"].Value.ToString();
                                string strDocID = m_dgvDIPmal.Rows[e.RowIndex].Cells["colMalSkraID"].Value.ToString();
                                string strEXP = "documentid = '" + strDocID + "'";
                                DataRow[] fRow = m_dsDIPmal.Tables[strGrunnur].Select(strEXP);
                                if (fRow.Length != 0)
                                {
                                    fRow[0].Delete();
                                    m_dsDIPmal.Tables[strGrunnur].AcceptChanges();
                                }
                                m_dgvDIPmal.Rows.Remove(m_dgvDIPmal.Rows[e.RowIndex]);
                                m_dtDIPMal = (DataTable)m_dgvDIPmal.DataSource;
                                m_dtDIPMal.AcceptChanges();
                                //m_dsDIPmal.Tables[0] = m_dtDIPMal;
                            }
                        }
                        if (senderGrid.Columns["colMalOpna"].Index == e.ColumnIndex)
                        {
                            var p = new Process();

                            string strSlod = senderGrid.Rows[e.RowIndex].Cells["colMalSlod"].Value.ToString();
                            //string[] strSkra = Directory.GetFiles(strSlod);
                            //if (strSkra.Length > 0)
                            //{
                            //    strSlod = strSkra[0].ToString();
                            //}


                            p.StartInfo = new ProcessStartInfo(strSlod)
                            {
                                UseShellExecute = true
                            };
                            p.Start();
                        }
                        break;

                    case "m_dgvDIPGagnagrunnar":
                        if (senderGrid.Columns["colGagnRemove"].Index == e.ColumnIndex)
                        {
                            DialogResult result = MessageBox.Show("Viltu fjarlægja þetta skjal?", "Fjarlægja skjal", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                m_dgvDIPGagnagrunnar.Rows.Remove(m_dgvDIPGagnagrunnar.Rows[e.RowIndex]);
                                m_dtDIPGrunn = (DataTable)m_dgvDIPGagnagrunnar.DataSource;
                                m_dtDIPGrunn.AcceptChanges();
                            }
                        }
                        if (senderGrid.Columns["colGagnOpna"].Index == e.ColumnIndex)
                        {

                            string strGagnagrunnur = senderGrid.Rows[e.RowIndex].Cells["colGagnHeiti"].Value.ToString();
                            string strVarsla = senderGrid.Rows[e.RowIndex].Cells["colGagnHeitivorslu"].Value.ToString();
                            string strLeit = senderGrid.Rows[e.RowIndex].Cells["colGagnLeitskilyrdi"].Value.ToString();
                            string strSQL = senderGrid.Rows[e.RowIndex].Cells["colGagnSQL"].Value.ToString();
                            frmGagnagrunnSkoda skoda = new frmGagnagrunnSkoda(strSQL, virkurNotandi, strGagnagrunnur, strLeit, strGagnagrunnur, strVarsla);
                            skoda.ShowDialog();
                        }
                        break;
                }
                setjaFoldaTaba();
            }
        }

        private void m_btnPantAthUpp_Click(object sender, EventArgs e)
        {
            cDIPKarfa karfa = new cDIPKarfa();
            karfa.m_bAfrit = virkurNotandi.m_bAfrit;
            if (m_trwDIP.SelectedNode.Tag != null)
            {
                string strTag = m_trwDIP.SelectedNode.Tag.ToString();
                karfa.sækjaKörfu(strTag);
                karfa.athugasemdir = m_tboPontunAth.Text;
                karfa.vista();
            }
        }
    }
}
