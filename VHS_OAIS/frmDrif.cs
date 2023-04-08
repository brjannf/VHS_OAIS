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
using cClassVHS;
using Org.BouncyCastle.Bcpg;
using ByteSizeLib;

namespace VHS_OAIS
{
    public partial class frmDrif : Form
    {
        private readonly ReportViewer reportViewer;
        public frmDrif()
        {
            InitializeComponent();
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
             
        private void frmDrif_Load(object sender, EventArgs e)
        {
            DataTable dt = cSkyrslur.sækjaFiles();
            foreach(DataRow r in dt.Rows)
            {
                long  bla = (long) Convert.ToDouble(r["laust"]);
                r["laust"] = FormatBytes(bla);
            }

            ReportDataSource reportDataSource = new ReportDataSource("DataSet2", dt);
            //reportDataSource.Nafn = "DATASET2";
            //reportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.RefreshReport();
            
        }

        private static double FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB" }; //, "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024;
            }

            return  dblSByte;
        }
    }
}
