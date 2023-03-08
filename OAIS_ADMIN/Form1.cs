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
          
            
        }

      

        private void m_btnInnskra_Click(object sender, EventArgs e)
        {
            innskra();          
        }

        private void innskra()
        {
            m_lblVillaInnSkraning.Visible = false;  
            string strNotandi = m_tboNoterndaNafn.Text;
            string strLykilor� = m_tboLykilOrd.Text;
            virkurNotandi.s�kjaNotanda(strNotandi, strLykilor�);
            if (virkurNotandi.nafn != null)
            {
                m_tacMain.BringToFront();
                m_tacMain.Dock = DockStyle.Fill;
                this.Text = "Velkominn " + virkurNotandi.nafn;
                m_uscInnsetning.virkurnotandi = virkurNotandi;
               
            }
            else
            {
                m_lblVillaInnSkraning.Visible = true;
                m_lblVillaInnSkraning.Text = "Rangt notendanafn e�a lykilor�";
            }
        }

        private void m_tboNoterndaNafn_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                innskra();
            }
            
        }
    }
}