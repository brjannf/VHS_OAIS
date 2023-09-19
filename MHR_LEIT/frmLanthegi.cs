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

namespace MHR_LEIT
{
    public partial class frmLanthegi : Form
    {
        cNotandi virkurnotandi = new cNotandi(); 
        cLanthegar lanthegi= new cLanthegar();
        public frmLanthegi(cNotandi not)
        {
            InitializeComponent();
            virkurnotandi = not;
        }

        private void m_btnVista_Click(object sender, EventArgs e)
        {
            lanthegi.m_bAfrit = virkurnotandi.m_bAfrit;
            lanthegi.nafn = m_tboNafn.Text;
            lanthegi.kennitala = m_tboKennitala.Text.Replace("-", "");
            lanthegi.nafn_fyrirtaekis = m_tboHeit_fyrirtaekis.Text; ; 
            lanthegi.kennitala_fyrirtaekis = m_tboKennitalFyrirtaekis.Text.Replace("-", "");
            lanthegi.netfang = m_tboNetfang.Text;
            lanthegi.simi= m_tboSimi.Text;
            lanthegi.skrad_af = virkurnotandi.nafn;

            lanthegi.vista();
            DialogResult result= MessageBox.Show("Lánþegi skráður, loka glugga?", "Lánþegi skráður",MessageBoxButtons.YesNo);
            if(DialogResult.Yes == result) 
            {
                this.Close();
            }
        }
    }
}
