﻿namespace MHR_LEIT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            m_chbOrdmyndir = new CheckBox();
            label7 = new Label();
            label6 = new Label();
            m_comFjoldiFaerslnaLeit = new ComboBox();
            m_lblSkraEnding = new Label();
            m_comExtensions = new ComboBox();
            m_lblVorsluUtgafur = new Label();
            m_comVorsluUtgafur = new ComboBox();
            m_lblGagangrunnar = new Label();
            m_comGagnagrunnar = new ComboBox();
            m_lblLeitarnidurstodur = new Label();
            m_btnHreinsa = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            m_dtEnd = new DateTimePicker();
            m_dtpStart = new DateTimePicker();
            m_comSkjalamyndari = new ComboBox();
            m_comVorslustofnun = new ComboBox();
            m_btnLeita = new Button();
            m_tboLeitOrd = new TextBox();
            splitContainer4 = new SplitContainer();
            m_dgvLeit = new DataGridView();
            coltitillvorsluUtgafu = new DataGridViewTextBoxColumn();
            colDocTitel = new DataGridViewTextBoxColumn();
            colExtensions = new DataGridViewTextBoxColumn();
            colLastWriten = new DataGridViewTextBoxColumn();
            colMal = new DataGridViewTextBoxColumn();
            colInnhaldSkjals = new DataGridViewTextBoxColumn();
            colAdgengi = new DataGridViewTextBoxColumn();
            colSkjalamyndari = new DataGridViewTextBoxColumn();
            colVorslustsofnun = new DataGridViewTextBoxColumn();
            colGagnaGrunnur = new DataGridViewTextBoxColumn();
            colDocID = new DataGridViewTextBoxColumn();
            colTegund_gagnagrunns = new DataGridViewTextBoxColumn();
            colDocOpnaAfrit = new DataGridViewButtonColumn();
            colDocFrum = new DataGridViewButtonColumn();
            colDocInnihald = new DataGridViewButtonColumn();
            colDocPanta = new DataGridViewButtonColumn();
            colDocVarslaID = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            colVarslaStofnunID = new DataGridViewTextBoxColumn();
            colSkjalMyndID = new DataGridViewTextBoxColumn();
            colDocMalID = new DataGridViewTextBoxColumn();
            m_pnlPageing = new Panel();
            m_btnSidasta = new Button();
            m_btnFyrsta = new Button();
            m_lblSida = new Label();
            m_btnFyrri = new Button();
            m_lblSidaAf = new Label();
            m_comPages = new ComboBox();
            m_btnNaesta = new Button();
            m_pnlNotandi = new Panel();
            m_btnKeyrAfritInn = new Button();
            m_chbAfrit = new CheckBox();
            m_lblVillaInnSkraning = new Label();
            m_btnInnskra = new Button();
            m_lblLykilOrd = new Label();
            m_tboLykilOrd = new TextBox();
            m_lblNotendaNafn = new Label();
            m_tboNoterndaNafn = new TextBox();
            m_tacMain = new TabControl();
            m_tapLeit = new TabPage();
            m_tapAfgreidsla = new TabPage();
            splitContainer2 = new SplitContainer();
            m_trwDIP = new TreeView();
            splitContainer3 = new SplitContainer();
            m_grbTegundSkjala = new GroupBox();
            m_rdbFrum = new RadioButton();
            m_rdbFrumTif = new RadioButton();
            m_chbPDF = new CheckBox();
            m_rdbTiff = new RadioButton();
            m_lblKarfaNr = new Label();
            m_btnPantAthUpp = new Button();
            m_grbAthugasemdir = new GroupBox();
            m_tboPontunAth = new TextBox();
            m_lblPontunstatus = new Label();
            m_prbPontun = new ProgressBar();
            m_btnTæma = new Button();
            m_lblLanthegi = new Label();
            m_btnOpna = new Button();
            m_btnKlaraPontun = new Button();
            label5 = new Label();
            m_comLanthegar = new ComboBox();
            m_btnNyrLanthegi = new Button();
            m_grbDIP = new GroupBox();
            m_tacPontun = new TabControl();
            m_tapPontunSkra = new TabPage();
            m_dgvDIPList = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colTitill = new DataGridViewTextBoxColumn();
            colHeitiUtgáfu = new DataGridViewTextBoxColumn();
            colSkraOpna = new DataGridViewButtonColumn();
            colPDF = new DataGridViewButtonColumn();
            colSkraRemove = new DataGridViewButtonColumn();
            colSkraVarslaID = new DataGridViewTextBoxColumn();
            m_tapPontunMalakerfi = new TabPage();
            m_dgvDIPmal = new DataGridView();
            colMalSkraID = new DataGridViewTextBoxColumn();
            colMalTitillSkjals = new DataGridViewTextBoxColumn();
            colMalTitilMals = new DataGridViewTextBoxColumn();
            colMalTitillVorslu = new DataGridViewTextBoxColumn();
            colMalOpna = new DataGridViewButtonColumn();
            colBtnFjarlaegja = new DataGridViewButtonColumn();
            colMalVarslaUtgafaID = new DataGridViewTextBoxColumn();
            colMalPDF = new DataGridViewButtonColumn();
            colMalGagnGrunnur = new DataGridViewTextBoxColumn();
            m_tapPontunGagnagrunnar = new TabPage();
            m_dgvDIPGagnagrunnar = new DataGridView();
            colGagnHeiti = new DataGridViewTextBoxColumn();
            colLeitskilyrdi = new DataGridViewTextBoxColumn();
            colGagnHeitivorslu = new DataGridViewTextBoxColumn();
            colGagnOpna = new DataGridViewButtonColumn();
            colGagnRemove = new DataGridViewButtonColumn();
            colGagnSQL = new DataGridViewTextBoxColumn();
            m_tapUmsjon = new TabPage();
            m_tacUmsjon = new TabControl();
            m_tapNotendur = new TabPage();
            uscNotendur1 = new uscNotendur();
            m_tapLanthegar = new TabPage();
            usclanthegar1 = new usclanthegar();
            m_tapUppfæra = new TabPage();
            splitContainer5 = new SplitContainer();
            m_btnGetData = new Button();
            m_btnLagaToflur = new Button();
            splitContainer6 = new SplitContainer();
            m_dgvUtgafur = new DataGridView();
            colHeitiVarslaMidlun = new DataGridViewTextBoxColumn();
            colMidlunTaka = new DataGridViewCheckBoxColumn();
            colAudkenniVarslaMidlun = new DataGridViewTextBoxColumn();
            m_grbInsertStatus = new GroupBox();
            m_lblStatusDoing = new Label();
            m_lblStatusVarslaTaka = new Label();
            m_lblImportStatusHeild = new Label();
            m_prgImportStatusHeild = new ProgressBar();
            m_btnKeyraVorsluInn = new Button();
            m_tapLysigogn = new TabPage();
            m_dgvVorsluUtgafur = new DataGridView();
            colUtgafurAuðkenni = new DataGridViewTextBoxColumn();
            colUtgafaTitill = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            colUtgafaVorslustofnun = new DataGridViewTextBoxColumn();
            colUtgafaSkjalam = new DataGridViewTextBoxColumn();
            colUtgafaStaerd = new DataGridViewTextBoxColumn();
            colUtgafaTimabil = new DataGridViewTextBoxColumn();
            colUtgafaAdgangur = new DataGridViewTextBoxColumn();
            colUtgafurFrum = new DataGridViewCheckBoxColumn();
            colUtgafaDagsSkraningar = new DataGridViewTextBoxColumn();
            colUtgafaHverSkradi = new DataGridViewTextBoxColumn();
            colTegund = new DataGridViewTextBoxColumn();
            colUtgafaSkjalamAudkenni = new DataGridViewTextBoxColumn();
            comBtnVörslustofnun = new DataGridViewButtonColumn();
            comBtnSkjalamyndari = new DataGridViewButtonColumn();
            colBtnGeymsluskra = new DataGridViewButtonColumn();
            colUtgafaVorsluAudkenni = new DataGridViewTextBoxColumn();
            colUtgafaSlod = new DataGridViewTextBoxColumn();
            menuStrip1 = new MenuStrip();
            m_tomUtskra = new ToolStripMenuItem();
            m_tomHjalpCHM = new ToolStripMenuItem();
            m_tomHjalpPDF = new ToolStripMenuItem();
            folderBrowserDialog1 = new FolderBrowserDialog();
            helpProvider1 = new HelpProvider();
            helpProvider2 = new HelpProvider();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvLeit).BeginInit();
            m_pnlPageing.SuspendLayout();
            m_pnlNotandi.SuspendLayout();
            m_tacMain.SuspendLayout();
            m_tapLeit.SuspendLayout();
            m_tapAfgreidsla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            m_grbTegundSkjala.SuspendLayout();
            m_grbAthugasemdir.SuspendLayout();
            m_grbDIP.SuspendLayout();
            m_tacPontun.SuspendLayout();
            m_tapPontunSkra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvDIPList).BeginInit();
            m_tapPontunMalakerfi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvDIPmal).BeginInit();
            m_tapPontunGagnagrunnar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvDIPGagnagrunnar).BeginInit();
            m_tapUmsjon.SuspendLayout();
            m_tacUmsjon.SuspendLayout();
            m_tapNotendur.SuspendLayout();
            m_tapLanthegar.SuspendLayout();
            m_tapUppfæra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer6).BeginInit();
            splitContainer6.Panel1.SuspendLayout();
            splitContainer6.Panel2.SuspendLayout();
            splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvUtgafur).BeginInit();
            m_grbInsertStatus.SuspendLayout();
            m_tapLysigogn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvVorsluUtgafur).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(m_chbOrdmyndir);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(m_comFjoldiFaerslnaLeit);
            splitContainer1.Panel1.Controls.Add(m_lblSkraEnding);
            splitContainer1.Panel1.Controls.Add(m_comExtensions);
            splitContainer1.Panel1.Controls.Add(m_lblVorsluUtgafur);
            splitContainer1.Panel1.Controls.Add(m_comVorsluUtgafur);
            splitContainer1.Panel1.Controls.Add(m_lblGagangrunnar);
            splitContainer1.Panel1.Controls.Add(m_comGagnagrunnar);
            splitContainer1.Panel1.Controls.Add(m_lblLeitarnidurstodur);
            splitContainer1.Panel1.Controls.Add(m_btnHreinsa);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(m_dtEnd);
            splitContainer1.Panel1.Controls.Add(m_dtpStart);
            splitContainer1.Panel1.Controls.Add(m_comSkjalamyndari);
            splitContainer1.Panel1.Controls.Add(m_comVorslustofnun);
            splitContainer1.Panel1.Controls.Add(m_btnLeita);
            splitContainer1.Panel1.Controls.Add(m_tboLeitOrd);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer4);
            splitContainer1.Size = new Size(1390, 386);
            splitContainer1.SplitterDistance = 124;
            splitContainer1.TabIndex = 0;
            // 
            // m_chbOrdmyndir
            // 
            m_chbOrdmyndir.AutoSize = true;
            m_chbOrdmyndir.Location = new Point(1157, 58);
            m_chbOrdmyndir.Name = "m_chbOrdmyndir";
            m_chbOrdmyndir.Size = new Size(642, 19);
            m_chbOrdmyndir.TabIndex = 22;
            m_chbOrdmyndir.Text = "Leita eftir öllum orðmyndum (Beygingarlýsing íslensks nútímamáls. Stofnun Árna Magnússonar í íslenskum fræðum)";
            m_chbOrdmyndir.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1306, 92);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 21;
            label7.Text = "færslur á síðu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1157, 90);
            label6.Name = "label6";
            label6.Size = new Size(32, 15);
            label6.TabIndex = 20;
            label6.Text = "Sýna";
            // 
            // m_comFjoldiFaerslnaLeit
            // 
            m_comFjoldiFaerslnaLeit.DropDownStyle = ComboBoxStyle.DropDownList;
            m_comFjoldiFaerslnaLeit.FormattingEnabled = true;
            m_comFjoldiFaerslnaLeit.Items.AddRange(new object[] { "10", "50", "100", "500", "1000" });
            m_comFjoldiFaerslnaLeit.Location = new Point(1204, 87);
            m_comFjoldiFaerslnaLeit.Name = "m_comFjoldiFaerslnaLeit";
            m_comFjoldiFaerslnaLeit.Size = new Size(87, 23);
            m_comFjoldiFaerslnaLeit.TabIndex = 19;
            m_comFjoldiFaerslnaLeit.SelectedIndexChanged += m_comFjoldiFaerslnaLeit_SelectedIndexChanged;
            // 
            // m_lblSkraEnding
            // 
            m_lblSkraEnding.AutoSize = true;
            m_lblSkraEnding.Location = new Point(394, 84);
            m_lblSkraEnding.Name = "m_lblSkraEnding";
            m_lblSkraEnding.Size = new Size(82, 15);
            m_lblSkraEnding.TabIndex = 18;
            m_lblSkraEnding.Text = "Skráaendingar";
            // 
            // m_comExtensions
            // 
            m_comExtensions.FormattingEnabled = true;
            m_comExtensions.Location = new Point(504, 81);
            m_comExtensions.Name = "m_comExtensions";
            m_comExtensions.Size = new Size(145, 23);
            m_comExtensions.TabIndex = 17;
            // 
            // m_lblVorsluUtgafur
            // 
            m_lblVorsluUtgafur.AutoSize = true;
            m_lblVorsluUtgafur.Location = new Point(747, 121);
            m_lblVorsluUtgafur.Name = "m_lblVorsluUtgafur";
            m_lblVorsluUtgafur.Size = new Size(78, 15);
            m_lblVorsluUtgafur.TabIndex = 16;
            m_lblVorsluUtgafur.Text = "Vörsluútgáfur";
            // 
            // m_comVorsluUtgafur
            // 
            m_comVorsluUtgafur.DropDownStyle = ComboBoxStyle.DropDownList;
            m_comVorsluUtgafur.FormattingEnabled = true;
            m_comVorsluUtgafur.Location = new Point(847, 116);
            m_comVorsluUtgafur.Name = "m_comVorsluUtgafur";
            m_comVorsluUtgafur.Size = new Size(295, 23);
            m_comVorsluUtgafur.TabIndex = 15;
            m_comVorsluUtgafur.SelectedIndexChanged += m_comVorsluUtgafur_SelectedIndexChanged;
            // 
            // m_lblGagangrunnar
            // 
            m_lblGagangrunnar.AutoSize = true;
            m_lblGagangrunnar.Location = new Point(1176, 130);
            m_lblGagangrunnar.Name = "m_lblGagangrunnar";
            m_lblGagangrunnar.Size = new Size(83, 15);
            m_lblGagangrunnar.TabIndex = 14;
            m_lblGagangrunnar.Text = "Gagnagrunnar";
            // 
            // m_comGagnagrunnar
            // 
            m_comGagnagrunnar.FormattingEnabled = true;
            m_comGagnagrunnar.Location = new Point(1326, 124);
            m_comGagnagrunnar.Name = "m_comGagnagrunnar";
            m_comGagnagrunnar.Size = new Size(145, 23);
            m_comGagnagrunnar.TabIndex = 13;
            m_comGagnagrunnar.SelectedIndexChanged += n_comGagnagrunnar_SelectedIndexChanged;
            // 
            // m_lblLeitarnidurstodur
            // 
            m_lblLeitarnidurstodur.AutoSize = true;
            m_lblLeitarnidurstodur.Location = new Point(54, 57);
            m_lblLeitarnidurstodur.Name = "m_lblLeitarnidurstodur";
            m_lblLeitarnidurstodur.Size = new Size(38, 15);
            m_lblLeitarnidurstodur.TabIndex = 12;
            m_lblLeitarnidurstodur.Text = "label5";
            m_lblLeitarnidurstodur.Visible = false;
            // 
            // m_btnHreinsa
            // 
            m_btnHreinsa.Location = new Point(1261, 21);
            m_btnHreinsa.Name = "m_btnHreinsa";
            m_btnHreinsa.Size = new Size(75, 23);
            m_btnHreinsa.TabIndex = 11;
            m_btnHreinsa.Text = "Hreinsa";
            m_btnHreinsa.UseVisualStyleBackColor = true;
            m_btnHreinsa.Click += m_btnHreinsa_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 124);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 10;
            label4.Text = "Endadagsetning";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 90);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 9;
            label3.Text = "Upphafsdagsetning";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(747, 92);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 8;
            label2.Text = "Skjalamyndari";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(747, 61);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 7;
            label1.Text = "Vörslustofnun";
            // 
            // m_dtEnd
            // 
            m_dtEnd.Checked = false;
            m_dtEnd.Location = new Point(180, 124);
            m_dtEnd.Name = "m_dtEnd";
            m_dtEnd.ShowCheckBox = true;
            m_dtEnd.Size = new Size(172, 23);
            m_dtEnd.TabIndex = 6;
            // 
            // m_dtpStart
            // 
            m_dtpStart.Checked = false;
            m_dtpStart.Location = new Point(180, 84);
            m_dtpStart.Name = "m_dtpStart";
            m_dtpStart.ShowCheckBox = true;
            m_dtpStart.Size = new Size(172, 23);
            m_dtpStart.TabIndex = 5;
            // 
            // m_comSkjalamyndari
            // 
            m_comSkjalamyndari.DropDownStyle = ComboBoxStyle.DropDownList;
            m_comSkjalamyndari.FormattingEnabled = true;
            m_comSkjalamyndari.Location = new Point(847, 87);
            m_comSkjalamyndari.Name = "m_comSkjalamyndari";
            m_comSkjalamyndari.Size = new Size(295, 23);
            m_comSkjalamyndari.TabIndex = 4;
            m_comSkjalamyndari.SelectedIndexChanged += m_comSkjalamyndari_SelectedIndexChanged;
            // 
            // m_comVorslustofnun
            // 
            m_comVorslustofnun.DropDownStyle = ComboBoxStyle.DropDownList;
            m_comVorslustofnun.FormattingEnabled = true;
            m_comVorslustofnun.Location = new Point(847, 58);
            m_comVorslustofnun.Name = "m_comVorslustofnun";
            m_comVorslustofnun.Size = new Size(295, 23);
            m_comVorslustofnun.TabIndex = 3;
            m_comVorslustofnun.SelectedIndexChanged += m_comVorslustofnun_SelectedIndexChanged;
            // 
            // m_btnLeita
            // 
            m_btnLeita.Location = new Point(1157, 21);
            m_btnLeita.Name = "m_btnLeita";
            m_btnLeita.Size = new Size(75, 23);
            m_btnLeita.TabIndex = 1;
            m_btnLeita.Text = "Leita";
            m_btnLeita.UseVisualStyleBackColor = true;
            m_btnLeita.Click += m_btnLeita_Click;
            // 
            // m_tboLeitOrd
            // 
            m_tboLeitOrd.Location = new Point(53, 22);
            m_tboLeitOrd.Name = "m_tboLeitOrd";
            m_tboLeitOrd.Size = new Size(1089, 23);
            m_tboLeitOrd.TabIndex = 0;
            m_tboLeitOrd.KeyDown += m_tboLeitOrd_KeyDown;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(m_dgvLeit);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(m_pnlPageing);
            splitContainer4.Size = new Size(1390, 258);
            splitContainer4.SplitterDistance = 199;
            splitContainer4.TabIndex = 1;
            // 
            // m_dgvLeit
            // 
            m_dgvLeit.AllowUserToAddRows = false;
            m_dgvLeit.AllowUserToDeleteRows = false;
            m_dgvLeit.AllowUserToOrderColumns = true;
            m_dgvLeit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvLeit.Columns.AddRange(new DataGridViewColumn[] { coltitillvorsluUtgafu, colDocTitel, colExtensions, colLastWriten, colMal, colInnhaldSkjals, colAdgengi, colSkjalamyndari, colVorslustsofnun, colGagnaGrunnur, colDocID, colTegund_gagnagrunns, colDocOpnaAfrit, colDocFrum, colDocInnihald, colDocPanta, colDocVarslaID, dataGridViewTextBoxColumn1, colVarslaStofnunID, colSkjalMyndID, colDocMalID });
            m_dgvLeit.Dock = DockStyle.Fill;
            m_dgvLeit.Location = new Point(0, 0);
            m_dgvLeit.Name = "m_dgvLeit";
            m_dgvLeit.ReadOnly = true;
            m_dgvLeit.RowHeadersVisible = false;
            m_dgvLeit.RowTemplate.Height = 25;
            m_dgvLeit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            m_dgvLeit.Size = new Size(1390, 199);
            m_dgvLeit.TabIndex = 0;
            m_dgvLeit.CellClick += m_dgvLeit_CellClick;
            // 
            // coltitillvorsluUtgafu
            // 
            coltitillvorsluUtgafu.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            coltitillvorsluUtgafu.DataPropertyName = "titill_vorsluutgafu";
            coltitillvorsluUtgafu.HeaderText = "Titill vörsluútgáfu";
            coltitillvorsluUtgafu.Name = "coltitillvorsluUtgafu";
            coltitillvorsluUtgafu.ReadOnly = true;
            coltitillvorsluUtgafu.Width = 114;
            // 
            // colDocTitel
            // 
            colDocTitel.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDocTitel.DataPropertyName = "doctitill";
            colDocTitel.HeaderText = "Titill skjals";
            colDocTitel.Name = "colDocTitel";
            colDocTitel.ReadOnly = true;
            // 
            // colExtensions
            // 
            colExtensions.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colExtensions.DataPropertyName = "extension";
            colExtensions.HeaderText = "Skáaending";
            colExtensions.Name = "colExtensions";
            colExtensions.ReadOnly = true;
            colExtensions.Width = 93;
            // 
            // colLastWriten
            // 
            colLastWriten.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colLastWriten.DataPropertyName = "docLastWriten";
            colLastWriten.HeaderText = "Síðast breytt";
            colLastWriten.Name = "colLastWriten";
            colLastWriten.ReadOnly = true;
            colLastWriten.Width = 89;
            // 
            // colMal
            // 
            colMal.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMal.DataPropertyName = "maltitill";
            colMal.HeaderText = "Titill máls";
            colMal.Name = "colMal";
            colMal.ReadOnly = true;
            colMal.Width = 76;
            // 
            // colInnhaldSkjals
            // 
            colInnhaldSkjals.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colInnhaldSkjals.DataPropertyName = "docInnihald";
            colInnhaldSkjals.HeaderText = "Innihald skjals";
            colInnhaldSkjals.Name = "colInnhaldSkjals";
            colInnhaldSkjals.ReadOnly = true;
            colInnhaldSkjals.Visible = false;
            // 
            // colAdgengi
            // 
            colAdgengi.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colAdgengi.DataPropertyName = "skjalaskra_adgengi";
            colAdgengi.HeaderText = "Aðgengistakmarkanir";
            colAdgengi.Name = "colAdgengi";
            colAdgengi.ReadOnly = true;
            colAdgengi.Width = 145;
            // 
            // colSkjalamyndari
            // 
            colSkjalamyndari.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colSkjalamyndari.DataPropertyName = "skjalamyndari_heiti";
            colSkjalamyndari.HeaderText = "Skjalamyndari";
            colSkjalamyndari.Name = "colSkjalamyndari";
            colSkjalamyndari.ReadOnly = true;
            colSkjalamyndari.Width = 106;
            // 
            // colVorslustsofnun
            // 
            colVorslustsofnun.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colVorslustsofnun.DataPropertyName = "vorslustofnun_heiti";
            colVorslustsofnun.HeaderText = "Vörslustofnun";
            colVorslustsofnun.Name = "colVorslustsofnun";
            colVorslustsofnun.ReadOnly = true;
            colVorslustsofnun.Width = 105;
            // 
            // colGagnaGrunnur
            // 
            colGagnaGrunnur.DataPropertyName = "heiti_gagangrunns";
            colGagnaGrunnur.HeaderText = "Gagnagrunnur";
            colGagnaGrunnur.Name = "colGagnaGrunnur";
            colGagnaGrunnur.ReadOnly = true;
            colGagnaGrunnur.Visible = false;
            // 
            // colDocID
            // 
            colDocID.DataPropertyName = "documentid";
            colDocID.HeaderText = "Auðkenni skjals";
            colDocID.Name = "colDocID";
            colDocID.ReadOnly = true;
            colDocID.Visible = false;
            // 
            // colTegund_gagnagrunns
            // 
            colTegund_gagnagrunns.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTegund_gagnagrunns.DataPropertyName = "tegund_grunns";
            colTegund_gagnagrunns.HeaderText = "Tegund";
            colTegund_gagnagrunns.Name = "colTegund_gagnagrunns";
            colTegund_gagnagrunns.ReadOnly = true;
            colTegund_gagnagrunns.Width = 71;
            // 
            // colDocOpnaAfrit
            // 
            colDocOpnaAfrit.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDocOpnaAfrit.HeaderText = "Opna afrit (tif)";
            colDocOpnaAfrit.Name = "colDocOpnaAfrit";
            colDocOpnaAfrit.ReadOnly = true;
            colDocOpnaAfrit.Text = "Afrit";
            colDocOpnaAfrit.UseColumnTextForButtonValue = true;
            colDocOpnaAfrit.Width = 62;
            // 
            // colDocFrum
            // 
            colDocFrum.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDocFrum.HeaderText = "Opna frumrit";
            colDocFrum.Name = "colDocFrum";
            colDocFrum.ReadOnly = true;
            colDocFrum.Text = "Frumrit";
            colDocFrum.UseColumnTextForButtonValue = true;
            colDocFrum.Width = 74;
            // 
            // colDocInnihald
            // 
            colDocInnihald.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDocInnihald.HeaderText = "Sjá innhald";
            colDocInnihald.Name = "colDocInnihald";
            colDocInnihald.ReadOnly = true;
            colDocInnihald.Text = "Innhald";
            colDocInnihald.UseColumnTextForButtonValue = true;
            colDocInnihald.Width = 64;
            // 
            // colDocPanta
            // 
            colDocPanta.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDocPanta.HeaderText = "Setja í körfu";
            colDocPanta.Name = "colDocPanta";
            colDocPanta.ReadOnly = true;
            colDocPanta.Text = "Panta";
            colDocPanta.UseColumnTextForButtonValue = true;
            colDocPanta.Width = 68;
            // 
            // colDocVarslaID
            // 
            colDocVarslaID.DataPropertyName = "vorsluutgafa";
            colDocVarslaID.HeaderText = "Vörlsuútgáf";
            colDocVarslaID.Name = "colDocVarslaID";
            colDocVarslaID.ReadOnly = true;
            colDocVarslaID.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "documentid";
            dataGridViewTextBoxColumn1.HeaderText = "id doc";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // colVarslaStofnunID
            // 
            colVarslaStofnunID.DataPropertyName = "vorslustofnun_audkenni";
            colVarslaStofnunID.HeaderText = "varsla auðkenni";
            colVarslaStofnunID.Name = "colVarslaStofnunID";
            colVarslaStofnunID.ReadOnly = true;
            colVarslaStofnunID.Visible = false;
            // 
            // colSkjalMyndID
            // 
            colSkjalMyndID.DataPropertyName = "skjalamyndari_audkenni";
            colSkjalMyndID.HeaderText = "Auðkenni skjalamyndara";
            colSkjalMyndID.Name = "colSkjalMyndID";
            colSkjalMyndID.ReadOnly = true;
            colSkjalMyndID.Visible = false;
            // 
            // colDocMalID
            // 
            colDocMalID.DataPropertyName = "malID";
            colDocMalID.HeaderText = "MALID";
            colDocMalID.Name = "colDocMalID";
            colDocMalID.ReadOnly = true;
            colDocMalID.Visible = false;
            // 
            // m_pnlPageing
            // 
            m_pnlPageing.Controls.Add(m_btnSidasta);
            m_pnlPageing.Controls.Add(m_btnFyrsta);
            m_pnlPageing.Controls.Add(m_lblSida);
            m_pnlPageing.Controls.Add(m_btnFyrri);
            m_pnlPageing.Controls.Add(m_lblSidaAf);
            m_pnlPageing.Controls.Add(m_comPages);
            m_pnlPageing.Controls.Add(m_btnNaesta);
            m_pnlPageing.Dock = DockStyle.Fill;
            m_pnlPageing.Location = new Point(0, 0);
            m_pnlPageing.Name = "m_pnlPageing";
            m_pnlPageing.Size = new Size(1390, 55);
            m_pnlPageing.TabIndex = 8;
            m_pnlPageing.Visible = false;
            // 
            // m_btnSidasta
            // 
            m_btnSidasta.Location = new Point(942, 24);
            m_btnSidasta.Name = "m_btnSidasta";
            m_btnSidasta.Size = new Size(75, 23);
            m_btnSidasta.TabIndex = 4;
            m_btnSidasta.Text = ">|";
            m_btnSidasta.UseVisualStyleBackColor = true;
            m_btnSidasta.Click += m_btnSidasta_Click;
            // 
            // m_btnFyrsta
            // 
            m_btnFyrsta.Location = new Point(401, 23);
            m_btnFyrsta.Name = "m_btnFyrsta";
            m_btnFyrsta.Size = new Size(75, 23);
            m_btnFyrsta.TabIndex = 2;
            m_btnFyrsta.Text = "|<";
            m_btnFyrsta.UseVisualStyleBackColor = true;
            m_btnFyrsta.Click += m_btnFyrsta_Click;
            // 
            // m_lblSida
            // 
            m_lblSida.AutoSize = true;
            m_lblSida.Location = new Point(597, 31);
            m_lblSida.Name = "m_lblSida";
            m_lblSida.Size = new Size(32, 15);
            m_lblSida.TabIndex = 6;
            m_lblSida.Text = "Síða ";
            // 
            // m_btnFyrri
            // 
            m_btnFyrri.Location = new Point(504, 24);
            m_btnFyrri.Name = "m_btnFyrri";
            m_btnFyrri.Size = new Size(75, 23);
            m_btnFyrri.TabIndex = 1;
            m_btnFyrri.Text = "<";
            m_btnFyrri.UseVisualStyleBackColor = true;
            m_btnFyrri.Click += m_btnFyrri_Click;
            // 
            // m_lblSidaAf
            // 
            m_lblSidaAf.AutoSize = true;
            m_lblSidaAf.Location = new Point(754, 31);
            m_lblSidaAf.Name = "m_lblSidaAf";
            m_lblSidaAf.Size = new Size(17, 15);
            m_lblSidaAf.TabIndex = 7;
            m_lblSidaAf.Text = "af";
            // 
            // m_comPages
            // 
            m_comPages.FormattingEnabled = true;
            m_comPages.Location = new Point(666, 25);
            m_comPages.Name = "m_comPages";
            m_comPages.Size = new Size(72, 23);
            m_comPages.TabIndex = 5;
            m_comPages.SelectedIndexChanged += m_comPages_SelectedIndexChanged;
            // 
            // m_btnNaesta
            // 
            m_btnNaesta.Location = new Point(847, 24);
            m_btnNaesta.Name = "m_btnNaesta";
            m_btnNaesta.Size = new Size(75, 23);
            m_btnNaesta.TabIndex = 3;
            m_btnNaesta.Text = ">";
            m_btnNaesta.UseVisualStyleBackColor = true;
            m_btnNaesta.Click += m_btnNaesta_Click;
            // 
            // m_pnlNotandi
            // 
            m_pnlNotandi.Controls.Add(m_btnKeyrAfritInn);
            m_pnlNotandi.Controls.Add(m_chbAfrit);
            m_pnlNotandi.Controls.Add(m_lblVillaInnSkraning);
            m_pnlNotandi.Controls.Add(m_btnInnskra);
            m_pnlNotandi.Controls.Add(m_lblLykilOrd);
            m_pnlNotandi.Controls.Add(m_tboLykilOrd);
            m_pnlNotandi.Controls.Add(m_lblNotendaNafn);
            m_pnlNotandi.Controls.Add(m_tboNoterndaNafn);
            m_pnlNotandi.Location = new Point(651, 513);
            m_pnlNotandi.Name = "m_pnlNotandi";
            m_pnlNotandi.Size = new Size(371, 257);
            m_pnlNotandi.TabIndex = 3;
            m_pnlNotandi.Paint += m_pnlNotandi_Paint;
            // 
            // m_btnKeyrAfritInn
            // 
            m_btnKeyrAfritInn.Location = new Point(118, 336);
            m_btnKeyrAfritInn.Name = "m_btnKeyrAfritInn";
            m_btnKeyrAfritInn.Size = new Size(276, 23);
            m_btnKeyrAfritInn.TabIndex = 12;
            m_btnKeyrAfritInn.Text = "Keyra inn afrit frá Héraðsskjalasafni";
            m_btnKeyrAfritInn.UseVisualStyleBackColor = true;
            m_btnKeyrAfritInn.Visible = false;
            m_btnKeyrAfritInn.Click += m_btnKeyrAfritInn_Click;
            // 
            // m_chbAfrit
            // 
            m_chbAfrit.AutoSize = true;
            m_chbAfrit.Location = new Point(117, 284);
            m_chbAfrit.Name = "m_chbAfrit";
            m_chbAfrit.Size = new Size(135, 19);
            m_chbAfrit.TabIndex = 11;
            m_chbAfrit.Text = "Opna afritunargrunn";
            m_chbAfrit.UseVisualStyleBackColor = true;
            m_chbAfrit.Visible = false;
            // 
            // m_lblVillaInnSkraning
            // 
            m_lblVillaInnSkraning.AutoSize = true;
            m_lblVillaInnSkraning.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            m_lblVillaInnSkraning.ForeColor = Color.IndianRed;
            m_lblVillaInnSkraning.Location = new Point(118, 306);
            m_lblVillaInnSkraning.Name = "m_lblVillaInnSkraning";
            m_lblVillaInnSkraning.Size = new Size(52, 21);
            m_lblVillaInnSkraning.TabIndex = 10;
            m_lblVillaInnSkraning.Text = "label1";
            m_lblVillaInnSkraning.Visible = false;
            // 
            // m_btnInnskra
            // 
            m_btnInnskra.Location = new Point(295, 249);
            m_btnInnskra.Name = "m_btnInnskra";
            m_btnInnskra.Size = new Size(116, 23);
            m_btnInnskra.TabIndex = 9;
            m_btnInnskra.Text = "Innskráning";
            m_btnInnskra.UseVisualStyleBackColor = true;
            m_btnInnskra.Click += m_btnInnskra_Click;
            // 
            // m_lblLykilOrd
            // 
            m_lblLykilOrd.AutoSize = true;
            m_lblLykilOrd.Location = new Point(117, 203);
            m_lblLykilOrd.Name = "m_lblLykilOrd";
            m_lblLykilOrd.Size = new Size(51, 15);
            m_lblLykilOrd.TabIndex = 8;
            m_lblLykilOrd.Text = "Lykilorð:";
            // 
            // m_tboLykilOrd
            // 
            m_tboLykilOrd.Location = new Point(185, 200);
            m_tboLykilOrd.Name = "m_tboLykilOrd";
            m_tboLykilOrd.PasswordChar = '*';
            m_tboLykilOrd.Size = new Size(226, 23);
            m_tboLykilOrd.TabIndex = 7;
            m_tboLykilOrd.KeyUp += m_tboLykilOrd_KeyUp;
            // 
            // m_lblNotendaNafn
            // 
            m_lblNotendaNafn.AutoSize = true;
            m_lblNotendaNafn.Location = new Point(88, 153);
            m_lblNotendaNafn.Name = "m_lblNotendaNafn";
            m_lblNotendaNafn.Size = new Size(80, 15);
            m_lblNotendaNafn.TabIndex = 6;
            m_lblNotendaNafn.Text = "Notendanafn:";
            // 
            // m_tboNoterndaNafn
            // 
            m_tboNoterndaNafn.Location = new Point(185, 150);
            m_tboNoterndaNafn.Name = "m_tboNoterndaNafn";
            m_tboNoterndaNafn.Size = new Size(226, 23);
            m_tboNoterndaNafn.TabIndex = 5;
            m_tboNoterndaNafn.KeyUp += m_tboNoterndaNafn_KeyUp;
            // 
            // m_tacMain
            // 
            m_tacMain.Controls.Add(m_tapLeit);
            m_tacMain.Controls.Add(m_tapAfgreidsla);
            m_tacMain.Controls.Add(m_tapUmsjon);
            m_tacMain.Location = new Point(10, 61);
            m_tacMain.Name = "m_tacMain";
            m_tacMain.SelectedIndex = 0;
            m_tacMain.Size = new Size(1404, 420);
            m_tacMain.TabIndex = 1;
            m_tacMain.SelectedIndexChanged += m_tacMain_SelectedIndexChanged;
            // 
            // m_tapLeit
            // 
            m_tapLeit.Controls.Add(splitContainer1);
            m_tapLeit.Location = new Point(4, 24);
            m_tapLeit.Name = "m_tapLeit";
            m_tapLeit.Padding = new Padding(3);
            m_tapLeit.Size = new Size(1396, 392);
            m_tapLeit.TabIndex = 0;
            m_tapLeit.Text = "Leit";
            m_tapLeit.UseVisualStyleBackColor = true;
            // 
            // m_tapAfgreidsla
            // 
            m_tapAfgreidsla.Controls.Add(splitContainer2);
            m_tapAfgreidsla.Location = new Point(4, 24);
            m_tapAfgreidsla.Name = "m_tapAfgreidsla";
            m_tapAfgreidsla.Padding = new Padding(3);
            m_tapAfgreidsla.Size = new Size(1396, 392);
            m_tapAfgreidsla.TabIndex = 1;
            m_tapAfgreidsla.Text = "Afgreiðsla";
            m_tapAfgreidsla.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(m_trwDIP);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(1390, 386);
            splitContainer2.SplitterDistance = 274;
            splitContainer2.TabIndex = 3;
            // 
            // m_trwDIP
            // 
            m_trwDIP.Dock = DockStyle.Fill;
            m_trwDIP.Location = new Point(0, 0);
            m_trwDIP.Name = "m_trwDIP";
            m_trwDIP.Size = new Size(274, 386);
            m_trwDIP.TabIndex = 0;
            m_trwDIP.AfterSelect += m_trwDIP_AfterSelect;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(m_grbTegundSkjala);
            splitContainer3.Panel1.Controls.Add(m_lblKarfaNr);
            splitContainer3.Panel1.Controls.Add(m_btnPantAthUpp);
            splitContainer3.Panel1.Controls.Add(m_grbAthugasemdir);
            splitContainer3.Panel1.Controls.Add(m_lblPontunstatus);
            splitContainer3.Panel1.Controls.Add(m_prbPontun);
            splitContainer3.Panel1.Controls.Add(m_btnTæma);
            splitContainer3.Panel1.Controls.Add(m_lblLanthegi);
            splitContainer3.Panel1.Controls.Add(m_btnOpna);
            splitContainer3.Panel1.Controls.Add(m_btnKlaraPontun);
            splitContainer3.Panel1.Controls.Add(label5);
            splitContainer3.Panel1.Controls.Add(m_comLanthegar);
            splitContainer3.Panel1.Controls.Add(m_btnNyrLanthegi);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(m_grbDIP);
            splitContainer3.Size = new Size(1112, 386);
            splitContainer3.SplitterDistance = 244;
            splitContainer3.TabIndex = 3;
            // 
            // m_grbTegundSkjala
            // 
            m_grbTegundSkjala.Controls.Add(m_rdbFrum);
            m_grbTegundSkjala.Controls.Add(m_rdbFrumTif);
            m_grbTegundSkjala.Controls.Add(m_chbPDF);
            m_grbTegundSkjala.Controls.Add(m_rdbTiff);
            m_grbTegundSkjala.Location = new Point(632, 159);
            m_grbTegundSkjala.Name = "m_grbTegundSkjala";
            m_grbTegundSkjala.Size = new Size(135, 100);
            m_grbTegundSkjala.TabIndex = 19;
            m_grbTegundSkjala.TabStop = false;
            m_grbTegundSkjala.Text = "Tegund skjala";
            // 
            // m_rdbFrum
            // 
            m_rdbFrum.AutoSize = true;
            m_rdbFrum.Location = new Point(19, 36);
            m_rdbFrum.Name = "m_rdbFrum";
            m_rdbFrum.Size = new Size(101, 19);
            m_rdbFrum.TabIndex = 16;
            m_rdbFrum.Text = "Aðeins frumrit";
            m_rdbFrum.UseVisualStyleBackColor = true;
            // 
            // m_rdbFrumTif
            // 
            m_rdbFrumTif.AutoSize = true;
            m_rdbFrumTif.Checked = true;
            m_rdbFrumTif.Location = new Point(19, 75);
            m_rdbFrumTif.Name = "m_rdbFrumTif";
            m_rdbFrumTif.Size = new Size(99, 19);
            m_rdbFrumTif.TabIndex = 18;
            m_rdbFrumTif.TabStop = true;
            m_rdbFrumTif.Text = "Furmrit og tiff";
            m_rdbFrumTif.UseVisualStyleBackColor = true;
            // 
            // m_chbPDF
            // 
            m_chbPDF.AutoSize = true;
            m_chbPDF.Location = new Point(22, 20);
            m_chbPDF.Name = "m_chbPDF";
            m_chbPDF.Size = new Size(80, 19);
            m_chbPDF.TabIndex = 13;
            m_chbPDF.Text = "Búa til pdf";
            m_chbPDF.UseVisualStyleBackColor = true;
            // 
            // m_rdbTiff
            // 
            m_rdbTiff.AutoSize = true;
            m_rdbTiff.Location = new Point(19, 56);
            m_rdbTiff.Name = "m_rdbTiff";
            m_rdbTiff.Size = new Size(79, 19);
            m_rdbTiff.TabIndex = 17;
            m_rdbTiff.Text = "Aðeins tiff";
            m_rdbTiff.UseVisualStyleBackColor = true;
            // 
            // m_lblKarfaNr
            // 
            m_lblKarfaNr.AutoSize = true;
            m_lblKarfaNr.Location = new Point(92, 72);
            m_lblKarfaNr.Name = "m_lblKarfaNr";
            m_lblKarfaNr.Size = new Size(38, 15);
            m_lblKarfaNr.TabIndex = 12;
            m_lblKarfaNr.Text = "label8";
            // 
            // m_btnPantAthUpp
            // 
            m_btnPantAthUpp.Location = new Point(790, 203);
            m_btnPantAthUpp.Name = "m_btnPantAthUpp";
            m_btnPantAthUpp.Size = new Size(194, 23);
            m_btnPantAthUpp.TabIndex = 11;
            m_btnPantAthUpp.Text = "Uppfæra athugasemdir";
            m_btnPantAthUpp.UseVisualStyleBackColor = true;
            m_btnPantAthUpp.Click += m_btnPantAthUpp_Click;
            // 
            // m_grbAthugasemdir
            // 
            m_grbAthugasemdir.Controls.Add(m_tboPontunAth);
            m_grbAthugasemdir.Location = new Point(787, 7);
            m_grbAthugasemdir.Name = "m_grbAthugasemdir";
            m_grbAthugasemdir.Size = new Size(334, 190);
            m_grbAthugasemdir.TabIndex = 10;
            m_grbAthugasemdir.TabStop = false;
            m_grbAthugasemdir.Text = "Athugasemdir pöntunar";
            // 
            // m_tboPontunAth
            // 
            m_tboPontunAth.Dock = DockStyle.Fill;
            m_tboPontunAth.Location = new Point(3, 19);
            m_tboPontunAth.Multiline = true;
            m_tboPontunAth.Name = "m_tboPontunAth";
            m_tboPontunAth.Size = new Size(328, 168);
            m_tboPontunAth.TabIndex = 9;
            // 
            // m_lblPontunstatus
            // 
            m_lblPontunstatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            m_lblPontunstatus.AutoSize = true;
            m_lblPontunstatus.Location = new Point(539, 213);
            m_lblPontunstatus.Name = "m_lblPontunstatus";
            m_lblPontunstatus.Size = new Size(38, 15);
            m_lblPontunstatus.TabIndex = 8;
            m_lblPontunstatus.Text = "label7";
            m_lblPontunstatus.Visible = false;
            // 
            // m_prbPontun
            // 
            m_prbPontun.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            m_prbPontun.Location = new Point(88, 206);
            m_prbPontun.Name = "m_prbPontun";
            m_prbPontun.Size = new Size(417, 23);
            m_prbPontun.TabIndex = 7;
            m_prbPontun.Visible = false;
            // 
            // m_btnTæma
            // 
            m_btnTæma.Location = new Point(630, 130);
            m_btnTæma.Name = "m_btnTæma";
            m_btnTæma.Size = new Size(125, 23);
            m_btnTæma.TabIndex = 6;
            m_btnTæma.Text = "Tæma lista";
            m_btnTæma.UseVisualStyleBackColor = true;
            m_btnTæma.Click += m_btnTæma_Click;
            // 
            // m_lblLanthegi
            // 
            m_lblLanthegi.AutoSize = true;
            m_lblLanthegi.Location = new Point(88, 88);
            m_lblLanthegi.Name = "m_lblLanthegi";
            m_lblLanthegi.Size = new Size(38, 15);
            m_lblLanthegi.TabIndex = 5;
            m_lblLanthegi.Text = "label6";
            m_lblLanthegi.Visible = false;
            // 
            // m_btnOpna
            // 
            m_btnOpna.Location = new Point(630, 98);
            m_btnOpna.Name = "m_btnOpna";
            m_btnOpna.Size = new Size(125, 23);
            m_btnOpna.TabIndex = 4;
            m_btnOpna.Text = "Opna pakka";
            m_btnOpna.UseVisualStyleBackColor = true;
            m_btnOpna.Click += m_btnOpna_Click;
            // 
            // m_btnKlaraPontun
            // 
            m_btnKlaraPontun.Location = new Point(630, 69);
            m_btnKlaraPontun.Name = "m_btnKlaraPontun";
            m_btnKlaraPontun.Size = new Size(125, 23);
            m_btnKlaraPontun.TabIndex = 3;
            m_btnKlaraPontun.Text = "Klára pöntun";
            m_btnKlaraPontun.UseVisualStyleBackColor = true;
            m_btnKlaraPontun.Click += m_btnKlaraPontun_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(88, 44);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 2;
            label5.Text = "Veldu lánþega";
            // 
            // m_comLanthegar
            // 
            m_comLanthegar.FormattingEnabled = true;
            m_comLanthegar.Location = new Point(219, 40);
            m_comLanthegar.Name = "m_comLanthegar";
            m_comLanthegar.Size = new Size(352, 23);
            m_comLanthegar.TabIndex = 1;
            m_comLanthegar.SelectedIndexChanged += m_comLanthegar_SelectedIndexChanged;
            // 
            // m_btnNyrLanthegi
            // 
            m_btnNyrLanthegi.Location = new Point(630, 40);
            m_btnNyrLanthegi.Name = "m_btnNyrLanthegi";
            m_btnNyrLanthegi.Size = new Size(125, 23);
            m_btnNyrLanthegi.TabIndex = 0;
            m_btnNyrLanthegi.Text = "Nýr lánþegi";
            m_btnNyrLanthegi.UseVisualStyleBackColor = true;
            m_btnNyrLanthegi.Click += m_btnNyrLanthegi_Click;
            // 
            // m_grbDIP
            // 
            m_grbDIP.Controls.Add(m_tacPontun);
            m_grbDIP.Dock = DockStyle.Fill;
            m_grbDIP.Location = new Point(0, 0);
            m_grbDIP.Name = "m_grbDIP";
            m_grbDIP.Size = new Size(1112, 138);
            m_grbDIP.TabIndex = 3;
            m_grbDIP.TabStop = false;
            m_grbDIP.Text = "Gögn í pöntun";
            // 
            // m_tacPontun
            // 
            m_tacPontun.Controls.Add(m_tapPontunSkra);
            m_tacPontun.Controls.Add(m_tapPontunMalakerfi);
            m_tacPontun.Controls.Add(m_tapPontunGagnagrunnar);
            m_tacPontun.Dock = DockStyle.Fill;
            m_tacPontun.Location = new Point(3, 19);
            m_tacPontun.Name = "m_tacPontun";
            m_tacPontun.SelectedIndex = 0;
            m_tacPontun.Size = new Size(1106, 116);
            m_tacPontun.TabIndex = 3;
            // 
            // m_tapPontunSkra
            // 
            m_tapPontunSkra.Controls.Add(m_dgvDIPList);
            m_tapPontunSkra.Location = new Point(4, 24);
            m_tapPontunSkra.Name = "m_tapPontunSkra";
            m_tapPontunSkra.Padding = new Padding(3);
            m_tapPontunSkra.Size = new Size(1098, 88);
            m_tapPontunSkra.TabIndex = 0;
            m_tapPontunSkra.Text = "Skráarkerfi";
            m_tapPontunSkra.UseVisualStyleBackColor = true;
            // 
            // m_dgvDIPList
            // 
            m_dgvDIPList.AllowUserToAddRows = false;
            m_dgvDIPList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvDIPList.Columns.AddRange(new DataGridViewColumn[] { colID, colTitill, colHeitiUtgáfu, colSkraOpna, colPDF, colSkraRemove, colSkraVarslaID });
            m_dgvDIPList.Dock = DockStyle.Fill;
            m_dgvDIPList.Location = new Point(3, 3);
            m_dgvDIPList.Name = "m_dgvDIPList";
            m_dgvDIPList.ReadOnly = true;
            m_dgvDIPList.RowHeadersVisible = false;
            m_dgvDIPList.RowTemplate.Height = 25;
            m_dgvDIPList.Size = new Size(1092, 82);
            m_dgvDIPList.TabIndex = 2;
            m_dgvDIPList.CellClick += m_dgvDIPList_CellClick;
            // 
            // colID
            // 
            colID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colID.DataPropertyName = "skjalID";
            colID.HeaderText = "Auðkenni skjals";
            colID.Name = "colID";
            colID.ReadOnly = true;
            colID.Width = 114;
            // 
            // colTitill
            // 
            colTitill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTitill.DataPropertyName = "titill";
            colTitill.HeaderText = "Titill skjals";
            colTitill.Name = "colTitill";
            colTitill.ReadOnly = true;
            // 
            // colHeitiUtgáfu
            // 
            colHeitiUtgáfu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colHeitiUtgáfu.DataPropertyName = "heitiVorslu";
            colHeitiUtgáfu.HeaderText = "Vörsluútgáfa";
            colHeitiUtgáfu.Name = "colHeitiUtgáfu";
            colHeitiUtgáfu.ReadOnly = true;
            colHeitiUtgáfu.Width = 98;
            // 
            // colSkraOpna
            // 
            colSkraOpna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colSkraOpna.HeaderText = "Opna";
            colSkraOpna.Name = "colSkraOpna";
            colSkraOpna.ReadOnly = true;
            colSkraOpna.Text = "Opna";
            colSkraOpna.ToolTipText = "Opna skjal";
            colSkraOpna.UseColumnTextForButtonValue = true;
            colSkraOpna.Width = 42;
            // 
            // colPDF
            // 
            colPDF.HeaderText = "Búa til PDF";
            colPDF.Name = "colPDF";
            colPDF.ReadOnly = true;
            colPDF.Text = "PDF";
            colPDF.UseColumnTextForButtonValue = true;
            // 
            // colSkraRemove
            // 
            colSkraRemove.HeaderText = "Fjarlægja";
            colSkraRemove.Name = "colSkraRemove";
            colSkraRemove.ReadOnly = true;
            colSkraRemove.Text = "Fjarlægja";
            colSkraRemove.UseColumnTextForButtonValue = true;
            // 
            // colSkraVarslaID
            // 
            colSkraVarslaID.DataPropertyName = "vorsluutgafa";
            colSkraVarslaID.HeaderText = "Vörsluútgáfuauðkenni";
            colSkraVarslaID.Name = "colSkraVarslaID";
            colSkraVarslaID.ReadOnly = true;
            colSkraVarslaID.Visible = false;
            // 
            // m_tapPontunMalakerfi
            // 
            m_tapPontunMalakerfi.Controls.Add(m_dgvDIPmal);
            m_tapPontunMalakerfi.Location = new Point(4, 24);
            m_tapPontunMalakerfi.Name = "m_tapPontunMalakerfi";
            m_tapPontunMalakerfi.Padding = new Padding(3);
            m_tapPontunMalakerfi.Size = new Size(1098, 88);
            m_tapPontunMalakerfi.TabIndex = 1;
            m_tapPontunMalakerfi.Text = "Málakerfi";
            m_tapPontunMalakerfi.UseVisualStyleBackColor = true;
            // 
            // m_dgvDIPmal
            // 
            m_dgvDIPmal.AllowUserToAddRows = false;
            m_dgvDIPmal.AllowUserToDeleteRows = false;
            m_dgvDIPmal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvDIPmal.Columns.AddRange(new DataGridViewColumn[] { colMalSkraID, colMalTitillSkjals, colMalTitilMals, colMalTitillVorslu, colMalOpna, colBtnFjarlaegja, colMalVarslaUtgafaID, colMalPDF, colMalGagnGrunnur });
            m_dgvDIPmal.Dock = DockStyle.Fill;
            m_dgvDIPmal.Location = new Point(3, 3);
            m_dgvDIPmal.Name = "m_dgvDIPmal";
            m_dgvDIPmal.ReadOnly = true;
            m_dgvDIPmal.RowHeadersVisible = false;
            m_dgvDIPmal.RowTemplate.Height = 25;
            m_dgvDIPmal.Size = new Size(1092, 82);
            m_dgvDIPmal.TabIndex = 0;
            m_dgvDIPmal.CellClick += m_dgvDIPmal_CellClick;
            // 
            // colMalSkraID
            // 
            colMalSkraID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalSkraID.DataPropertyName = "Skrar";
            colMalSkraID.HeaderText = "Auðkenni skjals";
            colMalSkraID.Name = "colMalSkraID";
            colMalSkraID.ReadOnly = true;
            colMalSkraID.Width = 105;
            // 
            // colMalTitillSkjals
            // 
            colMalTitillSkjals.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMalTitillSkjals.DataPropertyName = "titill";
            colMalTitillSkjals.HeaderText = "Titill skjals";
            colMalTitillSkjals.Name = "colMalTitillSkjals";
            colMalTitillSkjals.ReadOnly = true;
            // 
            // colMalTitilMals
            // 
            colMalTitilMals.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalTitilMals.DataPropertyName = "maltitill";
            colMalTitilMals.HeaderText = "Titill máls";
            colMalTitilMals.Name = "colMalTitilMals";
            colMalTitilMals.ReadOnly = true;
            colMalTitilMals.Width = 76;
            // 
            // colMalTitillVorslu
            // 
            colMalTitillVorslu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalTitillVorslu.DataPropertyName = "heitivorslu";
            colMalTitillVorslu.HeaderText = "Heiti  vörsluútgáfu";
            colMalTitillVorslu.Name = "colMalTitillVorslu";
            colMalTitillVorslu.ReadOnly = true;
            colMalTitillVorslu.Width = 119;
            // 
            // colMalOpna
            // 
            colMalOpna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalOpna.HeaderText = "Opna";
            colMalOpna.Name = "colMalOpna";
            colMalOpna.ReadOnly = true;
            colMalOpna.Text = "Opna";
            colMalOpna.ToolTipText = "Opna skrá";
            colMalOpna.UseColumnTextForButtonValue = true;
            colMalOpna.Width = 42;
            // 
            // colBtnFjarlaegja
            // 
            colBtnFjarlaegja.HeaderText = "Fjarlægja";
            colBtnFjarlaegja.Name = "colBtnFjarlaegja";
            colBtnFjarlaegja.ReadOnly = true;
            colBtnFjarlaegja.Text = "Fjarlægja";
            colBtnFjarlaegja.UseColumnTextForButtonValue = true;
            // 
            // colMalVarslaUtgafaID
            // 
            colMalVarslaUtgafaID.DataPropertyName = "slod";
            colMalVarslaUtgafaID.HeaderText = "Vörsluauðkenni";
            colMalVarslaUtgafaID.Name = "colMalVarslaUtgafaID";
            colMalVarslaUtgafaID.ReadOnly = true;
            colMalVarslaUtgafaID.Visible = false;
            // 
            // colMalPDF
            // 
            colMalPDF.HeaderText = "Búa til PDF";
            colMalPDF.Name = "colMalPDF";
            colMalPDF.ReadOnly = true;
            colMalPDF.Text = "PDF";
            colMalPDF.UseColumnTextForButtonValue = true;
            // 
            // colMalGagnGrunnur
            // 
            colMalGagnGrunnur.DataPropertyName = "gagnagrunnur";
            colMalGagnGrunnur.HeaderText = "Gagnagrunnur";
            colMalGagnGrunnur.Name = "colMalGagnGrunnur";
            colMalGagnGrunnur.ReadOnly = true;
            colMalGagnGrunnur.Visible = false;
            // 
            // m_tapPontunGagnagrunnar
            // 
            m_tapPontunGagnagrunnar.Controls.Add(m_dgvDIPGagnagrunnar);
            m_tapPontunGagnagrunnar.Location = new Point(4, 24);
            m_tapPontunGagnagrunnar.Name = "m_tapPontunGagnagrunnar";
            m_tapPontunGagnagrunnar.Padding = new Padding(3);
            m_tapPontunGagnagrunnar.Size = new Size(1098, 88);
            m_tapPontunGagnagrunnar.TabIndex = 2;
            m_tapPontunGagnagrunnar.Text = "Gagnagrunnar";
            m_tapPontunGagnagrunnar.UseVisualStyleBackColor = true;
            // 
            // m_dgvDIPGagnagrunnar
            // 
            m_dgvDIPGagnagrunnar.AllowUserToAddRows = false;
            m_dgvDIPGagnagrunnar.AllowUserToDeleteRows = false;
            m_dgvDIPGagnagrunnar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvDIPGagnagrunnar.Columns.AddRange(new DataGridViewColumn[] { colGagnHeiti, colLeitskilyrdi, colGagnHeitivorslu, colGagnOpna, colGagnRemove, colGagnSQL });
            m_dgvDIPGagnagrunnar.Dock = DockStyle.Fill;
            m_dgvDIPGagnagrunnar.Location = new Point(3, 3);
            m_dgvDIPGagnagrunnar.Name = "m_dgvDIPGagnagrunnar";
            m_dgvDIPGagnagrunnar.ReadOnly = true;
            m_dgvDIPGagnagrunnar.RowHeadersVisible = false;
            m_dgvDIPGagnagrunnar.RowTemplate.Height = 25;
            m_dgvDIPGagnagrunnar.Size = new Size(1092, 82);
            m_dgvDIPGagnagrunnar.TabIndex = 0;
            m_dgvDIPGagnagrunnar.CellClick += m_dgvDIPGagnagrunnar_CellClick;
            // 
            // colGagnHeiti
            // 
            colGagnHeiti.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGagnHeiti.DataPropertyName = "heiti";
            colGagnHeiti.HeaderText = "Heiti gagnagrunns";
            colGagnHeiti.Name = "colGagnHeiti";
            colGagnHeiti.ReadOnly = true;
            colGagnHeiti.Width = 119;
            // 
            // colLeitskilyrdi
            // 
            colLeitskilyrdi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLeitskilyrdi.DataPropertyName = "leitarskilyrdi";
            colLeitskilyrdi.HeaderText = "Leitarskilyrði";
            colLeitskilyrdi.Name = "colLeitskilyrdi";
            colLeitskilyrdi.ReadOnly = true;
            // 
            // colGagnHeitivorslu
            // 
            colGagnHeitivorslu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGagnHeitivorslu.DataPropertyName = "heitivorslu";
            colGagnHeitivorslu.HeaderText = "Heiti vörsluútgáfu";
            colGagnHeitivorslu.Name = "colGagnHeitivorslu";
            colGagnHeitivorslu.ReadOnly = true;
            colGagnHeitivorslu.Width = 116;
            // 
            // colGagnOpna
            // 
            colGagnOpna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGagnOpna.HeaderText = "Opna";
            colGagnOpna.Name = "colGagnOpna";
            colGagnOpna.ReadOnly = true;
            colGagnOpna.Text = "Opna";
            colGagnOpna.ToolTipText = "Opna gögn";
            colGagnOpna.UseColumnTextForButtonValue = true;
            colGagnOpna.Width = 42;
            // 
            // colGagnRemove
            // 
            colGagnRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGagnRemove.HeaderText = "Fjarlægja";
            colGagnRemove.Name = "colGagnRemove";
            colGagnRemove.ReadOnly = true;
            colGagnRemove.Text = "Fjarlægja";
            colGagnRemove.UseColumnTextForButtonValue = true;
            colGagnRemove.Width = 61;
            // 
            // colGagnSQL
            // 
            colGagnSQL.DataPropertyName = "sql";
            colGagnSQL.HeaderText = "Sqlinn";
            colGagnSQL.Name = "colGagnSQL";
            colGagnSQL.ReadOnly = true;
            colGagnSQL.Visible = false;
            // 
            // m_tapUmsjon
            // 
            m_tapUmsjon.Controls.Add(m_tacUmsjon);
            m_tapUmsjon.Location = new Point(4, 24);
            m_tapUmsjon.Name = "m_tapUmsjon";
            m_tapUmsjon.Padding = new Padding(3);
            m_tapUmsjon.Size = new Size(1396, 392);
            m_tapUmsjon.TabIndex = 2;
            m_tapUmsjon.Text = "Umsjón";
            m_tapUmsjon.UseVisualStyleBackColor = true;
            // 
            // m_tacUmsjon
            // 
            m_tacUmsjon.Controls.Add(m_tapNotendur);
            m_tacUmsjon.Controls.Add(m_tapLanthegar);
            m_tacUmsjon.Controls.Add(m_tapUppfæra);
            m_tacUmsjon.Controls.Add(m_tapLysigogn);
            m_tacUmsjon.Dock = DockStyle.Fill;
            m_tacUmsjon.Location = new Point(3, 3);
            m_tacUmsjon.Name = "m_tacUmsjon";
            m_tacUmsjon.SelectedIndex = 0;
            m_tacUmsjon.Size = new Size(1390, 386);
            m_tacUmsjon.TabIndex = 0;
            m_tacUmsjon.SelectedIndexChanged += m_tacUmsjon_SelectedIndexChanged;
            // 
            // m_tapNotendur
            // 
            m_tapNotendur.Controls.Add(uscNotendur1);
            m_tapNotendur.Location = new Point(4, 24);
            m_tapNotendur.Name = "m_tapNotendur";
            m_tapNotendur.Padding = new Padding(3);
            m_tapNotendur.Size = new Size(1382, 358);
            m_tapNotendur.TabIndex = 0;
            m_tapNotendur.Text = "Notendur";
            m_tapNotendur.UseVisualStyleBackColor = true;
            // 
            // uscNotendur1
            // 
            uscNotendur1.Dock = DockStyle.Fill;
            uscNotendur1.Location = new Point(3, 3);
            uscNotendur1.Margin = new Padding(3, 4, 3, 4);
            uscNotendur1.Name = "uscNotendur1";
            uscNotendur1.Size = new Size(1376, 352);
            uscNotendur1.TabIndex = 0;
            // 
            // m_tapLanthegar
            // 
            m_tapLanthegar.Controls.Add(usclanthegar1);
            m_tapLanthegar.Location = new Point(4, 24);
            m_tapLanthegar.Name = "m_tapLanthegar";
            m_tapLanthegar.Padding = new Padding(3);
            m_tapLanthegar.Size = new Size(1382, 358);
            m_tapLanthegar.TabIndex = 1;
            m_tapLanthegar.Text = "Lánþegar";
            m_tapLanthegar.UseVisualStyleBackColor = true;
            // 
            // usclanthegar1
            // 
            usclanthegar1.Dock = DockStyle.Fill;
            usclanthegar1.Location = new Point(3, 3);
            usclanthegar1.Margin = new Padding(3, 4, 3, 4);
            usclanthegar1.Name = "usclanthegar1";
            usclanthegar1.Size = new Size(1376, 352);
            usclanthegar1.TabIndex = 0;
            // 
            // m_tapUppfæra
            // 
            m_tapUppfæra.Controls.Add(splitContainer5);
            m_tapUppfæra.Location = new Point(4, 24);
            m_tapUppfæra.Name = "m_tapUppfæra";
            m_tapUppfæra.Padding = new Padding(3);
            m_tapUppfæra.Size = new Size(1382, 358);
            m_tapUppfæra.TabIndex = 2;
            m_tapUppfæra.Text = "Færa inn gögn";
            m_tapUppfæra.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.Location = new Point(3, 3);
            splitContainer5.Margin = new Padding(3, 2, 3, 2);
            splitContainer5.Name = "splitContainer5";
            splitContainer5.Orientation = Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(m_btnGetData);
            splitContainer5.Panel1.Controls.Add(m_btnLagaToflur);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(splitContainer6);
            splitContainer5.Size = new Size(1376, 352);
            splitContainer5.SplitterDistance = 104;
            splitContainer5.SplitterWidth = 3;
            splitContainer5.TabIndex = 2;
            // 
            // m_btnGetData
            // 
            m_btnGetData.Location = new Point(735, 16);
            m_btnGetData.Name = "m_btnGetData";
            m_btnGetData.Size = new Size(182, 23);
            m_btnGetData.TabIndex = 1;
            m_btnGetData.Text = "Sækja gögn";
            m_btnGetData.UseVisualStyleBackColor = true;
            m_btnGetData.Click += m_btnGetData_Click;
            // 
            // m_btnLagaToflur
            // 
            m_btnLagaToflur.Location = new Point(735, 46);
            m_btnLagaToflur.Name = "m_btnLagaToflur";
            m_btnLagaToflur.Size = new Size(182, 23);
            m_btnLagaToflur.TabIndex = 0;
            m_btnLagaToflur.Text = "Laga töflur";
            m_btnLagaToflur.UseVisualStyleBackColor = true;
            m_btnLagaToflur.Click += m_btnLagaToflur_Click;
            // 
            // splitContainer6
            // 
            splitContainer6.Dock = DockStyle.Fill;
            splitContainer6.Location = new Point(0, 0);
            splitContainer6.Margin = new Padding(3, 2, 3, 2);
            splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            splitContainer6.Panel1.Controls.Add(m_dgvUtgafur);
            // 
            // splitContainer6.Panel2
            // 
            splitContainer6.Panel2.Controls.Add(m_grbInsertStatus);
            splitContainer6.Panel2.Controls.Add(m_btnKeyraVorsluInn);
            splitContainer6.Size = new Size(1376, 245);
            splitContainer6.SplitterDistance = 569;
            splitContainer6.TabIndex = 1;
            // 
            // m_dgvUtgafur
            // 
            m_dgvUtgafur.AllowUserToAddRows = false;
            m_dgvUtgafur.AllowUserToDeleteRows = false;
            m_dgvUtgafur.AllowUserToOrderColumns = true;
            m_dgvUtgafur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvUtgafur.Columns.AddRange(new DataGridViewColumn[] { colHeitiVarslaMidlun, colMidlunTaka, colAudkenniVarslaMidlun });
            m_dgvUtgafur.Dock = DockStyle.Fill;
            m_dgvUtgafur.Location = new Point(0, 0);
            m_dgvUtgafur.Margin = new Padding(3, 2, 3, 2);
            m_dgvUtgafur.Name = "m_dgvUtgafur";
            m_dgvUtgafur.RowHeadersVisible = false;
            m_dgvUtgafur.RowTemplate.Height = 29;
            m_dgvUtgafur.Size = new Size(569, 245);
            m_dgvUtgafur.TabIndex = 0;
            m_dgvUtgafur.CellContentClick += m_dgvUtgafur_CellContentClick;
            // 
            // colHeitiVarslaMidlun
            // 
            colHeitiVarslaMidlun.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHeitiVarslaMidlun.DataPropertyName = "heiti_varsla";
            colHeitiVarslaMidlun.HeaderText = "Titill vörsluútgáfu";
            colHeitiVarslaMidlun.Name = "colHeitiVarslaMidlun";
            // 
            // colMidlunTaka
            // 
            colMidlunTaka.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMidlunTaka.DataPropertyName = "taka";
            colMidlunTaka.HeaderText = "Velja vörsluútgáfu til að setja inn";
            colMidlunTaka.Name = "colMidlunTaka";
            colMidlunTaka.Width = 111;
            // 
            // colAudkenniVarslaMidlun
            // 
            colAudkenniVarslaMidlun.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colAudkenniVarslaMidlun.DataPropertyName = "audkenni";
            colAudkenniVarslaMidlun.HeaderText = "Auðkenni vörsluútgáfu";
            colAudkenniVarslaMidlun.Name = "colAudkenniVarslaMidlun";
            colAudkenniVarslaMidlun.Width = 140;
            // 
            // m_grbInsertStatus
            // 
            m_grbInsertStatus.Controls.Add(m_lblStatusDoing);
            m_grbInsertStatus.Controls.Add(m_lblStatusVarslaTaka);
            m_grbInsertStatus.Controls.Add(m_lblImportStatusHeild);
            m_grbInsertStatus.Controls.Add(m_prgImportStatusHeild);
            m_grbInsertStatus.Location = new Point(27, 62);
            m_grbInsertStatus.Name = "m_grbInsertStatus";
            m_grbInsertStatus.Size = new Size(380, 188);
            m_grbInsertStatus.TabIndex = 4;
            m_grbInsertStatus.TabStop = false;
            m_grbInsertStatus.Text = "Framganga";
            m_grbInsertStatus.Visible = false;
            // 
            // m_lblStatusDoing
            // 
            m_lblStatusDoing.AutoSize = true;
            m_lblStatusDoing.Location = new Point(41, 97);
            m_lblStatusDoing.Name = "m_lblStatusDoing";
            m_lblStatusDoing.Size = new Size(38, 15);
            m_lblStatusDoing.TabIndex = 6;
            m_lblStatusDoing.Text = "label8";
            // 
            // m_lblStatusVarslaTaka
            // 
            m_lblStatusVarslaTaka.AutoSize = true;
            m_lblStatusVarslaTaka.Location = new Point(41, 32);
            m_lblStatusVarslaTaka.Name = "m_lblStatusVarslaTaka";
            m_lblStatusVarslaTaka.Size = new Size(38, 15);
            m_lblStatusVarslaTaka.TabIndex = 5;
            m_lblStatusVarslaTaka.Text = "label8";
            // 
            // m_lblImportStatusHeild
            // 
            m_lblImportStatusHeild.AutoSize = true;
            m_lblImportStatusHeild.Location = new Point(306, 60);
            m_lblImportStatusHeild.Name = "m_lblImportStatusHeild";
            m_lblImportStatusHeild.Size = new Size(38, 15);
            m_lblImportStatusHeild.TabIndex = 1;
            m_lblImportStatusHeild.Text = "label8";
            // 
            // m_prgImportStatusHeild
            // 
            m_prgImportStatusHeild.Location = new Point(41, 60);
            m_prgImportStatusHeild.Margin = new Padding(3, 2, 3, 2);
            m_prgImportStatusHeild.Name = "m_prgImportStatusHeild";
            m_prgImportStatusHeild.Size = new Size(231, 17);
            m_prgImportStatusHeild.TabIndex = 2;
            // 
            // m_btnKeyraVorsluInn
            // 
            m_btnKeyraVorsluInn.Location = new Point(62, 19);
            m_btnKeyraVorsluInn.Margin = new Padding(3, 2, 3, 2);
            m_btnKeyraVorsluInn.Name = "m_btnKeyraVorsluInn";
            m_btnKeyraVorsluInn.Size = new Size(258, 26);
            m_btnKeyraVorsluInn.TabIndex = 0;
            m_btnKeyraVorsluInn.Text = "Keyra valdar vörsluútgáfur inn í kerfið";
            m_btnKeyraVorsluInn.UseVisualStyleBackColor = true;
            m_btnKeyraVorsluInn.Visible = false;
            m_btnKeyraVorsluInn.Click += m_btnKeyraVorsluInn_Click;
            // 
            // m_tapLysigogn
            // 
            m_tapLysigogn.Controls.Add(m_dgvVorsluUtgafur);
            m_tapLysigogn.Location = new Point(4, 24);
            m_tapLysigogn.Name = "m_tapLysigogn";
            m_tapLysigogn.Size = new Size(1382, 358);
            m_tapLysigogn.TabIndex = 3;
            m_tapLysigogn.Text = "Lýsigögn";
            m_tapLysigogn.UseVisualStyleBackColor = true;
            // 
            // m_dgvVorsluUtgafur
            // 
            m_dgvVorsluUtgafur.AllowUserToAddRows = false;
            m_dgvVorsluUtgafur.AllowUserToDeleteRows = false;
            m_dgvVorsluUtgafur.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            m_dgvVorsluUtgafur.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            m_dgvVorsluUtgafur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvVorsluUtgafur.Columns.AddRange(new DataGridViewColumn[] { colUtgafurAuðkenni, colUtgafaTitill, dataGridViewTextBoxColumn2, colUtgafaVorslustofnun, colUtgafaSkjalam, colUtgafaStaerd, colUtgafaTimabil, colUtgafaAdgangur, colUtgafurFrum, colUtgafaDagsSkraningar, colUtgafaHverSkradi, colTegund, colUtgafaSkjalamAudkenni, comBtnVörslustofnun, comBtnSkjalamyndari, colBtnGeymsluskra, colUtgafaVorsluAudkenni, colUtgafaSlod });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            m_dgvVorsluUtgafur.DefaultCellStyle = dataGridViewCellStyle2;
            m_dgvVorsluUtgafur.Dock = DockStyle.Fill;
            m_dgvVorsluUtgafur.Location = new Point(0, 0);
            m_dgvVorsluUtgafur.MultiSelect = false;
            m_dgvVorsluUtgafur.Name = "m_dgvVorsluUtgafur";
            m_dgvVorsluUtgafur.ReadOnly = true;
            m_dgvVorsluUtgafur.RowHeadersVisible = false;
            m_dgvVorsluUtgafur.RowTemplate.Height = 25;
            m_dgvVorsluUtgafur.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            m_dgvVorsluUtgafur.Size = new Size(1382, 358);
            m_dgvVorsluUtgafur.TabIndex = 2;
            m_dgvVorsluUtgafur.CellClick += m_dgvVorsluUtgafur_CellContentClick;
            // 
            // colUtgafurAuðkenni
            // 
            colUtgafurAuðkenni.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colUtgafurAuðkenni.DataPropertyName = "vorsluutgafa";
            colUtgafurAuðkenni.HeaderText = "Auðkenni vörsluútgáfu";
            colUtgafurAuðkenni.Name = "colUtgafurAuðkenni";
            colUtgafurAuðkenni.ReadOnly = true;
            colUtgafurAuðkenni.Width = 140;
            // 
            // colUtgafaTitill
            // 
            colUtgafaTitill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colUtgafaTitill.DataPropertyName = "utgafa_titill";
            colUtgafaTitill.HeaderText = "Titill vörsluútgáfu";
            colUtgafaTitill.Name = "colUtgafaTitill";
            colUtgafaTitill.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn2.DataPropertyName = "afharnr";
            dataGridViewTextBoxColumn2.HeaderText = "Afhendingaár og númer vörsluútgáfu";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 148;
            // 
            // colUtgafaVorslustofnun
            // 
            colUtgafaVorslustofnun.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colUtgafaVorslustofnun.DataPropertyName = "varsla_heiti";
            colUtgafaVorslustofnun.HeaderText = "Vörslustofnun vörsluútgáfu";
            colUtgafaVorslustofnun.Name = "colUtgafaVorslustofnun";
            colUtgafaVorslustofnun.ReadOnly = true;
            colUtgafaVorslustofnun.Width = 160;
            // 
            // colUtgafaSkjalam
            // 
            colUtgafaSkjalam.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colUtgafaSkjalam.DataPropertyName = "skjalm_heiti";
            colUtgafaSkjalam.HeaderText = "Skjalamyndari vörsluútgáfu";
            colUtgafaSkjalam.Name = "colUtgafaSkjalam";
            colUtgafaSkjalam.ReadOnly = true;
            colUtgafaSkjalam.Width = 160;
            // 
            // colUtgafaStaerd
            // 
            colUtgafaStaerd.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colUtgafaStaerd.DataPropertyName = "staerd";
            colUtgafaStaerd.HeaderText = "Stærð vörsluútgáfu";
            colUtgafaStaerd.Name = "colUtgafaStaerd";
            colUtgafaStaerd.ReadOnly = true;
            colUtgafaStaerd.Width = 122;
            // 
            // colUtgafaTimabil
            // 
            colUtgafaTimabil.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colUtgafaTimabil.DataPropertyName = "timabil";
            colUtgafaTimabil.HeaderText = "Tímabil vörsluútgáfu";
            colUtgafaTimabil.Name = "colUtgafaTimabil";
            colUtgafaTimabil.ReadOnly = true;
            colUtgafaTimabil.Width = 129;
            // 
            // colUtgafaAdgangur
            // 
            colUtgafaAdgangur.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colUtgafaAdgangur.DataPropertyName = "adgangstakmarkanir";
            colUtgafaAdgangur.HeaderText = "Takmarkanir á aðgengi";
            colUtgafaAdgangur.Name = "colUtgafaAdgangur";
            colUtgafaAdgangur.ReadOnly = true;
            colUtgafaAdgangur.Width = 99;
            // 
            // colUtgafurFrum
            // 
            colUtgafurFrum.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colUtgafurFrum.DataPropertyName = "frumeintak";
            colUtgafurFrum.HeaderText = "Frumeintak til";
            colUtgafurFrum.Name = "colUtgafurFrum";
            colUtgafurFrum.ReadOnly = true;
            colUtgafurFrum.Width = 78;
            // 
            // colUtgafaDagsSkraningar
            // 
            colUtgafaDagsSkraningar.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colUtgafaDagsSkraningar.DataPropertyName = "dags_skrad";
            colUtgafaDagsSkraningar.HeaderText = "Dagsetning skráningar";
            colUtgafaDagsSkraningar.Name = "colUtgafaDagsSkraningar";
            colUtgafaDagsSkraningar.ReadOnly = true;
            colUtgafaDagsSkraningar.Width = 137;
            // 
            // colUtgafaHverSkradi
            // 
            colUtgafaHverSkradi.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colUtgafaHverSkradi.DataPropertyName = "hver_skradi";
            colUtgafaHverSkradi.HeaderText = "Hver skráði";
            colUtgafaHverSkradi.Name = "colUtgafaHverSkradi";
            colUtgafaHverSkradi.ReadOnly = true;
            colUtgafaHverSkradi.Width = 84;
            // 
            // colTegund
            // 
            colTegund.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTegund.DataPropertyName = "tegund";
            colTegund.HeaderText = "Tegund";
            colTegund.Name = "colTegund";
            colTegund.ReadOnly = true;
            colTegund.Width = 71;
            // 
            // colUtgafaSkjalamAudkenni
            // 
            colUtgafaSkjalamAudkenni.DataPropertyName = "skjalamyndari";
            colUtgafaSkjalamAudkenni.HeaderText = "skjalamynd auðkenni";
            colUtgafaSkjalamAudkenni.Name = "colUtgafaSkjalamAudkenni";
            colUtgafaSkjalamAudkenni.ReadOnly = true;
            colUtgafaSkjalamAudkenni.Visible = false;
            // 
            // comBtnVörslustofnun
            // 
            comBtnVörslustofnun.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            comBtnVörslustofnun.HeaderText = "Breyta vörslustofnun";
            comBtnVörslustofnun.Name = "comBtnVörslustofnun";
            comBtnVörslustofnun.ReadOnly = true;
            comBtnVörslustofnun.Text = "Vörslustofnun";
            comBtnVörslustofnun.ToolTipText = "ISDIAH";
            comBtnVörslustofnun.UseColumnTextForButtonValue = true;
            comBtnVörslustofnun.Width = 110;
            // 
            // comBtnSkjalamyndari
            // 
            comBtnSkjalamyndari.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            comBtnSkjalamyndari.HeaderText = "Breyta skjalamyndara";
            comBtnSkjalamyndari.Name = "comBtnSkjalamyndari";
            comBtnSkjalamyndari.ReadOnly = true;
            comBtnSkjalamyndari.Text = "Skjalamyndari";
            comBtnSkjalamyndari.ToolTipText = "ISAAR-CPF";
            comBtnSkjalamyndari.UseColumnTextForButtonValue = true;
            comBtnSkjalamyndari.Width = 113;
            // 
            // colBtnGeymsluskra
            // 
            colBtnGeymsluskra.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBtnGeymsluskra.HeaderText = "Breyta geymsluskrá";
            colBtnGeymsluskra.Name = "colBtnGeymsluskra";
            colBtnGeymsluskra.ReadOnly = true;
            colBtnGeymsluskra.Text = "Geymsluskrá";
            colBtnGeymsluskra.ToolTipText = "ISAD(G)";
            colBtnGeymsluskra.UseColumnTextForButtonValue = true;
            colBtnGeymsluskra.Width = 104;
            // 
            // colUtgafaVorsluAudkenni
            // 
            colUtgafaVorsluAudkenni.DataPropertyName = "vorslustofnun";
            colUtgafaVorsluAudkenni.HeaderText = "Vörslustofnun auðkenni";
            colUtgafaVorsluAudkenni.Name = "colUtgafaVorsluAudkenni";
            colUtgafaVorsluAudkenni.ReadOnly = true;
            colUtgafaVorsluAudkenni.Visible = false;
            // 
            // colUtgafaSlod
            // 
            colUtgafaSlod.DataPropertyName = "slod";
            colUtgafaSlod.HeaderText = "Slod";
            colUtgafaSlod.Name = "colUtgafaSlod";
            colUtgafaSlod.ReadOnly = true;
            colUtgafaSlod.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { m_tomUtskra, m_tomHjalpCHM, m_tomHjalpPDF });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1577, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // m_tomUtskra
            // 
            m_tomUtskra.Alignment = ToolStripItemAlignment.Right;
            m_tomUtskra.Name = "m_tomUtskra";
            m_tomUtskra.Size = new Size(52, 20);
            m_tomUtskra.Text = "Útskrá";
            m_tomUtskra.Visible = false;
            m_tomUtskra.Click += m_tomUtskra_Click;
            // 
            // m_tomHjalpCHM
            // 
            m_tomHjalpCHM.Name = "m_tomHjalpCHM";
            m_tomHjalpCHM.Size = new Size(86, 20);
            m_tomHjalpCHM.Text = "Hjálp (CHM)";
            m_tomHjalpCHM.Visible = false;
            m_tomHjalpCHM.Click += m_tomHjalpCHM_Click;
            // 
            // m_tomHjalpPDF
            // 
            m_tomHjalpPDF.Name = "m_tomHjalpPDF";
            m_tomHjalpPDF.Size = new Size(79, 20);
            m_tomHjalpPDF.Text = "Hjálp (PDF)";
            m_tomHjalpPDF.Visible = false;
            m_tomHjalpPDF.Click += m_tomHjalpPDF_Click;
            // 
            // helpProvider1
            // 
            helpProvider1.HelpNamespace = "C:\\Users\\brjann\\source\\repos\\VHS_OAIS\\MHR_LEIT\\Hjalp\\MHR-LEIT.chm";
            // 
            // helpProvider2
            // 
            helpProvider2.HelpNamespace = "C:\\Users\\brjann\\source\\repos\\VHS_OAIS\\MHR_LEIT\\Hjalp\\MHR-LEIT.pdf";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1577, 925);
            Controls.Add(m_pnlNotandi);
            Controls.Add(m_tacMain);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvLeit).EndInit();
            m_pnlPageing.ResumeLayout(false);
            m_pnlPageing.PerformLayout();
            m_pnlNotandi.ResumeLayout(false);
            m_pnlNotandi.PerformLayout();
            m_tacMain.ResumeLayout(false);
            m_tapLeit.ResumeLayout(false);
            m_tapAfgreidsla.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            m_grbTegundSkjala.ResumeLayout(false);
            m_grbTegundSkjala.PerformLayout();
            m_grbAthugasemdir.ResumeLayout(false);
            m_grbAthugasemdir.PerformLayout();
            m_grbDIP.ResumeLayout(false);
            m_tacPontun.ResumeLayout(false);
            m_tapPontunSkra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvDIPList).EndInit();
            m_tapPontunMalakerfi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvDIPmal).EndInit();
            m_tapPontunGagnagrunnar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvDIPGagnagrunnar).EndInit();
            m_tapUmsjon.ResumeLayout(false);
            m_tacUmsjon.ResumeLayout(false);
            m_tapNotendur.ResumeLayout(false);
            m_tapLanthegar.ResumeLayout(false);
            m_tapUppfæra.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            splitContainer6.Panel1.ResumeLayout(false);
            splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer6).EndInit();
            splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvUtgafur).EndInit();
            m_grbInsertStatus.ResumeLayout(false);
            m_grbInsertStatus.PerformLayout();
            m_tapLysigogn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvVorsluUtgafur).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button m_btnLeita;
        private TextBox m_tboLeitOrd;
        private DataGridView m_dgvLeit;
        private DateTimePicker m_dtEnd;
        private DateTimePicker m_dtpStart;
        private ComboBox m_comSkjalamyndari;
        private ComboBox m_comVorslustofnun;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button m_btnHreinsa;
        private TabControl m_tacMain;
        private TabPage m_tapLeit;
        private TabPage m_tapAfgreidsla;
        private Label m_lblLeitarnidurstodur;
        private DataGridView m_dgvDIPList;
        private Panel m_pnlNotandi;
        private Label m_lblVillaInnSkraning;
        private Button m_btnInnskra;
        private Label m_lblLykilOrd;
        private TextBox m_tboLykilOrd;
        private Label m_lblNotendaNafn;
        private TextBox m_tboNoterndaNafn;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Button m_btnKlaraPontun;
        private Label label5;
        private ComboBox m_comLanthegar;
        private Button m_btnNyrLanthegi;
        private Button m_btnOpna;
        private TreeView m_trwDIP;
        private GroupBox m_grbDIP;
        private Label m_lblLanthegi;
        private Button m_btnTæma;
        private Label m_lblGagangrunnar;
        private ComboBox m_comGagnagrunnar;
        private TabControl m_tacPontun;
        private TabPage m_tapPontunSkra;
        private TabPage m_tapPontunMalakerfi;
        private TabPage m_tapPontunGagnagrunnar;
        private DataGridView m_dgvDIPGagnagrunnar;
        private DataGridView m_dgvDIPmal;
        private Label m_lblPontunstatus;
        private ProgressBar m_prbPontun;
        private CheckBox m_chbAfrit;
        private TabPage m_tapUmsjon;
        private TabControl m_tacUmsjon;
        private TabPage m_tapNotendur;
        private TabPage m_tapLanthegar;
        private TabPage m_tapUppfæra;
        private uscNotendur uscNotendur1;
        private usclanthegar usclanthegar1;
        private Label m_lblVorsluUtgafur;
        private ComboBox m_comVorsluUtgafur;
        private Label m_lblSkraEnding;
        private ComboBox m_comExtensions;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem m_tomUtskra;
        private SplitContainer splitContainer4;
        private Button m_btnSidasta;
        private Button m_btnNaesta;
        private Button m_btnFyrsta;
        private Button m_btnFyrri;
        private ComboBox m_comFjoldiFaerslnaLeit;
        private Label label7;
        private Label label6;
        private Label m_lblSidaAf;
        private Label m_lblSida;
        private ComboBox m_comPages;
        private Panel m_pnlPageing;
        private DataGridViewTextBoxColumn coltitillvorsluUtgafu;
        private DataGridViewTextBoxColumn colDocTitel;
        private DataGridViewTextBoxColumn colExtensions;
        private DataGridViewTextBoxColumn colLastWriten;
        private DataGridViewTextBoxColumn colMal;
        private DataGridViewTextBoxColumn colInnhaldSkjals;
        private DataGridViewTextBoxColumn colAdgengi;
        private DataGridViewTextBoxColumn colSkjalamyndari;
        private DataGridViewTextBoxColumn colVorslustsofnun;
        private DataGridViewTextBoxColumn colGagnaGrunnur;
        private DataGridViewTextBoxColumn colDocID;
        private DataGridViewTextBoxColumn colTegund_gagnagrunns;
        private DataGridViewButtonColumn colDocOpnaAfrit;
        private DataGridViewButtonColumn colDocFrum;
        private DataGridViewButtonColumn colDocInnihald;
        private DataGridViewButtonColumn colDocPanta;
        private DataGridViewTextBoxColumn colDocVarslaID;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn colVarslaStofnunID;
        private DataGridViewTextBoxColumn colSkjalMyndID;
        private DataGridViewTextBoxColumn colDocMalID;
        private TabPage m_tapLysigogn;
        private DataGridView m_dgvVorsluUtgafur;
        private CheckBox m_chbOrdmyndir;
        private FolderBrowserDialog folderBrowserDialog1;
        private SplitContainer splitContainer5;
        private Button m_btnGetData;
        private Button m_btnLagaToflur;
        private SplitContainer splitContainer6;
        private Button m_btnKeyraVorsluInn;
        private ProgressBar m_prgImportStatusHeild;
        private Label m_lblImportStatusHeild;
        private Button m_btnKeyrAfritInn;
        private DataGridViewTextBoxColumn colGagnHeiti;
        private DataGridViewTextBoxColumn colLeitskilyrdi;
        private DataGridViewTextBoxColumn colGagnHeitivorslu;
        private DataGridViewButtonColumn colGagnOpna;
        private DataGridViewButtonColumn colGagnRemove;
        private DataGridViewTextBoxColumn colGagnSQL;
        private GroupBox m_grbAthugasemdir;
        private TextBox textBox1;
        private TextBox m_tboPontunAth;
        private Button m_btnPantAthUpp;
        private Label m_lblKarfaNr;
        private GroupBox m_grbInsertStatus;
        private DataGridView m_dgvUtgafur;
        private DataGridViewTextBoxColumn colHeitiVarslaMidlun;
        private DataGridViewCheckBoxColumn colMidlunTaka;
        private DataGridViewTextBoxColumn colAudkenniVarslaMidlun;
        private Label m_lblStatusVarslaTaka;
        private Label m_lblStatusDoing;
        private CheckBox m_chbPDF;
        private RadioButton m_rdbFrumTif;
        private RadioButton m_rdbTiff;
        private RadioButton m_rdbFrum;
        private GroupBox m_grbTegundSkjala;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colTitill;
        private DataGridViewTextBoxColumn colHeitiUtgáfu;
        private DataGridViewButtonColumn colSkraOpna;
        private DataGridViewButtonColumn colPDF;
        private DataGridViewButtonColumn colSkraRemove;
        private DataGridViewTextBoxColumn colSkraVarslaID;
        private DataGridViewTextBoxColumn colMalSkraID;
        private DataGridViewTextBoxColumn colMalTitillSkjals;
        private DataGridViewTextBoxColumn colMalTitilMals;
        private DataGridViewTextBoxColumn colMalTitillVorslu;
        private DataGridViewButtonColumn colMalOpna;
        private DataGridViewButtonColumn colBtnFjarlaegja;
        private DataGridViewTextBoxColumn colMalVarslaUtgafaID;
        private DataGridViewButtonColumn colMalPDF;
        private DataGridViewTextBoxColumn colMalGagnGrunnur;
        private DataGridViewTextBoxColumn colUtgafurAuðkenni;
        private DataGridViewTextBoxColumn colUtgafaTitill;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn colUtgafaVorslustofnun;
        private DataGridViewTextBoxColumn colUtgafaSkjalam;
        private DataGridViewTextBoxColumn colUtgafaStaerd;
        private DataGridViewTextBoxColumn colUtgafaTimabil;
        private DataGridViewTextBoxColumn colUtgafaAdgangur;
        private DataGridViewCheckBoxColumn colUtgafurFrum;
        private DataGridViewTextBoxColumn colUtgafaDagsSkraningar;
        private DataGridViewTextBoxColumn colUtgafaHverSkradi;
        private DataGridViewTextBoxColumn colTegund;
        private DataGridViewTextBoxColumn colUtgafaSkjalamAudkenni;
        private DataGridViewButtonColumn comBtnVörslustofnun;
        private DataGridViewButtonColumn comBtnSkjalamyndari;
        private DataGridViewButtonColumn colBtnGeymsluskra;
        private DataGridViewTextBoxColumn colUtgafaVorsluAudkenni;
        private DataGridViewTextBoxColumn colUtgafaSlod;
        private ToolStripMenuItem m_tomHjalpCHM;
        private ToolStripMenuItem m_tomHjalpPDF;
        private HelpProvider helpProvider1;
        private HelpProvider helpProvider2;
    }
}