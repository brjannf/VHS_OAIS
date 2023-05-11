using cClassOAIS;
using System.Data;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace MHR_LEIT
{
    public partial class Form1 : Form
    {
        DataTable m_dtDIP = new DataTable();
        cNotandi virkurNotandi = new cNotandi();
        cDIPKarfa karfa = new cDIPKarfa();
        cLanthegar lanþegi = new cLanthegar();
        string m_strSlodDIP = string.Empty;
        public Form1()
        {
            InitializeComponent();
            m_pnlNotandi.BringToFront();
            m_pnlNotandi.Dock = DockStyle.Fill;
            this.Text = "MHR - LEIT";
            this.WindowState = FormWindowState.Maximized;
            m_dtDIP.Columns.Add("skjalID");
            m_dtDIP.Columns.Add("titill");
            m_dtDIP.Columns.Add("vorsluutgafa");
            m_dtDIP.Columns.Add("md5");
            m_dtDIP.Columns.Add("slod");

            fyllaV0rslusstofnanir();
            fyllaSkjalamyndara();
            fyllaLanthega();
            fyllaDIPLista();



        }

        private void fyllaDIPLista()
        {
            DataTable dt = karfa.getKorfurDIP();
        
            m_trwDIP.Nodes.Clear();
            foreach(DataRow r in dt.Rows)
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
            DataTable dt = varsla.getAllVOrslustofnanir();
            DataRow r = dt.NewRow();
            r["varsla_heiti"] = "Veldu vörslustofnun";
            dt.Rows.InsertAt(r, 0);
            m_comVorslustofnun.ValueMember = "vorslustofnun";
            m_comVorslustofnun.DisplayMember = "varsla_heiti";
            m_comVorslustofnun.DataSource = dt;
        }
        private void fyllaSkjalamyndara()
        {
            cSkjalamyndari skjalam = new cSkjalamyndari();
            DataTable dt = skjalam.getSkjalamyndaralista();
            DataRow r = dt.NewRow();
            r["5_1_2_opinbert_heiti"] = "Veldu skjalamyndara";
            dt.Rows.InsertAt(r, 0);
            m_comSkjalamyndari.ValueMember = "5_1_6_auðkenni";
            m_comSkjalamyndari.DisplayMember = "5_1_2_opinbert_heiti";
            m_comSkjalamyndari.DataSource = dt;

        }
        private void m_btnLeita_Click(object sender, EventArgs e)
        {
            leita();  
        }

        private void leita()
        {
            cMIdlun midlun = new cMIdlun();

            midlun.leitarord = m_tboLeitOrd.Text;
          
           
            if(m_comVorslustofnun.SelectedIndex != 0)
            {
                midlun.vorslustofnun_audkenni = m_comVorslustofnun.SelectedValue.ToString();
            }
            if(m_comSkjalamyndari.SelectedIndex != 0) 
            {
                midlun.skjalamyndari_audkenni = m_comSkjalamyndari.SelectedValue.ToString();
            }
            if(m_dtpStart.Checked)
            {
                midlun.Upphafsdags = m_dtpStart.Value.ToString();
            }
            if(m_dtEnd.Checked)
            {
                midlun.Endadags = m_dtEnd.Value.ToString();
            }
         //   mid

            DataTable dt = midlun.leit(m_tboLeitOrd.Text);
            m_dgvLeit.AutoGenerateColumns = false;
            m_dgvLeit.DataSource = dt;
            m_lblLeitarnidurstodur.Visible = true;
            m_lblLeitarnidurstodur.Text = string.Format("Það fundust {0} leitarniðurstöður útfrá leitarorðunum {1}", dt.Rows.Count, m_tboLeitOrd.Text);
        }

        private void m_tboLeitOrd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                leita();
            }
        }

        private void m_dgvLeit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var senderGrid = (DataGridView)sender;
                string strGagnagrunnur = senderGrid.Rows[e.RowIndex].Cells["colGagnaGrunnur"].Value.ToString();
                string strValid = senderGrid.Rows[e.RowIndex].Cells["colDocID"].Value.ToString();

                DataTable table = (DataTable) m_dgvLeit.DataSource;
                DataRow row = table.NewRow();
                row = ((DataRowView)m_dgvLeit.Rows[e.RowIndex].DataBoundItem).Row;

                frmSkraarkerfi skrakerfi = new frmSkraarkerfi(strGagnagrunnur, strValid, row, m_tboLeitOrd.Text, m_dtDIP);
                skrakerfi.ShowDialog();
            
                foreach(DataRow r in skrakerfi.m_dtValid.Rows)
                {
                    string strEXp = string.Format("skjalID='{0}' and vorsluutgafa='{1}'", r["skjalID"], r["vorsluutgafa"]);
                    DataRow[] frow = m_dtDIP.Select(strEXp);
                    if(frow.Length == 0)
                    {
                        m_dtDIP.ImportRow(r);
                    }
                   
                }
              //  m_dgvDIPList.AutoGenerateColumns = false;
                m_dgvDIPList.DataSource = m_dtDIP;
                m_grbDIP.Text = string.Format("Óafgreitt gögn {0}", m_dtDIP.Rows.Count);
                m_tapAfgreidsla.Text  = string.Format("Afgreiðsla: {0} skrár óafgreiddar", m_dtDIP.Rows.Count);
              
                m_dgvLeit.DataSource = table;
                Application.DoEvents(); 
            }
        }

        private void m_btnHreinsa_Click(object sender, EventArgs e)
        {
            m_tboLeitOrd.Text = string.Empty;
            fyllaSkjalamyndara();
            fyllaV0rslusstofnanir();
           
            m_dtpStart.Value = DateTime.Now;
            m_dtEnd.Value = DateTime.Now;
            m_dtEnd.Checked = false;
            m_dtpStart.Checked = false;

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
            virkurNotandi.sækjaNotanda(strNotandi, strLykilorð);
            if (virkurNotandi.nafn != null)
            {
                m_tacMain.BringToFront();
                m_tacMain.Dock = DockStyle.Fill;
                this.Text = "Velkominn " + virkurNotandi.nafn;
                
                this.WindowState = FormWindowState.Maximized;

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

            if(m_comLanthegar.SelectedIndex == 0)
            {
                MessageBox.Show("Vinnsamlegast veldu lánþega eða búðu til nýjan");
                return;
            }

            string strExcell = string.Empty;

            DataTable dtExcell = m_dtDIP.Clone();

            foreach (DataRow r in m_dtDIP.Rows)
            {
                //skrái körfu strax, geri það máski síðar síðar
                if(karfa.karfa == 0)
                {
                    karfa.heiti = m_comLanthegar.Text + " " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                    karfa.lanthegi = m_comLanthegar.SelectedValue.ToString();
                    karfa.hver_skradi = virkurNotandi.nafn;
                    karfa.vista();
                }
                cDIPkarfaItem karfa_item = new cDIPkarfaItem();

                string strVorsluutgafa = r["vorsluutgafa"].ToString();
                string strID = r["skjalID"].ToString();
                string strTitill = r["titill"].ToString();

                //finna vörsluútgáfurót
                cVorsluutgafur utgafur = new cVorsluutgafur();
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

                    string strDIProot = divo.Name + "\\DIP"; 
                    if (!Directory.Exists(strDIProot))
                    {
                        Directory.CreateDirectory(strDIProot);
                    }
                    string strDIPfolder = strDIProot + "\\" + karfa.karfa +"_" + m_comLanthegar.Text; //ná í þetta síðar með cLanthega
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
                    strSplit = strSlod.Split("\\");
                    strID = "\\" + strSplit[strSplit.Length - 1];
                    string strMD5 = md5.getMD5(strID, utgafur.vorsluutgafa);
                    r["slod"] = strEndaSkjal.Replace(strDIProot, "");
                    r["md5"] = strMD5;

                    dtExcell.ImportRow(r);

                    karfa_item.karfa = karfa.karfa;
                    karfa_item.skjalID = r["skjalID"].ToString();
                    karfa_item.titill = r["titill"].ToString();
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


            }
          //  File.SetAttributes(strExcell, File.GetAttributes(strExcell) & ~FileAttributes.ReadOnly);
            //  exportExell(m_dtDIP, strExcell + "\\Gagnalisti.xlsx");
            exportExell(dtExcell, "C:\\temp\\listi.xlsx");
            File.Copy("C:\\temp\\listi.xlsx", strExcell + "\\Gagnalisti.xlsx", true);
            try
            {
                File.Delete("C:\\temp\\listi.xlsx");
            }
            catch (Exception x)
            {

               // throw;
            }
            m_dgvDIPList.DataSource = m_dtDIP;
            fyllaDIPLista();
            m_dtDIP.Rows.Clear();
            karfa.hreinsahlut();
            MessageBox.Show("DIP tilbúið");
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
                        if(strBLA.Contains("\\"))
                        {
                            workSheet.Hyperlinks.Add(workSheet.Cells[i + 2, j + 1],".." + strBLA, Type.Missing, "Sharifsoft", "www.Sharifsoft.com");
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
            if(m_strSlodDIP != string.Empty)
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
           string strKarfa = e.Node.Tag.ToString();
            cDIPkarfaItem items = new cDIPkarfaItem();
            DataTable dt =  items.getKorfuItemDIP(strKarfa);
            m_grbDIP.Text = string.Format("Afgreitt {0}", dt.Rows.Count);
            m_dgvDIPList.DataSource = items.getKorfuItemDIP(strKarfa);
            string[] strSplit = dt.Rows[0]["slod"].ToString().Split("\\");
            m_strSlodDIP = strSplit[0] + "\\" + strSplit[2] +"\\" + strSplit[3];
        }

        private void m_comLanthegar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_comLanthegar.Focused)
            {
                if(m_comLanthegar.SelectedIndex != 0)
                {
                    string strID = m_comLanthegar.SelectedValue.ToString();
                    lanþegi.getaLanthega(strID);
                    if(lanþegi.id != 0)
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
            m_dtDIP.Rows.Clear();
            m_dgvDIPList.DataSource = m_dtDIP;
        }
    }
}