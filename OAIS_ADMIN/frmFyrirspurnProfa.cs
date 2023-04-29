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
    public partial class frmFyrirspurnProfa : Form
    {
        string m_strDatabase = string.Empty;
        public frmFyrirspurnProfa()
        {
            InitializeComponent();
        }
        public frmFyrirspurnProfa(string strFyrirSpurn, string strDatabase)
        {
            InitializeComponent();
            this.m_strDatabase = strDatabase;
            m_tboFyrirspurn.Text = strFyrirSpurn;

        }

        private void m_btnTesta_Click(object sender, EventArgs e)
        {
            cMIdlun midlun = new cMIdlun();
            m_dgvTest.DataSource = midlun.testFyrirSpurn(m_tboFyrirspurn.Text, m_strDatabase);
        }
    }
}
