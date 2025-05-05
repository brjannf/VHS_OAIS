using cClassOAIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MHR_LEIT
{
    public partial class frmNotendur : Form
    {
        cNotandi virkurnotandi = new cNotandi();
        cNotandi breytanota = new cNotandi();
        string m_strrKennitala = string.Empty;
        public frmNotendur()
        {
            InitializeComponent();
        }

        public frmNotendur(cNotandi notandi, cNotandi virkur)
        {

            InitializeComponent();
            virkurnotandi = virkur;
            breytanota = notandi;
            breytanota.m_bAfrit = virkurnotandi.m_bAfrit;
            m_strrKennitala = breytanota.kennitala;
            fyllaVorsluStofnun();
            fyllaNotanda();
            

        }

        private void fyllaVorsluStofnun()
        {
            cVorslustofnun varsla = new cVorslustofnun();
            varsla.m_bAfrit = virkurnotandi.m_bAfrit;
            DataTable dt = varsla.getAllVörslustofnanir();
            DataRow r = dt.NewRow();
            r["varsla_heiti"] = "Veldu vörslustofnun";
            dt.Rows.InsertAt(r, 0);
            m_comVörslustofnun.ValueMember = "vorslustofnun";
            m_comVörslustofnun.DisplayMember = "varsla_heiti";
            m_comVörslustofnun.DataSource = dt;
        }

        private void fyllaNotanda()
        {
            m_tboNafn.Text = breytanota.nafn;
            m_tboKennitala.Text = breytanota.kennitala;
            m_tboLykilord.Text = breytanota.lykilord;
            m_tboNetfang.Text = breytanota.netfang;
            m_tboNotendaNafn.Text = breytanota.notendanafn;
            m_tboHeimilsfang.Text = breytanota.heimilisfang;
            if (virkurnotandi.m_bAfrit)
            {
                m_comVörslustofnun.SelectedItem = m_comVörslustofnun.Items[1];
            }
            else
            {
                if(breytanota.vörslustofnun != null)
                {
                    m_comVörslustofnun.SelectedValue = breytanota.vörslustofnun;
                }
              
            }
            m_tboSimi.Text = breytanota.simi;
            m_tboAthugasemdir.Text = breytanota.athugasemdir;
            if (breytanota.virkur == 1)
            {
                m_chbVirkur.Checked = true;
            }
            else
            {
                m_chbVirkur.Checked = false;
            }

            if (breytanota.kennitala != null)
            {
                m_comHlutverk.Text = breytanota.hlutverk;
                m_comVörslustofnun.Text = breytanota.vörslustofnun;
            }
            else
            {
                m_comHlutverk.Text = "Veldu hlutverk";
                m_comVörslustofnun.Text = "Veldu vörslustofnun";
                m_chbVirkur.Checked = true;
            }

        }

        private void m_btnVista_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            cNotandi testNot = new cNotandi();
            testNot.m_bAfrit = virkurnotandi.m_bAfrit;  
            testNot.sækjaNotanda(m_tboKennitala.Text.Replace("-", ""));

            if (m_tboNafn.Text.Length == 0)
            {
                errorProvider1.SetError(m_tboNafn, "Vantar nafn");

            }
            if (m_strrKennitala != string.Empty)
            {
                if (m_tboKennitala.Text.Replace("-", "") != m_strrKennitala)
                {
                    if (testNot.kennitala == m_tboKennitala.Text.Replace("-", ""))
                    {
                        errorProvider1.SetError(m_tboKennitala, string.Format("{0}, er með þessa kennitölu", testNot.nafn));
                    }
                }

            }
            if (m_tboKennitala.Text.Replace("-", "").Length != 10)
            {
                errorProvider1.SetError(m_tboKennitala, "Vantar kennitölu");
            }
            testNot.hreinsaHlut();
            testNot.sækjaNotandaNot(m_tboKennitala.Text.Replace("-", ""), m_tboNotendaNafn.Text);
            if (testNot.notendanafn != null)
            {
                errorProvider1.SetError(m_tboNotendaNafn, string.Format("{0}, er með þetta notendanafn", testNot.nafn));
            }

            if (m_tboNotendaNafn.Text.Length == 0)
            {
                errorProvider1.SetError(m_tboNotendaNafn, "Vantar notendanafn");
            }
            if (m_comVörslustofnun.Text == "Veldu vörslustofnun")
            {
                errorProvider1.SetError(m_comVörslustofnun, "Veldu vörslustofnun");
            }
            if (m_tboLykilord.Text.Length == 0)
            {
                errorProvider1.SetError(m_tboLykilord, "Vantar lykilorð");
            }
            if (m_comHlutverk.Text == "Veldu hlutverk")
            {
                errorProvider1.SetError(m_comHlutverk, "Veldu hlutverk");
            }

            if (errorProvider1.HasErrors)
            {
                return;
            }

            breytanota.nafn = m_tboNafn.Text;
            breytanota.kennitala = m_tboKennitala.Text.Replace("-", "");
            breytanota.lykilord = m_tboLykilord.Text;
            breytanota.netfang = m_tboNetfang.Text;
            breytanota.notendanafn = m_tboNotendaNafn.Text;
            breytanota.heimilisfang = m_tboHeimilsfang.Text;
            breytanota.simi = m_tboSimi.Text;
            breytanota.hlutverk = m_comHlutverk.Text;
            breytanota.vörslustofnun = m_comVörslustofnun.SelectedValue.ToString(); ;
            breytanota.hver_skradi = virkurnotandi.nafn;
            breytanota.athugasemdir = m_tboAthugasemdir.Text;
            if (m_chbVirkur.Checked)
            {
                breytanota.virkur = 1;
            }
            else
            {
                breytanota.virkur = 0;
            }


            breytanota.vista(m_strrKennitala);
            m_strrKennitala = breytanota.kennitala;
            DialogResult result = MessageBox.Show("Breytingar skráðar. Loka glugga?", "Vistað", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void m_tboLandfræði_5_3_2_TextChanged(object sender, EventArgs e)
        {
            // amount of padding to add
            TextBox box = (TextBox)sender;
            const int padding = 3;
            // get number of lines (first line is 0, so add 1)
            int numLines = box.GetLineFromCharIndex(box.TextLength) + 1;
            // get border thickness
            int border = box.Height - box.Height;
            // set height (height of one line * number of lines + spacing)
            box.Height = 20 * numLines + padding + border; // box.Height * numLines + padding + border;

        }
    }
}
