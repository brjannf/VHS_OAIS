using Microsoft.Reporting.WinForms;
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

namespace OAIS_ADMIN
{
    public partial class frmKvittun : Form
    {
        private readonly ReportViewer reportViewer;
        private string m_strAuðkenni = string.Empty;
        public frmKvittun(string strAuðkenni)
        {
            InitializeComponent();
            m_strAuðkenni = strAuðkenni;
            Text = "Report viewer";
            WindowState = FormWindowState.Maximized;
            // reportViewer.ReportRefresh += reportViewer.Refresh(refhreh);
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            LocalReport localReport = reportViewer.LocalReport;
            //  localReport.ReportPath = "Report1.rdlc";
            localReport.ReportPath = "Report1.rdlc";
            reportViewer.RefreshReport();
            Controls.Add(reportViewer);
        }

        //public frmKvittun()
        //{
        //    InitializeComponent();
        //}

            private void frmLoad(object sender, EventArgs e)
        {
            cSkjalaskra varsla = new cSkjalaskra();
            DataTable dt = varsla.getKvittun(m_strAuðkenni);

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
            
            ReportDataSource reportDataSource = new ReportDataSource("dsKvittun", dtCloned);
            //reportDataSource.Nafn = "DATASET2";
            //reportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.RefreshReport();
        }

        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB" , "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }
    }
}
