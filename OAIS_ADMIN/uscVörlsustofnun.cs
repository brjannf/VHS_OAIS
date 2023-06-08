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

namespace OAIS_ADMIN
{
   
    public partial class uscVörlsustofnun : UserControl
    {
        cVorslustofnun vörslustofnun = new cVorslustofnun();
        cNotandi virkurnotandi = new cNotandi();
        public uscVörlsustofnun()
        {
            InitializeComponent();
        }

        public uscVörlsustofnun(cVorslustofnun varsla, cNotandi virkur)
        {
            InitializeComponent();
            vörslustofnun = varsla;
            virkurnotandi = virkur;
            fyllaSkraningarStöðu();
            fyllaSkraningarStig();
            fyllaKlasa();
            fyllaVörslustofnun();
        }

        private void fyllaSkraningarStöðu()
        {
           DataTable dt =  vörslustofnun.getENUMSkraningStaða();
           m_comSrkáningarStaaða_5_6_4.DataSource = dt;
           m_comSrkáningarStaaða_5_6_4.ValueMember = "gerd";
           m_comSrkáningarStaaða_5_6_4.DisplayMember = "gerd";
        }

        private void fyllaSkraningarStig()
        {
            DataTable dt = vörslustofnun.getENUMSkraningStig();
            m_comSkrangingrStig_5_6_5.DataSource = dt;
            m_comSkrangingrStig_5_6_5.ValueMember = "gerd";
            m_comSkrangingrStig_5_6_5.DisplayMember = "gerd";
        }
        private void fyllaKlasa()
        {
            DataTable dt = vörslustofnun.getENUMKlasar();
            m_comKlasi.DataSource = dt;
            m_comKlasi.ValueMember = "klasi";
            m_comKlasi.DisplayMember = "klasi";
        }

        private void fyllaVörslustofnun()
        {
            m_lblSkrad.Text = "Skráð: " + vörslustofnun.dags_skráð + " -" + vörslustofnun.hver_skráði;
            if (vörslustofnun.hver_breytti != string.Empty)
            {
                m_lblBreytt.Visible = true;
                m_lblBreytt.Text = "Síðast breytt: " + vörslustofnun.dags_breytt + " - " + vörslustofnun.hver_breytti;
            }
            m_tboAuðkenni_5_1_1.Text = vörslustofnun.auðkenni_5_1_1;
            m_tboOpinbert_heiti_5_1_2.Text = vörslustofnun.opinbert_heiti_5_1_2;
            m_tboErlendHeiti_5_1_3.Text =  vörslustofnun.erlent_heiti_5_1_3;
            m_tboAnnaðHeiti_5_1_4.Text = vörslustofnun.annað_heiti_5_1_4;
            m_tboTegund_5_1_5.Text = vörslustofnun.tegund_5_1_5_;
            m_tboAðsetur_5_2_1.Text = vörslustofnun.aðsetur_5_2_1;
            m_tboSamskiptaleidir_5_2_2.Text = vörslustofnun.samskiptaleiðir_5_2_2;
            m_tboSamskiptaaðilar_5_2_3.Text = vörslustofnun.samskiptaaðilar_5_2_3;
            m_tboSaga_5_3_1.Text = vörslustofnun.saga_stofnunar_5_3_1;
            m_tboLandfræði_5_3_2.Text = vörslustofnun.landfræðilegt_samhengi_5_3_2;
            m_tboStjornsysla_5_3_3.Text = vörslustofnun.stjórnsýsluheimildir_5_3_3;
            m_tboStjornStada_5_3_4.Text = vörslustofnun.stjórnsýsluleg_staða_5_3_4;
            m_tboVardveisla_5_3_5.Text =  vörslustofnun.varðveislustefna_5_3_5;
            m_tboByggingar_5_3_6.Text = vörslustofnun.byggingar_5_3_6;
            m_tboSkjalafordi_5_3_7.Text = vörslustofnun.skjalaforði_5_3_7;
            m_tboUtgafur_5_3_8.Text =  vörslustofnun.útgáfur_5_3_8;
            m_tboOpnarTimar_5_4_1.Text = vörslustofnun.opnunartímar_5_4_1;
            m_tboAdgangur_5_4_2.Text = vörslustofnun.aðgangsforsendur_5_4_2;
            m_tboAdgengi_5_4_3.Text = vörslustofnun.aðgengi_5_4_3;
            m_tboRannsokn_5_5_1.Text = vörslustofnun.rannsóknarþjónusta_5_5_1;
            m_tboAfritun_5_5_2.Text = vörslustofnun.afritunarþjónusta_5_5_2;
            m_tboAlmenning_5_5_3.Text = vörslustofnun.almenningssvæði_5_5_3;
            m_tboLysandi_5_6_1.Text = vörslustofnun.lýsandi_auðkenni_5_6_1;
            m_tboEinkennandi_5_6_2.Text =  vörslustofnun.einkennandi_heiti_5_6_2;
            m_tboReglur_5_6_3.Text = vörslustofnun.reglur_staðlar_5_6_3;
            m_comSrkáningarStaaða_5_6_4.SelectedValue =  vörslustofnun.skráningarstaða_5_6_4;
            m_comSkrangingrStig_5_6_5.SelectedValue = vörslustofnun.skráningarstig_5_6_5;
            m_tboDagsetningar_6_6_6.Text = vörslustofnun.dagsetningar_5_6_6;
            m_tboTungumal_5_6_7.Text = vörslustofnun.tungumál_letur_5_6_7;
            m_tboHeimildir_5_6_8.Text = vörslustofnun.heimildir_5_6_8;
            m_tboAthugasemdir_5_6_9.Text = vörslustofnun.athugasemdir_5_6_9;
            m_comKlasi.SelectedValue = vörslustofnun.klasi;

        }

        private void m_btn_5_1_Click(object sender, EventArgs e)
        {
            Button takki = (Button)sender;
            TableLayoutPanel TPN = (TableLayoutPanel)takki.Parent;

            if (takki.Text == "+")
            {
                TPN.AutoSize = false;
                takki.Tag = TPN.Height;
                TPN.Height = 20;
                
                takki.Text = "-";
            }
            else
            {
                TPN.AutoSize = true;
                TPN.Height = Convert.ToInt32(takki.Tag);
                takki.Text = "+";
            }
            stillaToflur();
        }

        private void stillaToflur()
        {
            int x = m_tlp_1.Location.X;
            m_tpl_2.Location = new Point(m_tlp_1.Location.X, m_tlp_1.Location.Y + m_tlp_1.Height + 20);
            int y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20;
            m_tpl_3.Location = new Point(x, y);
            y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20 + m_tpl_3.Height + 20;
            m_tpl_4.Location = new Point(x, y);
            y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20 + m_tpl_3.Height + 20  + m_tpl_4.Height + 20;
            m_tpl_5.Location = new Point(x, y);
            y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20 + m_tpl_3.Height + 20 + m_tpl_4.Height + 20 + m_tpl_5.Height + 20; ;
            m_tpl_6.Location = new Point(x, y);
        }

        private void m_btnVista_Click(object sender, EventArgs e)
        {
           // vörslustofnun.auðkenni_5_1_1 =  m_tboAuðkenni_5_1_1.Text;
            vörslustofnun.opinbert_heiti_5_1_2 = m_tboOpinbert_heiti_5_1_2.Text;
            vörslustofnun.erlent_heiti_5_1_3 = m_tboErlendHeiti_5_1_3.Text;
            vörslustofnun.annað_heiti_5_1_4 = m_tboAnnaðHeiti_5_1_4.Text;
            vörslustofnun.tegund_5_1_5_ = m_tboTegund_5_1_5.Text;
            vörslustofnun.aðsetur_5_2_1 = m_tboAðsetur_5_2_1.Text;
            vörslustofnun.samskiptaleiðir_5_2_2 = m_tboSamskiptaleidir_5_2_2.Text;
            vörslustofnun.samskiptaaðilar_5_2_3 = m_tboSamskiptaaðilar_5_2_3.Text;
            vörslustofnun.saga_stofnunar_5_3_1  = m_tboSaga_5_3_1.Text;
            vörslustofnun.landfræðilegt_samhengi_5_3_2 = m_tboLandfræði_5_3_2.Text;
            vörslustofnun.stjórnsýsluheimildir_5_3_3 = m_tboStjornsysla_5_3_3.Text;
            vörslustofnun.stjórnsýsluleg_staða_5_3_4 = m_tboStjornStada_5_3_4.Text;
            vörslustofnun.varðveislustefna_5_3_5 = m_tboVardveisla_5_3_5.Text;
            vörslustofnun.byggingar_5_3_6 = m_tboByggingar_5_3_6.Text;
            vörslustofnun.skjalaforði_5_3_7 = m_tboSkjalafordi_5_3_7.Text;
            vörslustofnun.útgáfur_5_3_8 = m_tboUtgafur_5_3_8.Text;
            vörslustofnun.opnunartímar_5_4_1 = m_tboOpnarTimar_5_4_1.Text;
            vörslustofnun.aðgangsforsendur_5_4_2 = m_tboAdgangur_5_4_2.Text;
            vörslustofnun.aðgengi_5_4_3 = m_tboAdgengi_5_4_3.Text;
            vörslustofnun.rannsóknarþjónusta_5_5_1 = m_tboRannsokn_5_5_1.Text;
            vörslustofnun.afritunarþjónusta_5_5_2 = m_tboAfritun_5_5_2.Text;
            vörslustofnun.almenningssvæði_5_5_3 = m_tboAlmenning_5_5_3.Text;
            vörslustofnun.lýsandi_auðkenni_5_6_1 = m_tboLysandi_5_6_1.Text;
            vörslustofnun.einkennandi_heiti_5_6_2 = m_tboEinkennandi_5_6_2.Text;
            vörslustofnun.reglur_staðlar_5_6_3 = m_tboReglur_5_6_3.Text;
            vörslustofnun.skráningarstaða_5_6_4 = m_comSrkáningarStaaða_5_6_4.SelectedValue.ToString();
            vörslustofnun.skráningarstig_5_6_5 = m_comSkrangingrStig_5_6_5.SelectedValue.ToString();
            vörslustofnun.dagsetningar_5_6_6 = m_tboDagsetningar_6_6_6.Text;
            vörslustofnun.tungumál_letur_5_6_7 = m_tboTungumal_5_6_7.Text;
            vörslustofnun.heimildir_5_6_8 = m_tboHeimildir_5_6_8.Text;
            vörslustofnun.athugasemdir_5_6_9 = m_tboAthugasemdir_5_6_9.Text;
            vörslustofnun.klasi = m_comKlasi.SelectedValue.ToString();
            vörslustofnun.hver_breytti = virkurnotandi.nafn;

            vörslustofnun.vista();
            vörslustofnun.getVörslustofnun(vörslustofnun.auðkenni_5_1_1);
            fyllaVörslustofnun();
            MessageBox.Show("Búið að vista breytingar");
            
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
            stillaToflur();
        }

        private void uscVörlsustofnun_Load(object sender, EventArgs e)
        {

        }
    }
   
}

