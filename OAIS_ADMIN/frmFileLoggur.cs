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

namespace OAIS_ADMIN
{
    public partial class frmFileLoggur : Form
    {
        cVHS_files files = new cVHS_files();
        string m_strDrif = string.Empty;
        public frmFileLoggur()
        {
            InitializeComponent();
        }
        public frmFileLoggur(string strDrif)
        {
            InitializeComponent();
            m_strDrif = strDrif;

            fyllaAr();

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
            DataTable dt = files.getFiles(strDate, m_strDrif);
            m_dgvFiles.DataSource = formatTable(dt);
            m_lblFjoldi.Text = dt.Rows.Count + " hreyfingar skráðar";
        }
        private void m_trwDate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_trwDate.Focused)
            {
                if (e.Node.Level == 0)
                {
                    fyllaManud(e.Node.Text, e.Node);
                }
                if (e.Node.Level == 1)
                {
                    fyllaDaga(e.Node.Tag.ToString(), e.Node);
                }
                if (e.Node.Level == 2)
                {
                    fyllaFiles(e.Node.Tag.ToString());
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
    }
    }

