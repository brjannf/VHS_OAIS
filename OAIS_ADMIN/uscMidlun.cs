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
using Google.Protobuf.WellKnownTypes;

namespace OAIS_ADMIN
{
    public partial class uscMidlun : UserControl
    {
        public cNotandi virkurnotandi = new cNotandi();
        private cSkjalamyndari skjalamyndari = new cSkjalamyndari();
        private cVorslustofnun vörslustofnun = new cVorslustofnun();
        private cSkjalaskra skrá = new cSkjalaskra();
        private cMIdlun midlun = new cMIdlun();
        public uscMidlun()
        {
            InitializeComponent();
            fyllaVorsluUtgafur();
        }
        private void fyllaVorsluUtgafur()
        {
            cSkjalaskra skrá = new cSkjalaskra();
            DataTable dt = skrá.getVörsluútgáfur();

            m_dgvUtgafur.AutoGenerateColumns = false;
            m_dgvUtgafur.DataSource = formatTable(dt);
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
                    string strslod = senderGrid.Rows[e.RowIndex].Cells["colSlod"].Value.ToString();
                    //1. auðkenni vörsluútgáfu
                    string strAuðkenni = senderGrid.Rows[e.RowIndex].Cells["colVorsluutgafu"].Value.ToString();
                    skrá.getSkraning(strAuðkenni);
                    //2. auðkenni vörslustofnunar
                    string strVarsla = senderGrid.Rows[e.RowIndex].Cells["colVorslustofnun"].Value.ToString();
                    vörslustofnun.getVörslustofnun(strVarsla);
                    //3. auðkenni skjalamyndara
                    string strSkjalam = senderGrid.Rows[e.RowIndex].Cells["colSkjalamyndari"].Value.ToString();
                    skjalamyndari.getSkjalamyndaraByAuðkenni(strSkjalam);

                    midla(strslod);
                }
            }

        }

        private void midla(string strSlod)
        {

            //1. búa til gagnagrunninn
            string strDataBase = skrá.auðkenni_3_1_1;
            strDataBase = strDataBase.Replace(".", "_");
            midlun.createDatabase(strDataBase);
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
            if (columnsus.Contains("dbName"))
            {
                strDataBase = ds.Tables[0].Rows[0]["dbName"].ToString().Replace("\"", "").Replace(" ", "_");
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
                        midlun.tegund_grunns = "Skráarkerfi"; //þarf að finna betur úr þessu eða láta notanda velja.
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
                MessageBox.Show("Búið");
            }
        }

        private void m_dgvFyrirSpurnir_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns["colBtnPrófa"].Index == e.ColumnIndex)
                {
                    //0. ná í stlóð á vörsluútgáfu
                    string strFyrirspurn = senderGrid.Rows[e.RowIndex].Cells["colFyrirFyrirspurn"].Value.ToString();
                    string strDatabase = senderGrid.Rows[e.RowIndex].Cells["colFyrirDatabase"].Value.ToString();
                    frmFyrirspurnProfa frmTest = new frmFyrirspurnProfa(strFyrirspurn, strDatabase);
                    frmTest.Show();
                }
                if (senderGrid.Columns["colBtnVista"].Index == e.ColumnIndex)
                {
                    string strFyrirspurn = senderGrid.Rows[e.RowIndex].Cells["colFyrirFyrirspurn"].Value.ToString();
                    string strDatabase = senderGrid.Rows[e.RowIndex].Cells["colFyrirDatabase"].Value.ToString();
                    string strNafn = senderGrid.Rows[e.RowIndex].Cells["colFyrirNafn"].Value.ToString();
                    string strLysing = senderGrid.Rows[e.RowIndex].Cells["colFyrirLýsing"].Value.ToString();
                    midlun.vistaFyrirSpurn(strFyrirspurn, strDatabase, strNafn, strLysing);
                    MessageBox.Show("Fyrirspurn vistuð");
                }
            }
           
        }
    }
}
