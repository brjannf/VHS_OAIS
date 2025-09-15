namespace OAIS_ADMIN
{
    partial class uscGeymsluMidlar
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
            m_dgvDrif = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colComID = new DataGridViewTextBoxColumn();
            colSlod = new DataGridViewTextBoxColumn();
            colFormat = new DataGridViewTextBoxColumn();
            colNotad = new DataGridViewTextBoxColumn();
            colLaust = new DataGridViewTextBoxColumn();
            colHeild = new DataGridViewTextBoxColumn();
            colTegund = new DataGridViewTextBoxColumn();
            colFramleitt = new DataGridViewTextBoxColumn();
            colVirk = new DataGridViewCheckBoxColumn();
            colbtnOpna = new DataGridViewButtonColumn();
            colbtnSkoda = new DataGridViewButtonColumn();
            splitContainer1 = new SplitContainer();
            m_grbTolvur = new GroupBox();
            m_trwTolvur = new TreeView();
            splitContainer2 = new SplitContainer();
            m_grValinVel = new GroupBox();
            m_lblDate = new Label();
            m_lblHeiti = new Label();
            m_lblID = new Label();
            m_lblModel = new Label();
            m_lblSerial = new Label();
            m_grbDrif = new GroupBox();
            m_grbAfritun = new GroupBox();
            splitContainer3 = new SplitContainer();
            m_comHvarGeymt = new ComboBox();
            m_lblBackupStatus = new Label();
            label1 = new Label();
            m_lblHvadAfrita = new Label();
            label2 = new Label();
            m_btnTakaAfrit = new Button();
            m_comAfritDrif = new ComboBox();
            m_grbAfritATH = new GroupBox();
            m_tboAfritATH = new TextBox();
            m_prgBackup = new ProgressBar();
            m_grbAfritunListi = new GroupBox();
            m_dgvBackup = new DataGridView();
            colBackID = new DataGridViewTextBoxColumn();
            colBackDrifID = new DataGridViewTextBoxColumn();
            colBackMerking = new DataGridViewTextBoxColumn();
            colBackSlod = new DataGridViewTextBoxColumn();
            colBackStaerd = new DataGridViewTextBoxColumn();
            colBackGeymt = new DataGridViewTextBoxColumn();
            colbackAthugasemdir = new DataGridViewTextBoxColumn();
            colBackHver = new DataGridViewTextBoxColumn();
            colBackDags = new DataGridViewTextBoxColumn();
            colBackBtnRestore = new DataGridViewButtonColumn();
            colBackBtnOpna = new DataGridViewButtonColumn();
            folderBrowserDialog1 = new FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)m_dgvDrif).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            m_grbTolvur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            m_grValinVel.SuspendLayout();
            m_grbDrif.SuspendLayout();
            m_grbAfritun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            m_grbAfritATH.SuspendLayout();
            m_grbAfritunListi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvBackup).BeginInit();
            SuspendLayout();
            // 
            // m_dgvDrif
            // 
            m_dgvDrif.AllowUserToAddRows = false;
            m_dgvDrif.AllowUserToDeleteRows = false;
            m_dgvDrif.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvDrif.Columns.AddRange(new DataGridViewColumn[] { colID, colComID, colSlod, colFormat, colNotad, colLaust, colHeild, colTegund, colFramleitt, colVirk, colbtnOpna, colbtnSkoda });
            m_dgvDrif.Dock = DockStyle.Fill;
            m_dgvDrif.Location = new Point(3, 25);
            m_dgvDrif.Name = "m_dgvDrif";
            m_dgvDrif.ReadOnly = true;
            m_dgvDrif.RowHeadersVisible = false;
            m_dgvDrif.RowTemplate.Height = 25;
            m_dgvDrif.Size = new Size(1290, 78);
            m_dgvDrif.TabIndex = 0;
            m_dgvDrif.CellClick += m_dgvDrif_CellClick;
            // 
            // colID
            // 
            colID.DataPropertyName = "id";
            colID.HeaderText = "ID";
            colID.Name = "colID";
            colID.ReadOnly = true;
            colID.Visible = false;
            // 
            // colComID
            // 
            colComID.DataPropertyName = "comId";
            colComID.HeaderText = "comID";
            colComID.Name = "colComID";
            colComID.ReadOnly = true;
            colComID.Visible = false;
            // 
            // colSlod
            // 
            colSlod.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSlod.DataPropertyName = "nafn";
            colSlod.HeaderText = "Slóð á vörsluútgáfur";
            colSlod.Name = "colSlod";
            colSlod.ReadOnly = true;
            // 
            // colFormat
            // 
            colFormat.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colFormat.DataPropertyName = "format";
            colFormat.HeaderText = "Format drifs";
            colFormat.Name = "colFormat";
            colFormat.ReadOnly = true;
            colFormat.Width = 114;
            // 
            // colNotad
            // 
            colNotad.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colNotad.DataPropertyName = "notad";
            colNotad.HeaderText = "Svæði notað";
            colNotad.Name = "colNotad";
            colNotad.ReadOnly = true;
            colNotad.Width = 114;
            // 
            // colLaust
            // 
            colLaust.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colLaust.DataPropertyName = "laust";
            colLaust.HeaderText = "Laust svæði";
            colLaust.Name = "colLaust";
            colLaust.ReadOnly = true;
            colLaust.Width = 108;
            // 
            // colHeild
            // 
            colHeild.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colHeild.DataPropertyName = "heild";
            colHeild.HeaderText = "Heildarstærð";
            colHeild.Name = "colHeild";
            colHeild.ReadOnly = true;
            colHeild.Width = 129;
            // 
            // colTegund
            // 
            colTegund.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTegund.DataPropertyName = "tegund";
            colTegund.HeaderText = "Merking drifs";
            colTegund.Name = "colTegund";
            colTegund.ReadOnly = true;
            colTegund.Width = 122;
            // 
            // colFramleitt
            // 
            colFramleitt.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colFramleitt.DataPropertyName = "framleitt";
            colFramleitt.HeaderText = "Framleiðsludagsetning";
            colFramleitt.Name = "colFramleitt";
            colFramleitt.ReadOnly = true;
            colFramleitt.Width = 199;
            // 
            // colVirk
            // 
            colVirk.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colVirk.DataPropertyName = "virk";
            colVirk.HeaderText = "Virkt";
            colVirk.Name = "colVirk";
            colVirk.ReadOnly = true;
            colVirk.Width = 50;
            // 
            // colbtnOpna
            // 
            colbtnOpna.HeaderText = "Opna drif";
            colbtnOpna.Name = "colbtnOpna";
            colbtnOpna.ReadOnly = true;
            colbtnOpna.Text = "Opna";
            colbtnOpna.UseColumnTextForButtonValue = true;
            // 
            // colbtnSkoda
            // 
            colbtnSkoda.HeaderText = "Skoða logg";
            colbtnSkoda.Name = "colbtnSkoda";
            colbtnSkoda.ReadOnly = true;
            colbtnSkoda.Text = "Skoða";
            colbtnSkoda.UseColumnTextForButtonValue = true;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(m_grbTolvur);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1521, 743);
            splitContainer1.SplitterDistance = 217;
            splitContainer1.TabIndex = 2;
            // 
            // m_grbTolvur
            // 
            m_grbTolvur.Controls.Add(m_trwTolvur);
            m_grbTolvur.Dock = DockStyle.Fill;
            m_grbTolvur.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            m_grbTolvur.ForeColor = SystemColors.ControlText;
            m_grbTolvur.Location = new Point(0, 0);
            m_grbTolvur.Name = "m_grbTolvur";
            m_grbTolvur.Size = new Size(213, 739);
            m_grbTolvur.TabIndex = 1;
            m_grbTolvur.TabStop = false;
            m_grbTolvur.Text = "Tölvubúnaður";
            // 
            // m_trwTolvur
            // 
            m_trwTolvur.Dock = DockStyle.Fill;
            m_trwTolvur.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            m_trwTolvur.Location = new Point(3, 25);
            m_trwTolvur.Name = "m_trwTolvur";
            m_trwTolvur.Size = new Size(207, 711);
            m_trwTolvur.TabIndex = 0;
            m_trwTolvur.AfterSelect += m_trwTolvur_AfterSelect;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(m_grValinVel);
            splitContainer2.Panel1.Controls.Add(m_grbDrif);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(m_grbAfritun);
            splitContainer2.Size = new Size(1300, 743);
            splitContainer2.SplitterDistance = 230;
            splitContainer2.TabIndex = 2;
            // 
            // m_grValinVel
            // 
            m_grValinVel.Controls.Add(m_lblDate);
            m_grValinVel.Controls.Add(m_lblHeiti);
            m_grValinVel.Controls.Add(m_lblID);
            m_grValinVel.Controls.Add(m_lblModel);
            m_grValinVel.Controls.Add(m_lblSerial);
            m_grValinVel.Dock = DockStyle.Fill;
            m_grValinVel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            m_grValinVel.Location = new Point(0, 0);
            m_grValinVel.Name = "m_grValinVel";
            m_grValinVel.Size = new Size(1296, 120);
            m_grValinVel.TabIndex = 12;
            m_grValinVel.TabStop = false;
            m_grValinVel.Text = "Upplýsingar um tölvu";
            m_grValinVel.Visible = false;
            // 
            // m_lblDate
            // 
            m_lblDate.AutoSize = true;
            m_lblDate.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblDate.Location = new Point(18, 91);
            m_lblDate.Name = "m_lblDate";
            m_lblDate.Size = new Size(65, 25);
            m_lblDate.TabIndex = 11;
            m_lblDate.Text = "label3";
            // 
            // m_lblHeiti
            // 
            m_lblHeiti.AutoSize = true;
            m_lblHeiti.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblHeiti.Location = new Point(18, 60);
            m_lblHeiti.Name = "m_lblHeiti";
            m_lblHeiti.Size = new Size(65, 25);
            m_lblHeiti.TabIndex = 7;
            m_lblHeiti.Text = "label1";
            // 
            // m_lblID
            // 
            m_lblID.AutoSize = true;
            m_lblID.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblID.Location = new Point(18, 120);
            m_lblID.Name = "m_lblID";
            m_lblID.Size = new Size(65, 25);
            m_lblID.TabIndex = 10;
            m_lblID.Text = "label2";
            // 
            // m_lblModel
            // 
            m_lblModel.AutoSize = true;
            m_lblModel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblModel.Location = new Point(18, 25);
            m_lblModel.Name = "m_lblModel";
            m_lblModel.Size = new Size(65, 25);
            m_lblModel.TabIndex = 8;
            m_lblModel.Text = "label2";
            // 
            // m_lblSerial
            // 
            m_lblSerial.AutoSize = true;
            m_lblSerial.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblSerial.Location = new Point(18, 152);
            m_lblSerial.Name = "m_lblSerial";
            m_lblSerial.Size = new Size(65, 25);
            m_lblSerial.TabIndex = 9;
            m_lblSerial.Text = "label3";
            // 
            // m_grbDrif
            // 
            m_grbDrif.Controls.Add(m_dgvDrif);
            m_grbDrif.Dock = DockStyle.Bottom;
            m_grbDrif.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            m_grbDrif.Location = new Point(0, 120);
            m_grbDrif.Name = "m_grbDrif";
            m_grbDrif.Size = new Size(1296, 106);
            m_grbDrif.TabIndex = 1;
            m_grbDrif.TabStop = false;
            m_grbDrif.Text = "Drif";
            m_grbDrif.Visible = false;
            // 
            // m_grbAfritun
            // 
            m_grbAfritun.Controls.Add(splitContainer3);
            m_grbAfritun.Dock = DockStyle.Fill;
            m_grbAfritun.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            m_grbAfritun.Location = new Point(0, 0);
            m_grbAfritun.Name = "m_grbAfritun";
            m_grbAfritun.Size = new Size(1296, 505);
            m_grbAfritun.TabIndex = 0;
            m_grbAfritun.TabStop = false;
            m_grbAfritun.Text = "Afritun (backup)";
            m_grbAfritun.Visible = false;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(3, 25);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(m_comHvarGeymt);
            splitContainer3.Panel1.Controls.Add(m_lblBackupStatus);
            splitContainer3.Panel1.Controls.Add(label1);
            splitContainer3.Panel1.Controls.Add(m_lblHvadAfrita);
            splitContainer3.Panel1.Controls.Add(label2);
            splitContainer3.Panel1.Controls.Add(m_btnTakaAfrit);
            splitContainer3.Panel1.Controls.Add(m_comAfritDrif);
            splitContainer3.Panel1.Controls.Add(m_grbAfritATH);
            splitContainer3.Panel1.Controls.Add(m_prgBackup);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(m_grbAfritunListi);
            splitContainer3.Size = new Size(1290, 477);
            splitContainer3.SplitterDistance = 200;
            splitContainer3.TabIndex = 13;
            // 
            // m_comHvarGeymt
            // 
            m_comHvarGeymt.DropDownStyle = ComboBoxStyle.DropDownList;
            m_comHvarGeymt.FormattingEnabled = true;
            m_comHvarGeymt.Items.AddRange(new object[] { "Veldu geymslustað\t", "HKOP", "HMOS", "HARN" });
            m_comHvarGeymt.Location = new Point(237, 87);
            m_comHvarGeymt.Name = "m_comHvarGeymt";
            m_comHvarGeymt.Size = new Size(308, 29);
            m_comHvarGeymt.TabIndex = 10;
            // 
            // m_lblBackupStatus
            // 
            m_lblBackupStatus.AutoSize = true;
            m_lblBackupStatus.Location = new Point(1027, 186);
            m_lblBackupStatus.Name = "m_lblBackupStatus";
            m_lblBackupStatus.Size = new Size(105, 21);
            m_lblBackupStatus.TabIndex = 12;
            m_lblBackupStatus.Text = "Hvar geymt?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 87);
            label1.Name = "label1";
            label1.Size = new Size(189, 21);
            label1.TabIndex = 1;
            label1.Text = "Hvar verður afrit geymt";
            // 
            // m_lblHvadAfrita
            // 
            m_lblHvadAfrita.AutoSize = true;
            m_lblHvadAfrita.Location = new Point(116, 144);
            m_lblHvadAfrita.Name = "m_lblHvadAfrita";
            m_lblHvadAfrita.Size = new Size(97, 21);
            m_lblHvadAfrita.TabIndex = 11;
            m_lblHvadAfrita.Text = "Hvaða drif?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 26);
            label2.Name = "label2";
            label2.Size = new Size(192, 21);
            label2.TabIndex = 3;
            label2.Text = "Drif sem afrit er vistað á";
            // 
            // m_btnTakaAfrit
            // 
            m_btnTakaAfrit.Location = new Point(1156, 171);
            m_btnTakaAfrit.Name = "m_btnTakaAfrit";
            m_btnTakaAfrit.Size = new Size(114, 43);
            m_btnTakaAfrit.TabIndex = 5;
            m_btnTakaAfrit.Text = "Taka afrit";
            m_btnTakaAfrit.UseVisualStyleBackColor = true;
            m_btnTakaAfrit.Click += m_btnTakaAfrit_Click;
            // 
            // m_comAfritDrif
            // 
            m_comAfritDrif.DropDownStyle = ComboBoxStyle.DropDownList;
            m_comAfritDrif.FormattingEnabled = true;
            m_comAfritDrif.Location = new Point(237, 23);
            m_comAfritDrif.Name = "m_comAfritDrif";
            m_comAfritDrif.Size = new Size(308, 29);
            m_comAfritDrif.TabIndex = 9;
            // 
            // m_grbAfritATH
            // 
            m_grbAfritATH.Controls.Add(m_tboAfritATH);
            m_grbAfritATH.Location = new Point(612, 14);
            m_grbAfritATH.Name = "m_grbAfritATH";
            m_grbAfritATH.Size = new Size(658, 151);
            m_grbAfritATH.TabIndex = 7;
            m_grbAfritATH.TabStop = false;
            m_grbAfritATH.Text = "Athugasemdir";
            // 
            // m_tboAfritATH
            // 
            m_tboAfritATH.Dock = DockStyle.Fill;
            m_tboAfritATH.Location = new Point(3, 25);
            m_tboAfritATH.Multiline = true;
            m_tboAfritATH.Name = "m_tboAfritATH";
            m_tboAfritATH.Size = new Size(652, 123);
            m_tboAfritATH.TabIndex = 6;
            // 
            // m_prgBackup
            // 
            m_prgBackup.Location = new Point(237, 186);
            m_prgBackup.Name = "m_prgBackup";
            m_prgBackup.Size = new Size(745, 23);
            m_prgBackup.TabIndex = 8;
            // 
            // m_grbAfritunListi
            // 
            m_grbAfritunListi.Controls.Add(m_dgvBackup);
            m_grbAfritunListi.Dock = DockStyle.Fill;
            m_grbAfritunListi.Location = new Point(0, 0);
            m_grbAfritunListi.Name = "m_grbAfritunListi";
            m_grbAfritunListi.Size = new Size(1290, 273);
            m_grbAfritunListi.TabIndex = 1;
            m_grbAfritunListi.TabStop = false;
            m_grbAfritunListi.Text = "Afrit tekinn";
            // 
            // m_dgvBackup
            // 
            m_dgvBackup.AllowUserToAddRows = false;
            m_dgvBackup.AllowUserToDeleteRows = false;
            m_dgvBackup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvBackup.Columns.AddRange(new DataGridViewColumn[] { colBackID, colBackDrifID, colBackMerking, colBackSlod, colBackStaerd, colBackGeymt, colbackAthugasemdir, colBackHver, colBackDags, colBackBtnRestore, colBackBtnOpna });
            m_dgvBackup.Dock = DockStyle.Fill;
            m_dgvBackup.Location = new Point(3, 25);
            m_dgvBackup.Name = "m_dgvBackup";
            m_dgvBackup.ReadOnly = true;
            m_dgvBackup.RowHeadersVisible = false;
            m_dgvBackup.RowTemplate.Height = 25;
            m_dgvBackup.Size = new Size(1284, 245);
            m_dgvBackup.TabIndex = 0;
            m_dgvBackup.DataSourceChanged += m_dgvBackup_DataSourceChanged;
            m_dgvBackup.CellClick += m_dgvBackup_CellClick;
            // 
            // colBackID
            // 
            colBackID.DataPropertyName = "id";
            colBackID.HeaderText = "ID";
            colBackID.Name = "colBackID";
            colBackID.ReadOnly = true;
            // 
            // colBackDrifID
            // 
            colBackDrifID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBackDrifID.DataPropertyName = "drifid";
            colBackDrifID.HeaderText = "DrifID";
            colBackDrifID.Name = "colBackDrifID";
            colBackDrifID.ReadOnly = true;
            colBackDrifID.Visible = false;
            // 
            // colBackMerking
            // 
            colBackMerking.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBackMerking.DataPropertyName = "merking";
            colBackMerking.HeaderText = "Merking drifs";
            colBackMerking.Name = "colBackMerking";
            colBackMerking.ReadOnly = true;
            colBackMerking.Width = 125;
            // 
            // colBackSlod
            // 
            colBackSlod.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBackSlod.DataPropertyName = "slodAfrit";
            colBackSlod.HeaderText = "Slóð á drifi";
            colBackSlod.Name = "colBackSlod";
            colBackSlod.ReadOnly = true;
            colBackSlod.Width = 108;
            // 
            // colBackStaerd
            // 
            colBackStaerd.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBackStaerd.DataPropertyName = "steard";
            colBackStaerd.HeaderText = "Stærð";
            colBackStaerd.Name = "colBackStaerd";
            colBackStaerd.ReadOnly = true;
            colBackStaerd.Width = 79;
            // 
            // colBackGeymt
            // 
            colBackGeymt.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBackGeymt.DataPropertyName = "hvar_geymt";
            colBackGeymt.HeaderText = "Hvar geymt";
            colBackGeymt.Name = "colBackGeymt";
            colBackGeymt.ReadOnly = true;
            colBackGeymt.Width = 114;
            // 
            // colbackAthugasemdir
            // 
            colbackAthugasemdir.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colbackAthugasemdir.DataPropertyName = "athugasemdir";
            colbackAthugasemdir.HeaderText = "Athugasemdir";
            colbackAthugasemdir.Name = "colbackAthugasemdir";
            colbackAthugasemdir.ReadOnly = true;
            // 
            // colBackHver
            // 
            colBackHver.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBackHver.DataPropertyName = "hvar_afritadi";
            colBackHver.HeaderText = "Hver tók afrit";
            colBackHver.Name = "colBackHver";
            colBackHver.ReadOnly = true;
            colBackHver.Width = 96;
            // 
            // colBackDags
            // 
            colBackDags.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBackDags.DataPropertyName = "dagsetning";
            colBackDags.HeaderText = "Dagsetning afritunar";
            colBackDags.Name = "colBackDags";
            colBackDags.ReadOnly = true;
            colBackDags.Width = 177;
            // 
            // colBackBtnRestore
            // 
            colBackBtnRestore.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBackBtnRestore.HeaderText = "Endurheimta (restore)";
            colBackBtnRestore.Name = "colBackBtnRestore";
            colBackBtnRestore.ReadOnly = true;
            colBackBtnRestore.Resizable = DataGridViewTriState.True;
            colBackBtnRestore.SortMode = DataGridViewColumnSortMode.Automatic;
            colBackBtnRestore.Text = "Endurheimta";
            colBackBtnRestore.UseColumnTextForButtonValue = true;
            colBackBtnRestore.Width = 185;
            // 
            // colBackBtnOpna
            // 
            colBackBtnOpna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colBackBtnOpna.HeaderText = "Opna afrit";
            colBackBtnOpna.Name = "colBackBtnOpna";
            colBackBtnOpna.ReadOnly = true;
            colBackBtnOpna.Resizable = DataGridViewTriState.True;
            colBackBtnOpna.SortMode = DataGridViewColumnSortMode.Automatic;
            colBackBtnOpna.Text = "Opna";
            colBackBtnOpna.UseColumnTextForButtonValue = true;
            colBackBtnOpna.Width = 103;
            // 
            // uscGeymsluMidlar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "uscGeymsluMidlar";
            Size = new Size(1521, 743);
            ((System.ComponentModel.ISupportInitialize)m_dgvDrif).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            m_grbTolvur.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            m_grValinVel.ResumeLayout(false);
            m_grValinVel.PerformLayout();
            m_grbDrif.ResumeLayout(false);
            m_grbAfritun.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            m_grbAfritATH.ResumeLayout(false);
            m_grbAfritATH.PerformLayout();
            m_grbAfritunListi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvBackup).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView m_dgvDrif;
        private SplitContainer splitContainer1;
        private TreeView m_trwTolvur;
        private GroupBox m_grbTolvur;
        private SplitContainer splitContainer2;
        private GroupBox m_grbDrif;
        private Label m_lblID;
        private Label m_lblSerial;
        private Label m_lblModel;
        private Label m_lblHeiti;
        private Label m_lblDate;
        private GroupBox m_grbAfritun;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colComID;
        private DataGridViewTextBoxColumn colSlod;
        private DataGridViewTextBoxColumn colFormat;
        private DataGridViewTextBoxColumn colNotad;
        private DataGridViewTextBoxColumn colLaust;
        private DataGridViewTextBoxColumn colHeild;
        private DataGridViewTextBoxColumn colTegund;
        private DataGridViewTextBoxColumn colFramleitt;
        private DataGridViewCheckBoxColumn colVirk;
        private DataGridViewButtonColumn colbtnOpna;
        private DataGridViewButtonColumn colbtnSkoda;
        private Label label1;
        private DataGridView m_dgvBackup;
        private ProgressBar progressBar1;
        private GroupBox m_grbAfritATH;
        private TextBox m_tboAfritATH;
        private Button m_btnTakaAfrit;
        private Label label2;
        private ComboBox m_comHvarGeymt;
        private ComboBox m_comAfritDrif;
        private Label m_lblHvadAfrita;
        private ProgressBar m_prgBackup;
        private Label m_lblBackupStatus;
        private DataGridViewTextBoxColumn colBackID;
        private DataGridViewTextBoxColumn colBackDrifID;
        private DataGridViewTextBoxColumn colBackMerking;
        private DataGridViewTextBoxColumn colBackSlod;
        private DataGridViewTextBoxColumn colBackStaerd;
        private DataGridViewTextBoxColumn colBackGeymt;
        private DataGridViewTextBoxColumn colbackAthugasemdir;
        private DataGridViewTextBoxColumn colBackHver;
        private DataGridViewTextBoxColumn colBackDags;
        private DataGridViewButtonColumn colBackBtnRestore;
        private DataGridViewButtonColumn colBackBtnOpna;
        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox m_grValinVel;
        private SplitContainer splitContainer3;
        private GroupBox m_grbAfritunListi;
    }
}
