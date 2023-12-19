using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cClassOAIS;
using cClassVHS;
using DocumentFormat.OpenXml.Office2010.Word;

namespace MHR_LEIT
{
    public partial class frmMalakerfi : Form
    {
        public DataTable m_dtPontunMal = new DataTable();
        string m_strGagnagrunnur = string.Empty;
        cMIdlun midlun = new cMIdlun();
        cNotandi virkurnotandi = new cNotandi();    
        DataTable m_dtFyrirspurnir = new DataTable();
        DataTable m_dtSkra = new DataTable();

        DataTable m_dtGrunn = new DataTable();
        DataSet m_dsMal = new DataSet();
        string  m_strIdValinn = string.Empty; //skjal sem er valið í niðurstöðum
        string m_strFileValinn = string.Empty;
        string m_strRoot = string.Empty;
        cVHS_drives drive = new cVHS_drives();
        string m_strSQLMAL = string.Empty;
        string m_strHeitiMalaKerfis = string.Empty;

        public frmMalakerfi()
        {
            InitializeComponent();
        }

        
        public frmMalakerfi(string strGagnagrunnur, DataRow row, DataTable dtGrunn, DataTable dtSkra, DataTable dtMalKerfi, cNotandi not, DataSet dsMal)
        {
            InitializeComponent();


            m_dtSkra = dtSkra;
            m_dtGrunn = dtGrunn;
            m_dsMal = dsMal;
          
            if(dtMalKerfi != null)
            {
                m_dtPontunMal = dtMalKerfi;
            }
     
            m_dgvPontunSkraarKerfi.DataSource = dtSkra;
           
            foreach (DataGridViewColumn col in m_dgvPontunSkraarKerfi.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            m_dgvPontunGagnagrunnar.DataSource = dtGrunn;
          
            foreach (DataGridViewColumn col in m_dgvPontunGagnagrunnar.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            m_dgvPontunMalaKerfi.DataSource = m_dtPontunMal;
           
            foreach (DataGridViewColumn col in m_dgvPontunMalaKerfi.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            setjaFoldaTaba();
            m_pibSkjal.Focus();
            m_strGagnagrunnur = strGagnagrunnur;
            virkurnotandi = not;
            midlun.m_bAfrit = virkurnotandi.m_bAfrit;
            drive.m_bAfrit = virkurnotandi.m_bAfrit;
            m_dtFyrirspurnir = midlun.getGagnagrunnaFyrirSpurnir(m_strGagnagrunnur);

           if (dtMalKerfi == null)
            {
                m_dtPontunMal.Columns.Add("gagnagrunnur");
                m_dtPontunMal.Columns.Add("slod");
                m_dtPontunMal.Columns.Add("sqlMal");
            }
     

            fyllaMalalykla();
            if(virkurnotandi.m_bAfrit)
            {
                m_strRoot = drive.driveVirkkComputers() + "\\" + row["vorsluutgafa"];
            }
            else
            {
                m_strRoot = drive.driveVirkkComputers() + "\\" + row["vorslustofnun_audkenni"].ToString() + "\\" + row["skjalamyndari_audkenni"] + "\\" + row["vorsluutgafa"];
            }
            // ná hér heiti kerfis

            DataSet ds = new DataSet();
            ds.ReadXml(m_strRoot + "\\Indices\\tableIndex.xml");
            string bla =  ds.Tables[0].TableName;
            if(ds.Tables.Contains("siardDiark"))
            {
                m_strHeitiMalaKerfis = ds.Tables["siardDiark"].Rows[0]["dbName"].ToString();
            }

            m_strIdValinn = row["documentid"].ToString();
            string strValin = m_strIdValinn;
            //ná í málID skjals
            string strExp = "nafn='gagn_mal'";
            DataRow[] fRow = m_dtFyrirspurnir.Select(strExp);
            string strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{docID}", m_strIdValinn);
            DataTable dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
            string strMalID = dtMal.Rows[0][0].ToString();

            if (m_strHeitiMalaKerfis == "GoPro")
            {
                fyllaSkjol(strMalID);
              
                foreach (DataGridViewRow dgvr in m_dgvSkjol.Rows)
                {
                    if (dgvr.Cells["doctype"].Value.ToString() == "Um mál")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    if (dgvr.Cells["doctype"].Value.ToString() == "Tölvupóstur")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                    if (dgvr.Cells["doctype"].Value.ToString() == "Viðhengi tölvupósts")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    if (dgvr.Cells["doctype"].Value.ToString() == "Skjal")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }



            foreach (DataGridViewColumn col in m_dgvSkjol.Columns)
           {
              col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            //foreach (DataGridViewRow r in m_dgvSkjol.Rows)
            //{
            //    string strBla = r.Cells["colDokumentID"].Value.ToString();
            //    DataTable dt = (DataTable)m_dgvSkjol.DataSource;
            //    if (r.Cells["colDokumentID"].Value.ToString() == m_strIdValinn)
            //    {
            //        r.Selected = true;
            //        r.Cells[0].Selected = true;
            //        r.DefaultCellStyle.BackColor = Color.LightGreen;
            //        m_dgvSkjol.FirstDisplayedScrollingRowIndex = r.Index;
            //    }

            //}
            //fylla málatöflu með máli undir þessu málID
            strExp = "nafn='mal_malID'";
            fRow = m_dtFyrirspurnir.Select(strExp);
            strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{malID}", strMalID);
            dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
            //  MessageBox.Show(strSQL);
            m_strSQLMAL = strSQL;
            fyllaInfoMall(dtMal);
            //ná í lykill máls
            if(dtMal.Rows.Count > 0)
            {
                string strMalalykill = dtMal.Rows[0]["IndekstermID"].ToString(); //breyta fyrirspurn kalla þetta lykillID

                foreach (TreeNode n in m_trwMalalykill.Nodes)
                {
                    if (n.Tag.ToString() == strMalalykill)
                    {
                        n.BackColor = Color.LightGreen;
                        string strLykillID = n.Tag.ToString();
                        strExp = "nafn='mal_lykill'";
                        fRow = m_dtFyrirspurnir.Select(strExp);
                        strSQL = fRow[0]["fyrirspurn"].ToString();
                        strSQL = strSQL.Replace("{lykillID}", strLykillID);

                        dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
                    
                        foreach (DataRow r in dtMal.Rows)
                        {
                            TreeNode treeNode = new TreeNode(r["Sagstittel"].ToString());
                            treeNode.Tag = r["SagsID"];
                            if(strMalID == treeNode.Tag.ToString())
                            {
                                treeNode.BackColor= Color.LightGreen;   
                            }
                            n.Nodes.Add(treeNode);
                            n.Expand();
                        }

                    }
                }
            }

         

            fyllaMyndSkjal(Convert.ToInt32(strValin), 1);
            splitContainer5.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            m_dgvSkjol.Focus();

        }
        private void fyllaInfoMall(DataTable dt)
        {
            foreach(DataRow r in dt.Rows)
            {
                m_libMalInfo.Items.Clear();
                foreach(DataColumn col in dt.Columns)
                {
                    string strItem = col.ColumnName + ": " + r[col.ColumnName];
                    m_libMalInfo.Items.Add(strItem);
                }
               
            }
        }

        private void fyllaMalalykla()
        {
            m_trwMalalykill.Nodes.Clear();
            string strExp = "nafn='malalykill'";
            DataRow[] fRow = m_dtFyrirspurnir.Select(strExp);
            DataTable dtLyklar = midlun.keyraFyrirspurn(fRow[0]["fyrirspurn"].ToString(), m_strGagnagrunnur);
            foreach(DataRow row in dtLyklar.Rows) 
            {
              //  malalykill, lykillID
                TreeNode n = new TreeNode(row["malalykill"].ToString());
                n.Tag = row["lykillID"].ToString();
                m_trwMalalykill.Nodes.Add(n);
            }
            m_tapMalaLykill.Text = string.Format("Málalyklar ({0})", dtLyklar.Rows.Count);
        }
        private void fyllaMalalyklaAllt()
        {
            m_trwMalalykill.Nodes.Clear();
            string strExp = "nafn='malalykill_allt'";
            DataRow[] fRow = m_dtFyrirspurnir.Select(strExp);
            DataTable dtLyklar = midlun.keyraFyrirspurn(fRow[0]["fyrirspurn"].ToString(), m_strGagnagrunnur);
            foreach (DataRow row in dtLyklar.Rows)
            {
                //  malalykill, lykillID
                TreeNode n = new TreeNode(row["malalykill"].ToString());
                n.Tag = row["lykillID"].ToString();
                m_trwMalalykill.Nodes.Add(n);

                string strLykillID = n.Tag.ToString();
                strExp = "nafn='mal_lykill'";
                fRow = m_dtFyrirspurnir.Select(strExp);
                string strSQL = fRow[0]["fyrirspurn"].ToString();
                strSQL = strSQL.Replace("{lykillID}", strLykillID);
                DataTable dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
                if(dtMal.Rows.Count == 0) 
                {
                    n.BackColor = Color.LightPink;
                }
            }
            m_tapMalaLykill.Text = string.Format("Málalyklar ({0})", dtLyklar.Rows.Count);
        }

        private void fyllaSkjol(string strMalID)
        {
            //1. ná í ýfirskjal
            string  strExp = "nafn='mal_um'";
            DataRow[]  fRow = m_dtFyrirspurnir.Select(strExp);
            string strSQL = string.Empty;
            DataTable dtSkjol = new DataTable();


            if (fRow.Length == 1)
            {
                strSQL = fRow[0]["fyrirspurn"].ToString();
                strSQL = strSQL.Replace("{malID}", strMalID);
                dtSkjol = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
            }
         
            //ná í tölvupóst
            strExp = "nafn='mal_attachment'";
            fRow = m_dtFyrirspurnir.Select(strExp);
            if (fRow.Length == 1)
            {
                strSQL = fRow[0]["fyrirspurn"].ToString();
                strSQL = strSQL.Replace("{malID}", strMalID);
                DataTable dtAtt = dtSkjol.Clone();
                dtAtt = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);

                foreach (DataRow r in dtAtt.Rows)
                {
                    strExp = "dokumentid='" + r["dokumentid"].ToString() + "'";
                    fRow = dtSkjol.Select(strExp);
                    if (fRow.Length == 0)
                    {
                        dtSkjol.ImportRow(r);
                    }

                }
            }
            //viðhengi
            strExp = "nafn='mal_gogn'";
            fRow = m_dtFyrirspurnir.Select(strExp);
            strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{docid}", strMalID);
            DataTable dtGogn = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
            //finna öll viðhengi og líma undir tölvupóst


            if (m_strHeitiMalaKerfis == "GoPro")
            {


                strExp = "MailIDByAttachments <>''";
                fRow = dtGogn.Select(strExp);

                DataTable dtSkjolClone = dtSkjol.Copy();

                foreach (DataRow fr in fRow)
                {
                    // if(fRow.Length == 1)
                    {
                        foreach (DataRow row in dtSkjol.Rows)
                        {
                            if (fr["MailIDByAttachments"].ToString() == row["dokumentID"].ToString())
                            {
                                string strMailAtt = fr["MailIDByAttachments"].ToString();
                                string strDokID = row["dokumentID"].ToString();
                                int iIndwx = 0;
                                int iTala = 0;
                                foreach (DataRow ffr in dtSkjolClone.Rows)
                                {
                                    if (ffr["dokumentid"].ToString() == strMailAtt)
                                    {
                                        iIndwx = iTala;
                                    }
                                    iTala++;
                                }

                                DataRow attRow = dtSkjolClone.NewRow();
                                for (int i = 0; i < dtGogn.Columns.Count; i++)
                                {
                                    attRow["dokumentid"] = fr["dokumentid"];
                                    attRow["author"] = fr["author"];
                                    attRow["subject"] = fr["subject"];
                                    attRow["creationdate"] = fr["creationdate"];
                                    attRow["motificationdate"] = fr["motificationdate"];
                                    attRow["doctype"] = "Viðhengi tölvupósts"; // fr["motificationdate"];
                                    attRow["MailIDByAttachments"] = fr["MailIDByAttachments"];
                                }
                                //attRow["dokumentid"] = fr["dokumentid"];
                                //attRow["MailIDByAttachments"] = fr["MailIDByAttachments"];
                                dtSkjolClone.Rows.InsertAt(attRow, iIndwx + 1);
                                dtSkjolClone.AcceptChanges();
                            }

                        }
                    }


                }

                strExp = "MailIDByAttachments is null";
                fRow = dtGogn.Select(strExp);

                foreach (DataRow gr in fRow)
                {
                    strExp = "dokumentid = '" + gr["dokumentid"].ToString() + "'";
                    DataRow[] gROW = dtSkjolClone.Select(strExp);
                    if (gROW.Length == 0)
                    {
                        dtSkjolClone.ImportRow(gr);
                    }

                }
                m_dgvSkjol.DataSource = dtSkjolClone;
                m_grbSkjol.Text = string.Format("Skjöl ({0})", dtSkjolClone.Rows.Count);
                m_dgvSkjol.ClearSelection();

                foreach (DataGridViewRow dgvr in m_dgvSkjol.Rows)
                {
                    if (dgvr.Cells["doctype"].Value.ToString() == "Um mál")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    if (dgvr.Cells["doctype"].Value.ToString() == "Tölvupóstur")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                    if (dgvr.Cells["doctype"].Value.ToString() == "Viðhengi tölvupósts")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    if (dgvr.Cells["doctype"].Value.ToString() == "Skjal")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
            //if (fRow.Length == 1)
            //{
            //    strSQL = fRow[0]["fyrirspurn"].ToString();
            //    strSQL = strSQL.Replace("{malID}", strMalID);
            //    DataTable dtAtt = dtSkjol.Clone();
            //    dtAtt = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);

            //    foreach (DataRow r in dtAtt.Rows)
            //    {
            //        strExp = "dokumentid='" + r["dokumentid"].ToString() + "'";
            //        fRow = dtSkjol.Select(strExp);
            //        if (fRow.Length == 0)
            //        {
            //            dtSkjol.ImportRow(r);
            //        }

            //    }
            //}


        }

        private void m_trwMalalykill_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_trwMalalykill.Focused)
            {
                if (e.Node.Level == 0)
                {
                    string strLykillID = e.Node.Tag.ToString();
                    string strExp = "nafn='mal_lykill'";
                    DataRow[] fRow = m_dtFyrirspurnir.Select(strExp);
                    string strSQL = fRow[0]["fyrirspurn"].ToString();
                    strSQL = strSQL.Replace("{lykillID}", strLykillID);

                    DataTable dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
                   
                    e.Node.Nodes.Clear();   
                    foreach (DataRow r in dtMal.Rows)
                    {
                        TreeNode treeNode = new TreeNode(r["Sagstittel"].ToString());
                        treeNode.Tag = r["SagsID"];
                        e.Node.Nodes.Add(treeNode);
                        e.Node.Expand();
                    }
                }
                if (e.Node.Level == 1)
                {
                    splitContainer5.Visible = false;
                    string strMalID = e.Node.Tag.ToString();
                   
                    string strExp = "nafn='mal_malID'";
                    DataRow[] fRow = m_dtFyrirspurnir.Select(strExp);
                    string strSQL = fRow[0]["fyrirspurn"].ToString();
                    strSQL = strSQL.Replace("{malID}", strMalID);

                    DataTable dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
                    m_strSQLMAL = strSQL;
                    fyllaInfoMall(dtMal);

                    // ná í document, email og memo
                    //1 ná í yfirskjal um málið
                    if(m_strHeitiMalaKerfis == "GoPro")
                    {
                        fyllaSkjol(strMalID);
                        return;
                    }
                   

                    strExp = "nafn='mal_gogn'";
                    fRow = m_dtFyrirspurnir.Select(strExp);
                    strSQL = fRow[0]["fyrirspurn"].ToString();
                    strSQL = strSQL.Replace("{docid}", strMalID);
                    DataTable dtSkjol = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);

                    strExp = "nafn='mal_attachment'";
                    fRow = m_dtFyrirspurnir.Select(strExp);
                    if (fRow.Length == 1)
                    {
                        strSQL = fRow[0]["fyrirspurn"].ToString();
                        strSQL = strSQL.Replace("{malID}", strMalID);
                        DataTable dtAtt = dtSkjol.Clone();
                        dtAtt = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);

                        foreach (DataRow r in dtAtt.Rows)
                        {
                            strExp = "dokumentid='" + r["dokumentid"].ToString() + "'";
                            fRow = dtSkjol.Select(strExp);
                            if (fRow.Length == 0)
                            {
                                dtSkjol.ImportRow(r);
                            }

                        }
                    }
                    strExp = "nafn='mal_um'";
                    fRow = m_dtFyrirspurnir.Select(strExp);
                    if (fRow.Length == 1)
                    {
                        strSQL = fRow[0]["fyrirspurn"].ToString();
                        strSQL = strSQL.Replace("{malID}", strMalID);
                        DataTable dtAtt = dtSkjol.Clone();
                        dtAtt = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);

                        foreach (DataRow r in dtAtt.Rows)
                        {
                            strExp = "dokumentid='" + r["dokumentid"].ToString() + "'";
                            fRow = dtSkjol.Select(strExp);
                            if (fRow.Length == 0)
                            {
                                dtSkjol.ImportRow(r);
                            }

                        }
                    }


                    m_dgvSkjol.DataSource = dtSkjol;
                    m_grbSkjol.Text = string.Format("Skjöl ({0})", dtSkjol.Rows.Count);
                    m_dgvSkjol.ClearSelection();
                    foreach (DataGridViewRow r in m_dgvSkjol.Rows)
                    {
                        string strBla = r.Cells["colDokumentID"].Value.ToString();
                        DataTable dt = (DataTable)m_dgvSkjol.DataSource;
                        if (r.Cells["colDokumentID"].Value.ToString() == m_strIdValinn)
                        {
                            r.Selected = true;
                            r.Cells[0].Selected = true;
                            r.DefaultCellStyle.BackColor = Color.LightGreen;
                            m_dgvSkjol.FirstDisplayedScrollingRowIndex = r.Index;
                        }

                    }
//ná í það sem er í attachments 


;
                    foreach (DataGridViewColumn col in m_dgvSkjol.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }



        }

      
        private void fyllaMyndSkjal(int iID, int iPage)
        {
            m_strIdValinn = iID.ToString();
            double dColl = Convert.ToInt32(m_strIdValinn) / 10000;
            if (iID == 1)
            {
                dColl = 1;
            }
            else
            {
                dColl = dColl + 1;
            }

            string strValid = m_strRoot + "\\Documents\\docCollection" + dColl.ToString() + "\\" + m_strIdValinn;
          
     
            string[] strFiles = Directory.GetFiles(strValid);
            m_strFileValinn = strFiles[0];

            Image image = Image.FromFile(m_strFileValinn);
            FrameDimension dimension;

            dimension = FrameDimension.Page;
            int x = 70;
            int iPages = image.GetFrameCount(dimension);
            m_numUpDown.Maximum = iPages;
            m_numUpDown.Minimum = 1;
            m_lblSidaValinn.Text = string.Format("af {0} valin", iPages);
            string strExp = "skjalID='" + m_strIdValinn + "'";
            //DataRow[] frow = m_dtSkrar.Select(strExp);
            //if (frow.Length > 0)
            //{
            //    //  DateTime date = Convert.ToDateTime[]
            //    m_lblDagsetning.Text = string.Format("Síðast var skráð í skjalið {0}", frow[0]["lastwriten"]);
            //}
            image.SelectActiveFrame(FrameDimension.Page, iPage - 1); // iPages - 1);
            m_pibSkjal.Image = image;
            //opna blættí skalið
            splitContainer5.Visible = true;
        }

        private void m_pibSkjal_DoubleClick(object sender, EventArgs e)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(m_strFileValinn)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void m_trwMalalykill_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown)
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void m_dgvSkjol_SelectionChanged(object sender, EventArgs e)

        {     
            if(m_dgvSkjol.SelectedRows.Count == 1 && m_dgvSkjol.Focused)
            {
                string strDocID = m_dgvSkjol.Rows[m_dgvSkjol.SelectedRows[0].Index].Cells["colDokumentID"].Value.ToString();
                fyllaMyndSkjal(Convert.ToInt32(strDocID), 1);
            }
           
        }

        private void m_btnAlltKarfa_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)m_dgvSkjol.DataSource;
            if(m_dtPontunMal.Columns.Count == 3)
             {
                foreach (DataColumn col in dt.Columns)
                {
                    m_dtPontunMal.Columns.Add(col.ColumnName);

                }
            }
            
            
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                DataRow r = m_dtPontunMal.NewRow();
                r["gagnagrunnur"] = m_strGagnagrunnur;
            
                r["sqlMal"] = m_strSQLMAL;

                int iID = Convert.ToInt32(row["DokumentID"]); //þarf að breyta og setja fast lykilheiti
                double dColl = iID / 10000;
                if (iID == 1)
                {
                    dColl = 1;
                }
                else
                {
                    dColl = dColl + 1;
                }
                string strValid = m_strRoot + "\\Documents\\docCollection" + dColl.ToString() + "\\" + iID.ToString();
                r["slod"] = strValid;
                int j = 3;
                foreach (DataColumn col in dt.Columns)
                { //  if(j-2 < dt.Columns.Count)
                    {
                        r[j] = dt.Rows[i][j - 3];
                        j++;
                    }
                   

                }


                m_dtPontunMal.Rows.Add(r);

                m_dtPontunMal.AcceptChanges();
                i++;
            }
            m_dgvPontunMalaKerfi.DataSource = m_dtPontunMal;
            setjaFoldaTaba();
            foreach (DataGridViewColumn col in m_dgvPontunMalaKerfi.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void m_btnEittKara_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)m_dgvSkjol.DataSource;
            int iIndex =  m_dgvSkjol.SelectedRows[0].Index;
            if (m_dtPontunMal.Columns.Count == 3)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    m_dtPontunMal.Columns.Add(col.ColumnName);

                }
            }
            DataRow r = m_dtPontunMal.NewRow();
            r["gagnagrunnur"] = m_strGagnagrunnur;

            r["sqlMal"] = m_strSQLMAL;

            int iID = Convert.ToInt32(dt.Rows[iIndex]["DokumentID"]); //þarf að breyta og setja fast lykilheiti
            double dColl = iID / 10000;
            if (iID == 1)
            {
                dColl = 1;
            }
            else
            {
                dColl = dColl + 1;
            }
            string strValid = m_strRoot + "\\Documents\\docCollection" + dColl.ToString() + "\\" + iID.ToString();
            r["slod"] = strValid;
            int j = 3;
            foreach (DataColumn col in dt.Columns)
            { //  if(j-2 < dt.Columns.Count)
                {
                    r[j] = dt.Rows[iIndex][j - 3];
                    j++;
                }


            }


            m_dtPontunMal.Rows.Add(r);

            m_dtPontunMal.AcceptChanges();
            m_dgvPontunMalaKerfi.DataSource = m_dtPontunMal;
            setjaFoldaTaba();
            foreach (DataGridViewColumn col in m_dgvPontunMalaKerfi.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void setjaFoldaTaba()
        {
            DataTable dt = (DataTable)m_dgvPontunMalaKerfi.DataSource;
            int iFjold = dt.Rows.Count;
            m_tapMalkerfi.Text = string.Format("Málakerfi ({0})", dt.Rows.Count);

            dt = (DataTable)m_dgvPontunGagnagrunnar.DataSource;
            iFjold = iFjold + dt.Rows.Count;
            m_tapGagnagrunnar.Text = string.Format("Gagnagrunnur ({0})", dt.Rows.Count);

            dt = (DataTable)m_dgvPontunSkraarKerfi.DataSource;
            iFjold = iFjold + dt.Rows.Count;
            m_tapSkraakerfi.Text = string.Format("SKráakerfi ({0})", dt.Rows.Count);

            m_grbPantanir.Text = string.Format("Óafgreitt ({0})", iFjold);

        }

        private void m_btnLeita_Click(object sender, EventArgs e)
        {
            leita();
        }
        private void leita()
        {
            midlun.leitarord = m_tboLeita.Text;
            DataTable dt= midlun.leitInnraDataTable(midlun.leitarord, m_strGagnagrunnur);

            m_trwLeit.Nodes.Clear();    
            foreach (DataRow dr in dt.Rows)
            {
                // documentid, doctitill 
                TreeNode n = new TreeNode(dr["doctitill"].ToString() + " " + dr["documentid"].ToString());
                n.Tag = dr["documentid"].ToString();
                m_trwLeit.Nodes.Add(n);
            }
            m_tapLeit.Text = string.Format("Leitarniðurstöður ({0})", dt.Rows.Count);
            m_tacMalaLykillLeit.SelectedTab = m_tapLeit;

         
            
        }

        private void m_tboLeita_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                leita();
            }
        }

        private void finnaDoc()
        {
           
            string strExp = "nafn='gagn_mal'";
            DataRow[] fRow = m_dtFyrirspurnir.Select(strExp);
            string strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{docID}", m_strIdValinn);
            DataTable dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
            string strMalID = dtMal.Rows[0][0].ToString();

            //ná í skjöl máls fyllaskjalatöflu
            strExp = "nafn='mal_gogn'";
            fRow = m_dtFyrirspurnir.Select(strExp);
            strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{docid}", strMalID);
            DataTable dtSkjol = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);

            strExp = "nafn='mal_attachment'";
            fRow = m_dtFyrirspurnir.Select(strExp);
            if (fRow.Length == 1)
            {
                strSQL = fRow[0]["fyrirspurn"].ToString();
                strSQL = strSQL.Replace("{malID}", strMalID);
                DataTable dtAtt = dtSkjol.Clone();
                dtAtt = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);

                foreach (DataRow r in dtAtt.Rows)
                {
                    strExp = "dokumentid='" + r["dokumentid"].ToString() + "'";
                    fRow = dtSkjol.Select(strExp);
                    if (fRow.Length == 0)
                    {
                        dtSkjol.ImportRow(r);
                    }

                }
            }

            m_dgvSkjol.DataSource = dtSkjol;
            m_grbSkjol.Text = string.Format("Skjöl ({0})", dtSkjol.Rows.Count);

            foreach (DataGridViewColumn col in m_dgvSkjol.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            
            //fylla málatöflu með máli undir þessu málID
            strExp = "nafn='mal_malID'";
            fRow = m_dtFyrirspurnir.Select(strExp);
            strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{malID}", strMalID);
            dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
            //  MessageBox.Show(strSQL);
            m_strSQLMAL = strSQL;
            fyllaInfoMall(dtMal);
            //ná í lykill máls
            if (dtMal.Rows.Count > 0)
            {
                string strMalalykill = dtMal.Rows[0]["IndekstermID"].ToString(); //breyta fyrirspurn kalla þetta lykillID

                foreach (TreeNode n in m_trwMalalykill.Nodes)
                {
                    n.BackColor = Color.White;
                    foreach(TreeNode nn in n.Nodes)
                    {
                        nn.BackColor = Color.White;
                    }
                    if (n.Tag.ToString() == strMalalykill)
                    {
                        n.BackColor = Color.LightGreen;
                        string strLykillID = n.Tag.ToString();
                        strExp = "nafn='mal_lykill'";
                        fRow = m_dtFyrirspurnir.Select(strExp);
                        strSQL = fRow[0]["fyrirspurn"].ToString();
                        strSQL = strSQL.Replace("{lykillID}", strLykillID);

                        dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
                        n.Nodes.Clear();
                        foreach (DataRow r in dtMal.Rows)
                        {
                            TreeNode treeNode = new TreeNode(r["Sagstittel"].ToString());
                            treeNode.Tag = r["SagsID"];
                            if (strMalID == treeNode.Tag.ToString())
                            {
                                treeNode.BackColor = Color.LightGreen;
                            }
                            n.Nodes.Add(treeNode);
                            n.Expand();
                        }

                    }
                }
            }

           
        }

        private void m_dgvLeitarNidurstodur_SizeChanged(object sender, EventArgs e)
        {
         
           
        }

        private void m_dgvLeitarNidurstodur_SelectionChanged(object sender, EventArgs e)
        {
            //m_strIdValinn = m_dgvLeitarNidurstodur.Rows[m_dgvLeitarNidurstodur.SelectedRows[0].Index].Cells["colID"].Value.ToString();
            //string strID = m_strIdValinn;
            //foreach (DataGridViewRow r in m_dgvSkjol.Rows)
            //{
            //    string strValue = r.Cells[0].Value.ToString();
            //    if (r.Cells[0].Value.ToString() == strID)
            //    {
            //        m_dgvSkjol.CurrentCell = m_dgvSkjol.Rows[r.Index].Cells[0];
            //        r.Selected = true;
            //        //.Rows(0).Cells(0);
            //    }
            //}
            //finnaDoc();
            //fyllaMyndSkjal(Convert.ToInt32(strID), 1);
        }

        private void m_btnLjukaPontun_Click(object sender, EventArgs e)
        {
           if( m_dsMal.Tables.Count == 0)
            {
                DataTable dtMalTemp = m_dtPontunMal.Clone();
                foreach (DataRow r in m_dtPontunMal.Rows)
                {
                    dtMalTemp.ImportRow(r);
                }
                m_dsMal.Tables.Add(dtMalTemp);
            }
          
            frmAfgreidsla frmAfgreidsla = new frmAfgreidsla(virkurnotandi, m_dtSkra, m_dtPontunMal, m_dtGrunn, m_dsMal);
            frmAfgreidsla.ShowDialog();
        }

        private void m_trwLeit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            m_strIdValinn = e.Node.Tag.ToString();
            string strID = m_strIdValinn;

            string strExp = "nafn='gagn_mal'";
            DataRow[] fRow = m_dtFyrirspurnir.Select(strExp);
            string strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{docID}", m_strIdValinn);
            DataTable dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
            string strMalID = dtMal.Rows[0][0].ToString();

        
            fyllaSkjol(strMalID);


            strExp = "nafn='mal_malID'";
            fRow = m_dtFyrirspurnir.Select(strExp);
            strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{malID}", strMalID);

            dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
            m_strSQLMAL = strSQL;
            fyllaInfoMall(dtMal);
         
          //  finnaDoc();
            fyllaMyndSkjal(Convert.ToInt32(strID), 1);
            m_dgvSkjol.ClearSelection();
            foreach(DataGridViewRow r in m_dgvSkjol.Rows)
            {
                string strBla = r.Cells["colDokumentID"].Value.ToString();
                if (r.Cells["colDokumentID"].Value.ToString() == m_strIdValinn)
                {
                    r.Selected= true;
                    r.Cells[0].Selected= true;
                    r.DefaultCellStyle.BackColor = Color.LightGreen;
                    m_dgvSkjol.FirstDisplayedScrollingRowIndex = r.Index;
                }

            }


        }

        private void m_dgvSkjol_Paint(object sender, PaintEventArgs e)
        {
            //if (m_strHeitiMalaKerfis == "GoPro")
            //{
            //    foreach (DataGridViewRow dgvr in m_dgvSkjol.Rows)
            //    {
            //        if (dgvr.Cells["doctype"].Value.ToString() == "Um mál")
            //        {
            //            dgvr.DefaultCellStyle.BackColor = Color.LightYellow;
            //        }
            //        if (dgvr.Cells["doctype"].Value.ToString() == "Tölvupóstur")
            //        {
            //            dgvr.DefaultCellStyle.BackColor = Color.LightSkyBlue;
            //        }
            //        if (dgvr.Cells["doctype"].Value.ToString() == "Viðhengi tölvupósts")
            //        {
            //            dgvr.DefaultCellStyle.BackColor = Color.LightBlue;
            //        }
            //        if (dgvr.Cells["doctype"].Value.ToString() == "Skjal")
            //        {
            //            dgvr.DefaultCellStyle.BackColor = Color.LightGray;
            //        }
            //    }
            //}
            //if(!m_dgvSkjol.Focused)
            //{
               
            //    m_dgvSkjol.ClearSelection();
            //    foreach (DataGridViewRow r in m_dgvSkjol.Rows)
            //    {
            //        string strBla = r.Cells["colDokumentID"].Value.ToString();
            //        if (r.Cells["colDokumentID"].Value.ToString() == m_strIdValinn)
            //        {
            //            r.Selected = true;
            //            r.Cells[0].Selected = true;
            //            r.DefaultCellStyle.BackColor = Color.LightGreen;
            //            m_dgvSkjol.FirstDisplayedScrollingRowIndex = r.Index;
            //         //   m_dgvSkjol.Focus();
            //            fyllaMyndSkjal(Convert.ToInt32(strBla), 1);

            //        }
            //        else
            //        {
            //         //   m_dgvSkjol.ClearSelection();
            //        }

            //    }
            //}
      
            // m_dgvSkjol.ClearSelection();
        }

        private void m_rdbInnheldlurMal_CheckedChanged(object sender, EventArgs e)
        {
            if(m_rdbInnheldlurMal.Checked) 
            {
                fyllaMalalykla();
            }
            if(m_rdbInnheldurAllt.Checked)
            {
                fyllaMalalyklaAllt();
            }
        }

        private void m_dgvSkjol_Leave(object sender, EventArgs e)
        {
          //  m_dgvSkjol.ClearSelection();
        }

        private void m_dgvSkjol_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (m_strHeitiMalaKerfis == "GoPro")
            {
                foreach (DataGridViewRow dgvr in m_dgvSkjol.Rows)
                {
                    if (dgvr.Cells["doctype"].Value.ToString() == "Um mál")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    if (dgvr.Cells["doctype"].Value.ToString() == "Tölvupóstur")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                    if (dgvr.Cells["doctype"].Value.ToString() == "Viðhengi tölvupósts")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    if (dgvr.Cells["doctype"].Value.ToString() == "Skjal")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }

            if (!m_dgvSkjol.Focused)
            {

                m_dgvSkjol.ClearSelection();
                foreach (DataGridViewRow r in m_dgvSkjol.Rows)
                {
                    string strBla = r.Cells["colDokumentID"].Value.ToString();
                    if (r.Cells["colDokumentID"].Value.ToString() == m_strIdValinn)
                    {
                        r.Selected = true;
                        r.Cells[0].Selected = true;
                        r.DefaultCellStyle.BackColor = Color.LightGreen;
                        m_dgvSkjol.FirstDisplayedScrollingRowIndex = r.Index;
                        //   m_dgvSkjol.Focus();
                        fyllaMyndSkjal(Convert.ToInt32(strBla), 1);

                    }
                    else
                    {
                        //   m_dgvSkjol.ClearSelection();
                    }

                }
            }
        }

        private void m_libMalInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = m_libMalInfo.SelectedItem.ToString();
                Clipboard.SetData(DataFormats.StringFormat, s);
            }
        }
    }
    
}
