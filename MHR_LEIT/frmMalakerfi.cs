﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cClassOAIS;
using cClassVHS;

namespace MHR_LEIT
{
    public partial class frmMalakerfi : Form
    {
        public DataTable m_dtPontunMal = new DataTable();
        string m_strGagnagrunnur = string.Empty;
        cMIdlun midlun = new cMIdlun();
        DataTable m_dtFyrirspurnir = new DataTable();
        string  m_strIdValinn = string.Empty; //skjal sem er valið í niðurstöðum
        string m_strFileValinn = string.Empty;
        string m_strRoot = string.Empty;
        cVHS_drives drive = new cVHS_drives();
        string m_strSQLMAL = string.Empty;

        public frmMalakerfi()
        {
            InitializeComponent();
        }

        
        public frmMalakerfi(string strGagnagrunnur, DataRow row, DataTable dtGrunn, DataTable dtSkra, DataTable dtMalKerfi)
        {
            InitializeComponent();
          
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
            m_dtFyrirspurnir = midlun.getGagnagrunnaFyrirSpurnir(m_strGagnagrunnur);

           if (dtMalKerfi == null)
            {
                m_dtPontunMal.Columns.Add("gagnagrunnur");
                m_dtPontunMal.Columns.Add("slod");
                m_dtPontunMal.Columns.Add("sqlMal");
            }
     

            fyllaMalalykla();
            m_strRoot = drive.driveVirkkComputers() + "\\" + row["vorslustofnun_audkenni"].ToString() + "\\" + row["skjalamyndari_audkenni"] + "\\" + row["vorsluutgafa"];

            m_strIdValinn = row["documentid"].ToString();
            //ná í málID skjals
            string strExp = "nafn='gagn_mal'";
            DataRow[] fRow = m_dtFyrirspurnir.Select(strExp);
            string strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{docID}", m_strIdValinn);
            DataTable dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
            string strMalID = dtMal.Rows[0][0].ToString();

            //ná í skjöl máls fyllaskjalatöflu
            strExp = "nafn='mal_doc'";
            fRow = m_dtFyrirspurnir.Select(strExp);
            strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{malID}", strMalID);
            DataTable dtSkjol = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
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
           


            fyllaMyndSkjal(Convert.ToInt32(m_strIdValinn), 1);
            this.WindowState = FormWindowState.Maximized;
        }
        private void fyllaInfoMall(DataTable dt)
        {
            foreach(DataRow r in dt.Rows)
            {
                string strInfo = string.Empty;
                foreach(DataColumn col in dt.Columns)
                {
                    strInfo += col.ColumnName + ": " + r[col.ColumnName] + Environment.NewLine;
                }
                m_lblMalInfo.Text = strInfo;
            }
        }

        private void fyllaMalalykla()
        {
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
                   
                    string strExp = "nafn='eitt_mal'";
                    DataRow[] fRow = m_dtFyrirspurnir.Select(strExp);
                    string strSQL = fRow[0]["fyrirspurn"].ToString();
                    strSQL = strSQL.Replace("{malID}", strMalID);

                    DataTable dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
                    m_strSQLMAL = strSQL;
                    fyllaInfoMall(dtMal);

                    strExp = "nafn='mal_gogn'";
                    fRow = m_dtFyrirspurnir.Select(strExp);
                    strSQL = fRow[0]["fyrirspurn"].ToString();
                    strSQL = strSQL.Replace("{docid}", strMalID);

                    DataTable dtSkjol = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
                    m_dgvSkjol.DataSource = dtSkjol;
                    m_grbSkjol.Text = string.Format("Skjöl ({0})", dtSkjol.Rows.Count);
                    foreach (DataGridViewColumn col in m_dgvSkjol.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }



        }

        private void m_dgvSkjol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string strDocID = m_dgvSkjol.Rows[e.RowIndex].Cells["DokumentID"].Value.ToString();
            //fyllaMyndSkjal(Convert.ToInt32(strDocID), 1);

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
            if(m_dgvSkjol.SelectedRows.Count == 1)
            {
                string strDocID = m_dgvSkjol.Rows[m_dgvSkjol.SelectedRows[0].Index].Cells["DokumentID"].Value.ToString();
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
            m_tapMalkerfi.Text = string.Format("SKráakerfi ({0})", dt.Rows.Count);

            dt = (DataTable)m_dgvPontunGagnagrunnar.DataSource;
            iFjold = iFjold + dt.Rows.Count;
            m_tapGagnagrunnar.Text = string.Format("SKráakerfi ({0})", dt.Rows.Count);

            dt = (DataTable)m_dgvPontunSkraarKerfi.DataSource;
            iFjold = iFjold + dt.Rows.Count;
            m_tapSkraakerfi.Text = string.Format("SKráakerfi ({0})", dt.Rows.Count);

            m_grbPantanir.Text = string.Format("Óafgreitt ({0})", iFjold);

        }
    }
    
}