namespace Kortlagning_excel
{
    using cClassOAIS;
    using DocumentFormat.OpenXml.Drawing.Diagrams;
    using DocumentFormat.OpenXml.Wordprocessing;
    using IronXL;
    using Microsoft.Office.Interop.Excel;
    using System.Data;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using DataTable = System.Data.DataTable;
    using Excel = Microsoft.Office.Interop.Excel;

    //using Excell = Microsoft.Office.Interop.Excel; 
    public partial class Form1 : Form
    {
        private System.Data.DataTable m_dtExcell = new System.Data.DataTable();
        private System.Data.DataTable m_dtMappa = new System.Data.DataTable();
        private System.Data.DataTable m_dtMySQL = new System.Data.DataTable();
        private cKortlagningar_excel kortlagning = new cKortlagningar_excel();
        private string m_strMappa = string.Empty;
        private string m_strExcelSkjal = string.Empty;
        private string m_strHeradsskjalasafn = string.Empty;
        private string m_strHerAudkenni = string.Empty;
        private string m_strExcelGrunnur = "excel";
        private int m_iTakkiIndex = 0;
        private ToolTip _cellToolTip;
        public Form1()
        {
            InitializeComponent();
            //    m_strMappa = "C:\\Users\\brjann\\OneDrive - Braud\\Documents\\9. Kortlagningar\\komid\\Skyrsla\\Heradsskjalasofn"; //onedrive
            m_strMappa = "C:\\Users\\brjann\\Miðstöð héraðsskjalasafna um rafræna skjalavörslu\\MHR - Documents\\09 Kortlagningar\\Heradsskjalasofn"; //sharepoint
            m_dtMappa.Columns.Add("ID");
            m_dtMappa.Columns.Add("slod");
            // m_dtExcell.Columns.Add("status");

            fyllaTakka();

            _cellToolTip = new ToolTip
            {
                ShowAlways = true,
                // These properties are optional when using ToolTip.Show(...)
                AutomaticDelay = 0,
                InitialDelay = 0,
                ReshowDelay = 0
            };

            // Disable default delayed DataGridView tooltips
            m_dgvExcelSkjal.ShowCellToolTips = false;

            // Wire events
            m_dgvExcelSkjal.CellMouseEnter += m_dgvExcelSkjal_CellMouseEnter;
            m_dgvExcelSkjal.CellMouseLeave += m_dgvExcelSkjal_CellMouseLeave;
            m_dgvExcelSkjal.Scroll += (s, ev) => _cellToolTip.Hide(m_dgvExcelSkjal);
        }

        private void fyllaTakka()
        {
            DirectoryInfo difo = new DirectoryInfo(m_strMappa);
            //   FileInfo[] fifo = difo.GetFiles();
            foreach (FileInfo fi in difo.GetFiles())
            {
                DataRow r = m_dtMappa.NewRow();
                r["ID"] = fi.Name;
                r["slod"] = fi.FullName;
                m_dtMappa.Rows.Add(r);
                m_dtMappa.AcceptChanges();
            }
            m_dgvMappaSkjol.DataSource = m_dtMappa;
        }
        private void m_btnOpnaExcel_Click(object sender, EventArgs e)
        {
            //breyta þessum takk í swap á milli excels og gagnagrunns
            ExcelGagnagrunnur();
            //if (m_btnExcelGrunnur.Text == "Excel skrár")
            //{
            //    m_btnExcelGrunnur.Text = "Gagnagrunnur";
            //    m_strExcelGrunnur = "mysql";

            //    fyllaExcelGrid();
            //}
            //else
            //{
            //    m_btnExcelGrunnur.Text = "Excel skrár";
            //    m_strExcelGrunnur = "excel";
            //    lesaExcel(m_strExcelSkjal);
            //    fyllaExcelGrid();

            //}
        }

        private void ExcelGagnagrunnur()
        {
            //breyta þessum takk í swap á milli excels og gagnagrunns

            if (m_btnExcelGrunnur.Text == "Excel skrár")
            {
                m_btnExcelGrunnur.Text = "Gagnagrunnur";
                m_strExcelGrunnur = "mysql";

                fyllaExcelGrid();
            }
            else
            {
                m_btnExcelGrunnur.Text = "Excel skrár";
                m_strExcelGrunnur = "excel";
                lesaExcel(m_strExcelSkjal);
                fyllaExcelGrid();

            }
        }
        //private void lesaGagnagrunn()
        //{
        //    m_dtExcell = kortlagning.getKortHera(m_strHerAudkenni);
        //    m_dtExcell.Columns.Add("status");
        //    //  m_dgvExcelSkjal.DataSource = m_dtMySQL;
        //}
        private bool fyllaExcelGrid()
        {
            bool bRet = false;
            if (m_dtExcell.Rows.Count > 0)
            {
                m_strHeradsskjalasafn = m_dtExcell.Rows[0]["heradsskjalasafn"].ToString();
                m_strHerAudkenni = m_dtExcell.Rows[0]["Audkenni"].ToString();
                m_lblHeradsSkjalaSafn.Text = m_strHeradsskjalasafn;
                m_dtMySQL = kortlagning.getKortHera(m_strHerAudkenni);
                // Ensure m_dtMySQL exists
                if (m_dtMySQL == null)
                {
                    m_dtMySQL = new System.Data.DataTable();
                }

                // Ensure "status" column exists and is positioned at the end
                if (!m_dtMySQL.Columns.Contains("status"))
                {
                    m_dtMySQL.Columns.Add("status");
                }
                else
                {
                    // Move "status" to the last column
                    m_dtMySQL.Columns["status"].SetOrdinal(m_dtMySQL.Columns.Count - 1);
                }
                //samkeyra m_dtExcell og m_dtMySQL og skrá breytingar einhvernveginnz
                int iUpdate = 0;
                int iExcell = m_dtExcell.Rows.Count;
                int iMySQL = m_dtMySQL.Rows.Count;
                string strIDDel = string.Empty;
                foreach (DataRow r in m_dtExcell.Rows)
                {
                    if (iMySQL > iExcell)
                    {
                        foreach (DataRow r2 in m_dtMySQL.Rows)
                        {
                            string strID = r2["ID"].ToString();
                            string strExp = "ID='" + strID + "'";
                            DataRow[] fRow = m_dtExcell.Select(strExp);
                            if (fRow.Length == 0)
                            {
                                //búið að eyða úr excell
                                if (!strIDDel.Contains(strID + ":"))
                                {
                                    strIDDel += strID + ":";
                                    bRet = true;
                                }

                            }
                        }
                    }



                    if (string.IsNullOrEmpty(r["ID"].ToString()))
                    {
                        r["status"] = "insert";
                        bRet = true;
                    }
                    else
                    {
                        string strExcelData = string.Empty;
                        string strMysqlData = string.Empty;
                        string strExp = "ID='" + r["ID"].ToString() + "'";
                        DataRow[] fRow = m_dtMySQL.Select(strExp);
                        if (fRow.Length == 1)
                        {
                            int i = 0;
                            foreach (var item in fRow[0].ItemArray)
                            {

                                if (i != fRow[0].ItemArray.Length - 1)
                                {

                                    string strName = m_dtMySQL.Columns[i].ColumnName;
                                    if (strName != "status" && strName != "Noteringar")
                                    {
                                        strMysqlData += strName + "~" + item.ToString() + "|";
                                    }


                                }

                                i++;

                            }


                        }
                        foreach (DataColumn column in m_dtExcell.Columns)
                        {
                            if (column.ColumnName != "status" && column.ColumnName != "Noteringar")
                            {
                                strExcelData += column.ColumnName + "~" + r[column].ToString() + "|";
                            }

                        }

                        if (strMysqlData.Trim() != strExcelData.Trim())
                        {
                            r["status"] = "update";
                            iUpdate++;
                            if(fRow.Length != 0)
                            {
                                fRow[0]["status"] = "update";
                                bRet = true;
                            }
                         
                            //var file1Lines = Convert.ToChar(strMysqlData);
                            //var file2Lines = Convert.ToChar(strExcelData);
                            //  IEnumerable<String> inFirstNotInSecond = file1Lines.Except(file2Lines);
                            //  IEnumerable<String> inSecondNotInFirst = file2Lines.Except(file1Lines)
                        }
                        else
                        {
                            r["status"] = "óbreytt";
                            fRow[0]["status"] = "óbreytt";
                        }

                    }
                }

                System.Data.DataTable dtClone = m_dtMySQL.Clone();
                // dtClone.Columns.Add("status");
                if (strIDDel != string.Empty)
                {
                    string[] strSplit = strIDDel.Split(":");

                    foreach (string strSplit2 in strSplit)
                    {
                        if (strSplit2 != string.Empty)
                        {
                            string strExpDex = "ID='" + strSplit2 + "'";
                            DataRow[] fRowDel = m_dtMySQL.Select(strExpDex);
                            if (fRowDel.Length == 1)
                            {
                                dtClone.ImportRow(fRowDel[0]);
                                //m_dtExcell.Rows.Add(fRowDel[0].ItemArray);
                                // string strbla = dtClone.Rows[0][dtClone.Columns.Count - 1].ToString();
                            }
                        }

                    }

                }
                if (m_strExcelGrunnur == "excel")
                {
                    foreach (DataRow row in m_dtExcell.Rows)
                    {
                        dtClone.ImportRow(row);

                    }
                }
                else
                {
                    foreach (DataRow row in m_dtMySQL.Rows)
                    {
                        dtClone.ImportRow(row);

                    }
                }


                m_lblUpdate.Text = string.Format("Uppfæra: {0} færslur", iUpdate);
                m_lblExcell.Text = string.Format("Færslur í excelskjali: {0} færslur", iExcell);
                m_lblMySQL.Text = string.Format("Færslur í grunni: {0} færslur", iMySQL);
                m_dgvExcelSkjal.DataSource = dtClone; // m_dtExcell;
                foreach (DataGridViewRow r in m_dgvExcelSkjal.Rows)
                {
                    if (r.Cells["status"].Value.ToString() == "update")
                    {
                        r.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        //rúlla í gegnum dálka og tékka á hvar er breytt?
                        int i = 0;
                        foreach (DataGridViewCell cell in r.Cells)
                        {
                            string strID = r.Cells["id"].Value.ToString();
                            string strExcelGildi = cell.Value.ToString();

                            string strExp = "ID='" + strID + "'";
                            if (m_strExcelGrunnur == "excel")
                            {
                                DataRow[] fRow = m_dtMySQL.Select(strExp);
                                if (fRow.Length != 0)
                                {


                                    if (i < fRow[0].ItemArray.Length)
                                    {
                                        string strMySQLGildi = fRow[0].ItemArray[i].ToString();

                                        if (strExcelGildi != strMySQLGildi)
                                        {
                                            cell.Style.BackColor = System.Drawing.Color.LightBlue;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DataRow[] fRow = m_dtExcell.Select(strExp);
                                if (i < fRow[0].ItemArray.Length)
                                {
                                    string strMySQLGildi = fRow[0].ItemArray[i].ToString();

                                    if (strExcelGildi != strMySQLGildi)
                                    {
                                        cell.Style.BackColor = System.Drawing.Color.LightBlue;
                                    }
                                }
                            }



                            i++;

                        }

                    }
                    if (r.Cells["status"].Value.ToString() == "óbreytt")
                    {
                        r.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                    if (r.Cells["status"].Value.ToString() == "insert")
                    {
                        r.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                    }
                    if (r.Cells["status"].Value.ToString() == "")
                    {
                        r.DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                    }
                }
            }
            return bRet;
        }
        private void lesaExcel(string strSlod)
        {
          
            m_dtExcell.Rows.Clear();
            m_dtExcell.Columns.Clear();
            using (OleDbConnection conn = new OleDbConnection())
            {

                string Import_FileName = strSlod;
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

        private void m_btnVista_Click(object sender, EventArgs e)
        {
            cKortlagningar_excel kortExcel = new cKortlagningar_excel();
            System.Data.DataTable dtVista = (System.Data.DataTable)m_dgvExcelSkjal.DataSource;
            string strExp = "status= 'update'";
            m_prbPublish.Value = 0;
            m_prbPublish.Maximum = dtVista.Rows.Count;
            m_prbPublish.Step = 1;
            foreach (DataRow r in dtVista.Rows)
            {
                if (r["status"].ToString() != "óbreytt")
                {
                    if (r["status"] != DBNull.Value) //update insert
                    {


                        if (r["id"] != DBNull.Value)
                        {
                            kortExcel.id = Convert.ToInt32(r["id"]);
                        }

                        kortExcel.Heradsskjalasafn = r["Heradsskjalasafn"].ToString();
                        kortExcel.Audkenni = r["Audkenni"].ToString();
                        kortExcel.Klasi = r["Klasi"].ToString();
                        kortExcel.Sveitarfelag = r["Sveitarfelag"].ToString();
                        kortExcel.Afhendingarskyldur_adili = r["Afhendingarskyldur_adili"].ToString();
                        kortExcel.Heiti_kerfis = r["Heiti_kerfis"].ToString();
                        kortExcel.Heiti_kerfis_ext = r["Heiti_kerfis_ext"].ToString();
                        kortExcel.Rafraen_sofn = r["Rafraen_sofn"].ToString();
                        kortExcel.Hlutverk_kerfis = r["Hlutverk_kerfis"].ToString();
                        kortExcel.Byrgi_og_umsjon = r["Byrgi_og_umsjon"].ToString();
                        kortExcel.Skrifstofa_Deild_Starfseining = r["Skrifstofa_Deild_Starfseining"].ToString();
                        kortExcel.Tengilidur_skrifstofudeildar_starfseiningar = r["Tengilidur_skrifstofudeildar_starfseiningar"].ToString();
                        kortExcel.thjonustuaili_Birgi = r["thjonustuaili_Birgi"].ToString();
                        kortExcel.Hysingaradili = r["Hysingaradili"].ToString();
                        kortExcel.Tekid_notkun_dags = r["Tekid_notkun_dags"].ToString();
                        kortExcel.Tilkynnt_dags = r["Tilkynnt_dags"].ToString();
                        kortExcel.Vardveisla_kerfis = r["Vardveisla_kerfis"].ToString();
                        kortExcel.staerd = r["staerd"].ToString();
                        kortExcel.Notkun_stada = r["Notkun_stada"].ToString();
                        kortExcel.Athugasemdir = r["Athugasemdir"].ToString();
                        kortExcel.Afhendingaar = r["Afhendingaar"].ToString();

                        kortExcel.vista();
                        kortExcel.hreinsaHlut();
                    }
                    else
                    {
                        int id = Convert.ToInt32(r["id"]);
                        kortExcel.eyda(id);
                    }


                }
                m_prbPublish.PerformStep();
                m_lblPublish.Text = string.Format("{0}/{1}", m_prbPublish.Value, m_prbPublish.Maximum);
                System.Windows.Forms.Application.DoEvents();
            }
            //þarf að uppfæra excel ef bæti við
            //1. ná í uppfærð gögn
            updateExcel();
            //  lesaExcel(m_strExcelSkjal); //þarf að lesa excel aftur til að fá nýtt id
            DataGridViewButtonCell c = (DataGridViewButtonCell)m_dgvMappaSkjol.Rows[m_dgvMappaSkjol.CurrentRow.Index].Cells["colTakkar"];
            //  DataGridViewButtonColumn c = (DataGridViewButtonColumn)m_dgvMappaSkjol.Rows[r.Index].Cells["colTakkar"].Value;
            if (fyllaExcelGrid())
            {
                //    r.DefaultCellStyle.ForeColor = Color.LightYellow;
                c.FlatStyle = FlatStyle.Flat;
                c.Style.BackColor = System.Drawing.Color.LightYellow;
            }
            else
            {
                //  r.DefaultCellStyle.ForeColor = Color.LightGreen;
                c.FlatStyle = FlatStyle.Flat;
                c.Style.BackColor = System.Drawing.Color.LightGreen;
            }
            MessageBox.Show("Vistað og tvistað");
        }

        private async void updateExcel()
        {
            Excel.Application excel = null;
            Excel.Workbook wb = null;
            Excel.Worksheet xlWorkSheet = null;

            try
            {
                excel = new Excel.Application();
                wb = excel.Workbooks.Open(m_strExcelSkjal);
                xlWorkSheet = (Excel.Worksheet)wb.Worksheets.get_Item(1);

                m_dtMySQL = kortlagning.getKortHera(m_strHerAudkenni); //breyta þessu í auðkenni vörslustofnunar
                int iRow = 2;
                await Task.Delay(3000); // allow COM to initialize
                m_prbPublish.Value = 0;
                m_prbPublish.Maximum = m_dtMySQL.Rows.Count;
                m_prbPublish.Step = 1;
                foreach (DataRow r in m_dtMySQL.Rows)
                {
                    int iCol = 1;
                    foreach (DataColumn column in m_dtMySQL.Columns)
                    {
                        if (column.ColumnName != "status")
                        {
                            xlWorkSheet.Cells[iRow, iCol] = r[column].ToString();
                            iCol++;
                        }

                    }
                    iRow++;
                    m_prbPublish.PerformStep();
                    m_lblPublish.Text = string.Format("{0}/{1}", m_prbPublish.Value, m_prbPublish.Maximum);
                    System.Windows.Forms.Application.DoEvents();
                }

                wb.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Excel: {ex.Message}");
            }
            finally
            {
                // Close workbook
                if (wb != null)
                {
                    try { wb.Close(false); } catch { }
                    try { System.Runtime.InteropServices.Marshal.ReleaseComObject(wb); } catch { }
                    wb = null;
                }

                // Release worksheet
                if (xlWorkSheet != null)
                {
                    try { System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet); } catch { }
                    xlWorkSheet = null;
                }

                // Quit and release Excel application
                if (excel != null)
                {
                    try { excel.Quit(); } catch { }
                    try { System.Runtime.InteropServices.Marshal.ReleaseComObject(excel); } catch { }
                    excel = null;
                }

                // Force garbage collection to ensure COM cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void m_dgvMappaSkjol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colTakkar"].Index == e.ColumnIndex)
                {
                    m_strExcelSkjal = senderGrid.Rows[e.RowIndex].Cells["colSlod"].Value.ToString();
                    lesaExcel(m_strExcelSkjal);
                    fyllaExcelGrid();
                    m_iTakkiIndex = e.RowIndex;
                }


            }
        }

        private void m_btnAthBreytingar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in m_dgvMappaSkjol.Rows)
            {
                string strSlod = r.Cells["colSlod"].Value.ToString();
                //OPNA EXCEL    
                lesaExcel(strSlod);
                m_strExcelSkjal = strSlod;
                DataGridViewButtonCell c = (DataGridViewButtonCell)m_dgvMappaSkjol.Rows[r.Index].Cells["colTakkar"];
                //  DataGridViewButtonColumn c = (DataGridViewButtonColumn)m_dgvMappaSkjol.Rows[r.Index].Cells["colTakkar"].Value;
                if (fyllaExcelGrid())
                {
                    //    r.DefaultCellStyle.ForeColor = Color.LightYellow;
                    c.FlatStyle = FlatStyle.Flat;
                    c.Style.BackColor = System.Drawing.Color.LightYellow;
                }
                else
                {
                    //  r.DefaultCellStyle.ForeColor = Color.LightGreen;
                    c.FlatStyle = FlatStyle.Flat;
                    c.Style.BackColor = System.Drawing.Color.LightGreen;
                }
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void m_btnUppfaeraBirtingu_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();

            string strSkjal = "C:\\Users\\brjann\\Miðstöð héraðsskjalasafna um rafræna skjalavörslu\\MHR - Documents\\09 Kortlagningar\\kortlagning_allt.xlsx";
            Workbook wb = excel.Workbooks.Open(strSkjal);
            Worksheet xlWorkSheet = (Excel.Worksheet)wb.Worksheets.get_Item(1);

            m_dtMySQL = kortlagning.getKortHera();
            //Skrá allt í grunni aftur í m_dtMySQL.
            int iRow = 2;
            m_prbPublish.Value = 0;
            m_prbPublish.Maximum = m_dtMySQL.Rows.Count;
            m_prbPublish.Step = 1;
            foreach (DataRow r in m_dtMySQL.Rows)
            {
                int iCol = 1;
                foreach (DataColumn column in m_dtMySQL.Columns)
                {
                    //if(iRow == 1)
                    //{
                    //    xlWorkSheet.Cells[iRow, iCol] = column.ColumnName;
                    //    iCol++;
                    //}
                    //else
                    //{
                    xlWorkSheet.Cells[iRow, iCol] = r[column].ToString();
                    iCol++;
                    //}

                }

                iRow++;
                m_prbPublish.PerformStep();
                m_lblPublish.Text = string.Format("{0}/{1}", m_prbPublish.Value, m_prbPublish.Maximum);
                System.Windows.Forms.Application.DoEvents();
            }

            wb.Save();
            wb.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            MessageBox.Show("Búið");
        }

        private void m_btnOpnaAllt_Click(object sender, EventArgs e)
        {
            var p = new Process();
            string strSlod = "https://heradskjalasofn.sharepoint.com/:x:/r/sites/MHR/Shared%20Documents/09%20Kortlagningar/kortlagning_allt.xlsx?d=w49ed0650085f4d879431bf6fdd26b471&csf=1&web=1&e=v6OlLq";
            p.StartInfo = new ProcessStartInfo(strSlod)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void m_btnVistaIexcell_Click(object sender, EventArgs e)
        {
            //1. sækja gögn úr gagnagrunni
            m_strHeradsskjalasafn = m_dtExcell.Rows[0]["heradsskjalasafn"].ToString();

            //  m_strExcelSkjal
            //2. sækja excell, rúlla yfir hann
            vistaExcell(m_strHeradsskjalasafn);
            //3 vista breytingar
        }

        private async void vistaExcell(string strHeradskjalasafn)
        {
            Excel.Application excel = new Excel.Application();
            excel.Interactive = true;

            string strSkjal = m_strExcelSkjal;
            Workbook wb = excel.Workbooks.Open(strSkjal);
            Worksheet xlWorkSheet = (Excel.Worksheet)wb.Worksheets.get_Item(1);

            m_dtMySQL = kortlagning.getKortHera(m_strHerAudkenni);
            //Skrá allt í excell aftur frá gagnagrunni.
            int iRow = 2;
            m_prbPublish.Value = 0;
            m_prbPublish.Maximum = m_dtMySQL.Rows.Count;
            m_prbPublish.Step = 1;
            await Task.Delay(3000); //c# og com tala ekki á sama hraða bíða 3 sec
            foreach (DataRow r in m_dtMySQL.Rows)
            {
                int iCol = 1;
                foreach (DataColumn column in m_dtMySQL.Columns)
                {
                    //þarf að láta bíða í 1-3 sekúndur meðan C# og com eru að ná saman

                    xlWorkSheet.Cells[iRow, iCol] = r[column].ToString();
                    iCol++;
                    //}

                }

                iRow++;
                m_prbPublish.PerformStep();
                m_lblPublish.Text = string.Format("{0}/{1}", m_prbPublish.Value, m_prbPublish.Maximum);
                System.Windows.Forms.Application.DoEvents();
            }

            wb.Save();
            wb.Close();
            MessageBox.Show("Búið");
        }

        private void m_dgvExcelSkjal_MouseHover(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentCell != null)
            {
                if (dgv.CurrentCell.Style.BackColor == System.Drawing.Color.LightBlue)
                {
                    ////fletta upp í grunni hvað gildið var áður 
                    //string strDalkur = dgv.CurrentCell.OwningColumn.Name;
                    //string strID = dgv.Rows[dgv.CurrentCell.RowIndex].Cells["ID"].Value.ToString();
                    //string strExp = "ID='" + strID + "'";
                    //DataRow[] fRow = m_dtMySQL.Select(strExp);

                    dgv.CellToolTipTextNeeded += toolTip_ValueNeeded; // (sender, toolTip_ValueNeeded); // = fRow[0].ItemArray[dgv.CurrentCell.ColumnIndex].ToString();

                }
            }

        }

        private void toolTip_ValueNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            string strDalkur = dgv.CurrentCell.OwningColumn.Name;
            string strID = dgv.Rows[dgv.CurrentCell.RowIndex].Cells["ID"].Value.ToString();
            string strExp = "ID='" + strID + "'";
            if (m_strExcelGrunnur == "excel")
            {
                DataRow[] fRow = m_dtMySQL.Select(strExp);
                e.ToolTipText = fRow[0].ItemArray[dgv.CurrentCell.ColumnIndex].ToString();
            }
            else
            {
                DataRow[] fRow = m_dtExcell.Select(strExp);
                e.ToolTipText = fRow[0].ItemArray[dgv.CurrentCell.ColumnIndex].ToString();

            }
            //DataRow[] fRow = m_dtMySQL.Select(strExp);
            //e.ToolTipText = fRow[0].ItemArray[dgv.CurrentCell.ColumnIndex].ToString();

        }


        // Event handlers to show/hide tooltip immediately
        private void m_dgvExcelSkjal_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            // Only show for changed cells (your existing logic uses LightBlue)
            if (cell.Style.BackColor != System.Drawing.Color.LightBlue)
            {
                _cellToolTip.Hide(dgv);
                return;
            }

            // Resolve ID value from the row (case-insensitive lookup)
            object idObj = null;
            if (dgv.Columns.Contains("ID")) idObj = dgv.Rows[e.RowIndex].Cells["ID"].Value;
            else
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (string.Equals(col.Name, "ID", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(col.HeaderText, "ID", StringComparison.OrdinalIgnoreCase))
                    {
                        idObj = dgv.Rows[e.RowIndex].Cells[col.Index].Value;
                        break;
                    }
                }
            }

            if (idObj == null || Convert.IsDBNull(idObj))
            {
                _cellToolTip.Hide(dgv);
                return;
            }

            string strID = idObj.ToString();

            // Ensure DB table is available
            m_dtMySQL = kortlagning.getKortHera(m_strHerAudkenni);
            if (m_dtMySQL == null || m_dtMySQL.Rows.Count == 0)
            {
                _cellToolTip.Hide(dgv);
                return;
            }

            // Lookup DB row by ID (escape quotes)
            DataRow[] found = m_dtMySQL.Select($"ID='{strID.Replace("'", "''")}'");
            if (m_strExcelGrunnur == "excel")
            {
                found = m_dtMySQL.Select($"ID='{strID.Replace("'", "''")}'");
            }
            else
            {
                found = m_dtExcell.Select($"ID='{strID.Replace("'", "''")}'");
            }
            if (found.Length == 0)
            {
                _cellToolTip.Hide(dgv);
                return;
            }

            DataRow dbRow = found[0];

            // Map display column to DB column by index as fallback
            int dbColIndex = Math.Min(e.ColumnIndex, Math.Max(0, m_dtMySQL.Columns.Count - 1));
            string prevValue = dbRow.ItemArray.Length > dbColIndex ? dbRow.ItemArray[dbColIndex]?.ToString() ?? string.Empty : string.Empty;

            // Show tooltip at cell location immediately
            var rect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            _cellToolTip.Show(prevValue, dgv, rect.Left + 8, rect.Top + rect.Height / 2, 5000);
        }

        private void m_dgvExcelSkjal_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            _cellToolTip.Hide(m_dgvExcelSkjal);
        }

        private void m_dgvExcelSkjal_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentCell != null)
            {
                DataTable table = (DataTable)m_dgvExcelSkjal.DataSource;
                DataRow row = table.NewRow();
                row = ((DataRowView)m_dgvExcelSkjal.Rows[e.RowIndex].DataBoundItem).Row;
                frmFaeersla frm = new frmFaeersla(row, m_strExcelGrunnur, m_strExcelSkjal);
                frm.ShowDialog();
                ExcelGagnagrunnur();
                lagaEinnTakka();
            }
        }

        private void lagaEinnTakka()
        {
            lesaExcel(m_strExcelSkjal);
         
            DataGridViewButtonCell c = (DataGridViewButtonCell)m_dgvMappaSkjol.Rows[m_iTakkiIndex].Cells["colTakkar"];
            //  DataGridViewButtonColumn c = (DataGridViewButtonColumn)m_dgvMappaSkjol.Rows[r.Index].Cells["colTakkar"].Value;
            if (fyllaExcelGrid())
            {
                //    r.DefaultCellStyle.ForeColor = Color.LightYellow;
                c.FlatStyle = FlatStyle.Flat;
                c.Style.BackColor = System.Drawing.Color.LightYellow;
            }
            else
            {
                //  r.DefaultCellStyle.ForeColor = Color.LightGreen;
                c.FlatStyle = FlatStyle.Flat;
                c.Style.BackColor = System.Drawing.Color.LightGreen;
            }
            System.Windows.Forms.Application.DoEvents();
        }
    }
}
