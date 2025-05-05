using cClassOAIS;
//using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MHR_LEIT
{
    public partial class frmGagnagrunnur : Form
    {
        string m_strGagnagrunnur = string.Empty;
        string m_strOrginal = string.Empty;
        string m_strSQLpanta = string.Empty;
        string m_strLeitSkilyrdi = string.Empty;

        cNotandi virkurnotandi = new cNotandi();
        cSkjalaskra skjal = new cSkjalaskra();

        DataTable m_dtSkra = new DataTable();
        DataTable m_dtMal = new DataTable();
        DataSet m_dsMal = new DataSet();


        DataTable m_dtFyrirspurnir = new DataTable();
        cMIdlun mIdlun = new cMIdlun();
        public DataTable m_dtPantad = new DataTable();
        public frmGagnagrunnur()
        {
            InitializeComponent();
        }
        public frmGagnagrunnur(string strGagnagrunnur, string strOrginalHeiti, DataTable dtGrunnar, DataTable dtSkrar, DataTable dtMal, cNotandi not, DataSet ds_mal, cNotandi virkur)
        {
            InitializeComponent();
            virkurnotandi = virkur;
            skjal.m_bAfrit = virkurnotandi.m_bAfrit;

            skjal.getSkraning(strGagnagrunnur.Replace("_", "."));

            m_dtSkra = dtSkrar;
            m_dtMal = dtMal;
            m_dsMal = ds_mal;

            m_dtPantad = dtGrunnar.Clone();
            foreach (DataRow r in dtGrunnar.Rows)
            {
                m_dtPantad.ImportRow(r);
            }
            erPontun();
            this.WindowState = FormWindowState.Maximized;
            virkurnotandi = not;
            mIdlun.m_bAfrit = virkurnotandi.m_bAfrit;
            m_strGagnagrunnur = strGagnagrunnur;
            m_strOrginal = strOrginalHeiti;
            m_dtFyrirspurnir = mIdlun.getGagnagrunnaFyrirSpurnir(strGagnagrunnur);
            fyllaFyrirspurnaform();
            this.Text = m_strOrginal;
            m_dgvPantSkraarkerfi.AutoGenerateColumns = false;
            m_dgvPantSkraarkerfi.DataSource = dtSkrar;
            m_tapSkráarkerfi.Text = string.Format("Skráarkerfi ({0})", dtSkrar.Rows.Count);

            if (ds_mal.Tables.Count > 0)
            {
                m_dgvPantMalaKerfi.AutoGenerateColumns = false;
                DataTable dtMalAllt = new DataTable();

                for (int i = 0; i < ds_mal.Tables.Count; i++)
                {
                    if (i == 0)
                        dtMalAllt = ds_mal.Tables[i].Copy();
                    else
                        dtMalAllt.Merge(ds_mal.Tables[i]);
                }
                m_dgvPantMalaKerfi.DataSource = dtMalAllt;
                m_tapMalakrefi.Text = string.Format("Málakerfi ({0})", dtMalAllt.Rows.Count);
            }
            else
            {
                m_dgvPantMalaKerfi.AutoGenerateColumns = false;

                m_dgvPantMalaKerfi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                m_dgvPantMalaKerfi.DataSource = dtMal;
                m_tapMalakrefi.Text = string.Format("Málakerfi ({0})", dtMal.Rows.Count);
            }


            m_dgvPantGagnagrunnar.AutoGenerateColumns = false;
            m_dgvPantGagnagrunnar.DataSource = m_dtPantad;
            m_tapGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", dtGrunnar.Rows.Count);

            //if(m_dtPantad.Columns.Count != 5)
            //{
            //    m_dtPantad.Columns.Add("Heiti");
            //    m_dtPantad.Columns.Add("vorsluutgafa");
            //    m_dtPantad.Columns.Add("leitarskilyrði");
            //    m_dtPantad.Columns.Add("sql");
            //    m_dtPantad.Columns.Add("heitivorslu");
            //}



        }

        private void erPontun()
        {
            int iFjoldi = m_dtPantad.Rows.Count + m_dtSkra.Rows.Count + m_dsMal.Tables.Count;
            if (iFjoldi != 0)
            {
                m_btnLjukaPontun.Visible = true;
            }
            else
            {
                m_btnLjukaPontun.Visible = false;
            }
        }
        private void fyllaFyrirspurnaform()
        {
            DataTable dtClone = m_dtFyrirspurnir.Clone();

           


            DataView view = new DataView(m_dtFyrirspurnir);
            DataTable distinctValues = view.ToTable(true, "nr");

            string strSQL = string.Empty;

            foreach (DataRow nr in distinctValues.Rows)
            {
                //finna hér allt sem passar við nr 
                string strEXp = "nr='" + nr["nr"].ToString() + "'";
                DataRow[] fRow = m_dtFyrirspurnir.Select(strEXp);
                int i = 0;
                foreach (DataRow r in fRow)
                {
                    if (!r["lysing"].ToString().Contains("færibreyta"))
                    {
                        dtClone.ImportRow(r);
                        strSQL = r["fyrirspurn"].ToString();
                        i++;
                        if (r["nafn"].ToString().Contains("texti_search")) // == "AV_samskipti_\r\n")
                        {
                            DataGridViewTextBoxColumn colText = new DataGridViewTextBoxColumn();
                            // DataTable dt = mIdlun.keyraFyrirspurn(fRow[i]["fyrirspurn"].ToString(), m_strGagnagrunnur);
                            colText.Name = "texti";
                            colText.HeaderText = "texti";
                            colText.Width = 100;
                            m_dgvFyrirspurnir.Columns.Insert(3, colText);
                        }

                    }
                    else //if (nr["nr"].ToString() == "1")
                    {

                        string[] strSplit = strSQL.Split("'");
                        if (i <= fRow.Length - 1)
                        {
                            foreach (string str in strSplit)
                            {
                                if (str.Contains("{"))
                                {
                                    string[] strFæri = str.Split(":");

                                    if (strFæri.Length == 1)
                                    {


                                        DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();

                                        DataTable dt = mIdlun.keyraFyrirspurn(fRow[i]["fyrirspurn"].ToString(), m_strGagnagrunnur);
                                        col.Name = "dalkur";
                                        m_dgvFyrirspurnir.Columns.Insert(m_dgvFyrirspurnir.Columns.Count - 1, col);

                                        //   m_dgvFyrirspurnir.Columns.Add(col);
                                        string strDalkur = string.Empty;
                                        foreach (DataColumn column in dt.Columns)
                                        {
                                            strDalkur = column.ColumnName;
                                        }
                                        string strDisplay = strDalkur; // strFæri[0].Replace("{", "").Replace("}", "");
                                        col.DisplayMember = strDisplay;
                                        string strValue = strDalkur; // strFæri[0].Replace("{", "").Replace("}", ""); ;
                                        col.HeaderText = col.DisplayMember;
                                        col.ValueMember = strValue;
                                        col.DataSource = dt; // products_list.ToList();
                                        i++;
                                    }
                                    if (strFæri.Length == 3)
                                    {
                                        DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();

                                        DataTable dt = mIdlun.keyraFyrirspurn(fRow[i]["fyrirspurn"].ToString(), m_strGagnagrunnur);

                                        m_dgvFyrirspurnir.Columns.Insert(m_dgvFyrirspurnir.Columns.Count - 1, col);
                                        //   m_dgvFyrirspurnir.Columns.Add(col);
                                        string strDisplay = strFæri[2].Replace("{", "").Replace("}", "");
                                        col.DisplayMember = strDisplay;
                                        col.Width = 200;
                                        string strValue = strFæri[1].Replace("{", "").Replace("}", "");
                                        col.HeaderText = col.DisplayMember;
                                        col.ValueMember = strValue;
                                        col.DataSource = dt; // products_list.ToList();
                                        i++;

                                    }

                                }
                            }
                        }

                    }

                }
            }

            DataGridViewButtonColumn Keyra = new DataGridViewButtonColumn();
            Keyra.Name = "keyra";
            Keyra.Text = "Keyra fyrirspurn";
            Keyra.Width = 150;
            Keyra.UseColumnTextForButtonValue = true;
            m_dgvFyrirspurnir.CellClick += keyrafyrirspurn_CellClick;
            if (m_dgvFyrirspurnir.Columns["uninstall_column"] == null)
            {
                m_dgvFyrirspurnir.Columns.Insert(m_dgvFyrirspurnir.Columns.Count - 1, Keyra);

            }
            m_dgvFyrirspurnir.DataSource = dtClone; // dtClone;
            //DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)m_dgvFyrirspurnir["dalkur", 1];
            //cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            //cell.ReadOnly = true;

            //col.DataSource = 
            // m_dgvFyrirspurnir.Columns.Add(col);

        }

        private void keyrafyrirspurn_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;



            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //ná í fyrirspurnina laga hana og keyra svo
                string strSQL = senderGrid.Rows[e.RowIndex].Cells["colFyrirspurn"].Value.ToString();
                string strSQLSenda = string.Empty;
                string[] Split = strSQL.Split("'");
                string strVilla = string.Empty;
                int i = 1;
                foreach (string s in Split)
                {
                    if (s.Contains("{"))
                    {
                        foreach (DataGridViewColumn col in senderGrid.Columns)
                        {
                            string strType = col.CellType.ToString();
                            //if (strType == "System.Windows.Forms.DataGridViewComboBoxCell")
                            // if (!s.Contains("texti"))
                            {
                                if (s.Contains(col.HeaderText))
                                {
                                    if (senderGrid.Rows[e.RowIndex].Cells[col.Index].Value != null)
                                    {
                                        string strValue = senderGrid.Rows[e.RowIndex].Cells[col.Index].Value.ToString();
                                        string strText = senderGrid.Rows[e.RowIndex].Cells[col.Index].FormattedValue.ToString();
                                        if (s.Contains("texti"))
                                        {
                                            strSQLSenda += s.Replace("{texti}", strValue) + "'"; // "'%" + strValue + "%' ";
                                        }
                                        else
                                        {
                                            strSQLSenda = strSQLSenda.TrimEnd();
                                            strSQLSenda += strValue + "' ";
                                        }

                                        m_strLeitSkilyrdi += col.HeaderText + " =  '" + strText + "' ";
                                    }
                                    else
                                    {
                                        strVilla += col.HeaderText + Environment.NewLine;
                                        // MessageBox.Show(col.HeaderText);
                                    }

                                }

                            }
                            // if (strType == "System.Windows.Forms.DataGridViewTextBoxCell")
                            //else
                            //{
                            //    // if (senderGrid.Rows[e.RowIndex].Cells[col.Index].Value != null)
                            //     {
                            //         //string strValue = senderGrid.Rows[e.RowIndex].Cells[col.Index].Value.ToString();
                            //         //string strText = senderGrid.Rows[e.RowIndex].Cells[col.Index].FormattedValue.ToString();
                            //         if (s.Contains("texti"))
                            //         {

                            //             strSQLSenda += s.Replace("{texti}", strValue) + "'"; // "'%" + strValue + "%' ";
                            //         }
                            //         m_strLeitSkilyrdi += col.HeaderText + " =  '" + strText + "' ";
                            //     }

                            // }
                        }
                    }
                    else
                    {
                        //string strText = s.Replace("|", "%");
                        //strText = s.Replace("~", "'");
                        if (i != Split.Length)
                        {
                            strSQLSenda += s + "'";
                        }
                        else
                        {
                            strSQLSenda += s;
                        }

                    }
                    i++;
                }


                //select b.Artsnavn, a.Antal, c.Amtsnavn, a.Aar from AGG a, ART_kode b, AMT_kode c where b.artid = '{art_kode:ArtID:ArtsNavn}'and a.ArtID = b.ArtID and a.Aar = '{distinct Aar}'and a.AmtID = '{amt_kode:AmtID:AmtsNavn}'and a.AmtID = c.AmtID
                try
                {

                    DataTable dt = mIdlun.keyraFyrirspurn(strSQLSenda, m_strGagnagrunnur);
                    m_strSQLpanta = strSQLSenda;

                    m_dgvNidurstodur.DataSource = dt;
                    m_grbNidurstodur.Text = string.Format("Það fundust {0} færslur", dt.Rows.Count.ToString("#,##0"));
                    foreach (DataGridViewColumn col in m_dgvNidurstodur.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                    }
                    m_dgvNidurstodur.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    m_dgvNidurstodur.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    m_dgvNidurstodur.RowTemplate.Resizable = DataGridViewTriState.True;
                    m_dgvNidurstodur.RowTemplate.Height = 50;


                }
                catch (Exception x)
                {
                    MessageBox.Show(string.Format("Vantar að velja eftirfarandi breytur {0}{1}", Environment.NewLine, strVilla));
                }
            }
        }

        private void m_btnSetjaIkorfu_Click(object sender, EventArgs e)
        {
            if (m_dgvFyrirspurnir.DataSource != null) //breyta í fjölda niðurstaðna
            {
                if (m_strSQLpanta != string.Empty)
                {
                    DataRow r = m_dtPantad.NewRow();
                    r["heiti"] = m_strOrginal;
                    r["vorsluutgafa"] = m_strGagnagrunnur.Replace("_", ".");
                    r["leitarskilyrdi"] = m_strLeitSkilyrdi;
                    r["sql"] = m_strSQLpanta;
                    r["heitivorslu"] = skjal.titill_3_1_2;
                    m_dtPantad.Rows.Add(r);
                    m_dtPantad.AcceptChanges();
                    m_dgvPantGagnagrunnar.AutoGenerateColumns = false;
                    m_dgvPantGagnagrunnar.DataSource = m_dtPantad;
                    m_tapGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtPantad.Rows.Count);
                    m_strLeitSkilyrdi = string.Empty;
                    //foreach (DataGridViewColumn col in m_dgvPantGagnagrunnar.Columns)
                    //{
                    //    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //}

                }
                else
                {
                    MessageBox.Show("Vantar að keyra fyrirspurn");
                }
                if (m_dtPantad.Rows.Count != 0)
                {
                    m_btnLjukaPontun.Visible = true;
                }

            }
        }

        private void m_btnLjukaPontun_Click(object sender, EventArgs e)
        {
            frmAfgreidsla afgreidsla = new frmAfgreidsla(virkurnotandi, m_dtSkra, m_dtMal, m_dtPantad, m_dsMal);
            afgreidsla.ShowDialog();
            setjaFoldaTaba();
            erPontun();


        }

        private void setjaFoldaTaba()
        {
            DataTable dt = (DataTable)m_dgvPantMalaKerfi.DataSource;
            DataTable dtMalAllt = new DataTable();
            for (int i = 0; i < m_dsMal.Tables.Count; i++)
            {
                if (i == 0)
                    dtMalAllt = m_dsMal.Tables[i].Copy();
                else
                    dtMalAllt.Merge(m_dsMal.Tables[i]);
            }

            int iFjold = dtMalAllt.Rows.Count;
            m_tapMalakrefi.Text = string.Format("Málakerfi ({0})", dtMalAllt.Rows.Count);

            dt = (DataTable)m_dgvPantGagnagrunnar.DataSource;
            iFjold = iFjold + dt.Rows.Count;
            m_tapGagnagrunnar.Text = string.Format("Gagnagrunnur ({0})", dt.Rows.Count);

            dt = (DataTable)m_dgvPantSkraarkerfi.DataSource;
            iFjold = iFjold + dt.Rows.Count;
            m_tapSkráarkerfi.Text = string.Format("SKráakerfi ({0})", dt.Rows.Count);

            m_grbPontun.Text = string.Format("Óafgreitt ({0})", iFjold);

        }

        private void m_dgvPantGagnagrunnar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                switch (senderGrid.Name)
                {
                    case "m_dgvPantGagnagrunnar":
                        if (senderGrid.Columns["colDelete"].Index == e.ColumnIndex)
                        {
                            DialogResult result = MessageBox.Show("Viltu fjarlægja þetta skjal?", "Fjarlægja skjal", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                m_dgvPantGagnagrunnar.Rows.Remove(m_dgvPantGagnagrunnar.Rows[e.RowIndex]);
                                m_dtPantad = (DataTable)m_dgvPantGagnagrunnar.DataSource;
                                m_dtPantad.AcceptChanges();
                                erPontun();
                                setjaFoldaTaba();
                            }
                        }
                        if (senderGrid.Columns["colGagnOpna"].Index == e.ColumnIndex)
                        {
                            string strVarsla = senderGrid.Rows[e.RowIndex].Cells["colHeitiVarsla"].Value.ToString();
                            string strLeit = senderGrid.Rows[e.RowIndex].Cells["colLeitSkilyrdi"].Value.ToString();
                            string strSQL = senderGrid.Rows[e.RowIndex].Cells["colGagnSQL"].Value.ToString();
                            frmGagnagrunnSkoda skoda = new frmGagnagrunnSkoda(strSQL, virkurnotandi, m_strGagnagrunnur, strLeit, m_strOrginal, strVarsla);
                            skoda.ShowDialog();
                        }
                        break;
                    case "m_dgvPantSkraarkerfi":
                        if (senderGrid.Columns["colSkraDelete"].Index == e.ColumnIndex)
                        {
                            DialogResult result = MessageBox.Show("Viltu fjarlægja þetta skjal?", "Fjarlægja skjal", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                m_dgvPantSkraarkerfi.Rows.Remove(m_dgvPantSkraarkerfi.Rows[e.RowIndex]);
                                m_dtSkra = (DataTable)m_dgvPantSkraarkerfi.DataSource;
                                m_dtSkra.AcceptChanges();
                                erPontun();
                                setjaFoldaTaba();
                            }
                        }
                        if (senderGrid.Columns["colSkraOpna"].Index == e.ColumnIndex)
                        {
                            var p = new Process();
                            string strSlod = string.Empty;
                            string strVorsluutgafa = senderGrid.Rows[e.RowIndex].Cells["colSkraVarslaID"].Value.ToString();
                            cVorsluutgafur utgafur = new cVorsluutgafur();
                            utgafur.m_bAfrit = virkurnotandi.m_bAfrit;
                            utgafur.getVörsluútgáfu(strVorsluutgafa);
                            strSlod = utgafur.slod;


                            string strValid = senderGrid.Rows[e.RowIndex].Cells["colSkraID"].Value.ToString();
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
                    case "m_dgvPantMalaKerfi":
                        if (senderGrid.Columns["colMalDelete"].Index == e.ColumnIndex)
                        {
                            DialogResult result = MessageBox.Show("Viltu fjarlægja þetta skjal?", "Fjarlægja skjal", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {

                                string strGrunnur = m_dgvPantMalaKerfi.Rows[e.RowIndex].Cells["colMalGagnagrunnur"].Value.ToString();
                                string strDocID = m_dgvPantMalaKerfi.Rows[e.RowIndex].Cells["colMalSkraID"].Value.ToString();
                                string strEXP = "documentid = '" + strDocID + "'";
                                DataRow[] fRow = m_dsMal.Tables[strGrunnur].Select(strEXP);
                                if (fRow.Length != 0)
                                {
                                    fRow[0].Delete();
                                    m_dsMal.Tables[strGrunnur].AcceptChanges();
                                }
                                m_dgvPantMalaKerfi.Rows.Remove(m_dgvPantMalaKerfi.Rows[e.RowIndex]);
                                m_dtMal = (DataTable)m_dgvPantMalaKerfi.DataSource;
                                m_dtMal.AcceptChanges();
                                erPontun();
                                setjaFoldaTaba();
                            }
                        }
                        if (senderGrid.Columns["colMalOpna"].Index == e.ColumnIndex)
                        {
                            var p = new Process();

                            string strSlod = senderGrid.Rows[e.RowIndex].Cells["colMalSlod"].Value.ToString();
                            string[] strSkra = Directory.GetFiles(strSlod);
                            if (strSkra.Length > 0)
                            {
                                strSlod = strSkra[0].ToString();
                            }


                            p.StartInfo = new ProcessStartInfo(strSlod)
                            {
                                UseShellExecute = true
                            };
                            p.Start();
                        }
                        break;
                    default:
                        break;
                }
            }


        }

        private void m_btnLoka_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
