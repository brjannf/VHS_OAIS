using cClassOAIS;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace MHR_LEIT
{
    public partial class frmAtvik : Form
    {
        string m_strGrunnur = "";
        string m_strHeiti = "";
        cMIdlun midlun = new cMIdlun();
        string m_strRoot = string.Empty;
        DataTable m_dtStofnanir = new DataTable();
        public frmAtvik()
        {
            InitializeComponent();
        }

        public frmAtvik(string strGrunnur, string strHeiti, cNotandi virkurnotandi)
        {
            InitializeComponent();
            //keyri þetta einfalt fyrst

            cVorsluutgafur varsla = new cVorsluutgafur();
            varsla.m_bAfrit = virkurnotandi.m_bAfrit;
            varsla.getVörsluútgáfu(strGrunnur.Replace("_", "."));
            m_strRoot = varsla.slod;


            m_strGrunnur = strGrunnur;
            m_strHeiti = strHeiti;

            fyllaAtvik();

            string strSQL = "SELECT * FROM institutions i;";
            m_dtStofnanir = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
            m_lbFyrirTæki.Text = m_dtStofnanir.Rows[0]["CompanyName"].ToString() + "(kt: " + m_dtStofnanir.Rows[0]["CompanyKt"].ToString() + ")";
            fyllaSvid();

        }
        public void fyllaAtvik()
        {
            string strSQL = "Show tables";
            DataTable dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur); //þarf að sortera þetta í stafrófsröð
            m_trwFlokkar.Nodes.Clear();

            foreach (DataRow row in dt.Rows)
            {

                switch (row[0].ToString())
                {
                    case "notification":
                        {
                            strSQL = "Select * from notification";
                            DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                            m_trwFlokkar.Nodes.Add("notification", "Ábendingar (" + dtNoti.Rows.Count + ")");
                        }
                        break;
                    case "nearmissaccident":
                        {
                            strSQL = "Select * from nearmissaccident";
                            DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                            m_trwFlokkar.Nodes.Add("nearmissaccident", "Næstum slys (" + dtNoti.Rows.Count + ")");
                            // m_trwFlokkar.Nodes.Add("nearmissaccident", "Næstum slys");
                        }
                        break;
                    case "accident_minor":
                        {
                            strSQL = "Select * from accident_minor";
                            DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                            m_trwFlokkar.Nodes.Add("accident_minor", "Minniháttar slys (" + dtNoti.Rows.Count + ")");
                            //   m_trwFlokkar.Nodes.Add("accident_minor", "Minniháttar slys");
                        }
                        break;
                    case "accident_remote":
                        {
                            strSQL = "Select * from accident_remote";
                            DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                            m_trwFlokkar.Nodes.Add("accident_remote", "Fjarveruslys (" + dtNoti.Rows.Count + ")");
                            //  m_trwFlokkar.Nodes.Add("accident_remote", "Fjarveruslys");
                        }
                        break;
                    case "violence":
                        {
                            strSQL = "Select * from violence";
                            DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                            m_trwFlokkar.Nodes.Add("violence", "Ógn/Áreiti/Einelti (" + dtNoti.Rows.Count + ")");
                            //m_trwFlokkar.Nodes.Add("violence", "Ógn/Áreiti/Einelti");
                        }
                        break;
                    case "childinjury":
                        {
                            strSQL = "Select * from childinjury";
                            DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                            m_trwFlokkar.Nodes.Add("childinjury", "Slys á barni (" + dtNoti.Rows.Count + ")");
                            // m_trwFlokkar.Nodes.Add("childinjury", "Slys á barni");
                        }
                        break;

                    default:
                        break;
                }

            }
            //   Id, CompanyName, CompanyKt, DivisionName, DepartmentName
        }
        private void fyllaSvid()
        {
            // DataRow[] drSvid =  m_dtStofnanir.Select("Id = " + m_dtStofnanir.Rows[0]["Id"].ToString());
            DataTable uniqueTable = m_dtStofnanir.DefaultView.ToTable(true, "DivisionName");
            DataRow r = uniqueTable.NewRow();
            r["DivisionName"] = "(Veldu svið)";
            uniqueTable.Rows.InsertAt(r, 0);


            m_comSvid.DisplayMember = "DivisionName";
            m_comSvid.ValueMember = "Id";
            m_comSvid.DataSource = uniqueTable;
            fyllaDeild(m_comDeild.SelectedText);
        }

        private void fyllaDeild(string strSvid)
        {
            if (strSvid == string.Empty || strSvid == "(Veldu svið)")
            {
                DataTable uniqueTable = m_dtStofnanir.DefaultView.ToTable(true, "DepartmentName");
                DataRow r = uniqueTable.NewRow();
                r["DepartmentName"] = "(Veldu deild)";
                uniqueTable.Rows.InsertAt(r, 0);


                m_comDeild.DisplayMember = "DepartmentName";
                m_comDeild.ValueMember = "Id";
                m_comDeild.DataSource = uniqueTable; ;
            }
            else
            {
                DataRow[] drDeild = m_dtStofnanir.Select("DivisionName = '" + strSvid + "'");
                DataTable dtDeild = new DataTable();
                dtDeild.Columns.Add("Id");
                dtDeild.Columns.Add("DepartmentName");
                foreach (DataRow row in drDeild)
                {
                    DataRow r = dtDeild.NewRow();
                    r["Id"] = row["Id"];
                    r["DepartmentName"] = row["DepartmentName"];
                    dtDeild.Rows.Add(r);
                }
                DataRow r2 = dtDeild.NewRow();
                r2["DepartmentName"] = "(Veldu deild)";
                dtDeild.Rows.InsertAt(r2, 0);
                m_comDeild.DisplayMember = "DepartmentName";
                m_comDeild.ValueMember = "Id";
                m_comDeild.DataSource = dtDeild;
            }
        }

        private void m_trwFlokkar_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (m_trwFlokkar.Focused)
            {
                if (e.Node.Level == 0)
                {
                    e.Node.Nodes.Clear();
                    DataTable dt = new DataTable();
                    string strSQL = ""; 

                    if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex == 0)
                    {
                        strSQL = "SELECT IncidentDate, RecordedName, Id FROM " + e.Node.Name + " WHERE DivisionName ='" + m_comSvid.Text + "'"    ;
                        dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                    }
                    if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex != 0)
                    {
                        strSQL = "SELECT IncidentDate, RecordedName, Id FROM " + e.Node.Name + " WHERE DepartmentName ='" + m_comDeild.Text + "'";
                        dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                    }
                    if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex != 0)
                    {
                        strSQL = "SELECT IncidentDate, RecordedName, Id FROM " + e.Node.Name + " WHERE DivisionName ='" + m_comSvid.Text + "' AND DepartmentName ='" + m_comDeild.Text + "'";
                        dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                    }

                    if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex == 0)
                    {
                        strSQL = "SELECT IncidentDate, RecordedName, Id FROM " + e.Node.Name;
                        dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                    }
                    

                    foreach (DataRow row in dt.Rows)
                    {
                        TreeNode node = new TreeNode(row["IncidentDate"].ToString() + " Skráð af " + row["RecordedName"].ToString());
                        node.Tag = row["Id"].ToString();

                        e.Node.Nodes.Add(node);
                        e.Node.Expand();
                    }
                }
                if (e.Node.Level == 1)
                {
                    fyllaRichTextBox(e);
                }
            }
        }

        public void fyllaRichTextBox(TreeViewEventArgs e)
        {

            //************************1 ATVIKIÐ SJÁLFT*******************
            string strSQL = "Select * from " + e.Node.Parent.Name + " WHERE Id = '" + e.Node.Tag + "'";
            DataTable dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
            //m_dgvStoff.DataSource = dt;
            string strFaersla = "";
            richTextBox1.Clear();
            switch (e.Node.Parent.Name)
            {
                case "notification":
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 16f, richTextBox1.SelectionFont.Style);
                    richTextBox1.AppendText("Atviksskýrsla - Ábending"); //bæta við tegund skýrslu
                    break;
                case "accident_minor":
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 16f, richTextBox1.SelectionFont.Style);
                    richTextBox1.AppendText("Atviksskýrsla - minniháttar slys"); //bæta við tegund skýrslu
                    break;
                case "accident_remote":
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 16f, richTextBox1.SelectionFont.Style);
                    richTextBox1.AppendText("Atviksskýrsla - fjarveruslys"); //bæta við tegund skýrslu
                    break;
                case "childinjury":
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 16f, richTextBox1.SelectionFont.Style);
                    richTextBox1.AppendText("Atviksskýrsla - slys á barni"); //bæta við tegund skýrslu
                    break;
                case "nearmissaccident":
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 16f, richTextBox1.SelectionFont.Style);
                    richTextBox1.AppendText("Atviksskýrsla - næstum slys"); //bæta við tegund skýrslu
                    break;
                case "violence":
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 16f, richTextBox1.SelectionFont.Style);
                    richTextBox1.AppendText("Atviksskýrsla - ógn/Áreiti/Einelti"); //bæta við tegund skýrslu
                    break;

                default:
                    break;
            }

            //richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 16f,  richTextBox1.SelectionFont.Style);
            //richTextBox1.AppendText("Atviksskýrsla "); //bæta við tegund skýrslu
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(Environment.NewLine);
            foreach (DataColumn col in dt.Columns)
            {
                switch (col.ColumnName)
                {
                    case "CompanyName":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Fyirtæki: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "CompanyKt":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Kennitala fyrirtækis: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        richTextBox1.AppendText(Environment.NewLine);
                        break;
                    case "DivisionName":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Svið: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "DepartmentName":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Deild: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "IncidentDate":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Dagsetning atviks: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "RecordedName":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Tilkynnandi atviks: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "RocordedEmail":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Tölvupóstur tilkynnanda: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "RocordedPhone":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Sími tilkynnanda: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        richTextBox1.AppendText(Environment.NewLine);
                        break;
                    case "Name":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Nafn slasaða: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "Email":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Tölvupóstur slasaða: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "Phone":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Símanúmer slasaða: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "Job":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Starfsheiti slasaða: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "Gender":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Kyn slasaða: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "Age":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Aldur slasaða: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "SSN":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Kennitala slasaða: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "NationalityName":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Þjóðerni slasaða: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        richTextBox1.AppendText(Environment.NewLine);
                        break;
                    case "Place":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Staðsetning atviks: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "Address":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Staðsetning atviks (gata): ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        richTextBox1.AppendText(Environment.NewLine);
                        break;
                    case "Description":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Lýsing á  atviki: ");
                        richTextBox1.AppendText(Environment.NewLine);
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;
                    case "ProposedImprovements":
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Tillögur að úrbótum: ");
                        richTextBox1.AppendText(Environment.NewLine);
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(dt.Rows[0][col].ToString() + Environment.NewLine);
                        break;



                    default:
                        break;
                }
              
            }
            //*******************vitni*******************************

            richTextBox1.AppendText(Environment.NewLine);
        
            strSQL = "SELECT table_name FROM information_schema.tables WHERE table_schema = " + "'" + m_strGrunnur + "' and TABLE_NAME = '" + e.Node.Parent.Name + "_Witness'";
            dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
            if (dt.Rows.Count != 0) //ef til er vitnatafla
            {
                strSQL = "SELECT * FROM " + e.Node.Parent.Name + "_Witness WHERE parent_id = '" + e.Node.Tag + "'";
                DataTable dtWitness = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                if (dtWitness.Rows.Count != 0)
                {
                    foreach (DataRow r in dtWitness.Rows)
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Vitni: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(r["Name"].ToString() + Environment.NewLine);
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Tölvupóstur vitnis: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(r["Email"].ToString() + Environment.NewLine);
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Símanúmer vitnis: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(r["Phone"].ToString() + Environment.NewLine);
                    }
                    richTextBox1.AppendText(Environment.NewLine);
                }    
             }

            //*****************viðbrögð*************************
            strSQL = "SELECT table_name FROM information_schema.tables WHERE table_schema = " + "'" + m_strGrunnur + "' and TABLE_NAME = '" + e.Node.Parent.Name + "_reactionafteraccident'";

            dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);

            if (dt.Rows.Count > 0)
            {
                strSQL = "SELECT * FROM " + e.Node.Parent.Name + "_reactionafteraccident WHERE parent_id = '" + e.Node.Tag + "'";
                DataTable dtReaction = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                if(dtReaction.Rows.Count != 0)
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                    richTextBox1.AppendText("Viðbrögð við slysi" + Environment.NewLine);

                    foreach (DataRow r in dtReaction.Rows)
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(r["Name"].ToString() + " - Já" + Environment.NewLine);
                    }
                  
                }
            }
            //***************************VINNUEFTIRLITIÐ*******************

            strSQL = "SELECT table_name FROM information_schema.tables WHERE table_schema = " + "'" + m_strGrunnur + "' and TABLE_NAME = '" + e.Node.Parent.Name + "_veaccident'";

            dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
            if(dt.Rows.Count > 0)
            {
                strSQL = "SELECT * FROM " + e.Node.Parent.Name + "_veaccident WHERE parent_id = '" + e.Node.Tag + "'";
                DataTable dtVEAccident = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                if(dtVEAccident.Rows.Count > 0)
                {
                    richTextBox1.AppendText(Environment.NewLine);
                 
                   
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 14f, richTextBox1.SelectionFont.Style);
                    richTextBox1.AppendText("Skýrsla vinnueftirlits" + Environment.NewLine);
                    richTextBox1.AppendText(Environment.NewLine);

                    foreach (DataColumn col in dtVEAccident.Columns)
                    {

                        switch (col.ColumnName)
                        {
                            case "SizeOfEnterpriseName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Stærð stofnunar: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "CompanyHireDate":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Ráðningardagur: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "StartOfWorkingDay":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Byrjaði í vinnu: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEMunicipalityName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Sveitarfélag: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEWorkingEnviromentGroupName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Vinnuumhverfi (flokkur): ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEWorkingEnviromentName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Vinnuumhverfi: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEWorkstationName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Vinnustöð: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEEmploymentStatusOfTheVictimName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Starfsstaða: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEWorkTimeName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Hve lengi unnið: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEWorkingHoursName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Í hverskonar vinnutilhögun: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEVictimsOccupationMajorGroupName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Tegund vinnu (flokkur): ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEVictimsOccupationSubMajorGroupName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Tegund vinnu (yfirflokkur): ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEVictimsOccupationMinorGroupName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Tegund vinnu (undirflokkur): ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEVictimsOccupationUnitGroupName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Starfsflokkur: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEAbsenceDueToAccidentName":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Fjarverudagar: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VESpecificPhysicalActivityMostSevere":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Helstu líkamlegu athafnir: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEWorkDeviationMostSevere":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Helstu frávik vegna vinnu: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEContactModeOfInjuryMostSevere":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Alvarlegustu orsakir slyss: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VETypeOfInjuryMostSevere":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Alvarlegustu afleiðingar slyss: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            case "VEPartOfBodyInjuredMostSevere":
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText("Hvaða líkamshlutar?: ");
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText(dtVEAccident.Rows[0][col].ToString() + Environment.NewLine);
                                break;
                            default:
                                break;
                        }

                    }
                        
                }
            }
            //********************skjöl******************
            strSQL = "SELECT table_name FROM information_schema.tables WHERE table_schema = " + "'" + m_strGrunnur + "' and TABLE_NAME = '" + e.Node.Parent.Name + "_files'";

            dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
            if (dt.Rows.Count > 0)
            {
                strSQL = "SELECT * FROM " + e.Node.Parent.Name + "_files WHERE parent_id = '" + e.Node.Tag + "'";
                DataTable dtFiles = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                if (dtFiles.Rows.Count > 0)
                {
                    richTextBox1.AppendText(Environment.NewLine);
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, 14f, richTextBox1.SelectionFont.Style);
                    richTextBox1.AppendText("Skjöl" + Environment.NewLine);
                    richTextBox1.AppendText(Environment.NewLine);

                    foreach (DataRow r in dtFiles.Rows)
                    {

                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Titill skráar: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(r["Name"].ToString() + Environment.NewLine);
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText("Lýsing: ");
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(r["Description"].ToString() + Environment.NewLine);
                        richTextBox1.AppendText(Environment.NewLine);

                        int iID = Convert.ToInt32(r["DokumentID"]);
                        double dColl = Convert.ToInt32(iID) / 10000;
                        if (iID == 1)
                        {
                            dColl = 1;
                        }
                        else
                        {
                            dColl = dColl + 1;
                        }
                        string strValid = m_strRoot + "\\Documents\\docCollection" + dColl.ToString() + "\\" + iID;
                       
                        InsertImageViaClipboard(richTextBox1, Image.FromFile(strValid + "\\1.tif"));
                        richTextBox1.AppendText(Environment.NewLine);

                    }
                }
            }
           
        }
      

        private void InsertImageViaClipboard(RichTextBox rtb, Image img)
        {
            var old = Clipboard.GetDataObject();
            try
            {
                Clipboard.SetImage(img);
                rtb.Focus();
                rtb.Paste(); // simplest approach
            }
            finally
            {
                if (old != null) Clipboard.SetDataObject(old);
            }
        }
        public void InsertImageIntoRichTextBox(RichTextBox rtb, string imagePath)
        {
            try
            {
                // 1. Load the image from the specified file path
                using (Image img = Image.FromFile(imagePath))
                {
                    // 2. Backup existing clipboard data to avoid overwriting user data permanently
                    IDataObject originalClipboardData = Clipboard.GetDataObject();

                    // 3. Set the image onto the clipboard
                    Clipboard.SetImage(img);

                    // 4. Paste the image into the RichTextBox
                    rtb.Paste();

                    // 5. Restore the user's original clipboard data
                    if (originalClipboardData != null)
                    {
                        Clipboard.SetDataObject(originalClipboardData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting image: {ex.Message}");
            }
        }
        public void InsertImageToRichTextBox(string strPath)
        {
            // 1. Load the image from a file path
            string imagePath = strPath;

            using (Image img = Image.FromFile(imagePath))
            {
                // 2. Copy the image to the clipboard
                Clipboard.SetImage(img);

                // 3. Move the caret/cursor to where you want the image (optional)
                richTextBox1.SelectionStart = richTextBox1.TextLength;

                // 4. Paste the image into the RichTextBox
                richTextBox1.Paste();
            }

            // 5. Clear the clipboard afterward to be a good citizen (optional)
            Clipboard.Clear();
        }

        private void m_comSvid_SelectedIndexChanged(object sender, EventArgs e)
        {
            fyllaDeild(m_comSvid.Text);
        }

        private void m_btnFiltera_Click(object sender, EventArgs e)
        {
            string strSQL = "Show tables";
            DataTable dt = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
            m_trwFlokkar.Nodes.Clear();
            foreach (DataRow row in dt.Rows)
            {

                switch (row[0].ToString())
                {
                    case "notification":
                        {
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from notification where DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("notification", "Ábendingar (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from notification where DepartmentName = '" + m_comDeild.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("notification", "Ábendingar (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from notification where DepartmentName = '" + m_comDeild.Text + "' and DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("notification", "Ábendingar (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from notification";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                m_trwFlokkar.Nodes.Add("notification", "Ábendingar (" + dtNoti.Rows.Count + ")");
                            }

                            //  m_trwFlokkar.Nodes.Add("notification", "Ábendingar");
                        }
                        break;
                    case "nearmissaccident":
                        {
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from nearmissaccident where DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("nearmissaccident", "Næstum slys (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from nearmissaccident where DepartmentName = '" + m_comDeild.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("nearmissaccident", "Næstum slys (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from nearmissaccident where DepartmentName = '" + m_comDeild.Text + "' and DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("nearmissaccident", "Næstum slys (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from nearmissaccident";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                m_trwFlokkar.Nodes.Add("nearmissaccident", "Næstum slys (" + dtNoti.Rows.Count + ")");
                            }


                            // m_trwFlokkar.Nodes.Add("nearmissaccident", "Næstum slys");
                        }
                        break;
                    case "accident_minor":
                        {
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from accident_minor where DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("accident_minor", "Minniháttar slys (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from accident_minor where DepartmentName = '" + m_comDeild.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("accident_minor", "Minniháttar slys (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from accident_minor where DepartmentName = '" + m_comDeild.Text + "' and DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("accident_minor", "Minniháttar slys (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from accident_minor";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                m_trwFlokkar.Nodes.Add("accident_minor", "Minniháttar slys (" + dtNoti.Rows.Count + ")");
                            }
                            //m_trwFlokkar.Nodes.Add("accident_minor", "Minniháttar slys");
                        }
                        break;
                    case "accident_remote":
                        {
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from accident_remote where DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("accident_remote", "Fjarveruslys (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from accident_remote where DepartmentName = '" + m_comDeild.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("accident_remote", "Fjarveruslys (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from accident_remote where DepartmentName = '" + m_comDeild.Text + "' and DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("accident_remote", "Fjarveruslys (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from accident_remote";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                m_trwFlokkar.Nodes.Add("accident_remote", "Fjarveruslys (" + dtNoti.Rows.Count + ")");
                            }
                            //  m_trwFlokkar.Nodes.Add("accident_remote", "Fjarveruslys");
                        }
                        break;
                    case "violence":
                        {
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from violence where DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("violence", "Ógn/Áreiti/Einelti (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from violence where DepartmentName = '" + m_comDeild.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("violence", "Ógn/Áreiti/Einelti (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from violence where DepartmentName = '" + m_comDeild.Text + "' and DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("violence", "Ógn/Áreiti/Einelti (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from violence";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                m_trwFlokkar.Nodes.Add("violence", "Ógn/Áreiti/Einelti (" + dtNoti.Rows.Count + ")");
                            }
                            // m_trwFlokkar.Nodes.Add("violence", "Ógn/Áreiti/Einelti");
                        }
                        break;
                    case "childinjury":
                        {
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from childinjury where DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("childinjury", "Slys á barni (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from childinjury where DepartmentName = '" + m_comDeild.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("childinjury", "Slys á barni (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex != 0 && m_comDeild.SelectedIndex != 0)
                            {
                                strSQL = "Select * from childinjury where DepartmentName = '" + m_comDeild.Text + "' and DivisionName = '" + m_comSvid.Text + "'";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                if (dtNoti.Rows.Count > 0)
                                {
                                    m_trwFlokkar.Nodes.Add("childinjury", "Slys á barni (" + dtNoti.Rows.Count + ")");
                                }
                            }
                            if (m_comSvid.SelectedIndex == 0 && m_comDeild.SelectedIndex == 0)
                            {
                                strSQL = "Select * from childinjury";
                                DataTable dtNoti = midlun.keyraFyrirspurn(strSQL, m_strGrunnur);
                                m_trwFlokkar.Nodes.Add("childinjury", "Slys á barni (" + dtNoti.Rows.Count + ")");
                            }
                            // m_trwFlokkar.Nodes.Add("childinjury", "Slys á barni");
                        }
                        break;

                    default:
                        break;
                }

            }
        }

        private void m_btnHreinsa_Click(object sender, EventArgs e)
        {
            m_comSvid.SelectedIndex = 0;
            m_comDeild.SelectedIndex = 0;
            fyllaAtvik();
        }
    }
   
}
