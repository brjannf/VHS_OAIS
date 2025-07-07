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

namespace MHR_LEIT
{
    public partial class frmFylgiskjol : Form
    {
        private string m_strSlod = string.Empty;    
        public frmFylgiskjol(string strSlod)
        {
            InitializeComponent();
            m_strSlod = strSlod;
            DataSet ds = new DataSet();
            ds.ReadXml(strSlod + "\\Indices\\contextDocumentationIndex.xml");
        
            m_dgvFylgiskjol.DataSource = ds.Tables[0];
        }

        private void m_dgvFylgiskjol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var p = new Process();
                string strID = m_dgvFylgiskjol.Rows[e.RowIndex].Cells["colID"].Value.ToString();   
                string strSlod =m_strSlod + "\\ContextDocumentation\\docCollection1\\" + strID + "\\1.tif";
                p.StartInfo = new ProcessStartInfo(strSlod)
                {
                    UseShellExecute = true
                };
                p.Start();
            }
        }
    }
}
