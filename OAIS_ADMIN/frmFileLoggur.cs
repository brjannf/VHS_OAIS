using System;
using cClassVHS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using Org.BouncyCastle.Cms;

namespace OAIS_ADMIN
{
    public partial class frmFileLoggur : Form
    {
        cVHS_files files = new cVHS_files();
        string m_strDrif = string.Empty;
        DataTable m_dtFiles = new DataTable();
        public frmFileLoggur()
        {
            InitializeComponent();
        }
        public frmFileLoggur(string strDrif)
        {
            InitializeComponent();
            m_strDrif = strDrif;

            fyllaAr();
            this.WindowState = FormWindowState.Maximized;

        }

        private void fyllaAr()
        {
            DataTable dt = files.getAR(m_strDrif);
            foreach (DataRow r in dt.Rows)
            {
                TreeNode n = new TreeNode(r["ar"].ToString());
                m_trwDate.Nodes.Add(n);
                n.Expand();
            }
        }
        private void fyllaManud(string strAr, TreeNode n)
        {
            DataTable dt = files.getManud(m_strDrif, strAr);
            n.Nodes.Clear();
            foreach (DataRow r in dt.Rows)
            {

                TreeNode nn = new TreeNode(mánuðir(r["manudur"].ToString()));
                nn.Tag = r["manudur"];
                n.Nodes.Add(nn);
                n.Expand();
            }
        }
        private void fyllaDaga(string strManudur, TreeNode n)
        {
            DataTable dt = files.getDaga(m_strDrif, n.Parent.Text, n.Tag.ToString());
            n.Nodes.Clear();
            foreach (DataRow r in dt.Rows)
            {
                DateTime dat = Convert.ToDateTime(r["dags"]);
                TreeNode nn = new TreeNode(dat.DayOfWeek + " " + r["dagur"].ToString());
                nn.Tag = r["dags"];

                n.Nodes.Add(nn);
                n.Expand();
            }
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
        private void fyllaFiles(string strDate)
        {
            m_dtFiles = files.getFiles(strDate, m_strDrif);
            m_dgvFiles.DataSource = formatTable(m_dtFiles);
            m_grbSkrar.Text = string.Format("{0}  hreyfingar skráðar", m_dtFiles.Rows.Count); // t + " hreyfingar skráðar";

            //aðegerðir
            DataView view = new DataView(m_dtFiles);
            DataTable dtAdgerd = view.ToTable(true, "adgerd");
            DataRow r = dtAdgerd.NewRow();
            r["adgerd"] = "Veldu aðgerð";
            dtAdgerd.Rows.InsertAt(r, 0);
            m_comAdgerd.DisplayMember = "adgerd";
            m_comAdgerd.ValueMember = "adgerd";
            m_comAdgerd.DataSource = dtAdgerd;

            DataTable dtTimi = new DataTable();
            dtTimi.Columns.Add("klukkan");

            string strTil = string.Empty;
            foreach(DataRow row in m_dtFiles.Rows)
            {
                string[] strSplit = row["DATE"].ToString().Split(" ");
                strSplit = strSplit[1].Split(":");
                if(strTil != strSplit[0])
                {
                    DataRow rK = dtTimi.NewRow();
                    rK["klukkan"] = strSplit[0] + ":00";    
                    dtTimi.Rows.Add(rK);
                    dtTimi.AcceptChanges();
                    strTil = strSplit[0];   
                }

            }
            DataRow rkk =dtTimi.NewRow();
            rkk["klukkan"] = "Veldu tíma dags";
            dtTimi.Rows.InsertAt(rkk, 0);
            m_comKlukkan.DisplayMember = "klukkan";
            m_comKlukkan.ValueMember = "klukkan";
            m_comKlukkan.DataSource = dtTimi;
        }
        private void m_trwDate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_trwDate.Focused)
            {
                if (e.Node.Level == 0)
                {
                    fyllaManud(e.Node.Text, e.Node);
                    m_grbLeita.Visible = false;
                }
                if (e.Node.Level == 1)
                {
                    fyllaDaga(e.Node.Tag.ToString(), e.Node);
                    m_grbLeita.Visible = false;
                }
                if (e.Node.Level == 2)
                {
                    fyllaFiles(e.Node.Tag.ToString());
                    m_grbLeita.Visible = true;
                    m_grbLeita.Text = string.Format("Leita í skrám frá {0}", e.Node.Tag.ToString());
                }

            }

        }

        private DataTable formatTable(DataTable dt)
        {
            DataTable dtCloned = dt.Clone();
            dtCloned.Columns["laust"].DataType = typeof(string);
            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);


            }
            foreach (DataRow r in dtCloned.Rows)
            {
                long staerd = (long)Convert.ToDouble(r["laust"]);
                r["laust"] = FormatBytes(staerd);
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
                dblSByte = bytes / 1024.1;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        private void m_btnLeita_Click(object sender, EventArgs e)
        {
            leita();
        }
        private void leita()
        {
            string strExpression = string.Empty;
            DataTable dtClone = m_dtFiles.Clone();
            m_dtFiles.Columns["DATE"].DataType = typeof(string);
            if(m_tboLeitarOrd.Text != string.Empty)
            {
                strExpression += "slod like '%" + m_tboLeitarOrd.Text + "%'";
            }
            if(m_comAdgerd.SelectedIndex!= 0)
            {
                if(strExpression == string.Empty)
                {
                    strExpression += "adgerd ='" + m_comAdgerd.SelectedValue + "'";
                }
                else
                {
                    strExpression += " and adgerd ='" + m_comAdgerd.SelectedValue + "'";
                }
            }
           if(m_comKlukkan.SelectedIndex!= 0) 
            {
                if(strExpression == string.Empty) 
                {
                    strExpression = "DATE like '%" + m_comKlukkan.SelectedValue.ToString().Replace(":00", "") + ":%'";

                }
                else
                {
                    strExpression += " and DATE like '%" + m_comKlukkan.SelectedValue.ToString().Replace(":00", "") + ":%'";
                }
            }

            DataRow[] fRow = m_dtFiles.Select(strExpression);
            foreach(DataRow fr in fRow)
            {
                dtClone.ImportRow(fr);
            }
            m_dgvFiles.DataSource = dtClone;
            m_grbSkrar.Text = string.Format("{0} hreyfingar skráðar", dtClone.Rows.Count);
        }

        private void m_tboLeitarOrd_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Enter) 
            {
                leita();
            }
        }

        private void m_comAdgerd_SelectedIndexChanged(object sender, EventArgs e)
        {
           ComboBox com = (ComboBox)sender;
            if(com.Focused && com.SelectedIndex != -1) 
            {
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                leita();
            }
        }

        private void m_btnHreinsa_Click(object sender, EventArgs e)
        {
            m_tboLeitarOrd.Text = string.Empty;
            m_comAdgerd.SelectedIndex = 0;
            m_comKlukkan.SelectedIndex = 0;
            m_dgvFiles.DataSource = m_dtFiles;
        }
    }
    }

