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
    public partial class frmVörslustofnun : Form
    {
        public frmVörslustofnun()
        {
            InitializeComponent();
            
        }

        public frmVörslustofnun(cVorslustofnun varsla, cNotandi virkur)
        {
            InitializeComponent();
            this.Text = "Vörslustofnun - " + varsla.opinbert_heiti_5_1_2;
            uscVörlsustofnun vörslustofnun = new uscVörlsustofnun(varsla, virkur);
            this.Controls.Add(vörslustofnun);
            vörslustofnun.Dock= DockStyle.Fill;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
