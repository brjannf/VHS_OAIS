using cClassOAIS;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math.EC.Multiplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIS_ADMIN
{
    public partial class uscInnSetning : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        public cVorslustofnun vörslustofnun = new cVorslustofnun();
        public cSkjalamyndari skjalamyndari = new cSkjalamyndari();
        public cSkjalaskra skrá = new cSkjalaskra();
        public uscInnSetning()
        {
            InitializeComponent();
        }

        private void m_lblDragDrop_Click(object sender, EventArgs e)
        {
          
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                string strFileIndex = folderBrowserDialog1.SelectedPath + "\\Indices\\fileIndex.xml";
                string strArchiveIndex = folderBrowserDialog1.SelectedPath + "\\Indices\\archiveIndex.xml";
                if (File.Exists(strFileIndex))
                {
                    string[] strSplit = folderBrowserDialog1.SelectedPath.Split('\\');
                    string strVarsla = strSplit[strSplit.Length - 1];


                    fyllaVörslustofnn(strVarsla);
                    fyllaSkjalamyndara(strArchiveIndex, strVarsla);
                    fyllaSkjalaSkra(strArchiveIndex, strVarsla);
                    bMD5Test(strFileIndex, strVarsla);
                }
                else
                {
                    MessageBox.Show("Vantar fileIndex.xml");
                }

            }
        }

       
        private void m_pnlSIP_DragEnter(object sender, DragEventArgs e)
        {
            var dropped = ((string[])e.Data.GetData(DataFormats.FileDrop));

            string strFileIndex = dropped[0].ToString() + "\\Indices\\fileIndex.xml";
            string strArchiveIndex = dropped[0].ToString() + "\\Indices\\archiveIndex.xml";
            if (File.Exists(strFileIndex)) 
            {
                string[] strSplit = dropped[0].ToString().Split('\\');
                string strVarsla = strSplit[strSplit.Length-1];
                fyllaSkjalamyndara(strArchiveIndex, strVarsla);
                fyllaSkjalaSkra(strArchiveIndex, strVarsla);
                fyllaVörslustofnn(strVarsla);
                bMD5Test(strFileIndex, strVarsla);
            }
            else
            {
                MessageBox.Show("Vantar fileIndex.xml");
            }
        }

        private bool bMD5Test(string strFileName, string strVarsla)
        {
            bool bRet = true;
            DataSet ds = new DataSet();
            ds.ReadXml(strFileName);
            string strRoot = string.Empty;
            string[] strSplit = strFileName.Split("\\");
            bool bErBuid = false;
        
            foreach (string strSplitItem in strSplit)
            {
                if(strSplitItem != strVarsla && !bErBuid)
                {
                    strRoot += strSplitItem + "\\";
                    
                }
                if(strSplitItem == strVarsla) 
                {
                    bErBuid = true;
                }
            }

            m_pgbTekksuma.Step = 1;
            m_pgbTekksuma.Value = 1;
            m_pgbTekksuma.Maximum = ds.Tables[0].Rows.Count;


            string strNotOK = string.Empty;
            foreach (DataRow r in ds.Tables[0].Rows) 
            {
                string strSlod = strRoot + r["foN"] +"\\"+ r["fiN"];
                string strMD5 = r["MD5"].ToString();
                DataTable dt = new DataTable();
                dt.Columns.Add("Skjal");
                dt.Columns.Add("Skrad");
                dt.Columns.Add("Er");
                
                if(md5(strSlod) != strMD5)
                {
                    m_dgvMD5Villur.Visible = true;
                    DataRow rr = dt.NewRow();
                    rr["Skjal"] = strRoot + r["foN"] + "\\" + r["fiN"];
                    rr["Skrad"] = strMD5;
                    rr["Er"] = md5(strSlod);
                    dt.Rows.Add(rr);
                    dt.AcceptChanges();
                    m_dgvMD5Villur.DataSource = dt;

                }

                m_pgbTekksuma.PerformStep();
                m_lblTekkSuma.Text = string.Format("{0}/{1}", m_pgbTekksuma.Value, m_pgbTekksuma.Maximum);
                Application.DoEvents();
            }



            return bRet;

        }

        private string md5(string strFile)
        {
            string strRet = string.Empty;
            using (var md5 = MD5.Create())
            {
                
                // using (FileStream straumur = File.OpenRead("C:\\AVID.SA.18000.1\\Documents\\docCollection1\\1\\1.tif"))
                {
                    FileStream InputBin = new FileStream(strFile, FileMode.Open, FileAccess.Read, FileShare.None);
                    byte[] bla = md5.ComputeHash(InputBin);
                    strRet = BitConverter.ToString(bla).Replace("-", "");
                    InputBin.Close();
                }
            }
            return strRet;
        }
        private void fyllaSkjalaSkra(string strArchiveIndex, string strVarsla)
        {
            m_comISADG_aðgengi.Text = "Veldu aðgengi";
            DataSet ds = new DataSet();
            ds.ReadXml(strArchiveIndex);
            skrá.auðkenni_3_1_1 = strVarsla;
            skrá.getSkraning(skrá.auðkenni_3_1_1);
            if (skrá.ID != 0)
            {
                m_tboISADG_auðkenni.Text = skrá.auðkenni_3_1_1;
                m_tboISADG_titill.Text = skrá.titill_3_1_2;
                m_tboISADG_innihald.Text = skrá.yfirlit_innihald_3_3_1;
                m_comISADG_aðgengi.SelectedItem = skrá.skilyrði_aðgengi_3_4_1;
                m_btnSkraningStaðfesta.Text = "Staðfesta";
            }
            else
            {
                skrá.vörslustofnun = vörslustofnun.auðkenni_5_1_1;
                m_tboISADG_auðkenni.Text = skrá.auðkenni_3_1_1;
                skrá.titill_3_1_2 = ds.Tables["archiveCreatorList"].Rows[0]["creatorName"].ToString() + " - " + ds.Tables["archiveIndex"].Rows[0]["systemName"].ToString();
                m_tboISADG_titill.Text = skrá.titill_3_1_2;
                skrá.yfirlit_innihald_3_3_1 = ds.Tables["archiveIndex"].Rows[0]["systemContent"].ToString();
                m_tboISADG_innihald.Text = skrá.yfirlit_innihald_3_3_1;
                if (m_comISADG_aðgengi.SelectedItem.ToString() != "Veldu aðgengi")
                {
                    skrá.skilyrði_aðgengi_3_4_1 = m_comISADG_aðgengi.SelectedItem.ToString();
                }
                skrá.skjalamyndari = skjalamyndari.id;
                skrá.heiti_skjalamyndara_3_2_1 = skjalamyndari.opinbert_heiti_5_1_2;
                skrá.upplýsingastig_3_1_4 = "Skjalasafn";
                skrá.hver_skráði = virkurnotandi.nafn;
                m_btnSkraningStaðfesta.Text = "Vista";
            }

        }
        private void fyllaVörslustofnn(string strVarsla)
        {
            string[] strSplit = strVarsla.Split('.');
            string strVarslaAuðkenni = strSplit[1];
            vörslustofnun.getVörslustofnun(strVarslaAuðkenni);
            if(vörslustofnun.ID != 0)
            {
                vörslustofnun.auðkenni_5_1_1 = strVarslaAuðkenni;
                m_tboISDIAH_auðkenni.Text = vörslustofnun.auðkenni_5_1_1;
                vörslustofnun.hver_skráði = virkurnotandi.nafn;
                vörslustofnun.tegund_5_1_5_ = "Héraðsskjalasafn";
                vörslustofnun.skráningarstaða_5_6_4 = "Drög að lýsingu";
                vörslustofnun.skráningarstig_5_6_5 = "Lágmarks skráning";
              
                m_tboISDIAH_auðkenni.Text = vörslustofnun.auðkenni_5_1_1;
                m_tboISDIAH_obinbert_heiti.Text = vörslustofnun.opinbert_heiti_5_1_2;
                m_btnVörslustofnunStaðfesta.Text = "Staðfesta";
            }
            else
            {
                vörslustofnun.hver_skráði = virkurnotandi.nafn;
                vörslustofnun.auðkenni_5_1_1 = strVarslaAuðkenni;
                vörslustofnun.tegund_5_1_5_ = "Héraðsskjalasafn";
                vörslustofnun.skráningarstaða_5_6_4 = "Drög að lýsingu";
                vörslustofnun.skráningarstig_5_6_5 = "Lágmarks skráning";
                m_lblHeitVarslaVantar.Visible = true;
                m_tboISDIAH_auðkenni.Text = strVarslaAuðkenni;
               
                m_btnVörslustofnunStaðfesta.Text = "Vista";
            }
         
        }
        private void fyllaSkjalamyndara(string strArchiveIndex, string strVarsla)
        {
            //ÞARF AÐ BREYTA SÍÐAR - EF FLEIRI ENN EINN SKJALAMYNDARI
            //1. sækja skjalamyndara út frá nafni
            DataSet ds = new DataSet();
            ds.ReadXml(strArchiveIndex);
            string strNafn = ds.Tables["archiveCreatorList"].Rows[0]["creatorName"].ToString();
            skjalamyndari.getSkjalamyndara(strNafn);

            
            skjalamyndari.skráningarstaða_5_4_4 = "Drög að lýsingu";
            skjalamyndari.skráningarstig_5_4_5 = "Lágmarks skráning";
            //
            DataTable dt = skjalamyndari.getENUM();
            DataRow r = dt.NewRow();
            r["gerd"] = "Veldu gerð";
            dt.Rows.InsertAt(r, 0);

            m_comISAAR_gerð.ValueMember = "gerd";
            m_comISAAR_gerð.DisplayMember = "gerd";
            m_comISAAR_gerð.DataSource = dt;

            if(skjalamyndari.gerð_5_1_1 != null)
            {
                m_comISAAR_gerð.SelectedValue = skjalamyndari.gerð_5_1_1;
            }
            else
            {
                skjalamyndari.auðkenni_5_1_6 = skjalamyndari.næstaAUðkenni();
            }

            m_tboISAAR_auðkenni.Text = skjalamyndari.auðkenni_5_1_6;
            m_comISAAR_nafn.Text = strNafn;
            skjalamyndari.opinbert_heiti_5_1_2 = strNafn;
            skjalamyndari.hver_skráði = virkurnotandi.nafn;
            if(skjalamyndari.id != 0)
            {
                m_btnSkjalamyndariStadfesta.Text = "Staðfesta";
            }
            else
            {
                m_btnSkjalamyndariStadfesta.Text = "Vista";
            }
        }

        private void m_btnStadfesta_Click(object sender, EventArgs e)
        {

            switch (m_btnSkjalamyndariStadfesta.Text)
            {
                case "Vista":
                    errorProvider1.Clear();
                    if(m_comISAAR_gerð.SelectedIndex== 0)
                    {
                        errorProvider1.SetError(m_comISAAR_gerð, "Veldu gerð skjalamyndara");
                    }
                    if(m_comISAAR_nafn.Text == string.Empty)
                    {
                        errorProvider1.SetError(m_comISAAR_nafn, "Vantar heiti skjalamyndara");
                    }
                    if(errorProvider1.HasErrors)
                    {
                        return;
                    }
                    skjalamyndari.auðkenni_vörslustofnunar_5_4_2 = vörslustofnun.auðkenni_5_1_1;
                    skjalamyndari.vista();
                    skjalamyndari.getSkjalamyndara(skjalamyndari.id);
                    m_btnSkjalamyndariStadfesta.Text = "Fullskrá";
                    m_grbISAAR.BackColor = Color.LightGreen;
                    break;
                case "Staðfesta":
                    m_grbISAAR.BackColor = Color.LightGreen;
                    m_btnSkjalamyndariStadfesta.Text = "Fullskrá";
                    break;

                case "Fullskrá":
                    frmSkjalamyndariSkra frmSkjal = new frmSkjalamyndariSkra(skjalamyndari, virkurnotandi);
                    frmSkjal.ShowDialog();
                    skjalamyndari.getSkjalamyndara(skjalamyndari.id);
                    m_comISAAR_gerð.SelectedValue = skjalamyndari.gerð_5_1_1;
                    m_comISAAR_nafn.Text = skjalamyndari.opinbert_heiti_5_1_2;
                    break;
            }

        }


        private void m_btnSkraningStaðfesta_Click(object sender, EventArgs e)
        {

            switch (m_btnSkraningStaðfesta.Text)
            {
                case "Vista":
                    errorProvider1.Clear();
                    if(m_comISADG_aðgengi.SelectedIndex == 0) 
                    {
                        errorProvider1.SetError(m_comISADG_aðgengi, "Veldu aðgengi");
                    }
                    if(m_tboISADG_titill.Text == string.Empty) 
                    {
                        errorProvider1.SetError(m_tboISADG_titill, "Vantar titill");
                    }
                    if(m_tboISADG_innihald.Text == string.Empty)
                    {
                        errorProvider1.SetError(m_grbISADG_innihald, "Vantar að skrá innihald");
                    }
                    if(errorProvider1.HasErrors)
                    {
                        return;
                    }
                    skrá.vista();
                    m_btnSkraningStaðfesta.Text = "Fullskrá";
                    m_grbIsadG.BackColor = Color.LightGreen;
                    break;
                case "Staðfesta":
                    m_grbIsadG.BackColor = Color.LightGreen;
                    m_btnSkraningStaðfesta.Text = "Fullskrá";
                    break;

                case "Fullskrá":
                    frmSkráning frmSkjal = new frmSkráning(skrá);
                    frmSkjal.ShowDialog();
                    break;
            }

           
        }

        private void m_comISAAR_gerð_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(m_comISAAR_gerð.SelectedIndex != 0 )
            {
                skjalamyndari.gerð_5_1_1 = m_comISAAR_gerð.SelectedValue.ToString();
            }
        }

        private void m_btnVörslustofnunStaðfesta_Click(object sender, EventArgs e)
        {
            switch (m_btnVörslustofnunStaðfesta.Text)
            {
                case "Vista":
                    errorProvider1.Clear();
                    if(m_tboISDIAH_auðkenni.Text == string.Empty)
                    {
                        errorProvider1.SetError(m_tboISDIAH_auðkenni, "Vantar auðkenni");

                    }
                    if(m_tboISDIAH_obinbert_heiti.Text == string.Empty)
                    {
                        errorProvider1.SetError(m_tboISDIAH_obinbert_heiti, "Vantar heiti vörslustofnunar");
                    }
                    if(errorProvider1.HasErrors)
                    {
                        return;
                    }

                    vörslustofnun.vista();
                    m_btnVörslustofnunStaðfesta.Text = "Fullskrá";
                    m_grbISDIAH.BackColor = Color.LightGreen;
                    break;
                case "Staðfesta":
                    if(vörslustofnun.ID != 0)
                    {
                        m_grbISDIAH.BackColor = Color.LightGreen;
                        m_btnVörslustofnunStaðfesta.Text = "Fullskrá";
                    }
                 
                    break;

                case "Fullskrá":
                    frmVörslustofnun frmVarsla = new frmVörslustofnun(vörslustofnun, virkurnotandi);
                    frmVarsla.ShowDialog();
                    vörslustofnun.getVörslustofnun(vörslustofnun.auðkenni_5_1_1);
                    m_tboISDIAH_obinbert_heiti.Text = vörslustofnun.opinbert_heiti_5_1_2;
                    break;
            }
        }

        private void m_tboISDIAH_obinbert_heiti_TextChanged(object sender, EventArgs e)
        {
            vörslustofnun.opinbert_heiti_5_1_2 = m_tboISDIAH_obinbert_heiti.Text;
            m_lblHeitVarslaVantar.Visible = false;
        }
    }
}
