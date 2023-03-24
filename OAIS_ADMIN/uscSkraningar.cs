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
    public partial class uscSkraningar : UserControl
    {
        private cSkjalaskra skjalaskra = new cSkjalaskra();
        private cNotandi virkurnotandi = new cNotandi();
        public uscSkraningar()
        {
            InitializeComponent();
        }

        public uscSkraningar(cSkjalaskra skjal, cNotandi virkur)
        {
            InitializeComponent();
            skjalaskra = skjal;
            virkurnotandi = virkur;
            fyllaUpplysingastig();
            fyllaSkjalasafn();
        }

        private void fyllaUpplysingastig()
        {
            DataTable dt = skjalaskra.getUpplysingastigENUM();
            m_comUpplysingastig_3_1_4.DataSource = dt;
            m_comUpplysingastig_3_1_4.ValueMember = "gerd";
            m_comUpplysingastig_3_1_4.DisplayMember = "gerd";
        }

        private void fyllaSkjalasafn()
        {
            m_lblSkrad.Text = "Skráð: " + skjalaskra.dags_skráð + " -" + skjalaskra.hver_skráði;
            if(skjalaskra.hver_breytti != string.Empty ) 
            {
                m_lblBreytt.Visible = true;
                m_lblBreytt.Text = "Síðast breytt: " + skjalaskra.dags_breytt + " - " + skjalaskra.hver_breytti;
            }
           m_tboAudkenni_3_1_1.Text = skjalaskra.auðkenni_3_1_1;
           m_tboTitill_3_1_2.Text = skjalaskra.titill_3_1_2;
           m_tboTimabil_3_1_3.Text = skjalaskra.tímabil_3_1_3;
           m_comUpplysingastig_3_1_4.Text = skjalaskra.upplýsingastig_3_1_4;
           m_tboMagnLysing_3_1_5.Text = skjalaskra.magn_lýsing_3_1_5;
           m_tboHeitiSkjalamyndara_3_2_1.Text = skjalaskra.heiti_skjalamyndara_3_2_1;
           m_tboSagaSkjlaamyndara_3_2_2.Text = skjalaskra.saga_skjalamyndara_3_2_2;
           m_tboSagaSkjalana_3_2_3.Text = skjalaskra.saga_skjalanna_3_2_3;
           m_tboAfhendingarTil_3_2_4.Text = skjalaskra.afhendingar_tilfærslur_3_2_4;
           m_tboYfirlit_innihald_3_3_1.Text = skjalaskra.yfirlit_innihald_3_3_1;
           m_tboTimaætlanir_3_3_2.Text = skjalaskra.tímaáætlanir_3_3_2;
           m_tboFyrirSkja_3_3_3.Text = skjalaskra.fyrirsjáanlegar_viðbætur_3_3_3;
           m_tboInnriSkipan_3_3_4.Text = skjalaskra.innri_skipan_3_3_4;
           m_comAdgegni_3_4_1.Text = skjalaskra.skilyrði_aðgengi_3_4_1;
           m_tboEndurPrentun_3_4_2.Text = skjalaskra.skilyrði_endurprentun_3_4_2;
            if (string.IsNullOrEmpty(skjalaskra.tungumál_3_4_3))
            {
                m_tboTungumal_3_4_3.Text = "Íslenska";
            }
            else
            {
                m_tboTungumal_3_4_3.Text = skjalaskra.tungumál_3_4_3;
            }
         
           m_tboYtriEinkenni_3_4_4.Text =  skjalaskra.ytri_einkenni_3_4_4;
           m_tboHjalpar_3_4_5.Text = skjalaskra.hjálpargögn_3_4_5;
           m_tboFrumrit_3_5_1.Text = skjalaskra.tilvist_frumrita_3_5_1;
           m_tboAfrit_3_5_2.Text = skjalaskra.tilvist_afrita_3_5_2;
           m_tboSkyld_3_5_3.Text = skjalaskra.skyld_skjöl_3_5_3;
           m_tboUtgafu_3_5_4.Text = skjalaskra.útgáfuupplýsingar_3_5_4;
           m_tboAthugasemdir_3_6_1.Text = skjalaskra.athugasemdir_3_6_1;
           m_tboAthugSkjal_3_7_1.Text = skjalaskra.athugasemdir_skjalavarðar_3_7_1;
           m_tboReglur_3_7_2.Text = skjalaskra.reglur_venjur_3_7_2;
           m_tboDagsendingar_3_7_3.Text = skjalaskra.dagsetningar_3_7_3;

        }

        private void stillaToflur()
        {
            int x = m_tlp_1.Location.X;
            m_tpl_2.Location = new Point(m_tlp_1.Location.X, m_tlp_1.Location.Y + m_tlp_1.Height + 20);
            int y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20;
            m_tpl_3.Location = new Point(x, y);
            y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20 + m_tpl_3.Height + 20;
            m_tpl_4.Location = new Point(x, y);
            y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20 + m_tpl_3.Height + 20 + m_tpl_4.Height + 20;
            m_tpl_5.Location = new Point(x, y);
            y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20 + m_tpl_3.Height + 20 + m_tpl_4.Height + 20  + m_tpl_5.Height + 20;
            m_tpl_6.Location = new Point(x, y);
            y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20 + m_tpl_3.Height + 20 + m_tpl_4.Height + 20 + m_tpl_5.Height + 20 + m_tpl_6.Height + 20;
            m_tpl_7.Location = new Point(x, y);
        }

        private void m_btn_5_1_Click_1(object sender, EventArgs e)
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

        private void m_btnVista_Click(object sender, EventArgs e)
        {
           
            skjalaskra.auðkenni_3_1_1 = m_tboAudkenni_3_1_1.Text;
            skjalaskra.titill_3_1_2 = m_tboTitill_3_1_2.Text;
            skjalaskra.tímabil_3_1_3 = m_tboTimabil_3_1_3.Text;
            skjalaskra.upplýsingastig_3_1_4 = m_comUpplysingastig_3_1_4.Text;
            skjalaskra.magn_lýsing_3_1_5 = m_tboMagnLysing_3_1_5.Text;
            skjalaskra.heiti_skjalamyndara_3_2_1 = m_tboHeitiSkjalamyndara_3_2_1.Text;
            skjalaskra.saga_skjalamyndara_3_2_2 = m_tboSagaSkjlaamyndara_3_2_2.Text;
            skjalaskra.saga_skjalanna_3_2_3 = m_tboSagaSkjalana_3_2_3.Text;
            skjalaskra.afhendingar_tilfærslur_3_2_4 = m_tboAfhendingarTil_3_2_4.Text;
            skjalaskra.yfirlit_innihald_3_3_1 = m_tboYfirlit_innihald_3_3_1.Text;
            skjalaskra.tímaáætlanir_3_3_2 = m_tboTimaætlanir_3_3_2.Text;
            skjalaskra.fyrirsjáanlegar_viðbætur_3_3_3 = m_tboFyrirSkja_3_3_3.Text;
            skjalaskra.innri_skipan_3_3_4 = m_tboInnriSkipan_3_3_4.Text;
            skjalaskra.skilyrði_aðgengi_3_4_1 = m_comAdgegni_3_4_1.Text;
            skjalaskra.skilyrði_endurprentun_3_4_2 = m_tboEndurPrentun_3_4_2.Text;
            skjalaskra.tungumál_3_4_3 = m_tboTungumal_3_4_3.Text;
            skjalaskra.ytri_einkenni_3_4_4 = m_tboYtriEinkenni_3_4_4.Text;
            skjalaskra.hjálpargögn_3_4_5 = m_tboHjalpar_3_4_5.Text;
            skjalaskra.tilvist_frumrita_3_5_1 = m_tboFrumrit_3_5_1.Text;
            skjalaskra.tilvist_afrita_3_5_2 = m_tboAfrit_3_5_2.Text;
            skjalaskra.skyld_skjöl_3_5_3 = m_tboSkyld_3_5_3.Text;
            skjalaskra.útgáfuupplýsingar_3_5_4 = m_tboUtgafu_3_5_4.Text;
            skjalaskra.athugasemdir_3_6_1 = m_tboAthugasemdir_3_6_1.Text;
            skjalaskra.athugasemdir_skjalavarðar_3_7_1 = m_tboAthugSkjal_3_7_1.Text;
            skjalaskra.reglur_venjur_3_7_2 = m_tboReglur_3_7_2.Text;
            skjalaskra.dagsetningar_3_7_3 = m_tboDagsendingar_3_7_3.Text;

            skjalaskra.hver_breytti = virkurnotandi.nafn;
            skjalaskra.vista();
            skjalaskra.getSkraning(skjalaskra.auðkenni_3_1_1);
            fyllaSkjalasafn();
            MessageBox.Show("Breytingar skráðar");
        }
    }
}
