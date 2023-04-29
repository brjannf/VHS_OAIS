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
//using DocumentFormat.OpenXml.Drawing.Charts;
//using DocumentFormat.OpenXml.EMMA;

namespace MHR_LEIT
{
    public partial class frmSkraarkerfi : Form
    {
        cMIdlun midlun = new cMIdlun();
        cVHS_drives drive = new cVHS_drives();
        DataTable m_dtSkrar = new DataTable();
        string m_strGagnagrunnur = string.Empty;
        string m_strFileValinn = string.Empty;
        string m_strIdValinn = string.Empty;
        string m_strRoot = string.Empty;
        ArrayList arr = new ArrayList();

        public frmSkraarkerfi()
        {
            InitializeComponent();
        }
        public frmSkraarkerfi(string strGagnagrunnur,string strValdi, DataRow row, string strLeitarOrd)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            m_tobLeitarord.Text = strLeitarOrd;
            m_strGagnagrunnur =strGagnagrunnur;
            m_strIdValinn = strValdi;
            m_strFileValinn = strValdi;
             m_strRoot = drive.driveVirkkComputers() + "\\" + row["vorslustofnun_audkenni"].ToString() + "\\" + row["skjalamyndari_audkenni"] + "\\" + row["vorsluutgafa"];
            if(Directory.Exists(m_strRoot.Replace("AVID", "FRUM")))
            {
                m_btnFrumRit.Enabled = true;
            }
            else
            {
                m_btnFrumRit.Enabled = false;
            }

            int iID = Convert.ToInt32(m_strFileValinn);
            double dColl = iID / 10000;
            if(iID == 1)
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

            fyllaMyndSkjal(Convert.ToInt32(m_strIdValinn), 1);
            //Image image = Image.FromFile(m_strFileValinn);
            //m_pibSkjal.Image = image;
            
            fyllaFilesystem();
            //id, vorsluutgafa, titill_vorsluutgafu, heiti_gagangrunns, tegund_grunns, tafla_grunns, dalkur_documentid, documentid, dalkur_doctitill, doctitill, dalkur_docCreated, docCreated, dalkur_docLastWriten, docLastWriten, dalkur_malID, malID, dalkur_malTitill, maltitill, docInnihald, vorslustofnun_audkenni, vorslustofnun_heiti, skjalamyndari_audkenni, skjalamyndari_heiti, skjalaskra_timabil, skjalaskra_adgengi, skjalaskra_afharnr, skjalaskra_innihald, hver_skradi, dags_skrad

        }
        private void fyllaFilesystem()
        {
            //sækja fyrirspurnina
            string strFyrirspurn =  midlun.getFyrirspurn("Þarf að laga hér og setja í alvöru jú sí");
            //keyra fyrirspurninga
            m_dtSkrar = midlun.keyraFyrirspurn(strFyrirspurn, m_strGagnagrunnur);
            int i = 0;
            string strSkra = string.Empty;
            foreach (DataRow r in m_dtSkrar.Rows)
            {
                PopulateTreeView(m_trwFileSystem, m_dtSkrar.Rows[i]["mappa"].ToString().Split('\\'), '\\', r["skjalID"].ToString(), m_dtSkrar.Rows[i]["mappa"].ToString());
                if(r["skjalID"].ToString() == m_strIdValinn)
                {
                    string[] strSplit = m_dtSkrar.Rows[i]["mappa"].ToString().Split('\\');
                    //   m_tobLeitarord.Text = m_dtSkrar.Rows[i]["mappa"].ToString();
                    strSkra = strSplit[strSplit.Length - 1]; // r["skjalID"].ToString();
                }
                i++;
            }
           TreeNode[] nodues =  m_trwFileSystem.Nodes.Find(strSkra + "\\", true);
            m_trwFileSystem.SelectedNode = nodues[0];
        }

        public void PopulateTreeView(TreeView treeView, string[] paths, char pathSeparator, string strTag, string strSlod)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            int i = 0;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
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

                               if(bSkjal) //if (lastNode.Text.Contains('.'))
                                {
                                    lastNode.Tag = strTag;
                                    if(m_strIdValinn == strTag)
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
                    if(e.Node.Tag.ToString().Contains("\\"))
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
                                    if(str.Contains("."))
                                    {
                                        TreeNode n = new TreeNode(str);
                                        n.Tag = r["skjalID"].ToString();
                                        e.Node.Nodes.Add(n);
                                        e.Node.Expand();
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

            Image image = Image.FromFile(m_strFileValinn);
            FrameDimension dimension;

            dimension = FrameDimension.Page;
            int x = 70;
            int iPages = image.GetFrameCount(dimension);
            splitContainer3.Panel1.Controls.Clear();
            for (int i = 0; i < iPages; i++)
            {
                Button l  = new Button();
                l.Text = string.Format("Mynd {0}/{1}", i + 1, iPages);
                splitContainer3.Panel1.Controls.Add(l);
                Point p = new Point(x, 0);
                l.Location = p;
                x = x + 100;
                l.Click += new EventHandler(pageImaga);

            }
            image.SelectActiveFrame(FrameDimension.Page, iPage-1); // iPages - 1);
            m_pibSkjal.Image = image;
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
            if(arr.Count> 0) 
            {
                foreach (TreeNode n in arr)
                {
                    n.BackColor = Color.White;
                }
                arr.Clear();
            }
          
            DataTable dt = m_dtSkrar.Clone();
            string strIDS = midlun.leitInnra(m_tobLeitarord.Text, m_strGagnagrunnur);
            if (strIDS != string.Empty)
            {
                string strExp = "skjalid in(" + strIDS + ")"; // "skjalid in(2051,3496)";
                DataRow[] frow = m_dtSkrar.Select(strExp);
                m_lblLeitarNidurstodur.Text = frow.Length.ToString();
                foreach (DataRow r in frow)
                {
                    dt.ImportRow(r);
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
                            TreeNode nn = new TreeNode(strSpit[strSpit.Length - 1]);
                            nn.Tag = f["skjalID"].ToString();
                            nn.BackColor = Color.LightGreen;
                            tNode[0].Nodes.Add(nn);
                            
                            tNode[0].Expand();
                            arr.Add(nn);

                        }

                    }
                m_trwFileSystem.ExpandAll();
                m_trwFileSystem.SelectedNode = (TreeNode)arr[0];
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
    }
}