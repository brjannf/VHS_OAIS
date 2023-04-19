using cClassOAIS;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIS_ADMIN
{
    public partial class frmReportVarsla : Form
    {
       cNotandi virkurnotandi = new cNotandi();
        private readonly ReportViewer reportViewer;
        string m_strAuðkenni = string.Empty;
        cStillingar stillingar = new cStillingar();
        public frmReportVarsla()
        {
            InitializeComponent();
        }

        public frmReportVarsla(string strVarsla, cNotandi notandi)
        {
            InitializeComponent();

            stillingar.getStillingar(getComputer());

            virkurnotandi = notandi;
            m_strAuðkenni = strVarsla;
            Text = "Report viewer";
            WindowState = FormWindowState.Maximized;
            // reportViewer.ReportRefresh += reportViewer.Refresh(refhreh);
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            LocalReport localReport = reportViewer.LocalReport;
            //  localReport.ReportPath = "Report1.rdlc";
            localReport.ReportPath = "reportVarsla.rdlc";
            reportViewer.RefreshReport();
            Controls.Add(reportViewer);
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
        private void frmLoad(object sender, EventArgs e)
        {
            cVorslustofnun varsla = new cVorslustofnun();
            DataTable dt = varsla.utgafurVorslustofnunar(m_strAuðkenni);

            DataTable dtCloned = dt.Clone();
            dtCloned.Columns["staerd"].DataType = typeof(string);
            dtCloned.Columns["dags_skrad"].DataType = typeof(string);
            int iVerd = 0;
            foreach (DataRow row in dt.Rows)
            {
               
                dtCloned.ImportRow(row);
                
            }
            ///gera stærð skiljanlega
            long heild = 0;
           
            foreach (DataRow r in dtCloned.Rows)
            {
                DateTime dat = Convert.ToDateTime(r["dags_skrad"]);
                r["dags_skrad"] = dat.Day + "." + mánuðir(dat.Month.ToString()) + "." + dat.Year;
                int iMan = 0;
                if (dat.Year == DateTime.Now.Year)
                {
                    iMan = 12 - dat.Month; //má fara betur yfir
                }
                else
                {
                    iMan = 12;
                }

                long bla = (long)Convert.ToDouble(r["staerd"]);
                int iVerdVarsla = (getGigs(bla) * Convert.ToInt32(stillingar.verd)) * iMan;
                iVerd += iVerdVarsla;
                r["verd"] = iVerdVarsla + " Krónur";
                bla = (long)Convert.ToDouble(r["staerd"]);
                heild += bla;
                r["staerd"] = FormatBytes(bla);
            }
            DataRow rr= dtCloned.NewRow();
            rr["skjalm_heiti"] = "Samtals:";
            rr["verd"] = iVerd + " krónur";
            rr["staerd"] = FormatBytes(heild);
            dtCloned.Rows.Add(rr);
            dtCloned.AcceptChanges();
            ReportDataSource reportDataSource = new ReportDataSource("dtVarsla", dtCloned);
            //reportDataSource.Nafn = "DATASET2";
            //reportDataSource.Value = dt;
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.RefreshReport();
        }

        private int getGigs(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB" }; //, "TB" };
            int i;
            double dblSByte = bytes;
            bool bGig = false;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.1;
                if(i == 2)
                {
                    bGig= true;
                }
            }
            if(!bGig) 
            {
               return 1;
            }

            return Convert.ToInt32(Math.Ceiling(dblSByte)) ;
        }
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.1;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }
        private string mánuðir(string strManudur)
        {
            string strRet = string.Empty;
            switch (strManudur)
            {
                case "1":
                    strRet = "Janúar";
                    break;
                case "2":
                    strRet = "Febrúar";
                    break;
                case "3":
                    strRet = "Mars";
                    break;
                case "4":
                    strRet = "Apríl";
                    break;
                case "5":
                    strRet = "Maí";
                    break;
                case "6":
                    strRet = "Júní";
                    break;
                case "7":
                    strRet = "Júlí";
                    break;
                case "8":
                    strRet = "Ágúst";
                    break;
                case "9":
                    strRet = "September";
                    break;
                case "10":
                    strRet = "Október";
                    break;
                case "11":
                    strRet = "Nóvember";
                    break;
                case "12":
                    strRet = "Desember";
                    break;
            }

            return strRet;
        }
    }

  
}
