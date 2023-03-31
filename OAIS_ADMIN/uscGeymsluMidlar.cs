using cClassOAIS;
using cClassVHS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIS_ADMIN
{
    public partial class uscGeymsluMidlar : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        public uscGeymsluMidlar()
        {
            InitializeComponent();

            cVHS_computer comp = new cVHS_computer();
            dataGridView1.DataSource = comp.getAllComputers();
        }
    }
}
