using cClassOAIS;
//using DocumentFormat.OpenXml.Spreadsheet;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIS_ADMIN
{
    public partial class uscGagnaUmsjon : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        cVorslustofnun vörslustofnun = new cVorslustofnun();
        cSkjalamyndari skjalamyndari = new cSkjalamyndari();
        cSkjalaskra utgafur = new cSkjalaskra();

        DataTable m_dtVorslustofnanir = new DataTable();
        DataTable m_dtSkjalamyndarar =   new DataTable();
        DataTable m_dtUtgáfur = new DataTable();

        DataTable m_dtAllt = new DataTable();   
        DataTable m_dtSumt = new DataTable();   
        public uscGagnaUmsjon()
        {
            InitializeComponent();
            fyllaVörslustofnanir();
            fyllaSkjalamyndara();
            fyllaVörsluUtgafur();

            fyllaLeitVorsluutgafu();



            cSkjalaskra skrá = new cSkjalaskra();
            m_dtAllt = skrá.getVörsluútgáfur();

        }
        
        private void fyllaLeitVörslustofnanir()
        {
            DataView view = new DataView(m_dtVorslustofnanir);
            view.Sort = "heiti";
            DataTable dtHeiti = view.ToTable(true, "heiti");
            DataRow r = dtHeiti.NewRow();
            r["heiti"] = "Veldu heiti vörslustofnunar";
            dtHeiti.Rows.InsertAt(r, 0);
            m_comLeitVarslaHeiti.ValueMember = "heiti";
            m_comLeitVarslaHeiti.DisplayMember = "heiti";
            m_comLeitVarslaHeiti.DataSource = dtHeiti;

            DataTable dtKlasar = view.ToTable(true, "klasar");
            DataRow rr = dtKlasar.NewRow();
            rr["klasar"] = "Veldu landsvæði";
            dtKlasar.Rows.InsertAt(rr, 0);
            m_comLeitVarslaKlasi.ValueMember = "klasar";
            m_comLeitVarslaKlasi.DisplayMember = "klasar";
            m_comLeitVarslaKlasi.DataSource = dtKlasar;
        }

        private void fyllaLeitVorsluutgafu()
        {
            DataView view = new DataView(m_dtUtgáfur);
            view.Sort = "utgafa_titill";
            DataTable dtTitill = view.ToTable(true, "utgafa_titill");
                   
            DataRow r = dtTitill.NewRow();
            r["utgafa_titill"] = "Veldu titil vörsluútgáfu";

            //  m_comUtgafaLeittitill.Items.Insert(0,r);
            dtTitill.Rows.InsertAt(r, 0);
            m_comUtgafaLeittitill.ValueMember = "utgafa_titill";
            m_comUtgafaLeittitill.DisplayMember = "utgafa_titill";
         
            m_comUtgafaLeittitill.DataSource = dtTitill;

            view.Sort = "afharnr";
            DataTable dtAfhAr = view.ToTable(true, "afharnr");
            DataRow rar = dtAfhAr.NewRow();
            rar["afharnr"] = "Veldu afhendingaár/númer";
            dtAfhAr.Rows.InsertAt(rar, 0);
            m_comUtgafaLeitAfhar.ValueMember = "afharnr";
            m_comUtgafaLeitAfhar.DisplayMember = "afharnr";
            m_comUtgafaLeitAfhar.DataSource = dtAfhAr;

            view.Sort = "varsla_heiti";
            DataTable dtVarsla = view.ToTable(true, "varsla_heiti");
            DataRow rav = dtVarsla.NewRow();
            rav["varsla_heiti"] = "Veldu Vörslustofnun";
            dtVarsla.Rows.InsertAt(rav, 0);
            m_comUtgafaVorsluStofnun.ValueMember = "varsla_heiti";
            m_comUtgafaVorsluStofnun.DisplayMember = "varsla_heiti";
            m_comUtgafaVorsluStofnun.DataSource = dtVarsla;

            view.Sort = "skjalm_heiti";
            DataTable dtSkjalm = view.ToTable(true, "skjalm_heiti");
            DataRow ras = dtSkjalm.NewRow();
            ras["skjalm_heiti"] = "Veldu Vörslustofnun";
            dtSkjalm.Rows.InsertAt(ras, 0);
            m_comUtgafaLeitSkjalamyndari.ValueMember = "skjalm_heiti";
            m_comUtgafaLeitSkjalamyndari.DisplayMember = "skjalm_heiti";
            m_comUtgafaLeitSkjalamyndari.DataSource = dtSkjalm;

        }

        private void fyllaVörslustofnanir()
        {
            m_dtVorslustofnanir =  vörslustofnun.getAllVorslustofnanirGU();
            m_dgvVorslustofnanir.AutoGenerateColumns = false;
            m_dgvVorslustofnanir.DataSource = m_dtVorslustofnanir;
            m_dgvVorslustofnanir.ClearSelection();
        }
        private void fyllaSkjalamyndara()
        {
            m_dtSkjalamyndarar = skjalamyndari.getSkjalamyndaralistaGU();
            m_dgvSkjalaMyndarar.AutoGenerateColumns = false;
            m_dgvSkjalaMyndarar.DataSource = m_dtSkjalamyndarar;
            m_dgvSkjalaMyndarar.ClearSelection();

        }
        public void fyllaVörsluUtgafur()
        {
            FyllaLeitSkjalamyndara();
            fyllaLeitVörslustofnanir();
            m_dtUtgáfur = utgafur.getVörsluútgáfurGU();
          
            m_dgvVorsluUtgafur.AutoGenerateColumns = false;
            m_dgvVorsluUtgafur.DataSource = formatTable(m_dtUtgáfur);
            m_dgvVorsluUtgafur.ClearSelection();
            foreach (DataGridViewRow r in m_dgvVorsluUtgafur.Rows)
            {
              
                if (r.Cells["colUtgafurMidlad"].Value.ToString() == "1")
                {
                    r.DefaultCellStyle.BackColor = Color.LightGreen; 
                    r.ReadOnly = false;
                }
                else
                {
                    r.DefaultCellStyle.BackColor = Color.LightYellow;
                    r.ReadOnly = false;
                }
                if (r.Cells["colUtgafurEytt"].Value.ToString() == "1")
                {
                    r.DefaultCellStyle.BackColor = Color.LightPink;
                    r.ReadOnly = true;
                }

            }
        }
        private void fyllaVörslustofnunOLD(string strSkjalamyndari)
        {
            if(strSkjalamyndari == string.Empty)
            {
                //id, vorsluutgafa, utgafa_titill, vorslustofnun, varsla_heiti, skjalamyndari, skjalm_heiti, staerd, slod, innihald, timabil, afharnr, MD5, hver_skradi, dags_skrad
                //string strExp = string.Format("vorslustofnun='{0}",
                m_comVörslustofnanir.DataSource = m_dtAllt;
                m_comVörslustofnanir.ValueMember = "vorslustofnun";
                m_comVörslustofnanir.DisplayMember = "varsla_heiti";
               
            }
        }

        private void FyllaLeitSkjalamyndara()
        {
            DataView view = new DataView(m_dtSkjalamyndarar);
            DataTable dt = view.ToTable(true, "heiti");
            DataRow r = dt.NewRow();
            r["heiti"] =   "Veldu skjalamyndara";
            dt.Rows.InsertAt(r, 0);
            m_comLeitSkjalamyndaraHeiti.ValueMember = "heiti";
            m_comLeitSkjalamyndaraHeiti.DisplayMember = "heiti";
            m_comLeitSkjalamyndaraHeiti.DataSource = dt;

           
            DataTable dtGerd = view.ToTable(true, "gerd");
            DataRow rr = dtGerd.NewRow();
            rr["gerd"] = "Veldu gerð";
            dtGerd.Rows.InsertAt(rr, 0);
            m_comLeitSkjalmGerd.ValueMember = "gerd";
            m_comLeitSkjalmGerd.DisplayMember = "gerd";
            m_comLeitSkjalmGerd.DataSource = dtGerd;

            DataTable dtTimabil = view.ToTable(true,"timabil");
            DataTable dtUpp = new  DataTable();
            dtUpp.Columns.Add("timabil");
            DataTable dtLok = new DataTable();
            dtLok.Columns.Add("timabil");
            foreach (DataRow rTim in dtTimabil.Rows)
            {
                if (rTim["timabil"].ToString() != string.Empty)
                {
                    string[] strSplit = rTim["timabil"].ToString().Split("-");
                    if(strSplit.Length > 0) 
                    {
                        if (strSplit.Length == 1)
                        {
                            DataRow rUpp = dtUpp.NewRow();
                            rUpp["timabil"] = strSplit[0];
                            dtUpp.Rows.Add(rUpp);
                            dtUpp.AcceptChanges();

                        }
                        if(strSplit.Length == 2)
                        {
                            DataRow rUpp = dtUpp.NewRow();
                            rUpp["timabil"] = strSplit[0];
                            dtUpp.Rows.Add(rUpp);
                            dtUpp.AcceptChanges();
                            if (strSplit[1].ToString() != string.Empty)
                            {
                                DataRow rLok = dtLok.NewRow();
                                rLok["timabil"] = strSplit[1];
                                dtLok.Rows.Add(rLok);
                                dtLok.AcceptChanges();
                            }
                            
                        }
                    }
                }
            }
            DataRow rUpp0 = dtUpp.NewRow();
            rUpp0["timabil"] = "Veldu upphafsár";
            dtUpp.Rows.InsertAt(rUpp0, 0);

            DataRow rLok0 = dtLok.NewRow();
            rLok0["timabil"] = "Veldu lokaaár";
            dtLok.Rows.InsertAt(rLok0, 0);

            dtUpp.DefaultView.Sort = "timabil desc";
            dtLok.DefaultView.Sort = "timabil desc";

            

            m_comLeitSkjalmUpp.DataSource = dtUpp;
            m_comLeitSkjalmUpp.DisplayMember = "timabil";
            m_comLeitSkjalmUpp.ValueMember = "timabil";
            m_comLeitSkjalmLok.DataSource = dtLok;
            m_comLeitSkjalmLok.DisplayMember = "timabil";
            m_comLeitSkjalmLok.ValueMember = "timabil";

        }
        
        private void fyllaSkjalamyndaraOLD(string strVörlsustofnun)
        {
            m_comSkjalamyndarar.DataSource = m_dtAllt;
            m_comSkjalamyndarar.ValueMember = "skjalamyndari";
            m_comSkjalamyndarar.DisplayMember = "skjalm_heiti";
        }

        public void endurHressa()
        {
            cSkjalaskra skrá = new cSkjalaskra();
            m_dtAllt = skrá.getVörsluútgáfur();
            m_dtSumt = m_dtAllt.Clone();
            m_dgvUtgafur.AutoGenerateColumns = false;
            m_dgvUtgafur.DataSource =formatTable(m_dtAllt);
            foreach(DataGridViewRow row in m_dgvUtgafur.Rows ) 
            {
                if (row.Cells["colEytt"].Value.ToString() == "1")
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                    row.ReadOnly= true; 
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen; ;
                    row.ReadOnly = false;
                }
            }
           
            fyllaVörslustofnunOLD("");
            fyllaSkjalamyndaraOLD("");
        }

        private void m_comVörslustofnanir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_comVörslustofnanir.Focused )
            {
                if(m_comVörslustofnanir.SelectedValue != null)
                {
                    DataTable dt = new DataTable();
                    dt = m_dtAllt.Clone(); 
                   
                    string strExpr = string.Format("vorslustofnun='{0}'", m_comVörslustofnanir.SelectedValue.ToString());
                    DataRow[] fROW = m_dtAllt.Select(strExpr);
                    foreach (DataRow r in fROW)
                    {
                        dt.ImportRow(r);
                    }
                    m_dgvUtgafur.DataSource = formatTable(dt);
                }
             
            }
         
        }

        private void m_btnHreinsa_Click(object sender, EventArgs e)
        {
            endurHressa();
        }

        private void m_comSkjalamyndarar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_comSkjalamyndarar.Focused)
            {
                if (m_comSkjalamyndarar.SelectedValue != null)
                {
                    DataTable dt = new DataTable();
                    dt = m_dtAllt.Clone();

                    string strExpr = string.Format("skjalamyndari='{0}'", m_comSkjalamyndarar.SelectedValue.ToString());
                    DataRow[] fROW = m_dtAllt.Select(strExpr);
                    foreach (DataRow r in fROW)
                    {
                        dt.ImportRow(r);
                    }
                    m_dgvUtgafur.DataSource = dt;
                }

            }

        }
        private DataTable formatTable(DataTable dt)
        {
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

        private void m_dgvAllt_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                bool bEytt = Convert.ToBoolean(Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["colEytt"].Value.ToString()));
                if (senderGrid.Columns["colEditSkjalamyndari"].Index == e.ColumnIndex)
                {
                    if(!bEytt)
                    {
                        string strHeiti = senderGrid.Rows[e.RowIndex].Cells["colSkjalamyndari"].Value.ToString();
                        cSkjalamyndari skjalm = new cSkjalamyndari();
                        skjalm.getSkjalamyndaraByAuðkenni(strHeiti);
                        frmSkjalamyndariSkra frmSkjalm = new frmSkjalamyndariSkra(skjalm, virkurnotandi);
                        frmSkjalm.ShowDialog();
                        endurHressa();
                    }
                  
                }
                if (senderGrid.Columns["colEditVaral"].Index == e.ColumnIndex)
                {
                    if (!bEytt)
                    {
                        string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVorslustofnun"].Value.ToString();
                        cVorslustofnun varsla = new cVorslustofnun();
                        varsla.getVörslustofnun(strAuðkenni);
                        frmVörslustofnun frmVarsla = new frmVörslustofnun(varsla, virkurnotandi);
                        frmVarsla.ShowDialog();
                        endurHressa();
                    }
                }
                if (senderGrid.Columns["colEditSkrá"].Index == e.ColumnIndex)
                {
                    if (!bEytt)
                    {
                        string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVorsluutgafu"].Value.ToString();
                        strAuðkenni = strAuðkenni.Replace("FRUM", "AVID");
                        cSkjalaskra skrá = new cSkjalaskra();
                        skrá.getSkraning(strAuðkenni);
                        frmSkráning frmSkra = new frmSkráning(skrá, virkurnotandi);
                        frmSkra.ShowDialog();
                        endurHressa();
                    }
                }
                if (senderGrid.Columns["colOpna"].Index == e.ColumnIndex)
                {
                    if (!bEytt)
                    {
                        string strSlod = senderGrid.Rows[e.RowIndex].Cells["colSlod"].Value.ToString();
                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(strSlod)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }

                }

                if (senderGrid.Columns["colEditKvittun"].Index == e.ColumnIndex)
                {
                    if (!bEytt)
                    {
                        string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVorsluutgafu"].Value.ToString();
                        strAuðkenni = strAuðkenni.Replace("FRUM", "AVID");
                        frmKvittun frmKvittun = new frmKvittun(strAuðkenni);
                        frmKvittun.ShowDialog();
                        endurHressa();
                    }
                }
                if (senderGrid.Columns["colRepVarsla"].Index == e.ColumnIndex)
                {
                    if (!bEytt)
                    {
                        string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVorslustofnun"].Value.ToString();
                        frmReportVarsla frmVarsla = new frmReportVarsla(strAuðkenni, virkurnotandi);
                        frmVarsla.ShowDialog();
                        endurHressa();
                    }
                }
                if (senderGrid.Columns["colRepSkjalm"].Index == e.ColumnIndex)
                {
                    if (!bEytt)
                    {
                        string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colSkjalamyndari"].Value.ToString();
                        frmReportSkjalamyndari frmRepSkjalm = new frmReportSkjalamyndari(strAuðkenni, virkurnotandi);
                        frmRepSkjalm.ShowDialog();
                        endurHressa();
                    }
                }
                if (senderGrid.Columns["colDelEyda"].Index == e.ColumnIndex)
                {
                    if (!bEytt)
                    {
                        DialogResult result = MessageBox.Show("Viltu örruglega eyða þessari vörslútgáfu?", "Eyða vörsluútgáfu", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string strSkjalamyndari = senderGrid.Rows[e.RowIndex].Cells["colSkjalmHeiti"].Value.ToString();
                            string strVörslustofnun = senderGrid.Rows[e.RowIndex].Cells["colVorslustofnun"].Value.ToString();
                            string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVorsluutgafu"].Value.ToString();
                            string strSlod = senderGrid.Rows[e.RowIndex].Cells["colSlod"].Value.ToString();
                            frmEyda eyða = new frmEyda(strAuðkenni, strSkjalamyndari, strVörslustofnun, strSlod);
                            eyða.ShowDialog();
                            endurHressa();
                        }
                    }
                }
            }
        }

        private void m_btnSkyrsla_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ekkert komið en bý til eitthvað sniðugt og praktískt síðar");
        }

        private void m_btnLeita_Click(object sender, EventArgs e)
        {
            leit();
        }

        private void leit()
        {
            MessageBox.Show("eftir að útgfæra");
        }

        private void m_btnArskyrsla_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sorrý árið er ekki búið");
        }

        private void m_dgvVorsluUtgafur_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                bool bEytt = Convert.ToBoolean(Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells["colUtgafurEytt"].Value.ToString()));
               
              
                if (senderGrid.Columns["colUtgafaFullskra"].Index == e.ColumnIndex)
                {
                    if (!bEytt)
                    {
                        string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colUtgafurAuðkenni"].Value.ToString();
                        strAuðkenni = strAuðkenni.Replace("FRUM", "AVID");
                        cSkjalaskra skrá = new cSkjalaskra();
                        skrá.getSkraning(strAuðkenni);
                        frmSkráning frmSkra = new frmSkráning(skrá, virkurnotandi);
                        frmSkra.ShowDialog();
                        endurHressa();
                    }
                }
               

                if (senderGrid.Columns["colUtgafurKvittun"].Index == e.ColumnIndex)
                {
                    if (!bEytt)
                    {
                        string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colUtgafurAuðkenni"].Value.ToString();
                        strAuðkenni = strAuðkenni.Replace("FRUM", "AVID");
                        frmKvittun frmKvittun = new frmKvittun(strAuðkenni);
                        frmKvittun.ShowDialog();
                        endurHressa();
                    }
                }
              
               
                if (senderGrid.Columns["colUtgafaEyda"].Index == e.ColumnIndex)
                {
                    if (!bEytt)
                    {
                        DialogResult result = MessageBox.Show("Viltu örruglega eyða þessari vörslútgáfu?", "Eyða vörsluútgáfu", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string strSkjalamyndari = senderGrid.Rows[e.RowIndex].Cells["colUtgafaSkjalam"].Value.ToString();
                            string strVörslustofnun = senderGrid.Rows[e.RowIndex].Cells["colUtgafaVorsluAudkenni"].Value.ToString();
                            string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colUtgafurAuðkenni"].Value.ToString();
                            string strSlod = senderGrid.Rows[e.RowIndex].Cells["colUtgafaSlod"].Value.ToString();
                            frmEyda eyða = new frmEyda(strAuðkenni, strSkjalamyndari, strVörslustofnun, strSlod);
                            eyða.ShowDialog();
                     
                        }
                    }
                }
               
                fyllaVörsluUtgafur();
                fyllaLeitVorsluutgafu();
            }
        }

        private void m_dgvVorsluUtgafur_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in m_dgvVorsluUtgafur.Rows)
            {

                if (r.Cells["colUtgafurMidlad"].Value.ToString() == "1")
                {
                    r.DefaultCellStyle.BackColor = Color.LightGreen;
                    r.ReadOnly = false;
                }
                else
                {
                    r.DefaultCellStyle.BackColor = Color.LightYellow;
                    r.ReadOnly = false;
                }
                if (r.Cells["colUtgafurEytt"].Value.ToString() == "1")
                {
                    r.DefaultCellStyle.BackColor = Color.LightPink;
                    r.ReadOnly = true;
                }

            }
        }

        private void m_dgvSkjalaMyndarar_SelectionChanged(object sender, EventArgs e)
        {
            //fá vörslustofnanir skjalamyndara
            if (m_dgvSkjalaMyndarar.SelectedRows.Count != 0)
            {
                if (m_dgvSkjalaMyndarar.Focused && m_dgvSkjalaMyndarar.SelectedRows[0].Index != -1)
                {
                    string strVarsla = m_dgvSkjalaMyndarar.Rows[m_dgvSkjalaMyndarar.SelectedRows[0].Index].Cells["colSkjalmVarsla"].Value.ToString();

                    DataTable dtVarsla = skjalamyndari.getSkjalamyndaraVörslustofnun(strVarsla);
                    m_dgvSkjalamVorslustofnun.DataSource = dtVarsla;

                    //fá vörsluútgafur skjalamyndara
                    string strSkjalam = m_dgvSkjalaMyndarar.Rows[m_dgvSkjalaMyndarar.SelectedRows[0].Index].Cells["colSkjalamAuðkenni"].Value.ToString();
                    string strExp = "skjalamyndari='" + strSkjalam + "'"; ;
                    DataRow[] fRow = m_dtUtgáfur.Select(strExp);
                    DataTable dt = m_dtUtgáfur.Clone();
                    foreach (DataRow row in fRow)
                    {
                        dt.ImportRow(row);
                    }
                    m_dgvSkjalamUtgafa.AutoGenerateColumns = false;
                    m_dgvSkjalamUtgafa.DataSource = dt;


                }
            

        }

        }

        private void m_comLeitSkjalamyndaraHeiti_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            if (com.Focused)
            {
              //  if (com.SelectedIndex != 0)
                {
                    LeitaSkjalmyndara();

                }

            }
        }

        private void m_dgvSkjalaMyndarar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colSkjalamyndSkyrsla"].Index == e.ColumnIndex)
                {
                       string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colSkjalamAuðkenni"].Value.ToString();
                        frmReportSkjalamyndari frmRepSkjalm = new frmReportSkjalamyndari(strAuðkenni, virkurnotandi);
                        frmRepSkjalm.ShowDialog();
                      
                }
                if (senderGrid.Columns["colSkjalmFullskra"].Index == e.ColumnIndex)
                {                
                    
                        string strHeiti = senderGrid.Rows[e.RowIndex].Cells["colSkjalamAuðkenni"].Value.ToString();
                        cSkjalamyndari skjalm = new cSkjalamyndari();
                        skjalm.getSkjalamyndaraByAuðkenni(strHeiti);
                        frmSkjalamyndariSkra frmSkjalm = new frmSkjalamyndariSkra(skjalm, virkurnotandi);
                        frmSkjalm.ShowDialog();


                }
                fyllaSkjalamyndara();
            }
        }

        private void m_dgvVorslustofnanir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colVaralSkyrsla"].Index == e.ColumnIndex)
                {
                    string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVarslaAudkenni"].Value.ToString();
                    frmReportVarsla frmVarsla = new frmReportVarsla(strAuðkenni, virkurnotandi);
                    frmVarsla.ShowDialog();
                   

                }
                if (senderGrid.Columns["colVarslaFullskra"].Index == e.ColumnIndex)
                {
                    string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVarslaAudkenni"].Value.ToString();
                    cVorslustofnun varsla = new cVorslustofnun();
                    varsla.getVörslustofnun(strAuðkenni);
                    frmVörslustofnun frmVarsla = new frmVörslustofnun(varsla, virkurnotandi);
                    frmVarsla.ShowDialog();
               
                }
           
                fyllaVörslustofnanir();
                fyllaLeitVörslustofnanir();
            }
        }

        private void m_dgvVorslustofnanir_SelectionChanged(object sender, EventArgs e)
        {
            if (m_dgvVorslustofnanir.SelectedRows.Count != 0)
            {
                if (m_dgvVorslustofnanir.Focused && m_dgvVorslustofnanir.SelectedRows[0].Index != -1)

                {
                    string strVarsla = m_dgvVorslustofnanir.Rows[m_dgvVorslustofnanir.SelectedRows[0].Index].Cells["colVarslaAudkenni"].Value.ToString();

                    string strExp = "vorslustofnun= '" + strVarsla + "'";
                    DataRow[] fRow = m_dtUtgáfur.Select(strExp);
                    DataTable dtClone = m_dtUtgáfur.Clone();
                    foreach (DataRow r in fRow)
                    {
                        dtClone.ImportRow(r);
                    }
                    m_dgvVarslaSkjalmyndarar.AutoGenerateColumns = false;
                    m_dgvVarslaSkjalmyndarar.DataSource = dtClone;
                    m_dgvVarslaUtgafur.AutoGenerateColumns = false;
                    m_dgvVarslaUtgafur.DataSource = dtClone;



                }
            }
        }

        private void m_tacGagnaUmsjon_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_dtUtgáfur = utgafur.getVörsluútgáfurGU();
            fyllaSkjalamyndara();
            fyllaVörslustofnanir();
        }

        private void m_btnUtgafurLeit_Click(object sender, EventArgs e)
        {
            LeitaVörsluÚgafur();
        }
        private void LeitVörslustofnanir()
        {
            string strExpession = string.Empty;
            string strHeiti = string.Empty;
            string StrKlasi = string.Empty;

            if(m_comLeitVarslaHeiti.SelectedIndex != 0)
            {
                strHeiti = m_comLeitVarslaHeiti.SelectedValue.ToString();
            }
            if(m_comLeitVarslaKlasi.SelectedIndex != 0)
            {
                StrKlasi = m_comLeitVarslaKlasi.SelectedValue.ToString();
            }
            if(strHeiti != string.Empty) 
            {
                strExpession = "heiti='" + strHeiti + "'";
            }
            if(StrKlasi != string.Empty)
            {
                if (strExpession == string.Empty)
                {
                    strExpession = "klasar='" + StrKlasi + "'";
                }
                else
                {
                    strExpession += " and Klasar='" + StrKlasi + "'";
                }
            }

            DataTable dtClone = m_dtVorslustofnanir.Clone();
            DataRow[] frow = m_dtVorslustofnanir.Select(strExpession);

            foreach(DataRow row in frow) 
            {
                dtClone.ImportRow(row);
            }
            m_dgvVorslustofnanir.DataSource = dtClone;
            m_dgvVorslustofnanir.ClearSelection();
        }
        private void LeitaSkjalmyndara()
        {
            string strExpresion = string.Empty;
            string strHeiti = string.Empty;
            string strGerð = string.Empty;
            string strUpp = string.Empty;   
            string strLok = string.Empty;   

            if(m_comLeitSkjalamyndaraHeiti.SelectedIndex != 0)
            {
                strHeiti = m_comLeitSkjalamyndaraHeiti.SelectedValue.ToString();
            }
            if(m_comLeitSkjalmGerd.SelectedIndex != 0)
            {
                strGerð = m_comLeitSkjalmGerd.SelectedValue.ToString();
            }
            if(m_comLeitSkjalmUpp.SelectedIndex != 0)
            {
                strUpp = m_comLeitSkjalmUpp.SelectedValue.ToString();
            }
            if (m_comLeitSkjalmLok.SelectedIndex != 0)
            {
                strLok = m_comLeitSkjalmLok.SelectedValue.ToString();
            }
            if (strHeiti != string.Empty)
            {
                strExpresion = "heiti='" + strHeiti + "'";
            }
            if (strGerð != string.Empty)
            {
                if (strExpresion == string.Empty)
                {
                    strExpresion = "gerd='" + strGerð + "'";
                }
                else
                {
                    strExpresion += " and gerd='" + strGerð + "'";
                }
            }


            DataTable dtClone = m_dtSkjalamyndarar.Clone();
            DataRow[] frow = m_dtSkjalamyndarar.Select(strExpresion);

            foreach (DataRow fro in frow) 
            {

                if(strUpp != string.Empty && strLok == string.Empty)
                {
                    if (fro["timabil"].ToString() != string.Empty)
                    {
                        int iUpp = Convert.ToInt32(strUpp);
                        string[] strSplit = fro["timabil"].ToString().Split("-");
                        int iGrunn = Convert.ToInt32(strSplit[0]);
                        if (iGrunn >= iUpp)
                        {
                            dtClone.ImportRow(fro);
                        }
                    }
                  
                }
                if (strUpp == string.Empty && strLok != string.Empty)
                {
                    if (fro["timabil"].ToString() != string.Empty)
                    {
                        int iLok = Convert.ToInt32(strLok);
                        string[] strSplit = fro["timabil"].ToString().Split("-");
                        if(strSplit.Length == 2)
                        {
                            if (strSplit[1] != string.Empty) 
                            {
                                int iGrunn = Convert.ToInt32(strSplit[1]);
                                if (iGrunn <= iLok)
                                {
                                    dtClone.ImportRow(fro);
                                }
                            }

                        }
                      
                    }
                }
                if (strUpp != string.Empty && strLok != string.Empty)
                {
                    if (fro["timabil"].ToString() != string.Empty)
                    {
                        int iUpp = Convert.ToInt32(strUpp);
                        int iLok = Convert.ToInt32(strLok);
                        string[] strSplit = fro["timabil"].ToString().Split("-");
                        if (strSplit.Length == 2)
                        {
                            if (strSplit[1] != string.Empty)
                            {
                                int iGrunnUpp = Convert.ToInt32(strSplit[0]);
                                int iGrunnLok = Convert.ToInt32(strSplit[1]);
                                if (iGrunnUpp >= iUpp && iGrunnLok <= iLok)
                                {
                                    dtClone.ImportRow(fro);
                                }
                            }
                        }


                    }
                }
                if (strUpp == string.Empty && strLok == string.Empty)
                {
                    dtClone.ImportRow(fro);
                }
               
            }
            m_dgvSkjalaMyndarar.DataSource = dtClone;
            m_dgvSkjalaMyndarar.ClearSelection();

        }
        private void LeitaVörsluÚgafur()
        {
            string strExpression  = string.Empty;
            string strTitill = string.Empty;
            string strAfharNr = string.Empty;   
            string strVorslustofnun = string.Empty;
            string strSkjalamyndari = string.Empty;
            string strUpphaf = string.Empty;
            string strLok = string.Empty;

            if(m_comUtgafaLeittitill.SelectedIndex != 0)
            {
                strTitill = m_comUtgafaLeittitill.SelectedValue.ToString();
            }
            if(m_comUtgafaLeitAfhar.SelectedIndex != 0)
            {
                strAfharNr = m_comUtgafaLeitAfhar.SelectedValue.ToString();
            }
            if (m_comUtgafaVorsluStofnun.SelectedIndex != 0)
            {
                strVorslustofnun = m_comUtgafaVorsluStofnun.SelectedValue.ToString();
            }
            if(m_comUtgafaLeitSkjalamyndari.SelectedIndex != 0)
            {
                strSkjalamyndari = m_comUtgafaLeitSkjalamyndari.SelectedValue.ToString();
            }
            if(m_dapUtgafaLeitUpphaf.Checked)
            {
                strUpphaf = m_dapUtgafaLeitUpphaf.Value .ToString();    
            }
            if(m_dapUtgafaLeitLoka.Checked)
            {
                strLok = m_dapUtgafaLeitLoka.Value.ToString();
            }

            if(strTitill != string.Empty)
            {
                strExpression = "utgafa_titill='" + strTitill + "'";
            }
            if(strAfharNr!= string.Empty) 
            {
                if(strExpression == string.Empty) 
                {
                    strExpression = "afharnr='" + strAfharNr + "'";
                }
                else
                {
                    strExpression += " and afharnr='" + strAfharNr + "'";
                }
            }
            if (strVorslustofnun != string.Empty)
            {
                if (strExpression == string.Empty)
                {
                    strExpression = "varsla_heiti='" + strVorslustofnun + "'";
                }
                else
                {
                    strExpression += " and varsla_heiti='" + strVorslustofnun + "'";
                }
            }
            if (strSkjalamyndari != string.Empty)
            {
                if (strExpression == string.Empty)
                {
                    strExpression = "skjalm_heiti='" + strSkjalamyndari + "'";
                }
                else
                {
                    strExpression += " and skjalm_heiti='" + strSkjalamyndari + "'";
                }
            }
          

            DataTable dtClone = m_dtUtgáfur.Clone();
            DataRow[] frow = m_dtUtgáfur.Select(strExpression);
            foreach(DataRow fr in frow) 
            {
                if (strUpphaf != string.Empty && strLok == string.Empty)
                {
                    DateTime datUpp = Convert.ToDateTime(strUpphaf);
                    string[] strSplit = fr["timabil"].ToString().Split("-");
                    DateTime datGrunn = Convert.ToDateTime(strSplit[0]);
                    if (datGrunn >= datUpp)
                    {
                        dtClone.ImportRow(fr);
                    }
                }
                if (strUpphaf == string.Empty && strLok != string.Empty)
                {
                    DateTime datLok = Convert.ToDateTime(strLok);
                    string[] strSplit = fr["timabil"].ToString().Split("-");
                    DateTime datGrunn = Convert.ToDateTime(strSplit[1]);
                    if (datGrunn <= datLok)
                    {
                        dtClone.ImportRow(fr);
                    }

                }
                if (strUpphaf != string.Empty && strLok != string.Empty)
                {
                    DateTime datLok = Convert.ToDateTime(strLok);
                    DateTime datUpp = Convert.ToDateTime(strUpphaf);
                    string[] strSplit = fr["timabil"].ToString().Split("-");
                    DateTime datGrunnUpp = Convert.ToDateTime(strSplit[0]);
                    DateTime datGrunnLok = Convert.ToDateTime(strSplit[1]);
                    if (datGrunnUpp >= datUpp && datGrunnLok <= datLok)
                    {
                        dtClone.ImportRow(fr);
                    }

                }
                if (strUpphaf == string.Empty && strLok == string.Empty)
                {
                    dtClone.ImportRow(fr);
                }

            }

            m_dgvVorsluUtgafur.DataSource =formatTable(dtClone);
            m_dgvVorsluUtgafur.ClearSelection();
            foreach (DataGridViewRow r in m_dgvVorsluUtgafur.Rows)
            {

                if (r.Cells["colUtgafurMidlad"].Value.ToString() == "1")
                {
                    r.DefaultCellStyle.BackColor = Color.LightGreen;
                    r.ReadOnly = false;
                }
                else
                {
                    r.DefaultCellStyle.BackColor = Color.LightYellow;
                    r.ReadOnly = false;
                }
                if (r.Cells["colUtgafurEytt"].Value.ToString() == "1")
                {
                    r.DefaultCellStyle.BackColor = Color.LightPink;
                    r.ReadOnly = true;
                }

            }
        }

        private void m_btnUtgafurHreinsa_Click(object sender, EventArgs e)
        {
            fyllaLeitVorsluutgafu();
         
            m_dapUtgafaLeitUpphaf.Value = DateTime.Now;
            m_dapUtgafaLeitUpphaf.Checked = false;
            m_dapUtgafaLeitLoka.Value = DateTime.Now;
            m_dapUtgafaLeitLoka.Checked = false;
           
            m_dgvVorsluUtgafur.DataSource = formatTable(m_dtUtgáfur);
            m_dgvVorsluUtgafur.ClearSelection();
            foreach (DataGridViewRow r in m_dgvVorsluUtgafur.Rows)
            {

                if (r.Cells["colUtgafurMidlad"].Value.ToString() == "1")
                {
                    r.DefaultCellStyle.BackColor = Color.LightGreen;
                    r.ReadOnly = false;
                }
                else
                {
                    r.DefaultCellStyle.BackColor = Color.LightYellow;
                    r.ReadOnly = false;
                }
                if (r.Cells["colUtgafurEytt"].Value.ToString() == "1")
                {
                    r.DefaultCellStyle.BackColor = Color.LightPink;
                    r.ReadOnly = true;
                }

            }
        }

        private void m_comUtgafaLeittitill_SelectedIndexChanged(object sender, EventArgs e)
        {
         
           ComboBox com = (ComboBox)sender;
            if(com.Focused)
            {
              //  if (com.SelectedIndex != 0)
                {
                     LeitaVörsluÚgafur();
                   
                }
                //else
                //{
                //    m_dgvVorsluUtgafur.DataSource = m_dtUtgáfur;
                //    foreach (DataGridViewRow r in m_dgvVorsluUtgafur.Rows)
                //    {

                //        if (r.Cells["colUtgafurMidlad"].Value.ToString() == "1")
                //        {
                //            r.DefaultCellStyle.BackColor = Color.LightGreen;
                //            r.ReadOnly = false;
                //        }
                //        else
                //        {
                //            r.DefaultCellStyle.BackColor = Color.LightYellow;
                //            r.ReadOnly = false;
                //        }
                //        if (r.Cells["colUtgafurEytt"].Value.ToString() == "1")
                //        {
                //            r.DefaultCellStyle.BackColor = Color.LightPink;
                //            r.ReadOnly = true;
                //        }

                //    }
                //}
            }
            
         
        }

        private void m_btnLeitSkjalam_Click(object sender, EventArgs e)
        {
            LeitaSkjalmyndara();
        }

        private void m_btnLeitSkjalmHreinsa_Click(object sender, EventArgs e)
        {
            FyllaLeitSkjalamyndara();
            LeitaSkjalmyndara();
        }

        private void m_btnLeitVarsla_Click(object sender, EventArgs e)
        {
            LeitaVörsluÚgafur();
        }

        private void m_comLeitVarslaHeiti_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox com = (ComboBox)sender;
            if (com.Focused)
            {
             //   if (com.SelectedIndex != 0)
                {
                    LeitVörslustofnanir();

                }

            }
        }

        private void m_btnLeitVarslaHreinsa_Click(object sender, EventArgs e)
        {
            fyllaLeitVörslustofnanir();
            LeitVörslustofnanir();
        }
    }
}
