using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using cClassOAIS;
using cClassVHS;

namespace MHR_LEIT
{
    public partial class frmUtlan : Form
    {
        cNotandi virkurnotandi = new cNotandi();    
        cDIPKarfa karfa = new cDIPKarfa();
        cVHS_drives drivus = new cVHS_drives();
        string m_strDrif = string.Empty;


        public frmUtlan()
        {
            InitializeComponent();
        }
        public frmUtlan(string strID, cNotandi not)
        {
            InitializeComponent();
          
            virkurnotandi = not;
            karfa.m_bAfrit = virkurnotandi.m_bAfrit;
            drivus.m_bAfrit = virkurnotandi.m_bAfrit;
            m_strDrif = drivus.driveVirkkComputers();
            DriveInfo drive = new DriveInfo(m_strDrif);
            m_strDrif = drive.RootDirectory + "\\DIP";
            fyllalanalista(strID);
          

        }
        private void fyllalanalista(string strID)
        {
            m_dgvLanListi.DataSource = karfa.getKorfuLanthega(strID);
        }

        private void m_dgvLanListi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ibla = e.RowIndex;
            if (e.RowIndex != -1)
            {
                DataGridView grid = (DataGridView)sender;
                string strKarfa = grid.Rows[e.RowIndex].Cells["colKarfa"].Value.ToString();

                string strSlod = string.Empty;

                string[] strDir = Directory.GetDirectories(m_strDrif);
                foreach (string str in strDir)
                {
                    string[] strSplie = str.Split("\\");
                    strSplie = strSplie[strSplie.Length - 1].Split("_");
                    string strBLA = strSplie[0];
                    if (strKarfa == strBLA)
                    {
                        strSlod = str;
                    }

                }

                // string strLanthegi = grid.Rows[e.RowIndex].Cells["colLanID"].Value.ToString();
                // cLanthegar lanthegar= new cLanthegar();
                // lanthegar.m_bAfrit = virkurnotandi.m_bAfrit;
                // lanthegar.getaLanthega(strLanthegi);

                //strSlod = m_strDrif + "\\" + strKarfa +"_" + lanthegar.nafn;

                if (strSlod != string.Empty)
                {
                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(strSlod)
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
            }
       
        }
    }
}
