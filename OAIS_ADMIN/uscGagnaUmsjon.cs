using cClassOAIS;
using DocumentFormat.OpenXml.Bibliography;
//using DocumentFormat.OpenXml.Spreadsheet;
//using DocumentFormat.OpenXml.Spreadsheet;
//using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OAIS_ADMIN
{
    public partial class uscGagnaUmsjon : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        cVorslustofnun vörslustofnun = new cVorslustofnun();
        cSkjalamyndari skjalamyndari = new cSkjalamyndari();
        cSkjalaskra utgafur = new cSkjalaskra();

        DataTable m_dtVorslustofnanir = new DataTable();
        DataTable m_dtSkjalamyndarar = new DataTable();
        DataTable m_dtUtgáfur = new DataTable();

        DataTable m_dtAllt = new DataTable();
        DataTable m_dtSumt = new DataTable();

        string m_strRoot = string.Empty;
        DataTable m_dtSkjalamArchive = new DataTable();

        private DataTable m_dtStyring_tafla1 = new DataTable();
        private DataTable m_dtVirkni_tafla2 = new DataTable();
        private DataTable m_dtAfhending_tafla3 = new DataTable();
        private DataTable m_dtVidtaka_tafla4 = new DataTable();
        private DataTable m_dtVardVeisla_tafla5 = new DataTable();
        private DataTable m_dtAnnad_tafla6 = new DataTable();
        private DataSet m_dsAllt = new DataSet();

        DataTable m_dtDoc = new DataTable();
        DataTable m_dtFile = new DataTable();

        public uscGagnaUmsjon()
        {
            InitializeComponent();
            fyllaVörslustofnanir();
            fyllaSkjalamyndara();
            fyllaVörsluUtgafur();
            FyllaVOrsluUtgafurArchiveIndex();
            fyllaLeitVorsluutgafu();
            FyllaVOrsluUtgafurDocIndex();



            cSkjalaskra skrá = new cSkjalaskra();
            m_dtAllt = skrá.getVörsluútgáfur();


            m_dtSkjalamArchive.Columns.Add("skjalamyndari");
            m_dtSkjalamArchive.Columns.Add("dags_fyrst");
            m_dtSkjalamArchive.Columns.Add("dags_sidast");

            //m_dtStyring_tafla1
            m_dtStyring_tafla1.Columns.Add("skjal");
            m_dtStyring_tafla1.Columns.Add("slod");
            m_dtStyring_tafla1.Columns.Add("tegund");
            m_dtStyring_tafla1.Columns.Add("tag");
            m_dtStyring_tafla1.Columns.Add("opna");
            m_dtStyring_tafla1.Columns.Add("lysing");
            m_dtStyring_tafla1.Columns.Add("hofundur");
            m_dtStyring_tafla1.Columns.Add("stofnun");
            m_dtStyring_tafla1.Columns.Add("skrad");
            m_dtStyring_tafla1.Columns.Add("nr");
            m_dtStyring_tafla1.Columns.Add("tafla");
            m_dtStyring_tafla1.TableName = "tafla1";
            m_dsAllt.Tables.Add(m_dtStyring_tafla1);

            m_dtVirkni_tafla2 = m_dtStyring_tafla1.Clone();
            m_dtVirkni_tafla2.TableName = "tafla2";
            m_dsAllt.Tables.Add(m_dtVirkni_tafla2);

            m_dtAfhending_tafla3 = m_dtStyring_tafla1.Clone();
            m_dtAfhending_tafla3.TableName = "tafla3";
            m_dsAllt.Tables.Add(m_dtAfhending_tafla3);

            m_dtVidtaka_tafla4 = m_dtStyring_tafla1.Clone();
            m_dtVidtaka_tafla4.TableName = "tafla4";
            m_dsAllt.Tables.Add(m_dtVidtaka_tafla4);

            m_dtVardVeisla_tafla5 = m_dtStyring_tafla1.Clone();
            m_dtVardVeisla_tafla5.TableName = "tafla5";
            m_dsAllt.Tables.Add(m_dtVardVeisla_tafla5);

            m_dtAnnad_tafla6 = m_dtStyring_tafla1.Clone();
            m_dtAnnad_tafla6.TableName = "tafla6";

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
            m_dtVorslustofnanir = vörslustofnun.getAllVorslustofnanirGU();
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
        private void FyllaVOrsluUtgafurArchiveIndex()
        {
            m_dgvArchiveUtgafur.AutoGenerateColumns = false;
            m_dgvArchiveUtgafur.DataSource = m_dtUtgáfur;
            m_dgvContextUtgafur.AutoGenerateColumns = false;
            m_dgvContextUtgafur.DataSource = m_dtUtgáfur;

        }
        private void FyllaVOrsluUtgafurDocIndex()
        {
            m_dgvDocUtgafur.AutoGenerateColumns = false;
            m_dgvDocUtgafur.DataSource = m_dtUtgáfur;
            m_dgvDocUtgafur.AutoGenerateColumns = false;
            m_dgvDocUtgafur.DataSource = m_dtUtgáfur;

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

        private void FyllaLeitSkjalamyndara()
        {
            DataView view = new DataView(m_dtSkjalamyndarar);
            DataTable dt = view.ToTable(true, "heiti");
            DataRow r = dt.NewRow();
            r["heiti"] = "Veldu skjalamyndara";
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

            DataTable dtTimabil = view.ToTable(true, "timabil");
            DataTable dtUpp = new DataTable();
            dtUpp.Columns.Add("timabil");
            DataTable dtLok = new DataTable();
            dtLok.Columns.Add("timabil");
            foreach (DataRow rTim in dtTimabil.Rows)
            {
                if (rTim["timabil"].ToString() != string.Empty)
                {
                    string[] strSplit = rTim["timabil"].ToString().Split("-");
                    if (strSplit.Length > 0)
                    {
                        if (strSplit.Length == 1)
                        {
                            DataRow rUpp = dtUpp.NewRow();
                            rUpp["timabil"] = strSplit[0];
                            dtUpp.Rows.Add(rUpp);
                            dtUpp.AcceptChanges();

                        }
                        if (strSplit.Length == 2)
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

                LeitaVörsluÚgafur();
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
                FyllaLeitSkjalamyndara();
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

            if (m_comLeitVarslaHeiti.SelectedIndex != 0)
            {
                strHeiti = m_comLeitVarslaHeiti.SelectedValue.ToString();
            }
            if (m_comLeitVarslaKlasi.SelectedIndex != 0)
            {
                StrKlasi = m_comLeitVarslaKlasi.SelectedValue.ToString();
            }
            if (strHeiti != string.Empty)
            {
                strExpession = "heiti='" + strHeiti + "'";
            }
            if (StrKlasi != string.Empty)
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

            foreach (DataRow row in frow)
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

            if (m_comLeitSkjalamyndaraHeiti.SelectedIndex != 0)
            {
                strHeiti = m_comLeitSkjalamyndaraHeiti.SelectedValue.ToString();
            }
            if (m_comLeitSkjalmGerd.SelectedIndex != 0)
            {
                strGerð = m_comLeitSkjalmGerd.SelectedValue.ToString();
            }
            if (m_comLeitSkjalmUpp.SelectedIndex != 0)
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

                if (strUpp != string.Empty && strLok == string.Empty)
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
                        if (strSplit.Length == 2)
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
            string strExpression = string.Empty;
            string strTitill = string.Empty;
            string strAfharNr = string.Empty;
            string strVorslustofnun = string.Empty;
            string strSkjalamyndari = string.Empty;
            string strUpphaf = string.Empty;
            string strLok = string.Empty;

            if (m_comUtgafaLeittitill.SelectedIndex != 0)
            {
                strTitill = m_comUtgafaLeittitill.SelectedValue.ToString();
            }
            if (m_comUtgafaLeitAfhar.SelectedIndex != 0)
            {
                strAfharNr = m_comUtgafaLeitAfhar.SelectedValue.ToString();
            }
            if (m_comUtgafaVorsluStofnun.SelectedIndex != 0)
            {
                strVorslustofnun = m_comUtgafaVorsluStofnun.SelectedValue.ToString();
            }
            if (m_comUtgafaLeitSkjalamyndari.SelectedIndex != 0)
            {
                strSkjalamyndari = m_comUtgafaLeitSkjalamyndari.SelectedValue.ToString();
            }
            if (m_dapUtgafaLeitUpphaf.Checked)
            {
                strUpphaf = m_dapUtgafaLeitUpphaf.Value.ToString();
            }
            if (m_dapUtgafaLeitLoka.Checked)
            {
                strLok = m_dapUtgafaLeitLoka.Value.ToString();
            }

            if (strTitill != string.Empty)
            {
                strExpression = "utgafa_titill='" + strTitill + "'";
            }
            if (strAfharNr != string.Empty)
            {
                if (strExpression == string.Empty)
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
            foreach (DataRow fr in frow)
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

            m_dgvVorsluUtgafur.DataSource = formatTable(dtClone);
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
            if (com.Focused)
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

        private void m_dgvArchiveUtgafur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                if (senderGrid.Rows[e.RowIndex].Cells["colArchiveOpnaIndex"].ColumnIndex == e.ColumnIndex)
                {
                    m_strRoot = senderGrid.Rows[e.RowIndex].Cells["colArchiveSlod"].Value.ToString();
                    string strSlod = m_strRoot + "\\Indices\\archiveIndex.xml";

                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(strSlod)
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
                if (senderGrid.Rows[e.RowIndex].Cells["colArchiveOpnaVorslu"].ColumnIndex == e.ColumnIndex)
                {
                    m_strRoot = senderGrid.Rows[e.RowIndex].Cells["colArchiveSlod"].Value.ToString();
                    string strSlod = m_strRoot;

                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(strSlod)
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
            }
        }

        public void fyllaArchiveIndex()
        {
            try
            {
                //DataSet ds = new DataSet();
                //ds.ReadXml(m_strRoot + "\\Indices\\archiveIndex.xml");
                //DataColumnCollection columns = ds.Tables[0].Columns;
                bool bTrueFalse = false;
                DateTime dat = new DateTime();
                dat = DateTime.Now;

                XmlDocument doc = new XmlDocument();
                string strSlod = m_strRoot + "\\Indices\\archiveIndex.xml";
                doc.Load(m_strRoot + "\\Indices\\archiveIndex.xml");

                //m_tboVorsluUtgafuNumer_1.Text = doc.SelectSingleNode("/archiveIndex/archiveInformationPackageID").InnerText; 

                // m_tboVorsluUtgafuNumer_1.Text = doc.SelectSingleNode("/archiveIndex/archiveInformationPackageID").InnerText;
                //1. archiveInformationPackageID
                if (doc.SelectSingleNode("//*[local-name()='archiveInformationPackageID']") != null)
                {
                    m_tboVorsluUtgafuNumer_1.Text = doc.SelectSingleNode("//*[local-name()='archiveInformationPackageID']").InnerText;
                    //  m_comSkjalaMyndarar_8.Text = ds.Tables[0].Rows[0]["archiveInformationPackageID"].ToString();
                }
                else
                {
                    m_tboVorsluUtgafuNumer_1.Text = string.Empty;
                }
                //2. archiveInformationPackageIDPrevious
                if (doc.SelectSingleNode("//*[local-name()='archiveInformationPackageIDPrevious']") != null)
                {
                    m_tboVorsluNumerFyrra_2.Text = doc.SelectSingleNode("//*[local-name()='archiveInformationPackageIDPrevious']").InnerText;
                    // m_tboVorsluNumerFyrra_2.Text = ds.Tables[0].Rows[0]["archiveInformationPackageIDPrevious"].ToString();
                }
                else
                {
                    m_tboVorsluNumerFyrra_2.Text = string.Empty;
                }
                //3. archivePeriodStart
                if (doc.SelectSingleNode("//*[local-name()='archivePeriodStart']") != null)
                {
                    m_dtpUppafsDagsetningGogn_6.Value = Convert.ToDateTime(doc.SelectSingleNode("//*[local-name()='archivePeriodStart']").InnerText);
                    //  m_dtpUppafsDagsetning_3.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["archivePeriodStart"].ToString());
                }
                else
                {

                    m_dtpUppafsDagsetningGogn_6.Value = dat;
                }
                //4. archivePeriodEnd
                if (doc.SelectSingleNode("//*[local-name()='archivePeriodEnd']") != null)
                {
                    m_dtpLokaDagsetningGogn_7.Value = Convert.ToDateTime(doc.SelectSingleNode("//*[local-name()='archivePeriodEnd']").InnerText.ToString());
                }
                else
                {

                    m_dtpLokaDagsetningGogn_7.Value = dat;
                }
                //5. archiveInformationPacketType
                if (doc.SelectSingleNode("//*[local-name()='archiveInformationPacketType']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='archiveInformationPacketType']").InnerText.ToString());
                    if (bTrueFalse)
                    {
                        m_rdbLokaAfhendingJA_5.Checked = true;
                    }
                    else
                    {
                        m_rdbLokaAfhendingNei_5.Checked = true;
                    }
                }

                //5. archiveType
                if (doc.SelectSingleNode("//*[local-name()='archiveType']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='archiveType']").InnerText.ToString());
                    if (bTrueFalse)
                    {
                        m_rdbSkjalTimLokidJa.Checked = true;
                    }
                    else
                    {
                        m_rdbSkjalTimLokidNei.Checked = true;
                    }
                }

                m_dtSkjalamArchive.Rows.Clear();

                XmlNodeList list = doc.SelectNodes("//*[local-name()='creatorName']");
                XmlNodeList listStart = doc.SelectNodes("//*[local-name()='creationPeriodStart']");
                XmlNodeList listEnd = doc.SelectNodes("//*[local-name()='creationPeriodEnd']");
                int i = 0;
                foreach (XmlNode n in list)
                {
                    DataRow r = m_dtSkjalamArchive.NewRow();
                    r["skjalamyndari"] = n.InnerText;
                    r["dags_fyrst"] = listStart[i].InnerText;
                    r["dags_sidast"] = listEnd[i].InnerText;
                    m_dtSkjalamArchive.Rows.Add(r);
                    m_dtSkjalamArchive.AcceptChanges();
                    i++;
                }
                m_dgvSkjalmArchive.DataSource = m_dtSkjalamArchive;

                //6. creationPeriodStart
                //if (doc.SelectSingleNode("//*[local-name()='creationPeriodStart']") != null)
                //{
                //    m_dtpUppafsDagsetning_3.Value = Convert.ToDateTime(doc.SelectSingleNode("//*[local-name()='creationPeriodStart']").InnerText.ToString());
                //}
                //else
                //{

                //    m_dtpUppafsDagsetning_3.Value = dat;
                //}

                ////7. creationPeriodEnd
                //if (doc.SelectSingleNode("//*[local-name()='creationPeriodEnd']").InnerText != null)
                //{
                //    m_dtpLokaDagsetning_4.Value = Convert.ToDateTime(doc.SelectSingleNode("//*[local-name()='creationPeriodEnd']").InnerText.ToString());
                //}
                //else
                //{

                //    m_dtpLokaDagsetning_4.Value = dat;
                //}


                ////8. creatorName
                //if (doc.SelectSingleNode("//*[local-name()='creatorName']") != null)
                //{
                //    //Þarf að hugsa út í ef ekkert creatorID er
                //    if (doc.SelectSingleNode("//*[local-name()='creatorID']") != null)
                //    {
                //       m_comSkjalaMyndarar_8.SelectedValue = doc.SelectSingleNode("//*[local-name()='creatorID']").InnerText;
                //    }
                //    else
                //    {
                //      m_comSkjalaMyndarar_8.Text = doc.SelectSingleNode("//*[local-name()='creatorName']").InnerText;
                //    }

                //}

                //9. systemName
                if (doc.SelectSingleNode("//*[local-name()='systemName']") != null)
                {
                    //Þarf að hugsa út í ef ekkert creatorID er
                    m_tboKerfisHeiti_9.Text = doc.SelectSingleNode("//*[local-name()='systemName']").InnerText;
                }
                else
                {
                    m_tboKerfisHeiti_9.Text = string.Empty;
                }

                //10. alternativeName
                if (doc.SelectSingleNode("//*[local-name()='alternativeName']") != null)
                {
                    //Þarf að hugsa út í ef ekkert creatorID er
                    m_tboKerfiAnnadHeiti_10.Text = doc.SelectSingleNode("//*[local-name()='alternativeName']").InnerText;
                }
                else
                {
                    m_tboKerfiAnnadHeiti_10.Text = string.Empty;
                }

                //11. systemPurpose
                if (doc.SelectSingleNode("//*[local-name()='systemPurpose']") != null)
                {
                    //Þarf að hugsa út í ef ekkert creatorID er
                    m_tboKerfiTilgangur_11.Text = doc.SelectSingleNode("//*[local-name()='systemPurpose']").InnerText;
                }
                else
                {
                    m_tboKerfiTilgangur_11.Text = string.Empty;
                }

                //12. systemContent
                if (doc.SelectSingleNode("//*[local-name()='systemContent']") != null)
                {
                    //Þarf að hugsa út í ef ekkert creatorID er
                    m_tboKerfiInnihald_12.Text = doc.SelectSingleNode("//*[local-name()='systemContent']").InnerText;
                }
                else
                {
                    m_tboKerfiInnihald_12.Text = string.Empty;

                }

                //13. regionNum
                if (doc.SelectSingleNode("//*[local-name()='regionNum']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='regionNum']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbSvaedisNumerJa_13.Checked = true;
                    }
                    else
                    {
                        m_rdbSvaedisNumerNei_13.Checked = true;
                    }
                }
                //14. regionNum
                if (doc.SelectSingleNode("//*[local-name()='regionNum']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='regionNum']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbSveitarFelagJa_14.Checked = true;
                    }
                    else
                    {
                        m_rdbSveitarFelagNei_14.Checked = true;
                    }
                }
                //15. cprNum
                if (doc.SelectSingleNode("//*[local-name()='cprNum']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='cprNum']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbKennitalaJa_15.Checked = true;
                    }
                    else
                    {
                        m_rdbKennitalaNei_15.Checked = true;
                    }
                }
                //16. cvrNum
                if (doc.SelectSingleNode("//*[local-name()='cvrNum']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='cvrNum']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbKennitalaFyrirTaekisJa_16.Checked = true;
                    }
                    else
                    {
                        m_rdbKennitalaFyrirTaekisJNei_16.Checked = true;
                    }
                }
                //17. matrikNum
                if (doc.SelectSingleNode("//*[local-name()='matrikNum']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='matrikNum']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbLandsNumerJa_17.Checked = true;
                    }
                    else
                    {
                        m_rdbLandsNumerNei_17.Checked = true;
                    }
                }
                //18. matrikNum
                if (doc.SelectSingleNode("//*[local-name()='bbrNum']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='bbrNum']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbFastaNumerJa_18.Checked = true;
                    }
                    else
                    {
                        m_rdbFastaNumerNei_18.Checked = true;
                    }
                }
                //19. whoSygKod
                if (doc.SelectSingleNode("//*[local-name()='whoSygKod']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='whoSygKod']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbSjukKodarJa_19.Checked = true;
                    }
                    else
                    {
                        m_rdbSjukKodarNei_19.Checked = true;
                    }
                }
                //20. sourceName
                if (doc.SelectSingleNode("//*[local-name()='sourceName']") != null)
                {
                    //Þarf að hugsa út í ef ekkert creatorID er
                    m_tboGagnaLind_20.Text = doc.SelectSingleNode("//*[local-name()='sourceName']").InnerText;
                }
                else
                {
                    m_tboGagnaLind_20.Text = string.Empty;

                }
                //21. userName
                if (doc.SelectSingleNode("//*[local-name()='userName']") != null)
                {
                    //Þarf að hugsa út í ef ekkert creatorID er
                    m_tboGagnaNotandi_21.Text = doc.SelectSingleNode("//*[local-name()='userName']").InnerText;
                }
                else
                {
                    m_tboGagnaNotandi_21.Text = string.Empty;

                }
                //22. predecessorName
                if (doc.SelectSingleNode("//*[local-name()='predecessorName']") != null)
                {
                    //Þarf að hugsa út í ef ekkert creatorID er
                    m_tboFyrriKerfisHeiti_22.Text = doc.SelectSingleNode("//*[local-name()='predecessorName']").InnerText;
                }
                else
                {
                    m_tboFyrriKerfisHeiti_22.Text = string.Empty;

                }
                //23. containsDigitalDocuments
                if (doc.SelectSingleNode("//*[local-name()='containsDigitalDocuments']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='containsDigitalDocuments']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbStafreanSkjolJa_23.Checked = true;
                    }
                    else
                    {
                        m_rdbStafreanSkjolNei_23.Checked = true;
                    }
                }
                //24. searchRelatedOtherRecords
                if (doc.SelectSingleNode("//*[local-name()='searchRelatedOtherRecords']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='searchRelatedOtherRecords']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbLeitarAdferdJa_24.Checked = true;
                    }
                    else
                    {
                        m_rdbLeitarAdferdNei_24.Checked = true;
                    }
                }


                //25. relatedRecordsName
                if (doc.SelectSingleNode("//*[local-name()='relatedRecordsName']") != null)
                {
                    //Þarf að hugsa út í ef ekkert creatorID er
                    if (doc.SelectSingleNode("//*[local-name()='relatedRecordsName']").InnerText != string.Empty)
                    {
                        m_tboTengdSkjalaSafns_25.Text = doc.SelectSingleNode("//*[local-name()='relatedRecordsName']").InnerText;
                    }
                    else
                    {
                        m_tboTengdSkjalaSafns_25.Text = string.Empty;

                    }

                }
                else
                {
                    m_tboTengdSkjalaSafns_25.Text = string.Empty;

                }
                //26. systemFileConcept
                if (doc.SelectSingleNode("//*[local-name()='systemFileConcept']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='systemFileConcept']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbTilvistMalaSkraJa_26.Checked = true;
                    }
                    else
                    {
                        m_rdbTilvistMalaSkraNei_26.Checked = true;
                    }
                }

                //27. multipleDataCollection
                if (doc.SelectSingleNode("//*[local-name()='multipleDataCollection']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='multipleDataCollection']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbSOAJa_27.Checked = true;
                    }
                    else
                    {
                        m_rdbSOANei_27.Checked = true;
                    }
                }
                //28.otherAccessTypeRestrictions
                if (doc.SelectSingleNode("//*[local-name()='otherAccessTypeRestrictions']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='otherAccessTypeRestrictions']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbLokudGognJa_29.Checked = true;
                    }
                    else
                    {
                        m_rdbLokudGognJNei_29.Checked = true;
                    }
                }
                //29.personalDataRestrictedInfo
                if (doc.SelectSingleNode("//*[local-name()='personalDataRestrictedInfo']") != null)
                {
                    bTrueFalse = Convert.ToBoolean(doc.SelectSingleNode("//*[local-name()='personalDataRestrictedInfo']").InnerText);
                    if (bTrueFalse)
                    {
                        m_rdbPersonuGognJa_28.Checked = true;
                    }
                    else
                    {
                        m_rdbPersonuGognNei_28.Checked = true;
                    }
                }
                //30.archiveApproval
                if (doc.SelectSingleNode("//*[local-name()='archiveApproval']") != null)
                {

                    if (doc.SelectSingleNode("//*[local-name()='archiveApproval']").InnerText != string.Empty)
                    {
                        m_tboVidtokuSkjalasafn_30.Text = doc.SelectSingleNode("//*[local-name()='archiveApproval']").InnerText;
                    }
                    else
                    {
                        m_tboVidtokuSkjalasafn_30.Text = string.Empty;

                    }

                }
                //30.archiveRestrictions
                if (doc.SelectSingleNode("//*[local-name()='archiveRestrictions']") != null)
                {

                    if (doc.SelectSingleNode("//*[local-name()='archiveRestrictions']").InnerText != string.Empty)
                    {
                        m_tboAdagansTakmark_31.Text = doc.SelectSingleNode("//*[local-name()='archiveRestrictions']").InnerText;
                    }
                    else
                    {
                        m_tboAdagansTakmark_31.Text = string.Empty;

                    }

                }

            }
            catch (Exception x)
            {
                MessageBox.Show(string.Format("Fann ekki {0}", m_strRoot + "\\Indices\\archiveIndex.xml"));
            }

        }


        public void fyllaContexdocument()
        {

            //0. tæma töflur
            m_dtStyring_tafla1.Rows.Clear();
            m_dtVirkni_tafla2.Rows.Clear();
            m_dtAfhending_tafla3.Rows.Clear();
            m_dtVidtaka_tafla4.Rows.Clear();
            m_dtVardVeisla_tafla5.Rows.Clear();
            m_dtAnnad_tafla6.Rows.Clear();
            //1.sækja condexDocumentIndex.xml
            XmlDocument doc = new XmlDocument();
            doc.Load(m_strRoot + "\\Indices\\contextDocumentationIndex.xml");
            //2. fá document listan
            XmlNodeList list = doc.SelectNodes("//*[local-name()='document']");
            foreach (XmlNode n in list)
            {
                DataTable dtAllt = m_dtStyring_tafla1.Clone();
                DataRow r = dtAllt.NewRow();

                //  DataRow rr = m_dtVirkni_tafla2.NewRow();
                //    DataRow rrr = m_dtAfhending_tafla3.NewRow();
                // string i = n.SelectSingleNode("//*[local-name()='document']").InnerText;
                // string strBla = n.ch
                XmlNodeList aCild = n.ChildNodes;
                foreach (XmlNode a in aCild)
                {
                    r["opna"] = "Opna skjal";
                    if (a.Name == "documentCategory")
                    {
                        //Tvær gerðir - 1. Aðeins með það sem er true 2. allt uppi og það er true/false
                        XmlNodeList cCildChild = a.ChildNodes;
                        string strTag = string.Empty;

                        foreach (XmlNode c in cCildChild)
                        {
                            if (c.Name == "systemInformation")
                            {
                                XmlNodeList dCildChild = c.ChildNodes;
                                foreach (XmlNode d in dCildChild)
                                {
                                    if (d.Name == "systemPurpose" || d.Name == "systemRegulations" || d.Name == "systemContent" || d.Name == "systemAdministrativeFunctions" || d.Name == "systemPresentationStructure" || d.Name == "systemDataProvision" || d.Name == "systemDataTransfer" || d.Name == "systemAgencyQualityControl" || d.Name == "systemPublication" || d.Name == "systemInformationOther")
                                    {
                                        if (Convert.ToBoolean(d.InnerText))
                                        {
                                            r["tafla"] = "1";
                                            strTag += d.Name + ",";
                                            r["tag"] = d.Name; //   r["tag"] = "Skráð";
                                        }
                                    }

                                }
                            }
                            if (c.Name == "operationalInformation")
                            {
                                XmlNodeList dCildChild = c.ChildNodes;
                                foreach (XmlNode d in dCildChild)
                                {
                                    if (d.Name == "operationalSystemInformation" || d.Name == "operationalSystemConvertedInformation" || d.Name == "operationalSystemSOA" || d.Name == "operationalSystemInformationOther")
                                    {
                                        if (Convert.ToBoolean(d.InnerText))
                                        {
                                            r["tafla"] = "2";
                                            strTag += d.Name + ",";
                                            r["tag"] = d.Name; //   r["tag"] = "Skráð";
                                        }
                                    }
                                }
                            }
                            if (c.Name == "submissionInformation")
                            {
                                XmlNodeList dCildChild = c.ChildNodes;
                                foreach (XmlNode d in dCildChild)
                                {
                                    if (d.Name == "archivalProvisions" || d.Name == "archivalTransformationInformation" || d.Name == "archivalInformationOther")
                                    {
                                        if (Convert.ToBoolean(d.InnerText))
                                        {
                                            r["tafla"] = "3";
                                            strTag += d.Name + ",";
                                            r["tag"] = d.Name; //   r["tag"] = "Skráð";
                                        }
                                    }
                                }
                            }
                            if (c.Name == "ingestInformation")
                            {
                                XmlNodeList dCildChild = c.ChildNodes;
                                foreach (XmlNode d in dCildChild)
                                {
                                    if (d.Name == "archivistNotes" || d.Name == "archivalTestNotes" || d.Name == "archivalInformationOther")
                                    {
                                        if (Convert.ToBoolean(d.InnerText))
                                        {
                                            r["tafla"] = "4";
                                            strTag += d.Name + ",";
                                            r["tag"] = d.Name; //   r["tag"] = "Skráð";
                                        }
                                    }
                                }
                            }
                            if (c.Name == "archivalPreservationInformation")
                            {
                                XmlNodeList dCildChild = c.ChildNodes;
                                foreach (XmlNode d in dCildChild)
                                {
                                    if (d.Name == "archicalMigrationInformation" || d.Name == "archivalInformationOther")
                                    {
                                        if (Convert.ToBoolean(d.InnerText))
                                        {
                                            r["tafla"] = "5";
                                            strTag += d.Name + ",";
                                            r["tag"] = d.Name; //   r["tag"] = "Skráð";
                                        }
                                    }
                                }
                            }
                            if (c.Name == "informationOther")
                            {
                                XmlNodeList dCildChild = c.ChildNodes;
                                foreach (XmlNode d in dCildChild)
                                {
                                    if (d.Name == "informationOther")
                                    {
                                        if (Convert.ToBoolean(d.InnerText))
                                        {
                                            r["tafla"] = "6";
                                            strTag += d.Name + ",";
                                            r["tag"] = d.Name; //   r["tag"] = "Skráð";
                                        }
                                    }
                                }
                            }
                        }

                        if (strTag != string.Empty)
                        {
                            r["tegund"] = strTag.Remove(strTag.Length - 1);
                        }

                    }
                    if (a.Name == "documentID")
                    {
                        r["nr"] = a.InnerText;
                        //ná í skjalið og skella í minni og nota við uppfærslu
                        //https://stackoverflow.com/questions/8624071/save-and-load-memorystream-to-from-a-file
                        //MemoryStream stream = new MemoryStream
                        //FileStream.CopyTo(stream);
                        //m_stRoot + "\\Indices\\contextDocumentationIndex.xml"
                        MemoryStream ms = new MemoryStream();
                        // string strFile = m_stRoot + "\\ContextDocumentation\\docCollection1\\";

                        string[] strFile = Directory.GetFiles(m_strRoot + "\\ContextDocumentation\\docCollection1\\" + r["nr"].ToString() + "\\");
                        if (strFile.Length != 0)
                        {
                            r["slod"] = strFile[0];
                            //FileInfo fifo = new FileInfo(strFile[0]);
                            //File.Copy(fifo.FullName, "C:\\temp\\" + r["nr"] + "." + fifo.Extension, true);
                            //r["slod"] = "C:\\temp\\" + r["nr"] + "." + fifo.Extension;
                        }

                        //using (FileStream file = new FileStream(strFile[0], FileMode.Create, System.IO.FileAccess.Write))
                        //{
                        //    byte[] bytes = new byte[ms.Length];
                        //    ms.Read(bytes, 0, (int)ms.Length);
                        //    file.Write(bytes, 0, bytes.Length);
                        //    ms.Close();
                        //}

                    }
                    if (a.Name == "documentTitle")
                    {
                        r["skjal"] = a.InnerText;
                    }
                    if (a.Name == "documentDescription")
                    {
                        r["lysing"] = a.InnerText;
                    }
                    if (a.Name == "documentDate")
                    {
                        r["skrad"] = a.InnerText;
                    }
                    //documentAuthor
                    if (a.Name == "documentAuthor")
                    {
                        XmlNodeList bCildChild = a.ChildNodes;
                        foreach (XmlNode b in bCildChild)
                        {
                            if (b.Name == "authorName")
                            {
                                r["hofundur"] = b.InnerText;
                            }
                            if (b.Name == "authorInstitution")
                            {
                                r["stofnun"] = b.InnerText;
                            }
                        }
                    }
                }


                //    r["nr"] = n.SelectNodes("//documentID").ToString();   // ("//*[local-name()='documentID']").InnerText;
                dtAllt.Rows.Add(r);
                if (r["tafla"].ToString() == "1")
                {
                    m_dtStyring_tafla1.ImportRow(r);
                }
                if (r["tafla"].ToString() == "2")
                {
                    m_dtVirkni_tafla2.ImportRow(r);
                }
                if (r["tafla"].ToString() == "3")
                {
                    m_dtAfhending_tafla3.ImportRow(r);
                }
                if (r["tafla"].ToString() == "4")
                {
                    m_dtVidtaka_tafla4.ImportRow(r);
                }
                if (r["tafla"].ToString() == "5")
                {
                    m_dtVardVeisla_tafla5.ImportRow(r);
                }
                if (r["tafla"].ToString() == "6")
                {
                    m_dtAnnad_tafla6.ImportRow(r);
                }


            }
            m_dgvStyring_tafla1.AutoGenerateColumns = false;
            m_dgvStyring_tafla1.DataSource = m_dtStyring_tafla1;
            m_dgvVirkni_tafla2.AutoGenerateColumns = false;
            m_dgvVirkni_tafla2.DataSource = m_dtVirkni_tafla2;
            m_dgvAfhending_tafla3.AutoGenerateColumns = false;
            m_dgvAfhending_tafla3.DataSource = m_dtAfhending_tafla3;
            m_dgvVidtaka_tafla4.AutoGenerateColumns = false;
            m_dgvVidtaka_tafla4.DataSource = m_dtVidtaka_tafla4;
            m_dgvVardVeisla_tafla5.AutoGenerateColumns = false;
            m_dgvVardVeisla_tafla5.DataSource = m_dtVardVeisla_tafla5;
            m_dgvAnnad_tafla6.AutoGenerateColumns = false;
            m_dgvAnnad_tafla6.DataSource = m_dtAnnad_tafla6;
        }

        private void m_btnArch1_Click(object sender, EventArgs e)
        {
            Button takki = (Button)sender;
            TableLayoutPanel TPN = (TableLayoutPanel)takki.Parent;

            if (takki.Text == "+")
            {
                TPN.AutoSize = false;
                takki.Tag = TPN.Height;
                TPN.Height = 20;

                takki.Text = "-";
            }
            else
            {
                TPN.AutoSize = false;
                TPN.Height = Convert.ToInt32(takki.Tag);
                takki.Text = "+";
            }
            stillaToflur();
        }
        private void stillaToflur()
        {
            int x = m_tlpUtgafa1.Location.X;
            m_tlpSkjalm2.Location = new Point(m_tlpUtgafa1.Location.X, m_tlpUtgafa1.Location.Y + m_tlpUtgafa1.Height + 20);
            int y = m_tlpUtgafa1.Height + 20 + m_tlpSkjalm2.Height + 20;
            m_tlpKerfisUpp3.Location = new Point(x, y);
            //y = m_tlp_1.Location.Y + m_tlp_1.Height + 20 + m_tpl_2.Height + 20 + m_tpl_3.Height + 20;
            //m_tpl_4.Location = new Point(x, y);
            x = m_tlpInniHald4.Location.X;
            m_tlpNotkun5.Location = new Point(x, m_tlpInniHald4.Location.Y + m_tlpInniHald4.Height + 20);
        }

        private void m_dgvArchiveUtgafur_SelectionChanged(object sender, EventArgs e)
        {
            if (m_dgvArchiveUtgafur.Focused)
            {
                m_strRoot = m_dgvArchiveUtgafur.Rows[m_dgvArchiveUtgafur.SelectedRows[0].Index].Cells["colArchiveSlod"].Value.ToString();
                fyllaArchiveIndex();

            }

        }

        private void m_dgvStyring_tafla1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string strName = senderGrid.Name;

            switch (strName)
            {
                case "m_dgvStyring_tafla1":
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {

                        if (senderGrid.Rows[e.RowIndex].Cells["colContext1Skoda"].ColumnIndex == e.ColumnIndex)
                        {
                            string strSlod = senderGrid.Rows[e.RowIndex].Cells["colSlodSkjals"].Value.ToString();


                            var p = new Process();
                            p.StartInfo = new ProcessStartInfo(strSlod)
                            {
                                UseShellExecute = true
                            };
                            p.Start();
                        }

                    }
                    break;
                case "m_dgvVirkni_tafla2":

                    if (senderGrid.Rows[e.RowIndex].Cells["colOpna2"].ColumnIndex == e.ColumnIndex)
                    {
                        string strSlod = senderGrid.Rows[e.RowIndex].Cells["colTafla2Slod"].Value.ToString();


                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(strSlod)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                    break;
                case "m_dgvAfhending_tafla3":

                    if (senderGrid.Rows[e.RowIndex].Cells["colOpna3"].ColumnIndex == e.ColumnIndex)
                    {
                        string strSlod = senderGrid.Rows[e.RowIndex].Cells["colTafla3Slod"].Value.ToString();


                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(strSlod)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                    break;
                case "m_dgvVidtaka_tafla4":

                    if (senderGrid.Rows[e.RowIndex].Cells["colOpna4"].ColumnIndex == e.ColumnIndex)
                    {
                        string strSlod = senderGrid.Rows[e.RowIndex].Cells["colTafla4Slod"].Value.ToString();


                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(strSlod)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                    break;
                case "m_dgvVardVeisla_tafla5":

                    if (senderGrid.Rows[e.RowIndex].Cells["colOpna5"].ColumnIndex == e.ColumnIndex)
                    {
                        string strSlod = senderGrid.Rows[e.RowIndex].Cells["colTafla5Slod"].Value.ToString();


                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(strSlod)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                    break;
                case "m_dgvAnnad_tafla6":

                    if (senderGrid.Rows[e.RowIndex].Cells["colOpna6"].ColumnIndex == e.ColumnIndex)
                    {
                        string strSlod = senderGrid.Rows[e.RowIndex].Cells["colTafla6Slod"].Value.ToString();


                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(strSlod)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                    break;
                default:
                    break;
            }


        }

        private void m_dgvContextUtgafur_SelectionChanged(object sender, EventArgs e)
        {
            if (m_dgvContextUtgafur.Focused)
            {
                m_strRoot = m_dgvContextUtgafur.Rows[m_dgvContextUtgafur.SelectedRows[0].Index].Cells["colContextSlod"].Value.ToString();
                fyllaContexdocument();
            }

        }

        private void m_dgvDocUtgafur_SelectionChanged(object sender, EventArgs e)
        {
            if (m_dgvDocUtgafur.Focused)
            {
                m_strRoot = m_dgvDocUtgafur.Rows[m_dgvDocUtgafur.SelectedRows[0].Index].Cells["colDocSlod"].Value.ToString();

                DataSet ds = new DataSet();
                string strSlodDoc = m_strRoot + "\\Indices\\docIndex.xml";
                // string strSlodFile = m_strRoot + "\\Indices\\fileIndex.xml";
                if (File.Exists(strSlodDoc))
                {
                    ds.ReadXml(strSlodDoc);
                    if (ds.Tables.Contains("doc"))
                    {
                        m_dtDoc = ds.Tables["doc"];
                        m_dgvDoc.AutoGenerateColumns = false;
                        m_dgvDoc.DataSource = m_dtDoc;
                        m_grbDoc.Text = string.Format("Skjöl ({0})", ds.Tables["doc"].Rows.Count);
                    }
                }
                else
                {
                    // MessageBox.Show("Engar skrár í þessari vörsluútgáfu");
                    m_grbDoc.Text = string.Format("Skjöl (0) - vörsluútgáfan innheldur enginn skjöl");
                    m_dtDoc.Rows.Clear();
                    m_dgvDoc.AutoGenerateColumns = false;
                    m_dgvDoc.DataSource = m_dtDoc;
                }
                //if (File.Exists(strSlodFile))
                //{ 
                //    DataSet dsFile = new DataSet();
                //    dsFile.ReadXml(strSlodFile);
                //    if (dsFile.Tables.Contains("f"))
                //    {
                //        m_dtFile = dsFile.Tables["f"];
                //        m_dgvFile.DataSource = m_dtFile;
                //        m_grbFile.Text = string.Format("Gátsummur ({0})", m_dtFile.Rows.Count);
                //    }
                //}


            }
        }

        private void m_dgvFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string strSlod = m_dgvFile.Rows[e.RowIndex].Cells["colFileSlod"].Value.ToString();
            string strSkjal = m_dgvFile.Rows[e.RowIndex].Cells["colFileSkjal"].Value.ToString();
            string[] strSplit = m_strRoot.Split("\\");
            string strFinal = m_strRoot.Replace(strSplit[strSplit.Length - 1], "") + strSlod + "\\" + strSkjal;

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(strFinal)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void m_dgvDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string strID = m_dgvDoc.Rows[e.RowIndex].Cells["colDocID"].Value.ToString();
            string strColl = m_dgvDoc.Rows[e.RowIndex].Cells["colDocCollection"].Value.ToString();


            string strSlod = m_strRoot + "\\Documents\\" + strColl + "\\" + strID;
            string[] strFile = Directory.GetFiles(strSlod);

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(strFile[0])
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void m_docLeit_Click(object sender, EventArgs e)
        {
            docLeit();

        }

        private void m_btnLDocHreinsa_Click(object sender, EventArgs e)
        {
            m_dgvDoc.DataSource = m_dtDoc;
            m_grbDoc.Text = string.Format("Skjöl ({0})", m_dtDoc.Rows.Count);
            m_tboDocLeit.Text = string.Empty;
        }
        private void docLeit()
        {
            if (m_dtDoc.Rows.Count == 0) return;
            string strExpression = string.Empty;
            DataTable dt = m_dtDoc.Clone();
            strExpression = "oFn like '%" + m_tboDocLeit.Text + "%'";

            DataRow[] fRow = m_dtDoc.Select(strExpression);

            foreach (DataRow r in fRow)
            {
                dt.ImportRow(r);
            }
            m_dgvDoc.DataSource = dt;
            m_grbDoc.Text = string.Format("Skjöl ({0})", dt.Rows.Count);
        }
        private void m_tboDocLeit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                docLeit();
            }
        }

        private void fileLeit()
        {
            if (m_dtFile.Rows.Count == 0) return;
            string strExpression = string.Empty;
            DataTable dt = m_dtFile.Clone();
            strExpression = "md5 ='" + m_tboLeitGatsumma.Text.ToUpper() + "'";

            DataRow[] fRow = m_dtFile.Select(strExpression);

            foreach (DataRow r in fRow)
            {
                dt.ImportRow(r);
            }
            m_dgvFile.DataSource = dt;
            m_grbFile.Text = string.Format("Gátsummur({0})", dt.Rows.Count);
        }

        private void leitMD5()
        {
            //fileLeit();
            string strMD5 = m_tboLeitGatsumma.Text;
            cMD5 mD5 = new cMD5();
            DataTable dt = mD5.getMD5(strMD5);
            //finna docindex skjalið
            if (dt.Rows.Count == 1)
            {
                string strSlod = dt.Rows[0]["slod"].ToString();
                if (strSlod.Contains("\\Documents"))
                {
                    string[] strSplit = strSlod.Split('\\');
                    string strAIP = dt.Rows[0]["mappa"].ToString();
                    string strdocIndex = strAIP + "\\Indices\\docIndex.xml";
                    DataSet ds = new DataSet();
                    ds.ReadXml(strdocIndex);

                    DataTable dtMD5 = ds.Tables["doc"];
                    string strExp = "dID = '" + strSplit[strSplit.Length - 1] + "'";
                    DataRow[] fRow = dtMD5.Select(strExp);
                    if (fRow.Length > 0)
                    {
                        string strTitill = fRow[0]["oFN"].ToString();
                        dt.Rows[0]["titill"] = strTitill;
                    }
                }
                else
                {
                    dt.Rows[0]["titill"] = dt.Rows[0]["file"];
                }


            }

            m_dgvFile.DataSource = dt;
            m_dgvFile.ClearSelection();
        }
        private void m_btnGatsummaLeit_Click_1(object sender, EventArgs e)
        {
            leitMD5();
        }

        private void m_btnGatsummaHreinsa_Click_1(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)m_dgvFile.DataSource;
            dt.Rows.Clear();
            m_dgvFile.DataSource = dt;
            m_grbFile.Text = string.Format("Gátsummur ({0})", m_dtDoc.Rows.Count);
            m_tboLeitGatsumma.Text = string.Empty;
        }

        private void m_tboLeitGatsumma_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                leitMD5();
            }
        }

        private void m_dgvFile_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string strSlod = m_dgvFile.Rows[e.RowIndex].Cells["colMD5Slod"].Value.ToString() + "\\" + m_dgvFile.Rows[e.RowIndex].Cells["colMD5Titilvarsla"].Value.ToString();
                     
          //  string[] strFile = Directory.GetFiles(strSlod);

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(strSlod)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        private void m_dgvContextUtgafur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                if (senderGrid.Rows[e.RowIndex].Cells["colContextOpna"].ColumnIndex == e.ColumnIndex)
                {
                    m_strRoot = senderGrid.Rows[e.RowIndex].Cells["colContextSlod"].Value.ToString();
                    string strSlod = m_strRoot + "\\Indices\\contextDocumentationIndex.xml";

                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(strSlod)
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
            }
        }

        private void m_dgvDocUtgafur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            try
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {

                    if (senderGrid.Rows[e.RowIndex].Cells["colDocOpna"].ColumnIndex == e.ColumnIndex)
                    {
                        m_strRoot = senderGrid.Rows[e.RowIndex].Cells["colDocSlod"].Value.ToString();
                        string strSlod = m_strRoot + "\\Indices\\docIndex.xml";

                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(strSlod)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                }
            }
            catch (Exception x)
            {

              //      throw;
            }
        }

        private void m_btnVistaArkiveIndex_Click(object sender, EventArgs e)
        {
            bool bOk = true;
            errorProvider1.Clear();
            m_tboVorsluUtgafuNumer_1.BackColor = System.Drawing.Color.White;
            m_tboKerfisHeiti_9.BackColor = System.Drawing.Color.White;
            m_comSkjalaMyndarar_8.BackColor = System.Drawing.Color.White;
            m_tboKerfiTilgangur_11.BackColor = System.Drawing.Color.White;
            m_tboKerfiInnihald_12.BackColor = System.Drawing.Color.White;
            m_tboVidtokuSkjalasafn_30.BackColor = System.Drawing.Color.White;
            m_tboTengdSkjalaSafns_25.BackColor = System.Drawing.Color.White;

            if (m_tboVorsluUtgafuNumer_1.Text == string.Empty)
            {
                errorProvider1.SetError(m_tboVorsluUtgafuNumer_1, "Vantar vörslunúmer");
                m_tboVorsluUtgafuNumer_1.BackColor = System.Drawing.Color.LightPink;
                bOk = false;
            }
            if (m_tboKerfisHeiti_9.Text == string.Empty)
            {
                errorProvider1.SetError(m_tboKerfisHeiti_9, "Vantar kerfisheiti");
                m_tboKerfisHeiti_9.BackColor = System.Drawing.Color.LightPink;
                bOk = false;
            }
            if (m_dtSkjalamyndarar.Rows.Count == 0)
            {
                errorProvider1.SetError(m_dgvSkjalaMyndarar, "Vantar að tilgreina skjalamyndara");
                m_comSkjalaMyndarar_8.BackColor = System.Drawing.Color.LightPink;
                bOk = false;
            }
            //if (m_comSkjalaMyndarar_8.SelectedIndex == 0)
            //{
            //    errorProvider1.SetError(m_comSkjalaMyndarar_8, "Vantar heiti skjalamyndara");
            //    m_comSkjalaMyndarar_8.BackColor = System.Drawing.Color.LightPink;
            //    bOk = false;
            //}
            if (m_tboKerfiTilgangur_11.Text == string.Empty)
            {
                errorProvider1.SetError(m_tboKerfiTilgangur_11, "Vantar að skrá tilgang kerfis");
                m_tboKerfiTilgangur_11.BackColor = System.Drawing.Color.LightPink;
                bOk = false;
            }
            if (m_tboKerfiInnihald_12.Text == string.Empty)
            {
                errorProvider1.SetError(m_tboKerfiInnihald_12, "Vantar að skrá innhald kerfis");
                m_tboKerfiInnihald_12.BackColor = System.Drawing.Color.LightPink;
                bOk = false;
            }
            if (m_rdbLeitarAdferdJa_24.Checked && m_tboTengdSkjalaSafns_25.Text == string.Empty)
            {
                errorProvider1.SetError(m_tboTengdSkjalaSafns_25, "Vantar að skrá heiti tengds skjalasafns");
                m_tboTengdSkjalaSafns_25.BackColor = System.Drawing.Color.LightPink;
                bOk = false;
            }


            if (m_tboVidtokuSkjalasafn_30.Text == string.Empty)
            {
                errorProvider1.SetError(m_tboVidtokuSkjalasafn_30, "Vantar að skrá viðtökuskjalasafni");
                m_tboVidtokuSkjalasafn_30.BackColor = System.Drawing.Color.LightPink;
                bOk = false;
            }

            if (bOk)
            {
                archiveIndex();
                MessageBox.Show("Vei skráning tókst - mátt panta pizzu", "Skráning tókst");
                m_btnPizza.Visible = true;
                string strNyRoot = String.Empty;
                string[] strSplit = m_strRoot.Split("\\");
                if (strSplit.Length == 2)
                {
                    strNyRoot = m_strRoot.Replace(strSplit[1], m_tboVorsluUtgafuNumer_1.Text + ".1");
                }
                if (strSplit.Length == 3)
                {
                    strNyRoot = m_strRoot.Replace(strSplit[2], m_tboVorsluUtgafuNumer_1.Text + ".1");
                }
                if (strNyRoot != String.Empty)
                {
                    DirectoryInfo difo = new DirectoryInfo(m_strRoot);
                    if (difo.FullName != strNyRoot)
                    {
                        Directory.Move(difo.FullName, strNyRoot);
                    }


                    m_strRoot = strNyRoot;

                }



            }
            else
            {
                MessageBox.Show("Vinsamlegast lagið villur til að halda áfram", "Villur í skráningu");
                m_btnPizza.Visible = false;
            }
        }

        private void archiveIndex()
        {
            //todo - færa þetta inn í cArchiveindex og búa til object
            string strDateFormatt = "yyyy-MM-dd";
            string strTrueFalse = string.Empty;

            XmlDocument doc = new XmlDocument();
            doc.Load(m_strRoot + "\\Indices\\archiveIndex.xml");

            //. declaration - má sleppa þarf að finna betur út úr
            //XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            //XmlElement root = doc.DocumentElement;
            //doc.InsertBefore(xmlDeclaration, root);
            //0. archiveIndex - setja attribute og vísun á schema
            XmlElement elArchiveIndex = doc.DocumentElement; //.CreateElement(string.Empty, "archiveIndex", string.Empty);
                                                             //XmlElement elArchiveIndex = doc.DocumentElement;
                                                             //elArchiveIndex.SetAttribute("schemaLocation", "http://www.w3.org/2001/XMLSchema-instance", "http://www.sa.dk/xmlns/diark/1.0 ../Schemas/standard/archiveIndex.xsd");   //þarf að laga og fá  rétt
                                                             // doc.AppendChild(elArchiveIndex);

            //1. archiveInformationPackageID
            XmlNodeList list = doc.SelectNodes("//*[local-name()='archiveInformationPackageID']");

            if (list.Count == 0)
            {
                XmlElement archiveInformationPackageID = doc.CreateElement(string.Empty, "archiveInformationPackageID", string.Empty);
                elArchiveIndex.AppendChild(archiveInformationPackageID);
                XmlText archiveInformationPackageID_text = doc.CreateTextNode(m_tboVorsluUtgafuNumer_1.Text);
                archiveInformationPackageID.AppendChild(archiveInformationPackageID_text);
            }
            else
            {
                doc.SelectSingleNode("//*[local-name()='archiveInformationPackageID']").InnerText = m_tboVorsluUtgafuNumer_1.Text;

            }



            //2. archiveInformationPackageIDPrevious
            if (m_tboVorsluNumerFyrra_2.Text != string.Empty)
            {
                list = doc.SelectNodes("//*[local-name()='archiveInformationPackageIDPrevious']");

                if (list.Count == 0)
                {
                    XmlElement archiveInformationPackageIDPrevious = doc.CreateElement(string.Empty, "archiveInformationPackageIDPrevious", string.Empty);
                    elArchiveIndex.AppendChild(archiveInformationPackageIDPrevious);
                    XmlText archiveInformationPackageIDPrevious_text = doc.CreateTextNode(m_tboVorsluNumerFyrra_2.Text);
                    archiveInformationPackageIDPrevious.AppendChild(archiveInformationPackageIDPrevious_text);
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='archiveInformationPackageIDPrevious']").InnerText = m_tboVorsluNumerFyrra_2.Text;
                }
            }
            //3. archivePeriodStart
            list = doc.SelectNodes("//*[local-name()='archivePeriodStart']");

            if (list.Count == 0)
            {
                XmlElement archivePeriodStart = doc.CreateElement(string.Empty, "archivePeriodStart", string.Empty);
                elArchiveIndex.AppendChild(archivePeriodStart);
                XmlText archivePeriodStart_text = doc.CreateTextNode(m_dtpUppafsDagsetningGogn_6.Value.ToString(strDateFormatt));
                archivePeriodStart.AppendChild(archivePeriodStart_text);
            }
            else
            {
                doc.SelectSingleNode("//*[local-name()='archivePeriodStart']").InnerText = m_dtpUppafsDagsetningGogn_6.Value.ToString(strDateFormatt);
            }

            //4. archivePeriodEnd
            list = doc.SelectNodes("//*[local-name()='archivePeriodEnd']");
            if (list.Count == 0)
            {
                XmlElement archivePeriodEnd = doc.CreateElement(string.Empty, "archivePeriodEnd", string.Empty);
                elArchiveIndex.AppendChild(archivePeriodEnd);
                XmlText archivePeriodEnd_text = doc.CreateTextNode(m_dtpLokaDagsetningGogn_7.Value.ToString(strDateFormatt));
                archivePeriodEnd.AppendChild(archivePeriodEnd_text);
            }
            else
            {
                doc.SelectSingleNode("//*[local-name()='archivePeriodEnd']").InnerText = m_dtpLokaDagsetningGogn_7.Value.ToString(strDateFormatt);
            }
            //5. archiveInformationPacketType
            list = doc.SelectNodes("//*[local-name()='archiveInformationPacketType']");
            if (list.Count == 0)
            {
                XmlElement archiveInformationPacketType = doc.CreateElement(string.Empty, "archiveInformationPacketType", string.Empty);
                elArchiveIndex.AppendChild(archiveInformationPacketType);

                if (m_rdbLokaAfhendingJA_5.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }
                XmlText archiveInformationPacketType_text = doc.CreateTextNode(strTrueFalse);
                archiveInformationPacketType.AppendChild(archiveInformationPacketType_text);
            }
            else
            {
                if (m_rdbLokaAfhendingJA_5.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='archiveInformationPacketType']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='archiveInformationPacketType']").InnerText = "false";
                }
            }
            // archiveCreatorList ************tag þar sem allt creation fer undir***************************
            list = doc.SelectNodes("//*[local-name()='archiveCreatorList']");
            XmlElement archiveCreatorList = doc.CreateElement(string.Empty, "archiveCreatorList", string.Empty);
            if (list.Count == 0)
            {

                elArchiveIndex.AppendChild(archiveCreatorList);

            }
            else
            {
                //eyða öllu creator dæmi úr skjali
                XmlNodeList creatorlist = doc.SelectNodes("//*[local-name()='creatorName']");
                foreach (XmlNode n in creatorlist)
                {
                    n.RemoveAll();
                    n.ParentNode.RemoveChild(n);
                }
                creatorlist = doc.SelectNodes("//*[local-name()='creationPeriodStart']");
                foreach (XmlNode nn in creatorlist)
                {
                    nn.RemoveAll();
                    nn.ParentNode.RemoveChild(nn);
                }

                creatorlist = doc.SelectNodes("//*[local-name()='creationPeriodEnd']");
                foreach (XmlNode nnn in creatorlist)
                {
                    nnn.RemoveAll();
                    XmlElement el = (XmlElement)nnn;
                    nnn.ParentNode.RemoveChild(nnn);
                    // el.Descendants().Where(e => string.IsNullOrEmpty(e.Value)).Remove();
                }

                archiveCreatorList = (XmlElement)list[0];

            }
            DataTable dtSkjal = (DataTable)m_dgvSkjalmArchive.DataSource;
            foreach (DataRow rr in dtSkjal.Rows)
            {

                //creatorName
                XmlElement creatorName = doc.CreateElement(string.Empty, "creatorName", string.Empty);
                archiveCreatorList.AppendChild(creatorName);
                XmlText creatorName_text = doc.CreateTextNode(rr["skjalamyndari"].ToString());
                creatorName.AppendChild(creatorName_text);

                XmlElement creationPeriodStart = doc.CreateElement(string.Empty, "creationPeriodStart", string.Empty);
                archiveCreatorList.AppendChild(creationPeriodStart);
                DateTime dDatDod = Convert.ToDateTime(rr["dags_fyrst"]);
                XmlText creationPeriodStart_text = doc.CreateTextNode(dDatDod.ToString(strDateFormatt)); //vantar dateformat
                creationPeriodStart.AppendChild(creationPeriodStart_text);

                XmlElement creationPeriodEnd = doc.CreateElement(string.Empty, "creationPeriodEnd", string.Empty);
                archiveCreatorList.AppendChild(creationPeriodEnd);
                dDatDod = Convert.ToDateTime(rr["dags_sidast"]);
                XmlText creationPeriodEnd_text = doc.CreateTextNode(dDatDod.ToString(strDateFormatt));
                creationPeriodEnd.AppendChild(creationPeriodEnd_text);


            }

            //8a. creatorName
            //    list = doc.SelectNodes("//*[local-name()='creatorName']");
            //    if (list.Count == 0)
            //    {
            //        XmlElement creatorName = doc.CreateElement(string.Empty, "creatorName", string.Empty);
            //        archiveCreatorList.AppendChild(creatorName);
            //        XmlText creatorName_text = doc.CreateTextNode(m_comSkjalaMyndarar_8.Text);
            //        creatorName.AppendChild(creatorName_text);

            //    }
            //    else
            //    {
            //        doc.SelectSingleNode("//*[local-name()='creatorName']").InnerText = m_comSkjalaMyndarar_8.Text;
            //    }

            //    //6. creationPeriodStart

            //    list = doc.SelectNodes("//*[local-name()='creationPeriodStart']");
            //    if (list.Count == 0)
            //    {
            //        XmlElement creationPeriodStart = doc.CreateElement(string.Empty, "creationPeriodStart", string.Empty);
            //        archiveCreatorList.AppendChild(creationPeriodStart);
            //        XmlText creationPeriodStart_text = doc.CreateTextNode(m_dtpUppafsDagsetning_3.Value.ToString(strDateFormatt));
            //        creationPeriodStart.AppendChild(creationPeriodStart_text);
            //    }
            //    else
            //    {
            //        doc.SelectSingleNode("//*[local-name()='creationPeriodStart']").InnerText = m_dtpUppafsDagsetning_3.Value.ToString(strDateFormatt);
            //    }

            //    //7. creationPeriodEnd

            ////    if (m_rdbLokaAfhendingJA_5.Checked)
            //  //  {
            //        list = doc.SelectNodes("//*[local-name()='creationPeriodEnd']");
            //        if (list.Count == 0)
            //        {
            //            XmlElement creationPeriodEnd = doc.CreateElement(string.Empty, "creationPeriodEnd", string.Empty);
            //            archiveCreatorList.AppendChild(creationPeriodEnd);
            //            XmlText creationPeriodEnd_text = doc.CreateTextNode(m_dtpLokaDagsetning_4.Value.ToString(strDateFormatt));
            //            creationPeriodEnd.AppendChild(creationPeriodEnd_text);
            //        }
            //        else
            //        {
            //            doc.SelectSingleNode("//*[local-name()='creationPeriodEnd']").InnerText = m_dtpLokaDagsetning_4.Value.ToString(strDateFormatt);
            //        }
            // }
            //else
            //{
            //    list = doc.SelectNodes("//*[local-name()='creationPeriodEnd']");
            //    if (list.Count == 1)
            //    {
            //        list[0].RemoveAll();
            //    }
            //    else
            //    {
            //        XmlElement creationPeriodEnd = doc.CreateElement(string.Empty, "creationPeriodEnd", string.Empty);
            //        archiveCreatorList.AppendChild(creationPeriodEnd);
            //    }
            //}



            //8b. creatorID - viðbót við danska staðalinn - gengur ekki upp með ADA
            //list = doc.SelectNodes("//*[local-name()='creatorID']");
            //if (list.Count == 0 && m_comSkjalaMyndarar_8.SelectedIndex != -1)
            //{
            //    XmlElement creatorID = doc.CreateElement(string.Empty, "creatorID", string.Empty);
            //    elArchiveIndex.AppendChild(creatorID);
            //    XmlText creatorID_text = doc.CreateTextNode(m_comSkjalaMyndarar_8.SelectedValue.ToString());
            //    creatorID.AppendChild(creatorID_text);
            //}
            //else
            //{
            //    if(m_comSkjalaMyndarar_8.SelectedIndex != -1)
            //    {
            //        doc.SelectSingleNode("//*[local-name()='creatorID']").InnerText = m_comSkjalaMyndarar_8.SelectedValue.ToString();
            //    }
            //    else
            //    {
            //        if(list.Count != 0)
            //        {
            //            list[0].RemoveAll();
            //        }

            //    }

            //}
            //5. archiveInformationPacketType
            list = doc.SelectNodes("//*[local-name()='archiveType']");
            if (list.Count == 0)
            {
                XmlElement archiveType = doc.CreateElement(string.Empty, "archiveType", string.Empty);
                elArchiveIndex.AppendChild(archiveType);

                if (m_rdbSkjalTimLokidJa.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }
                XmlText archiveType_text = doc.CreateTextNode(strTrueFalse);
                archiveType.AppendChild(archiveType_text);
            }
            else
            {
                if (m_rdbSkjalTimLokidJa.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='archiveType']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='archiveType']").InnerText = "false";
                }
            }

            //9. systemName
            list = doc.SelectNodes("//*[local-name()='systemName']");
            if (list.Count == 0)
            {
                XmlElement systemName = doc.CreateElement(string.Empty, "systemName", string.Empty);
                elArchiveIndex.AppendChild(systemName);
                XmlText systemName_text = doc.CreateTextNode(m_tboKerfisHeiti_9.Text);
                systemName.AppendChild(systemName_text);
            }
            else
            {
                doc.SelectSingleNode("//*[local-name()='systemName']").InnerText = m_tboKerfisHeiti_9.Text;
            }

            //10. alternativeName
            list = doc.SelectNodes("//*[local-name()='alternativeName']");
            if (list.Count == 0)
            {
                if (m_tboKerfiAnnadHeiti_10.Text != string.Empty)
                {
                    XmlElement alternativeName = doc.CreateElement(string.Empty, "alternativeName", string.Empty);
                    elArchiveIndex.AppendChild(alternativeName);
                    XmlText alternativeName_text = doc.CreateTextNode(m_tboKerfiAnnadHeiti_10.Text);
                    alternativeName.AppendChild(alternativeName_text);
                }
            }
            else
            {
                if (m_tboKerfiAnnadHeiti_10.Text != string.Empty)
                {
                    doc.SelectSingleNode("//*[local-name()='alternativeName']").InnerText = m_tboKerfiAnnadHeiti_10.Text;
                }
                else
                {
                    //eyða elementi ef það er autt - tæmir elementið en fjarlægir það ekki. Þarf að finna útúr þessu.
                    list[0].RemoveAll();
                }
            }

            //11. systemPurpose
            list = doc.SelectNodes("//*[local-name()='systemPurpose']");
            if (list.Count == 0)
            {
                XmlElement systemPurpose = doc.CreateElement(string.Empty, "systemPurpose", string.Empty);
                elArchiveIndex.AppendChild(systemPurpose);
                XmlText systemPurpose_text = doc.CreateTextNode(m_tboKerfiTilgangur_11.Text);
                systemPurpose.AppendChild(systemPurpose_text);
            }
            else
            {
                doc.SelectSingleNode("//*[local-name()='systemPurpose']").InnerText = m_tboKerfiTilgangur_11.Text;
            }


            //12. systemContent
            list = doc.SelectNodes("//*[local-name()='systemContent']");
            if (list.Count == 0)
            {
                XmlElement systemContent = doc.CreateElement(string.Empty, "systemContent", string.Empty);
                elArchiveIndex.AppendChild(systemContent);
                XmlText systemContent_text = doc.CreateTextNode(m_tboKerfiInnihald_12.Text);
                systemContent.AppendChild(systemContent_text);
            }
            else
            {
                doc.SelectSingleNode("//*[local-name()='systemContent']").InnerText = m_tboKerfiInnihald_12.Text;
            }

            //13. regionNum
            list = doc.SelectNodes("//*[local-name()='regionNum']");
            if (list.Count == 0)
            {
                XmlElement regionNum = doc.CreateElement(string.Empty, "regionNum", string.Empty);
                elArchiveIndex.AppendChild(regionNum);

                if (m_rdbSvaedisNumerJa_13.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }

                XmlText regionNum_text = doc.CreateTextNode(strTrueFalse);
                regionNum.AppendChild(regionNum_text);
            }
            else
            {
                if (m_rdbSvaedisNumerJa_13.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='regionNum']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='regionNum']").InnerText = "false";
                }

            }


            //14. komNum
            list = doc.SelectNodes("//*[local-name()='komNum']");
            if (list.Count == 0)
            {

                XmlElement komNum = doc.CreateElement(string.Empty, "komNum", string.Empty);
                elArchiveIndex.AppendChild(komNum);

                if (m_rdbSveitarFelagJa_14.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }

                XmlText komNum_text = doc.CreateTextNode(strTrueFalse);
                komNum.AppendChild(komNum_text);
            }
            else
            {
                if (m_rdbSveitarFelagJa_14.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='komNum']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='komNum']").InnerText = "false";
                }

            }

            //15. cprNum
            list = doc.SelectNodes("//*[local-name()='cprNum']");
            if (list.Count == 0)
            {
                XmlElement cprNum = doc.CreateElement(string.Empty, "cprNum", string.Empty);
                elArchiveIndex.AppendChild(cprNum);

                if (m_rdbKennitalaJa_15.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }

                XmlText cprNum_text = doc.CreateTextNode(strTrueFalse);
                cprNum.AppendChild(cprNum_text);
            }
            else
            {
                if (m_rdbKennitalaJa_15.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='cprNum']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='cprNum']").InnerText = "false";
                }

            }


            //16. cvrNum
            list = doc.SelectNodes("//*[local-name()='cvrNum']");
            if (list.Count == 0)
            {
                XmlElement cvrNum = doc.CreateElement(string.Empty, "cvrNum", string.Empty);
                elArchiveIndex.AppendChild(cvrNum);

                if (m_rdbKennitalaFyrirTaekisJa_16.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }

                XmlText cvrNum_text = doc.CreateTextNode(strTrueFalse);
                cvrNum.AppendChild(cvrNum_text);
            }
            else
            {
                if (m_rdbKennitalaFyrirTaekisJa_16.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='cvrNum']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='cvrNum']").InnerText = "false";
                }

            }

            //17. matrikNum
            list = doc.SelectNodes("//*[local-name()='matrikNum']");
            if (list.Count == 0)
            {
                XmlElement matrikNum = doc.CreateElement(string.Empty, "matrikNum", string.Empty);
                elArchiveIndex.AppendChild(matrikNum);

                if (m_rdbLandsNumerJa_17.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }

                XmlText matrikNum_text = doc.CreateTextNode(strTrueFalse);
                matrikNum.AppendChild(matrikNum_text);
            }
            else
            {
                if (m_rdbLandsNumerJa_17.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='matrikNum']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='matrikNum']").InnerText = "false";
                }

            }
            //18. bbrNum
            list = doc.SelectNodes("//*[local-name()='bbrNum']");
            if (list.Count == 0)
            {
                XmlElement bbrNum = doc.CreateElement(string.Empty, "bbrNum", string.Empty);
                elArchiveIndex.AppendChild(bbrNum);

                if (m_rdbFastaNumerJa_18.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }

                XmlText bbrNum_text = doc.CreateTextNode(strTrueFalse);
                bbrNum.AppendChild(bbrNum_text);
            }
            else
            {
                if (m_rdbFastaNumerJa_18.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='bbrNum']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='bbrNum']").InnerText = "false";
                }

            }

            //19. whoSygKod
            list = doc.SelectNodes("//*[local-name()='whoSygKod']");
            if (list.Count == 0)
            {
                XmlElement whoSygKod = doc.CreateElement(string.Empty, "whoSygKod", string.Empty);
                elArchiveIndex.AppendChild(whoSygKod);

                if (m_rdbSjukKodarJa_19.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }

                XmlText whoSygKod_text = doc.CreateTextNode(strTrueFalse);
                whoSygKod.AppendChild(whoSygKod_text);
            }
            else
            {
                if (m_rdbSjukKodarJa_19.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='whoSygKod']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='whoSygKod']").InnerText = "false";
                }

            }

            //20. sourceName
            list = doc.SelectNodes("//*[local-name()='sourceName']");
            if (list.Count == 0)
            {
                if (m_tboGagnaLind_20.Text != string.Empty)
                {
                    XmlElement sourceName = doc.CreateElement(string.Empty, "sourceName", string.Empty);
                    elArchiveIndex.AppendChild(sourceName);
                    XmlText sourceName_text = doc.CreateTextNode(m_tboGagnaLind_20.Text);
                    sourceName.AppendChild(sourceName_text);
                }
            }
            else
            {
                if (m_tboGagnaLind_20.Text != string.Empty)
                {
                    doc.SelectSingleNode("//*[local-name()='sourceName']").InnerText = m_tboGagnaLind_20.Text;
                }
                else
                {
                    list[0].RemoveAll(); //þarf að finna út með eyða elementi
                }


            }
            //21 userName
            list = doc.SelectNodes("//*[local-name()='userName']");
            if (list.Count == 0)
            {
                if (m_tboGagnaNotandi_21.Text != string.Empty)
                {
                    XmlElement userName = doc.CreateElement(string.Empty, "userName", string.Empty);
                    elArchiveIndex.AppendChild(userName);
                    XmlText userName_text = doc.CreateTextNode(m_tboGagnaNotandi_21.Text);
                    userName.AppendChild(userName_text);
                }
            }
            else
            {
                if (m_tboGagnaNotandi_21.Text != string.Empty)
                {
                    doc.SelectSingleNode("//*[local-name()='userName']").InnerText = m_tboGagnaNotandi_21.Text;
                }
                else
                {
                    list[0].RemoveAll(); //þarf að finna út með eyða elementi
                }
            }

            //22 predecessorName
            list = doc.SelectNodes("//*[local-name()='predecessorName']");
            if (list.Count == 0)
            {
                if (m_tboFyrriKerfisHeiti_22.Text != string.Empty)
                {
                    XmlElement predecessorName = doc.CreateElement(string.Empty, "predecessorName", string.Empty);
                    elArchiveIndex.AppendChild(predecessorName);
                    XmlText predecessorName_text = doc.CreateTextNode(m_tboFyrriKerfisHeiti_22.Text);
                    predecessorName.AppendChild(predecessorName_text);
                }
            }
            else
            {
                if (m_tboFyrriKerfisHeiti_22.Text != string.Empty)
                {
                    doc.SelectSingleNode("//*[local-name()='predecessorName']").InnerText = m_tboFyrriKerfisHeiti_22.Text;
                }
                else
                {
                    list[0].RemoveAll(); //þarf að finna út með eyða elementi
                }
            }


            //23. containsDigitalDocuments
            list = doc.SelectNodes("//*[local-name()='containsDigitalDocuments']");
            if (list.Count == 0)
            {
                XmlElement containsDigitalDocuments = doc.CreateElement(string.Empty, "containsDigitalDocuments", string.Empty);
                elArchiveIndex.AppendChild(containsDigitalDocuments);

                if (m_rdbStafreanSkjolJa_23.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }
                XmlText containsDigitalDocuments_text = doc.CreateTextNode(strTrueFalse);
                containsDigitalDocuments.AppendChild(containsDigitalDocuments_text);
            }
            else
            {
                if (m_rdbStafreanSkjolJa_23.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='containsDigitalDocuments']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='containsDigitalDocuments']").InnerText = "false";
                }

            }

            //24. searchRelatedOtherRecords
            list = doc.SelectNodes("//*[local-name()='searchRelatedOtherRecords']");
            if (list.Count == 0)
            {
                XmlElement searchRelatedOtherRecords = doc.CreateElement(string.Empty, "searchRelatedOtherRecords", string.Empty);
                elArchiveIndex.AppendChild(searchRelatedOtherRecords);

                if (m_rdbLeitarAdferdJa_24.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }
                XmlText searchRelatedOtherRecords_text = doc.CreateTextNode(strTrueFalse);
                searchRelatedOtherRecords.AppendChild(searchRelatedOtherRecords_text);
            }
            else
            {
                if (m_rdbLeitarAdferdJa_24.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='searchRelatedOtherRecords']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='searchRelatedOtherRecords']").InnerText = "false";
                }

            }

            //25. relatedRecordsName
            list = doc.SelectNodes("//*[local-name()='relatedRecordsName']");
            if (list.Count == 0)
            {
                if (m_tboTengdSkjalaSafns_25.Text != string.Empty) //þarf fleiri skilyrði þar sem þetta er skylda ef 24 er true
                {
                    XmlElement relatedRecordsName = doc.CreateElement(string.Empty, "relatedRecordsName", string.Empty);
                    elArchiveIndex.AppendChild(relatedRecordsName);
                    XmlText relatedRecordsName_text = doc.CreateTextNode(m_tboTengdSkjalaSafns_25.Text);
                    relatedRecordsName.AppendChild(relatedRecordsName_text);
                }
            }
            else
            {
                if (m_tboFyrriKerfisHeiti_22.Text != string.Empty)
                {
                    doc.SelectSingleNode("//*[local-name()='relatedRecordsName']").InnerText = m_tboTengdSkjalaSafns_25.Text;
                }
                else
                {
                    list[0].RemoveAll(); //þarf að finna út með eyða elementi
                }
            }

            //26. systemFileConcept
            list = doc.SelectNodes("//*[local-name()='systemFileConcept']");
            if (list.Count == 0)
            {
                XmlElement systemFileConcept = doc.CreateElement(string.Empty, "systemFileConcept", string.Empty);
                elArchiveIndex.AppendChild(systemFileConcept);

                if (m_rdbTilvistMalaSkraJa_26.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }
                XmlText systemFileConcept_text = doc.CreateTextNode(strTrueFalse);
                systemFileConcept.AppendChild(systemFileConcept_text);
            }
            else
            {
                if (m_rdbTilvistMalaSkraJa_26.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='systemFileConcept']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='systemFileConcept']").InnerText = "false";
                }

            }

            //27. multipleDataCollection
            list = doc.SelectNodes("//*[local-name()='multipleDataCollection']");
            if (list.Count == 0)
            {
                XmlElement multipleDataCollection = doc.CreateElement(string.Empty, "multipleDataCollection", string.Empty);
                elArchiveIndex.AppendChild(multipleDataCollection);

                if (m_rdbSOAJa_27.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }
                XmlText multipleDataCollection_text = doc.CreateTextNode(strTrueFalse);
                multipleDataCollection.AppendChild(multipleDataCollection_text);
            }
            else
            {
                if (m_rdbSOAJa_27.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='multipleDataCollection']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='multipleDataCollection']").InnerText = "false";
                }

            }

            //28. personalDataRestrictedInfo
            list = doc.SelectNodes("//*[local-name()='personalDataRestrictedInfo']");
            if (list.Count == 0)
            {
                XmlElement personalDataRestrictedInfo = doc.CreateElement(string.Empty, "personalDataRestrictedInfo", string.Empty);
                elArchiveIndex.AppendChild(personalDataRestrictedInfo);

                if (m_rdbPersonuGognJa_28.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }
                XmlText personalDataRestrictedInfo_text = doc.CreateTextNode(strTrueFalse);
                personalDataRestrictedInfo.AppendChild(personalDataRestrictedInfo_text);
            }
            else
            {
                if (m_rdbPersonuGognJa_28.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='personalDataRestrictedInfo']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='personalDataRestrictedInfo']").InnerText = "false";
                }

            }

            //29. otherAccessTypeRestrictions
            list = doc.SelectNodes("//*[local-name()='otherAccessTypeRestrictions']");
            if (list.Count == 0)
            {
                XmlElement otherAccessTypeRestrictions = doc.CreateElement(string.Empty, "otherAccessTypeRestrictions", string.Empty);
                elArchiveIndex.AppendChild(otherAccessTypeRestrictions);

                if (m_rdbLokudGognJa_29.Checked)
                {
                    strTrueFalse = "true";
                }
                else
                {
                    strTrueFalse = "false";
                }
                XmlText otherAccessTypeRestrictions_text = doc.CreateTextNode(strTrueFalse);
                otherAccessTypeRestrictions.AppendChild(otherAccessTypeRestrictions_text);
            }
            else
            {
                if (m_rdbLokudGognJa_29.Checked)
                {
                    doc.SelectSingleNode("//*[local-name()='otherAccessTypeRestrictions']").InnerText = "true";
                }
                else
                {
                    doc.SelectSingleNode("//*[local-name()='otherAccessTypeRestrictions']").InnerText = "false";
                }

            }


            //30. archiveApproval
            list = doc.SelectNodes("//*[local-name()='archiveApproval']");
            if (list.Count == 0)
            {
                XmlElement archiveApproval = doc.CreateElement(string.Empty, "archiveApproval", string.Empty);
                elArchiveIndex.AppendChild(archiveApproval);
                XmlText archiveApproval_text = doc.CreateTextNode(m_tboVidtokuSkjalasafn_30.Text);
                archiveApproval.AppendChild(archiveApproval_text);
            }
            else
            {
                doc.SelectSingleNode("//*[local-name()='archiveApproval']").InnerText = m_tboVidtokuSkjalasafn_30.Text;
            }


            //31. archiveRestrictions
            list = doc.SelectNodes("//*[local-name()='archiveRestrictions']");
            if (list.Count == 0)
            {
                if (m_tboAdagansTakmark_31.Text != string.Empty)
                {
                    XmlElement archiveRestrictions = doc.CreateElement(string.Empty, "archiveRestrictions", string.Empty);
                    elArchiveIndex.AppendChild(archiveRestrictions);
                    XmlText archiveRestrictions_text = doc.CreateTextNode(m_tboAdagansTakmark_31.Text);
                    archiveRestrictions.AppendChild(archiveRestrictions_text);
                }
            }
            else
            {
                if (m_tboAdagansTakmark_31.Text != string.Empty)
                {
                    doc.SelectSingleNode("//*[local-name()='archiveRestrictions']").InnerText = m_tboAdagansTakmark_31.Text;
                }
                else
                {
                    list[0].RemoveAll(); //þarf að finna út með eyða elementi
                }
            }


            doc.Save(m_strRoot + "\\Indices\\archiveIndex.xml");
            skitaMix(m_strRoot + "\\Indices\\archiveIndex.xml");

            //þarf að uppfæra MD5 fyrir archive index inn í fileindex og inn í gagnagrunni.
            uppfæraFileIndex(m_strRoot + "\\Indices\\fileIndex.xml", m_tboVorsluUtgafuNumer_1.Text, m_strRoot + "\\Indices\\archiveIndex.xml" );
        }

        private void uppfæraFileIndex(string strFileindex, string strVarsla, string strArchiveIndex)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(strFileindex);
            string strNyMD5 = string.Empty;
            string strOldMD5 = string.Empty;
            foreach (DataRow fRow in ds.Tables["f"].Rows)
            {
                if (fRow["fiN"].ToString() == "archiveIndex.xml")
                {
                    //Reikna út nýtt MD5 fyrir fileindex
                    strNyMD5 = md5(strArchiveIndex).ToUpper();
                    strOldMD5 = fRow["md5"].ToString();
                    fRow["md5"] = strNyMD5;
                }
            }

            //ds.WriteXml(strFileindex);
            uppfæraMD5xml(strFileindex, strNyMD5, strOldMD5);
            cMD5 gattsuma = new cMD5();
            gattsuma.uppfæraMD5(strOldMD5, strNyMD5);
        }

        private string md5(string strFile)
        {
            string strRet = string.Empty;
            using (var md5 = MD5.Create())
            {

                // using (FileStream straumur = File.OpenRead("C:\\AVID.SA.18000.1\\Documents\\docCollection1\\1\\1.tif"))
                {
                    FileStream InputBin = new FileStream(strFile, FileMode.Open, FileAccess.Read, FileShare.None);
                    byte[] bla = md5.ComputeHash(InputBin);
                    strRet = BitConverter.ToString(bla).Replace("-", "");
                    InputBin.Close();
                }
            }
            return strRet;
        }
        private void skitaMix(string strSlod)
        {
            string text = File.ReadAllText(strSlod);
            text = text.Replace(" xmlns=\"\">", ">");
            File.WriteAllText(strSlod, text);

        }

        private void uppfæraMD5xml(string strSlod, string strNy, string strOld)
        {
            string text = File.ReadAllText(strSlod);
            text = text.Replace(strOld,strNy);
            File.WriteAllText(strSlod, text);

        }
    }
}
