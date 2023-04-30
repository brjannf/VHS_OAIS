using cClassOAIS;

using System.Data;
using System.Runtime.CompilerServices;

namespace MHR_LEIT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            fyllaV0rslusstofnanir();
            fyllaSkjalamyndara();


        }

        private void fyllaV0rslusstofnanir()
        {
            cVorslustofnun varsla = new cVorslustofnun();
            DataTable dt = varsla.getAllVOrslustofnanir();
            DataRow r = dt.NewRow();
            r["varsla_heiti"] = "Veldu vörslustofnun";
            dt.Rows.InsertAt(r, 0);
            m_comVorslustofnun.ValueMember = "vorslustofnun";
            m_comVorslustofnun.DisplayMember = "varsla_heiti";
            m_comVorslustofnun.DataSource = dt;
        }
        private void fyllaSkjalamyndara()
        {
            cSkjalamyndari skjalam = new cSkjalamyndari();
            DataTable dt = skjalam.getSkjalamyndaralista();
            DataRow r = dt.NewRow();
            r["5_1_2_opinbert_heiti"] = "Veldu skjalamyndara";
            dt.Rows.InsertAt(r, 0);
            m_comSkjalamyndari.ValueMember = "5_1_6_auðkenni";
            m_comSkjalamyndari.DisplayMember = "5_1_2_opinbert_heiti";
            m_comSkjalamyndari.DataSource = dt;

        }
        private void m_btnLeita_Click(object sender, EventArgs e)
        {
            leita();  
        }

        private void leita()
        {
            cMIdlun midlun = new cMIdlun();

            midlun.leitarord = m_tboLeitOrd.Text;
          
           
            if(m_comVorslustofnun.SelectedIndex != 0)
            {
                midlun.vorslustofnun_audkenni = m_comVorslustofnun.SelectedValue.ToString();
            }
            if(m_comSkjalamyndari.SelectedIndex != 0) 
            {
                midlun.skjalamyndari_audkenni = m_comSkjalamyndari.SelectedValue.ToString();
            }
            if(m_dtpStart.Checked)
            {
                midlun.Upphafsdags = m_dtpStart.Value.ToString();
            }
            if(m_dtEnd.Checked)
            {
                midlun.Endadags = m_dtEnd.Value.ToString();
            }
         //   mid

            DataTable dt = midlun.leit(m_tboLeitOrd.Text);
            m_dgvLeit.AutoGenerateColumns = false;
            m_dgvLeit.DataSource = dt;
            m_lblLeitarnidurstodur.Visible = true;
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

        private void m_btnHreinsa_Click(object sender, EventArgs e)
        {
            m_tboLeitOrd.Text = string.Empty;
            fyllaSkjalamyndara();
            fyllaV0rslusstofnanir();
           
            m_dtpStart.Value = DateTime.Now;
            m_dtEnd.Value = DateTime.Now;
            m_dtEnd.Checked = false;
            m_dtpStart.Checked = false;

        }
    }
}