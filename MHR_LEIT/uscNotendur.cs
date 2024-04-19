using cClassOAIS;
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
    public partial class uscNotendur : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        
        DataTable m_dtNotendur = new DataTable();
        public uscNotendur()
        {
            
            InitializeComponent();
           // fyllaNotendaLista();
        }
        public void fyllaNotendaLista()
        {

            m_dtNotendur = virkurnotandi.notendaListi();
            m_dgvNotendur.AutoGenerateColumns = false;
            m_dgvNotendur.DataSource = m_dtNotendur;
            if (m_dtNotendur.Rows.Count == 1)
            {
                m_dgvNotendur.Height = (m_dtNotendur.Rows.Count * 90);
            }
            else
            {
                m_dgvNotendur.Height = (m_dtNotendur.Rows.Count * 30) + 30;
            }

            Point p = new Point(m_btnStofnaNotanda.Location.X, m_dgvNotendur.Height + 40);
            m_btnStofnaNotanda.Location = p;
            m_dgvNotendur.BackgroundColor = Color.White;

        }

        private void m_btnStofnaNotanda_Click(object sender, EventArgs e)
        {
            cNotandi not = new cNotandi();
            frmNotendur frmNot = new frmNotendur(not, virkurnotandi);
            frmNot.ShowDialog();
            m_dtNotendur = virkurnotandi.notendaListi();
            fyllaNotendaLista();
        }

        private void m_dgvNotendur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colNotBreyta"].Index == e.ColumnIndex)
                {
                    cNotandi notbreyta = new cNotandi();
                    notbreyta.m_bAfrit = virkurnotandi.m_bAfrit;
                    string strKennitla = senderGrid.Rows[e.RowIndex].Cells["colNotandiKennitala"].Value.ToString();
                    notbreyta.sækjaNotanda(strKennitla);
                    frmNotendur frmNot = new frmNotendur(notbreyta, virkurnotandi);
                    frmNot.ShowDialog();
                    m_dtNotendur = virkurnotandi.notendaListi();
                    fyllaNotendaLista();

                }
            }
        }
    }
}
