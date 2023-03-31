using cClassOAIS;
using Org.BouncyCastle.Bcpg.OpenPgp;
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

namespace OAIS_ADMIN
{
    public partial class uscGagnaUmsjon : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        DataTable m_dtAllt = new DataTable();   
        DataTable m_dtSumt = new DataTable();   
        public uscGagnaUmsjon()
        {
            InitializeComponent();
           
            cSkjalaskra skrá = new cSkjalaskra();
            m_dtAllt = skrá.getVörsluútgáfur();
            


        }

        private void fyllaVörslustofnun(string strSkjalamyndari)
        {
            if(strSkjalamyndari == string.Empty)
            {
                //id, vorsluutgafa, utgafa_titill, vorslustofnun, varsla_heiti, skjalamyndari, skjalm_heiti, staerd, slod, innihald, timabil, afharnr, MD5, hver_skradi, dags_skrad
                //string strExp = string.Format("vorslustofnun='{0}",
                m_comVörslustofnanir.DataSource = m_dtAllt;
                m_comVörslustofnanir.ValueMember = "vorslustofnun";
                m_comVörslustofnanir.DisplayMember = "varsla_heiti";
               
            }
        }

        
        private void fyllaSkjalamyndara(string strVörlsustofnun)
        {
            m_comSkjalamyndarar.DataSource = m_dtAllt;
            m_comSkjalamyndarar.ValueMember = "skjalamyndari";
            m_comSkjalamyndarar.DisplayMember = "skjalm_heiti";
        }

        public void endurHressa()
        {
            cSkjalaskra skrá = new cSkjalaskra();
            m_dtAllt = skrá.getVörsluútgáfur();
            m_dtSumt = m_dtAllt.Clone();
            m_dgvAllt.DataSource =formatTable(m_dtAllt);
            fyllaVörslustofnun("");
            fyllaSkjalamyndara("");
        }

        private void m_comVörslustofnanir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_comVörslustofnanir.Focused )
            {
                if(m_comVörslustofnanir.SelectedValue != null)
                {
                    DataTable dt = new DataTable();
                    dt = m_dtAllt.Clone(); 
                   
                    string strExpr = string.Format("vorslustofnun='{0}'", m_comVörslustofnanir.SelectedValue.ToString());
                    DataRow[] fROW = m_dtAllt.Select(strExpr);
                    foreach (DataRow r in fROW)
                    {
                        dt.ImportRow(r);
                    }
                    m_dgvAllt.DataSource = formatTable(dt);
                }
             
            }
         
        }

        private void m_btnHreinsa_Click(object sender, EventArgs e)
        {
            endurHressa();
        }

        private void m_comSkjalamyndarar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_comSkjalamyndarar.Focused)
            {
                if (m_comSkjalamyndarar.SelectedValue != null)
                {
                    DataTable dt = new DataTable();
                    dt = m_dtAllt.Clone();

                    string strExpr = string.Format("skjalamyndari='{0}'", m_comSkjalamyndarar.SelectedValue.ToString());
                    DataRow[] fROW = m_dtAllt.Select(strExpr);
                    foreach (DataRow r in fROW)
                    {
                        dt.ImportRow(r);
                    }
                    m_dgvAllt.DataSource = dt;
                }

            }

        }
        private DataTable formatTable(DataTable dt)
        {
            DataTable dtCloned = dt.Clone();
            dtCloned.Columns["staerd"].DataType = typeof(string);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }
            //gera stærð skiljanlega

            foreach (DataRow r in dtCloned.Rows)
            {
                long bla = (long)Convert.ToDouble(r["staerd"]);
                r["staerd"] = FormatBytes(bla);
            }
            return dtCloned;
        }
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        private void m_dgvAllt_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colEditSkjalamyndari"].Index == e.ColumnIndex)
                {
                    string strHeiti = senderGrid.Rows[e.RowIndex].Cells["colSkjalmHeiti"].Value.ToString();
                    cSkjalamyndari skjalm = new cSkjalamyndari();
                    skjalm.getSkjalamyndara(strHeiti);
                    frmSkjalamyndariSkra frmSkjalm = new frmSkjalamyndariSkra(skjalm, virkurnotandi);
                    frmSkjalm.ShowDialog();
                }
                if (senderGrid.Columns["colEditVaral"].Index == e.ColumnIndex)
                {
                    string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVorslustofnun"].Value.ToString();
                    cVorslustofnun varsla = new cVorslustofnun();
                    varsla.getVörslustofnun(strAuðkenni);
                    frmVörslustofnun frmVarsla = new frmVörslustofnun(varsla, virkurnotandi);
                    frmVarsla.ShowDialog();
                }
                if (senderGrid.Columns["colEditSkrá"].Index == e.ColumnIndex)
                {
                    string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVorsluutgafu"].Value.ToString();
                    strAuðkenni = strAuðkenni.Replace("FRUM", "AVID");
                    cSkjalaskra skrá = new cSkjalaskra();
                    skrá.getSkraning(strAuðkenni);
                    frmSkráning frmSkra = new frmSkráning(skrá, virkurnotandi);
                    frmSkra.ShowDialog();
                }
                if (senderGrid.Columns["colOpna"].Index == e.ColumnIndex)
                {
                    string strSlod = senderGrid.Rows[e.RowIndex].Cells["colSlod"].Value.ToString();


                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(strSlod)
                    {
                        UseShellExecute = true
                    };
                    p.Start();

                }
            }
        }

        private void m_btnSkyrsla_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ekkert komið en bý til eitthvað sniðugt og praktískt síðar");
        }
    }
}
