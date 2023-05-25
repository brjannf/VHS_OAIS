using cClassOAIS;
//using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        string m_strLeitSkilyrdi  = string.Empty;
        
        DataTable m_dtFyrirspurnir = new DataTable();   
        cMIdlun mIdlun= new cMIdlun();
        public DataTable m_dtPantad = new DataTable();
        public frmGagnagrunnur()
        {
            InitializeComponent();
        }
        public frmGagnagrunnur(string strGagnagrunnur, string strOrginalHeiti, DataTable dtGrunnar, DataTable dtSkrar, DataTable dtMal)
        {
            InitializeComponent();
            m_dtPantad = dtGrunnar.Clone();
            foreach(DataRow r in dtGrunnar.Rows)
            {
                m_dtPantad.ImportRow(r);
            }

            this.WindowState = FormWindowState.Maximized;
            m_strGagnagrunnur = strGagnagrunnur;
            m_strOrginal = strOrginalHeiti;
            m_dtFyrirspurnir = mIdlun.getGagnagrunnaFyrirSpurnir(strGagnagrunnur);
            fyllaFyrirspurnaform();
            this.Text = m_strOrginal;
            m_dgvPantSkraarkerfi.DataSource = dtSkrar;
            m_tapSkráarkerfi.Text = string.Format("Skráarkerfi ({0})", dtSkrar.Rows.Count);
            foreach (DataGridViewColumn col in m_dgvPantSkraarkerfi.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            m_dgvPantMalaKerfi.DataSource = dtMal;
            m_tapMalakrefi.Text = string.Format("Málakerfi ({0})", dtMal.Rows.Count);
            foreach (DataGridViewColumn col in m_dgvPantMalaKerfi.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
          
            m_dgvPantGagnagrunnar.DataSource = m_dtPantad;
            m_tapGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", dtGrunnar.Rows.Count);
            foreach (DataGridViewColumn col in m_dgvPantGagnagrunnar.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if(m_dtPantad.Columns.Count != 5)
            {
                m_dtPantad.Columns.Add("Heiti");
                m_dtPantad.Columns.Add("vorsluutgafa");
                m_dtPantad.Columns.Add("leitarskilyrði");
                m_dtPantad.Columns.Add("sql");
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
                string strEXp = "nr='" + nr["nr"].ToString() +"'";
                DataRow[] fRow = m_dtFyrirspurnir.Select(strEXp);
                int i = 0;
                foreach (DataRow r in fRow)
                {
                    if (!r["lysing"].ToString().Contains("færibreyta"))
                    {
                        dtClone.ImportRow(r);
                        strSQL = r["fyrirspurn"].ToString();
                        i++;

                    }
                    else if (nr["nr"].ToString() == "1" )
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
            DataGridViewButtonColumn Keyra  = new DataGridViewButtonColumn();
            Keyra.Name = "keyra";
            Keyra.Text = "Keyra fyrirspurn";
            Keyra.UseColumnTextForButtonValue = true;   
            m_dgvFyrirspurnir.CellClick += keyrafyrirspurn_CellClick;
            if (m_dgvFyrirspurnir.Columns["uninstall_column"] == null)
            {
                m_dgvFyrirspurnir.Columns.Insert(m_dgvFyrirspurnir.Columns.Count-1, Keyra);
            }
            m_dgvFyrirspurnir.DataSource = dtClone; // dtClone;
            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)m_dgvFyrirspurnir["dalkur", 1];
            cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            cell.ReadOnly = true;

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
                foreach(string s in Split) 
                {
                    if (s.Contains("{"))
                    {
                        foreach (DataGridViewColumn col in senderGrid.Columns)
                        {
                            string strType = col.CellType.ToString();
                            if (strType == "System.Windows.Forms.DataGridViewComboBoxCell")
                            {
                                if(s.Contains(col.HeaderText))
                                {
                                    if(senderGrid.Rows[e.RowIndex].Cells[col.Index].Value != null)
                                    {
                                        string strValue = senderGrid.Rows[e.RowIndex].Cells[col.Index].Value.ToString();
                                        string strText = senderGrid.Rows[e.RowIndex].Cells[col.Index].FormattedValue.ToString();
                                        strSQLSenda += "'" + strValue + "' ";
                                        m_strLeitSkilyrdi += col.HeaderText + " =  '" + strText + "' ";
                                    }
                                    else
                                    {
                                        strVilla += col.HeaderText + Environment.NewLine;
                                       // MessageBox.Show(col.HeaderText);
                                    }
                                  
                                }
                             
                            }
                        }
                    }
                    else
                    {
                        strSQLSenda += s + " ";
                    }
                  
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
                }
                catch (Exception x)
                {
                    MessageBox.Show(string.Format("Vantar að velja eftirfarandi breytur {0}{1}", Environment.NewLine, strVilla));
                }
            }
        }

        private void m_btnSetjaIkorfu_Click(object sender, EventArgs e)
        {
            if(m_dgvFyrirspurnir.DataSource != null) //breyta í fjölda niðurstaðna
            {
                if (m_strSQLpanta != string.Empty)
                {
                    DataRow r = m_dtPantad.NewRow();
                    r["heiti"] = m_strOrginal;
                    r["vorsluutgafa"] = m_strGagnagrunnur.Replace("_", ".");
                    r["leitarskilyrði"] = m_strLeitSkilyrdi;
                    r["sql"] = m_strSQLpanta;
                    m_dtPantad.Rows.Add(r);
                    m_dtPantad.AcceptChanges();
                    m_dgvPantGagnagrunnar.DataSource = m_dtPantad;
                    m_tapGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtPantad.Rows.Count);
                    foreach (DataGridViewColumn col in m_dgvPantGagnagrunnar.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                }
                else
                {
                    MessageBox.Show("Vantar að keyra fyrirspurn");
                }
            

            }
        }
    }
}
