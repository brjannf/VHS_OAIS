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
using Microsoft.Reporting.WinForms;

namespace MHR_LEIT
{
    public partial class frmLanthegarSkyrsla : Form
    {
        public frmLanthegarSkyrsla()
        {
            InitializeComponent();
        }
        private readonly ReportViewer reportViewer;
        public frmLanthegarSkyrsla(cNotandi virkurnotandi, DataTable dtLan)
        {
            InitializeComponent();
            cDIPKarfa karfa = new cDIPKarfa();
            karfa.m_bAfrit = virkurnotandi.m_bAfrit;
            dtLan = karfa.getKorfurDIPReportDummy();
            DataTable dt = dtLan.Clone();
          
            foreach(DataRow r in dtLan.Rows)
            {
                karfa.sækjaKörfu(r["karfa"].ToString());

                //sækja úr skráasafni
                DataTable dtSkrar = karfa.getKorfurSkrarSkjol(karfa.karfa.ToString());
                string strVorslutgafa = string.Empty;
                string strSkrar = string.Empty;
               
                foreach (DataRow rskra in dtSkrar.Rows)
                {
                    
                    if (rskra["heitiVorslu"].ToString() != strVorslutgafa)
                    {
                        DataRow row = dt.NewRow();
                        strVorslutgafa = rskra["heitiVorslu"].ToString();
                       
                        row["karfa"] = karfa.karfa;
                        row["lanthegi"] = karfa.heiti;
                        strSkrar =  karfa.getKorfurSkrarSkjol(karfa.karfa.ToString(), strVorslutgafa);
                        row["skrar"] = strSkrar;
                        row["vorsluutgafa"] = strVorslutgafa;
                        row["athugasemdir"] = karfa.athugasemdir;
                        row["dags_skrad"] = karfa.dags_skrad;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                    }
                    
                }
              
                //sækja úr málasafni
                DataTable dtMalSkrar = karfa.getKorfurMalSkjol(karfa.karfa.ToString());
                strVorslutgafa = string.Empty;
                foreach (DataRow rMal in dtMalSkrar.Rows)
                {
                   
                 
                    if (rMal["heitiVorslu"].ToString() != strVorslutgafa)
                    {
                        DataRow row = dt.NewRow();
                        strVorslutgafa = rMal["heitiVorslu"].ToString();

                        row["karfa"] = karfa.karfa;
                        row["lanthegi"] = karfa.heiti;
                        strSkrar = karfa.getKorfurMalSkjol(karfa.karfa.ToString(), strVorslutgafa);
                        row["skrar"] = strSkrar;
                        row["vorsluutgafa"] = strVorslutgafa;
                        row["athugasemdir"] = karfa.athugasemdir;
                        row["dags_skrad"] = karfa.dags_skrad;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                       
                    }
                }
                //sækja úr gagngrunni
                DataTable dtGagnSkrar = karfa.getKorfurGagnSkjol(karfa.karfa.ToString());
                strVorslutgafa = string.Empty;
                foreach (DataRow rGagn in dtGagnSkrar.Rows)
                {


                    if (rGagn["heitiVorslu"].ToString() != strVorslutgafa)
                    {
                        DataRow row = dt.NewRow();
                        strVorslutgafa = rGagn["heitiVorslu"].ToString();

                        row["karfa"] = karfa.karfa;
                        row["lanthegi"] = karfa.heiti;
                        strSkrar = karfa.getKorfurGagnSkjol(karfa.karfa.ToString(), strVorslutgafa);
                        row["skrar"] = strSkrar;
                        row["vorsluutgafa"] = strVorslutgafa;
                        row["athugasemdir"] = karfa.athugasemdir;
                        row["dags_skrad"] = karfa.dags_skrad;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();

                    }
                }
            }

            WindowState = FormWindowState.Maximized;

            // Initialize the ReportViewer
            reportViewer = new ReportViewer
            {
                Dock = DockStyle.Fill
            };

            // Set the report path
            reportViewer.LocalReport.ReportPath = "ReportLanthegi.rdlc";

            // Create a ReportDataSource
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt);

           
            // Add the data source to the report
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            // Refresh the report
            reportViewer.RefreshReport();

            // Add the ReportViewer to the form
            Controls.Add(reportViewer);
        }
    }
}
