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
using cClassVHS;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace OAIS_ADMIN
{
    public partial class uscMidlun : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        private cSkjalamyndari skjalamyndari = new cSkjalamyndari();
        private cVorslustofnun vörslustofnun = new cVorslustofnun();
        private cSkjalaskra skrá = new cSkjalaskra();
        private cMIdlun midlun = new cMIdlun();
        private string m_strSlod = string.Empty;
        private string m_strGrunnur = string.Empty;
        private DataTable m_dtKlasar = new DataTable();
        public uscMidlun()
        {
            InitializeComponent();
            fyllaVorsluUtgafur();
            fyllaklasa();


            splitContainer1.SplitterDistance = 250;
        }
        public void fyllaVorsluUtgafur()
        {
            cSkjalaskra skrá = new cSkjalaskra();
            DataTable dt = skrá.getVörsluútgáfurMidlun();

            m_dgvUtgafur.AutoGenerateColumns = false;
            DataTable dtFormat = formatTable(dt);
            m_dgvUtgafur.DataSource = dtFormat;
            foreach (DataGridViewRow r in m_dgvUtgafur.Rows)
            {
              if (r.Cells["colMidlad"].Value.ToString() == "1")
                {
                    r.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void fyllaklasa()
        {
            m_dtKlasar = vörslustofnun.getAllKlasa();
            DataView view = new DataView(m_dtKlasar);
            DataTable klasar = view.ToTable(true, "klasar");

            foreach(DataRow r in klasar.Rows)
            {
                TreeNode n = new TreeNode(r["klasar"].ToString());
                m_trwKlasarVorslustonun.Nodes.Add(n);
            }


        }

        private DataTable formatTable(DataTable dt)
        {
            DataTable dtClone = dt.Clone();
            dtClone.Columns["staerd"].DataType = typeof(string);
            foreach (DataRow row in dt.Rows)
            {
                dtClone.ImportRow(row);
            }
            //gera stærð skiljanlega

            foreach (DataRow r in dtClone.Rows)
            {
                long bla = (long)Convert.ToDouble(r["staerd"]);
                r["staerd"] = FormatBytes(bla);
            }
            return dtClone;
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

        private void m_dgvUtgafur_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colBtnBirta"].Index == e.ColumnIndex)
                {
                    //0. ná í stlóð á vörsluútgáfu
                    m_strSlod = senderGrid.Rows[e.RowIndex].Cells["colSlod"].Value.ToString();
                    //1. auðkenni vörsluútgáfu
                    string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVorsluutgafu"].Value.ToString();
                    skrá.getSkraning(strAuðkenni.Replace("FRUM","AVID"));
                    m_strGrunnur = skrá.auðkenni_3_1_1.Replace(".", "_");
                    //2. auðkenni vörslustofnunar
                    string strVarsla = senderGrid.Rows[e.RowIndex].Cells["colVorslustofnun"].Value.ToString();
                    vörslustofnun.getVörslustofnun(strVarsla);
                    //3. auðkenni skjalamyndara
                    string strSkjalam = senderGrid.Rows[e.RowIndex].Cells["colSkjalamyndari"].Value.ToString();
                    skjalamyndari.getSkjalamyndaraByAuðkenni(strSkjalam);
                    m_lblValinVorsluutgafa.Text = senderGrid.Rows[e.RowIndex].Cells["colTitill"].Value.ToString();
                    m_lblValinVorsluutgafa.Visible = true;

                    // midla(strslod);
                }

                cVorsluutgafur utgafa = new cVorsluutgafur();
                utgafa.getVörsluútgáfu(skrá.auðkenni_3_1_1);
                if (Convert.ToBoolean(Convert.ToInt32(utgafa.midlun)))
                {
                    DataTable dtFyrirspurnir = midlun.getGagnagrunnaFyrirSpurnirMidlun(skrá.auðkenni_3_1_1.Replace(".", "_"));
                    m_dgvUtgafur.AutoGenerateColumns = false;
                    m_dgvFyrirSpurnir.DataSource = dtFyrirspurnir;
                    foreach(DataGridViewRow r in m_dgvFyrirSpurnir.Rows)
                    {
                        if(r.Cells["colID"].Value != null)
                        {
                            if (r.Cells["colID"].Value.ToString() != "0")
                            {
                                r.DefaultCellStyle.BackColor = Color.LightGreen;
                            }
                        }
                        
                    }
                }
                else
                {
                    string strTableIndex = m_strSlod + "\\Indices\\tableIndex.xml";
                    DataSet ds = new DataSet();
                    ds.ReadXml(strTableIndex);
                    if (ds.Tables.Contains("view"))
                    {
                        DataTable dt = ds.Tables["view"];
                        dt.Columns.Add("database");
                        foreach (DataRow dr in dt.Rows)
                        {
                           // dr["database"] = strDataBase;
                        }
                        m_dgvUtgafur.AutoGenerateColumns = false;
                        m_dgvFyrirSpurnir.DataSource = ds.Tables["view"];
                    }
                }
           
                //uppfæra vorsluutgafu
                //cVorsluutgafur utgafa = new cVorsluutgafur();
                //utgafa.getVörsluútgáfu(skrá.auðkenni_3_1_1);
                //utgafa.midlun = "1";
                //utgafa.hver_midladi = virkurnotandi.nafn;
                //utgafa.uppFaeraVegnaMidlun();
            }

        }

        private void midla(string strSlod)
        {
            //þarf að fara neðar
            cVorsluutgafur utgafa = new cVorsluutgafur();
            utgafa.getVörsluútgáfu(skrá.auðkenni_3_1_1);
            utgafa.midlun = "1";
            utgafa.hver_midladi = virkurnotandi.nafn;
            utgafa.uppFaeraVegnaMidlun();
            //1. búa til gagnagrunninn
            string strDataBase = skrá.auðkenni_3_1_1;
            strDataBase = strDataBase.Replace(".", "_");
            midlun.createDatabase(strDataBase);
            midlun.tegund_grunns = m_comTegundVörslu.Text;
            //2. skrá í yfirlitsgrunn
           //midlun.instertYfirlit(skrá.auðkenni_3_1_1, skrá.titill_3_1_2);
            //3. búa til töflur - fiska á sama tíma eftir functiondescription
            string strTableIndex = strSlod + "\\Indices\\tableIndex.xml";
            DataSet ds = new DataSet();
            ds.ReadXml(strTableIndex);
            if (ds.Tables.Contains("view"))
            {
                DataTable dt = ds.Tables["view"];
                dt.Columns.Add("database");
                foreach (DataRow dr in dt.Rows)
                {
                    dr["database"] = strDataBase;
                }
                m_dgvFyrirSpurnir.DataSource = ds.Tables["view"];
            }
            DataColumnCollection columnsus = ds.Tables[0].Columns;
            if (columnsus.Contains("dbName")) //*****************tek þetta út nafn á gagangrunni************************
            {
              //  strDataBase = ds.Tables[0].Rows[0]["dbName"].ToString().Replace("\"", "").Replace(" ", "_"); 
            }
            else
            {
                // strDataBase = m_stringVörslunumer.Replace(".", "_") + "_filesystem"; //þarf að ná í vörlunúmerisheitið eða eitthvað
            }

            string strTime = string.Empty;
            string strSQL = string.Empty;
            m_prbToflur.Value = 0;
            m_prbToflur.Step = 1;
            m_prbToflur.Maximum = ds.Tables["table"].Rows.Count;
            foreach (DataRow r in ds.Tables["table"].Rows)
            {
               
                string strMetadataFunc = string.Empty;
                string strTableName = r["name"].ToString();
                strTableName = strTableName.Replace("\"", "");
                strTableName = strTableName.Replace(" ", "_");

                m_prbToflur.PerformStep();
                m_lblToflurStatus.Text = string.Format("Bý til töflu {0}: sem er {1}/{2}", strTableName, m_prbToflur.Value, m_prbToflur.Maximum);
                Application.DoEvents();

                string strTableID = r["table_id"].ToString();
                string strTableFolder = r["folder"].ToString();
                strSQL = "DROP TABLE IF EXISTS `" + strDataBase + "`." + strTableName + ";" + Environment.NewLine;
                strSQL += "CREATE TABLE `" + strDataBase + "`.`" + strTableName + "` (" + Environment.NewLine;
                //finna dálka
                string strExpression = "columns_id=" + strTableID;
                DataRow[] frow = ds.Tables["column"].Select(strExpression);

                string strColumn = string.Empty;
                if (frow.Length != 0)
                {
                    string strColumsID = frow[0]["columns_id"].ToString();
                    strExpression = "columns_id=" + strColumsID;
                    frow = ds.Tables["column"].Select(strExpression);

                    if (frow.Length != 0)
                    {

                        int i = 1;
                        foreach (DataRow rr in frow)
                        {
                            if (rr["type"].ToString().ToLower() == "timestamp" || rr["type"].ToString().ToLower() == "datetime")
                            {
                                strTime += rr["name"] + ":::";
                                rr["type"] = "datetime";
                            }
                            //ríkiskaup
                            if (rr["type"].ToString().ToUpper().StartsWith("NATIONAL CHARACTER VARYING") && rr["name"].ToString() != "ID")
                            {
                                rr["type"] = "TEXT";
                            }
                            if (rr["type"].ToString().ToUpper().StartsWith("CHAR"))
                            {
                                if (!rr["type"].ToString().ToUpper().StartsWith("CHARACTER VARYING"))
                                {
                                    rr["type"] = "VAR" + rr["type"];
                                }

                            }

                            //fyrir siperinn ef string
                            if (rr["type"].ToString().ToUpper() == "STRING")
                            {
                                rr["type"] = "TEXT";
                            }

                            rr["name"] = rr["name"].ToString().Replace("\"", "");

                            strColumn += rr["name"] + ",";
                            //ef dálkur var text þá er hann longtext
                            if (rr["typeOriginal"].ToString().ToLower() == "text")
                            {
                                strSQL += rr["name"] + " " + "LONGTEXT" + " ";
                            }
                            else
                            {
                                strSQL += rr["name"] + " " + rr["type"] + " ";
                            }

                            //  if(Convert.ToBoolean(rr["nullable"]))
                            string strble = rr["nullable"].ToString();
                            if (rr["nullable"].ToString() == "false")
                            {
                                if (i != frow.Length)
                                {
                                    strSQL += "NOT NULL COMMENT '" + rr["description"].ToString().Replace("’", "") + "'," + Environment.NewLine;
                                }
                                else
                                {
                                    strExpression = "table_id=" + strTableID;
                                    frow = ds.Tables["primarykey"].Select(strExpression);
                                    if (frow.Length != 0)
                                    {
                                        DataColumnCollection columns = ds.Tables["primarykey"].Columns;
                                        if (columns.Contains("column"))
                                        {
                                            strSQL += "NOT NULL COMMENT '" + rr["description"].ToString().Replace("’", "") + "'," + Environment.NewLine;
                                            strSQL += "PRIMARY KEY (`" + frow[0]["column"] + "`)" + Environment.NewLine;
                                        }
                                        else
                                        {
                                            strSQL += "NOT NULL COMMENT '" + rr["description"].ToString().Replace("’", "") + "'" + Environment.NewLine;
                                        }
                                    }
                                    else
                                    {
                                        strSQL += "NOT NULL COMMENT '" + rr["description"].ToString().Replace("’", "") + "'" + Environment.NewLine;
                                    }

                                }

                            }
                            else
                            {
                                if (i != frow.Length)
                                {
                                    strSQL += " COMMENT '" + rr["description"].ToString().Replace("’", "") + "'," + Environment.NewLine;
                                }
                                else
                                {
                                    strExpression = "table_id=" + strTableID;
                                    frow = ds.Tables["primarykey"].Select(strExpression);
                                    if (frow.Length != 0)
                                    {
                                        DataColumnCollection columns = ds.Tables["primarykey"].Columns;
                                        if (columns.Contains("column"))
                                        {
                                            strSQL += " COMMENT '" + rr["description"].ToString().Replace("’", "") + "'," + Environment.NewLine;
                                            strSQL += "PRIMARY KEY (`" + frow[0]["column"] + "`)" + Environment.NewLine;
                                        }
                                        else
                                        {
                                            strSQL += " COMMENT '" + rr["description"].ToString().Replace("’", "") + "'" + Environment.NewLine;
                                        }


                                    }
                                    else
                                    {
                                        strSQL += "NOT NULL COMMENT '" + rr["description"].ToString().Replace("’", "") + "'" + Environment.NewLine;
                                    }
                                }

                            }

                            columnsus = ds.Tables["column"].Columns;
                            if (columnsus.Contains("functionalDescription"))
                            {

                                if (rr["functionalDescription"].ToString() != string.Empty)
                                {
                                    string strFunktion = rr["functionalDescription"].ToString();
                                    string strDalkur = rr["name"].ToString();
                                    string strDot = string.Empty;
                                    strMetadataFunc += "{" + strFunktion + "~" + strDalkur + "}";
                                }
                            }
                            if (ds.Tables.Contains("functionalDescription"))
                            {
                                //lesa og finn útfrá þessu
                                //1. finna út allar columns í 

                                strExpression = "column_id=" + rr["column_id"].ToString();
                                DataRow[] ffrow = ds.Tables["functionalDescription"].Select(strExpression);

                                if (ffrow.Length != 0)
                                {
                                    string strFunktion = ffrow[0][0].ToString();
                                    string strDalkur = rr["name"].ToString();

                                    strMetadataFunc += "{" + strFunktion + "~" + strDalkur + "}";
                                }

                                //string strFunction = 
                            }


                            i++;
                        }
                    }
                    //strSQL = strSQL.Remove(strSQL.Length - 1,2);
                    strSQL += ") ENGINE = InnoDB  DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";
                    midlun.createTable(strSQL);

                    //3. skrá niður gögn
                    DataSet dsData = new DataSet();
                    dsData.ReadXml(strSlod + "//Tables//" + strTableFolder + "//" + strTableFolder + ".xml");

                    m_prbGogn.Value = 0;
                    m_prbGogn.Maximum = dsData.Tables["row"].Rows.Count;
                    m_prbGogn.Step = 1;
                    foreach (DataRow rd in dsData.Tables["row"].Rows)
                    {
                        midlun.vorsluutgafa = skrá.auðkenni_3_1_1;
                        midlun.titill_vorsluutgafu = skrá.titill_3_1_2;
                        midlun.vorslustofnun_audkenni = vörslustofnun.auðkenni_5_1_1;
                        midlun.vorslustofnun_heiti = vörslustofnun.opinbert_heiti_5_1_2;
                        midlun.skjalamyndari_audkenni = skjalamyndari.auðkenni_5_1_6;
                        midlun.skjalamyndari_heiti = skjalamyndari.opinbert_heiti_5_1_2;
                        midlun.tafla_grunns = strTableName;
                        midlun.tegund_grunns = m_comTegundVörslu.Text; //þarf að finna betur úr þessu eða láta notanda velja.
                        midlun.skjalaskra_adgengi = skrá.skilyrði_aðgengi_3_4_1;
                        midlun.skjalaskra_afharnr = skrá.afhendingar_tilfærslur_3_2_4;
                        midlun.skjalaskra_innihald = skrá.yfirlit_innihald_3_3_1;
                        midlun.skjalaskra_timabil = skrá.tímabil_3_1_3;
                        midlun.hver_skradi = virkurnotandi.nafn;
                        //   midlun
                        midlun.insertToTable(strColumn, rd, strDataBase, strTableName, strTime, strMetadataFunc, skrá.auðkenni_3_1_1, strSlod);
                        m_prbGogn.PerformStep();
                        m_lblGognStatus.Text = string.Format("Vista röð {0}/{1}", m_prbGogn.Value, m_prbGogn.Maximum);
                        Application.DoEvents();
                    }
                   
                    //4. skrá í yfirlit_dálkar
                  
                    //5. skrá niður view
                }
               
            }
            MessageBox.Show("Búið");
            m_grbStatus.Visible = false;
        }

        private void m_dgvFyrirSpurnir_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            string strID = string.Empty;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colBtnPrófa"].Index == e.ColumnIndex)
                {
                  
                    
                    //0. ná í stlóð á vörsluútgáfu
                    string strFyrirspurn = senderGrid.Rows[e.RowIndex].Cells["colFyrirFyrirspurn"].Value.ToString();
                   // string strDatabase = senderGrid.Rows[e.RowIndex].Cells["colFyrirDatabase"].Value.ToString();
                    frmFyrirspurnProfa frmTest = new frmFyrirspurnProfa(strFyrirspurn, m_strGrunnur);
                    frmTest.ShowDialog();
                    senderGrid.Rows[e.RowIndex].Cells["colFyrirFyrirspurn"].Value = frmTest.m_strFyrirspurn;

                }
                if (senderGrid.Columns["colBtnVista"].Index == e.ColumnIndex)
                {
                    if (senderGrid.Rows[e.RowIndex].Cells["colID"].Value != null)
                    {
                        strID = senderGrid.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                    }
                    else
                    {
                        strID = "0";
                    }
                    string strFyrirspurn = senderGrid.Rows[e.RowIndex].Cells["colFyrirFyrirspurn"].Value.ToString();
                  
                  // string strDatabase = senderGrid.Rows[e.RowIndex].Cells["colFyrirDatabase"].Value.ToString();
                    string strNafn = senderGrid.Rows[e.RowIndex].Cells["colFyrirNafn"].Value.ToString();
                    string strLysing = senderGrid.Rows[e.RowIndex].Cells["colFyrirLýsing"].Value.ToString();
                     strID =  midlun.vistaFyrirSpurn(strFyrirspurn, m_strGrunnur, strNafn, strLysing, strID);
                    MessageBox.Show("Fyrirspurn vistuð");
                    senderGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    senderGrid.Rows[e.RowIndex].Cells["colID"].Value = strID;
                }
            }
           
        }

        private void m_btnEndurHressa_Click(object sender, EventArgs e)
        {
            fyllaVorsluUtgafur();
        }

        private void m_btnkeyra_Click(object sender, EventArgs e)
        {
            if(m_comTegundVörslu.Text != "")
            {
                if (m_comTegundVörslu.Text == "Gagnagrunnur")
                {
                    cMIdlun midlun = new cMIdlun();
                    midlun.heiti_gagangrunns = m_strGrunnur;
                    midlun.vorsluutgafa = skrá.auðkenni_3_1_1;
                    string strOrginal = string.Empty;
                    string strTableIndex = m_strSlod + "\\Indices\\tableIndex.xml";
                    DataSet ds = new DataSet();
                    ds.ReadXml(strTableIndex);
                    {
                        strOrginal = ds.Tables[0].Rows[0]["dbName"].ToString().Replace("\"", "").Replace(" ", "_");
                    }
                    midlun.vistaGagnagrunn(strOrginal);
                }
                m_grbStatus.Visible = true;
                midla(m_strSlod);
                fyllaVorsluUtgafur();
            }
            else
            {
                MessageBox.Show("Veldu tegund");
            }
       
        }

        private void m_trwKlasarVorslustonun_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Level == 0) 
            {
                string strExpr = string.Empty;
                strExpr = "klasar='" + e.Node.Text + "'";
                DataTable dt = m_dtKlasar.Clone();
                DataRow[] fRow = m_dtKlasar.Select(strExpr);
                if (fRow.Length > 0)
                {
                    foreach (DataRow row in fRow)
                    {
                        dt.ImportRow(row);
                    }
                }
                DataView view = new DataView(dt);
                DataTable dtVarsla = view.ToTable(true, "5_1_2_opinbert_heiti", "5_1_1_auðkenni");
                e.Node.Nodes.Clear();
                string strVorslur = string.Empty;
                foreach (DataRow row in dtVarsla.Rows)
                {
                    TreeNode n = new TreeNode(row["5_1_2_opinbert_heiti"].ToString());
                    n.Tag = row["5_1_1_auðkenni"].ToString();
                    strVorslur += "'" + n.Tag + "',";
                    e.Node.Nodes.Add(n);
                    e.Node.Expand();
                }
                cVorsluutgafur utgafur = new cVorsluutgafur();
                DataTable dtKlasar = utgafur.getVorsluUtgafurKlasa(strVorslur.Remove(strVorslur.Length-1));
                m_dgvUtafurKlasarVarsla.AutoGenerateColumns = false;
      
                m_dgvUtafurKlasarVarsla.DataSource = dtKlasar;
                m_dgvUtafurKlasarVarsla.ClearSelection();
                m_lblKlasiVarslaValinn.Text = string.Format("Klasi {0} valinn", e.Node.Text);
                m_btnBuaTilPakka.Text = string.Format("Búa til miðlunarpakka fyrir {0} klasa", e.Node.Text);
                
            }
            if (e.Node.Level == 1)
            {
                m_dgvUtafurKlasarVarsla.AutoGenerateColumns = false;
                cVorsluutgafur utgafur = new cVorsluutgafur();
                DataTable dtKVarsla = utgafur.getVorsluUtgafurVorslu(e.Node.Tag.ToString());
                m_dgvUtafurKlasarVarsla.DataSource = dtKVarsla;
                m_dgvUtafurKlasarVarsla.ClearSelection();
                m_lblKlasiVarslaValinn.Text = string.Format("Vörslustofnun {0} valinn", e.Node.Text);
                m_btnBuaTilPakka.Text = string.Format("Búa til miðlunarpakka fyrir {0}", e.Node.Text);
            }
            foreach (DataGridViewRow dRow in m_dgvUtafurKlasarVarsla.Rows)
            {
                string strAuðkenni = dRow.Cells["colAudkenni"].Value.ToString();
                cSkjalaskra skra = new cSkjalaskra();
                DataTable dtSkra = skra.getGeymsluSkra(strAuðkenni);
                if (dtSkra.Rows.Count > 1)
                {
                    dRow.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }

        }

        private void m_dgvUtafurKlasarVarsla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colGeymsluskra"].Index == e.ColumnIndex)
                {
                    
                    string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colAudkenni"].Value.ToString();
                    string strSlod = senderGrid.Rows[e.RowIndex].Cells["colVarslaSlod"].Value.ToString();
                    frmGeymsluskra frmgeymsla= new frmGeymsluskra(strAuðkenni, strSlod, virkurnotandi);
                    frmgeymsla.ShowDialog();
                }
            }
        }

        private void m_dgvFyrirSpurnir_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void m_btnBuaTilPakka_Click(object sender, EventArgs e)
        {
            //Fara yfir gridview og keyra eftirfarandi
            //1. Flytja vörsluútgáfu á ákveðina möppu - þarf að ákveða heiti líklega AIP-{vörslustofnin|Klasi}/vörsluútgáfuauðkenni}/vörsluútgáfuauðkenni
            m_lblStatus.Text = "Bý til möppur";
            if (!Directory.Exists("D:\\AIP-Afrit"))
            {
                Directory.CreateDirectory("D:\\AIP-Afrit");
            }
            string strAfritunarMappa = string.Empty;
            string strDags = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString(); 
            if (m_trwKlasarVorslustonun.SelectedNode.Level == 0)
            {
               strAfritunarMappa = string.Format("D:\\AIP-Afrit\\Klasi_{0}_{1}", m_trwKlasarVorslustonun.SelectedNode.Text, strDags) ;
            }
            else
            {
                strAfritunarMappa = string.Format("D:\\AIP-Afrit\\{0}_{1}", m_trwKlasarVorslustonun.SelectedNode.Text, strDags);
            }
            if (!Directory.Exists(strAfritunarMappa))
            {
                Directory.CreateDirectory(strAfritunarMappa);
            }
            //búa til möppu fyrir hverja vörsluútgáfu
            DataTable dtVarsla = (DataTable)m_dgvUtafurKlasarVarsla.DataSource;
            string strVarslAuðkenni = string.Empty;
            string strAuðkenni = string.Empty;
            string strVarslaStofnun = string.Empty;
            string strStofnanir = string.Empty;
            foreach (DataRow r in dtVarsla.Rows)
            {
                m_prgVorsluStofnun.Maximum = dtVarsla.Rows.Count;
                m_prgVorsluStofnun.Value = 0;
                m_prgVorsluStofnun.Step = 1;
                m_lblStatus.Text = "flytt gögn frá " + r["varsla_heiti"].ToString();
                strVarslAuðkenni = r["vorsluutgafa"].ToString();
                strAuðkenni += "'" + strVarslAuðkenni + "',";
                string strVarslaTitill = r["utgafa_titill"].ToString().Replace(" / ", "_");
                string strBackup = string.Empty;
                if (r["vorslustofnun"].ToString() != strVarslaStofnun)
                {
                    strVarslaStofnun = r["vorslustofnun"].ToString();
                    strStofnanir += "'" + strVarslaStofnun + "',";
                }
                if (m_trwKlasarVorslustonun.SelectedNode.Level == 0)
                {

                }
                if (m_trwKlasarVorslustonun.SelectedNode.Level == 1)
                {

                    string strVarslaMappa = strAfritunarMappa + "\\Vörsluútgáfur";
                    if (!Directory.Exists(strVarslaMappa))
                    {
                        Directory.CreateDirectory(strVarslaMappa);
                    }
                    strVarslaMappa = strVarslaMappa + "\\" + strVarslaTitill;
                    strBackup = strVarslaMappa;
                    if (!Directory.Exists(strVarslaMappa))
                    {
                        Directory.CreateDirectory(strVarslaMappa);
                    }
                    string strFrum = strVarslaMappa;
                    strVarslaMappa = strVarslaMappa + "\\" + strVarslAuðkenni;
                    if (!Directory.Exists(strVarslaMappa))
                    {
                        Directory.CreateDirectory(strVarslaMappa);
                    }

                    //ef til eru frummgögn
                    string strSlod = r["slod"].ToString().Replace("AVID", "FRUM");
                    if (Directory.Exists(strSlod))
                    {
                     
                        strFrum = strFrum + "\\" + strVarslAuðkenni.Replace("AVID", "FRUM");
                        m_lblStatus.Text = m_lblStatus.Text + " " + strFrum;
                        Application.DoEvents();
                        CopyFolder(r["slod"].ToString().Replace("AVID", "FRUM"), strFrum);
                    }
                    m_lblStatus.Text = m_lblStatus.Text + " " + strVarslaMappa;
                    Application.DoEvents();
                    CopyFolder(r["slod"].ToString(), strVarslaMappa);
                    
                }
                m_prgVorsluStofnun.PerformStep();
                m_lblVorsluStofnunPrg.Text = string.Format("{0}/{1}", m_prgVorsluStofnun.Value, m_prgVorsluStofnun.Maximum);
                //2. Taka  sql-afrit afhverri útgáfu AIP-{vörslustofnin|Klasi}/vörsluútgáfuauðkenni/{gagnagrunnsheiti.sql}
                string strDest = strBackup + "\\SQL";
                if (!Directory.Exists(strDest)) 
                {
                    Directory.CreateDirectory(strDest); 
                }
                strDest = strDest + "\\" + strVarslAuðkenni.Replace(".", "_") + ".Sql";
                m_lblStatus.Text = "Tek afrit af grunni " + strVarslAuðkenni.Replace(".", "_");
                BackupSQL(strDest, strVarslAuðkenni.Replace(".", "_"));
            }


            //3. Gera insert-skriptu fyrir allan pakkan (metadata) AIP-{vörslustofnin|Klasi}/vörsluútgáfuauðkenni/{metadata.sql}
            //A. ná í schemað
            if (m_trwKlasarVorslustonun.SelectedNode.Level == 0)
            {
                strAfritunarMappa = string.Format("D:\\AIP-Afrit\\Klasi_{0}_{1}", m_trwKlasarVorslustonun.SelectedNode.Text, strDags);
            }
            else
            {
                strAfritunarMappa = string.Format("D:\\AIP-Afrit\\{0}_{1}", m_trwKlasarVorslustonun.SelectedNode.Text, strDags);
            }
            if (!Directory.Exists(strAfritunarMappa))
            {
                Directory.CreateDirectory(strAfritunarMappa);
            }
            string strSchema = strAfritunarMappa + "\\SQL_META_AFRIT";
            if (!Directory.Exists(strSchema))
            {
                Directory.CreateDirectory(strSchema);
            }
            File.Copy("OAIS_ADMIN_AFRIT.sql", strSchema + "\\OAIS_ADMIN_AFRIT.sql", true);
            //A. gera innsert sriptu
            cBackup back = new cBackup();
            DataTable dtGogn = new DataTable();
            //  string[] strTöflur = { "dt_fyrirspurnir", "dt_isaar_skjalamyndarar", "dt_isadg_skráningar", "dt_isdiah_vörslustofnanir", "dt_item_korfu_dip", "dt_item_korfu_mal_dip", "dt_karfa_dip", "dt_karfa_item_gagna_dip", "dt_lanthegar", "dt_md5", "dt_midlun", "dt_notendur" };
            string[] strTöflur = { "dt_isdiah_vörslustofnanir", "dt_isaar_skjalamyndarar", "dt_isadg_skráningar", "dt_fyrirspurnir",  "dt_md5", "dt_midlun", "ds_gagnagrunnar", "dt_notendur" };
            string strSQLTEXT = string.Empty;
            foreach (string str in strTöflur) 
            {
                if (str == "dt_isdiah_vörslustofnanir")
                {
                    //þarf að búa til nýtt fall ef allt á að komast
                    string strID = strStofnanir.Remove(strStofnanir.Length - 1);
                    dtGogn = back.getDataFromTable(str, "5_1_1_auðkenni", strID);
                    strSQLTEXT += createInsert(dtGogn, "dt_isdiah_vörslustofnanir");
                }
                if (str == "dt_isaar_skjalamyndarar")
                {
                    string strID = strStofnanir.Remove(strStofnanir.Length - 1);
                    dtGogn = back.getDataFromTable(str, "5_4_2_auðkenni_vörslustofnunar", strID);
                    strSQLTEXT += createInsert(dtGogn, "dt_isaar_skjalamyndarar");
                }
                if (str == "dt_isadg_skráningar")
                {
                    //þarf að búa til nýtt fall ef allt á að komast
                    string strID = strAuðkenni.Remove(strAuðkenni.Length - 1);

                    dtGogn = back.getDataFromTable(str, "3_1_1_auðkenni", strID);
                    strSQLTEXT += createInsert(dtGogn, "dt_isadg_skráningar");
                }
                if (str == "dt_fyrirspurnir")
                {
                    string strID = strAuðkenni.Replace(".", "_").Remove(strAuðkenni.Length-1);
                    dtGogn = back.getDataFromTable(str, "gagnagrunnur", strID);
                    strSQLTEXT += createInsert(dtGogn, "dt_fyrirspurnir"); //vantar að laga slaufusviga {}
                }
                
               
                //if (str == "dt_isadg_skráningar")
                //{
                //    //þarf að búa til nýtt fall ef allt á að komast
                //    string strID = strStofnanir.Remove(strStofnanir.Length - 1);
                //    dtGogn = back.getDataFromTable(str, "vörslustofnun", strID);
                //}
              
                if (str == "dt_md5")
                {
                    //þarf að búa til nýtt fall ef allt á að komast
                    string strID = strAuðkenni.Remove(strAuðkenni.Length - 1);
                    dtGogn = back.getDataFromTable(str, "AIP", strID);
                    strSQLTEXT += createInsert(dtGogn, "dt_md5");
                }
                if (str == "dt_midlun")
                {
                    //þarf að búa til nýtt fall ef allt á að komast
                    string strID = strAuðkenni.Remove(strAuðkenni.Length - 1);
                    dtGogn = back.getDataFromTable(str, "vorsluutgafa", strID);
                    strSQLTEXT += createInsert(dtGogn, "dt_midlun");
                }
                if(str == "ds_gagnagrunnar")
                {
                    //þarf að búa til nýtt fall ef allt á að komast
                    string strID = strAuðkenni.Remove(strAuðkenni.Length - 1);
                    dtGogn = back.getDataFromTable(str, "vorsluutgafa", strID);
                    strSQLTEXT += createInsert(dtGogn, "ds_gagnagrunnar");
                }
                if(str == "dt_notendur")
                {
                    //búa til einn master notanda
                }

            }
            //vista innsertið
            strSchema = strSchema + "\\INSERT.sql";
            File.WriteAllText(strSchema, strSQLTEXT);
            //4. gera geymsluskrá á ákveðnu formati AIP-{vörslustofnin|Klasi}/vörsluútgáfuauðkenni/{geymsluskra.xlsx}
            //5. gera EAD
            //6 gera EAC-CPF.

            MessageBox.Show("Búið");
        }

        private string createInsert(DataTable dt, string strTafla)
        {
            string strRet = string.Empty;
            string strClolumns = string.Empty;
            
            foreach(DataRow dr in dt.Rows) 
            {
                strRet += "INSERT INTO db_oais_admin_afrit." + strTafla + "  VALUES (";
                foreach (DataColumn col in dt.Columns)
                {
                    string strBla = mysqlESCAPE(dr[col.ColumnName].ToString());
                    strClolumns += "'" + mysqlESCAPE(dr[col.ColumnName].ToString()) + "',";
                }
                strRet += strClolumns.Remove(strClolumns.Length - 1) + ");" + Environment.NewLine;
                strClolumns = string.Empty;
            }
            return strRet;
        }
        private string mysqlESCAPE(string strTexti)
        {
           
                strTexti = strTexti.Replace("'", "\\'");
                strTexti = strTexti.Replace("{", "\\{");
                strTexti = strTexti.Replace("}", "\\}");
           
          
            return strTexti;
        }
        private void BackupSQL(string strDest, string strDatabase)
        {
            string constring = "server = localhost; user id = root; Password = ivarBjarkLind; database =" + strDatabase + ";"; //gera þetta abastract gegnum stillingar
                                                                                                                               // string constring = "server=localhost;user=root;pwd=qwerty;database=test;";

            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(strDest);
                        conn.Close();
                        cmd.Dispose();
                        conn.Dispose();

                    }
                }
            }
        }

        private void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            m_prgBackup.Maximum = files.Length;
            m_prgBackup.Step = 1;
            m_prgBackup.Value = 0;
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
                m_prgBackup.PerformStep();
                m_lblBackupStatus.Text = file; // string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            m_prgBackup.Maximum = folders.Length;
            m_prgBackup.Step = 1;
           m_prgBackup.Value = 0;
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
                m_prgBackup.PerformStep();
                m_lblBackupStatus.Text = folder; // string.Format("{0}/{1}", m_prgBackup.Value, m_prgBackup.Maximum);
                Application.DoEvents();
            }
        }
    }
}
