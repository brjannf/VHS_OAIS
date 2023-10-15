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
    public partial class frmInnhald : Form
    {
        public frmInnhald()
        {
            InitializeComponent();
        }
        public frmInnhald(string strInnihald, string strVorslustofnun, string strTitill, string strSkjalamyndari, string strHeitiVorsluutgafu)
        {
            InitializeComponent();
            this.Text =  strTitill;
            m_lblTitill.Text = "Titill: " + strTitill;
            m_lblVorslustofnun.Text = "Vörslustofnun: " + strVorslustofnun;
            m_tboInnhald.Text =  strInnihald;
            m_lblSkjalamyndari.Text = "Skjalamyndari: " + strSkjalamyndari;
            m_lblVorsluutgafa.Text = "Titill vörsluútgáfu " + strHeitiVorsluutgafu;
        }
    }
}
