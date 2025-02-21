using cClassOAIS;
using cClassVHS;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using OAIS_ADMIN;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Windows.Forms.Design;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace MHR_LEIT
{
    public partial class Form1 : Form
    {
        DataTable m_dtDIPSkra = new DataTable();
        DataTable m_dtDIPMal = new DataTable();
        DataTable m_dtDIPGrunn = new DataTable();
        DataSet m_dsDIPmal = new DataSet();

        bool bAdmin = false;
        bool bAfrit = false;

        DataTable m_dtLeitarNidurstodur = new DataTable();

        cNotandi virkurNotandi = new cNotandi();
        cDIPKarfa karfa = new cDIPKarfa();
        cLanthegar lanþegi = new cLanthegar();
        string m_strSlodDIP = string.Empty;
        string m_strRootInsert = string.Empty;

        public Form1()
        {
            InitializeComponent();

            m_comFjoldiFaerslnaLeit.Text = "100";
            m_pnlNotandi.Dock = DockStyle.Fill;
            m_pnlNotandi.BringToFront();
     
            this.Text = "MHR - LEIT";
            this.WindowState = FormWindowState.Maximized;
            DataTable dt = virkurNotandi.getGrunnar();
            foreach (DataRow r in dt.Rows)
            {
                if (r["Database (DB_OAIS%)"].ToString() == "db_oais_admin")
                {
                    bAdmin = true;
                }
                if (r["Database (DB_OAIS%)"].ToString() == "db_oais_admin_afrit")
                {
                    bAfrit = true;

                }
            }
            if (!bAdmin && !bAfrit)
            {
                frmUppsetning frmUpp = new frmUppsetning();
                frmUpp.ShowDialog();
                bAfrit = true;
                virkurNotandi.m_bAfrit = true;
            }
            if (bAdmin && bAfrit)
            {
                m_chbAfrit.Visible = true;
            }
            if (bAdmin && !bAfrit)
            {
                m_btnKeyrAfritInn.Visible = true;
            }
            //skáarkerfi dip-tafla
            m_dtDIPSkra.Columns.Add("skjalID");
            m_dtDIPSkra.Columns.Add("titill");
            m_dtDIPSkra.Columns.Add("vorsluutgafa");
            m_dtDIPSkra.Columns.Add("heitiVorslu");
            m_dtDIPSkra.Columns.Add("md5");
            m_dtDIPSkra.Columns.Add("slod");

            //gagnagrunnar dip-tafla
            m_dtDIPGrunn.Columns.Add("Heiti");
            m_dtDIPGrunn.Columns.Add("vorsluutgafa");
            m_dtDIPGrunn.Columns.Add("leitarskilyrdi");
            m_dtDIPGrunn.Columns.Add("sql");
            m_dtDIPGrunn.Columns.Add("slod");
            m_dtDIPGrunn.Columns.Add("heitivorslu");

            //málakerfi dip tafla
            m_dtDIPMal.Columns.Add("karfa");
            m_dtDIPMal.Columns.Add("md5");
            m_dtDIPMal.Columns.Add("heitiVorslu");
            m_dtDIPMal.Columns.Add("maltitill");
            m_dtDIPMal.Columns.Add("titill");
            m_dtDIPMal.Columns.Add("vorsluutgafa");
            m_dtDIPMal.Columns.Add("documentid");



            //fyllaV0rslusstofnanir();
            //fyllaSkjalamyndara();
            //fyllaLanthega();
            //fyllaDIPLista();
            //fyllaGagnaGrunna();



        }
        private void fyllaVorsluUtgafur()
        {
            cSkjalaskra utgafur = new cSkjalaskra();
            utgafur.m_bAfrit = virkurNotandi.m_bAfrit;
            DataTable dt = utgafur.getVörsluútgáfurGU();

            m_dgvVorsluUtgafur.AutoGenerateColumns = false;
            m_dgvVorsluUtgafur.DataSource = formatTable(dt);
        }

        private DataTable formatTable(DataTable dt)
        {
            DataTable dtCloned = dt.Clone();
            dtCloned.Columns["staerd"].DataType = typeof(string);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }
            //gera stærð skiljanlega

            foreach (DataRow r in dtCloned.Rows)
            {
                long bla = (long)Convert.ToDouble(r["staerd"]);
                r["staerd"] = FormatBytes(bla);
            }
            return dtCloned;
        }
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.1;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }
        private void fyllaGagnaGrunna()
        {
            cMIdlun midlun = new cMIdlun();
            midlun.m_bAfrit = virkurNotandi.m_bAfrit;
            DataTable dt = midlun.getGagnagrunna();
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.NewRow();
                r["orginal_heiti"] = "Veldu Gagnagrunn";
                dt.Rows.InsertAt(r, 0);
                //  id, vorsluutgafa, heiti_gagnagrunns, orgina_heiti
                m_comGagnagrunnar.ValueMember = "heiti_gagnagrunns";
                m_comGagnagrunnar.DisplayMember = "orginal_heiti";
                m_comGagnagrunnar.DataSource = dt;
            }
            else
            {
                m_comGagnagrunnar.Visible = false;
                m_lblGagangrunnar.Visible = false;
            }

        }
        private void fyllaExtensions(string strVarsla, string strSkjalm, string strUtgafa)
        {
            cMIdlun midlun = new cMIdlun();
            midlun.m_bAfrit = virkurNotandi.m_bAfrit;
            DataTable dt = midlun.getExtensions(strVarsla, strSkjalm, strUtgafa);
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.NewRow();
                r["extension"] = "Veldu skráaendingu";
                dt.Rows.InsertAt(r, 0);
                //  id, vorsluutgafa, heiti_gagnagrunns, orgina_heiti
                m_comExtensions.ValueMember = "extension";
                m_comExtensions.DisplayMember = "extension";
                m_comExtensions.DataSource = dt;
            }
            else
            {
                //m_comGagnagrunnar.Visible = false;
                //m_lblGagangrunnar.Visible = false;
            }
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

        private void fyllaV0rslusstofnanir()
        {
            cVorslustofnun varsla = new cVorslustofnun();
            varsla.m_bAfrit = virkurNotandi.m_bAfrit;
            DataTable dt = varsla.getAllVOrslustofnanir();
            DataRow r = dt.NewRow();
            r["varsla_heiti"] = "Veldu vörslustofnun";
            dt.Rows.InsertAt(r, 0);
            m_comVorslustofnun.ValueMember = "vorslustofnun";
            m_comVorslustofnun.DisplayMember = "varsla_heiti";
            m_comVorslustofnun.DataSource = dt;
        }
        private void fyllaSkjalamyndara(string strVorslustofnun)
        {
            cSkjalamyndari skjalam = new cSkjalamyndari();
            skjalam.m_bAfrit = virkurNotandi.m_bAfrit;
            DataTable dt = new DataTable();
            if (strVorslustofnun != string.Empty)
            {
                dt = skjalam.getSkjalamyndaralista(strVorslustofnun);
            }
            else
            {
                dt = skjalam.getSkjalamyndaralista();
            }

            DataRow r = dt.NewRow();
            r["5_1_2_opinbert_heiti"] = "Veldu skjalamyndara";
            dt.Rows.InsertAt(r, 0);
            m_comSkjalamyndari.ValueMember = "5_1_6_auðkenni";
            m_comSkjalamyndari.DisplayMember = "5_1_2_opinbert_heiti";
            m_comSkjalamyndari.DataSource = dt;

        }
        private void fyllaVörsluutgafur(string strSkjalam)
        {
            cVorsluutgafur utgafur = new cVorsluutgafur();
            utgafur.m_bAfrit = virkurNotandi.m_bAfrit;
            DataTable dt = new DataTable();
            if (strSkjalam != string.Empty)
            {
                dt = utgafur.getVorsluUtgafurLista(strSkjalam);
            }
            else
            {
                dt = utgafur.getVorsluUtgafurLista();
            }

            DataRow r = dt.NewRow();
            r["utgafa_titill"] = "Veldu vörsluútgáfu";
            dt.Rows.InsertAt(r, 0);
            m_comVorsluUtgafur.ValueMember = "vorsluutgafa";
            m_comVorsluUtgafur.DisplayMember = "utgafa_titill";
            m_comVorsluUtgafur.DataSource = dt;

        }
        private void m_btnLeita_Click(object sender, EventArgs e)
        {
            leita(true);
        }

        private void leita(bool bLeit)
        {
            cMIdlun midlun = new cMIdlun();
            midlun.m_bAfrit = bAfrit;
            midlun.leitarord = m_tboLeitOrd.Text;


            if (m_comExtensions.SelectedIndex != 0)
            {
                midlun.extension = m_comExtensions.SelectedValue.ToString();
            }

            if (m_comVorslustofnun.SelectedIndex != 0)
            {
                midlun.vorslustofnun_audkenni = m_comVorslustofnun.SelectedValue.ToString();
            }
            if (m_comSkjalamyndari.SelectedIndex != 0)
            {
                midlun.skjalamyndari_audkenni = m_comSkjalamyndari.SelectedValue.ToString();
            }
            if (m_comVorsluUtgafur.SelectedIndex != 0)
            {
                midlun.vorsluutgafa = m_comVorsluUtgafur.SelectedValue.ToString();
            }
            if (m_dtpStart.Checked)
            {
                midlun.Upphafsdags = m_dtpStart.Value.ToString();
            }
            if (m_dtEnd.Checked)
            {
                midlun.Endadags = m_dtEnd.Value.ToString();
            }
            //Bæta hér við öllum orðmyndum
            string strLeitarORd = m_tboLeitOrd.Text;
            if (m_chbOrdmyndir.Checked)
            {
                string[] strSplit = strLeitarORd.Split(" ");
                //leita uppi orðmyndir í BIN
                strLeitarORd = string.Empty;
                foreach (string str in strSplit)
                {
                    string strOrdmyndir = midlun.ordmyndir(str);
                    strLeitarORd += strOrdmyndir + " ";
                }

                if (strLeitarORd == " ")
                {
                    strLeitarORd = string.Empty;
                }
                if (strLeitarORd == string.Empty)
                {
                    strLeitarORd = m_tboLeitOrd.Text;
                }
            }
            int iPageFjoldi = Convert.ToInt32(m_comFjoldiFaerslnaLeit.Text);
            //   mid
            int iFjoldi = midlun.leitCount(strLeitarORd);
            decimal dFjoldi = Convert.ToDecimal((double)iFjoldi / (double)iPageFjoldi);
            int iPages = Convert.ToInt32(Math.Ceiling(dFjoldi));
            //fylla pagecombo
            if (bLeit)
            {
                m_comPages.Items.Clear();
                for (int i = 0; i < iPages; i++)
                {
                    m_comPages.Items.Add(i + 1);
                }
                if (iFjoldi != 0)
                {
                    m_comPages.SelectedIndex = 0;
                    m_pnlPageing.Visible = true;
                }
                else
                {
                    m_comPages.Text = "0";

                }
                if (iPages == 1)
                {
                    m_pnlPageing.Visible = false;
                }

            }


            m_lblSidaAf.Text = string.Format("af {0}", iPages);
            if (bLeit)
            {
                m_dtLeitarNidurstodur = midlun.leit(strLeitarORd, iPageFjoldi.ToString(), "0");
            }
            else
            {
                int Ipage = Convert.ToInt32(m_comPages.SelectedItem) - 1;
                iPages = Ipage * iPageFjoldi;
                m_dtLeitarNidurstodur = midlun.leit(strLeitarORd, iPageFjoldi.ToString(), iPages.ToString());
            }
            m_dgvLeit.AutoGenerateColumns = false;
            m_dgvLeit.DataSource = m_dtLeitarNidurstodur;
            m_lblLeitarnidurstodur.Visible = true;
            m_lblLeitarnidurstodur.Text = string.Format("Það fundust {0} leitarniðurstöður útfrá leitarorðunum {1}", iFjoldi, m_tboLeitOrd.Text);
        }

        private void m_tboLeitOrd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                leita(true);
            }
        }
        // setjaMaliIpontun(strTitill, strMalTitill, strGagnagrunnur, strHeitiVorslu, strMalID, strValid, strVorsluStofnunID, strSkjalmyndaraID, strVarslaID);
        private void setjaMaliIpontun(string strSkjalTitill, string strMalTitill, string strGagnaGrunnur, string strHeitiVorslu, string StrMalID, string strValid, string strVorsluStofnunID, string strSkjalmyndaraID, string strVarslaID)
        {
            //  if (strTegund == "Málakerfi")
            {


                DataTable dtPant = new DataTable();

                dtPant.Columns.Add("documentid"); //fæ documentid út úr viðmóti ekki grunni
                dtPant.Columns.Add("malid");
                dtPant.Columns.Add("gagnagrunnur");
                dtPant.Columns.Add("slod");
                dtPant.Columns.Add("sqlMal");

                dtPant.Columns.Add("titill");
                dtPant.Columns.Add("maltitill");
                dtPant.Columns.Add("heitivorslu");
                dtPant.Columns.Add("vorsluutgafa");


                cMIdlun midlun = new cMIdlun();
                midlun.m_bAfrit = virkurNotandi.m_bAfrit;
                DataTable dtFyrirSpurnir = midlun.getGagnagrunnaFyrirSpurnir(strGagnaGrunnur);

                string strExp = "nafn='mal_malID'"; //bæti við um málið hér:
                DataRow[] fRow = dtFyrirSpurnir.Select(strExp);
                string strSQL = fRow[0]["fyrirspurn"].ToString();
                strSQL = strSQL.Replace("{malID}", StrMalID);
                DataTable dtSkjol = midlun.keyraFyrirspurn(strSQL, strGagnaGrunnur);
                if (dtPant.Columns.Count == 7)
                {
                    foreach (DataColumn col in dtSkjol.Columns)
                    {
                        dtPant.Columns.Add(col.ColumnName);

                    }
                }
                strExp = "nafn='mal_malID'";
                fRow = dtFyrirSpurnir.Select(strExp);
                strSQL = fRow[0]["fyrirspurn"].ToString();

                strSQL = strSQL.Replace("{malID}", StrMalID);



                if (!m_dsDIPmal.Tables.Contains(strGagnaGrunnur))
                {
                    DataRow r = dtPant.NewRow();
                    r["documentid"] = strValid;
                    r["malid"] = StrMalID;
                    r["gagnagrunnur"] = strGagnaGrunnur;

                    r["sqlMal"] = strSQL;

                    r["titill"] = strSkjalTitill;
                    r["maltitill"] = strMalTitill;
                    r["heitivorslu"] = strHeitiVorslu;
                    r["vorsluutgafa"] = strVarslaID;
                    int iID = Convert.ToInt32(strValid);
                    double dColl = iID / 10000;
                    if (iID == 1)
                    {
                        dColl = 1;
                    }
                    else
                    {
                        dColl = dColl + 1;
                    }
                    cVHS_drives drive = new cVHS_drives();
                    drive.m_bAfrit = virkurNotandi.m_bAfrit;
                    string strDRif = drive.driveVirkkComputers();

                    string strSlod = string.Empty;

                    if (virkurNotandi.m_bAfrit)
                    {
                        strSlod = drive.driveVirkkComputers() + "\\" + strVarslaID + "\\Documents\\\\docCollection" + dColl.ToString() + "\\" + strValid;
                    }
                    else
                    {
                        strSlod = drive.driveVirkkComputers() + "\\" + strVorsluStofnunID + "\\" + strSkjalmyndaraID + "\\" + strVarslaID + "\\Documents\\\\docCollection" + dColl.ToString() + "\\" + strValid;
                    }

                    r["slod"] = strSlod;




                    //int j = 6;
                    //foreach (DataColumn col in dtSkjol.Columns)
                    //{
                    //    if (j - 2 < dtSkjol.Columns.Count)
                    //    {
                    //        // string strBLA = dtSkjol.Rows[0][j - 3].ToString();
                    //        r[j] = dtSkjol.Rows[0][j - 6];
                    //        j++;
                    //    }

                    //}

                    dtPant.Rows.Add(r);
                    dtPant.TableName = strGagnaGrunnur;
                    m_dsDIPmal.Tables.Add(dtPant);

                    //DataRow rMal = m_dtPontunMal.NewRow();
                    //rMal["vorsluutgafa"] = m_strGagnagrunnur.Replace("_", ".");
                    //rMal["Skrar"] = m_strIdValinn;
                    //rMal["maltitill"] = strMalTitill;
                    //rMal["heitivorslu"] = m_strHeitiVorslu;
                    //rMal["titill"] = strSkjalTitill;

                    //m_dtPontunMal.Rows.Add(rMal);
                    //m_dtPontunMal.AcceptChanges();
                    //dtPant.TableName = m_strGagnagrunnur;
                    // m_dsMal.Tables.Add(dtPant);
                }
                else
                {
                    DataRow r = m_dsDIPmal.Tables[strGagnaGrunnur].NewRow();
                    r["documentid"] = strValid;
                    r["malid"] = StrMalID;
                    r["gagnagrunnur"] = strGagnaGrunnur;
                    r["vorsluutgafa"] = strVarslaID;

                    r["sqlMal"] = strSQL;

                    int iID = Convert.ToInt32(strValid); //þarf að breyta og setja fast lykilheiti
                    double dColl = iID / 10000;
                    if (iID == 1)
                    {
                        dColl = 1;
                    }
                    else
                    {
                        dColl = dColl + 1;
                    }
                    cVHS_drives drive = new cVHS_drives();
                    drive.m_bAfrit = virkurNotandi.m_bAfrit;
                    string strSlod = string.Empty;

                    if (virkurNotandi.m_bAfrit)
                    {
                        strSlod = drive.driveVirkkComputers() + "\\" + strVarslaID + "\\Documents\\\\docCollection" + dColl.ToString() + "\\" + strValid;
                    }
                    else
                    {
                        strSlod = drive.driveVirkkComputers() + "\\" + strVorsluStofnunID + "\\" + strSkjalmyndaraID + "\\" + strVarslaID + "\\Documents\\\\docCollection" + dColl.ToString() + "\\" + strValid;
                    }
                    r["slod"] = strSlod;
                    r["maltitill"] = strMalTitill;
                    r["heitivorslu"] = strHeitiVorslu;
                    r["titill"] = strSkjalTitill;



                    m_dsDIPmal.Tables[strGagnaGrunnur].Rows.Add(r);

                    //DataRow rMal = m_dtDIPMal.NewRow();
                    //rMal["vorsluutgafa"] = strGagnaGrunnur.Replace("_", ".");
                    //rMal["Skrar"] = strValid;
                    //rMal["maltitill"] = strMalTitill;
                    //rMal["heitivorslu"] = strHeitiVorslu;
                    //rMal["titill"] = strSkjalTitill;

                    //m_dtDIPMal.Rows.Add(rMal);
                    //m_dtDIPMal.AcceptChanges();
                    //   dtPant.TableName = m_strGagnagrunnur;
                    // m_dsDIPmal.Tables.Add(dtPant);
                }



            }
        }
        private void m_dgvLeit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var senderGrid = (DataGridView)sender;
                string strGagnagrunnur = senderGrid.Rows[e.RowIndex].Cells["colGagnaGrunnur"].Value.ToString();
                string strTegund = senderGrid.Rows[e.RowIndex].Cells["colTegund_gagnagrunns"].Value.ToString();
                string strValid = senderGrid.Rows[e.RowIndex].Cells["colDocID"].Value.ToString();

                string strInnhald = senderGrid.Rows[e.RowIndex].Cells["colInnhaldSkjals"].Value.ToString();
                string strVorslustofnun = senderGrid.Rows[e.RowIndex].Cells["colVorslustsofnun"].Value.ToString();
                string strTitill = senderGrid.Rows[e.RowIndex].Cells["colDocTitel"].Value.ToString();
                string strHeitiVorslu = senderGrid.Rows[e.RowIndex].Cells["coltitillvorsluUtgafu"].Value.ToString();
                string strSkjalamyndari = senderGrid.Rows[e.RowIndex].Cells["colSkjalamyndari"].Value.ToString();
                string strSkjalID = senderGrid.Rows[e.RowIndex].Cells["colDocID"].Value.ToString();
                string strVarslaID = senderGrid.Rows[e.RowIndex].Cells["colDocVarslaID"].Value.ToString();
                string strVorsluStofnunID = senderGrid.Rows[e.RowIndex].Cells["colVarslaStofnunID"].Value.ToString();
                string strSkjalmyndaraID = senderGrid.Rows[e.RowIndex].Cells["colSkjalMyndID"].Value.ToString();
                string strMalID = senderGrid.Rows[e.RowIndex].Cells["colDocMalID"].Value.ToString();
                string strMalTitill = senderGrid.Rows[e.RowIndex].Cells["colMal"].Value.ToString();



                DataTable table = (DataTable)m_dgvLeit.DataSource;
                DataRow row = table.NewRow();
                row = ((DataRowView)m_dgvLeit.Rows[e.RowIndex].DataBoundItem).Row;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    //pantanir
                    if (senderGrid.Columns["colDocPanta"].Index == e.ColumnIndex)
                    {
                        if (strTegund == "Skráarkerfi")
                        {
                            string strExp = "skjalID = '" + strSkjalID + "' AND vorsluutgafa='" + strVarslaID + "'";

                            DataRow[] fRow = m_dtDIPSkra.Select(strExp);
                            if (fRow.Length == 0)
                            {
                                DataRow pRow = m_dtDIPSkra.NewRow();
                                pRow["skjalID"] = strSkjalID;
                                pRow["titill"] = strTitill;
                                pRow["vorsluutgafa"] = strVarslaID;
                                pRow["heitiVorslu"] = strHeitiVorslu;
                                pRow["md5"] = string.Empty;
                                pRow["slod"] = string.Empty;
                                m_dtDIPSkra.Rows.Add(pRow);

                                senderGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                                var btn = (DataGridViewButtonCell)senderGrid.Rows[e.RowIndex].Cells["colDocPanta"];
                                btn.UseColumnTextForButtonValue = false;
                                btn.Value = "Afpanta";
                            }
                            else
                            {
                                fRow[0].Delete();
                                m_dtDIPSkra.AcceptChanges();
                                var btn = (DataGridViewButtonCell)senderGrid.Rows[e.RowIndex].Cells["colDocPanta"];
                                btn.UseColumnTextForButtonValue = true;
                                senderGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                                //btn.Value = "Afpanta";

                            }


                        }
                        if (strTegund == "Málakerfi")
                        {
                            //athuga hvort skjalið sé komið í pöntun
                            string strExp = "documentid= '" + strValid + "'";

                            var btn = (DataGridViewButtonCell)senderGrid.Rows[e.RowIndex].Cells["colDocPanta"];
                            btn.UseColumnTextForButtonValue = false;
                            if (m_dsDIPmal.Tables.Contains(strGagnagrunnur))
                            {
                                DataRow[] fRow = m_dsDIPmal.Tables[strGagnagrunnur].Select(strExp);

                                if (fRow.Length == 0)
                                {
                                    setjaMaliIpontun(strTitill, strMalTitill, strGagnagrunnur, strHeitiVorslu, strMalID, strValid, strVorsluStofnunID, strSkjalmyndaraID, strVarslaID);

                                    senderGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                                    btn.Value = "Afpanta";

                                }
                                else
                                {
                                    senderGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                                    btn.Value = "Panta";
                                    fRow[0].Delete();
                                    m_dsDIPmal.Tables[strGagnagrunnur].AcceptChanges();

                                }
                            }
                            else
                            {
                                setjaMaliIpontun(strTitill, strMalTitill, strGagnagrunnur, strHeitiVorslu, strMalID, strValid, strVorsluStofnunID, strSkjalmyndaraID, strVarslaID);
                                senderGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                                btn.Value = "Afpanta";
                            }
                            Application.DoEvents();

                        }


                    }
                    //innhald
                    if (senderGrid.Columns["colDocInnihald"].Index == e.ColumnIndex)
                    {
                        frmInnhald innhald = new frmInnhald(strInnhald, strVorslustofnun, strTitill, strSkjalamyndari, strHeitiVorslu);
                        innhald.ShowDialog();
                        //útfæra pöntun
                    }
                    if (senderGrid.Columns["colDocFrum"].Index == e.ColumnIndex)
                    {
                        var p = new Process();
                        string strSlod = string.Empty;
                        cVHS_drives drive = new cVHS_drives();
                        drive.m_bAfrit = virkurNotandi.m_bAfrit;
                        string strDRif = drive.driveVirkkComputers();

                        if (virkurNotandi.m_bAfrit)
                        {
                            strSlod = strDRif + "\\" + strVarslaID.Replace("AVID", "FRUM") + "\\Documents"; //docCollection1//4//1.tif";
                        }
                        else
                        {
                            strSlod = strDRif + "\\" + strVorsluStofnunID + "\\" + strSkjalmyndaraID + "\\" + strVarslaID.Replace("AVID", "FRUM") + "\\Documents"; //docCollection1//4//1.tif";
                        }

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
                        strSlod = strSlod + "\\docCollection" + dColl.ToString() + "\\" + strValid;
                        if (Directory.Exists(strSlod))
                        {
                            string[] strFiles = Directory.GetFiles(strSlod);
                            if (strFiles.Length == 1)
                            {
                                strSlod = strFiles[0];

                                p.StartInfo = new ProcessStartInfo(strSlod)
                                {
                                    UseShellExecute = true
                                };
                                p.Start();

                            }
                            else
                            {
                                MessageBox.Show("Frumeintak ekki til");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Frumeintak ekki til");
                        }


                    }
                    if (senderGrid.Columns["colDocOpnaAfrit"].Index == e.ColumnIndex)
                    {
                        var p = new Process();
                        string strSlod = string.Empty;
                        cVHS_drives drive = new cVHS_drives();
                        drive.m_bAfrit = virkurNotandi.m_bAfrit;
                        string strDRif = drive.driveVirkkComputers();
                        if (virkurNotandi.m_bAfrit)
                        {
                            strSlod = strDRif + "\\" + strVarslaID + "\\Documents"; //docCollection1//4//1.tif";
                        }
                        else
                        {
                            strSlod = strDRif + "\\" + strVorsluStofnunID + "\\" + strSkjalmyndaraID + "\\" + strVarslaID + "\\Documents"; //docCollection1//4//1.tif";
                        }

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
                        strSlod = strSlod + "\\docCollection" + dColl.ToString() + "\\" + strValid;

                        string[] strFiles = Directory.GetFiles(strSlod);
                        strSlod = strFiles[0];

                        p.StartInfo = new ProcessStartInfo(strSlod)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                }
                else
                {
                    if (strTegund == "Skráarkerfi")
                    {
                        frmSkraarkerfi skrakerfi = new frmSkraarkerfi(strGagnagrunnur, strValid, row, m_tboLeitOrd.Text, m_dtDIPSkra, m_dtDIPMal, m_dtDIPGrunn, virkurNotandi, m_dsDIPmal);
                        skrakerfi.ShowDialog();

                        m_dtDIPSkra = skrakerfi.m_dtValid;

                        //foreach (DataRow r in skrakerfi.m_dtValid.Rows)
                        //{
                        //    string strEXp = string.Format("skjalID='{0}' and vorsluutgafa='{1}'", r["skjalID"], r["vorsluutgafa"]);
                        //    DataRow[] frow = m_dtDIPSkra.Select(strEXp);
                        //    if (frow.Length == 0)
                        //    {
                        //        m_dtDIPSkra.ImportRow(r);
                        //    }
                        //}
                    }
                    if (strTegund == "Málakerfi")
                    {
                        DataTable dtMal = m_dsDIPmal.Tables[strGagnagrunnur];
                        frmMalakerfi frmMala = new frmMalakerfi(strGagnagrunnur, row, m_dtDIPGrunn, m_dtDIPSkra, m_dtDIPMal, virkurNotandi, m_dsDIPmal);
                        frmMala.ShowDialog();
                    }

                }



                m_dgvDIPList.AutoGenerateColumns = false;
                m_dgvDIPList.DataSource = m_dtDIPSkra;

                m_dgvDIPmal.AutoGenerateColumns = false;
                DataTable dtMalAllt = new DataTable();

                for (int i = 0; i < m_dsDIPmal.Tables.Count; i++)
                {
                    if (i == 0)
                        dtMalAllt = m_dsDIPmal.Tables[i].Copy();
                    else
                        dtMalAllt.Merge(m_dsDIPmal.Tables[i]);
                }
                //foreach (DataTable tabel in m_dsDIPmal.Tables)
                //{
                //    foreach(DataRow r in table.Rows)
                //    {
                //        dtMalAllt.ImportRow(r);
                //        dtMalAllt.AcceptChanges();
                //    }
                //}

                m_dgvDIPmal.DataSource = dtMalAllt; // m_dsDIPmal.Tables[strGagnagrunnur]; // m_dtDIPMal;
                //foreach (DataGridViewColumn col in m_dgvDIPmal.Columns)
                //{
                //    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //}

                synaPantanirFjoldi();

            }
        }

        private void m_btnHreinsa_Click(object sender, EventArgs e)
        {
            m_tboLeitOrd.Text = string.Empty;
            m_lblLeitarnidurstodur.Text = string.Empty;
            fyllaSkjalamyndara("");
            fyllaV0rslusstofnanir();
            fyllaVörsluutgafur("");
            fyllaExtensions("", "", "");


            m_dtpStart.Value = DateTime.Now;
            m_dtEnd.Value = DateTime.Now;
            m_dtEnd.Checked = false;
            m_dtpStart.Checked = false;
            m_dtLeitarNidurstodur.Rows.Clear();
            if (m_comGagnagrunnar.Visible)
            {
                m_comGagnagrunnar.SelectedIndex = 0;
            }



        }

        private void m_btnInnskra_Click(object sender, EventArgs e)
        {
            innskra();
        }
        private void innskra()
        {
            m_lblVillaInnSkraning.Visible = false;
            string strNotandi = m_tboNoterndaNafn.Text;
            string strLykilorð = m_tboLykilOrd.Text;

            if (m_chbAfrit.Visible)
            {
                if (m_chbAfrit.Checked)
                {
                    bAfrit = true;
                }
                else
                {
                    bAfrit = false;
                }
            }


            virkurNotandi.m_bAfrit = bAfrit;
            if (!bAdmin && bAfrit)
            {
                virkurNotandi.m_bAfrit = true;
            }
            virkurNotandi.sækjaNotanda(strNotandi, strLykilorð);
            if (virkurNotandi.nafn != null)
            {
                m_tacMain.BringToFront();
                m_tacMain.Dock = DockStyle.Fill;
                if (this.virkurNotandi.hlutverk == "Skjalavörður")
                {
                    m_tacMain.TabPages.Remove(m_tapUmsjon);
                }
                else
                {
                    if (!m_tacMain.Contains(m_tapUmsjon))
                    {
                        m_tacMain.TabPages.Add(m_tapUmsjon);
                    }
                }
                m_tomUtskra.Visible = true;
                this.Text = "Velkominn " + virkurNotandi.nafn;

                this.WindowState = FormWindowState.Maximized;
                karfa.m_bAfrit = virkurNotandi.m_bAfrit;
                lanþegi.m_bAfrit = virkurNotandi.m_bAfrit;
                uscNotendur1.virkurnotandi.m_bAfrit = virkurNotandi.m_bAfrit;
                uscNotendur1.virkurnotandi = virkurNotandi;
                usclanthegar1.virkurnotandi = virkurNotandi;
                uscNotendur1.fyllaNotendaLista();
                usclanthegar1.fyllaLanthega();
                fyllaVörsluutgafur("");
                fyllaV0rslusstofnanir();
                fyllaSkjalamyndara("");
                fyllaLanthega();
                fyllaDIPLista();
                fyllaGagnaGrunna();
                fyllaExtensions("", "", "");


            }
            else
            {
                m_lblVillaInnSkraning.Visible = true;
                m_lblVillaInnSkraning.Text = "Rangt notendanafn eða lykilorð";
            }
        }

        private void m_btnNyrLanthegi_Click(object sender, EventArgs e)
        {
            frmLanthegi lanthegi = new frmLanthegi(virkurNotandi);
            lanthegi.ShowDialog();
            fyllaLanthega();
            m_comLanthegar.SelectedIndex = m_comLanthegar.Items.Count - 1;


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
            DataTable dtMal = (DataTable)m_dgvDIPmal.DataSource;
            m_prbPontun.Maximum = m_dtDIPGrunn.Rows.Count + dtMal.Rows.Count + m_dtDIPSkra.Rows.Count;
            m_prbPontun.Step = 1;
            m_prbPontun.Value = 0;
            m_lblPontunstatus.Text = string.Format("{0}/{1}", m_prbPontun.Value, m_prbPontun.Maximum);
            m_prbPontun.Visible = true;
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

                    //  string strDIProot = divo.Name + "\\DIP";
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
                    if (!Directory.Exists(strDIPfolder) && !m_rdbFrum.Checked)
                    {
                        Directory.CreateDirectory(strDIPfolder);
                    }
                    FileInfo fifo = new FileInfo(strSkjal[0]);
                    string[] strSplit = strTitill.Split(".");

                    string strEndaSkjal = strDIPfolder + "\\" + strSplit[0] + fifo.Extension;
                  

                    //********************Búa til PDF**************************
                    if(m_chbPDF.Checked)
                    {
                        m_lblPontunstatus.Text += "Bý til pdf - tekur tíma";
                        string strEndPDF = strEndaSkjal;
                        strEndPDF = m_strSlodDIP.Replace("\\\\", "\\");
                        strEndPDF = strEndPDF + "\\" + utgafur.utgafa_titill;
                        if (!Directory.Exists(strEndPDF))
                        {
                            Directory.CreateDirectory(strEndPDF);
                        }
                        strEndPDF = strEndPDF + "\\PDF";
                        if (!Directory.Exists(strEndPDF))
                        {
                            Directory.CreateDirectory(strEndPDF);
                        }

                        Application.DoEvents();
                        string strPDF =  createPDF(strSkjal[0], strEndPDF + "\\" + r["titill"].ToString());
                        // createPDF(strSlod, strEndaSkjal + "\\" + senderGrid.Rows[e.RowIndex].Cells["colTitill"].Value.ToString());

                      
                        // DataRow pdfRow = dtExcell.NewRow();
                       strPDF = strPDF.Replace(strDIProot, "") ;
                        //strSplit = r["titill"].ToString().Split(".");
                        //if(strSplit.Length != 0)
                        //{
                        //    strPDF = "\\" + strPDF +"\\" + strSplit[0] + ".pdf";
                        //}
                        r["slod"] = "\\" + strPDF;
                        dtExcell.ImportRow(r);
                    }

                    //*****************flytja tiff******************************
                    if (!m_rdbFrum.Checked)
                    {
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

                }
                if (bFrum && (m_rdbFrumTif.Checked || m_rdbFrum.Checked))
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
                        karfa_item.heitiVorslu = r["heitiVorslu"].ToString();
                        karfa_item.vorsluutgafa = r["vorsluutgafa"].ToString();
                        karfa_item.md5 = strMD5;
                        karfa_item.slod = strEndaSkjal;
                        karfa_item.vista();
                    }

                }

                m_prbPontun.PerformStep();
                m_lblPontunstatus.Text = string.Format("{0}/{1}", m_prbPontun.Value, m_prbPontun.Maximum);
                m_prbPontun.Visible = true;
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
                    DataRow rr = dtExcellMal.NewRow();
                    File.Copy(strSkraSlod, strDestDoc, true);
                    //********************Búa til PDF**************************
                    if(m_chbPDF.Checked)
                    {
                        m_lblPontunstatus.Text += "Bý til pdf - tekur tíma";
                       // m_prbPontun.Style = ProgressBarStyle.Marquee;    
                        createPDF(strSkraSlod, strDestDoc);
                        Application.DoEvents();

                        DataRow rpr = dtExcellMal.NewRow();
                        string strPDF = strDestDoc.Replace(strDIProot, "");
                        rpr["Slóð"] = strPDF.Replace(".tif", ".pdf");
                        rpr["Mál"] = "Mál_" + iMal.ToString("00");
                        rpr["Skrá"] = strDocTitill;

                        //  rr["md5"] = strMD5;
                        rpr["maltitill"] = r["maltitill"].ToString(); ;

                        dtExcellMal.Rows.Add(rpr);

                    }



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
                    
                    m_prbPontun.PerformStep();
                    m_lblPontunstatus.Text = string.Format("{0}/{1}", m_prbPontun.Value, m_prbPontun.Maximum);
                    m_prbPontun.Visible = true;
                    m_lblPontunstatus.Visible = true;
                    Application.DoEvents();
                }


            }

            //gaggnagrunnur
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
                m_prbPontun.PerformStep();
                m_lblPontunstatus.Text = string.Format("{0}/{1}", m_prbPontun.Value, m_prbPontun.Maximum);
                m_prbPontun.Visible = true;
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
            m_grbTegundSkjala.Visible = false;

            MessageBox.Show("DIP tilbúið");
            int Fjoldi = m_dtDIPSkra.Rows.Count + m_dtDIPGrunn.Rows.Count + m_dtDIPMal.Rows.Count;
            m_tapAfgreidsla.Text = string.Format("Afgreiðsla: {0} skrár óafgreiddar", Fjoldi);
            m_prbPontun.Visible = false;
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

        private string createPDF(string strTiff, string strPDF)
        {
            string strRet = string.Empty;
            try
            {
                cMIdlun midlun = new cMIdlun();
                midlun.m_bAfrit = virkurNotandi.m_bAfrit;
                strRet =  midlun.ocrCreatePDF(strTiff, strPDF);
                return strRet;
            }
            catch (Exception x)
            {
                return x.ToString();
                //throw;
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
                            workSheet.Hyperlinks.Add(workSheet.Cells[i + 2, j + 1], ".." + strBLA, System.Type.Missing, "Sharifsoft", "www.Sharifsoft.com");
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

        private void m_tboNoterndaNafn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                innskra();
            }
        }

        private void m_tboLykilOrd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                innskra();
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

        private void m_trwDIP_AfterSelect(object sender, TreeViewEventArgs e)
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
                splitContainer3.Panel1.BackColor = System.Drawing.Color.LightYellow;
                m_dgvDIPList.AutoGenerateColumns = false;
                m_dgvDIPList.DataSource = m_dtDIPSkra;
                m_tapPontunSkra.Text = string.Format("Skráakerfi ({0})", m_dtDIPSkra.Rows.Count);

                if (m_dsDIPmal.Tables.Count != 0)
                {
                    colBtnFjarlaegja.Visible = true;
                    colMalSkraID.DataPropertyName = "documentid";
                    m_dgvDIPmal.AutoGenerateColumns = false;
                    DataTable dtMalAllt = new DataTable();

                    for (int i = 0; i < m_dsDIPmal.Tables.Count; i++)
                    {
                        if (i == 0)
                            dtMalAllt = m_dsDIPmal.Tables[i].Copy();
                        else
                            dtMalAllt.Merge(m_dsDIPmal.Tables[i]);
                    }
                    m_dgvDIPmal.DataSource = dtMalAllt; // m_dsDIPmal.Tables[0];
                    m_tapPontunMalakerfi.Text = string.Format("Málakerfi ({0})", m_dsDIPmal.Tables[0].Rows.Count);
                    m_tacPontun.SelectedTab = m_tapPontunMalakerfi;
                }
                else
                {
                    m_dgvDIPmal.AutoGenerateColumns = false;
                    m_dgvDIPmal.DataSource = m_dtDIPMal;
                    m_tapPontunMalakerfi.Text = string.Format("Málakerfi ({0})", m_dtDIPMal.Rows.Count);
                }
                colGagnRemove.Visible = true;
                colSkraRemove.Visible = true;
                m_dgvDIPGagnagrunnar.AutoGenerateColumns = false;
                m_dgvDIPGagnagrunnar.DataSource = m_dtDIPGrunn;
                m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtDIPGrunn.Rows.Count);

                return;
            }




            colGagnRemove.Visible = false;
            colSkraRemove.Visible = false;
            colBtnFjarlaegja.Visible = false;
            colMalSkraID.DataPropertyName = "Skrar";
            m_btnKlaraPontun.Enabled = false;
            m_btnOpna.Enabled = true;
            m_btnTæma.Enabled = false;
            splitContainer3.Panel1.BackColor = System.Drawing.Color.LightGreen;
            string strKarfa = e.Node.Tag.ToString();
            cDIPKarfa karfa = new cDIPKarfa();
            karfa.m_bAfrit = virkurNotandi.m_bAfrit;
            karfa.sækjaKörfu(strKarfa);
            m_comLanthegar.SelectedValue = karfa.lanthegi;
            m_tboPontunAth.Text = karfa.athugasemdir;
            m_btnPantAthUpp.Enabled = true;
            m_lblKarfaNr.Visible = true;
            m_lblKarfaNr.Text = string.Format("Pöntun nr: {0}", karfa.karfa);

            cDIPkarfaItem items = new cDIPkarfaItem();
            items.m_bAfrit = virkurNotandi.m_bAfrit;

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

        private void m_btnTæma_Click(object sender, EventArgs e)
        {
            m_dtDIPSkra.Rows.Clear();
            m_dgvDIPList.DataSource = m_dtDIPSkra;
            m_dtDIPGrunn.Rows.Clear();
            m_dgvDIPGagnagrunnar.DataSource = m_dtDIPGrunn;
            m_dtDIPMal.Rows.Clear();
            m_dgvDIPmal.DataSource = m_dtDIPMal;
            m_dsDIPmal.Tables.Clear();

            m_tapPontunSkra.Text = string.Format("Skráakerfi ({0})", m_dtDIPSkra.Rows.Count);
            m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtDIPGrunn.Rows.Count);
            m_tapPontunMalakerfi.Text = string.Format("Málakerfi ({0})", m_dtDIPMal.Rows.Count);
            int iFjoldi = m_dtDIPSkra.Rows.Count + m_dtDIPGrunn.Rows.Count + m_dtDIPMal.Rows.Count;
            m_grbDIP.Text = string.Format("Óafgreitt {0}", iFjoldi);
            m_tapAfgreidsla.Text = string.Format("Afgreiðsla: {0} skrár óafgreiddar", iFjoldi);
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
            iFjoldi = m_dtDIPSkra.Rows.Count + m_dtDIPGrunn.Rows.Count + m_dtDIPMal.Rows.Count;
            m_grbDIP.Text = string.Format("Óafgreitt {0}", iFjoldi);

        }

        private void n_comGagnagrunnar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_comGagnagrunnar.Focused)
            {
                if (m_comGagnagrunnar.SelectedIndex != 0)
                {
                    string strGrunnur = m_comGagnagrunnar.SelectedValue.ToString();
                    string strHeiti = m_comGagnagrunnar.Text.ToString();
                    frmGagnagrunnur frmGagn = new frmGagnagrunnur(strGrunnur, strHeiti, m_dtDIPGrunn, m_dtDIPSkra, m_dtDIPMal, virkurNotandi, m_dsDIPmal, virkurNotandi);
                    frmGagn.ShowDialog();

                    m_dtDIPGrunn = frmGagn.m_dtPantad;

                    m_dgvDIPGagnagrunnar.AutoGenerateColumns = false;
                    m_dgvDIPGagnagrunnar.DataSource = m_dtDIPGrunn;

                    synaPantanirFjoldi();
                    //m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtDIPGrunn.Rows.Count);
                    //int iFjoldi = m_dtDIPGrunn.Rows.Count + m_dtDIPSkra.Rows.Count + m_dtDIPMal.Rows.Count;
                    //m_grbDIP.Text = string.Format("Óafgreitt ({0})", iFjoldi);
                    //m_tapAfgreidsla.Text = string.Format("Afgreiðsla: {0} skrár óafgreiddar", iFjoldi);
                }
            }
        }

        private void m_comVorslustofnun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_comVorslustofnun.Focused)
            {
                if (m_comVorslustofnun.SelectedIndex != 0)
                {
                    string strVarsla = m_comVorslustofnun.SelectedValue.ToString();
                    fyllaSkjalamyndara(strVarsla);
                    fyllaExtensions(strVarsla, "", "");
                    fyllaVörsluutgafur("");
                }
                else
                {
                    fyllaV0rslusstofnanir();
                    fyllaSkjalamyndara("");
                    fyllaVörsluutgafur("");
                    fyllaExtensions("", "", "");
                }
            }

        }

        private void m_comSkjalamyndari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_comSkjalamyndari.Focused)
            {
                if (m_comSkjalamyndari.SelectedIndex != 0)
                {
                    string strSkjalam = m_comSkjalamyndari.SelectedValue.ToString();
                    fyllaVörsluutgafur(strSkjalam);
                    fyllaExtensions("", strSkjalam, "");

                }
                else
                {
                    fyllaV0rslusstofnanir();
                    fyllaSkjalamyndara("");
                    fyllaVörsluutgafur("");
                }
            }

        }

        private void m_btnLagaToflur_Click(object sender, EventArgs e)
        {
            //nota þetta til að bæta við, breyta eða eyða töflum úr miðlunargrunni
            // 1. bæta við extensiondálki í midlunartöflu
            #region 1. bæta við extensiondálki í midlunartöflu
            try
            {
                virkurNotandi.addExtensionDalk();
            }
            catch (Exception x)
            {


            }
            //sækja alla midlunartöfluna

            cMIdlun midlun = new cMIdlun();
            midlun.m_bAfrit = virkurNotandi.m_bAfrit;
            cVHS_drives drive = new cVHS_drives();
            drive.m_bAfrit = virkurNotandi.m_bAfrit;
            string strDRif = drive.driveVirkkComputers();


            DataTable dt = midlun.getMidlunarToflu();
            //rúlla yfir töfluna og finna extensionið
            //SELECT id, vorsluutgafa, documentid, vorslustofnun_audkenni, skjalamyndari_audkenni FROM dt_midlun d;
            foreach (DataRow r in dt.Rows)
            {
                string strID = r["id"].ToString();
                string strVarslaID = r["vorsluutgafa"].ToString();
                string strDocID = r["documentid"].ToString();
                string strVorsluStofnunID = r["vorslustofnun_audkenni"].ToString();
                string strSkjalmyndaraID = r["skjalamyndari_audkenni"].ToString();
                string strSlod = string.Empty;
                //finnaskjalið
                if (virkurNotandi.m_bAfrit)
                {
                    strSlod = strDRif + "\\" + strVarslaID.Replace("AVID", "FRUM") + "\\Documents"; //docCollection1//4//1.tif";
                    if (!Directory.Exists(strSlod))
                    {
                        strSlod = strDRif + "\\" + strVarslaID + "\\Documents";
                    }
                }
                else
                {
                    strSlod = strDRif + "\\" + strVorsluStofnunID + "\\" + strSkjalmyndaraID + "\\" + strVarslaID.Replace("AVID", "FRUM") + "\\Documents"; //docCollection1//4//1.tif";
                    if (!Directory.Exists(strSlod))
                    {
                        strSlod = strDRif + "\\" + strVorsluStofnunID + "\\" + strSkjalmyndaraID + "\\" + strVarslaID + "\\Documents";
                    }
                }

                double dColl = Convert.ToInt32(strDocID) / 10000;
                int iID = Convert.ToInt32(strDocID);
                if (iID == 1)
                {
                    dColl = 1;
                }
                else
                {
                    dColl = dColl + 1;
                }
                if (iID == 10000)
                {
                    dColl = 0;
                    dColl = dColl + 1;
                }

                strSlod = strSlod + "\\docCollection" + dColl.ToString() + "\\" + strDocID;
                if (Directory.Exists(strSlod))
                {
                    string[] strFiles = Directory.GetFiles(strSlod);
                    if (strFiles.Length == 1)
                    {
                        FileInfo fifo = new FileInfo(strFiles[0]);
                        string strExtension = fifo.Extension;
                        midlun.uppfæraExtension(strExtension, strID);
                    }

                }
            }
            #endregion
            // 2. bæta við heiti heitiVorslu í dt_pantanir_karfa_item
            try
            {
                virkurNotandi.addHeitiVarsla();
            }
            catch (Exception x)
            {


            }

            MessageBox.Show("Búið");
        }

        private void m_tomUtskra_Click(object sender, EventArgs e)
        {
            m_pnlNotandi.BringToFront();
            m_pnlNotandi.Dock = DockStyle.Fill;
            m_tboNoterndaNafn.Text = string.Empty;
            m_tboLykilOrd.Text = string.Empty;
            virkurNotandi.hreinsaHlut();
            m_tomUtskra.Visible = false;

        }

        private void m_comVorsluUtgafur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_comVorsluUtgafur.Focused)
            {

                if (m_comVorsluUtgafur.SelectedIndex != 0)
                {
                    //ef valið tékka hvort þetta sé gagnagrunnur (ef svo opna viðmót)
                    cVorsluutgafur utgafur = new cVorsluutgafur();
                    utgafur.m_bAfrit = virkurNotandi.m_bAfrit;

                    string strUtgafa = m_comVorsluUtgafur.SelectedValue.ToString();
                    string strGagnagrunnur = utgafur.erGagnagrunnur(strUtgafa);
                    if (!string.IsNullOrEmpty(strGagnagrunnur))
                    {
                        string strGrunnur = strUtgafa.Replace(".", "_");
                        string strHeiti = strGagnagrunnur;
                        frmGagnagrunnur frmGagn = new frmGagnagrunnur(strGrunnur, strHeiti, m_dtDIPGrunn, m_dtDIPSkra, m_dtDIPMal, virkurNotandi, m_dsDIPmal, virkurNotandi);
                        frmGagn.ShowDialog();

                        m_dtDIPGrunn = frmGagn.m_dtPantad;

                        //foreach (DataRow r in frmGagn.m_dtPantad.Rows)
                        //{
                        //    string strLeitarskilyrði = r["leitarskilyrdi"].ToString().Replace("'", "\"");
                        //    string strEXp = string.Format("vorsluutgafa='{0}' and leitarskilyrdi='{1}'", r["vorsluutgafa"], strLeitarskilyrði, virkurNotandi);
                        //    DataRow[] frow = m_dtDIPGrunn.Select(strEXp);
                        //    if (frow.Length == 0)
                        //    {
                        //        m_dtDIPGrunn.ImportRow(r);
                        //    }
                        //    //    m_dtDIPGrunn.Columns.Add("Heiti");
                        //    //    m_dtDIPGrunn.Columns.Add("vorsluutgafa");
                        //    //    m_dtDIPGrunn.Columns.Add("leitarskilyrði");
                        //    //    m_dtDIPGrunn.Columns.Add("sql");
                        //}
                        m_dgvDIPGagnagrunnar.AutoGenerateColumns = false;
                        m_dgvDIPGagnagrunnar.DataSource = m_dtDIPGrunn;


                        m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtDIPGrunn.Rows.Count);
                        int iFjoldi = m_dtDIPGrunn.Rows.Count + m_dtDIPSkra.Rows.Count + m_dtDIPMal.Rows.Count;
                        m_grbDIP.Text = string.Format("Óafgreitt ({0})", iFjoldi);
                        m_tapAfgreidsla.Text = string.Format("Afgreiðsla: {0} skrár óafgreiddar", iFjoldi);
                    }
                    else
                    {
                        fyllaExtensions("", "", strUtgafa);
                    }

                }
                synaPantanirFjoldi();
            }

        }

        private void m_comPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_comPages.Focused)
            {
                leita(false);
            }

        }

        private void m_btnNaesta_Click(object sender, EventArgs e)
        {
            if (m_comPages.SelectedIndex != m_comPages.Items.Count - 1)
            {
                m_comPages.SelectedIndex = m_comPages.SelectedIndex + 1;
                leita(false);
            }

        }

        private void m_btnFyrri_Click(object sender, EventArgs e)
        {
            if (m_comPages.SelectedIndex != 0)
            {
                m_comPages.SelectedIndex = m_comPages.SelectedIndex - 1;
                leita(false);
            }

        }

        private void m_btnFyrsta_Click(object sender, EventArgs e)
        {
            if (m_comPages.Items.Count != 0)
            {
                m_comPages.SelectedIndex = 0;
                leita(false);
            }

        }

        private void m_btnSidasta_Click(object sender, EventArgs e)
        {
            if (m_comPages.Items.Count != 0)
            {
                m_comPages.SelectedIndex = m_comPages.Items.Count - 1;
                leita(false);
            }
        }

        private void m_comFjoldiFaerslnaLeit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_comFjoldiFaerslnaLeit.Focused)
            {
                leita(true);
            }
        }

        private void m_dgvDIPList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //fjarlægja item í körfu ef ekki er búið að afgreiða

            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colSkraRemove"].Index == e.ColumnIndex)
                {
                    DialogResult result = MessageBox.Show("Viltu fjarlægja þetta skjal?", "Fjarlægja skjal", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        m_dgvDIPList.Rows.Remove(m_dgvDIPList.Rows[e.RowIndex]);
                        m_dtDIPSkra = (DataTable)m_dgvDIPList.DataSource;
                        m_dtDIPSkra.AcceptChanges();
                    }
                    
                    synaPantanirFjoldi();

                }
                if (senderGrid.Columns["colPDF"].Index == e.ColumnIndex)
                {
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
                    //finna endaslóðina
                    string strEndaSkjal = m_strSlodDIP.Replace("\\\\", "\\");
                    strEndaSkjal = strEndaSkjal + "\\" + utgafur.utgafa_titill;
                    if(!Directory.Exists(strEndaSkjal))
                    {
                        Directory.CreateDirectory(strEndaSkjal);
                    }
                    strEndaSkjal = strEndaSkjal + "\\PDF";
                    if (!Directory.Exists(strEndaSkjal))
                    {
                        Directory.CreateDirectory(strEndaSkjal);
                    }
                    m_prbPontun.Visible = true;
                    m_prbPontun.Value = 0;
                    m_prbPontun.Maximum = 1;
                    m_lblPontunstatus.Visible = true;
                    m_lblPontunstatus.Text = "0/1 - bý til PDF getur tekið smá tíma";
                    Application.DoEvents();
                    createPDF(strSlod, strEndaSkjal + "\\" + senderGrid.Rows[e.RowIndex].Cells["colTitill"].Value.ToString());
                    m_prbPontun.PerformStep();
                    m_lblPontunstatus.Text = "1/1";
                    Application.DoEvents();
                    MessageBox.Show("Pdf - komið");
                    m_prbPontun.Visible = false;
                    m_lblPontunstatus.Visible = false;
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
            }
        }

        private void synaPantanirFjoldi()
        {

            m_tapPontunSkra.Text = string.Format("Skráakerfi ({0})", m_dtDIPSkra.Rows.Count);
            int iAllsPant = 0;
            if (m_dsDIPmal.Tables.Count > 0)
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
                iAllsPant = m_dtDIPSkra.Rows.Count + m_dtDIPGrunn.Rows.Count + dtMalAllt.Rows.Count;
            }
            else
            {
                m_tapPontunMalakerfi.Text = string.Format("Málakerfi (0)");
                iAllsPant = m_dtDIPSkra.Rows.Count + m_dtDIPGrunn.Rows.Count;
            }


            m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtDIPGrunn.Rows.Count);



            if (iAllsPant > 0)
            {

                m_grbDIP.Text = string.Format("Óafgreitt ({0})", iAllsPant);
                m_tapAfgreidsla.Text = string.Format("Afgreiðsla: ({0}) skrár óafgreiddar", iAllsPant);
            }
            else
            {
                m_tapAfgreidsla.Text = string.Format("Afgreiðsla");
                m_grbDIP.Text = string.Format("Óafgreitt (0)");
                if (m_trwDIP.Nodes.Count > 0)
                {
                    if (m_trwDIP.Nodes[0].Text == "Óafgreidd pöntun")
                    {
                        m_trwDIP.Nodes.Remove(m_trwDIP.Nodes[0]);
                    }
                }

                splitContainer3.Panel1.BackColor = System.Drawing.Color.LightGreen;
                if (m_trwDIP.Nodes.Count > 0)
                {
                    m_trwDIP.SelectedNode = m_trwDIP.Nodes[0];
                }
                m_btnKlaraPontun.Enabled = false;
                m_btnOpna.Enabled = true;
                m_btnTæma.Enabled = false;
                colGagnRemove.Visible = false;
                colSkraRemove.Visible = false;
                colGagnRemove.Visible = false;
            }


        }

        private void m_dgvDIPmal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colBtnFjarlaegja"].Index == e.ColumnIndex)
                {
                    //ÞARF AÐ fjarlægja líka úr dataseti
                    DialogResult result = MessageBox.Show("Viltu fjarlægja þetta skjal?", "Fjarlægja skjal", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string strGrunnur = m_dgvDIPmal.Rows[e.RowIndex].Cells["colMalGagnGrunnur"].Value.ToString();
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
                    }
                    synaPantanirFjoldi();

                }
                if (senderGrid.Columns["colMalOpna"].Index == e.ColumnIndex)
                {
                    var p = new Process();

                    string strSlod = senderGrid.Rows[e.RowIndex].Cells["colMalVarslaUtgafaID"].Value.ToString();
                    //string[] strSkra = Directory.GetFiles(strSlod);
                    //if(strSkra.Length > 0) 
                    //{
                    //    strSlod = strSkra[0].ToString();
                    //}


                    p.StartInfo = new ProcessStartInfo(strSlod)
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
                if (senderGrid.Columns["colMalPDF"].Index == e.ColumnIndex)
                {
                   
                    m_prbPontun.Visible = true;
                    m_prbPontun.Value = 0;
                    m_prbPontun.Maximum = 1;
                    m_lblPontunstatus.Visible = true;
                    m_lblPontunstatus.Text = "0/1 - bý til PDF getur tekið smá tíma";
                    Application.DoEvents();
                    string strSlod = senderGrid.Rows[e.RowIndex].Cells["colMalVarslaUtgafaID"].Value.ToString();
                    createPDF(strSlod, strSlod);
                    m_prbPontun.PerformStep();
                    m_lblPontunstatus.Text = "1/1";
                    Application.DoEvents();
                    MessageBox.Show("Pdf - komið");
                    m_prbPontun.Visible = false;
                    m_lblPontunstatus.Visible = false;
                }
            }
            
          
        }

        private void m_tacMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_tacMain.SelectedTab == m_tapAfgreidsla)
            {


                //finna út hvort til sé óafgreidd pöntun
                fyllaDIPLista();
                //EF TIL SÉ ÓAFGREIDD PÖNTUN VELJA HANA
                int iFjoldi = 0;
                if (m_dsDIPmal.Tables.Count != 0)
                {
                    DataTable dtMalAllt = new DataTable();
                    m_grbTegundSkjala.Enabled = true;
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
                //ef skrár >0 allar gerðir ef  mál>0 bjóða upp á pdf
                int iFjoldiSkjal = m_dtDIPSkra.Rows.Count + m_dsDIPmal.Tables.Count;
                if (iFjoldiSkjal != 0)
                {
                    m_grbTegundSkjala.Visible = true;
                    m_rdbFrum.Enabled = true;
                    m_rdbFrumTif.Enabled = true;
                    if (m_dtDIPSkra.Rows.Count == 0)
                    {
                        m_rdbFrum.Enabled = false;
                        m_rdbFrumTif.Enabled = false;
                        m_rdbTiff.Checked = true;
                    }
                    else
                    {
                        m_rdbFrumTif.Checked = true;
                    }
                }
                else
                {
                    m_grbTegundSkjala.Visible = false;
                }
                if (iFjoldi != 0)
                {
                    splitContainer3.Panel1.BackColor = System.Drawing.Color.LightYellow;

                    if (m_trwDIP.Nodes.Count > 0)
                    {
                        // TreeNode n = new TreeNode("Ópantað");
                        if (m_trwDIP.Nodes[0].Text != "Óafgreidd pöntun")
                        {
                            m_trwDIP.Nodes.Insert(0, "Óafgreidd pöntun");
                        }
                    }
                    else
                    {
                        m_trwDIP.Nodes.Insert(0, "Óafgreidd pöntun");
                    }
                    m_trwDIP.SelectedNode = m_trwDIP.Nodes[0];

                }
                else
                {
                    if (m_trwDIP.Nodes.Count != 0)
                    {

                        if (m_trwDIP.Nodes[0].Text == "Óafgreidd pöntun")
                        {
                            m_trwDIP.Nodes.Remove(m_trwDIP.Nodes[0]);
                        }
                        splitContainer3.Panel1.BackColor = System.Drawing.Color.White;
                        m_grbTegundSkjala.Visible = false;
                        m_trwDIP.SelectedNode = m_trwDIP.Nodes[0];
                    }

                }
                synaPantanirFjoldi();
            }
        }

        private void m_tacUmsjon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_tacUmsjon.SelectedTab == m_tapLysigogn)
            {
                fyllaVorsluUtgafur();
            }

        }

        private void m_dgvVorsluUtgafur_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void m_dgvVorsluUtgafur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["comBtnVörslustofnun"].Index == e.ColumnIndex)
                {
                    string strVorslustofnID = m_dgvVorsluUtgafur.Rows[e.RowIndex].Cells["colUtgafaVorsluAudkenni"].Value.ToString();
                    frmVorslustofnun frmVorslu = new frmVorslustofnun(strVorslustofnID, virkurNotandi);
                    frmVorslu.ShowDialog();
                }

                if (senderGrid.Columns["comBtnSkjalamyndari"].Index == e.ColumnIndex)
                {
                    string strSkjalamyndari = m_dgvVorsluUtgafur.Rows[e.RowIndex].Cells["colUtgafaSkjalamAudkenni"].Value.ToString();
                    cSkjalamyndari skjalamyndari = new cSkjalamyndari();
                    skjalamyndari.m_bAfrit = virkurNotandi.m_bAfrit;
                    skjalamyndari.getSkjalamyndaraByAuðkenni(strSkjalamyndari);
                    frmSkjalamyndari frmSkjalm = new frmSkjalamyndari(skjalamyndari, virkurNotandi);
                    frmSkjalm.ShowDialog();
                }
                if (senderGrid.Columns["colBtnGeymsluskra"].Index == e.ColumnIndex)
                {
                    //string strAuðkenni, string strSlod,string strTegund, cNotandi not, string strVarsla
                    string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colUtgafurAuðkenni"].Value.ToString();
                    string strVorslustofnID = m_dgvVorsluUtgafur.Rows[e.RowIndex].Cells["colUtgafaVorsluAudkenni"].Value.ToString();
                    //string strSlod = senderGrid.Rows[e.RowIndex].Cells["colVarslaSlod"].Value.ToString();
                    string strTegund = senderGrid.Rows[e.RowIndex].Cells["colTegund"].Value.ToString();
                    //string strVarsla = senderGrid.Rows[e.RowIndex].Cells["colVorsluID"].Value.ToString();

                    frmGeymsluskra frmgeymsla = new frmGeymsluskra(strAuðkenni, "asdf", strTegund, virkurNotandi, strVorslustofnID);
                    frmgeymsla.ShowDialog();
                }
            }


        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void m_pnlNotandi_Paint(object sender, PaintEventArgs e)
        {

        }

        private void m_dgvDIPGagnagrunnar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colGagnRemove"].Index == e.ColumnIndex)
                {
                    DialogResult result = MessageBox.Show("Viltu fjarlægja þetta skjal?", "Fjarlægja skjal", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        m_dgvDIPGagnagrunnar.Rows.Remove(m_dgvDIPGagnagrunnar.Rows[e.RowIndex]);
                        m_dtDIPGrunn = (DataTable)m_dgvDIPGagnagrunnar.DataSource;
                        m_dtDIPGrunn.AcceptChanges();
                    }
                    synaPantanirFjoldi();

                }
                if (senderGrid.Columns["colGagnOpna"].Index == e.ColumnIndex)
                {
                    string strGagnagrunnur = senderGrid.Rows[e.RowIndex].Cells["colGagnHeiti"].Value.ToString();
                    string strVarsla = senderGrid.Rows[e.RowIndex].Cells["colGagnHeitivorslu"].Value.ToString();
                    string strLeit = senderGrid.Rows[e.RowIndex].Cells["colLeitskilyrdi"].Value.ToString();
                    string strSQL = senderGrid.Rows[e.RowIndex].Cells["colGagnSQL"].Value.ToString();
                    frmGagnagrunnSkoda skoda = new frmGagnagrunnSkoda(strSQL, virkurNotandi, strGagnagrunnur, strLeit, strGagnagrunnur, strVarsla);
                    skoda.ShowDialog();
                }
            }
        }

        private void fyllaImportLista(string strSlod)
        {
            m_strRootInsert = strSlod;


            string strUtgafur = m_strRootInsert + "\\Vörsluútgáfur\\";
            string[] strMöppur = new string[0];
            if (Directory.Exists(strUtgafur))
            {
                strMöppur = Directory.GetDirectories(strUtgafur);
            }
            else
            {
                MessageBox.Show("Engar vörsluútgáfur í þessari möppur");
                return;
            }

            DataTable dtUtgafur = new DataTable();
            dtUtgafur.Columns.Clear();
            dtUtgafur.Rows.Clear();
            dtUtgafur.Columns.Add("heiti_varsla");
            dtUtgafur.Columns.Add("audkenni");
            dtUtgafur.Columns.Add("taka");
            //3. tékka hvort AIP sé komið áður
            cVorsluutgafur varsla = new cVorsluutgafur();
            varsla.m_bAfrit = virkurNotandi.m_bAfrit;
            DataTable dt = varsla.getVorsluUtgafurLista();

            foreach (string str in strMöppur)
            {
                DataRow r = dtUtgafur.NewRow();
                DirectoryInfo difo = new DirectoryInfo(str);
                r["heiti_varsla"] = difo.Name;
                string[] strAudkenni = Directory.GetDirectories(difo.FullName);
                string strVarsla = string.Empty;
                foreach (string strAud in strAudkenni)
                {
                    difo = new DirectoryInfo(strAud);

                    if (difo.Name.StartsWith("AVID"))
                    {
                        strVarsla = difo.Name;
                    }

                }
                r["audkenni"] = strVarsla;
                string strExp = "vorsluutgafa = '" + strVarsla + "'";
                DataRow[] fRow = dt.Select(strExp);
                if (fRow.Length == 0)
                {
                    r["taka"] = "true";
                }
                else
                {
                    r["taka"] = "false";
                }
                dtUtgafur.Rows.Add(r);
                dtUtgafur.AcceptChanges();
            }
            m_dgvUtgafur.DataSource = dtUtgafur;


            foreach (DataGridViewRow dr in m_dgvUtgafur.Rows)
            {
                string strExp = "vorsluutgafa = '" + dr.Cells["colAudkenniVarslaMidlun"].Value.ToString() + "'";
                DataRow[] fRow = dt.Select(strExp);
                if (!Convert.ToBoolean(dr.Cells["colMidlunTaka"].Value))
                {
                    dr.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;

                }
                //else
                //{
                //    dr.Cells["colMidlunTaka"].Value = true;
                //}


            }
            foreach (DataGridViewColumn col in m_dgvUtgafur.Columns)
            {
                if (col.Name != "colMidlunTaka")
                {
                    col.ReadOnly = true;
                }
                else
                {
                    col.ReadOnly = false;
                }
            }

        }

        private void m_btnGetData_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                fyllaImportLista(folderBrowserDialog1.SelectedPath);
                m_btnKeyraVorsluInn.Visible = true;
            }
        }

        private void m_dgvUtgafur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_btnKeyraVorsluInn_Click(object sender, EventArgs e)
        {
            //0. hvar er endadótið - verð víst að biðja um það get líka fundið í fyrri afendingum í slóð dt_vörlsuútgafúr


            cVHS_drives drive = new cVHS_drives();
            drive.m_bAfrit = virkurNotandi.m_bAfrit;
            drive.getVirktDrif();
            string strEndaMappa = drive.Nafn;

            //DialogResult result = folderBrowserDialog1.ShowDialog(this);
            //if (result == DialogResult.OK) 
            //{
            //    strEndaMappa = folderBrowserDialog1.SelectedPath;
            //    m_lblEndaMappa.Text = strEndaMappa;
            DataTable dt = (DataTable)m_dgvUtgafur.DataSource;
            string strExp = "taka='true'";
            DataRow[] fRow = dt.Select(strExp);
            if(fRow.Length == 0)
            {
                MessageBox.Show("Vantar að hakka við vörsuútgáfur til að flytja inn");
                return;
            }
            m_prgImportStatusHeild.Maximum = fRow.Length;
            m_prgImportStatusHeild.Step = 1;
            m_prgImportStatusHeild.Value = 0;
            //}
           // foreach (DataGridViewRow dr in m_dgvUtgafur.Rows)
            foreach (DataRow row in dt.Rows)
            {
                // if (dr.Cells["colMidlunTaka"].Value.ToString() == "True")
                if (row["taka"] != DBNull.Value)
                {
                 if(Convert.ToBoolean(row["taka"])) 
                {
                    //1. Flytja skjöl á réttan stað
                    string strAIP = m_strRootInsert + "\\Vörsluútgáfur" + "\\" + row["heiti_varsla"].ToString();
                    string[] strAIPmoppur = Directory.GetDirectories(strAIP);
                    foreach (string str in strAIPmoppur)
                    {
                        //string[] strAIPVarslaMoppur = Directory.GetDirectories(str);

                        m_prgImportStatusHeild.PerformStep();
                        m_lblImportStatusHeild.Text = string.Format("{0}/{1}", m_prgImportStatusHeild.Value, m_prgImportStatusHeild.Maximum);
                        m_lblStatusVarslaTaka.Text = string.Format("Flyt inn {0}", row["heiti_varsla"]);
           

                       // foreach (string strAIPmAPPA in strAIPVarslaMoppur)
                        {
                            string[] strSplit = str.Split("\\");
                            string strAudkenni = string.Empty;

                            if (strSplit.Length != 0)
                            {
                                strAudkenni = strSplit[strSplit.Length - 1];
                            }
                            // string strAudkenniOrginal = dr.Cells["colAudkenniVarslaMidlun"].Value.ToString();
                            string strAudkenniOrginal = row["audkenni"].ToString();

                            if (strAudkenni == strAudkenniOrginal || strAudkenni == strAudkenniOrginal.Replace("AVID", "FRUM"))
                            {
                                if (!Directory.Exists(strEndaMappa + "\\" + strAudkenni))
                                {
                                    Directory.CreateDirectory(strEndaMappa + "\\" + strAudkenni);
                                }
                                //    m_prgImportStatusEitt.PerformStep();
                                //    m_lblImportStatusEitt.Text = string.Format("{0}/{1}", m_prgImportStatusEitt.Value, m_prgImportStatusEitt.Maximum);
                                    m_grbInsertStatus.Visible = true;
                                    m_lblStatusDoing.Text = "Flyt inn skrár";
                                    Application.DoEvents();
                                    //taka út við debug*******************************
                                     try
                                    {
                                        CopyFolder(str, strEndaMappa + "\\" + strAudkenni);
                                    }
                                    catch (Exception x)
                                    {

                                       // throw;
                                    }
                             
                            }
                            //3. Keyra inn gagnagrunn
                            if (strAudkenni == "SQL")
                            {
                                string[] strSQLScript = Directory.GetFiles(str);
                                //keyra hér inn tvær skrár 
                                //1. sql afrit
                                //2. sql innsert.
                                foreach(string strSQL in strSQLScript)
                                {
                                    FileInfo fifo = new FileInfo(strSQL);

                                    if (fifo.Name != "insert.Sql")
                                    {
                                        m_grbInsertStatus.Visible = true;
                                        m_lblStatusDoing.Text = "Flyt inn gagnagrunn";
                                        Application.DoEvents();
                                        strSplit = strSQLScript[0].Split("\\");
                                        string strScript = strSplit[strSplit.Length - 1];
                                        strSplit = strScript.Split(".");
                                        if (strSplit.Length != 0)
                                        {
                                            Restore(strSQLScript[0], strSplit[0]);
                                        }
                                    
                                    }
                                    else
                                    {
                                        m_grbInsertStatus.Visible = true;
                                        m_lblStatusDoing.Text = "Flyt inn lýsigögn (metadata)";
                                        Application.DoEvents();
                                        //2. Keyra inn innsert fyrir media
                                        // string strPathInnsert = m_strRootInsert + "\\SQL_META_AFRIT\\INSERT.sql";
                                        cMIdlun midlun = new cMIdlun();
                                        midlun.m_bAfrit = virkurNotandi.m_bAfrit;
                                        midlun.scriptLoad(strSQL);
                                    
                                    }
                                }
                               
                            }

                        }
                    }
                   



                }
                }


            }

            //refhresha gridið
            fyllaImportLista(m_strRootInsert);
            m_grbInsertStatus.Visible = false;
            MessageBox.Show("Búið");
        }
        private void Restore(string strRestoreFile, string strDataBase)
        {
            string file = strRestoreFile;
            string constring = string.Empty;
            if (strDataBase != string.Empty)
            {
                cMIdlun midlun = new cMIdlun();
                midlun.m_bAfrit = virkurNotandi.m_bAfrit;
                midlun.createDatabase(strDataBase);
                constring = "server = localhost; user id = root; Password = ivarBjarkLind; database = " + strDataBase + ";";
            }
            else
            {
                constring = "server = localhost; user id = root; Password = ivarBjarkLind;"; // database = db_oais_admin_afrit;";
            }
            //  constring = "server = localhost; user id = root; Password = ivarBjarkLind;"; // database = db_oais_admin_afrit;";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(file);
                        conn.Close();
                    }
                }
            }
        }
        private void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            //m_prgBackup.Maximum = files.Length;
            //m_prgBackup.Step = 1;
            //m_prgBackup.Value = 0;
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
                //m_prgBackup.PerformStep();
                //m_lblBackupStatus.Text = file; // string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                FileInfo fifo = new FileInfo(file);
                DirectoryInfo difo = new DirectoryInfo(sourceFolder);


                m_lblStatusDoing.Text = string.Format("Flyt skrá {0} í {1}", difo.Name, difo.Parent.Name);
                Application.DoEvents();
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            //m_prgBackup.Maximum = folders.Length;
            //m_prgBackup.Step = 1;
            //m_prgBackup.Value = 0;
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
                //m_prgBackup.PerformStep();
                //m_lblBackupStatus.Text = folder; // string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }
        }

        private void m_btnKeyrAfritInn_Click(object sender, EventArgs e)
        {
            frmUppsetning frmUpp = new frmUppsetning();
            frmUpp.ShowDialog();
            m_chbAfrit.Visible = true;
            m_btnKeyrAfritInn.Visible = true;
        }

        private void m_btnPantAthUpp_Click(object sender, EventArgs e)
        {
            cDIPKarfa karfa = new cDIPKarfa();
            karfa.m_bAfrit = virkurNotandi.m_bAfrit;
            if (m_trwDIP.SelectedNode.Tag != null )
            {
                string strTag = m_trwDIP.SelectedNode.Tag.ToString();
                karfa.sækjaKörfu(strTag);
                karfa.athugasemdir = m_tboPontunAth.Text;
                karfa.vista();
            }
        }
    }
}