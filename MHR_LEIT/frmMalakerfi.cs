using System;
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
        string m_strGagnagrunnur = string.Empty;
        cMIdlun midlun = new cMIdlun();
        DataTable m_dtFyrirspurnir = new DataTable();
        string  m_strIdValinn = string.Empty; //skjal sem er valið í niðurstöðum
        string m_strFileValinn = string.Empty;
        string m_strRoot = string.Empty;
        cVHS_drives drive = new cVHS_drives();

        public frmMalakerfi()
        {
            InitializeComponent();
        }

        public frmMalakerfi(string strGagnagrunnur, DataRow row)
        {
            InitializeComponent();
            m_pibSkjal.Focus();
            m_strGagnagrunnur = strGagnagrunnur;
            m_dtFyrirspurnir = midlun.getGagnagrunnaFyrirSpurnir(m_strGagnagrunnur);
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
            //fylla málatöflu með máli undir þessu málID
            strExp = "nafn='mal_malID'";
            fRow = m_dtFyrirspurnir.Select(strExp);
            strSQL = fRow[0]["fyrirspurn"].ToString();
            strSQL = strSQL.Replace("{malID}", strMalID);
            dtMal = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
          //  MessageBox.Show(strSQL);
            m_dgvMal.DataSource = dtMal;
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
                    m_dgvMal.DataSource = dtMal;
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
                    string strLykillID = e.Node.Tag.ToString();
                    string strExp = "nafn='mal_gogn'";
                    DataRow[] fRow = m_dtFyrirspurnir.Select(strExp);
                    string strSQL = fRow[0]["fyrirspurn"].ToString();
                    strSQL = strSQL.Replace("{docid}", strLykillID);

                    DataTable dtSkjol = midlun.keyraFyrirspurn(strSQL, m_strGagnagrunnur);
                    m_dgvSkjol.DataSource = dtSkjol;
                }
            }



        }

        private void m_dgvSkjol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string strDocID = m_dgvSkjol.Rows[e.RowIndex].Cells["DokumentID"].Value.ToString();
            fyllaMyndSkjal(Convert.ToInt32(strDocID), 1);

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
         //   m_lblSidaValinn.Text = string.Format("af {0} valin", iPages);
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
    }
}
