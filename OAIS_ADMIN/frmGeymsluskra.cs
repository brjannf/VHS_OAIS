using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using cClassOAIS;
using SixLabors.ImageSharp.Drawing;
using Excel = Microsoft.Office.Interop.Excel;


namespace OAIS_ADMIN
{
    public partial class frmGeymsluskra : Form
    {
        public cNotandi virkurnotandi = new cNotandi();
        private string m_strVorsluAudkenni = string.Empty;
        private cSkjalaskra skjal = new cSkjalaskra();
        private cSkjalaskra fond = new cSkjalaskra();
        private cSkjalaskra temp = new cSkjalaskra();
        private string m_strTegund = string.Empty;
        cMIdlun midlun = new cMIdlun();
        string m_strAuðkenni = string.Empty;
        string m_strGagnagrunnur = string.Empty;
        string m_strSlod = string.Empty;
        TreeNode fondnode = new TreeNode();
        TreeNode seriesnode = new TreeNode();
        TreeNode subseriesnode = new TreeNode();

        DataTable m_dtGEYMSLUSKRA = new DataTable();
        int m_iSeriesLevel = 0;
        Array m_arrSeries;
        string m_strSeries = string.Empty;

        private DataTable m_dtGogn = new DataTable();
        public frmGeymsluskra()
        {
            InitializeComponent();
        }
        public frmGeymsluskra(string strAuðkenni, string strSlod,string strTegund, cNotandi not, string strVarsla)
        {
            InitializeComponent();

            m_arrSeries = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Þ","Æ", "Ö"};
            virkurnotandi = not;
            temp.m_bAfrit = virkurnotandi.m_bAfrit; 
            midlun.m_bAfrit = virkurnotandi.m_bAfrit;
            skjal.m_bAfrit = virkurnotandi.m_bAfrit;
            fond.m_bAfrit = virkurnotandi.m_bAfrit;
            m_dtGEYMSLUSKRA.Columns.Add("tilheyrir_skráningu");
            m_dtGEYMSLUSKRA.Columns.Add("upplysingastig");
            m_dtGEYMSLUSKRA.Columns.Add("auðkenni");
            m_dtGEYMSLUSKRA.Columns.Add("titill");
            m_dtGEYMSLUSKRA.Columns.Add("timabil");
            m_dtGEYMSLUSKRA.Columns.Add("innihald");
            m_dtGEYMSLUSKRA.Columns.Add("aðgengi");
            m_dtGEYMSLUSKRA.Columns.Add("afharnr");
            m_dtGEYMSLUSKRA.Columns.Add("athskjal");

            m_strVorsluAudkenni = strVarsla;

            m_strTegund = strTegund;
            m_strAuðkenni = strAuðkenni;
            m_strSlod = strSlod;
            m_strGagnagrunnur = m_strAuðkenni.Replace(".", "_");
            fyllaSkjalaSkra();
            fyllaGogn();
            skjal.getSkraning(strAuðkenni);
        }

        private void fyllaSkjalaSkra()
        {
            
            DataTable dt = skjal.getGeymsluSkra(m_strAuðkenni);
            m_trwGeymsluskrá.Nodes.Clear();
            TreeNode node = new TreeNode();
            TreeNode fondNode = new TreeNode();
            TreeNode seriesNode = new TreeNode();
            TreeNode subsseriesNode = new TreeNode();
            foreach (DataRow r in dt.Rows)
            {
                DataRow row = m_dtGEYMSLUSKRA.NewRow();
                //þarf hér að pæla í level of info
                TreeNode n = new TreeNode(r["3_1_2_titill"].ToString());
                if (r["3_1_4_upplýsingastig"].ToString() == "Skjalasafn")
                {
                    n.BackColor = Color.LightGreen;
                    n.Tag = r["3_1_1_auðkenni"].ToString();
                    m_trwGeymsluskrá.Nodes.Add(n);
                    fond.getSkraning(r["3_1_1_auðkenni"].ToString());
                    node = n;
                    fondNode = n;
                    string[] strSplit = fond.afhendingar_tilfærslur_3_2_4.Split("/");
                    fond.afhendingar_tilfærslur_3_2_4 = strSplit[0].Trim() + "/" + Convert.ToInt32(strSplit[1].Trim()).ToString();
                    row["tilheyrir_skráningu"] = fond.tilheyrir_skráningu;
                    row["upplysingastig"] = fond.upplýsingastig_3_1_4;
                    row["auðkenni"] = fond.auðkenni_3_1_1;
                    row["titill"] = fond.titill_3_1_2;
                    row["timabil"] = fond.tímabil_3_1_3;
                    row["innihald"] = fond.yfirlit_innihald_3_3_1;
                    row["aðgengi"] = fond.skilyrði_aðgengi_3_4_1;
                    row["afharnr"] = fond.afhendingar_tilfærslur_3_2_4;
                    row["athskjal"] = fond.athugasemdir_skjalavarðar_3_7_1;
                }
                if (r["3_1_4_upplýsingastig"].ToString() == "Yfirskjalaflokkur")
                {
                    n.BackColor = Color.LightGreen;
                    n.Tag = r["3_1_1_auðkenni"].ToString().Replace(fond.auðkenni_3_1_1 + "-", ""); 
                   // m_trwGeymsluskrá.Nodes.Add(n);
                    temp.getSkraning(r["3_1_1_auðkenni"].ToString());
                    fondNode.Nodes.Add(n);
                    string[] strSplit = fond.afhendingar_tilfærslur_3_2_4.Split("/");
                    fond.afhendingar_tilfærslur_3_2_4 = strSplit[0].Trim() + "/" + Convert.ToInt32(strSplit[1].Trim()).ToString();
                    row["tilheyrir_skráningu"] = temp.tilheyrir_skráningu;
                    row["upplysingastig"] = temp.upplýsingastig_3_1_4;
                    row["auðkenni"] =  temp.auðkenni_3_1_1.Replace(fond.auðkenni_3_1_1 + "-", "");
                    row["titill"] = temp.titill_3_1_2;
                    row["timabil"] = temp.tímabil_3_1_3;
                    row["innihald"] = temp.yfirlit_innihald_3_3_1;
                    row["aðgengi"] = temp.skilyrði_aðgengi_3_4_1;
                    row["afharnr"] = fond.afhendingar_tilfærslur_3_2_4;
                    row["athskjal"] = temp.athugasemdir_skjalavarðar_3_7_1;
                    node = n;
                    seriesNode = n;
                }
                if (r["3_1_4_upplýsingastig"].ToString() == "Skjalaflokkur")
                {
                    n.BackColor = Color.LightGreen;
                    n.Tag = r["3_1_1_auðkenni"].ToString().Replace(fond.auðkenni_3_1_1 + "-", "");
                    //  m_trwGeymsluskrá.Nodes.Add(n);
                    temp.getSkraning(r["3_1_1_auðkenni"].ToString());
                    seriesNode.Nodes.Add(n);
                    string[] strSplit = fond.afhendingar_tilfærslur_3_2_4.Split("/");
                    fond.afhendingar_tilfærslur_3_2_4 = strSplit[0].Trim() + "/" + Convert.ToInt32(strSplit[1].Trim()).ToString();
                    row["tilheyrir_skráningu"] = temp.tilheyrir_skráningu;
                    row["upplysingastig"] = temp.upplýsingastig_3_1_4;
                    row["auðkenni"] = temp.auðkenni_3_1_1.Replace(fond.auðkenni_3_1_1 + "-", "");
                    row["titill"] = temp.titill_3_1_2;
                    row["timabil"] = temp.tímabil_3_1_3;
                    row["innihald"] = temp.yfirlit_innihald_3_3_1;
                    row["aðgengi"] = temp.skilyrði_aðgengi_3_4_1;
                    row["afharnr"] = fond.afhendingar_tilfærslur_3_2_4;
                    row["athskjal"] = temp.athugasemdir_skjalavarðar_3_7_1;
                    node = n;
                    subsseriesNode = n;
                }
                if (r["3_1_4_upplýsingastig"].ToString() == "Örk")
                {
                    n.BackColor = Color.LightGreen;
                    n.Tag = r["3_1_1_auðkenni"].ToString().Replace(fond.auðkenni_3_1_1 + "-", "");
                    //  m_trwGeymsluskrá.Nodes.Add(n);
                    temp.getSkraning(r["3_1_1_auðkenni"].ToString());
                    node.Nodes.Add(n);
              
                    string[] strSplit = fond.afhendingar_tilfærslur_3_2_4.Split("/");
                    fond.afhendingar_tilfærslur_3_2_4 = strSplit[0].Trim() + "/" + Convert.ToInt32(strSplit[1].Trim()).ToString();
                    row["tilheyrir_skráningu"] = temp.tilheyrir_skráningu;
                    row["upplysingastig"] = temp.upplýsingastig_3_1_4;
                    row["auðkenni"] = temp.auðkenni_3_1_1.Replace(fond.auðkenni_3_1_1 + "-", "");
                    row["titill"] = temp.titill_3_1_2;
                    row["timabil"] = temp.tímabil_3_1_3;
                    row["innihald"] = temp.yfirlit_innihald_3_3_1;
                    row["aðgengi"] = temp.skilyrði_aðgengi_3_4_1;
                    row["afharnr"] = fond.afhendingar_tilfærslur_3_2_4;
                    row["athskjal"] = temp.athugasemdir_skjalavarðar_3_7_1;
                    node = fondnode;
                }

                m_trwGeymsluskrá.ExpandAll();
                m_dtGEYMSLUSKRA.Rows.Add(row);
                m_dtGEYMSLUSKRA.AcceptChanges();

            }
        }

        private void m_btnBuaTil_Click(object sender, EventArgs e)
        {

            //búa til töflu sem er einsog filemaker taflan og keyra gögn inn í þessi gildir fyrir harn
            DialogResult result = saveFileDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                DataTable dtFilemaker = new DataTable();

                if (m_strVorsluAudkenni == "HAKU")
                {
                    dtFilemaker.Columns.Add("Stofnun/deild");
                    dtFilemaker.Columns.Add("Skjalaflokkur");
                    dtFilemaker.Columns.Add("Kassanúmer");
                    dtFilemaker.Columns.Add("Örk");
                    dtFilemaker.Columns.Add("Frá ár");
                    dtFilemaker.Columns.Add("Til ár");
                    dtFilemaker.Columns.Add("Málalykill");
                    dtFilemaker.Columns.Add("Efni");
                    dtFilemaker.Columns.Add("Auðkenni og heiti skjalaflokks");
                    dtFilemaker.Columns.Add("Yfirskjalafl");
                    dtFilemaker.Columns.Add("Athugasemdir");
                }

                if (m_strVorsluAudkenni == "HARN")
                {
                    dtFilemaker.Columns.Add("tegund");
                    dtFilemaker.Columns.Add("Skjalamyndari");
                    dtFilemaker.Columns.Add("Sveitarfélag");
                    dtFilemaker.Columns.Add("Sveitarnr.");
                    dtFilemaker.Columns.Add("Afh. ár.");
                    dtFilemaker.Columns.Add("skjalaflokkur");
                    dtFilemaker.Columns.Add("kassanúmer");
                    dtFilemaker.Columns.Add("Örk");
                    dtFilemaker.Columns.Add("frá ár");
                    dtFilemaker.Columns.Add("til ár");
                    dtFilemaker.Columns.Add("L.1");
                    dtFilemaker.Columns.Add("Efni");
                    dtFilemaker.Columns.Add("Heiti skjalafl.");
                    dtFilemaker.Columns.Add("Geymsla");
                    dtFilemaker.Columns.Add("Yfirskjalafl");
                    dtFilemaker.Columns.Add("Ath.");
                    dtFilemaker.Columns.Add("Afhnúmer");
                }
                if (m_strVorsluAudkenni == "HMOS")
                {
                    //Skjalamyndari	Afh. ár	Afhnúmer	skjalaflokkur	kassanúmer	Örk	frá ár	til ár	Málalykill	Efni	Geymsla	Yfirskjalafl	Heiti skjalafl.	Ath.
                    dtFilemaker.Columns.Add("Skjalamyndari");
                    dtFilemaker.Columns.Add("Afh. ár");
                    dtFilemaker.Columns.Add("Afhnúmer");
                    dtFilemaker.Columns.Add("skjalaflokkur");
                    dtFilemaker.Columns.Add("kassanúmer");

                    dtFilemaker.Columns.Add("Örk");
                    dtFilemaker.Columns.Add("frá ár");
                    dtFilemaker.Columns.Add("til ár");
                    dtFilemaker.Columns.Add("Málalykill");
                    dtFilemaker.Columns.Add("Efni");
                    dtFilemaker.Columns.Add("Geymsla");
                    dtFilemaker.Columns.Add("Yfirskjalafl");
                    dtFilemaker.Columns.Add("Heiti skjalafl.");
                    dtFilemaker.Columns.Add("Ath.");
                }


                string strSeries = string.Empty;
                string strSubSeries = string.Empty;

                m_dtGEYMSLUSKRA.DefaultView.Sort = "auðkenni asc";
                DataTable dtSort = m_dtGEYMSLUSKRA.DefaultView.ToTable();

                foreach (DataRow r in dtSort.Rows)
                {
                    if (r["upplysingastig"].ToString() == "Yfirskjalaflokkur")
                    {
                        if (r["titill"].ToString() != strSeries)
                        {
                            strSeries = r["titill"].ToString();
                        }
                    }
                    if (r["upplysingastig"].ToString() == "Skjalaflokkur")
                    {
                        if (r["titill"] != strSeries)
                        {
                            strSubSeries = r["titill"].ToString();
                        }
                    }
                    if (r["upplysingastig"].ToString() == "Örk")
                    {
                        if (m_strVorsluAudkenni == "HARN")
                        {
                            DataRow row = dtFilemaker.NewRow();
                            row["tegund"] = "Opinber skjöl"; //þarf að breyta og vita hvað einka sköl eru
                            row["skjalamyndari"] = fond.heiti_skjalamyndara_3_2_1;
                            row["Sveitarfélag"] = string.Empty;
                            row["Sveitarnr."] = string.Empty;
                            string[] strSplit = fond.afhendingar_tilfærslur_3_2_4.Split("/");
                            row["Afh. ár."] = strSplit[0];
                            strSplit = strSeries.Split("-");
                            row["skjalaflokkur"] = strSplit[0];
                            row["kassanúmer"] = "1"; //þarf líklega ekki að breyta þessu
                            row["Örk"] = "1"; //þyrfti að breyta þessu ef fleiri en ein örk verður sett inn
                            strSplit = r["timabil"].ToString().Split("-");
                            if (strSplit.Length == 2)
                            {
                                row["frá ár"] = strSplit[0];
                                row["til ár"] = strSplit[1];
                            }

                            row["L.1"] = string.Empty;
                            row["Efni"] = r["innihald"];
                            row["Heiti skjalafl."] = strSubSeries;
                            row["Geymsla"] = string.Empty;
                            row["Yfirskjalafl"] = strSeries;
                            if (m_strTegund == "Málakerfi")
                            {
                                row["Ath."] = "Þetta skjalasafn inniheldur ræfræn gögn sem geymd eru hjá MHR og Héraðsskjalasafni Árnesinga"; // string.Empty; // string.Format("Skrár í þessum skjalaflokki eru geymdar í möppunni {0}", r["athskjal"].ToString());
                            }
                            else
                            {
                                row["Ath."] = string.Format("Skrár í þessum skjalaflokki eru geymdar í möppunni {0}", r["athskjal"].ToString());
                            }


                            row["Afhnúmer"] = fond.afhendingar_tilfærslur_3_2_4;
                            dtFilemaker.Rows.Add(row);
                            dtFilemaker.AcceptChanges();
                        }
                        if (m_strVorsluAudkenni == "HMOS")
                        {
                            DataRow row = dtFilemaker.NewRow();
                            row["skjalamyndari"] = fond.heiti_skjalamyndara_3_2_1;
                            string[] strSplit = fond.afhendingar_tilfærslur_3_2_4.Split("/");
                            row["Afh. ár"] = strSplit[0];
                            row["Afhnúmer"] = fond.afhendingar_tilfærslur_3_2_4;
                            strSplit = strSeries.Split("-");
                            row["skjalaflokkur"] = strSplit[0];
                            row["kassanúmer"] = "1"; //þarf líklega ekki að breyta þessu
                            row["Örk"] = "1"; //þyrfti að breyta þessu ef fleiri en ein örk verður sett inn
                            strSplit = r["timabil"].ToString().Split("-");
                            if (strSplit.Length == 2)
                            {
                                row["frá ár"] = strSplit[0];
                                row["til ár"] = strSplit[1];
                            }

                            row["Málalykill"] = string.Empty;
                            row["Efni"] = r["innihald"];
                            row["Heiti skjalafl."] = strSubSeries;
                            row["Geymsla"] = string.Empty;
                            row["Yfirskjalafl"] = strSeries;
                            row["Ath."] = string.Format("Skrár í þessum skjalaflokki eru geymdar í möppunni {0}", r["athskjal"].ToString());
                            row["Afhnúmer"] = fond.afhendingar_tilfærslur_3_2_4;
                            dtFilemaker.Rows.Add(row);
                            dtFilemaker.AcceptChanges();
                        }
                        if (m_strVorsluAudkenni == "HAKU")
                        {
                            DataRow row = dtFilemaker.NewRow();
                            row["Stofnun/deild"] = fond.heiti_skjalamyndara_3_2_1;
                            string[] strSplit = strSeries.Split("-");
                            row["Skjalaflokkur"] = strSplit[0];
                            row["Kassanúmer"] = "1";
                            row["Örk"] = "1";
                            strSplit = r["timabil"].ToString().Split("-");
                            if (strSplit.Length == 2)
                            {
                                row["Frá ár"] = strSplit[0];
                                row["Til ár"] = strSplit[1];
                            }
                            row["Málalykill"] = string.Empty;
                            row["Efni"] = r["innihald"];
                            row["Auðkenni og heiti skjalaflokks"] = strSubSeries;
                            row["Yfirskjalafl"] = strSeries;
                            row["Athugasemdir"] = string.Format("Skrár í þessum skjalaflokki eru geymdar í möppunni {0}", r["athskjal"].ToString());
                            dtFilemaker.Rows.Add(row);
                            dtFilemaker.AcceptChanges();
                        }

                    }

                }

                exportExell(dtFilemaker, saveFileDialog1.FileName);
                MessageBox.Show("búið");
            }
         

        }

        private void exportExell(System.Data.DataTable tbl, string excelFilePath)
        {
            try
            {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Excel._Worksheet workSheet = excelApp.ActiveSheet;

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
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }

                // check file path
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                     //   MessageBox.Show(String.Format("Exelskjal skráð í VINNUSKJÖL{0}{1}", Environment.NewLine, excelFilePath));
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
            catch (Exception ex)
            {

                //throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }

        private void fyllaGogn()
        {
            string strFyrirspurn = string.Empty;
            if(m_strTegund == "Skráarkerfi")
            {

                strFyrirspurn = midlun.getFyrirspurn(m_strGagnagrunnur, "Get_files_path");
                if (strFyrirspurn == string.Empty) //vegna nafnabreytinga AV 
                {
                    strFyrirspurn = midlun.getFyrirspurn(m_strGagnagrunnur, "AV_Get_files_path");
                    m_dtGogn = midlun.keyraFyrirspurn(strFyrirspurn, m_strGagnagrunnur);
                }
            }
            if (m_strTegund == "Málakerfi")
            {
                strFyrirspurn = midlun.getFyrirspurn(m_strGagnagrunnur, "malalykill");
                m_dtGogn = midlun.keyraFyrirspurn(strFyrirspurn, m_strGagnagrunnur);
            }
            if(m_strTegund == "Gagnagrunnur")
            {
                m_dtGogn = midlun.keyraFyrirspurn(strFyrirspurn, m_strGagnagrunnur);
                TreeNode n = new TreeNode("A-Gagnagrunnur1");
                m_trwGogn.Nodes.Add(n);
                TreeNode nn = new TreeNode("A-Gagnagrunnur2");
                n.Nodes.Add(nn);
            }
           
           
            int i  = 0; 
            foreach (DataRow r in m_dtGogn.Rows)
            {
                if (m_strTegund == "Skráarkerfi")
                {
                    PopulateTreeView(m_trwGogn, m_dtGogn.Rows[i]["mappa"].ToString().Split('\\'), '\\', r["skjalID"].ToString(), m_dtGogn.Rows[i]["mappa"].ToString());
                }
                //einfalda til að byrja með
                if (m_strTegund == "Málakerfi")
                {
                   
                    TreeNode n = new TreeNode(r["malalykill"].ToString());
                    // n.Tag = r["lykillID"];
                    n.Tag = r["malalykill"];
                    m_trwGogn.Nodes.Add(n);
                    strFyrirspurn = midlun.getFyrirspurn(m_strGagnagrunnur, "mal_lykill");
                    strFyrirspurn = strFyrirspurn.Replace("{lykillID}", n.Tag.ToString());
                   DataTable dt =  midlun.keyraFyrirspurn(strFyrirspurn, m_strGagnagrunnur);
                    foreach (DataRow rr in dt.Rows)
                    {
                        TreeNode nn = new TreeNode(rr["Sagstittel"].ToString());
                        n.Tag = rr["SagsID"].ToString();
                        n.Nodes.Add(nn);
                    }
                }
            
                //if (r["skjalID"].ToString() == m_strIdValinn)
                //{
                //   // string[] strSplit = m_dtGogn.Rows[i]["mappa"].ToString().Split('\\');
                //    //   m_tobLeitarord.Text = m_dtSkrar.Rows[i]["mappa"].ToString();
                //  //  strSkra = strSplit[strSplit.Length - 1]; // r["skjalID"].ToString();
                //}
                i++;
            }
            m_trwGogn.ExpandAll();
        }

        public void PopulateTreeView(TreeView treeView, string[] paths, char pathSeparator, string strTag, string strSlod)
        {
            TreeNode lastNode = null;
            string subPathAgg = string.Empty;
            int i = 0;
            foreach (string path in paths)
            {
                //   subPathAgg = string.Empty;
                i++;
                bool bSkjal = false;
                if (i == paths.Length)
                {
                    if (path.Contains("."))
                    {
                        bSkjal = true;
                    }
                }

                if (!bSkjal)
                {

                    foreach (string subPath in path.Split(pathSeparator))
                    {
                        subPathAgg += subPath + pathSeparator;
                        //var nodus = m_trwFileSystem.FlattenTree()
                        // .Where(nn => nn.Tag == lastNode.Tag)
                        //.ToList();
                        TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);  //leitar bara að nafni og finnur oft vitlaust og setur í
                        if (nodes.Length == 0)
                        {
                            if (lastNode == null)
                            {
                                lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                                lastNode.Expand();

                            }

                            else
                            {
                                lastNode = lastNode.Nodes.Add(subPathAgg, subPath);

                                if (bSkjal) //if (lastNode.Text.Contains('.'))
                                {
                                    lastNode.Tag = strTag;
                                    //if (m_strIdValinn == strTag)
                                    //{
                                    //    lastNode.BackColor = Color.LightGreen;
                                    //    m_trwFileSystem.SelectedNode = lastNode;
                                    //}
                                }
                                else
                                {
                                    lastNode.Tag = strSlod;
                                }

                            }

                        }

                        else
                        {
                            lastNode = nodes[0];
                            if (lastNode.IsSelected)
                            {
                                lastNode.Expand();
                            }


                        }


                    }
                }

            }
        }

        private void fyllaGeymsluskraTöflu(string strUpplysingastig, string strTitill)
        {
            DataRow row = m_dtGEYMSLUSKRA.NewRow();
            
           
       //     row["tilheyrir_skráningu"] = skjal.tilheyrir_skráningu;
            row["upplysingastig"] = strUpplysingastig;
            row["auðkenni"] = skjal.auðkenni_3_1_1;
            row["titill"] = skjal.titill_3_1_2;
            row["timabil"] =skjal.tímabil_3_1_3;
            row["innihald"] = skjal.yfirlit_innihald_3_3_1;
            row["aðgengi"] = fond.skilyrði_aðgengi_3_4_1;
            row["afharnr"] = fond.afhendingar_tilfærslur_3_2_4;
            row["athskjal"] = skjal.athugasemdir_skjalavarðar_3_7_1;
            m_dtGEYMSLUSKRA.Rows.Add(row);
            m_dtGEYMSLUSKRA.AcceptChanges();
        }

        private void m_trwGogn_AfterCheck(object sender, TreeViewEventArgs e)
        {
            skjal.hreinsaHlut();
            if(m_trwGogn.Focused)
            {
                m_iSeriesLevel = e.Node.Level;
                m_tboSeriesLevel.Text = string.Format("{0} - level {1}", e.Node.Text, m_iSeriesLevel);
            }
   
            TreeNode n = new TreeNode(e.Node.Text);
            fondnode = m_trwGeymsluskrá.Nodes[0];
        
            if(!m_trwGogn.SelectedNode.Checked)
            {
                var nodes = m_trwGeymsluskrá.FlattenTree()
                     .Where(nn => nn.Text == n.Text)
                     .ToList();
                if (nodes.Count != 0)
                {
                    if (nodes[0].Level != 2)
                    {
                        seriesnode.Checked = false;
                    }
                    m_trwGeymsluskrá.Nodes.Remove(nodes[0]);
                    int i = 0;
                    int iIndex = 0;
                    foreach(DataRow r in m_dtGEYMSLUSKRA.Rows)
                    {
                        if (r["titill"].ToString() == nodes[0].Text)
                        {
                            iIndex = i;
                        }
                        i++;
                    }
                    m_dtGEYMSLUSKRA.Rows[iIndex].Delete();
                    m_dtGEYMSLUSKRA.AcceptChanges();
                   
                   
                }
            }

            if (seriesnode.Checked)
            {
                if(m_trwGogn.SelectedNode.Checked)
                {
                   // //athuga hvort nóðan er kominn
                   //TreeNode[] fNode =   m_trwGeymsluskrá.Nodes.Find(seriesnode.Text, true);
                   // if (fNode.Length > 0)
                   // {

                   // }
                    seriesnode.Nodes.Add(n);
                   
                    subseriesnode = n;
                 
                    seriesnode.Checked = true;
                    skjal.auðkenni_3_1_1 =  n.Parent.Parent.Index.ToString("000") + "-" + n.Parent.Index.ToString("000") + "-" + n.Index.ToString("000");
                    n.Tag = skjal.auðkenni_3_1_1;
                    if(m_strTegund == "Skráarkerfi")
                    {
                        skjal.tímabil_3_1_3 = skjal.getTimabil(n.Text, m_strAuðkenni.Replace(".", "_"));
                    }
                    if(m_strTegund == "Málakerfi")
                    {
                        skjal.tímabil_3_1_3 = skjal.getTimabilMalKerfi(m_strAuðkenni.Replace(".", "_"), n.Text);
                    }
      
                    skjal.titill_3_1_2 = n.Text;
                    skjal.upplýsingastig_3_1_4 = "Skjalaflokkur";
                    skjal.athugasemdir_skjalavarðar_3_7_1 = n.Text;
                    fyllaGeymsluskraTöflu("Skjalaflokkur", n.Text);
                    fyllaDU();
                }
             
                m_trwGeymsluskrá.ExpandAll();
               
                return;
            }
            if (m_trwGogn.SelectedNode.Checked)
            {
                m_trwGeymsluskrá.Nodes[0].Nodes.Add(n);
                n.Checked = true;
                seriesnode = n;
                skjal.auðkenni_3_1_1 = n.Parent.Index.ToString("000") + "-" + n.Index.ToString("000");
                n.Tag = skjal.auðkenni_3_1_1;
                m_trwGeymsluskrá.ExpandAll();
                if (m_strTegund == "Skráarkerfi")
                {
                    skjal.tímabil_3_1_3 = skjal.getTimabil(n.Text, m_strAuðkenni.Replace(".", "_"));
                }
                  
            
                skjal.titill_3_1_2 = n.Text;
                skjal.upplýsingastig_3_1_4 = "Yfirskjalaflokkur";
                skjal.athugasemdir_skjalavarðar_3_7_1 = n.Text;
                fyllaGeymsluskraTöflu("Yfirskjalaflokkur", n.Text);
                fyllaDU();
            }

          
        }
        private void fyllaDU()
        {
            m_tboTimablil.Text = skjal.tímabil_3_1_3;
            m_tboTitill.Text = skjal.titill_3_1_2;
            m_tboUpplýsingastig.Text = skjal.upplýsingastig_3_1_4;
            m_tboAthSkjal.Text = skjal.athugasemdir_skjalavarðar_3_7_1;
        }
        private void m_trwGogn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
           m_trwGogn.SelectedNode = m_trwGogn.GetNodeAt(e.X, e.Y);
        }

        private void m_trwGeymsluskrá_AfterSelect(object sender, TreeViewEventArgs e)
        {
            m_tboTitill.Text = e.Node.Text;
            temp.hreinsaHlut();
            foreach(DataRow r in m_dtGEYMSLUSKRA.Rows)
            {
                if (r["auðkenni"].ToString() == e.Node.Tag.ToString())
                {
                    m_tboAuðkenni.Text = r["auðkenni"].ToString();
                    temp.auðkenni_3_1_1 = m_tboAuðkenni.Text;
                    m_tboAfhendingaarNr.Text = r["afharnr"].ToString();
                    temp.afhendingar_tilfærslur_3_2_4 = m_tboAfhendingaarNr.Text;
                    m_tboSkilyrðiAðgengi.Text = r["aðgengi"].ToString();
                    temp.skilyrði_aðgengi_3_4_1 = m_tboSkilyrðiAðgengi.Text;
                    m_tboYfirilInnihald.Text = r["innihald"].ToString();
                    temp.yfirlit_innihald_3_3_1 = m_tboYfirilInnihald.Text;
                    m_tboTimablil.Text = r["timabil"].ToString();
                    temp.tímabil_3_1_3 = m_tboTimablil.Text;
                    m_tboUpplýsingastig.Text = r["upplysingastig"].ToString();
                    m_tboAthSkjal.Text = r["athskjal"].ToString();
                    temp.athugasemdir_skjalavarðar_3_7_1 = m_tboAthSkjal.Text;
                }
            }
          
        }

        private void m_btnDUStadfesta_Click(object sender, EventArgs e)
        {
            //uppfæra node ef breytt ásamt töflu
            string strTitill = m_trwGeymsluskrá.SelectedNode.Text;
            string strAuðkenni = m_trwGeymsluskrá.SelectedNode.Tag.ToString();

            var nodes = m_trwGeymsluskrá.FlattenTree()
                     .Where(nn => nn.Tag.ToString() == strAuðkenni)
                     .ToList();
            if (nodes.Count != 0)
            {
                nodes[0].Text = m_tboTitill.Text;
                string strExp = "auðkenni='" + strAuðkenni + "'";
                DataRow[] fRow = m_dtGEYMSLUSKRA.Select(strExp);
                if(fRow.Length != 0)
                {
                    fRow[0]["titill"] = m_tboTitill.Text;
                }
            }
            //búa til örk
            cSkjalaskra ork = temp;
            temp.upplýsingastig_3_1_4 = "Örk";
            temp.titill_3_1_2 = "Örk 1";


            if (nodes[0].Parent.Parent != null && nodes[0].Text != "Örk 1")
            {
                TreeNode orkNode = new TreeNode("Örk 1");
                temp.auðkenni_3_1_1 = nodes[0].Parent.Parent.Index.ToString("000") + "-" + nodes[0].Parent.Index.ToString("000") + "-" + nodes[0].Index.ToString("000") + "-001";
               
                orkNode.Tag = temp.auðkenni_3_1_1;
                
                nodes[0].Nodes.Add(orkNode);
                nodes[0].Expand();
                if(m_strTegund == "Skráarkerfi")
                {
                    temp.yfirlit_innihald_3_3_1 = string.Format("Skjalaflokkur {0} inniheldur {1} rafræn skjöl.", nodes[0].Text, temp.getSkjalFjoldi(temp.athugasemdir_skjalavarðar_3_7_1, m_strAuðkenni));
                }
                if(m_strTegund == "Málakerfi")
                {
                    //ef málakerfið er GoPro
                    temp.yfirlit_innihald_3_3_1 = string.Format("Skjalaflokkur {0} inniheldur {1} rafræn skjöl.", nodes[0].Text, temp.getSkjalFjoldiMalkerfi(temp.athugasemdir_skjalavarðar_3_7_1, m_strAuðkenni));
                }
               
                skjal = temp;
                fyllaGeymsluskraTöflu("Örk", "asdfaf");
            }
           
            nodes[0].BackColor = Color.LightGreen;

        }

        private void m_btnVista_Click(object sender, EventArgs e)
        {
            skjal.hreinsaHlut();
            m_dtGEYMSLUSKRA.DefaultView.Sort = "auðkenni asc";
            DataTable dtSort = m_dtGEYMSLUSKRA.DefaultView.ToTable();
            int iTilheyrir = fond.tilheyrir_skráningu;
            skjal.eydaGeymsluskra(m_strAuðkenni);
           //  fond.tilheyrir_skráningu

            foreach (DataRow r in dtSort.Rows)
            {
                if (r["upplysingastig"].ToString() == "Yfirskjalaflokkur")
                {
                    skjal.tilheyrir_skráningu = fond.ID; 
                }
                else
                {
                    skjal.tilheyrir_skráningu = iTilheyrir;
                }
               
                skjal.auðkenni_3_1_1 = fond.auðkenni_3_1_1 + "-" + r["auðkenni"].ToString();
                skjal.titill_3_1_2 = r["titill"].ToString();
                skjal.upplýsingastig_3_1_4 = r["upplysingastig"].ToString();
                skjal.tímabil_3_1_3 = r["timabil"].ToString();
                skjal.yfirlit_innihald_3_3_1 = r["innihald"].ToString();
                skjal.afhendingar_tilfærslur_3_2_4 = fond.afhendingar_tilfærslur_3_2_4;

                skjal.skjalamyndari = fond.skjalamyndari;
                skjal.vörslustofnun = fond.vörslustofnun;
                skjal.heiti_skjalamyndara_3_2_1 = fond.heiti_skjalamyndara_3_2_1;
                skjal.tungumál_3_4_3 = fond.tungumál_3_4_3;
                skjal.hver_skráði = virkurnotandi.nafn;
                skjal.athugasemdir_skjalavarðar_3_7_1 = r["athskjal"].ToString();

                if(r["upplysingastig"].ToString() != "Skjalasafn")
                 {
                    skjal.vista();
                    skjal.getSkraning(skjal.auðkenni_3_1_1);
                    iTilheyrir = skjal.ID;
                    skjal.hreinsaHlut();
                }
                
            }

            MessageBox.Show("Búið að vista geymsluskrá");
        }

        private void m_trwGeymsluskrá_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Level == 1)
            {
                seriesnode = e.Node;
            }
            
        }

        private void m_btnEyda_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("viltu eyða geymsluskrá", "eyða geymsluskrá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                skjal.eydaGeymsluskra(m_strAuðkenni);
                fyllaSkjalaSkra();
            }
        }

        private void m_btnAddSubSerites_Click(object sender, EventArgs e)
        {
            string strTitill = m_trwGeymsluskrá.SelectedNode.Text;
            TreeNode subNode = new TreeNode(strTitill);
           
            var nodes = m_trwGeymsluskrá.FlattenTree()
                     .Where(nn => nn.Text == strTitill)
                     .ToList();
            subNode.Tag = nodes[0].Parent.Index.ToString("000") + "-" + nodes[0].Index.ToString("000") + "-000"; 
            m_trwGeymsluskrá.SelectedNode.Nodes.Add(subNode);
            m_trwGeymsluskrá.ExpandAll();
            skjal.auðkenni_3_1_1 = subNode.Tag.ToString();
            //temp.auðkenni_3_1_1 = nodes[0].Parent.Parent.Index.ToString("000") + "-" + nodes[0].Parent.Index.ToString("000") + "-" + nodes[0].Index.ToString("000") + "-001";

            //orkNode.Tag = temp.auðkenni_3_1_1;

            //nodes[0].Nodes.Add(orkNode);
            //nodes[0].Expand();
            //if (m_strTegund == "Skráarkerfi")
            //{
            //    temp.yfirlit_innihald_3_3_1 = string.Format("Skjalaflokkur {0} inniheldur {1} rafræn skjöl.", nodes[0].Text, temp.getSkjalFjoldi(temp.athugasemdir_skjalavarðar_3_7_1, m_strAuðkenni));
            //}

            //skjal = temp;
            fyllaGeymsluskraTöflu("Skjalaflokkur", "asdfaf");
        }

        private void m_btnAddFile_Click(object sender, EventArgs e)
        {

        }

        private void m_btnBuaTilAuto_Click(object sender, EventArgs e)
        {
            if(m_tboSeriesLevel.Text == string.Empty)
            {
                MessageBox.Show("Vinamlegast hakkið við fyrsta yfirskjalaflokk");
                return;
            }
            TreeNode tRoot = m_trwGeymsluskrá.Nodes[0];
            m_trwGeymsluskrá.Nodes.Clear();
            m_trwGeymsluskrá.Nodes.Insert(0, tRoot);

            m_trwGogn.SelectedNode.Checked = false;
            //tRoot.Nodes.Remove(tRoot.Nodes[0]);
           
            buaTilSkraAuto();
     
            // buaTilLaufAuto();
            int iSeries = 0;
            string[] strSeries = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Þ", "Æ", "Ö", "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1", "K1", "L1", "M1", "N1", "O1", "P1", "R1", "S1", "T1", "U1", "V1", "W1", "X1", "Y1", "Z1", "Þ1", "Æ1", "Ö1", "A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2", "I2", "J2", "K2", "L2", "M2", "N2", "O2", "P2", "R2", "S2", "T2", "U2", "V2", "W2", "X2", "Y2", "Z2", "Þ2", "Æ2", "Ö2" };
            m_lblToDo.Text = "Bæti við örkum skref 2 af 2";
            m_pgbGeymsluSkra.Value = 0;
            m_pgbGeymsluSkra.Step = 1;
            m_pgbGeymsluSkra.Maximum = m_trwGeymsluskrá.Nodes[0].Nodes.Count;

            foreach (TreeNode tSub in m_trwGeymsluskrá.Nodes[0].Nodes)
            {
                string strYfirMappa = string.Empty;
                string strBokSeries = string.Empty;
                if (m_chbBokstafir.Checked)
                {
                    strYfirMappa = tSub.Text;
                    strBokSeries = strSeries[iSeries];
                    tSub.Text = strSeries[iSeries] + "-" + tSub.Text;
                    string strExp = "auðkenni= '" + tSub.Tag.ToString() + "'";
                    DataRow[] fRow = m_dtGEYMSLUSKRA.Select(strExp);
                    if (fRow.Length != 0)
                    {
                        fRow[0]["titill"] = tSub.Text;
                    }
                }

                bool bEkkiNeittUndir = false;
                if(tSub.Nodes.Count == 0)
                {
                    //engar möppur undir series - búa til undirrskjalabla 
                    TreeNode sNode = new TreeNode(tSub.Text);
                    sNode.Tag = tSub.Tag + "-1"; //vantar að rifja upp hvurnig teng
                    tSub.Nodes.Add(sNode);
                    bEkkiNeittUndir = true;
                    //
                  //  buaTilOrkAuto(sNode, strYfirMappa);
                }
                if(tSub.Nodes.Count == 1)
                {
                    tSub.Nodes[0].Text = tSub.Text;
                    bEkkiNeittUndir = true;
                }

                if (tSub.Level == 1)
                {
                    int iSubSeries = 0;
                    m_pgbGeymsluSkra.Maximum = tSub.Nodes.Count;
                    foreach (TreeNode n in tSub.Nodes)
                    {
                        string strMappa = "...\\" + strYfirMappa + "\\" + n.Text;
                        if (m_chbBokstafir.Checked && !bEkkiNeittUndir)
                        {
                            string strBokSubSeries = strBokSeries + strSeries[iSubSeries];
                            n.Text = strBokSubSeries + "-" + n.Text;
                            string strExp = "auðkenni= '" + n.Tag.ToString() + "'";
                            DataRow[] fRow = m_dtGEYMSLUSKRA.Select(strExp);
                            if (fRow.Length != 0)
                            {
                                fRow[0]["titill"] = n.Text;
                            }

                        }
                        buaTilOrkAuto(n, strMappa);
                        m_pgbGeymsluSkra.PerformStep();
                        m_lblStatus.Text = string.Format("{0}/{1}", m_pgbGeymsluSkra.Value, m_pgbGeymsluSkra.Maximum);
                        Application.DoEvents();
                        iSubSeries++;
                    }

                }
                iSeries++;
            }

            Application.DoEvents();

        }

        private void m_btnBuaTilArkir_Click(object sender, EventArgs e)
        {
        
            
        }
        private void buaTilSkraAuto()
        {
            m_lblToDo.Text = "Bý til skjalaskrá skref 1 af 2";
            m_pgbGeymsluSkra.Value = 0;
            m_pgbGeymsluSkra.Step = 1;


            switch (m_iSeriesLevel)
            {
                case 0:
                    m_pgbGeymsluSkra.Maximum = m_trwGogn.Nodes.Count;
                    foreach (TreeNode tn in m_trwGogn.Nodes)
                    {
                        if (tn.Level == 0)
                        {
                            m_trwGogn.SelectedNode = tn;
                            // seriesnode = tn;
                            tn.Checked = true;
                            m_pgbGeymsluSkra.Value = 0;
                            m_pgbGeymsluSkra.Step = 1;
                            m_pgbGeymsluSkra.Maximum =  tn.Nodes.Count;
                            foreach (TreeNode tn1 in tn.Nodes)
                            {
                                //  m_trwGogn.SelectedNode = tn1;
                                tn1.Checked = true;
                                m_pgbGeymsluSkra.PerformStep();
                                m_lblStatus.Text = string.Format("{0}/{1}", m_pgbGeymsluSkra.Value, m_pgbGeymsluSkra.Maximum);
                                Application.DoEvents();

                            }
                            seriesnode.Checked = false;

                            m_pgbGeymsluSkra.PerformStep();
                            m_lblStatus.Text = string.Format("{0}/{1}", m_pgbGeymsluSkra.Value, m_pgbGeymsluSkra.Maximum);
                            Application.DoEvents();

                        }
                    }
            
                    break;
                case 1:
                    m_pgbGeymsluSkra.Maximum = m_trwGogn.Nodes[0].Nodes.Count;
                    foreach (TreeNode tn in m_trwGogn.Nodes[0].Nodes)
                    {
                        if (tn.Level == 1)
                        {
                            m_trwGogn.SelectedNode = tn;
                            // seriesnode = tn;
                            tn.Checked = true;

                            foreach (TreeNode tn1 in tn.Nodes)
                            {
                                //  m_trwGogn.SelectedNode = tn1;
                                tn1.Checked = true;

                            }

                            seriesnode.Checked = false;
                            m_pgbGeymsluSkra.PerformStep();
                            m_lblStatus.Text = string.Format("{0}/{1}", m_pgbGeymsluSkra.Value, m_pgbGeymsluSkra.Maximum);
                            Application.DoEvents();

                        }
                    }
                    break;
                case 2:
                    m_pgbGeymsluSkra.Maximum = m_trwGogn.Nodes[0].Nodes[0].Nodes.Count;
                    foreach (TreeNode tn in m_trwGogn.Nodes[0].Nodes[0].Nodes)
                    {
                        if (tn.Level == 2)
                        {
                            m_trwGogn.SelectedNode = tn;
                            // seriesnode = tn;
                            tn.Checked = true;

                            foreach (TreeNode tn1 in tn.Nodes)
                            {
                                //  m_trwGogn.SelectedNode = tn1;
                                tn1.Checked = true;

                            }

                            seriesnode.Checked = false;
                            m_pgbGeymsluSkra.PerformStep();
                            m_lblStatus.Text = string.Format("{0}/{1}", m_pgbGeymsluSkra.Value, m_pgbGeymsluSkra.Maximum);
                            Application.DoEvents();

                        }
                    }
                    break;
                case 3:
                    m_pgbGeymsluSkra.Maximum = m_trwGogn.Nodes[0].Nodes[0].Nodes[0].Nodes.Count;
                    foreach (TreeNode tn in m_trwGogn.Nodes[0].Nodes[0].Nodes[0].Nodes)
                    {
                        if (tn.Level == 3)
                        {
                            m_trwGogn.SelectedNode = tn;
                            // seriesnode = tn;
                            tn.Checked = true;

                            foreach (TreeNode tn1 in tn.Nodes)
                            {
                                //  m_trwGogn.SelectedNode = tn1;
                                tn1.Checked = true;

                            }

                            seriesnode.Checked = false;
                            m_pgbGeymsluSkra.PerformStep();
                            m_lblStatus.Text = string.Format("{0}/{1}", m_pgbGeymsluSkra.Value, m_pgbGeymsluSkra.Maximum);
                            Application.DoEvents();

                        }
                    }
                    break;
                case 4:
                    m_pgbGeymsluSkra.Maximum = m_trwGogn.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes.Count;
                    foreach (TreeNode tn in m_trwGogn.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes)
                    {
                        if (tn.Level == 4)
                        {
                            m_trwGogn.SelectedNode = tn;
                            // seriesnode = tn;
                            tn.Checked = true;

                            foreach (TreeNode tn1 in tn.Nodes)
                            {
                                //  m_trwGogn.SelectedNode = tn1;
                                tn1.Checked = true;

                            }

                            seriesnode.Checked = false;
                            m_pgbGeymsluSkra.PerformStep();
                            m_lblStatus.Text = string.Format("{0}/{1}", m_pgbGeymsluSkra.Value, m_pgbGeymsluSkra.Maximum);
                            Application.DoEvents();

                        }
                    }
                    break;
                case 5:
                    m_pgbGeymsluSkra.Maximum = m_trwGogn.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes.Count;
                    foreach (TreeNode tn in m_trwGogn.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes)
                    {
                        if (tn.Level == 5)
                        {
                            m_trwGogn.SelectedNode = tn;
                            // seriesnode = tn;
                            tn.Checked = true;

                            foreach (TreeNode tn1 in tn.Nodes)
                            {
                                //  m_trwGogn.SelectedNode = tn1;
                                tn1.Checked = true;

                            }

                            seriesnode.Checked = false;
                            m_pgbGeymsluSkra.PerformStep();
                            m_lblStatus.Text = string.Format("{0}/{1}", m_pgbGeymsluSkra.Value, m_pgbGeymsluSkra.Maximum);
                            Application.DoEvents();

                        }
                    }
                    break;
                case 6:
                    m_pgbGeymsluSkra.Maximum = m_trwGogn.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes.Count;
                    foreach (TreeNode tn in m_trwGogn.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes)
                    {
                        if (tn.Level == 6)
                        {
                            m_trwGogn.SelectedNode = tn;
                            // seriesnode = tn;
                            tn.Checked = true;

                            foreach (TreeNode tn1 in tn.Nodes)
                            {
                                //  m_trwGogn.SelectedNode = tn1;
                                tn1.Checked = true;

                            }

                            seriesnode.Checked = false;
                            m_pgbGeymsluSkra.PerformStep();
                            m_lblStatus.Text = string.Format("{0}/{1}", m_pgbGeymsluSkra.Value, m_pgbGeymsluSkra.Maximum);
                            Application.DoEvents();

                        }
                    }
                    break;
                case 7:
                    m_pgbGeymsluSkra.Maximum = m_trwGogn.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes.Count;
                    foreach (TreeNode tn in m_trwGogn.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes)
                    {
                        if (tn.Level == 7)
                        {
                            m_trwGogn.SelectedNode = tn;
                            // seriesnode = tn;
                            tn.Checked = true;

                            foreach (TreeNode tn1 in tn.Nodes)
                            {
                                //  m_trwGogn.SelectedNode = tn1;
                                tn1.Checked = true;

                            }

                            seriesnode.Checked = false;
                            m_pgbGeymsluSkra.PerformStep();
                            m_lblStatus.Text = string.Format("{0}/{1}", m_pgbGeymsluSkra.Value, m_pgbGeymsluSkra.Maximum);
                            Application.DoEvents();

                        }
                    }
                    break;
                default:
                    break;
            }


           
        }
       
        private void buaTilLaufAuto()
        {
            switch (m_iSeriesLevel)
            {
                case 0:
                    foreach (TreeNode tSub in m_trwGeymsluskrá.Nodes)
                    {

                        if (tSub.Level == 0)
                        {
                            foreach (TreeNode n in tSub.Nodes)
                            {
                                buaTilOrkAuto(n, "");
                                Application.DoEvents();
                            }

                        }
                    }

                    break;
                case 1:
                    foreach (TreeNode tSub in m_trwGeymsluskrá.Nodes[0].Nodes)
                    {

                        if (tSub.Level == 1)
                        {
                            foreach (TreeNode n in tSub.Nodes)
                            {
                                buaTilOrkAuto(n, "");
                                Application.DoEvents();
                            }

                        }
                    }
                    break;
                case 2:
                    foreach (TreeNode tSub in m_trwGeymsluskrá.Nodes[0].Nodes[0].Nodes)
                    {

                        if (tSub.Level == 2)
                        {
                            foreach (TreeNode n in tSub.Nodes)
                            {
                                buaTilOrkAuto(n,"");
                                Application.DoEvents();
                            }

                        }
                    }
                    break;
                case 3:
                    foreach (TreeNode tSub in m_trwGeymsluskrá.Nodes[0].Nodes[0].Nodes)
                    {

                        if (tSub.Level == 2)
                        {
                            foreach (TreeNode n in tSub.Nodes)
                            {
                                buaTilOrkAuto(n,"");
                                Application.DoEvents();
                            }

                        }
                    }
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
      
        private void buaTilOrkAuto(TreeNode nodus, string strMappa)
        {
            cSkjalaskra ork = temp;
            temp.upplýsingastig_3_1_4 = "Örk";
            temp.titill_3_1_2 = "Örk 1";


            if (nodus.Text != "Örk 1")
            {
                TreeNode orkNode = new TreeNode("Örk 1");
                temp.auðkenni_3_1_1 = nodus.Parent.Parent.Index.ToString("000") + "-" + nodus.Parent.Index.ToString("000") + "-" + nodus.Index.ToString("000") + "-001";

                orkNode.Tag = temp.auðkenni_3_1_1;

                nodus.Nodes.Add(orkNode);
                nodus.Expand();
                if (m_strTegund == "Málakerfi")
                {
                    temp.tímabil_3_1_3 = skjal.getTimabilMalKerfi(m_strAuðkenni.Replace(".", "_"), nodus.Text);
                }
                if (m_strTegund == "Skráarkerfi")
                {
                    string[] strSplit = nodus.Text.Split("-");
                    temp.yfirlit_innihald_3_3_1 = string.Format("Skjalaflokkur {0} inniheldur {1} rafræn skjöl.", nodus.Text, temp.getSkjalFjoldi(strSplit[1], m_strAuðkenni));
                    temp.tímabil_3_1_3 = skjal.getTimabil(strSplit[1], m_strGagnagrunnur);
                    // temp.athugasemdir_skjalavarðar_3_7_1 = string.Format("Gögn í þessum skjalaflokki eru geymd í möppunni {0},", strMappa);
                    temp.athugasemdir_skjalavarðar_3_7_1 = string.Format(strMappa);
                }
                if (m_strTegund == "Málakerfi")
                {
                    //ef málakerfið er GoPro
                    try
                    {
                        string strListiSkjol = temp.getSkjalListiiMalkerfi(nodus.Text, m_strAuðkenni);
                        string[] strSplit = strListiSkjol.Split("~");
                        strListiSkjol = string.Empty;
                        foreach (string str in strSplit)
                        {
                            strListiSkjol += str + Environment.NewLine;
                        }
                        temp.yfirlit_innihald_3_3_1 = string.Format("Skjalaflokkur {0} inniheldur {1} rafræn skjöl.{2}{2}{3}", nodus.Text, temp.getSkjalFjoldiMalkerfi(nodus.Text, m_strAuðkenni), Environment.NewLine, strListiSkjol);
                        temp.yfirlit_innihald_3_3_1 = string.Format("Skjalaflokkur {0} inniheldur {1} rafræn skjöl.", nodus.Text, temp.getSkjalFjoldiMalkerfi(nodus.Text, m_strAuðkenni));

                    }
                    catch (Exception x)
                    {

                        temp.yfirlit_innihald_3_3_1 = string.Format("Skjalaflokkur {0} inniheldur {1} rafræn skjöl.", nodus.Text, temp.getSkjalFjoldiMalkerfi(nodus.Text, m_strAuðkenni));
                    }
                }

                skjal = temp;
                fyllaGeymsluskraTöflu("Örk", "asdfaf");
            }

            nodus.BackColor = Color.LightGreen;
        }

        private void m_trwGogn_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

      
    }
    public static class SOExtension
    {
        public static IEnumerable<TreeNode> FlattenTree(this TreeView tv)
        {
            return FlattenTree(tv.Nodes);
        }

        public static IEnumerable<TreeNode> FlattenTree(this TreeNodeCollection coll)
        {
            return coll.Cast<TreeNode>()
                        .Concat(coll.Cast<TreeNode>()
                                    .SelectMany(x => FlattenTree(x.Nodes)));
        }
    }
}
