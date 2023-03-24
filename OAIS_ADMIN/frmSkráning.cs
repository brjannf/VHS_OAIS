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
    public partial class frmSkráning : Form
    {
        public frmSkráning()
        {
            InitializeComponent();
        }
        public frmSkráning(cSkjalaskra skrá, cNotandi virkur)
        {
            InitializeComponent();
            this.Text = "Afhendingarútgáfa - " + skrá.titill_3_1_2 + " " + skrá.auðkenni_3_1_1;
            uscSkraningar skjalM = new uscSkraningar(skrá, virkur);
            this.Controls.Add(skjalM);
            skjalM.Dock = DockStyle.Fill;
            this.WindowState = FormWindowState.Maximized;

        }

    }
}
