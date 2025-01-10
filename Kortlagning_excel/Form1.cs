namespace Kortlagning_excel
{
    using Microsoft.Office.Interop.Excel;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using cClassOAIS;
    using DocumentFormat.OpenXml.Drawing.Diagrams;
    using System.Drawing;
    using IronXL;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Diagnostics;

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
        public Form1()
        {
            InitializeComponent();
            //    m_strMappa = "C:\\Users\\brjann\\OneDrive - Braud\\Documents\\9. Kortlagningar\\komid\\Skyrsla\\Heradsskjalasofn"; //onedrive
            m_strMappa = "C:\\Users\\brjann\\Braud\\Braud - Documents\\Kortlagning\\Heradsskjalasofn"; //sharepoint
            m_dtMappa.Columns.Add("ID");
            m_dtMappa.Columns.Add("slod");
            m_dtExcell.Columns.Add("status");
            fyllaTakka();
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
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                m_dtExcell.Rows.Clear();
                m_dtMySQL.Rows.Clear();
                m_strExcelSkjal = openFileDialog1.FileName;
                lesaExcel(openFileDialog1.FileName);
                fyllaExcelGrid();


            }
        }

        private bool fyllaExcelGrid()
        {
            bool bRet = false;
            if (m_dtExcell.Rows.Count > 0)
            {
                m_strHeradsskjalasafn = m_dtExcell.Rows[0]["heradsskjalasafn"].ToString();
                m_lblHeradsSkjalaSafn.Text = m_strHeradsskjalasafn;
                m_dtMySQL = kortlagning.getKortHera(m_strHeradsskjalasafn);
                //samkeyra m_dtExcell og m_dtMySQL og skrá breytingar einhvernveginnz
                int iUpdate = 0;
                int iExcell = m_dtExcell.Rows.Count;
                int iMySQL = m_dtMySQL.Rows.Count;
                string strIDDel = string.Empty;
                foreach (DataRow r in m_dtExcell.Rows)
                {
                    if(iMySQL > iExcell)
                    {
                        foreach(DataRow r2 in m_dtMySQL.Rows)
                        {
                            string strID = r2["ID"].ToString();
                            string strExp = "ID='" + strID + "'";
                            DataRow[] fRow = m_dtExcell.Select(strExp);
                            if(fRow.Length == 0)
                            {
                                //búið að eyða úr excell
                                if(!strIDDel.Contains(strID + ":"))
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
                                    strMysqlData += strName + "~" + item.ToString() + "|";

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
                            bRet = true;
                            //var file1Lines = Convert.ToChar(strMysqlData);
                            //var file2Lines = Convert.ToChar(strExcelData);
                            //  IEnumerable<String> inFirstNotInSecond = file1Lines.Except(file2Lines);
                            //  IEnumerable<String> inSecondNotInFirst = file2Lines.Except(file1Lines)
                        }
                        else
                        {
                            r["status"] = "óbreytt";
                        }

                    }
                }

                System.Data.DataTable dtClone = m_dtMySQL.Clone();
                dtClone.Columns.Add("status");
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

                            }
                        }
                        
                    }

                }

                foreach (DataRow row in m_dtExcell.Rows) 
                {
                    dtClone.ImportRow(row);

                }
                m_lblUpdate.Text = string.Format("Uppfæra: {0} færslur", iUpdate);
                m_lblExcell.Text = string.Format("Færslur í excelskjali: {0} færslur", iExcell);
                m_lblMySQL.Text = string.Format("Færslur í grunni: {0} færslur", iMySQL);
                m_dgvExcelSkjal.DataSource = dtClone; // m_dtExcell;
                foreach (DataGridViewRow r in m_dgvExcelSkjal.Rows)
                {
                    if (r.Cells["status"].Value.ToString() == "update")
                    {
                        r.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    if (r.Cells["status"].Value.ToString() == "óbreytt")
                    {
                        r.DefaultCellStyle.BackColor = Color.White;
                    }
                    if (r.Cells["status"].Value.ToString() == "insert")
                    {
                        r.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    if (r.Cells["status"].Value.ToString() == "")
                    {
                        r.DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }
            }
            return bRet;
        }
        private void lesaExcel(string strSlod)
        {
            //var exceldoc = IronXL.WorkBook.LoadExcel(strSlod);
            //var worksheet = exceldoc.WorkSheets[0];


            //m_dtExcell = worksheet.ToDataTable(true);
            //m_dtExcell.Columns.Add("status");
            //foreach (DataRow r in m_dtExcell.Rows)
            //{
            //    foreach (DataColumn column in m_dtExcell.Columns)
            //    {
            //        r[column] = r[column].ToString().Replace(" 00:00:00", "");

            //    }
            //}
            ////dataGridView1.DataSource = dt;
            //return;
            m_dtExcell.Rows.Clear();
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

                    }
                }
            }
            //    string sSheetName = null;
            //    string sConnection = null;

            //    OleDbCommand oleExcelCommand = default(OleDbCommand);
            //    OleDbDataReader oleExcelReader = default(OleDbDataReader);
            //    OleDbConnection oleExcelConnection = default(OleDbConnection);

            //    sConnection = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"",strSlod);

            //    oleExcelConnection = new OleDbConnection(sConnection);
            //    oleExcelConnection.Open();

            //    m_dtExcell = oleExcelConnection.GetSchema("Tables");

            //    if (m_dtExcell.Rows.Count > 0)
            //    {
            //        sSheetName = m_dtExcell.Rows[0]["TABLE_NAME"].ToString();
            //    }

            //    m_dtExcell.Clear();
            //    m_dtExcell.Dispose();


            //    if (!string.IsNullOrEmpty(sSheetName))
            //    {
            //        oleExcelCommand = oleExcelConnection.CreateCommand();
            //        oleExcelCommand.CommandText = "Select * From [" + sSheetName + "]";
            //        oleExcelCommand.CommandType = CommandType.Text;
            //        oleExcelReader = oleExcelCommand.ExecuteReader();
            //        int nOutputRow = 0;

            //        while (oleExcelReader.Read())
            //        {
            //        }
            //        oleExcelReader.Close();
            //    }
            //    oleExcelConnection.Close();
            //    m_dgvExcelSkjal.DataSource = m_dtExcell;
        }

        private void m_btnVista_Click(object sender, EventArgs e)
        {
            cKortlagningar_excel kortExcel = new cKortlagningar_excel();
            System.Data.DataTable dtVista = (System.Data.DataTable)m_dgvExcelSkjal.DataSource;
            string strExp = "status= 'update'";
            foreach (DataRow r in dtVista.Rows)
            {
                if (r["status"].ToString() != "óbreytt")
                {
                    if (r["status"] != string.Empty) //update insert
                    {


                        if (r["id"] != DBNull.Value)
                        {
                            kortExcel.id = Convert.ToInt32(r["id"]);
                        }

                        kortExcel.Heradsskjalasafn = r["Heradsskjalasafn"].ToString();
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
                        kortExcel.eyda(kortExcel.id);
                    }
                }

            }
            //þarf að uppfæra excel ef bæti við
            //1. ná í uppfærð gögn
            updateExcel();
            lesaExcel(m_strExcelSkjal);
            fyllaExcelGrid();
            MessageBox.Show("Vistað");
        }

        private void updateExcel()
        {
            Excel.Application excel = new Excel.Application();

            Workbook wb = excel.Workbooks.Open(m_strExcelSkjal);
            Worksheet xlWorkSheet = (Excel.Worksheet)wb.Worksheets.get_Item(1);

            m_dtMySQL = kortlagning.getKortHera(m_strHeradsskjalasafn);
            //Skrá allt í grunni aftur í m_dtMySQL.
            int iRow = 2;
            foreach (DataRow r in m_dtMySQL.Rows)
            {
                int iCol = 1;
                foreach (DataColumn column in m_dtMySQL.Columns)
                {
                    xlWorkSheet.Cells[iRow, iCol] = r[column].ToString();
                    iCol++;
                }
                iRow++;
            }

            wb.Save();
            wb.Close();

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
                    c.Style.BackColor = Color.LightYellow;
                }
                else
                {
                    //  r.DefaultCellStyle.ForeColor = Color.LightGreen;
                    c.FlatStyle = FlatStyle.Flat;
                    c.Style.BackColor = Color.LightGreen;
                }
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void m_btnUppfaeraBirtingu_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();

            string strSkjal = "C:\\Users\\brjann\\Braud\\Braud - Documents\\Kortlagning\\kortlagning_allt.xlsx";
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
            MessageBox.Show("Búið");
        }

        private void m_btnOpnaAllt_Click(object sender, EventArgs e)
        {
            var p = new Process();
            string strSlod = "https://braudehf.sharepoint.com/:x:/r/sites/Braud/_layouts/15/Doc.aspx?sourcedoc=%7B737c6fce-ebcd-4072-9bfa-81921c3f924c%7D&action=view";
            p.StartInfo = new ProcessStartInfo(strSlod)
            {
                UseShellExecute = true
            };
            p.Start();
        }
      
    }
}
