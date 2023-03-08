using cClassOAIS;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Crypto;
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



            foreach(DataRow r in ds.Tables[0].Rows) 
            {
                string strSlod = strRoot + r["foN"] +"\\"+ r["fiN"];
                string strMD5 = r["MD5"].ToString();
                if(md5(strSlod) == strMD5)
                {
                    //skrá?
                    m_pgbTekksuma.PerformStep();
                    m_lblTekkSuma.Text = string.Format("{0}/{1}",m_pgbTekksuma.Value,m_pgbTekksuma.Maximum);
                    Application.DoEvents();
                }
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
            DataSet ds = new DataSet();
            ds.ReadXml(strArchiveIndex);
            m_tboISADG_auðkenni.Text = strVarsla;
            m_tboISADG_titill.Text = ds.Tables["archiveCreatorList"].Rows[0]["creatorName"].ToString() + " - " + ds.Tables["archiveIndex"].Rows[0]["systemName"].ToString();
            m_tboISADG_innihald.Text = ds.Tables["archiveIndex"].Rows[0]["systemContent"].ToString();

        }
        private void fyllaVörslustofnn(string strVarsla)
        {
            string[] strSplit = strVarsla.Split('.');
            string strVasrlaAuðkenni = strSplit[1];
            vörslustofnun.getVörslustofnun(strVasrlaAuðkenni);
            m_tboISDIAH_auðkenni.Text = vörslustofnun.auðkenni_5_1_1;
            m_tboISDIAH_obinbert_heiti.Text = vörslustofnun.opinbert_heiti_5_1_2;
        }
        private void fyllaSkjalamyndara(string strArchiveIndex, string strVarsla)
        {
            //ÞARF AÐ BREYTA SÍÐAR - EF FLEIRI ENN EINN SKJALAMYNDARI
           
            DataTable dt = skjalamyndari.getENUM();
            DataRow r = dt.NewRow();
            r["gerd"] = "Veldu gerð";
            dt.Rows.InsertAt(r, 0);

            m_comISAAR_gerð.ValueMember = "gerd";
            m_comISAAR_gerð.DisplayMember = "gerd";
            m_comISAAR_gerð.DataSource = dt;

            DataSet ds = new DataSet();
            ds.ReadXml(strArchiveIndex);
            string strNafn = ds.Tables["archiveCreatorList"].Rows[0]["creatorName"].ToString();
            m_comISAAR_nafn.Text = strNafn;
            skjalamyndari.opinbert_heiti_5_1_2 = strNafn;
            skjalamyndari.auðkenni_5_1_6 = "00001";
            skjalamyndari.hver_skráði = virkurnotandi.nafn;
        }

        private void m_btnStadfesta_Click(object sender, EventArgs e)
        {
            skjalamyndari.vista();
        }

        private void m_comISAAR_gerð_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(m_comISAAR_gerð.SelectedIndex != 0 )
            {
                skjalamyndari.gerð_5_1_1 = m_comISAAR_gerð.SelectedValue.ToString();
            }
        }
    }
}
