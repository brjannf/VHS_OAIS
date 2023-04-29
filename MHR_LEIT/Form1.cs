using cClassOAIS;

using System.Data;

namespace MHR_LEIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void m_btnLeita_Click(object sender, EventArgs e)
        {
            leita();  
        }

        private void leita()
        {
            cMIdlun midlun = new cMIdlun();
            DataTable dt = midlun.leit(m_tboLeitOrd.Text);
            m_dgvLeit.AutoGenerateColumns = false;
            m_dgvLeit.DataSource = dt;
            m_lblLeitarnidurstodur.Text = string.Format("Það fundust {0} leitarniðurstöður útfrá leitarorðunum {1}", dt.Rows.Count, m_tboLeitOrd.Text);
        }

        private void m_tboLeitOrd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                leita();
            }
        }

        private void m_dgvLeit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var senderGrid = (DataGridView)sender;
                string strGagnagrunnur = senderGrid.Rows[e.RowIndex].Cells["colGagnaGrunnur"].Value.ToString();
                string strValid = senderGrid.Rows[e.RowIndex].Cells["colDocID"].Value.ToString();

                DataTable table = m_dgvLeit.DataSource as DataTable;
                DataRow row = table.NewRow();
                row = ((DataRowView)m_dgvLeit.Rows[e.RowIndex].DataBoundItem).Row;

                frmSkraarkerfi skrakerfi = new frmSkraarkerfi(strGagnagrunnur, strValid, row, m_tboLeitOrd.Text);
                skrakerfi.ShowDialog();
            }
        }
    }
}