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
    public partial class frmSkjalamyndariSkra : Form
    {
        public frmSkjalamyndariSkra()
        {
            InitializeComponent();
        }

        public frmSkjalamyndariSkra(cSkjalamyndari skjalamyndari, cNotandi virkur)
        {
            InitializeComponent();
            InitializeComponent();
            this.Text = skjalamyndari.opinbert_heiti_5_1_2;
            uscSkjalamyndari skjalM = new uscSkjalamyndari(skjalamyndari, virkur);
            this.Controls.Add(skjalM);
            skjalM.Dock = DockStyle.Fill;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
