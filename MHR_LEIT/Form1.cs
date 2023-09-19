using cClassOAIS;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace MHR_LEIT
{
    public partial class Form1 : Form
    {
        DataTable m_dtDIPSkra = new DataTable();
        DataTable m_dtDIPMal = new DataTable();
        DataTable m_dtDIPGrunn = new DataTable();
        DataSet m_dsDIPmal= new DataSet();

        bool bAdmin = false;
        bool bAfrit = false;

        DataTable m_dtLeitarNidurstodur = new DataTable();  

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
           DataTable dt = virkurNotandi.getGrunnar();
            foreach(DataRow r in dt.Rows)
            {
                if (r["Database (DB_OAIS%)"].ToString() == "db_oais_admin")
                {
                    bAdmin = true;  
                }
                if(r["Database (DB_OAIS%)"].ToString() == "db_oais_admin_afrit")
                {
                    bAfrit = true;
                   
                }
            }
            if(!bAdmin && ! bAfrit)
            {
                frmUppsetning frmUpp = new frmUppsetning();
                frmUpp.ShowDialog();
                bAfrit = true;
                virkurNotandi.m_bAfrit = true;
            }
            if(bAdmin && bAfrit)
            {
                m_chbAfrit.Visible = true;  
            }

            m_dtDIPSkra.Columns.Add("skjalID");
            m_dtDIPSkra.Columns.Add("titill");
            m_dtDIPSkra.Columns.Add("vorsluutgafa");
            m_dtDIPSkra.Columns.Add("md5");
            m_dtDIPSkra.Columns.Add("slod");

            m_dtDIPGrunn.Columns.Add("Heiti");
            m_dtDIPGrunn.Columns.Add("vorsluutgafa");
            m_dtDIPGrunn.Columns.Add("leitarskilyrði");
            m_dtDIPGrunn.Columns.Add("sql");
            m_dtDIPGrunn.Columns.Add("slod");

            //id, karfa, md5, vorsluutgafa, Skrar, slod
            m_dtDIPMal.Columns.Add("karfa");
            m_dtDIPMal.Columns.Add("md5");
            m_dtDIPMal.Columns.Add("vorsluutgafa");
            m_dtDIPMal.Columns.Add("Skrar");
          


            //fyllaV0rslusstofnanir();
            //fyllaSkjalamyndara();
            //fyllaLanthega();
            //fyllaDIPLista();
            //fyllaGagnaGrunna();



        }
        private void fyllaGagnaGrunna()
        {
            cMIdlun midlun= new cMIdlun();
            midlun.m_bAfrit = virkurNotandi.m_bAfrit;
            DataTable dt = midlun.getGagnagrunna();
            DataRow r = dt.NewRow();
            r["orginal_heiti"] = "Veldu Gagnagrunn";
            dt.Rows.InsertAt(r, 0);
          //  id, vorsluutgafa, heiti_gagnagrunns, orgina_heiti
            m_comGagnagrunnar.ValueMember = "heiti_gagnagrunns";
            m_comGagnagrunnar.DisplayMember = "orginal_heiti";
            m_comGagnagrunnar.DataSource = dt;
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
        private void fyllaSkjalamyndara()
        {
            cSkjalamyndari skjalam = new cSkjalamyndari();
            skjalam.m_bAfrit = virkurNotandi.m_bAfrit;
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
            midlun.m_bAfrit = bAfrit;
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

            m_dtLeitarNidurstodur = midlun.leit(m_tboLeitOrd.Text);
            m_dgvLeit.AutoGenerateColumns = false;
            m_dgvLeit.DataSource = m_dtLeitarNidurstodur;
            m_lblLeitarnidurstodur.Visible = true;
            m_lblLeitarnidurstodur.Text = string.Format("Það fundust {0} leitarniðurstöður útfrá leitarorðunum {1}", m_dtLeitarNidurstodur.Rows.Count, m_tboLeitOrd.Text);
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
                string strTegund = senderGrid.Rows[e.RowIndex].Cells["colTegund_gagnagrunns"].Value.ToString();
                string strValid = senderGrid.Rows[e.RowIndex].Cells["colDocID"].Value.ToString();

                DataTable table = (DataTable) m_dgvLeit.DataSource;
                DataRow row = table.NewRow();
                row = ((DataRowView)m_dgvLeit.Rows[e.RowIndex].DataBoundItem).Row;
                 
                if(strTegund == "Skráarkerfi")
                {
                    frmSkraarkerfi skrakerfi = new frmSkraarkerfi(strGagnagrunnur, strValid, row, m_tboLeitOrd.Text, m_dtDIPSkra, m_dtDIPMal,m_dtDIPGrunn, virkurNotandi);
                    skrakerfi.ShowDialog();

                    foreach (DataRow r in skrakerfi.m_dtValid.Rows)
                    {
                        string strEXp = string.Format("skjalID='{0}' and vorsluutgafa='{1}'", r["skjalID"], r["vorsluutgafa"]);
                        DataRow[] frow = m_dtDIPSkra.Select(strEXp);
                        if (frow.Length == 0)
                        {
                            m_dtDIPSkra.ImportRow(r);
                        }

                    }
                }
                if(strTegund == "Málakerfi")
                {
                    DataTable dtMal = m_dsDIPmal.Tables[strGagnagrunnur];
                    frmMalakerfi frmMala = new frmMalakerfi(strGagnagrunnur, row, m_dtDIPGrunn, m_dtDIPSkra, dtMal, virkurNotandi);
                    frmMala.ShowDialog();
                    DataTable dt = frmMala.m_dtPontunMal;
                    if(dt.Rows.Count != 0)
                    {
                        dt.TableName = strGagnagrunnur;
                        if (m_dsDIPmal.Tables.Contains(strGagnagrunnur))
                        {
                            m_dsDIPmal.Tables.Remove(dt.TableName);
                            m_dsDIPmal.Tables.Add(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                DataRow rMal = m_dtDIPMal.NewRow();
                                rMal["vorsluutgafa"] = strGagnagrunnur.Replace("_", ".");
                                rMal["Skrar"] = dt.Rows.Count;

                                m_dtDIPMal.Rows.Add(rMal);
                                m_dtDIPMal.AcceptChanges();
                            }
                            //vantar að uppfæra töflu M_dtDIPMal

                        }
                        else
                        {
                            m_dsDIPmal.Tables.Add(dt);
                            foreach(DataRow dr in dt.Rows) 
                            {
                                DataRow rMal = m_dtDIPMal.NewRow();
                                rMal["vorsluutgafa"] = strGagnagrunnur.Replace("_", ".");
                                rMal["Skrar"] = dt.Rows.Count;

                                m_dtDIPMal.Rows.Add(rMal);
                                m_dtDIPMal.AcceptChanges();
                            }
                            

                            //m_dtDIPMal.Columns.Add("karfa");
                            //m_dtDIPMal.Columns.Add("md5");
                            //m_dtDIPMal.Columns.Add("vorsluutgafa");
                            //m_dtDIPMal.Columns.Add("Skrar");

                        }
                    }
                
                 
                }
         
            
              //  m_dgvDIPList.AutoGenerateColumns = false;
                m_dgvDIPList.DataSource = m_dtDIPSkra;
                m_dgvDIPmal.DataSource = m_dtDIPMal;
                foreach (DataGridViewColumn col in m_dgvDIPmal.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }


                m_tapPontunSkra.Text = string.Format("Skáarkerfi ({0})", m_dtDIPSkra.Rows.Count);
                m_tapPontunMalakerfi.Text = string.Format("Málakerfi ({0})", m_dtDIPMal.Rows.Count);
                m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtDIPGrunn.Rows.Count);
                int iFjoldi = m_dtDIPGrunn.Rows.Count + m_dtDIPSkra.Rows.Count + m_dtDIPMal.Rows.Count;
                m_grbDIP.Text = string.Format("Óafgreitt ({0})", iFjoldi);
                m_tapAfgreidsla.Text  = string.Format("Afgreiðsla: {0} skrár óafgreiddar", iFjoldi);
              
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
            m_dtLeitarNidurstodur.Rows.Clear();
            m_comGagnagrunnar.SelectedIndex = 0;
            

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
          
            if(m_chbAfrit.Visible) 
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
            if(!bAdmin && bAfrit) 
            {
                virkurNotandi.m_bAfrit = true;
            }
            virkurNotandi.sækjaNotanda(strNotandi, strLykilorð);
            if (virkurNotandi.nafn != null)
            {
                m_tacMain.BringToFront();
                m_tacMain.Dock = DockStyle.Fill;
                this.Text = "Velkominn " + virkurNotandi.nafn;
                
                this.WindowState = FormWindowState.Maximized;
                karfa.m_bAfrit = virkurNotandi.m_bAfrit;
                lanþegi.m_bAfrit = virkurNotandi.m_bAfrit;
                fyllaV0rslusstofnanir();
                fyllaSkjalamyndara();
                fyllaLanthega();
                fyllaDIPLista();
                fyllaGagnaGrunna();
               

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
            dtExcellMal.Columns.Add("Skrá");
            dtExcellMal.Columns.Add("Slóð");

            //Skráarkerfi
            m_pgbPontun.Maximum = m_dtDIPGrunn.Rows.Count + m_dtDIPMal.Rows.Count + m_dtDIPSkra.Rows.Count;
            m_pgbPontun.Step = 1;
            m_pgbPontun.Value = 0;
            m_tacPontun.SelectedTab = m_tapPontunSkra;
            Application.DoEvents();
            foreach (DataRow r in m_dtDIPSkra.Rows)
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
                    md5.m_bAfrit = virkurNotandi.m_bAfrit;
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
                        karfa_item.vorsluutgafa = r["vorsluutgafa"].ToString();
                        karfa_item.md5 = strMD5;
                        karfa_item.slod = strEndaSkjal;
                        karfa_item.vista();
                    }

                }

                m_pgbPontun.PerformStep();
                m_lblPontunstatus.Text = string.Format("{0}/{1}", m_pgbPontun.Value, m_pgbPontun.Maximum);
                m_pgbPontun.Visible = true;
                m_lblPontunstatus.Visible = true;
                Application.DoEvents();
            }

            m_tacPontun.SelectedTab = m_tapPontunMalakerfi;
            //Málakerfi
            foreach(DataTable dt in m_dsDIPmal.Tables)
            {
                if (karfa.karfa == 0)
                {
                    karfa.heiti = m_comLanthegar.Text + " " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                    karfa.lanthegi = m_comLanthegar.SelectedValue.ToString();
                    karfa.hver_skradi = virkurNotandi.nafn;
                    karfa.vista();
                }

                //skrái körfu strax, geri það máski síðar síðar
                int iMal = 1;
                string strSagsID = string.Empty;
                foreach (DataRow r in dt.Rows)
                {
                    if (strSagsID != r["sagsID"].ToString())
                    {
                        if (strSagsID != string.Empty)
                        {
                            iMal++;
                        }

                        strSagsID = r["sagsID"].ToString();
                    }
                    string strVorsluutgafa = r["gagnagrunnur"].ToString().Replace("_", "."); 
                                                                                           
                    cVorsluutgafur utgafur = new cVorsluutgafur();
                    utgafur.m_bAfrit = virkurNotandi.m_bAfrit;
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
                    string strExp = "dID= '" + strSplit[strSplit.Length - 1] +"'";
                    DataRow[] fRow = ds.Tables[0].Select(strExp);

                    string strDocTitill = fRow[0]["oFn"].ToString();
                    strSplit = strDocTitill.Split(".");
                    strDocTitill = strSplit[0] + ".tif";
                    if (!Directory.Exists(strDIPfolder +"\\" + "Mál_" + iMal.ToString("00")))
                    {
                        Directory.CreateDirectory(strDIPfolder + "\\"  + "Mál_" + iMal.ToString("00"));
                    }
                    string strDestDoc = strDIPfolder + "\\" + "Mál_" + iMal.ToString("00") + "\\" + strDocTitill;
                    File.Copy(strSkraSlod, strDestDoc, true);

                    string strDest = strDIPfolder +"\\" + "Mál_" + iMal.ToString("00") + "\\Mál.xlsx";
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
                    DataRow rr = dtExcellMal.NewRow();
                    rr["Mál"] = "Mál_" + iMal.ToString("00");
                    rr["Skrá"] = strDocTitill;
                    rr["Slóð"] = strDestDoc.Replace(strDIProot, "");
                    dtExcellMal.Rows.Add(rr);
                    dtExcellMal.AcceptChanges();

                    cDIPkarfaItem karfa_item = new cDIPkarfaItem();
                    karfa_item.m_bAfrit = virkurNotandi.m_bAfrit;
                    cMD5 mD5= new cMD5();
                    mD5.m_bAfrit = virkurNotandi.m_bAfrit;
                    string strMD5 = mD5.getMD5(strID, utgafur.vorsluutgafa);
                    karfa_item.karfa = karfa.karfa;
                    karfa_item.vorsluutgafa = r["gagnagrunnur"].ToString().Replace("_",".");
                    karfa_item.Fjold_skrar = dt.Rows.Count;
                    karfa_item.md5 = strMD5;
                    karfa_item.slod = strDestDoc;
                    karfa_item.vistaMalaKerfi();


                }

                m_pgbPontun.PerformStep();
                m_lblPontunstatus.Text = string.Format("{0}/{1}", m_pgbPontun.Value, m_pgbPontun.Maximum);
                m_pgbPontun.Visible = true;
                m_lblPontunstatus.Visible = true;
                Application.DoEvents();
            }

            //gaggnagrunnur
            int iFjoldi = 0;
            string strTextTXT = string.Empty;
            string strTXTfile = string.Empty;
            m_tacPontun.SelectedTab = m_tapPontunGagnagrunnar;
            Application.DoEvents();
            foreach(DataRow rr in m_dtDIPGrunn.Rows)
            {
                if (karfa.karfa == 0)
                {
                    karfa.heiti = m_comLanthegar.Text + " " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                    karfa.lanthegi = m_comLanthegar.SelectedValue.ToString();
                    karfa.hver_skradi = virkurNotandi.nafn;
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
                string strDest = strDIPfolder + "\\Fyrirspurn_"+ iFjoldi +".xlsx";
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
                rGrunn["leitarskilyrði"] = rr["leitarskilyrði"].ToString();
                rGrunn["sql"] = rr["sql"].ToString();
                rGrunn["slod"] = strDest.Replace(strDIProot, "");  // strSkjal[0];
              
                dtExcellGrunnur.Rows.Add(rGrunn);
               

                cDIPkarfaItem karfa_item = new cDIPkarfaItem();
                karfa_item.m_bAfrit = virkurNotandi.m_bAfrit;
                karfa_item.karfa = karfa.karfa;
                karfa_item.heiti= rr["heiti"].ToString();
                karfa_item.leitarskilyrdi = rr["leitarskilyrði"].ToString();
                karfa_item.vorsluutgafa = rr["vorsluutgafa"].ToString();
                karfa_item.sql = rr["sql"].ToString();
                karfa_item.slod = strDest;
                karfa_item.vistaGagnagrunn();
                //setja hérna inn "lestumig.txt"
                strTextTXT += "Fyrirspurn_" + 0 + " Leitarskilyrði: " + rr["leitarskilyrði"] + "Fjoldi niðurstaðna: " + dt.Rows.Count;

                m_pgbPontun.PerformStep();
                m_lblPontunstatus.Text = string.Format("{0}/{1}", m_pgbPontun.Value, m_pgbPontun.Maximum);
                m_pgbPontun.Visible = true;
                m_lblPontunstatus.Visible = true;
                Application.DoEvents();
            }


          //  File.SetAttributes(strExcell, File.GetAttributes(strExcell) & ~FileAttributes.ReadOnly);
            //  exportExell(m_dtDIPSkra, strExcell + "\\Gagnalisti.xlsx");
            if(dtExcell.Rows.Count > 0) 
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

            if(dtExcellMal.Rows.Count > 0)
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
            if(dtExcellGrunnur.Rows.Count >0)
            {
                string strDest = strTXTfile + "\\Fyrirspurn_" + i +".txt";
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
            fyllaDIPLista();
            m_dtDIPSkra.Rows.Clear();
            m_dtDIPGrunn.Rows.Clear();
            m_dtDIPMal.Rows.Clear();
            m_dsDIPmal.Tables.Clear();
            karfa.hreinsahlut();
            MessageBox.Show("DIP tilbúið");
            m_pgbPontun.Visible = false;
            m_lblPontunstatus.Visible = false;  
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
                            string strLink = ".." + strBLA; 
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
                        if(File.Exists(excelFilePath))
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
            items.m_bAfrit = virkurNotandi.m_bAfrit;
            DataTable dt =  items.getKorfuItemDIP(strKarfa);
            m_dgvDIPList.DataSource = items.getKorfuItemDIP(strKarfa);
          
            DataTable dtGrunn = items.getKorfuItemDIPGagnagrunnur(strKarfa);
            m_dgvDIPGagnagrunnar.DataSource = dtGrunn;
            foreach (DataGridViewColumn col in m_dgvDIPGagnagrunnar.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
          

            DataTable dtMal = items.getKorfuItemDIPMalakerfi(strKarfa); 
            m_dgvDIPmal.DataSource = dtMal;
            foreach (DataGridViewColumn col in m_dgvDIPmal.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }


            if (dt.Rows.Count > 0 ) 
            {
                string[] strSplit = dt.Rows[0]["slod"].ToString().Split("\\");
                m_strSlodDIP = strSplit[0] + "\\" + strSplit[2] + "\\" + strSplit[3];
               
            }
            if(dtGrunn.Rows.Count > 0 ) 
            {
                string[] strSplit = dtGrunn.Rows[0]["slod"].ToString().Split("\\");
                m_strSlodDIP = strSplit[0] + "\\" + strSplit[2] + "\\" + strSplit[3];
               
            }
            if(dtMal.Rows.Count > 0 ) 
            {
                string[] strSplit = dtMal.Rows[0]["slod"].ToString().Split("\\");
                m_strSlodDIP = strSplit[0] + "\\" + strSplit[2] + "\\" + strSplit[3];
               
            }
            m_tapPontunSkra.Text = string.Format("Skráakerfi ({0})", dt.Rows.Count);
            m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", dtGrunn.Rows.Count);
            m_tapPontunMalakerfi.Text = string.Format("Málakerfi ({0})", dtMal.Rows.Count);
            int iFjoldi = dt.Rows.Count + dtGrunn.Rows.Count + dtMal.Rows.Count;
            m_grbDIP.Text = string.Format("Afgreitt {0}", iFjoldi);
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

        }

        private void n_comGagnagrunnar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_comGagnagrunnar.Focused)
            {
                if(m_comGagnagrunnar.SelectedIndex != 0)
                {
                    string strGrunnur = m_comGagnagrunnar.SelectedValue.ToString();
                    string strHeiti = m_comGagnagrunnar.Text.ToString();
                    frmGagnagrunnur frmGagn = new frmGagnagrunnur(strGrunnur, strHeiti,m_dtDIPGrunn, m_dtDIPSkra, m_dtDIPMal,virkurNotandi);
                    frmGagn.ShowDialog();

                    foreach (DataRow r in frmGagn.m_dtPantad.Rows)
                    {
                       string strLeitarskilyrði = r["leitarskilyrði"].ToString().Replace("'","\"");
                        string strEXp = string.Format("vorsluutgafa='{0}' and leitarskilyrði='{1}'", r["vorsluutgafa"], strLeitarskilyrði, virkurNotandi);
                       DataRow[] frow = m_dtDIPGrunn.Select(strEXp);
                        if (frow.Length == 0)
                        {
                            m_dtDIPGrunn.ImportRow(r);
                        }
                    //    m_dtDIPGrunn.Columns.Add("Heiti");
                    //    m_dtDIPGrunn.Columns.Add("vorsluutgafa");
                    //    m_dtDIPGrunn.Columns.Add("leitarskilyrði");
                    //    m_dtDIPGrunn.Columns.Add("sql");
                    }

                    m_dgvDIPGagnagrunnar.DataSource = m_dtDIPGrunn;
                    foreach (DataGridViewColumn col in m_dgvDIPGagnagrunnar.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    m_tapPontunGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtDIPGrunn.Rows.Count);
                    int iFjoldi = m_dtDIPGrunn.Rows.Count + m_dtDIPSkra.Rows.Count + m_dtDIPMal.Rows.Count;
                    m_grbDIP.Text = string.Format("Óafgreitt ({0})", iFjoldi);
                    m_tapAfgreidsla.Text = string.Format("Afgreiðsla: {0} skrár óafgreiddar", iFjoldi);
                }
            }
        }
    }
}