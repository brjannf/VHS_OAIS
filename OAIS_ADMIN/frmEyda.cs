using cClassOAIS;
using cClassVHS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIS_ADMIN
{
    public partial class frmEyda : Form
    {
        cVorslustofnun vörslustofnun = new cVorslustofnun();
        cSkjalamyndari skjalamyndari = new cSkjalamyndari();
        cSkjalaskra útgáfa = new cSkjalaskra();
        string m_strSlod = string.Empty;
        string m_strAuðkenni = string.Empty;    

        public frmEyda()
        {
            InitializeComponent();
        }
        public frmEyda(string strUtgafa, string strSkjalmyndari, string strVarsla, string strSlod)
        {
            InitializeComponent();

            útgáfa.getSkraning(strUtgafa);
            skjalamyndari.getSkjalamyndara(strSkjalmyndari);
            vörslustofnun.getVörslustofnun(strVarsla);
            m_strSlod+= strSlod;
            m_strAuðkenni = strUtgafa;

            m_lblEyða.Text = "Viltu eyða eftirfarandi vörsluútgáfu" + Environment.NewLine;
            m_lblEyða.Text += "Titill: " + útgáfa.titill_3_1_2 + Environment.NewLine;
            m_lblEyða.Text += "Auðkenni: " + útgáfa.auðkenni_3_1_1 + Environment.NewLine;
            m_lblEyða.Text += "Skjalamynari: " + skjalamyndari.opinbert_heiti_5_1_2 + Environment.NewLine;
            m_lblEyða.Text += "Vörslustofnun: " + vörslustofnun.opinbert_heiti_5_1_2 + Environment.NewLine;



        }

        private void eyða()
        {
            DirectoryInfo dir = new DirectoryInfo(m_strSlod);
            //1. eyða skrám filesystem
            m_lblEyða.Text = "Eyði skrám";
            progressBar1.PerformStep();
            Application.DoEvents();
            if (Directory.Exists(m_strSlod))
            {
                Directory.Delete(m_strSlod, true);
            }
            cMD5 md5 = new cMD5();
            md5.eyda(útgáfa.auðkenni_3_1_1);
           
            Application.DoEvents();
            //2.eyða ISADG færslu
            m_lblEyða.Text = "Eyði ISAD(G) færslu";
            progressBar1.PerformStep();
            Application.DoEvents();
            útgáfa.eyða(útgáfa.auðkenni_3_1_1);

            //3. merkja eytt í vörslútgáfulista
            m_lblEyða.Text = "Merki vörslútgáfu eydda";
            progressBar1.PerformStep();
            Application.DoEvents();

            cVorsluutgafur utgaf = new cVorsluutgafur();
            utgaf.merkjaEYtt(m_strAuðkenni, 1);
            //4. tékka hvort fleiri nota skjalamynadra

            m_lblEyða.Text = "Skoða ISSAR";
            progressBar1.PerformStep();
            Application.DoEvents();
             //5 ef ekki eyða skjalamyndara
            if(skjalamyndari.fjoldiVirkarUtgafna(skjalamyndari.auðkenni_5_1_6) == 0 ) 
            {
                if(Directory.GetDirectories(dir.Parent.FullName).Length == 0 ) 
                {
                    Directory.Delete(dir.Parent.FullName);
                }
               
                skjalamyndari.eyða(skjalamyndari.auðkenni_5_1_6);
            }
            //6 tékka hvort vörslustofnun hafi fleiri skjalamyndara
            m_lblEyða.Text = "Skoða ISDIAH";
            progressBar1.PerformStep();
            Application.DoEvents();
          
            if(vörslustofnun.fjoldiVirkarUtgafna(vörslustofnun.auðkenni_5_1_1) == 0) 
            {
                if (Directory.GetDirectories(dir.Parent.Parent.FullName).Length == 0)
                {
                    Directory.Delete(dir.Parent.Parent.FullName);
                }

                vörslustofnun.eyða(vörslustofnun.auðkenni_5_1_1);
            }
            //7 eyða miðlun

            utgaf.midlunEyda(m_strAuðkenni);
            utgaf.midlun = "0";
            utgaf.vorsluutgafa = m_strAuðkenni;
            utgaf.uppFaeraVegnaMidlun();
            cMIdlun midlun = new cMIdlun();
            midlun.eydaFyrirspurnum(m_strAuðkenni.Replace(".", "_"));
            midlun.dropDatabase(m_strAuðkenni.Replace(".", "_"));
          


            this.Close();
            //7 ef ekki eyða vörslustofnun.


        }

        private void m_btnStaðfesta_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ertu allveg viss að þú viljir eyða vörslútgáfu", "Eyða", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes) 
            {
                m_lblEyða.Text = "Okíley";
                eyða();
            }

        }
    }
}
