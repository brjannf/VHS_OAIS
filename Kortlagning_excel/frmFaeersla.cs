using cClassOAIS;
using DocumentFormat.OpenXml.Vml;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;
using Path = System.IO.Path;

namespace Kortlagning_excel
{
    public partial class frmFaeersla : Form
    {
        DataTable m_dtGogn = new DataTable();
        DataTable m_dtExcell = new DataTable();
        string m_strExcelSkjal = string.Empty;
        string m_strExcellGagn = string.Empty;
        string m_strStatus = string.Empty;
        string m_strID = string.Empty;
        string m_strAudkenni = string.Empty;    
        DataRow m_drExcel;
        DataRow m_drGagnagrunnur;
        cKortlagningar_excel cKort = new cKortlagningar_excel();

        public frmFaeersla()
        {
            InitializeComponent();
        }
        public frmFaeersla(DataRow row, string strExcellGagn, string strSlodExcell)
        {
            InitializeComponent();

            // Prepare DataTable
            m_dtGogn.Columns.Add("Titill", typeof(string));
            m_dtGogn.Columns.Add("Gildi", typeof(string));

            m_strExcelSkjal = strSlodExcell;
            m_strExcellGagn = strExcellGagn;

            // Fill DataTable
            foreach (DataColumn col in row.Table.Columns)
            {
                DataRow r = m_dtGogn.NewRow();
                r["Titill"] = col.ColumnName;
                r["Gildi"] = row[col] != null ? row[col].ToString() : string.Empty;
                if (r["titill"].ToString() == "status")
                {
                    m_strStatus = r["Gildi"].ToString();
                }
                if (r["titill"].ToString() == "id")
                {
                    m_strID = r["Gildi"].ToString();
                }
                if(r["titill"].ToString() == "Audkenni")
                {
                    m_strAudkenni = r["Gildi"].ToString();
                }
                m_dtGogn.Rows.Add(r);
            }

            //ná í röð excel
            lesaExcel();
            if (m_strStatus != "insert")
            {
                string strExp = "id = '" + m_dtGogn.Rows[0]["Gildi"].ToString() + "'";
                DataRow[] rowus = m_dtExcell.Select(strExp);
                if (rowus.Length != 0)
                {
                    m_drExcel = rowus[0];
                }
            }
            else
            {
                m_drExcel = null;
            }


            //ná í röð gagnagrunni
            if (m_dtGogn.Rows[0]["Gildi"].ToString() != string.Empty)
            {
                int iID = Convert.ToInt32(m_dtGogn.Rows[0]["Gildi"]);
                DataTable dt = cKort.getKortHera(iID);
                if (dt.Rows.Count != 0)
                {
                    m_drGagnagrunnur = dt.Rows[0];
                }
            }


            // Bind to DataGridView
            m_dgvFaersla.DataSource = m_dtGogn;

            if (m_strExcellGagn == "excel")
            {
                m_btnExcelGagn.Text = "Excell";
            }
            else
            {
                m_btnExcelGagn.Text = "Gagnagrunnur";
            }

            ////rúlla yfir gagnasett og bera saman
            //int i = 0;
            //foreach (DataGridViewRow rr in m_dgvFaersla.Rows)
            //{
            //    if (rr.Cells["colTitill"].Value.ToString() != "status") 
            //    {
            //        string strGildi = rr.Cells["colGildi"].Value.ToString();
            //        string strGildiExcel = m_drExcel[i].ToString();
            //        string strGildiGagnagrunnur = m_drGagnagrunnur[i].ToString();
            //        if (strGildiGagnagrunnur != strGildiExcel)
            //        {
            //            rr.Cells["colGildi"].Style.BackColor = Color.LightYellow;
            //        }
            //    }

            //    i++;
            //}
        }

        private void fyllForm(DataRow row)
        {
            m_dtGogn.Rows.Clear();
            foreach (DataColumn col in row.Table.Columns)
            {
                DataRow r = m_dtGogn.NewRow();
                r["Titill"] = col.ColumnName;
                r["Gildi"] = row[col] != null ? row[col].ToString() : string.Empty;
                m_dtGogn.Rows.Add(r);

            }
            string strExp = "Titill = 'status'";
            if (m_dtGogn.Select(strExp).Length == 0)
            {
                DataRow rStatus = m_dtGogn.NewRow();
                rStatus["Titill"] = "status";
                rStatus["Gildi"] = m_strStatus;
                m_dtGogn.Rows.Add(rStatus);
            }
            else
            {
                m_dtGogn.Select(strExp)[0]["Gildi"] = m_strStatus;
            }
        }

        private void m_btnVista_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)m_dgvFaersla.DataSource;
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["Titill"].ToString())
                {
                    case "id":
                        if (dr["Gildi"].ToString() != string.Empty)
                        {
                            cKort.id = Convert.ToInt32(dr["Gildi"]);
                        }

                        break;
                    case "Heradsskjalasafn":
                        cKort.Heradsskjalasafn = dr["Gildi"].ToString();
                        break;
                    case "Audkenni":
                        cKort.Audkenni = dr["Gildi"].ToString();
                        break;
                    case "Klasi":
                        cKort.Klasi = dr["Gildi"].ToString();
                        break;
                    case "Sveitarfelag":
                        cKort.Sveitarfelag = dr["Gildi"].ToString();
                        break;
                    case "Afhendingarskyldur_adili":
                        cKort.Afhendingarskyldur_adili = dr["Gildi"].ToString();
                        break;
                    case "Heiti_kerfis":
                        cKort.Heiti_kerfis = dr["Gildi"].ToString();
                        break;
                    case "Heiti_kerfis_ext":
                        cKort.Heiti_kerfis_ext = dr["Gildi"].ToString();
                        break;
                    case "Rafraen_sofn":
                        cKort.Rafraen_sofn = dr["Gildi"].ToString();
                        break;
                    case "Hlutverk_kerfis":
                        cKort.Hlutverk_kerfis = dr["Gildi"].ToString();
                        break;
                    case "Byrgi_og_umsjon":
                        cKort.Byrgi_og_umsjon = dr["Gildi"].ToString();
                        break;
                    case "Skrifstofa_Deild_Starfseining":
                        cKort.Skrifstofa_Deild_Starfseining = dr["Gildi"].ToString();
                        break;
                    case "Tengilidur_skrifstofudeildar_starfseiningar":
                        cKort.Tengilidur_skrifstofudeildar_starfseiningar = dr["Gildi"].ToString();
                        break;
                    case "thjonustuaili_Birgi":
                        cKort.thjonustuaili_Birgi = dr["Gildi"].ToString();
                        break;
                    case "Hysingaradili":
                        cKort.Hysingaradili = dr["Gildi"].ToString();
                        break;
                    case "Tekid_notkun_dags":
                        cKort.Tekid_notkun_dags = dr["Gildi"].ToString();
                        break;
                    case "Tilkynnt_dags":
                        cKort.Tilkynnt_dags = dr["Gildi"].ToString();
                        break;
                    case "Vardveisla_kerfis":
                        cKort.Vardveisla_kerfis = dr["Gildi"].ToString();
                        break;
                    case "staerd":
                        cKort.staerd = dr["Gildi"].ToString();
                        break;
                    case "Notkun_stada":
                        cKort.Notkun_stada = dr["Gildi"].ToString();
                        break;
                    case "Athugasemdir":
                        cKort.Athugasemdir = dr["Gildi"].ToString();
                        break;
                    case "Afhendingaar":
                        cKort.Afhendingaar = dr["Gildi"].ToString();
                        break;
                    case "Noteringar":
                        cKort.Noteringar = dr["Gildi"].ToString();
                        break;
                    default:
                        break;
                }
            }
            cKort.vista();
            vistaExcell();
            cKort.hreinsaHlut();
        }



        // Pseudocode / Plan (detailed):
        // 1. Replace the existing vistaExcell method to ensure all Excel COM objects are properly released.
        // 2. Create local variables for Excel.Application, Workbook, Worksheet and Excel.Range where needed.
        // 3. Wrap the Excel operations in try/catch/finally to ensure cleanup on success or failure.
        // 4. When writing cells, obtain a Range for each cell and release that Range immediately after use.
        // 5. When deleting rows, obtain a Range for the row, call Delete(), then release that Range.
        // 6. Save the workbook after modifications (in try or before cleanup) and ensure Close() is called.
        // 7. Quit the Excel application, release all COM objects with System.Runtime.InteropServices.Marshal.ReleaseComObject.
        // 8. Set object references to null and force GC.Collect() and GC.WaitForPendingFinalizers() twice to ensure COM cleanup.
        // 9. Show the existing "Búið" message after cleanup (or show exception message in catch).
        // 10. Keep the existing 3 second delay (await Task.Delay(3000)) as original code did for COM timing.

        // Replaced method:
        private async void vistaExcell()
        {
            Excel.Application excel = null;
            Excel.Workbook wb = null;
            Excel.Worksheet xlWorkSheet = null;

            try
            {
                excel = new Excel.Application
                {
                    Interactive = true
                };

                string strSkjal = m_strExcelSkjal;
                wb = excel.Workbooks.Open(strSkjal);
                xlWorkSheet = (Excel.Worksheet)wb.Worksheets.get_Item(1);

                DataTable dt = cKort.getKortHera(m_strAudkenni);
                int iRow = 2;

                // keep original small delay to let COM catch up
                await Task.Delay(3000);

                // Write data into worksheet, releasing Range objects immediately
                foreach (DataRow r in dt.Rows)
                {
                    int iCol = 1;
                    foreach (DataColumn column in dt.Columns)
                    {
                        Excel.Range cell = null;
                        try
                        {
                            cell = (Excel.Range)xlWorkSheet.Cells[iRow, iCol];
                            cell.Value2 = r[column].ToString();
                        }
                        finally
                        {
                            if (cell != null)
                            {
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(cell);
                                cell = null;
                            }
                        }
                        iCol++;
                    }
                    iRow++;
                }

                // If Excel file has more rows than database, delete the extra rows
                if (m_dtExcell.Rows.Count > dt.Rows.Count)
                {
                    int iRowDelete = m_dtExcell.Rows.Count - dt.Rows.Count;
                    for (int i = 0; i < iRowDelete; i++)
                    {
                        Excel.Range delRow = null;
                        try
                        {
                            // Delete the row following the last database row (Sheet rows are 1-based; header assumed at row 1)
                            delRow = (Excel.Range)xlWorkSheet.Rows[dt.Rows.Count + 2];
                            delRow.Delete();
                        }
                        finally
                        {
                            if (delRow != null)
                            {
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(delRow);
                                delRow = null;
                            }
                        }
                    }
                }

                // Save workbook
                wb.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close workbook if open
                try
                {
                    if (wb != null)
                    {
                        wb.Close(false);
                    }
                }
                catch
                {
                    // ignore exceptions on close
                }

                // Quit Excel application
                try
                {
                    if (excel != null)
                    {
                        excel.Quit();
                    }
                }
                catch
                {
                    // ignore exceptions on quit
                }

                // Release COM objects in reverse order of creation
                if (xlWorkSheet != null)
                {
                    try
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                    }
                    catch { }
                    finally { xlWorkSheet = null; }
                }

                if (wb != null)
                {
                    try
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                    }
                    catch { }
                    finally { wb = null; }
                }

                if (excel != null)
                {
                    try
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    }
                    catch { }
                    finally { excel = null; }
                }

                // Force garbage collection to finalize and free COM references
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            MessageBox.Show("Búið");
        }


        private void m_dgvFaersla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow rr in m_dgvFaersla.Rows)
            {
                if (rr.Cells["colTitill"].Value.ToString() == "id" || rr.Cells["colTitill"].Value.ToString() == "Audkenni" || rr.Cells["colTitill"].Value.ToString() == "Heradsskjalasafn" || rr.Cells["colTitill"].Value.ToString() == "Klasi" || rr.Cells["colTitill"].Value.ToString() == "status")
                {
                    rr.ReadOnly = true;
                    rr.DefaultCellStyle.BackColor = Color.LightPink;
                }
                if (rr.Cells["colTitill"].Value.ToString() != "status")
                {
                    string strGildi = rr.Cells["colGildi"].Value.ToString();
                    string strGildiExcel = string.Empty;
                    if (m_drExcel != null)
                    {
                        strGildiExcel = m_drExcel[i].ToString();
                    }
                    string strGildiGagnagrunnur = string.Empty;
                    if (m_drGagnagrunnur != null)
                    {
                        strGildiGagnagrunnur = m_drGagnagrunnur[i].ToString();
                    }
                    if (strGildiGagnagrunnur != strGildiExcel)
                    {
                        rr.Cells["colGildi"].Style.BackColor = Color.LightYellow;
                    }
                }

                i++;
            }
        }

        private void lesaExcel()
        {

            m_dtExcell.Rows.Clear();
            m_dtExcell.Columns.Clear();
            using (OleDbConnection conn = new OleDbConnection())
            {

                string Import_FileName = m_strExcelSkjal;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + "Sheet1" + "$]";
                    comm.Connection = conn;
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(m_dtExcell);

                        // Ensure m_dtMySQL exists
                        if (m_dtExcell == null)
                        {
                            m_dtExcell = new System.Data.DataTable();
                        }

                        // Ensure "status" column exists and is positioned at the end
                        if (!m_dtExcell.Columns.Contains("status"))
                        {
                            m_dtExcell.Columns.Add("status");
                        }
                        //else
                        //{
                        //    // Move "status" to the last column
                        //    m_dtExcell.Columns["status"].SetOrdinal(m_dtMySQL.Columns.Count - 1);

                        //}

                    }

                    conn.Close();
                    comm.Dispose();
                }
            }

        }
        private void m_btnExcelGagn_Click(object sender, EventArgs e)
        {
            //swappa á millil excells og gagnagrunns

            if (m_strExcellGagn == "excel")
            {
                m_btnExcelGagn.Text = "Gagnagrunnur";
                m_strExcellGagn = "gagnagrunnur";
                //Sækja gögn úr gagnagrunni
                if (m_dtGogn.Rows[0]["Gildi"].ToString() != string.Empty)
                {
                    int iID = Convert.ToInt32(m_dtGogn.Rows[0]["Gildi"]);
                    DataTable dt = cKort.getKortHera(iID);
                    if (dt.Rows.Count != 0)
                    {
                        m_drGagnagrunnur = dt.Rows[0];
                       
                        fyllForm(dt.Rows[0]);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Færsla {0} hefur verið eytt úr Gagnagrunni", iID));
                    }
                }
                else
                {
                    MessageBox.Show("Eftir að vista færslu í gagnagrunn");
                }


            }
            else
            {
                m_btnExcelGagn.Text = "Excell";
                m_strExcellGagn = "excel";
                lesaExcel();
                if (m_dtGogn.Rows[0]["Gildi"].ToString() != string.Empty)
                {
                    string strExp = "id = '" + m_dtGogn.Rows[0]["Gildi"].ToString() + "'";
                    DataRow[] rowus = m_dtExcell.Select(strExp);
                    if (rowus.Length != 0)
                    {
                        m_drExcel = rowus[0];
                        fyllForm(rowus[0]);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Færsla {0} hefur verið eytt úr excel", m_dtGogn.Rows[0]["Gildi"].ToString()));
                    }
                }



            }
        }

        private void m_btnEyda_Click(object sender, EventArgs e)
        {
            //Eyða færslu bæði úr gagnagrunni og excel
           // cKort.getKortHera( Convert.ToInt32( m_strID ) );
           DialogResult result = MessageBox.Show("Ertu viss um að þú viljir eyða þessari færslu bæði úr gagnagrunni og excel skjali?", "Eyða færslu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                cKort.eyda(Convert.ToInt32(m_strID));
                vistaExcell();
            }
           this.Close();
        }
    }
}
