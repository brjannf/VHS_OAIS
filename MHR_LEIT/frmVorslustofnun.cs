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
using OAIS_ADMIN;

namespace MHR_LEIT
{
    public partial class frmVorslustofnun : Form
    {
        public frmVorslustofnun()
        {
            InitializeComponent();
        }
        public frmVorslustofnun(string strAuðkenni, cNotandi not)
        {
            InitializeComponent();
            cVorslustofnun varsla = new cVorslustofnun();
            varsla.m_bAfrit = not.m_bAfrit;
            varsla.getVörslustofnun(strAuðkenni);
            this.Text = "Vörslustofnun - " + varsla.opinbert_heiti_5_1_2;
            uscVörlsustofnun vörslustofnun = new uscVörlsustofnun(varsla, not);
            this.Controls.Add(vörslustofnun);
            vörslustofnun.Dock = DockStyle.Fill;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
