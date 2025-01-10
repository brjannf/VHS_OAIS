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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MHR_LEIT
{
    public partial class frmGagnagrunnSkoda : Form
    {
        cNotandi virkurnotandi = new cNotandi();
        public frmGagnagrunnSkoda(string strSQL, cNotandi notandi, string strGagnagrunnur, string strLeit, string strOrginal, string strHeitiVorslu)
        {
            InitializeComponent();
            this.Text = strHeitiVorslu;
            fyllaGogn(strSQL, strGagnagrunnur);
            m_lblLeit.Text = "Leitarskilyrði: " + strLeit;   
            m_lblOrginal.Text = "Gagnagrunnur: " + strOrginal; 
            virkurnotandi = notandi;    
        }
        private void fyllaGogn(string strSQL, string strGagnagrunnur)
        {
            cMIdlun midlun = new cMIdlun();
            midlun.m_bAfrit = virkurnotandi.m_bAfrit;

           DataTable dt =   midlun.keyraFyrirspurn(strSQL, strGagnagrunnur);
            m_grbResults.Text = string.Format("Fjöldi færsla ({0})",dt.Rows.Count);
            m_dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            m_dgvResult.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            m_dgvResult.RowTemplate.Resizable = DataGridViewTriState.True;
            m_dgvResult.RowTemplate.Height = 50;
            m_dgvResult.DataSource = dt;

        }
    }

    
}
