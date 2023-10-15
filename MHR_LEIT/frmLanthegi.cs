using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cClassOAIS;

namespace MHR_LEIT
{
    public partial class frmLanthegi : Form
    {
        cNotandi virkurnotandi = new cNotandi(); 
        cLanthegar lanthegi= new cLanthegar();
        public frmLanthegi(cNotandi not)
        {
            InitializeComponent();
            virkurnotandi = not;
        }
        public frmLanthegi(cNotandi not, string strID)
        {
            InitializeComponent();
            virkurnotandi = not;
            lanthegi.m_bAfrit = virkurnotandi.m_bAfrit;
            lanthegi.getaLanthega(strID);
            fyllaLanthega();
        }
        private void m_btnVista_Click(object sender, EventArgs e)
        {
            lanthegi.m_bAfrit = virkurnotandi.m_bAfrit;
           cLanthegar testLan = new cLanthegar(); 
            errorProvider1.Clear();

            if (m_tboNafn.Text.Length == 0)
            {
                errorProvider1.SetError(m_tboNafn, "Vantar nafn");

            }
                      
            if (m_tboKennitala.Text.Replace("-", "").Length != 10)
            {
                errorProvider1.SetError(m_tboKennitala, "Vantar kennitölu");
            }
            testLan.getaLanthegaKennitala(m_tboKennitala.Text.Replace("-", ""));
            if(testLan.kennitala != null)
            {
                if(testLan.kennitala != lanthegi.kennitala)
                {
                    errorProvider1.SetError(m_tboKennitala, string.Format("{0} er með þessa kennitölu", testLan.nafn));
                }
    
            }
            if(m_tboHeit_fyrirtaekis.Text != string.Empty && m_tboKennitalFyrirtaekis.Text.Replace("-","").Trim() == string.Empty)
            {
                errorProvider1.SetError(m_tboKennitalFyrirtaekis, "Vantar kennitölu stofnunar");
            }
            if (m_tboHeit_fyrirtaekis.Text == string.Empty && m_tboKennitalFyrirtaekis.Text.Replace("-", "").Trim() != string.Empty)
            {
                errorProvider1.SetError(m_tboHeit_fyrirtaekis, "Vantar heiti stofnunar");
            }
            if(m_tboSimi.Text == string.Empty && m_tboNetfang.Text == string.Empty)
            {
                errorProvider1.SetError(m_tboSimi, "Vantar símabúmer eða netfang");
                errorProvider1.SetError(m_tboNetfang, "Vantar símabúmer eða netfang");
            }

            if (errorProvider1.HasErrors)
            {
                return;
            }
            lanthegi.nafn = m_tboNafn.Text;
            lanthegi.kennitala = m_tboKennitala.Text.Replace("-", "");
            lanthegi.nafn_fyrirtaekis = m_tboHeit_fyrirtaekis.Text; ; 
            lanthegi.kennitala_fyrirtaekis = m_tboKennitalFyrirtaekis.Text.Replace("-", "");
            lanthegi.netfang = m_tboNetfang.Text;
            lanthegi.simi= m_tboSimi.Text;
            lanthegi.skrad_af = virkurnotandi.nafn;

            lanthegi.vista();
            DialogResult result= MessageBox.Show("Lánþegi skráður, loka glugga?", "Lánþegi skráður",MessageBoxButtons.YesNo);
            if(DialogResult.Yes == result) 
            {
                this.Close();
            }
        }

        private void fyllaLanthega()
        {
            m_tboNafn.Text = lanthegi.nafn;
            m_tboKennitala.Text = lanthegi.kennitala;
            m_tboHeit_fyrirtaekis.Text = lanthegi.nafn_fyrirtaekis;
            m_tboKennitalFyrirtaekis.Text = lanthegi.kennitala_fyrirtaekis;
            m_tboNetfang.Text = lanthegi.netfang;
            m_tboSimi.Text = lanthegi.simi;

        }

        private void m_chbKenniVantar_CheckedChanged(object sender, EventArgs e)
        {
            if(!m_chbKenniVantar.Checked)
            {
                m_tboKennitala.Text =string.Empty;
            }
            else
            {
                //næ í hæstu dummy
                int iMax = lanthegi.maxDummyKennitala() + 1;
                string strKenni = "000000" + iMax.ToString("0000");
                m_tboKennitala.Text = strKenni;
            }
        }

      
        private void m_chbKenniFyrirVantar_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_chbKenniFyrirVantar.Checked)
            {
                m_tboKennitalFyrirtaekis.Text = string.Empty;
            }
            else
            {
                //næ í hæstu dummy
                int iMax = lanthegi.maxDummyKennitalFyrirTaeki()+ 1;
                string strKenni = "000000" + iMax.ToString("0000");
                m_tboKennitalFyrirtaekis.Text = strKenni;
            }
        }
    }
}
