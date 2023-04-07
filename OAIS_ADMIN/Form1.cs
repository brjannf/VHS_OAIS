using System.Runtime.CompilerServices;
using static OAIS_ADMIN.uscNotandi;
using cClassOAIS;

namespace OAIS_ADMIN
{
    public partial class Form1 : Form
    {
       cNotandi virkurNotandi = new cNotandi();
        public Form1()
        {
            InitializeComponent();
            m_pnlNotandi.BringToFront();
            m_pnlNotandi.Dock = DockStyle.Fill;
            this.Text = "MHR";

        }

      

        private void m_btnInnskra_Click(object sender, EventArgs e)
        {
            innskra();          
        }

        private void innskra()
        {
            m_lblVillaInnSkraning.Visible = false;  
            string strNotandi = m_tboNoterndaNafn.Text;
            string strLykilorð = m_tboLykilOrd.Text;
            virkurNotandi.sækjaNotanda(strNotandi, strLykilorð);
            if (virkurNotandi.nafn != null)
            {
                m_tacMain.BringToFront();
                m_tacMain.Dock = DockStyle.Fill;
                this.Text = "Velkominn " + virkurNotandi.nafn;
                m_uscInnsetning.virkurnotandi = virkurNotandi;
                uscGagnaUmsjon1.virkurnotandi = virkurNotandi;
                uscGeymsluMidlar1.virkurnotandi = virkurNotandi;
                uscUmsjon1.virkurnotandi = virkurNotandi;
                virkurNotandi.skraInnskra(virkurNotandi.kennitala);
                if (virkurNotandi.hlutverk != "Umsjónarmaður")
                {
                    m_tacMain.TabPages.Remove(m_tapUmsjon);
                }
                else
                {
                    if(!m_tacMain.Contains(m_tapUmsjon))
                    {
                        m_tacMain.TabPages.Add(m_tapUmsjon);
                    }
                     
                }
                m_tacMain.SelectedTab = m_tapInnsetning;
                this.WindowState = FormWindowState.Maximized;
               
            }
            else
            {
                m_lblVillaInnSkraning.Visible = true;
                m_lblVillaInnSkraning.Text = "Rangt notendanafn eða lykilorð";
            }
        }

        private void m_tboNoterndaNafn_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                innskra();
            }
            
        }

        private void m_tapUmsjon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_tacMain.SelectedTab == m_tapGagnaUmsjon)
            {
                uscGagnaUmsjon1.endurHressa();
            }
       }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            m_pnlNotandi.BringToFront();
            virkurNotandi.hreinsaHlut();
            m_tboLykilOrd.Text = string.Empty;
            m_tboNoterndaNafn.Text = string.Empty;
            this.Text = "MHR";
        }
    }
}