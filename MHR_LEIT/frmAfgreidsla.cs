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
    public partial class frmAfgreidsla : Form
    {
        cNotandi not = new cNotandi();
         
        public frmAfgreidsla()
        {
            InitializeComponent();
        }
        public frmAfgreidsla(cNotandi not, DataTable dtSkra, DataTable dtMal, DataTable dtGrunn, DataSet dsMAL)
        {
            InitializeComponent();
            uscPantanir pantanir = new uscPantanir(not, dtSkra, dtMal,dtGrunn, dsMAL) ;
            this.Controls.Add(pantanir);
            pantanir.Dock = DockStyle.Fill;
        }

    }
}
