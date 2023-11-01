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
    public partial class uscSkjalamyndari : UserControl
    {
        private cSkjalamyndari skjalamyndari = new cSkjalamyndari();
        private cNotandi virkurnotandi = new cNotandi();
        public uscSkjalamyndari()
        {
            InitializeComponent();
        }

        public uscSkjalamyndari(cSkjalamyndari skjal, cNotandi virkur)
        {
            InitializeComponent();
            skjalamyndari = skjal;
            virkurnotandi = virkur;
            fyllaSkraningarStöðu();
            fyllaSkraningarStig();
            fyllaGerdSkjalamynara();
            fyllaSkjalamyndara();
        }

        private void fyllaGerdSkjalamynara()
        {
            DataTable dt = skjalamyndari.getENUM();
            m_comGerd_5_1_1.DataSource = dt;
            m_comGerd_5_1_1.ValueMember = "gerd";
            m_comGerd_5_1_1.DisplayMember = "gerd";
        }
        private void fyllaSkraningarStöðu()
        {
            DataTable dt = skjalamyndari.getENUMSkraningStaða();
            m_comSkraningStada_5_4_4.DataSource = dt;
            m_comSkraningStada_5_4_4.ValueMember = "gerd";
            m_comSkraningStada_5_4_4.DisplayMember = "gerd";
        }

        private void fyllaSkraningarStig()
        {
            DataTable dt = skjalamyndari.getENUMSkraningStig();
            m_comSkranStig_5_4_5.DataSource = dt;
            m_comSkranStig_5_4_5.ValueMember = "gerd";
            m_comSkranStig_5_4_5.DisplayMember = "gerd";
        }
        private void fyllaSkjalamyndara()
        {
            m_lblSkrad.Text = "Skráð: " + skjalamyndari.dags_skráð + " -" + skjalamyndari.hver_skráði;
            if (skjalamyndari.hver_breytti != string.Empty)
            {
                m_lblBreytt.Visible = true;
                m_lblBreytt.Text = "Síðast breytt: " + skjalamyndari.dags_breytt + " - " + skjalamyndari.hver_breytti;
            }
            m_comGerd_5_1_1.SelectedValue = skjalamyndari.gerð_5_1_1;
           m_tboOpinbert_heiti_5_1_2.Text = skjalamyndari.opinbert_heiti_5_1_2;
           m_tboErlendHeiti_5_1_3.Text = skjalamyndari.erlent_heiti_5_1_3;
           m_tboAnnaðHeitiAdkagad_5_1_4.Text = skjalamyndari.annað_heiti_aðlagað_5_1_4;
           m_tboAnnadHeiti_5_1_5.Text = skjalamyndari.annað_heiti_5_1_5;
           m_tboAudkenni_5_5_6.Text = skjalamyndari.auðkenni_5_1_6;
           m_tboTimabil_5_2_1.Text = skjalamyndari.tímabil_5_2_1;
           m_tboSaga_5_2_2.Text = skjalamyndari.saga_5_2_2;
           m_tboStadsetning_5_2_3.Text = skjalamyndari.staðsetning_5_2_3;
           m_tboLagale_5_2_4.Text = skjalamyndari.lagaleg_staða_5_2_4;
           m_tboHlutverk_5_2_5.Text =  skjalamyndari.hlutverk_5_2_5;
           m_tboLog_5_2_6.Text = skjalamyndari.tilheyrandi_lög_5_2_6;
           m_tboInnrStjorn_5_2_7.Text = skjalamyndari.innri_stjórnun_5_2_7;
           m_tboAlmennt_5_2_8.Text = skjalamyndari.almennt_samhengi_5_2_8;
           m_tboLandID_5_4_1.Text =  skjalamyndari.auðkenni_lands_5_4_1;
           if(m_tboLandID_5_4_1.Text == string.Empty)
            {
                m_tboLandID_5_4_1.Text = "IS";
            }
           m_tboAuðkenniVarsla_5_4_2.Text = skjalamyndari.auðkenni_vörslustofnunar_5_4_2;
           m_tboReglur_5_4_3.Text = skjalamyndari.reglur_staðlar_5_4_3;
           m_comSkraningStada_5_4_4.SelectedValue = skjalamyndari.skráningarstaða_5_4_4;
           m_comSkranStig_5_4_5.SelectedValue = skjalamyndari.skráningarstig_5_4_5;
           m_tboDagsetningar_5_4_6.Text = skjalamyndari.dagsetningar_5_4_6;
           m_tboTungumal_5_4_7.Text = skjalamyndari.tungumál_5_4_7;
           if (m_tboTungumal_5_4_7.Text == string.Empty)
           {
                m_tboTungumal_5_4_7.Text = "Íslenska";
           }
            m_tboHeimildir_5_4_8.Text = skjalamyndari.heimildir_5_4_8;
        }

      

        private void stillaToflur()
        {
            int x = m_tlp_1.Location.X;
            m_tpl_2.Location = new Point(m_tlp_1.Location.X, m_tlp_1.Location.Y + m_tlp_1.Height + 20);
            int y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20;
            m_tpl_3.Location = new Point(x, y);
            y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20 + m_tpl_3.Height + 20;
            m_tpl_4.Location = new Point(x, y);
           
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

        private void m_btnVista_Click(object sender, EventArgs e)
        {
            skjalamyndari.gerð_5_1_1 = m_comGerd_5_1_1.SelectedValue.ToString();
            skjalamyndari.opinbert_heiti_5_1_2  = m_tboOpinbert_heiti_5_1_2.Text;
            skjalamyndari.erlent_heiti_5_1_3 = m_tboErlendHeiti_5_1_3.Text;
            skjalamyndari.annað_heiti_aðlagað_5_1_4 = m_tboAnnaðHeitiAdkagad_5_1_4.Text;
            skjalamyndari.annað_heiti_5_1_5 = m_tboAnnadHeiti_5_1_5.Text;
            //  m_tboAudkenni_5_5_6.Text = skjalamyndari.auðkenni_5_1_6;
            skjalamyndari.tímabil_5_2_1 = m_tboTimabil_5_2_1.Text;
            skjalamyndari.saga_5_2_2 = m_tboSaga_5_2_2.Text;
            skjalamyndari.staðsetning_5_2_3 = m_tboStadsetning_5_2_3.Text;
            skjalamyndari.lagaleg_staða_5_2_4 = m_tboLagale_5_2_4.Text;
            skjalamyndari.hlutverk_5_2_5 = m_tboHlutverk_5_2_5.Text;
            skjalamyndari.tilheyrandi_lög_5_2_6 = m_tboLog_5_2_6.Text;
            skjalamyndari.innri_stjórnun_5_2_7 = m_tboInnrStjorn_5_2_7.Text;
            skjalamyndari.almennt_samhengi_5_2_8 = m_tboAlmennt_5_2_8.Text;
            skjalamyndari.auðkenni_lands_5_4_1 = m_tboLandID_5_4_1.Text;
            skjalamyndari.auðkenni_vörslustofnunar_5_4_2 = m_tboAuðkenniVarsla_5_4_2.Text;
            skjalamyndari.reglur_staðlar_5_4_3 = m_tboReglur_5_4_3.Text;
            skjalamyndari.skráningarstaða_5_4_4 = m_comSkraningStada_5_4_4.SelectedValue.ToString();
            skjalamyndari.skráningarstig_5_4_5 = m_comSkranStig_5_4_5.SelectedValue.ToString();
            skjalamyndari.dagsetningar_5_4_6 = m_tboDagsetningar_5_4_6.Text;
            skjalamyndari.tungumál_5_4_7 = m_tboTungumal_5_4_7.Text;
            skjalamyndari.heimildir_5_4_8 = m_tboHeimildir_5_4_8.Text;
            skjalamyndari.hver_breytti = virkurnotandi.nafn;

            skjalamyndari.vista();
            skjalamyndari.getSkjalamyndara(skjalamyndari.opinbert_heiti_5_1_2);
            fyllaSkjalamyndara();
            MessageBox.Show("Breytingar skráðar");
        }
    }
}
