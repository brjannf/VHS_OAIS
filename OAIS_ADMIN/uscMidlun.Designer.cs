namespace OAIS_ADMIN
{
    partial class uscMidlun
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            m_dgvUtgafur = new DataGridView();
            m_comID = new DataGridViewTextBoxColumn();
            colVorsluutgafu = new DataGridViewTextBoxColumn();
            colTitill = new DataGridViewTextBoxColumn();
            colVorslustofnun = new DataGridViewTextBoxColumn();
            colHeitiVarsla = new DataGridViewTextBoxColumn();
            colSkjalamyndari = new DataGridViewTextBoxColumn();
            colSkjalmHeiti = new DataGridViewTextBoxColumn();
            colStaerd = new DataGridViewTextBoxColumn();
            colSlod = new DataGridViewTextBoxColumn();
            colInnihald = new DataGridViewTextBoxColumn();
            colTimabil = new DataGridViewTextBoxColumn();
            colAfhArNR = new DataGridViewTextBoxColumn();
            colMD5 = new DataGridViewTextBoxColumn();
            colAdgangur = new DataGridViewTextBoxColumn();
            colHverSkradi = new DataGridViewTextBoxColumn();
            colDagsSkráð = new DataGridViewTextBoxColumn();
            colBtnBirta = new DataGridViewButtonColumn();
            colEytt = new DataGridViewTextBoxColumn();
            colMidlad = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            m_lblTegundVorslu = new Label();
            m_btnUppfæra = new Button();
            m_chbOCR = new CheckBox();
            m_grbStatus = new GroupBox();
            m_prbToflur = new ProgressBar();
            m_prbGogn = new ProgressBar();
            m_lblToflurStatus = new Label();
            m_lblGognStatus = new Label();
            m_grbFyrirspurnir = new GroupBox();
            m_dgvFyrirSpurnir = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colFyrirNafn = new DataGridViewTextBoxColumn();
            colFyrirFyrirspurn = new DataGridViewTextBoxColumn();
            colFyrirLýsing = new DataGridViewTextBoxColumn();
            colBtnPrófa = new DataGridViewButtonColumn();
            colFyrirDatabase = new DataGridViewTextBoxColumn();
            colBtnVista = new DataGridViewButtonColumn();
            m_lblValinVorsluutgafa = new Label();
            label1 = new Label();
            m_btnkeyra = new Button();
            m_btnEndurHressa = new Button();
            m_grbVorsluutgafur = new GroupBox();
            m_tacMidlun = new TabControl();
            m_tap_HRM_ACCESS = new TabPage();
            m_tapVorslur = new TabPage();
            splitContainer3 = new SplitContainer();
            m_grbKlasar = new GroupBox();
            m_trwKlasarVorslustonun = new TreeView();
            splitContainer2 = new SplitContainer();
            m_lblStatus = new Label();
            m_lblVorsluStofnunPrg = new Label();
            m_prgVorsluStofnun = new ProgressBar();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            m_lblBackupStatus = new Label();
            m_prgBackup = new ProgressBar();
            m_btnBuaTilPakka = new Button();
            m_lblKlasiVarslaValinn = new Label();
            m_grbUtgafur = new GroupBox();
            m_dgvUtafurKlasarVarsla = new DataGridView();
            colAudkenni = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            colVorslustofun = new DataGridViewTextBoxColumn();
            colTegund = new DataGridViewTextBoxColumn();
            colTaka = new DataGridViewCheckBoxColumn();
            colGeymsluskra = new DataGridViewButtonColumn();
            colVarslaSlod = new DataGridViewTextBoxColumn();
            colVorsluID = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)m_dgvUtgafur).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            m_grbStatus.SuspendLayout();
            m_grbFyrirspurnir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvFyrirSpurnir).BeginInit();
            m_grbVorsluutgafur.SuspendLayout();
            m_tacMidlun.SuspendLayout();
            m_tap_HRM_ACCESS.SuspendLayout();
            m_tapVorslur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            m_grbKlasar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            m_grbUtgafur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvUtafurKlasarVarsla).BeginInit();
            SuspendLayout();
            // 
            // m_dgvUtgafur
            // 
            m_dgvUtgafur.AllowUserToAddRows = false;
            m_dgvUtgafur.AllowUserToDeleteRows = false;
            m_dgvUtgafur.BackgroundColor = SystemColors.ControlLight;
            m_dgvUtgafur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvUtgafur.Columns.AddRange(new DataGridViewColumn[] { m_comID, colVorsluutgafu, colTitill, colVorslustofnun, colHeitiVarsla, colSkjalamyndari, colSkjalmHeiti, colStaerd, colSlod, colInnihald, colTimabil, colAfhArNR, colMD5, colAdgangur, colHverSkradi, colDagsSkráð, colBtnBirta, colEytt, colMidlad });
            m_dgvUtgafur.Dock = DockStyle.Fill;
            m_dgvUtgafur.Location = new Point(3, 24);
            m_dgvUtgafur.Margin = new Padding(3, 4, 3, 4);
            m_dgvUtgafur.Name = "m_dgvUtgafur";
            m_dgvUtgafur.ReadOnly = true;
            m_dgvUtgafur.RowHeadersVisible = false;
            m_dgvUtgafur.RowTemplate.Height = 25;
            m_dgvUtgafur.Size = new Size(1822, 328);
            m_dgvUtgafur.TabIndex = 1;
            m_dgvUtgafur.CellClick += m_dgvUtgafur_CellClick;
            // 
            // m_comID
            // 
            m_comID.DataPropertyName = "id";
            m_comID.HeaderText = "ID";
            m_comID.Name = "m_comID";
            m_comID.ReadOnly = true;
            m_comID.Visible = false;
            // 
            // colVorsluutgafu
            // 
            colVorsluutgafu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colVorsluutgafu.DataPropertyName = "vorsluutgafa";
            colVorsluutgafu.HeaderText = "Vörsluútgáfa";
            colVorsluutgafu.Name = "colVorsluutgafu";
            colVorsluutgafu.ReadOnly = true;
            colVorsluutgafu.Width = 117;
            // 
            // colTitill
            // 
            colTitill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTitill.DataPropertyName = "utgafa_titill";
            colTitill.HeaderText = "Titill vörsluútgáfu";
            colTitill.Name = "colTitill";
            colTitill.ReadOnly = true;
            // 
            // colVorslustofnun
            // 
            colVorslustofnun.DataPropertyName = "vorslustofnun";
            colVorslustofnun.HeaderText = "VörslustofnunID";
            colVorslustofnun.Name = "colVorslustofnun";
            colVorslustofnun.ReadOnly = true;
            colVorslustofnun.Visible = false;
            // 
            // colHeitiVarsla
            // 
            colHeitiVarsla.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colHeitiVarsla.DataPropertyName = "varsla_heiti";
            colHeitiVarsla.HeaderText = "Vörslustofnun";
            colHeitiVarsla.Name = "colHeitiVarsla";
            colHeitiVarsla.ReadOnly = true;
            colHeitiVarsla.Width = 123;
            // 
            // colSkjalamyndari
            // 
            colSkjalamyndari.DataPropertyName = "skjalamyndari";
            colSkjalamyndari.HeaderText = "skjalamyndari";
            colSkjalamyndari.Name = "colSkjalamyndari";
            colSkjalamyndari.ReadOnly = true;
            colSkjalamyndari.Visible = false;
            // 
            // colSkjalmHeiti
            // 
            colSkjalmHeiti.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colSkjalmHeiti.DataPropertyName = "skjalm_heiti";
            colSkjalmHeiti.HeaderText = "Heiti skjalamyndara";
            colSkjalmHeiti.Name = "colSkjalmHeiti";
            colSkjalmHeiti.ReadOnly = true;
            colSkjalmHeiti.Width = 151;
            // 
            // colStaerd
            // 
            colStaerd.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colStaerd.DataPropertyName = "staerd";
            colStaerd.HeaderText = "Stærð";
            colStaerd.Name = "colStaerd";
            colStaerd.ReadOnly = true;
            colStaerd.Width = 72;
            // 
            // colSlod
            // 
            colSlod.DataPropertyName = "slod";
            colSlod.HeaderText = "Slóð";
            colSlod.Name = "colSlod";
            colSlod.ReadOnly = true;
            colSlod.Visible = false;
            // 
            // colInnihald
            // 
            colInnihald.DataPropertyName = "innihald";
            colInnihald.HeaderText = "Innihald";
            colInnihald.Name = "colInnihald";
            colInnihald.ReadOnly = true;
            colInnihald.Visible = false;
            // 
            // colTimabil
            // 
            colTimabil.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTimabil.DataPropertyName = "timabil";
            colTimabil.HeaderText = "Tímabil";
            colTimabil.Name = "colTimabil";
            colTimabil.ReadOnly = true;
            colTimabil.Width = 84;
            // 
            // colAfhArNR
            // 
            colAfhArNR.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colAfhArNR.DataPropertyName = "afharnr";
            colAfhArNR.HeaderText = "Afhendingaár / númer";
            colAfhArNR.Name = "colAfhArNR";
            colAfhArNR.ReadOnly = true;
            colAfhArNR.Width = 126;
            // 
            // colMD5
            // 
            colMD5.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMD5.DataPropertyName = "MD5";
            colMD5.HeaderText = "Gátsumma";
            colMD5.Name = "colMD5";
            colMD5.ReadOnly = true;
            colMD5.Visible = false;
            // 
            // colAdgangur
            // 
            colAdgangur.DataPropertyName = "adgangstakmarkanir";
            colAdgangur.HeaderText = "Aðgengi";
            colAdgangur.Name = "colAdgangur";
            colAdgangur.ReadOnly = true;
            // 
            // colHverSkradi
            // 
            colHverSkradi.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colHverSkradi.DataPropertyName = "hver_skradi";
            colHverSkradi.HeaderText = "Hver skráði";
            colHverSkradi.Name = "colHverSkradi";
            colHverSkradi.ReadOnly = true;
            colHverSkradi.Width = 98;
            // 
            // colDagsSkráð
            // 
            colDagsSkráð.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDagsSkráð.DataPropertyName = "dags_skrad";
            colDagsSkráð.HeaderText = "Dags. skráð";
            colDagsSkráð.Name = "colDagsSkráð";
            colDagsSkráð.ReadOnly = true;
            // 
            // colBtnBirta
            // 
            colBtnBirta.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBtnBirta.HeaderText = "Setja í miðlun";
            colBtnBirta.Name = "colBtnBirta";
            colBtnBirta.ReadOnly = true;
            colBtnBirta.Text = "miðla";
            colBtnBirta.UseColumnTextForButtonValue = true;
            colBtnBirta.Width = 95;
            // 
            // colEytt
            // 
            colEytt.DataPropertyName = "eytt";
            colEytt.HeaderText = "Eytt";
            colEytt.Name = "colEytt";
            colEytt.ReadOnly = true;
            colEytt.Visible = false;
            // 
            // colMidlad
            // 
            colMidlad.DataPropertyName = "midlun";
            colMidlad.HeaderText = "Miðlað";
            colMidlad.Name = "colMidlad";
            colMidlad.ReadOnly = true;
            colMidlad.Visible = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 4);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(m_lblTegundVorslu);
            splitContainer1.Panel1.Controls.Add(m_btnUppfæra);
            splitContainer1.Panel1.Controls.Add(m_chbOCR);
            splitContainer1.Panel1.Controls.Add(m_grbStatus);
            splitContainer1.Panel1.Controls.Add(m_grbFyrirspurnir);
            splitContainer1.Panel1.Controls.Add(m_lblValinVorsluutgafa);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(m_btnkeyra);
            splitContainer1.Panel1.Controls.Add(m_btnEndurHressa);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(m_grbVorsluutgafur);
            splitContainer1.Size = new Size(1828, 871);
            splitContainer1.SplitterDistance = 510;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            // 
            // m_lblTegundVorslu
            // 
            m_lblTegundVorslu.AutoSize = true;
            m_lblTegundVorslu.Location = new Point(1045, 33);
            m_lblTegundVorslu.Name = "m_lblTegundVorslu";
            m_lblTegundVorslu.Size = new Size(50, 20);
            m_lblTegundVorslu.TabIndex = 14;
            m_lblTegundVorslu.Text = "label3";
            // 
            // m_btnUppfæra
            // 
            m_btnUppfæra.Location = new Point(1455, 29);
            m_btnUppfæra.Name = "m_btnUppfæra";
            m_btnUppfæra.Size = new Size(154, 44);
            m_btnUppfæra.TabIndex = 13;
            m_btnUppfæra.Text = "GoPro innsert";
            m_btnUppfæra.UseVisualStyleBackColor = true;
            m_btnUppfæra.Click += button1_Click;
            // 
            // m_chbOCR
            // 
            m_chbOCR.AutoSize = true;
            m_chbOCR.Checked = true;
            m_chbOCR.CheckState = CheckState.Checked;
            m_chbOCR.Location = new Point(1010, 64);
            m_chbOCR.Name = "m_chbOCR";
            m_chbOCR.Size = new Size(97, 24);
            m_chbOCR.TabIndex = 12;
            m_chbOCR.Text = "OCR lestur";
            m_chbOCR.UseVisualStyleBackColor = true;
            // 
            // m_grbStatus
            // 
            m_grbStatus.Controls.Add(m_prbToflur);
            m_grbStatus.Controls.Add(m_prbGogn);
            m_grbStatus.Controls.Add(m_lblToflurStatus);
            m_grbStatus.Controls.Add(m_lblGognStatus);
            m_grbStatus.Location = new Point(98, 92);
            m_grbStatus.Margin = new Padding(3, 4, 3, 4);
            m_grbStatus.Name = "m_grbStatus";
            m_grbStatus.Padding = new Padding(3, 4, 3, 4);
            m_grbStatus.Size = new Size(1343, 117);
            m_grbStatus.TabIndex = 11;
            m_grbStatus.TabStop = false;
            m_grbStatus.Text = "Staða";
            m_grbStatus.Visible = false;
            // 
            // m_prbToflur
            // 
            m_prbToflur.Location = new Point(24, 29);
            m_prbToflur.Margin = new Padding(3, 4, 3, 4);
            m_prbToflur.Name = "m_prbToflur";
            m_prbToflur.Size = new Size(815, 31);
            m_prbToflur.TabIndex = 0;
            // 
            // m_prbGogn
            // 
            m_prbGogn.Location = new Point(24, 71);
            m_prbGogn.Margin = new Padding(3, 4, 3, 4);
            m_prbGogn.Name = "m_prbGogn";
            m_prbGogn.Size = new Size(815, 31);
            m_prbGogn.TabIndex = 1;
            // 
            // m_lblToflurStatus
            // 
            m_lblToflurStatus.AutoSize = true;
            m_lblToflurStatus.Location = new Point(912, 29);
            m_lblToflurStatus.Name = "m_lblToflurStatus";
            m_lblToflurStatus.Size = new Size(50, 20);
            m_lblToflurStatus.TabIndex = 2;
            m_lblToflurStatus.Text = "label1";
            // 
            // m_lblGognStatus
            // 
            m_lblGognStatus.AutoSize = true;
            m_lblGognStatus.Location = new Point(912, 81);
            m_lblGognStatus.Name = "m_lblGognStatus";
            m_lblGognStatus.Size = new Size(50, 20);
            m_lblGognStatus.TabIndex = 3;
            m_lblGognStatus.Text = "label1";
            // 
            // m_grbFyrirspurnir
            // 
            m_grbFyrirspurnir.Controls.Add(m_dgvFyrirSpurnir);
            m_grbFyrirspurnir.Dock = DockStyle.Bottom;
            m_grbFyrirspurnir.Location = new Point(0, 329);
            m_grbFyrirspurnir.Margin = new Padding(3, 4, 3, 4);
            m_grbFyrirspurnir.Name = "m_grbFyrirspurnir";
            m_grbFyrirspurnir.Padding = new Padding(3, 4, 3, 4);
            m_grbFyrirspurnir.Size = new Size(1828, 181);
            m_grbFyrirspurnir.TabIndex = 10;
            m_grbFyrirspurnir.TabStop = false;
            m_grbFyrirspurnir.Text = "Fyrirspurnir";
            // 
            // m_dgvFyrirSpurnir
            // 
            m_dgvFyrirSpurnir.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvFyrirSpurnir.Columns.AddRange(new DataGridViewColumn[] { colID, colFyrirNafn, colFyrirFyrirspurn, colFyrirLýsing, colBtnPrófa, colFyrirDatabase, colBtnVista });
            m_dgvFyrirSpurnir.Dock = DockStyle.Fill;
            m_dgvFyrirSpurnir.Location = new Point(3, 24);
            m_dgvFyrirSpurnir.Margin = new Padding(3, 4, 3, 4);
            m_dgvFyrirSpurnir.Name = "m_dgvFyrirSpurnir";
            m_dgvFyrirSpurnir.RowHeadersVisible = false;
            m_dgvFyrirSpurnir.RowTemplate.Height = 25;
            m_dgvFyrirSpurnir.Size = new Size(1822, 153);
            m_dgvFyrirSpurnir.TabIndex = 4;
            m_dgvFyrirSpurnir.CellClick += m_dgvFyrirSpurnir_CellClick;
            m_dgvFyrirSpurnir.CellContentClick += m_dgvFyrirSpurnir_CellContentClick;
            // 
            // colID
            // 
            colID.DataPropertyName = "id";
            colID.HeaderText = "ID";
            colID.Name = "colID";
            colID.Visible = false;
            // 
            // colFyrirNafn
            // 
            colFyrirNafn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colFyrirNafn.DataPropertyName = "name";
            colFyrirNafn.HeaderText = "Heiti fyrirspurnar";
            colFyrirNafn.Name = "colFyrirNafn";
            colFyrirNafn.Width = 133;
            // 
            // colFyrirFyrirspurn
            // 
            colFyrirFyrirspurn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFyrirFyrirspurn.DataPropertyName = "queryOriginal";
            colFyrirFyrirspurn.HeaderText = "Fyrirspurn";
            colFyrirFyrirspurn.Name = "colFyrirFyrirspurn";
            // 
            // colFyrirLýsing
            // 
            colFyrirLýsing.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colFyrirLýsing.DataPropertyName = "description";
            colFyrirLýsing.HeaderText = "Lýsing fyrirspurnar";
            colFyrirLýsing.Name = "colFyrirLýsing";
            colFyrirLýsing.Width = 140;
            // 
            // colBtnPrófa
            // 
            colBtnPrófa.HeaderText = "Prófa";
            colBtnPrófa.Name = "colBtnPrófa";
            colBtnPrófa.Resizable = DataGridViewTriState.True;
            colBtnPrófa.SortMode = DataGridViewColumnSortMode.Automatic;
            colBtnPrófa.Text = "Prófa";
            colBtnPrófa.UseColumnTextForButtonValue = true;
            // 
            // colFyrirDatabase
            // 
            colFyrirDatabase.DataPropertyName = "database";
            colFyrirDatabase.HeaderText = "Database";
            colFyrirDatabase.Name = "colFyrirDatabase";
            colFyrirDatabase.Visible = false;
            // 
            // colBtnVista
            // 
            colBtnVista.HeaderText = "Vista";
            colBtnVista.Name = "colBtnVista";
            colBtnVista.Text = "Vista";
            colBtnVista.UseColumnTextForButtonValue = true;
            // 
            // m_lblValinVorsluutgafa
            // 
            m_lblValinVorsluutgafa.AutoSize = true;
            m_lblValinVorsluutgafa.Location = new Point(98, 40);
            m_lblValinVorsluutgafa.Name = "m_lblValinVorsluutgafa";
            m_lblValinVorsluutgafa.Size = new Size(50, 20);
            m_lblValinVorsluutgafa.TabIndex = 9;
            m_lblValinVorsluutgafa.Text = "label2";
            m_lblValinVorsluutgafa.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(805, 33);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 8;
            label1.Text = "Tegund vörlsuútgáfu";
            // 
            // m_btnkeyra
            // 
            m_btnkeyra.Location = new Point(1345, 29);
            m_btnkeyra.Margin = new Padding(3, 4, 3, 4);
            m_btnkeyra.Name = "m_btnkeyra";
            m_btnkeyra.Size = new Size(86, 31);
            m_btnkeyra.TabIndex = 6;
            m_btnkeyra.Text = "Búa til miðlunarútgáfu";
            m_btnkeyra.UseVisualStyleBackColor = true;
            m_btnkeyra.Click += m_btnkeyra_Click;
            // 
            // m_btnEndurHressa
            // 
            m_btnEndurHressa.Location = new Point(1645, 33);
            m_btnEndurHressa.Margin = new Padding(3, 4, 3, 4);
            m_btnEndurHressa.Name = "m_btnEndurHressa";
            m_btnEndurHressa.Size = new Size(141, 31);
            m_btnEndurHressa.TabIndex = 5;
            m_btnEndurHressa.Text = "Endurhressa";
            m_btnEndurHressa.UseVisualStyleBackColor = true;
            m_btnEndurHressa.Click += m_btnEndurHressa_Click;
            // 
            // m_grbVorsluutgafur
            // 
            m_grbVorsluutgafur.Controls.Add(m_dgvUtgafur);
            m_grbVorsluutgafur.Dock = DockStyle.Fill;
            m_grbVorsluutgafur.Location = new Point(0, 0);
            m_grbVorsluutgafur.Margin = new Padding(3, 4, 3, 4);
            m_grbVorsluutgafur.Name = "m_grbVorsluutgafur";
            m_grbVorsluutgafur.Padding = new Padding(3, 4, 3, 4);
            m_grbVorsluutgafur.Size = new Size(1828, 356);
            m_grbVorsluutgafur.TabIndex = 2;
            m_grbVorsluutgafur.TabStop = false;
            m_grbVorsluutgafur.Text = "Vörsluútgafur";
            // 
            // m_tacMidlun
            // 
            m_tacMidlun.Controls.Add(m_tap_HRM_ACCESS);
            m_tacMidlun.Controls.Add(m_tapVorslur);
            m_tacMidlun.Dock = DockStyle.Fill;
            m_tacMidlun.Location = new Point(0, 0);
            m_tacMidlun.Margin = new Padding(3, 4, 3, 4);
            m_tacMidlun.Name = "m_tacMidlun";
            m_tacMidlun.SelectedIndex = 0;
            m_tacMidlun.Size = new Size(1842, 912);
            m_tacMidlun.TabIndex = 3;
            // 
            // m_tap_HRM_ACCESS
            // 
            m_tap_HRM_ACCESS.Controls.Add(splitContainer1);
            m_tap_HRM_ACCESS.Location = new Point(4, 29);
            m_tap_HRM_ACCESS.Margin = new Padding(3, 4, 3, 4);
            m_tap_HRM_ACCESS.Name = "m_tap_HRM_ACCESS";
            m_tap_HRM_ACCESS.Padding = new Padding(3, 4, 3, 4);
            m_tap_HRM_ACCESS.Size = new Size(1834, 879);
            m_tap_HRM_ACCESS.TabIndex = 0;
            m_tap_HRM_ACCESS.Text = "Miðlun fyrir MHR";
            m_tap_HRM_ACCESS.UseVisualStyleBackColor = true;
            // 
            // m_tapVorslur
            // 
            m_tapVorslur.Controls.Add(splitContainer3);
            m_tapVorslur.Location = new Point(4, 29);
            m_tapVorslur.Margin = new Padding(3, 4, 3, 4);
            m_tapVorslur.Name = "m_tapVorslur";
            m_tapVorslur.Padding = new Padding(3, 4, 3, 4);
            m_tapVorslur.Size = new Size(1834, 879);
            m_tapVorslur.TabIndex = 1;
            m_tapVorslur.Text = "Miðlun fyrir vörslustofnanir";
            m_tapVorslur.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 4);
            splitContainer3.Margin = new Padding(3, 4, 3, 4);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(m_grbKlasar);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer2);
            splitContainer3.Size = new Size(1828, 871);
            splitContainer3.SplitterDistance = 247;
            splitContainer3.SplitterWidth = 5;
            splitContainer3.TabIndex = 1;
            // 
            // m_grbKlasar
            // 
            m_grbKlasar.Controls.Add(m_trwKlasarVorslustonun);
            m_grbKlasar.Dock = DockStyle.Fill;
            m_grbKlasar.Location = new Point(0, 0);
            m_grbKlasar.Margin = new Padding(3, 4, 3, 4);
            m_grbKlasar.Name = "m_grbKlasar";
            m_grbKlasar.Padding = new Padding(3, 4, 3, 4);
            m_grbKlasar.Size = new Size(247, 871);
            m_grbKlasar.TabIndex = 1;
            m_grbKlasar.TabStop = false;
            m_grbKlasar.Text = "Klasara/ Vörslustofnanir";
            // 
            // m_trwKlasarVorslustonun
            // 
            m_trwKlasarVorslustonun.Dock = DockStyle.Fill;
            m_trwKlasarVorslustonun.Location = new Point(3, 24);
            m_trwKlasarVorslustonun.Margin = new Padding(3, 4, 3, 4);
            m_trwKlasarVorslustonun.Name = "m_trwKlasarVorslustonun";
            m_trwKlasarVorslustonun.Size = new Size(241, 843);
            m_trwKlasarVorslustonun.TabIndex = 0;
            m_trwKlasarVorslustonun.AfterSelect += m_trwKlasarVorslustonun_AfterSelect;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(3, 4, 3, 4);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(m_lblStatus);
            splitContainer2.Panel1.Controls.Add(m_lblVorsluStofnunPrg);
            splitContainer2.Panel1.Controls.Add(m_prgVorsluStofnun);
            splitContainer2.Panel1.Controls.Add(label2);
            splitContainer2.Panel1.Controls.Add(progressBar1);
            splitContainer2.Panel1.Controls.Add(m_lblBackupStatus);
            splitContainer2.Panel1.Controls.Add(m_prgBackup);
            splitContainer2.Panel1.Controls.Add(m_btnBuaTilPakka);
            splitContainer2.Panel1.Controls.Add(m_lblKlasiVarslaValinn);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(m_grbUtgafur);
            splitContainer2.Size = new Size(1576, 871);
            splitContainer2.SplitterDistance = 373;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 0;
            // 
            // m_lblStatus
            // 
            m_lblStatus.AutoSize = true;
            m_lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblStatus.ForeColor = SystemColors.HotTrack;
            m_lblStatus.Location = new Point(168, 91);
            m_lblStatus.Name = "m_lblStatus";
            m_lblStatus.Size = new Size(50, 19);
            m_lblStatus.TabIndex = 8;
            m_lblStatus.Text = "label2";
            // 
            // m_lblVorsluStofnunPrg
            // 
            m_lblVorsluStofnunPrg.AutoSize = true;
            m_lblVorsluStofnunPrg.Location = new Point(955, 151);
            m_lblVorsluStofnunPrg.Name = "m_lblVorsluStofnunPrg";
            m_lblVorsluStofnunPrg.Size = new Size(50, 20);
            m_lblVorsluStofnunPrg.TabIndex = 7;
            m_lblVorsluStofnunPrg.Text = "label2";
            // 
            // m_prgVorsluStofnun
            // 
            m_prgVorsluStofnun.Location = new Point(168, 140);
            m_prgVorsluStofnun.Margin = new Padding(3, 4, 3, 4);
            m_prgVorsluStofnun.Name = "m_prgVorsluStofnun";
            m_prgVorsluStofnun.Size = new Size(754, 31);
            m_prgVorsluStofnun.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(955, 207);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(168, 196);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(754, 31);
            progressBar1.TabIndex = 4;
            // 
            // m_lblBackupStatus
            // 
            m_lblBackupStatus.AutoSize = true;
            m_lblBackupStatus.Location = new Point(955, 265);
            m_lblBackupStatus.Name = "m_lblBackupStatus";
            m_lblBackupStatus.Size = new Size(50, 20);
            m_lblBackupStatus.TabIndex = 3;
            m_lblBackupStatus.Text = "label2";
            // 
            // m_prgBackup
            // 
            m_prgBackup.Location = new Point(168, 255);
            m_prgBackup.Margin = new Padding(3, 4, 3, 4);
            m_prgBackup.Name = "m_prgBackup";
            m_prgBackup.Size = new Size(754, 31);
            m_prgBackup.TabIndex = 2;
            // 
            // m_btnBuaTilPakka
            // 
            m_btnBuaTilPakka.Location = new Point(168, 319);
            m_btnBuaTilPakka.Margin = new Padding(3, 4, 3, 4);
            m_btnBuaTilPakka.Name = "m_btnBuaTilPakka";
            m_btnBuaTilPakka.Size = new Size(767, 31);
            m_btnBuaTilPakka.TabIndex = 1;
            m_btnBuaTilPakka.Text = "Búa til miðlunarpakka";
            m_btnBuaTilPakka.UseVisualStyleBackColor = true;
            m_btnBuaTilPakka.Click += m_btnBuaTilPakka_Click;
            // 
            // m_lblKlasiVarslaValinn
            // 
            m_lblKlasiVarslaValinn.AutoSize = true;
            m_lblKlasiVarslaValinn.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblKlasiVarslaValinn.ForeColor = SystemColors.HotTrack;
            m_lblKlasiVarslaValinn.Location = new Point(168, 37);
            m_lblKlasiVarslaValinn.Name = "m_lblKlasiVarslaValinn";
            m_lblKlasiVarslaValinn.Size = new Size(65, 25);
            m_lblKlasiVarslaValinn.TabIndex = 0;
            m_lblKlasiVarslaValinn.Text = "label2";
            // 
            // m_grbUtgafur
            // 
            m_grbUtgafur.Controls.Add(m_dgvUtafurKlasarVarsla);
            m_grbUtgafur.Dock = DockStyle.Fill;
            m_grbUtgafur.Location = new Point(0, 0);
            m_grbUtgafur.Margin = new Padding(3, 4, 3, 4);
            m_grbUtgafur.Name = "m_grbUtgafur";
            m_grbUtgafur.Padding = new Padding(3, 4, 3, 4);
            m_grbUtgafur.Size = new Size(1576, 493);
            m_grbUtgafur.TabIndex = 0;
            m_grbUtgafur.TabStop = false;
            m_grbUtgafur.Text = "Vörsluútgáfur";
            // 
            // m_dgvUtafurKlasarVarsla
            // 
            m_dgvUtafurKlasarVarsla.AllowUserToAddRows = false;
            m_dgvUtafurKlasarVarsla.AllowUserToDeleteRows = false;
            m_dgvUtafurKlasarVarsla.AllowUserToOrderColumns = true;
            m_dgvUtafurKlasarVarsla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvUtafurKlasarVarsla.Columns.AddRange(new DataGridViewColumn[] { colAudkenni, dataGridViewTextBoxColumn1, colVorslustofun, colTegund, colTaka, colGeymsluskra, colVarslaSlod, colVorsluID });
            m_dgvUtafurKlasarVarsla.Dock = DockStyle.Fill;
            m_dgvUtafurKlasarVarsla.Location = new Point(3, 24);
            m_dgvUtafurKlasarVarsla.Margin = new Padding(3, 4, 3, 4);
            m_dgvUtafurKlasarVarsla.MultiSelect = false;
            m_dgvUtafurKlasarVarsla.Name = "m_dgvUtafurKlasarVarsla";
            m_dgvUtafurKlasarVarsla.RowHeadersVisible = false;
            m_dgvUtafurKlasarVarsla.RowTemplate.Height = 25;
            m_dgvUtafurKlasarVarsla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            m_dgvUtafurKlasarVarsla.Size = new Size(1570, 465);
            m_dgvUtafurKlasarVarsla.TabIndex = 0;
            m_dgvUtafurKlasarVarsla.CellClick += m_dgvUtafurKlasarVarsla_CellClick;
            // 
            // colAudkenni
            // 
            colAudkenni.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colAudkenni.DataPropertyName = "vorsluutgafa";
            colAudkenni.HeaderText = "Auðkenni vörslúgáfu";
            colAudkenni.Name = "colAudkenni";
            colAudkenni.Width = 153;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "utgafa_titill";
            dataGridViewTextBoxColumn1.HeaderText = "Titill vörsluútgáfu";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // colVorslustofun
            // 
            colVorslustofun.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colVorslustofun.DataPropertyName = "varsla_heiti";
            colVorslustofun.HeaderText = "Vörslustofnun";
            colVorslustofun.Name = "colVorslustofun";
            // 
            // colTegund
            // 
            colTegund.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTegund.DataPropertyName = "tegund";
            colTegund.HeaderText = "Tegund";
            colTegund.Name = "colTegund";
            colTegund.Width = 83;
            // 
            // colTaka
            // 
            colTaka.DataPropertyName = "taka";
            colTaka.HeaderText = "Taka með í útgáfu";
            colTaka.Name = "colTaka";
            // 
            // colGeymsluskra
            // 
            colGeymsluskra.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGeymsluskra.HeaderText = "Geymsluskrá";
            colGeymsluskra.Name = "colGeymsluskra";
            colGeymsluskra.Text = "Búa til skrá";
            colGeymsluskra.UseColumnTextForButtonValue = true;
            colGeymsluskra.Width = 97;
            // 
            // colVarslaSlod
            // 
            colVarslaSlod.DataPropertyName = "slod";
            colVarslaSlod.HeaderText = "Slóð";
            colVarslaSlod.Name = "colVarslaSlod";
            colVarslaSlod.Visible = false;
            // 
            // colVorsluID
            // 
            colVorsluID.DataPropertyName = "vorslustofnun";
            colVorsluID.HeaderText = "Vörslustofnun auðkenni";
            colVorsluID.Name = "colVorsluID";
            colVorsluID.Visible = false;
            // 
            // uscMidlun
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(m_tacMidlun);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uscMidlun";
            Size = new Size(1842, 912);
            ((System.ComponentModel.ISupportInitialize)m_dgvUtgafur).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            m_grbStatus.ResumeLayout(false);
            m_grbStatus.PerformLayout();
            m_grbFyrirspurnir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvFyrirSpurnir).EndInit();
            m_grbVorsluutgafur.ResumeLayout(false);
            m_tacMidlun.ResumeLayout(false);
            m_tap_HRM_ACCESS.ResumeLayout(false);
            m_tapVorslur.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            m_grbKlasar.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            m_grbUtgafur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvUtafurKlasarVarsla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView m_dgvUtgafur;
        private SplitContainer splitContainer1;
        private Label m_lblGognStatus;
        private Label m_lblToflurStatus;
        private ProgressBar m_prbGogn;
        private ProgressBar m_prbToflur;
        private DataGridView m_dgvFyrirSpurnir;
        private Button m_btnEndurHressa;
        private DataGridViewTextBoxColumn m_comID;
        private DataGridViewTextBoxColumn colVorsluutgafu;
        private DataGridViewTextBoxColumn colTitill;
        private DataGridViewTextBoxColumn colVorslustofnun;
        private DataGridViewTextBoxColumn colHeitiVarsla;
        private DataGridViewTextBoxColumn colSkjalamyndari;
        private DataGridViewTextBoxColumn colSkjalmHeiti;
        private DataGridViewTextBoxColumn colStaerd;
        private DataGridViewTextBoxColumn colSlod;
        private DataGridViewTextBoxColumn colInnihald;
        private DataGridViewTextBoxColumn colTimabil;
        private DataGridViewTextBoxColumn colAfhArNR;
        private DataGridViewTextBoxColumn colMD5;
        private DataGridViewTextBoxColumn colAdgangur;
        private DataGridViewTextBoxColumn colHverSkradi;
        private DataGridViewTextBoxColumn colDagsSkráð;
        private DataGridViewButtonColumn colBtnBirta;
        private DataGridViewTextBoxColumn colEytt;
        private DataGridViewTextBoxColumn colMidlad;
        private Label label1;
        private Button m_btnkeyra;
        private Label m_lblValinVorsluutgafa;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colFyrirNafn;
        private DataGridViewTextBoxColumn colFyrirFyrirspurn;
        private DataGridViewTextBoxColumn colFyrirLýsing;
        private DataGridViewButtonColumn colBtnPrófa;
        private DataGridViewTextBoxColumn colFyrirDatabase;
        private DataGridViewButtonColumn colBtnVista;
        private GroupBox m_grbStatus;
        private GroupBox m_grbFyrirspurnir;
        private GroupBox m_grbVorsluutgafur;
        private TabControl m_tacMidlun;
        private TabPage m_tap_HRM_ACCESS;
        private TabPage m_tapVorslur;
        private SplitContainer splitContainer3;
        private TreeView m_trwKlasarVorslustonun;
        private SplitContainer splitContainer2;
        private GroupBox m_grbKlasar;
        private GroupBox m_grbUtgafur;
        private DataGridView m_dgvUtafurKlasarVarsla;
        private Button m_btnBuaTilPakka;
        private Label m_lblKlasiVarslaValinn;
        private ProgressBar m_prgBackup;
        private Label m_lblBackupStatus;
        private Label m_lblStatus;
        private Label m_lblVorsluStofnunPrg;
        private ProgressBar m_prgVorsluStofnun;
        private Label label2;
        private ProgressBar progressBar1;
        private CheckBox m_chbOCR;
        private Button m_btnUppfæra;
        private Label m_lblTegundVorslu;
        private DataGridViewTextBoxColumn colAudkenni;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn colVorslustofun;
        private DataGridViewTextBoxColumn colTegund;
        private DataGridViewCheckBoxColumn colTaka;
        private DataGridViewButtonColumn colGeymsluskra;
        private DataGridViewTextBoxColumn colVarslaSlod;
        private DataGridViewTextBoxColumn colVorsluID;
    }
}
