﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cClassOAIS;
using cClassVHS;
using DocumentFormat.OpenXml.EMMA;
using OAIS_ADMIN;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using DocumentFormat.OpenXml.Drawing.Charts;
//using DocumentFormat.OpenXml.EMMA;

namespace MHR_LEIT
{
    public partial class frmSkraarkerfi : Form
    {
        cMIdlun midlun = new cMIdlun();
        cVHS_drives drive = new cVHS_drives();
        DataTable m_dtSkrar = new DataTable();
        DataTable m_dtMal = new DataTable();
        DataTable m_dtGrunn = new DataTable(); 
        DataSet m_dsDIPmal = new DataSet(); 
        DataTable m_dtExtension = new DataTable();
        

        cNotandi virkurnotandi = new cNotandi();    
        string m_strGagnagrunnur = string.Empty;
        string m_strFileValinn = string.Empty;
        string m_strIdValinn = string.Empty;
        string m_strRoot = string.Empty;
        string m_strVorslutgafa = string.Empty;
        ArrayList arr = new ArrayList();
        public DataTable m_dtValid = new DataTable();

        public frmSkraarkerfi()
        {
            InitializeComponent();
           
        }
        public frmSkraarkerfi(string strGagnagrunnur, string strValdi, DataRow row, string strLeitarOrd, DataTable dtDIP, DataTable dtMal, DataTable dtGrunn, cNotandi not, DataSet dsDIPmal)
        {
            InitializeComponent();

            this.Text = row["titill_vorsluutgafu"].ToString();   

            m_dtExtension.Columns.Add("extension");
            m_lblLeitarNidurstodur.Text = string.Empty;
            m_dtMal = dtMal;
            m_dtGrunn = dtGrunn;
            m_dsDIPmal = dsDIPmal;

            

            virkurnotandi = not;
            midlun.m_bAfrit = virkurnotandi.m_bAfrit;
            drive.m_bAfrit = virkurnotandi.m_bAfrit;
            m_dtValid = dtDIP.Clone();
            foreach(DataRow dr in dtDIP.Rows) 
            {
                m_dtValid.ImportRow(dr);
            }
            m_dgvValdarSkrar.DataSource = m_dtValid;    
            m_tapSkraarkerfi.Text = string.Format("Skráakerfi ({0})", m_dtValid.Rows.Count);

            m_dgvGagnaGrunnar.DataSource = dtGrunn;
            m_tapGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", dtGrunn.Rows.Count);
            foreach (DataGridViewColumn col in m_dgvGagnaGrunnar.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            m_dgvMalakerfi.DataSource= dtMal;
            m_tapMalakerfi.Text = string.Format("Málakerfi ({0})", dtMal.Rows.Count);
            foreach (DataGridViewColumn col in m_dgvMalakerfi.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            int iFjoldi = m_dtValid.Rows.Count + m_dtGrunn.Rows.Count + m_dtMal.Rows.Count;
            if (iFjoldi == 0)
            {
                m_btnAfgreida.Enabled = false;
            }
            else
            {
                m_btnAfgreida.Enabled = true;
            }
            //m_dtValid.Columns.Add("skjalID");
            //m_dtValid.Columns.Add("titill");
            //m_dtValid.Columns.Add("vorsluutgafa");

            this.WindowState = FormWindowState.Maximized;
            m_tobLeitarord.Text = strLeitarOrd;
            m_strGagnagrunnur = strGagnagrunnur;
            m_strIdValinn = strValdi;
            m_strFileValinn = strValdi;
            m_strVorslutgafa = row["vorsluutgafa"].ToString();
            if(virkurnotandi.m_bAfrit)
            {
                m_strRoot = drive.driveVirkkComputers() + "\\" + row["vorsluutgafa"];
            }
            else
            {
                m_strRoot = drive.driveVirkkComputers() + "\\" + row["vorslustofnun_audkenni"].ToString() + "\\" + row["skjalamyndari_audkenni"] + "\\" + row["vorsluutgafa"];
            }
        
            if (Directory.Exists(m_strRoot.Replace("AVID", "FRUM")))
            {
                m_btnFrumRit.Enabled = true;
            }
            else
            {
                m_btnFrumRit.Enabled = false;
            }

            int iID = Convert.ToInt32(m_strFileValinn);
            double dColl = iID / 10000;
            if (iID == 1)
            {
                dColl = 1;
            }
            else
            {
                dColl = dColl + 1;
            }


            string strValid = m_strRoot + "\\Documents\\docCollection" + dColl.ToString() + "\\" + strValdi;
            string[] strFiles = Directory.GetFiles(strValid);
            m_strFileValinn = strFiles[0];

           


            //Image image = Image.FromFile(m_strFileValinn);
            //m_pibSkjal.Image = image;

            fyllaFilesystem();
            fyllaMyndSkjal(Convert.ToInt32(m_strIdValinn), 1);
            //id, vorsluutgafa, titill_vorsluutgafu, heiti_gagangrunns, tegund_grunns, tafla_grunns, dalkur_documentid, documentid, dalkur_doctitill, doctitill, dalkur_docCreated, docCreated, dalkur_docLastWriten, docLastWriten, dalkur_malID, malID, dalkur_malTitill, maltitill, docInnihald, vorslustofnun_audkenni, vorslustofnun_heiti, skjalamyndari_audkenni, skjalamyndari_heiti, skjalaskra_timabil, skjalaskra_adgengi, skjalaskra_afharnr, skjalaskra_innihald, hver_skradi, dags_skrad
            //finna skráaendingar
            string strExt = String.Empty;
            foreach(DataRow rex in m_dtSkrar.Rows)
            {
               
                string[] strSplit = rex["mappa"].ToString().Split("." +
                    "");
                strExt = strSplit[strSplit.Length-1];
                string strExp = "extension = '" + "."+ strExt + "'";
                DataRow[] fRow = m_dtExtension.Select(strExp);
                if(fRow.Length == 0)
                {
                    DataRow re = m_dtExtension.NewRow();
                    re["extension"] = "." + strExt;
                    m_dtExtension.Rows.Add(re);
                    m_dtExtension.AcceptChanges();
                }
            }
            fyllaExtension();
        }
  
       private void fyllaExtension()
        {
            
            DataRow r = m_dtExtension.NewRow();
            r["extension"] = "Veldu skráaendingu";
            m_dtExtension.Rows.InsertAt(r, 0);
            //  id, vorsluutgafa, heiti_gagnagrunns, orgina_heiti
            m_comExternsion.ValueMember = "extension";
            m_comExternsion.DisplayMember = "extension";
            m_comExternsion.DataSource = m_dtExtension;
           
        }
        private void fyllaFilesystem()
        {
            //sækja fyrirspurnina
            string strFyrirspurn =  midlun.getFyrirspurn(m_strGagnagrunnur, "Get_files_path");
            if(strFyrirspurn == string.Empty) //vegna nafnabreytinga AV 
            {
               strFyrirspurn =  midlun.getFyrirspurn(m_strGagnagrunnur, "AV_Get_files_path");
            }
            //keyra fyrirspurninga
            m_dtSkrar = midlun.keyraFyrirspurn(strFyrirspurn, m_strGagnagrunnur);
            int i = 0;
            string strSkra = string.Empty;
            foreach (DataRow r in m_dtSkrar.Rows)
            {
                PopulateTreeView(m_trwFileSystem, m_dtSkrar.Rows[i]["mappa"].ToString().Split('\\'), '\\', r["skjalID"].ToString(), m_dtSkrar.Rows[i]["mappa"].ToString());
            //    PopulateTreeView2(m_trwFileSystem, m_dtSkrar.Rows[i]["mappa"].ToString().Split('\\'), '\\');
                if (r["skjalID"].ToString() == m_strIdValinn)
                {
                    string[] strSplit = m_dtSkrar.Rows[i]["mappa"].ToString().Split('\\');
                    //   m_tobLeitarord.Text = m_dtSkrar.Rows[i]["mappa"].ToString();
                    strSkra = strSplit[strSplit.Length - 1]; // r["skjalID"].ToString();
                    m_lilSlod.Text = string.Format("Slóð: {0}", m_dtSkrar.Rows[i]["mappa"].ToString().Replace(strSkra, ""));
                    m_lblSlodFile.Text = string.Format("Titill: {0}{1}{2}", strSkra, Environment.NewLine, m_strIdValinn);
                }
                i++;
            }
           TreeNode[] nodues =  m_trwFileSystem.Nodes.Find(strSkra + "\\", true);
            if (m_trwFileSystem.SelectedNode != null)
            {
                Point p = new Point(m_trwFileSystem.SelectedNode.Bounds.X, m_trwFileSystem.SelectedNode.Bounds.Y);
           //     m_trwFileSystem.PointToClient(p);
             //   m_trwFileSystem.SelectedNode = nodues[0];
            }
               
        }

        private static void PopulateTreeView2(TreeView treeView, string[] paths, char pathSeparator)
        {
            TreeNode lastNode = new TreeNode();
            string subPathAgg;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode != null)
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
                lastNode = null; // This is the place code was changed

            }
        }
     

        public void PopulateTreeView(TreeView treeView, string[] paths, char pathSeparator, string strTag, string strSlod)
        {
            TreeNode lastNode = null;
            string subPathAgg = string.Empty;
            int i = 0;
            foreach (string path in paths)
            {
             //   subPathAgg = string.Empty;
                i++;
                bool bSkjal = false;
                if(i == paths.Length)
                {
                    if(path.Contains("."))
                    {
                        bSkjal = true;
                    }
                }
              
               if (m_strIdValinn == strTag || !bSkjal)
                {

                    foreach (string subPath in path.Split(pathSeparator))
                    {
                        subPathAgg += subPath + pathSeparator;
                        //var nodus = m_trwFileSystem.FlattenTree()
                        // .Where(nn => nn.Tag == lastNode.Tag)
                        //.ToList();
                        TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);  //leitar bara að nafni og finnur oft vitlaust og setur í
                        if (nodes.Length == 0)
                        {
                            if (lastNode == null)
                            {
                                lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                                lastNode.Expand();

                            }

                            else
                            {
                                lastNode = lastNode.Nodes.Add(subPathAgg, subPath);

                               if(bSkjal) //if (lastNode.Text.Contains('.'))
                                {
                                    lastNode.Tag = strTag;
                                    if(m_strIdValinn == strTag)
                                    {
                                        lastNode.BackColor = Color.LightGreen;
                                        m_trwFileSystem.SelectedNode = lastNode;
                                    }
                                }
                               else
                                {
                                    lastNode.Tag = strSlod;
                                }

                            }

                        }

                        else
                        {
                            lastNode = nodes[0];
                            if(lastNode.IsSelected)
                            {
                                lastNode.Expand();
                            }
                           
                           
                        }


                    }
                }

            }
        }

        private void m_btnFrumRit_Click(object sender, EventArgs e)
        {

            string strFrum = m_strFileValinn.Replace("AVID", "FRUM");
            string strDirectory = new FileInfo(strFrum).Directory.FullName;
            string[] strFiles = Directory.GetFiles(strDirectory);


         
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(strFiles[0])
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void m_btnAfrit_Click(object sender, EventArgs e)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(m_strFileValinn)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void m_trwFileSystem_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(m_trwFileSystem.Focused)
            {
               
                if(e.Node.Tag != null)
                {
                    if (e.Node.Tag.ToString().Contains("\\"))
                    {
                        string[] strSplit = e.Node.Tag.ToString().Split("\\");
                        string strSlod = e.Node.Tag.ToString().Replace(strSplit[strSplit.Length - 1], "");
                        m_lilSlod.Text = string.Format("Slóð {0}{1}", strSlod, Environment.NewLine);
                        m_lblDagsetning.Text = string.Empty;
                        m_lblSlodFile.Text = string.Empty;
                    }
                    else
                    {
                        string[] strSplit = e.Node.Parent.Tag.ToString().Split("\\");
                        string strSlod = e.Node.Parent.Tag.ToString().Replace(strSplit[strSplit.Length - 1], "");
                        m_lilSlod.Text = string.Format("Slóð {0}{1}", strSlod, Environment.NewLine);

                        m_lblSlodFile.Text = string.Format("Titill: {0}{1}Auðkenni skjals: {2}", e.Node.Text, Environment.NewLine, e.Node.Tag);
                    }
                  
                    if (e.Node.Tag.ToString().Contains("\\"))
                    {
                     //   MessageBox.Show("gaman");

                        
                        string strSkra = e.Node.Tag.ToString();
                        string strMappa = e.Node.Text;
                        string[] strSplit = strSkra.Split('\\');
                        string strLeitMappa = string.Empty;
                        bool bBuid = false;
                        foreach(string str in strSplit)
                        {
                            if(!bBuid)
                            {
                                strLeitMappa +=  str + "\\";
                                if (str == strMappa)
                                {
                                    bBuid = true;
                                }
                            }
                        }
                        string strExp = "mappa like '" + strLeitMappa + "%'";
                        DataTable dtRest = new DataTable();
                        DataRow[] fRows = m_dtSkrar.Select(strExp);
                       
                        foreach(DataRow r in fRows)
                        {
                          //string strValid =  e.Node.Tag.ToString();
                          //string strMappaTest = r["mappa"].ToString();
                          //  if(strValid == strMappaTest)
                          //  {

                          //  }
                           strSplit = r["mappa"].ToString().Split("\\");
                            foreach(string str in strSplit)
                            {
                                if(bBuid)
                                {
                                    if(str == strMappa)
                                    {
                                        bBuid = false;
                                    }
                                }
                                else
                                {
                                    if (r["mappa"].ToString().Contains(strMappa + "\\" + str))
                                    {
                                        if (str.Contains("."))
                                        {
                                            TreeNode n = new TreeNode(str);
                                            n.Tag = r["skjalID"].ToString();
                                            Boolean b = false;
                                            foreach (TreeNode thisNode in e.Node.Nodes)
                                            {
                                              if(thisNode.Text == n.Text)
                                                {
                                                    b = true;
                                                }
                                            }
                                            if(!b)
                                            {
                                                n.Tag = r["skjalID"].ToString();
                                                var nodus = m_trwFileSystem.FlattenTree()
                                                 .Where(nn => nn.Tag == n.Tag)
                                                .ToList();
                                                //TreeNode[] nodes = m_trwFileSystem.Nodes.Find(n.Tag.ToString(), true);
                                                if (nodus.Count == 0)
                                                {
                                                    e.Node.Nodes.Add(n);
                                                    n.BackColor = Color.LightGray;
                                                    e.Node.Expand();
                                                  

                                                }
                                             
                                            }
                                            else
                                            {

                                            }

                                        }
                                        else
                                        {
                                            TreeNode n = new TreeNode(str);
                                            n.Tag = strLeitMappa; // + str;
                                            //var nodus = m_trwFileSystem.FlattenTree()
                                            // .Where(nn => nn.Tag == n.Tag)
                                            //.ToList();
                                            TreeNode[] nodes = m_trwFileSystem.Nodes.Find(n.Tag.ToString(), true);
                                            
                                            if (nodes[0] == null)
                                            {
                                                e.Node.Nodes.Add(n);
                                                e.Node.Expand();
                                            }

                                        }
                                    }
                                  
                                }

                            }
                      
                        }
                    }
                    else
                    {
                          
                        int iID = Convert.ToInt32(e.Node.Tag);
                        fyllaMyndSkjal(iID,1);
                      
                    }
                  
                }
                
            }
            
        }

        private void fyllaMyndSkjal(int iID, int iPage)
        {
            m_strIdValinn = iID.ToString();
            double dColl = Convert.ToInt32(m_strIdValinn)/ 10000;
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

            FileInfo fifo = new FileInfo(strFiles[0]);

            if(fifo.Extension == ".tif")
            {
                Image image = Image.FromFile(m_strFileValinn);
                FrameDimension dimension;

                dimension = FrameDimension.Page;
                int x = 70;
                int iPages = image.GetFrameCount(dimension);
                m_numUpDown.Maximum = iPages;
                m_numUpDown.Minimum = 1;
                m_lblSidaValinn.Text = string.Format("af {0} valin", iPages);
                string strExp = "skjalID='" + m_strIdValinn + "'";
                DataRow[] frow = m_dtSkrar.Select(strExp);
                if (frow.Length > 0)
                {
                    var date = Convert.ToDateTime(frow[0]["Lastwriten"]);
                    double diff = (DateTime.Now- date).TotalDays;
                    var totalYears = Math.Truncate(diff / 365);
                    var totalMonths = Math.Truncate((diff % 365) / 30);
                    var remainingDays = Math.Truncate((diff % 365) % 30);
                   string strDate = date.Day.ToString() + "." + date.Month.ToString() + "." + date.Year.ToString() ; 
                    TimeSpan tSpan = DateTime.Now - date;
                    if(totalYears.ToString() == "1")
                    {
                        m_lblDagsetning.Text = string.Format("Skjalinu var síðast breytt fyrir {0} ári, {1} mánuðum og {2} dögum eða þann {3}", totalYears, totalMonths, remainingDays, strDate);
                    }
                    else
                    {
                        m_lblDagsetning.Text = string.Format("Skjalinu var síðast breytt fyrir fyrir {0} árum, {1} mánuðum og {2} dögum eða þann {3}", totalYears, totalMonths, remainingDays, strDate);
                    }
                   
                }
                image.SelectActiveFrame(FrameDimension.Page, iPage - 1); // iPages - 1);
                m_pibSkjal.Image = image;
            }
            if(fifo.Extension == ".mpg")
            {

                string strExp = "skjalID='" + m_strIdValinn + "'";
                DataRow[] frow = m_dtSkrar.Select(strExp);
                if (frow.Length > 0)
                {
                    //  DateTime date = Convert.ToDateTime[]
                    m_lblDagsetning.Text = string.Format("Síðast var skráð í skjalið {0}", frow[0]["lastwriten"]);
                }
                 m_pibSkjal.ImageLocation = "video.png";
            }
            
           
            //opna blættí skalið
        }

         private void pageImaga(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string[] strSplit = b.Text.Split("/");
            string stPage = strSplit[0].Replace("Mynd ", "");
            int ipage = Convert.ToInt32(stPage);
            fyllaMyndSkjal(Convert.ToInt32(m_strIdValinn), ipage);
        }

        private void m_btnLeita_Click(object sender, EventArgs e)
        {
            leitInnra();
        }
        private void leitInnra()
        {
            m_trwLeit.Nodes.Clear();
            if(arr.Count> 0) 
            {
                foreach (TreeNode n in arr)
                {
                    n.BackColor = Color.White;
                }
                arr.Clear();
            }
          
            DataTable dt = m_dtSkrar.Clone();

            
            midlun.leitarord = m_tobLeitarord.Text ;

          
            if (m_dtpStart.Checked)
            {
                midlun.Upphafsdags = m_dtpStart.Value.ToString();
            }
            if (m_dtEnd.Checked)
            {
                midlun.Endadags = m_dtEnd.Value.ToString();
            }
            if(m_comExternsion.SelectedIndex != 0)
            {
                midlun.extension = m_comExternsion.SelectedValue.ToString();
            }
            string strIDS = midlun.leitInnra(m_tobLeitarord.Text, m_strGagnagrunnur);
            if (strIDS != string.Empty)
            {
                string strExp = "skjalid in(" + strIDS + ")"; // "skjalid in(2051,3496)";
                DataRow[] frow = m_dtSkrar.Select(strExp);
                m_lblLeitarNidurstodur.Text = string.Format("Það fundust {0} skjöl útfrá leitarskilyrðum", frow.Length.ToString());
                m_tacStrukturLeit.SelectedTab = m_tapLeitNiðutstöður;
                m_tapLeitNiðutstöður.Text = string.Format("Leitarniðurstöður ({0})", frow.Length);
                foreach (DataRow r in frow)
                {
                    dt.ImportRow(r);
                    string[] strSplit = r["mappa"].ToString().Split("\\");
                    TreeNode n = new TreeNode(strSplit[strSplit.Length-1]);
                    n.Tag = r["skjalID"].ToString();
                    m_trwLeit.Nodes.Add(n);
                  
                }
                
             
             
                
                    foreach(DataRow f in frow)
                    {
                      string strMappa = f["mappa"].ToString();
                      FileInfo fifo = new FileInfo(strMappa);
                      string[] strSpit = strMappa.Split("\\");
                     string strID = strSpit[strSpit.Length - 2] +"\\";
                      TreeNode[] tNode = m_trwFileSystem.Nodes.Find(strID, true);
                        if( tNode.Length != 0)
                        {
                            if (f["skjalID"].ToString() != m_strIdValinn)
                            {
                                TreeNode nn = new TreeNode(strSpit[strSpit.Length - 1]);
                                nn.Tag = f["skjalID"].ToString();
                                nn.BackColor = Color.LightGreen;
                                tNode[0].Nodes.Add(nn);

                                tNode[0].Expand();
                                arr.Add(nn);
                            }
                           

                        }

                    }
                m_trwFileSystem.ExpandAll();
                if(arr.Count != 0)
                {
                    m_trwFileSystem.SelectedNode = (TreeNode)arr[0];

                }
            }
            else
            {
                m_lblLeitarNidurstodur.Text = "Engar leitarniðurstöður";
            }
       
        }

      
        public void PopulateTreeViewInnriLeit(TreeView treeView, string[] paths, char pathSeparator, string strTag, string strSlod)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            int i = 0;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                i++;
                bool bSkjal = false;
                if (i == paths.Length)
                {
                    if (path.Contains("."))
                    {
                        bSkjal = true;
                    }
                }

               // if (m_strIdValinn == strTag || !bSkjal)
                {

                    foreach (string subPath in path.Split(pathSeparator))
                    {
                        subPathAgg += subPath + pathSeparator;
                        TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                        if (nodes.Length == 0)
                        {
                            if (lastNode == null)
                            {
                                lastNode = treeView.Nodes.Add(subPathAgg, subPath);

                            }

                            else
                            {
                                lastNode = lastNode.Nodes.Add(subPathAgg, subPath);

                                if (bSkjal) //if (lastNode.Text.Contains('.'))
                                {
                                    lastNode.Tag = strTag;
                                    if (m_strIdValinn == strTag)
                                    {
                                        lastNode.BackColor = Color.LightGreen;
                                    }
                                }
                                else
                                {
                                    lastNode.Tag = strSlod;
                                }

                            }

                        }

                        else
                        {
                            lastNode = nodes[0];

                        }


                    }
                }

            }
        }

        private void m_tobLeitarord_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                leitInnra();
            }
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

        private void m_numUpDown_ValueChanged(object sender, EventArgs e)
        {
           
            fyllaMyndSkjal(Convert.ToInt32(m_strIdValinn),Convert.ToInt32(m_numUpDown.Value));
        }

        private void m_dtpStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void m_lblLeitarNidurstodur_Click(object sender, EventArgs e)
        {

        }

        private void m_trwFileSystem_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNode(e.Node, e.Node.Checked);
            if(e.Node.Checked )
            {
                if(e.Node.Tag != null)
                {
                    if (!e.Node.Tag.ToString().Contains("\\"))
                    {
                        DataRow r = m_dtValid.NewRow();
                        r["skjalID"] = e.Node.Tag;
                        r["titill"] = e.Node.Text;
                        r["vorsluutgafa"] = m_strVorslutgafa;
                        string strExpr = "skjaliD = '" + e.Node.Tag.ToString() + "'";
                        DataRow[] fRow = m_dtValid.Select(strExpr);
                        if (fRow.Length == 0)
                        {
                            m_dtValid.Rows.Add(r);
                            m_dtValid.AcceptChanges();

                        }

                    }

                }


            }
            else
            {
                if (e.Node.Tag != null)
                {
                    string strExpr = "skjaliD = '" + e.Node.Tag.ToString() + "'";
                    DataRow[] fRow = m_dtValid.Select(strExpr);
                    if (fRow.Length != 0)
                    {
                        int iLength = fRow.Length;
                        for (int i = 0; i < iLength; i++)
                        {
                            fRow[i].Delete();
                        }

                        m_dtValid.AcceptChanges();
                    }

                }
            }
            int iFjoldi = m_dtValid.Rows.Count + m_dtGrunn.Rows.Count + m_dtMal.Rows.Count;
            if(iFjoldi == 0)
            {
                m_btnAfgreida.Enabled = false;  
            }
            else
            {
                m_btnAfgreida.Enabled = true;   
            }
            m_dgvValdarSkrar.DataSource = m_dtValid;
            m_tapSkraarkerfi.Text = string.Format("Skráakerfi ({0})", m_dtValid.Rows.Count);
          //  m_grbValdinnSkjol.Text = string.Format("Valinn skjöl ({0})", m_dtValid.Rows.Count);
        }
        private void CheckTreeViewNode(TreeNode node, Boolean isChecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;
                if(isChecked )
                {
                    if(!item.Tag.ToString().Contains("\\"))
                    {
                        DataRow r = m_dtValid.NewRow();
                        r["skjalID"] = item.Tag;
                        r["titill"] = item.Text;
                        r["vorsluutgafa"] = m_strVorslutgafa;
                        string strExpr = "skjaliD = '" + item.Tag.ToString() + "'";
                        DataRow[] fRow = m_dtValid.Select(strExpr);
                        if(fRow.Length == 0 )
                        {
                            m_dtValid.Rows.Add(r);
                            m_dtValid.AcceptChanges();
                        }
                    }
                 
                }
                else
                {
                    string strExpr = "skjaliD = '" + item.ToString() + "'";
                    DataRow[] fRow = m_dtValid.Select(strExpr);
                    if (fRow.Length > 0)
                    {
                        fRow[0].Delete();
                        m_dtValid.AcceptChanges();
                    }
                }

                if (item.Nodes.Count > 0)
                {
                    this.CheckTreeViewNode(item, isChecked);
                }
            }
        }

        private void m_btnAfgreida_Click(object sender, EventArgs e)
        {
            
            frmAfgreidsla frmAfgreida = new frmAfgreidsla(virkurnotandi,m_dtValid, m_dtMal, m_dtGrunn, m_dsDIPmal);
            frmAfgreida.ShowDialog();

            int iFjold = m_dtValid.Rows.Count + m_dtMal.Rows.Count + m_dtGrunn.Rows.Count;  

           if(iFjold == 0)
            {
                m_btnAfgreida.Enabled = false;  
            }
           else
            {
                m_btnAfgreida.Enabled = true;
            }

            m_tapGagnagrunnar.Text = string.Format("Gagnagrunnar ({0})", m_dtGrunn.Rows.Count);
            m_tapMalakerfi.Text = string.Format("Málakerfi ({0})", m_dtMal.Rows.Count);
            m_tapSkraarkerfi.Text = string.Format("Skráakerfi ({0})", m_dtValid.Rows.Count);




        }

        private void m_trwLeit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_trwLeit.Focused)
            {
                if (e.Node.Tag != null)
                {
                    //vantar að finna slóð útfrá docid
                    string strExp ="skjalID = '" + e.Node.Tag.ToString() + "'";
                    DataRow[] fRow = m_dtSkrar.Select(strExp);
                    string strSlod = string.Empty;
                    if(fRow.Length ==1)
                    {
                        strSlod= fRow[0]["mappa"].ToString();
                        string[] strSplit = strSlod.Split("\\");
                        strSlod = strSlod.Replace(strSplit[strSplit.Length - 1], "");
                    }

                    m_lilSlod.Text = string.Format("Slóð {0}{1}", strSlod, Environment.NewLine);

                    m_lblSlodFile.Text = string.Format("Titill: {0}{1}Auðkenni skjals: {2}", e.Node.Text, Environment.NewLine, e.Node.Tag);
                  //  m_lblSlodFile.Text = string.Format("Slóð skjals {0}{1}", e.Node.Tag.ToString(), Environment.NewLine);
                     int iID = Convert.ToInt32(e.Node.Tag);
                    fyllaMyndSkjal(iID, 1);

                    

                }

            }
        }

        private void m_trwLeit_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNode(e.Node, e.Node.Checked);
            if (e.Node.Checked)
            {
                if (e.Node.Tag != null)
                {
                    if (!e.Node.Tag.ToString().Contains("\\"))
                    {
                        DataRow r = m_dtValid.NewRow();
                        r["skjalID"] = e.Node.Tag;
                        r["titill"] = e.Node.Text;
                        r["vorsluutgafa"] = m_strVorslutgafa;
                        string strExpr = "skjaliD = '" + e.Node.Tag.ToString() + "'";
                        DataRow[] fRow = m_dtValid.Select(strExpr);
                        if (fRow.Length == 0)
                        {
                            m_dtValid.Rows.Add(r);
                            m_dtValid.AcceptChanges();

                        }

                    }

                }


            }
            else
            {
                if (e.Node.Tag != null)
                {
                    string strExpr = "skjaliD = '" + e.Node.Tag.ToString() + "'";
                    DataRow[] fRow = m_dtValid.Select(strExpr);
                    if (fRow.Length != 0)
                    {
                        int iLength = fRow.Length;
                        for (int i = 0; i < iLength; i++)
                        {
                            fRow[i].Delete();
                        }

                        m_dtValid.AcceptChanges();
                    }

                }
            }
            int iFjoldi = m_dtValid.Rows.Count + m_dtGrunn.Rows.Count + m_dtMal.Rows.Count;
            if (iFjoldi == 0)
            {
                m_btnAfgreida.Enabled = false;
            }
            else
            {
                m_btnAfgreida.Enabled = true;
            }
            m_dgvValdarSkrar.DataSource = m_dtValid;
            m_tapSkraarkerfi.Text = string.Format("Skráakerfi ({0})", m_dtValid.Rows.Count);
            //  m_grbValdinnSkjol.Text = string.Format("Valinn skjöl ({0})", m_dtValid.Rows.Count);
        }

        private void m_dgvValdarSkrar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if ((senderGrid.Columns["colSkraEyda"].Index == e.ColumnIndex))
                {
                    DialogResult result = MessageBox.Show("Viltu fjarlægja þetta skjal?", "Fjarlæjga skjal", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string strID = senderGrid.Rows[e.RowIndex].Cells["colAudkenniSkjals"].Value.ToString();
                        string strExp = "skjalID ='" + strID + "'";
                        DataRow[] frow = m_dtValid.Select(strExp);
                        frow[0].Delete();
                        m_dtValid.AcceptChanges();
                        m_dgvValdarSkrar.DataSource = m_dtValid;
                        m_tapSkraarkerfi.Text = string.Format("Skráakerfi ({0})", m_dtValid.Rows.Count);
                        //finna í Treeviewinum
                        var nodus = m_trwFileSystem.FlattenTree()
                                                .Where(nn => nn.Tag == strID)
                                               .ToList();
                        //TreeNode[] nodes = m_trwFileSystem.Nodes.Find(strID, true);
                        //nodes[0].Checked = false;
                        if (nodus.Count == 1)
                        {
                            nodus[0].Checked = false;
                        }
                        nodus = m_trwLeit.FlattenTree()
                                                .Where(nn => nn.Tag == strID)
                                               .ToList();

                        if (nodus.Count == 1)
                        {
                            nodus[0].Checked = false;
                        }
                    }
                }
            }
        }

        private void m_lilSlod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strSlod = m_lilSlod.Text.Replace("Slóð ", "").Trim();
           

            string strMappa = string.Empty;
            string[] strSplit = strSlod.Split('\\');
            string strLeitMappa = string.Empty;
            bool bBuid = false;
            string strSkjalID = string.Empty;
            if (m_tacStrukturLeit.SelectedTab == m_tapMoppuStruct)
            {
                strSkjalID = m_trwFileSystem.SelectedNode.Tag.ToString();
            }
            else
            {
                if(m_trwLeit.SelectedNode is  null)
                {
                    strSkjalID = m_trwFileSystem.SelectedNode.Tag.ToString();
                }
                else
                {
                    strSkjalID = m_trwLeit.SelectedNode.Tag.ToString();
                }
                
            }
            m_tacStrukturLeit.SelectedTab = m_tapMoppuStruct;
            foreach (string str in strSplit)
            {
                if(str != string.Empty)
                {
                    if (!bBuid)
                    {
                        strLeitMappa += str + "\\";
                        TreeNode[] node = m_trwFileSystem.Nodes.Find(strLeitMappa, true);
                        if (node.Length == 0)
                        {
                            strMappa = str;
                            bBuid = true;
                        }
                    }
                }
                
            }
            string strExp = "mappa like '" + strLeitMappa + "%'";
            DataTable dtRest = new DataTable();
            DataRow[] fRows = m_dtSkrar.Select(strExp);

            foreach (DataRow r in fRows)
            {
                //string strValid =  e.Node.Tag.ToString();
                //string strMappaTest = r["mappa"].ToString();
                //  if(strValid == strMappaTest)
                //  {

                //  }
                strSplit = r["mappa"].ToString().Split("\\");
                int i = 1;
                foreach (string str in strSplit)
                {
                    if (bBuid)
                    {
                        if (str == strMappa)
                        {
                            bBuid = false;
                        }
                    }
                    else
                    {
                        if (r["mappa"].ToString().Contains(strMappa + "\\" + str))
                        {
                            if (str.Contains(".") && i == strSplit.Length)
                            {
                                TreeNode[] nodes = m_trwFileSystem.Nodes.Find(strLeitMappa, true);
                                TreeNode n = new TreeNode(str);
                                n.Tag = r["skjalID"].ToString();
                                Boolean b = false;
                                //foreach (TreeNode thisNode in e.Node.Nodes)
                                //{
                                //    if (thisNode.Text == n.Text)
                                //    {
                                //        b = true;
                                //    }
                                //}
                         //       if (!b)
                                {
                                    n.Tag = r["skjalID"].ToString();
                                    var nodus = m_trwFileSystem.FlattenTree()
                                     .Where(nn => nn.Tag == n.Tag)
                                    .ToList();
                                   // TreeNode[] nodesX = m_trwFileSystem.Nodes.Find(n.Tag.ToString(), true);
                                    if (nodus.Count == 0)
                                    {
                                        if (n.Tag.ToString() == strSkjalID)
                                        {
                                            TreeNodeCollection colNode = nodes[0].Nodes;
                                            bool bErTil = false;
                                            foreach(TreeNode nx in colNode)
                                            {
                                                if(nx.Text == n.Text)
                                                {
                                                    nx.BackColor = Color.LightBlue;
                                                    nodes[0].Expand();
                                                    m_trwFileSystem.SelectedNode = nx;
                                                    //Point p = new Point(nx.Bounds.X, nx.Bounds.Y);
                                                    //m_trwFileSystem.AutoScrollOffset = p;
                                                    bErTil = true;
                                                }
                                            }
                                            if(!bErTil)
                                            {
                                                nodes[0].Nodes.Add(n);
                                                n.BackColor = Color.LightBlue;
                                                nodes[0].Expand();
                                                m_trwFileSystem.SelectedNode = n;
                                                //Point p = new Point(n.Bounds.X, n.Bounds.Y);
                                               // m_trwFileSystem.AutoScrollOffset = p;
                                            }
                                          
                                        }
                                       
                                    }

                                }
                                

                            }
                            else
                            {
                                //TreeNode n = new TreeNode(str);
                                //n.Tag = strLeitMappa; // + str;
                                //                      //var nodus = m_trwFileSystem.FlattenTree()
                                //                      // .Where(nn => nn.Tag == n.Tag)
                                //                      //.ToList();
                                //TreeNode[] nodes = m_trwFileSystem.Nodes.Find(n.Tag.ToString(), true);

                                //if (nodes[0] == null)
                                //{
                                //    e.Node.Nodes.Add(n);
                                //    e.Node.Expand();
                                //}

                            }
                           
                        }

                    }
                    i++;
                }

            }
        }
    }
    public static class SOExtension
    {
        public static IEnumerable<TreeNode> FlattenTree(this TreeView tv)
        {
            return FlattenTree(tv.Nodes);
        }

        public static IEnumerable<TreeNode> FlattenTree(this TreeNodeCollection coll)
        {
            return coll.Cast<TreeNode>()
                        .Concat(coll.Cast<TreeNode>()
                                    .SelectMany(x => FlattenTree(x.Nodes)));
        }
    }
}
