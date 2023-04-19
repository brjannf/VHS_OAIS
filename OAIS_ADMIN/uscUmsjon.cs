using cClassOAIS;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIS_ADMIN
{
    public partial class uscUmsjon : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        cStillingar stillingar = new cStillingar();
        DataTable m_dtNotendur = new DataTable();   
        public uscUmsjon()
        {
            InitializeComponent();
            m_dtNotendur = virkurnotandi.notendaListi();
            m_pnlNotendur.BringToFront();
            m_pnlStillingar.SendToBack();
            m_pnlNotendur.Dock = DockStyle.Fill;
            m_pnlStillingar.Dock = DockStyle.None;
            m_btnNotendur.BackColor = Color.LightGreen;
            m_btnUmhverfi.BackColor = Color.LightYellow;
            fyllaNotendaLista();
            fyllaStillingar();
            
        }

        private void fyllaStillingar()
        {

            stillingar.getStillingar(getComputer());
            m_tboSQLuser.Text = stillingar.sqluser;
            m_tboSQLpass.Text = stillingar.sqlpass;
            m_tboVerd.Text = stillingar.verd.ToString();

            if(stillingar.ID != 0 )
            {
                m_lblSkrad.Visible = true;
                m_pnlStillingar.BackColor = Color.LightGreen;
                m_btnStillingarVista.Text = "Vista Breytingar";
                m_lblSkrad.Text = "Skráð: " + stillingar.skrad_af + " " + stillingar.dags_skrad;
                if(stillingar.breytt_af.Length > 0)
                {
                    m_lblSkrad.Text += Environment.NewLine + "Breytt: " + stillingar.breytt_af + " " + stillingar.dags_breytt;
                }
            }
            else
            {
                m_lblSkrad.Visible = false; 
            }

            m_lblSQLversion.Text = "mySQL " + stillingar.getSQLversion();
            m_lblCurrComputer.Text = getComputer();
        }

        private string getComputer()
        {
            string strRet = string.Empty;
            this.Name = Environment.MachineName;

            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            //collection to store all management objects

            mc.Options.UseAmendedQualifiers = true;

            ManagementObjectCollection moc = mc.GetInstances();
            if (moc.Count != 0)
            {
                foreach (ManagementObject mo in mc.GetInstances())
                {
                    strRet = mo["Model"].ToString();

                }
            }

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_bios");

            ManagementObjectCollection information = searcher.Get();
            foreach (ManagementObject obj in information)
            {
                string strSerial = string.Empty;
                foreach (PropertyData data in obj.Properties)
                {
                    strRet += " Serial: " + data.Value.ToString();
                }
            }

            searcher.Dispose();
            return strRet;
          

        }
        private void m_btnNotendur_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Name == m_btnNotendur.Name) 
            {
                m_pnlNotendur.BringToFront();
                m_pnlStillingar.SendToBack();
                m_pnlNotendur.Dock = DockStyle.Fill;
                m_pnlStillingar.Dock = DockStyle.None;
                m_btnNotendur.BackColor = Color.LightGreen;
                m_btnUmhverfi.BackColor = Color.LightYellow;
                m_dtNotendur = virkurnotandi.notendaListi();
                fyllaNotendaLista();
            }
            else
            {
                m_pnlNotendur.SendToBack();
                m_pnlStillingar.BringToFront();
                m_pnlStillingar.Dock = DockStyle.Fill;
                m_pnlNotendur.Dock = DockStyle.None;
                m_btnNotendur.BackColor = Color.LightYellow;
                m_btnUmhverfi.BackColor = Color.LightGreen;
            }
        }

        private void fyllaNotendaLista()
        {
            m_dgvNotendur.AutoGenerateColumns = false;
            m_dgvNotendur.DataSource = m_dtNotendur;
            if(m_dtNotendur.Rows.Count == 1)
            {
                m_dgvNotendur.Height = (m_dtNotendur.Rows.Count * 60);
            }
            else
            {
                m_dgvNotendur.Height = (m_dtNotendur.Rows.Count * 30) +30;
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
                    string strKennitla = senderGrid.Rows[e.RowIndex].Cells["colNotandiKennitala"].Value.ToString();
                    notbreyta.sækjaNotanda(strKennitla);
                    frmNotendur frmNot = new frmNotendur(notbreyta, virkurnotandi);
                    frmNot.ShowDialog();
                    m_dtNotendur = virkurnotandi.notendaListi();
                    fyllaNotendaLista();

                }
            }
        }

        private void m_btnStillingarVista_Click(object sender, EventArgs e)
        {
            stillingar.curr_computer = m_lblCurrComputer.Text;
            stillingar.sqlversion = m_lblSQLversion.Text;
            stillingar.sqluser = m_tboSQLuser.Text;
            stillingar.sqlpass = m_tboSQLpass.Text;
            stillingar.verd = Convert.ToInt32(m_tboVerd.Text);
            stillingar.skrad_af = virkurnotandi.nafn;
            if(stillingar.ID != 0)
            {
                stillingar.breytt_af = virkurnotandi.nafn;
            }
            stillingar.vista();
            MessageBox.Show("Breytingar srkáðar");
            fyllaStillingar();

        }
    }
}
