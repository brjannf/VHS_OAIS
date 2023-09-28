using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cClassOAIS;

namespace MHR_LEIT
{
    public partial class usclanthegar : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        cLanthegar lanthegi = new cLanthegar();
        public usclanthegar()
        {
            InitializeComponent();

        }

        public void fyllaLanthega()
        {
            lanthegi.m_bAfrit = virkurnotandi.m_bAfrit;
            m_dgvLanthegar.DataSource = lanthegi.getLanthegaLista();
        }

        private void m_btnSkyrlsa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorrý ekki komið");
        }

        private void m_btnStofna_Click(object sender, EventArgs e)
        {
            frmLanthegi lan = new frmLanthegi(virkurnotandi);
            lan.ShowDialog();
            m_dgvLanthegar.DataSource = lanthegi.getLanthegaLista();
        }


        private void m_dgvLanthegar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colLanBreyta"].Index == e.ColumnIndex)
                {
                    string strLanID = senderGrid.Rows[e.RowIndex].Cells["colLanID"].Value.ToString();
                    frmLanthegi lan = new frmLanthegi(virkurnotandi, strLanID);
                    lan.ShowDialog();
                    m_dgvLanthegar.DataSource = lanthegi.getLanthegaLista();
                }
                if(senderGrid.Columns["colLanListi"].Index == e.ColumnIndex)
                {
                    string strLanID = senderGrid.Rows[e.RowIndex].Cells["colLanID"].Value.ToString();
                    frmUtlan utlan = new frmUtlan(strLanID, virkurnotandi);
                    utlan.ShowDialog();
                    //string strLanID = senderGrid.Rows[e.RowIndex].Cells["colLanID"].Value.ToString();
                    //frmLanthegi lan = new frmLanthegi(virkurnotandi, strLanID);
                    //lan.ShowDialog();
                    //m_dgvLanthegar.DataSource = lanthegi.getLanthegaLista();
                }

            }
            


        }
    }
}
