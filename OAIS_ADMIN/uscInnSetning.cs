using cClassOAIS;
using cClassVHS;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Math.EC.Multiplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace OAIS_ADMIN
{
    public partial class uscInnSetning : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        public cVorslustofnun vörslustofnun = new cVorslustofnun();
        public cSkjalamyndari skjalamyndari = new cSkjalamyndari();
        public cSkjalaskra skrá = new cSkjalaskra();
        string m_strDrif = string.Empty;
        public cMD5 m_MD5 = new cMD5();
        bool m_bISDIAH = false;
        bool m_bISAAR = false;
        bool m_bISADG = false;
        bool m_bMD5 = false; 
        string m_strSlodVarsla = string.Empty;
        string m_strRotVarsla =string.Empty;
        private string strDrive = string.Empty;
        long m_lStaerd = 0;
        long m_lStaerdFrum = 0;
        public uscInnSetning()
        {
            InitializeComponent();
            fyllaSkjalamyndaraLista();
            cVHS_drives drives = new cVHS_drives();
            m_strDrif = drives.driveVirkkComputers();
        }

        private void fyllaSkjalamyndaraLista()
        {
            DataTable dt = skjalamyndari.getSkjalamyndaralista();
            m_comISAAR_nafn.DataSource = dt;
            m_comISAAR_nafn.DisplayMember = "5_1_2_opinbert_heiti";
            m_comISAAR_nafn.ValueMember = "id";
        }
        private void m_lblDragDrop_Click(object sender, EventArgs e)
        {
          
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                string strFileIndex = folderBrowserDialog1.SelectedPath + "\\Indices\\fileIndex.xml";
                string strArchiveIndex = folderBrowserDialog1.SelectedPath + "\\Indices\\archiveIndex.xml";
                m_strSlodVarsla = folderBrowserDialog1.SelectedPath;
                if (File.Exists(strFileIndex))
                {
                    string[] strSplit = folderBrowserDialog1.SelectedPath.Split('\\');
                    string strVarsla = strSplit[strSplit.Length - 1];
                    m_strRotVarsla = strVarsla;
                    m_grbAvid.Text = strVarsla;
                    //tékka hvort afhendinginn hefur verið skráð inn áður
                    DataTable dtTil = skrá.getKvittun(strVarsla);
                   if ( dtTil.Rows.Count != 0 && dtTil.Rows[0]["eytt"].ToString() == "0")
                    {
                        MessageBox.Show("Þessi vörsluútgáfa er þegar kominn inn í kerfið, hvað gerir maður þá?");
                        m_btnKvittun.Enabled = true;
                        m_grbSkyrsla.BackColor = Color.LightYellow;
                        m_grbFlytjaSIP.BackColor = Color.LightGreen;
                        m_grbTekksuma.BackColor = Color.LightGreen;
                      //  m_grbISAAR.BackColor = Color.LightGreen;
                       // m_btnSkjalamyndariStadfesta.Text = "Fullskrá";
                        fyllaSkjalamyndara(strArchiveIndex, strVarsla);
                        if(skjalamyndari.ID != 0)
                        {
                            m_grbISAAR.BackColor = Color.LightGreen;
                            m_btnSkjalamyndariStadfesta.Text = "Fullskrá";
                        }
                        m_btnSkjalamyndariStadfesta.Enabled = true;
                        m_grbISAAR.Enabled = true;
                      
                        fyllaSkjalaSkra(strArchiveIndex, strVarsla);
                        m_grbISASG.Enabled = true;
                        m_grbISASG.BackColor = Color.LightGreen;
                        m_btnSkraningStaðfesta.Enabled = true;
                        m_btnSkraningStaðfesta.Text = "Fullskrá";
                        fyllaVörslustofnn(strVarsla);
                        m_grbISDIAH.Enabled = true;
                        m_grbISDIAH.BackColor = Color.LightGreen;
                        m_btnVörslustofnunStaðfesta.Enabled =true;
                        m_btnVörslustofnunStaðfesta.Text = "Fullskrá";


                        return;
                    }

                    fyllaSkjalamyndara(strArchiveIndex, strVarsla);
                    m_grbISDIAH.Enabled = true;
                    fyllaSkjalaSkra(strArchiveIndex, strVarsla);
                    m_grbISASG.Enabled = true;
                    fyllaVörslustofnn(strVarsla);
                    m_grbISAAR.Enabled = true;
                    m_bMD5 = bMD5Test(strFileIndex, strVarsla);
                   // m_btnFlytjaSIP.Enabled = true; //kommenta út svo


                    if (m_bMD5)
                    {
                        m_grbTekksuma.BackColor = Color.LightGreen;
                        if (m_bISDIAH && m_bISAAR && m_bISADG && m_bMD5)
                        {
                            m_btnFlytjaSIP.Enabled = true;
                            m_grbFlytjaSIP.BackColor = Color.LightYellow;
                        }

                    }
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
            m_strSlodVarsla = dropped[0].ToString();

            if (File.Exists(strFileIndex)) 
            {
                string[] strSplit = dropped[0].ToString().Split('\\');
                string strVarsla = strSplit[strSplit.Length-1];
                m_strRotVarsla = strVarsla;
                m_grbAvid.Text = strVarsla;
                //tékka hvort afhendinginn hefur verið skráð inn áður

                if (skrá.getKvittun(strVarsla).Rows.Count != 0)
                {
                    MessageBox.Show("Þessi vörsluútgáfa er þegar kominn inn í kerfið, hvað gerir maður þá?");
                    m_btnKvittun.Enabled = true;
                    m_grbSkyrsla.BackColor = Color.LightYellow;
                    m_grbFlytjaSIP.BackColor = Color.LightGreen;
                    m_grbTekksuma.BackColor = Color.LightGreen;
                    fyllaSkjalamyndara(strArchiveIndex, strVarsla);
                    m_grbISAAR.BackColor = Color.LightGreen;
                    m_btnSkjalamyndariStadfesta.Text = "Fullskrá";
                    m_btnSkjalamyndariStadfesta.Enabled = true;
                    m_grbISAAR.Enabled = true;

                    fyllaSkjalaSkra(strArchiveIndex, strVarsla);
                    m_grbISASG.Enabled = true;
                    m_grbISASG.BackColor = Color.LightGreen;
                    m_btnSkraningStaðfesta.Enabled = true;
                    m_btnSkraningStaðfesta.Text = "Fullskrá";
                    fyllaVörslustofnn(strVarsla);
                    m_grbISDIAH.Enabled = true;
                    m_grbISDIAH.BackColor = Color.LightGreen;
                    m_btnVörslustofnunStaðfesta.Enabled = true;
                    m_btnVörslustofnunStaðfesta.Text = "Fullskrá";


                    return;
                }


                m_strRotVarsla = strVarsla;
                fyllaSkjalamyndara(strArchiveIndex, strVarsla);
                m_grbISDIAH.Enabled = true;
                fyllaSkjalaSkra(strArchiveIndex, strVarsla);
                m_grbISASG.Enabled = true;
                fyllaVörslustofnn(strVarsla);
                m_grbISAAR.Enabled = true;

                m_bMD5 = bMD5Test(strFileIndex, strVarsla);
                if (m_bMD5)
                {
                    m_grbTekksuma.BackColor = Color.LightGreen;
                    if (m_bISDIAH && m_bISAAR && m_bISADG && m_bMD5)
                    {
                        m_btnFlytjaSIP.Enabled = true;
                        m_grbFlytjaSIP.BackColor = Color.LightYellow;
                    }

                }
            }
            else
            {
                MessageBox.Show("Vantar fileIndex.xml");
               
            }
        }

        private bool bMD5Test(string strFileName, string strVarsla)
        {
            bool bRet = true;
            m_dgvMD5Villur.Visible = false;
            m_grbTekksuma.BackColor = Color.LightYellow;
            m_dgvMD5Villur.DataSource = null; //þyrfti að taka rowið út ekki nulla út sourcinu
          //  m_grbTekksuma.BackColor = SystemColors.Control;
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
                    bRet = false;
                    m_grbTekksuma.BackColor = Color.LightPink;

                }

                m_pgbTekksuma.PerformStep();
                m_lblTekkSuma.Text = string.Format("{0}/{1}", m_pgbTekksuma.Value, m_pgbTekksuma.Maximum);
                m_pgbTekksuma.Visible = true;
                m_lblTekkSuma.Visible = true;
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
            skrá.hreinsaHlut();
            m_comISADG_aðgengi.Text = "Veldu aðgengi";
            DataSet ds = new DataSet();
            ds.ReadXml(strArchiveIndex);
            skrá.auðkenni_3_1_1 = strVarsla;
            skrá.getSkraning(skrá.auðkenni_3_1_1);
            if (skrá.ID != 0)
            {
                m_tboISADG_timabil.Text = skrá.tímabil_3_1_3;
                m_tboISADG_auðkenni.Text = skrá.auðkenni_3_1_1;
                m_tboISADG_titill.Text = skrá.titill_3_1_2;
                m_tboISADG_innihald.Text = skrá.yfirlit_innihald_3_3_1;
                m_comISADG_aðgengi.SelectedItem = skrá.skilyrði_aðgengi_3_4_1;
                m_tboISADG_AFHNR.Text = skrá.afhendingar_tilfærslur_3_2_4;

                m_grbISASG.BackColor = Color.LightYellow;
                m_btnSkraningStaðfesta.Text = "Staðfesta";
            }
            else
            {
                
                string[] strSplit = strVarsla.Split(".");
                //bæta við lengt stakks 2 == 7
                string strAFhAR = strSplit[strSplit.Length-2].Substring(0, 4);
                string strAFHNR = strSplit[strSplit.Length - 2].Substring(4, 3);
                skrá.afhendingar_tilfærslur_3_2_4  = strAFhAR + " / " + strAFHNR;
                m_tboISADG_AFHNR.Text = skrá.afhendingar_tilfærslur_3_2_4;
                skrá.vörslustofnun = vörslustofnun.auðkenni_5_1_1;
                m_tboISADG_auðkenni.Text = skrá.auðkenni_3_1_1;
                DateTime dStart = Convert.ToDateTime(ds.Tables["archiveIndex"].Rows[0]["archiveperiodstart"].ToString());
                DateTime dEnd = Convert.ToDateTime(ds.Tables["archiveIndex"].Rows[0]["archiveperiodEnd"].ToString());
                string strTímabil = dStart.ToString("dd.MM.yyyy") + "-" + dEnd.ToString("dd.MM.yyyy");
                m_tboISADG_timabil.Text = strTímabil;
                skrá.tímabil_3_1_3 = strTímabil;
                skrá.titill_3_1_2 = ds.Tables["archiveCreatorList"].Rows[0]["creatorName"].ToString() + " - " + ds.Tables["archiveIndex"].Rows[0]["systemName"].ToString();
                m_tboISADG_titill.Text = skrá.titill_3_1_2;
                skrá.yfirlit_innihald_3_3_1 = ds.Tables["archiveIndex"].Rows[0]["systemContent"].ToString();
                m_tboISADG_innihald.Text = skrá.yfirlit_innihald_3_3_1;
                if (m_comISADG_aðgengi.SelectedItem.ToString() != "Veldu aðgengi")
                {
                    skrá.skilyrði_aðgengi_3_4_1 = m_comISADG_aðgengi.SelectedItem.ToString();
                }
                skrá.skjalamyndari = skjalamyndari.ID;
                skrá.heiti_skjalamyndara_3_2_1 = skjalamyndari.opinbert_heiti_5_1_2;
                skrá.upplýsingastig_3_1_4 = "Skjalasafn";
                skrá.hver_skráði = virkurnotandi.nafn;
                m_btnSkraningStaðfesta.Text = "Vista";
            }

        }
        private void fyllaVörslustofnn(string strVarsla)
        {
            vörslustofnun.hreinsaHlut();
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
                m_grbISDIAH.BackColor = Color.LightYellow;
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
                m_tboISDIAH_obinbert_heiti.Text = vörslustofnun.opinbert_heiti_5_1_2;
                m_btnVörslustofnunStaðfesta.Text = "Vista";
            }
         
        }
        private void fyllaSkjalamyndara(string strArchiveIndex, string strVarsla)
        {
            //ÞARF AÐ BREYTA SÍÐAR - EF FLEIRI ENN EINN SKJALAMYNDARI
            //1. sækja skjalamyndara út frá nafni
            skjalamyndari.hreinsaHlut();
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

            if(skjalamyndari.gerð_5_1_1 != string.Empty)
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
            if(skjalamyndari.ID != 0)
            {
                m_btnSkjalamyndariStadfesta.Text = "Staðfesta";
                m_grbISAAR.BackColor = Color.LightYellow;
            }
            else
            {
                m_btnSkjalamyndariStadfesta.Text = "Vista";
                //m_grbISAAR.BackColor = Color.LightYellow;
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
                    skjalamyndari.getSkjalamyndara(skjalamyndari.opinbert_heiti_5_1_2);
                    m_btnSkjalamyndariStadfesta.Text = "Fullskrá";
                    m_grbISAAR.BackColor = Color.LightGreen;
                    fyllaSkjalamyndaraLista();
                    m_comISAAR_nafn.SelectedValue = skjalamyndari.auðkenni_5_1_6;
                    m_btnSkraningStaðfesta.Enabled = true;
                    m_bISAAR = true;
                    break;
                case "Staðfesta":
                    if(skjalamyndari.ID != 0)
                    {
                        m_grbISAAR.BackColor = Color.LightGreen;
                        m_btnSkjalamyndariStadfesta.Text = "Fullskrá";
                        m_btnSkraningStaðfesta.Enabled = true;
                        m_bISAAR = true;
                    }
                   
                    break;

                case "Fullskrá":
                    frmSkjalamyndariSkra frmSkjal = new frmSkjalamyndariSkra(skjalamyndari, virkurnotandi);
                    frmSkjal.ShowDialog();
                    skjalamyndari.getSkjalamyndara(skjalamyndari.ID);
                    m_comISAAR_gerð.SelectedValue = skjalamyndari.gerð_5_1_1;
                    m_comISAAR_nafn.Text = skjalamyndari.opinbert_heiti_5_1_2;
                    m_bISAAR = true;
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
                    skrá.skjalamyndari = skjalamyndari.ID;
                    skrá.vörslustofnun = vörslustofnun.auðkenni_5_1_1;
                    skrá.vista();
                    skrá.getSkraning(skrá.auðkenni_3_1_1);
                    m_btnSkraningStaðfesta.Text = "Fullskrá";
                    m_grbISASG.BackColor = Color.LightGreen;
                    m_bISADG = true;
                    break;
                case "Staðfesta":
                    m_grbISASG.BackColor = Color.LightGreen;
                    m_btnSkraningStaðfesta.Text = "Fullskrá";
                    m_bISADG = true;
                    break;

                case "Fullskrá":
                    frmSkráning frmSkjal = new frmSkráning(skrá, virkurnotandi);
                    frmSkjal.ShowDialog();
                    skrá.getSkraning(skrá.auðkenni_3_1_1);
                    m_comISADG_aðgengi.SelectedItem = skrá.skilyrði_aðgengi_3_4_1;
                    m_tboISADG_titill.Text = skrá.titill_3_1_2;
                    m_tboISADG_innihald.Text = skrá.yfirlit_innihald_3_3_1;
                    m_bISADG = true;
                    break;
            }

            if (m_bISDIAH && m_bISAAR && m_bISADG && m_bMD5)
            {
                m_btnFlytjaSIP.Enabled = true;
                m_grbFlytjaSIP.BackColor = Color.LightYellow;
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
                    m_btnSkjalamyndariStadfesta.Enabled = true;
                    m_bISDIAH = true;
                    break;
                case "Staðfesta":
                    if(vörslustofnun.ID != 0)
                    {
                        m_grbISDIAH.BackColor = Color.LightGreen;
                        m_btnVörslustofnunStaðfesta.Text = "Fullskrá";
                        m_btnSkjalamyndariStadfesta.Enabled = true;
                        m_bISDIAH = true;
                    }
                 
                    break;

                case "Fullskrá":
                    frmVörslustofnun frmVarsla = new frmVörslustofnun(vörslustofnun, virkurnotandi);
                    frmVarsla.ShowDialog();
                    vörslustofnun.getVörslustofnun(vörslustofnun.auðkenni_5_1_1);
                    m_tboISDIAH_obinbert_heiti.Text = vörslustofnun.opinbert_heiti_5_1_2;
                    m_bISADG = true;
                    break;
            }
        }

        private void m_tboISDIAH_obinbert_heiti_TextChanged(object sender, EventArgs e)
        {
            vörslustofnun.opinbert_heiti_5_1_2 = m_tboISDIAH_obinbert_heiti.Text;
            m_lblHeitVarslaVantar.Visible = false;
        }

        private void m_comISADG_aðgengi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_comISADG_aðgengi.SelectedIndex != 0)
            {
                skrá.skilyrði_aðgengi_3_4_1 = m_comISADG_aðgengi.SelectedItem.ToString();
            }
        }

        private void m_btnFlytjaSIP_Click(object sender, EventArgs e)
        {
            //1. flytja gögn yfir á geymslusvæði (harðkóðða til að byrja með rótarmöppu vantar umsjón fyrir miðla)
            m_grbAvid.Visible = true;
            string strRot = m_strDrif + "\\";
            string strRotVarsla = strRot + vörslustofnun.auðkenni_5_1_1;
            if (!Directory.Exists(strRotVarsla))
            {
                Directory.CreateDirectory(strRotVarsla);
            }
            string strRotSkjalamyndari = strRotVarsla + "\\" + skjalamyndari.auðkenni_5_1_6;
            if(!Directory.Exists(strRotSkjalamyndari))
            {
                Directory.CreateDirectory(strRotSkjalamyndari);
            }
            string strRotAIP = strRotSkjalamyndari + "\\" + m_strRotVarsla;


            m_prbAVID.Maximum = Directory.GetDirectories(m_strSlodVarsla).Length;
            m_prbAVID.Step = 1;
            m_prbAVID.Value = 0;
            DirectoryInfo difo = new DirectoryInfo(m_strSlodVarsla);
            string strSlodFRUM = string.Empty;
            foreach (var dir in difo.Parent.GetDirectories())
            {
                DirectoryInfo dido = new DirectoryInfo(dir.FullName);
                string strHeitiVarsla = m_strRotVarsla.Replace("AVID", "FRUM");

                
                if(dido.Name.StartsWith(strHeitiVarsla))
                {
                    //til frumeintak - þarf að flytja það líka. 
                    strSlodFRUM = dido.FullName;
                    m_grbFRUM.Visible= true;
                    m_grbFRUM.Text = skrá.auðkenni_3_1_1.Replace("AVID", "FRUM");
                }

            }

            m_prbFRUM.Maximum = 2;
            m_prbFRUM.Step = 1;
            m_prbFRUM.Value = 0;
            flytjaVorslutgafu(m_strSlodVarsla, strRotAIP);

            if (strSlodFRUM != string.Empty)
            {
                strRotAIP = strRotSkjalamyndari + "\\" + m_strRotVarsla.Replace("AVID", "FRUM");
                flytjaVorslutgafu(strSlodFRUM, strRotAIP);
            }
           
            cVorsluutgafur varsla = new cVorsluutgafur();
            varsla.getVörsluútgáfu(skrá.auðkenni_3_1_1);
            varsla.vorsluutgafa = skrá.auðkenni_3_1_1;
            varsla.utgafa_titill = skrá.titill_3_1_2;
            varsla.vorslustofnun = vörslustofnun.auðkenni_5_1_1;
            varsla.varsla_heiti = vörslustofnun.opinbert_heiti_5_1_2;
            varsla.skjalamyndari = skjalamyndari.auðkenni_5_1_6;
            varsla.skjalm_heiti = skjalamyndari.opinbert_heiti_5_1_2;
            varsla.staerd = m_lStaerd;
            varsla.slod = "D:\\AIP\\" + vörslustofnun.auðkenni_5_1_1 + "\\" + skjalamyndari.auðkenni_5_1_6 +"\\" + skrá.auðkenni_3_1_1;
            varsla.innihald = skrá.yfirlit_innihald_3_3_1;
            varsla.timabil = skrá.tímabil_3_1_3;
            varsla.afharnr = skrá.afhendingar_tilfærslur_3_2_4;
            varsla.MD5 = CreateMd5ForFolder(varsla.slod).ToUpper();
            varsla.hver_skradi = virkurnotandi.nafn;
            varsla.adgangstakmarkanir = skrá.skilyrði_aðgengi_3_4_1;
            DataTable dtTil = skrá.getKvittun(skrá.auðkenni_3_1_1);
            bool bErEytt  = false;
            if (dtTil.Rows.Count != 0 && dtTil.Rows[0]["eytt"].ToString() == "1")
            {
                varsla.vista();
                varsla.merkjaEYtt(varsla.vorsluutgafa, 0);
                bErEytt|= true;
            }
            else
            {
                
                varsla.vista();

            }
               
            if(strSlodFRUM != string.Empty)
            {
                varsla.getVörsluútgáfu(skrá.auðkenni_3_1_1.Replace("AVID", "FRUM"));
                varsla.vorsluutgafa = skrá.auðkenni_3_1_1.Replace("AVID", "FRUM");
                varsla.utgafa_titill = skrá.titill_3_1_2;
                varsla.vorslustofnun = vörslustofnun.auðkenni_5_1_1;
                varsla.varsla_heiti = vörslustofnun.opinbert_heiti_5_1_2;
                varsla.skjalamyndari = skjalamyndari.auðkenni_5_1_6;
                varsla.skjalm_heiti = skjalamyndari.opinbert_heiti_5_1_2;
                varsla.staerd = m_lStaerdFrum;
                varsla.slod = "D:\\AIP\\" + vörslustofnun.auðkenni_5_1_1 + "\\" + skjalamyndari.auðkenni_5_1_6 + "\\" + varsla.vorsluutgafa;
                varsla.innihald = skrá.yfirlit_innihald_3_3_1;
                varsla.timabil = skrá.tímabil_3_1_3;
                varsla.afharnr = skrá.afhendingar_tilfærslur_3_2_4;
                varsla.MD5 = CreateMd5ForFolder(varsla.slod).ToUpper();
                varsla.hver_skradi = virkurnotandi.nafn;
                varsla.adgangstakmarkanir = skrá.skilyrði_aðgengi_3_4_1;
                if(bErEytt)
                {
                    varsla.merkjaEYtt(varsla.vorsluutgafa, 0);
                }
                else
                {
                    varsla.vista();
                }
           
            }
            m_grbFlytjaSIP.BackColor = Color.LightGreen;
            m_grbSkyrsla.BackColor = Color.LightYellow;
            m_btnFlytjaSIP.Enabled = false;
            m_btnKvittun.Enabled = true; 
            MessageBox.Show("Búið");

            
        }
        public static string CreateMd5ForFolder(string path)
        {
            // assuming you want to include nested folders
            var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                                 .OrderBy(p => p).ToList();

            MD5 md5 = MD5.Create();

            for (int i = 0; i < files.Count; i++)
            {
                string file = files[i];

                // hash path
                string relativePath = file.Substring(path.Length + 1);
                byte[] pathBytes = Encoding.UTF8.GetBytes(relativePath.ToLower());
                md5.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);

                // hash contents
                byte[] contentBytes = File.ReadAllBytes(file);
                if (i == files.Count - 1)
                    md5.TransformFinalBlock(contentBytes, 0, contentBytes.Length);
                else
                    md5.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
            }

            return BitConverter.ToString(md5.Hash).Replace("-", "").ToLower();
        }
        private void flytjaVorslutgafu(string strOrg, string strDest)
        {
         
            foreach (var directory in Directory.GetDirectories(strOrg))
            {
                DirectoryInfo difo = new DirectoryInfo(directory);
                if (difo.FullName.Contains("AVID"))
                {
                    m_lblFilesAPI.Text = directory.ToString();
                }
                if (difo.FullName.Contains("FRUM"))
                {
                    m_lblFileFRUM.Text = directory.ToString();
                }

                Application.DoEvents();
               
                if (difo.Parent.FullName == m_strSlodVarsla && difo.Parent.Name.StartsWith("AVID"))
                {
                    m_prbAVID.PerformStep();
                    m_lblStatusAPI.Text = string.Format("{0} {1}/{2}",difo.Name, m_prbAVID.Value,m_prbAVID.Maximum);
                    Application.DoEvents();
                }
                if (difo.Parent.FullName == m_strSlodVarsla.Replace("AVID", "FRUM") && difo.Parent.Name.StartsWith("FRUM"))
                {
                    if(difo.FullName.Contains("Documents") || difo.FullName.Contains("VINNUSKJÖL"))
                    {
                        m_prbFRUM.PerformStep();
                        m_lblStatusFRUM.Text = string.Format("{0} {1}/{2}", difo.Name, m_prbFRUM.Value, m_prbFRUM.Maximum);
                        Application.DoEvents();

                    }
                   
                }

                //Get the path of the new directory
                var newDirectory = Path.Combine(strDest, Path.GetFileName(directory));
                //Create the directory if it doesn't already exist
                if (difo.FullName.Contains("AVID")) //þarf að finna út hvurning ég sleppi að búa til m0ppur sem eru ekki notaðar
                {
                    Directory.CreateDirectory(newDirectory);
                }
                if (difo.FullName.Contains("FRUM"))
                {
                    if (newDirectory.Contains("Documents") || newDirectory.Contains("VINNUSKJÖL"))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }
                    
                }
                    //if (difo.FullName.Contains("FRUM"))
                    //{
                    //    if (newDirectory.EndsWith("VINNUSKJÖL") || newDirectory.EndsWith("Documents"))
                    //    {
                    //        Directory.CreateDirectory(newDirectory);
                    //    }
                    //}

                    //Recursively clone the directory
                    flytjaVorslutgafu(directory, newDirectory);
            }
            FileInfo fifo = new FileInfo(strOrg);
            if (fifo.FullName.Contains("AVID"))
            {
                foreach (var file in Directory.GetFiles(strOrg))
                {

                    File.Copy(file, Path.Combine(strDest, Path.GetFileName(file)), true);
                    FileInfo folo = new FileInfo(file);
                    m_lStaerd += folo.Length; 
                    m_MD5.AIP = m_strRotVarsla;
                    m_MD5.slod = strDest;
                    m_MD5.file = Path.GetFileName(file);
                    m_MD5.MD5 = md5(Path.Combine(strDest, Path.GetFileName(file)));
                    m_MD5.vista();

                }
            }
            if (fifo.FullName.Contains("FRUM"))
            {
                //færi bara möppuna DOCUMENT og VINNUSKJÖL
                foreach (var file in Directory.GetFiles(strOrg))
                {
                    if (fifo.FullName.Contains("VINNUSKJÖL") || fifo.FullName.Contains("Documents"))
                    {
                        File.Copy(file, Path.Combine(strDest, Path.GetFileName(file)), true);

                        m_MD5.AIP = m_strRotVarsla;
                        m_MD5.slod = strDest;
                        m_MD5.file = Path.GetFileName(file); //þyrfti að ná orginal nafninu TODO gera leit í xml fyrri þetta.
                                                             //DataSet ds = new DataSet();
                                                             //ds.ReadXml(m_strSlodVarsla+ "\\Tables\\table1\\table1.xml");
                        FileInfo folo = new FileInfo(file);
                        m_lStaerdFrum   += folo.Length;
                        m_MD5.MD5 = md5(Path.Combine(strDest, Path.GetFileName(file)));
                        m_MD5.vista();
                    }
                }
                //if()
            }

        }

        private void m_btnKvittun_Click(object sender, EventArgs e)
        {
            frmKvittun frmkvitt = new frmKvittun(m_strRotVarsla);
            frmkvitt.ShowDialog();
            m_grbSkyrsla.BackColor = Color.LightGreen;
        }

        private void m_btnFjarlaegja_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eftir að útfæra");
        }

        private void m_comISAAR_nafn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_comISAAR_nafn.Focused)
            {
                int ID = Convert.ToInt32(m_comISAAR_nafn.SelectedValue);
                skjalamyndari.hreinsaHlut();
                skjalamyndari.getSkjalamyndara(ID);

                m_tboISAAR_auðkenni.Text = skjalamyndari.auðkenni_5_1_6;
                m_comISAAR_gerð.SelectedValue = skjalamyndari.gerð_5_1_1;
                m_grbISAAR.BackColor = Color.LightYellow;
                m_btnSkjalamyndariStadfesta.Text = "Staðfesta";
                
                
            }
        }
    }
}
