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
            this.m_dgvDrif = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLaust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTegund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFramleitt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVirk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colbtnOpna = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colbtnSkoda = new System.Windows.Forms.DataGridViewButtonColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_grbTolvur = new System.Windows.Forms.GroupBox();
            this.m_trwTolvur = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_grValinVel = new System.Windows.Forms.GroupBox();
            this.m_lblDate = new System.Windows.Forms.Label();
            this.m_lblHeiti = new System.Windows.Forms.Label();
            this.m_lblID = new System.Windows.Forms.Label();
            this.m_lblModel = new System.Windows.Forms.Label();
            this.m_lblSerial = new System.Windows.Forms.Label();
            this.m_grbDrif = new System.Windows.Forms.GroupBox();
            this.m_grbAfritun = new System.Windows.Forms.GroupBox();
            this.m_lblBackupStatus = new System.Windows.Forms.Label();
            this.m_lblHvadAfrita = new System.Windows.Forms.Label();
            this.m_comHvarGeymt = new System.Windows.Forms.ComboBox();
            this.m_comAfritDrif = new System.Windows.Forms.ComboBox();
            this.m_prgBackup = new System.Windows.Forms.ProgressBar();
            this.m_grbAfritATH = new System.Windows.Forms.GroupBox();
            this.m_tboAfritATH = new System.Windows.Forms.TextBox();
            this.m_btnTakaAfrit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dgvBackup = new System.Windows.Forms.DataGridView();
            this.colBackID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackDrifID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackMerking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackSlod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackStaerd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackGeymt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbackAthugasemdir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackHver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackDags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackBtnRestore = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBackBtnOpna = new System.Windows.Forms.DataGridViewButtonColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_grbTolvur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.m_grValinVel.SuspendLayout();
            this.m_grbDrif.SuspendLayout();
            this.m_grbAfritun.SuspendLayout();
            this.m_grbAfritATH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBackup)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgvDrif
            // 
            this.m_dgvDrif.AllowUserToAddRows = false;
            this.m_dgvDrif.AllowUserToDeleteRows = false;
            this.m_dgvDrif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvDrif.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colComID,
            this.colSlod,
            this.colFormat,
            this.colNotad,
            this.colLaust,
            this.colHeild,
            this.colTegund,
            this.colFramleitt,
            this.colVirk,
            this.colbtnOpna,
            this.colbtnSkoda});
            this.m_dgvDrif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDrif.Location = new System.Drawing.Point(3, 25);
            this.m_dgvDrif.Name = "m_dgvDrif";
            this.m_dgvDrif.ReadOnly = true;
            this.m_dgvDrif.RowHeadersVisible = false;
            this.m_dgvDrif.RowTemplate.Height = 25;
            this.m_dgvDrif.Size = new System.Drawing.Size(918, 93);
            this.m_dgvDrif.TabIndex = 0;
            this.m_dgvDrif.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrif_CellClick);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "id";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colComID
            // 
            this.colComID.DataPropertyName = "comId";
            this.colComID.HeaderText = "comID";
            this.colComID.Name = "colComID";
            this.colComID.ReadOnly = true;
            this.colComID.Visible = false;
            // 
            // colSlod
            // 
            this.colSlod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSlod.DataPropertyName = "nafn";
            this.colSlod.HeaderText = "Slóð á vörsluútgáfur";
            this.colSlod.Name = "colSlod";
            this.colSlod.ReadOnly = true;
            // 
            // colFormat
            // 
            this.colFormat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFormat.DataPropertyName = "format";
            this.colFormat.HeaderText = "Format drifs";
            this.colFormat.Name = "colFormat";
            this.colFormat.ReadOnly = true;
            this.colFormat.Width = 114;
            // 
            // colNotad
            // 
            this.colNotad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNotad.DataPropertyName = "notad";
            this.colNotad.HeaderText = "Svæði notað";
            this.colNotad.Name = "colNotad";
            this.colNotad.ReadOnly = true;
            this.colNotad.Width = 114;
            // 
            // colLaust
            // 
            this.colLaust.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLaust.DataPropertyName = "laust";
            this.colLaust.HeaderText = "Laust svæði";
            this.colLaust.Name = "colLaust";
            this.colLaust.ReadOnly = true;
            this.colLaust.Width = 108;
            // 
            // colHeild
            // 
            this.colHeild.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHeild.DataPropertyName = "heild";
            this.colHeild.HeaderText = "Heildarstærð";
            this.colHeild.Name = "colHeild";
            this.colHeild.ReadOnly = true;
            this.colHeild.Width = 129;
            // 
            // colTegund
            // 
            this.colTegund.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTegund.DataPropertyName = "tegund";
            this.colTegund.HeaderText = "Merking drifs";
            this.colTegund.Name = "colTegund";
            this.colTegund.ReadOnly = true;
            this.colTegund.Width = 122;
            // 
            // colFramleitt
            // 
            this.colFramleitt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFramleitt.DataPropertyName = "framleitt";
            this.colFramleitt.HeaderText = "Framleiðsludagsetning";
            this.colFramleitt.Name = "colFramleitt";
            this.colFramleitt.ReadOnly = true;
            this.colFramleitt.Width = 199;
            // 
            // colVirk
            // 
            this.colVirk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colVirk.DataPropertyName = "virk";
            this.colVirk.HeaderText = "Virkt";
            this.colVirk.Name = "colVirk";
            this.colVirk.ReadOnly = true;
            this.colVirk.Width = 50;
            // 
            // colbtnOpna
            // 
            this.colbtnOpna.HeaderText = "Opna drif";
            this.colbtnOpna.Name = "colbtnOpna";
            this.colbtnOpna.ReadOnly = true;
            this.colbtnOpna.Text = "Opna";
            this.colbtnOpna.UseColumnTextForButtonValue = true;
            // 
            // colbtnSkoda
            // 
            this.colbtnSkoda.HeaderText = "Skoða logg";
            this.colbtnSkoda.Name = "colbtnSkoda";
            this.colbtnSkoda.ReadOnly = true;
            this.colbtnSkoda.Text = "Skoða";
            this.colbtnSkoda.UseColumnTextForButtonValue = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_grbTolvur);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1397, 743);
            this.splitContainer1.SplitterDistance = 465;
            this.splitContainer1.TabIndex = 2;
            // 
            // m_grbTolvur
            // 
            this.m_grbTolvur.Controls.Add(this.m_trwTolvur);
            this.m_grbTolvur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbTolvur.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_grbTolvur.Location = new System.Drawing.Point(0, 0);
            this.m_grbTolvur.Name = "m_grbTolvur";
            this.m_grbTolvur.Size = new System.Drawing.Size(461, 739);
            this.m_grbTolvur.TabIndex = 1;
            this.m_grbTolvur.TabStop = false;
            this.m_grbTolvur.Text = "Tölvubúnaður";
            // 
            // m_trwTolvur
            // 
            this.m_trwTolvur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trwTolvur.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_trwTolvur.Location = new System.Drawing.Point(3, 19);
            this.m_trwTolvur.Name = "m_trwTolvur";
            this.m_trwTolvur.Size = new System.Drawing.Size(455, 717);
            this.m_trwTolvur.TabIndex = 0;
            this.m_trwTolvur.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trwTolvur_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_grValinVel);
            this.splitContainer2.Panel1.Controls.Add(this.m_grbDrif);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_grbAfritun);
            this.splitContainer2.Size = new System.Drawing.Size(928, 743);
            this.splitContainer2.SplitterDistance = 290;
            this.splitContainer2.TabIndex = 2;
            // 
            // m_grValinVel
            // 
            this.m_grValinVel.Controls.Add(this.m_lblDate);
            this.m_grValinVel.Controls.Add(this.m_lblHeiti);
            this.m_grValinVel.Controls.Add(this.m_lblID);
            this.m_grValinVel.Controls.Add(this.m_lblModel);
            this.m_grValinVel.Controls.Add(this.m_lblSerial);
            this.m_grValinVel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grValinVel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_grValinVel.Location = new System.Drawing.Point(0, 0);
            this.m_grValinVel.Name = "m_grValinVel";
            this.m_grValinVel.Size = new System.Drawing.Size(924, 165);
            this.m_grValinVel.TabIndex = 12;
            this.m_grValinVel.TabStop = false;
            this.m_grValinVel.Text = "Upplýsingar um tölvu";
            this.m_grValinVel.Visible = false;
            // 
            // m_lblDate
            // 
            this.m_lblDate.AutoSize = true;
            this.m_lblDate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblDate.Location = new System.Drawing.Point(18, 91);
            this.m_lblDate.Name = "m_lblDate";
            this.m_lblDate.Size = new System.Drawing.Size(65, 25);
            this.m_lblDate.TabIndex = 11;
            this.m_lblDate.Text = "label3";
            // 
            // m_lblHeiti
            // 
            this.m_lblHeiti.AutoSize = true;
            this.m_lblHeiti.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblHeiti.Location = new System.Drawing.Point(18, 60);
            this.m_lblHeiti.Name = "m_lblHeiti";
            this.m_lblHeiti.Size = new System.Drawing.Size(65, 25);
            this.m_lblHeiti.TabIndex = 7;
            this.m_lblHeiti.Text = "label1";
            // 
            // m_lblID
            // 
            this.m_lblID.AutoSize = true;
            this.m_lblID.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblID.Location = new System.Drawing.Point(18, 120);
            this.m_lblID.Name = "m_lblID";
            this.m_lblID.Size = new System.Drawing.Size(65, 25);
            this.m_lblID.TabIndex = 10;
            this.m_lblID.Text = "label2";
            // 
            // m_lblModel
            // 
            this.m_lblModel.AutoSize = true;
            this.m_lblModel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblModel.Location = new System.Drawing.Point(18, 25);
            this.m_lblModel.Name = "m_lblModel";
            this.m_lblModel.Size = new System.Drawing.Size(65, 25);
            this.m_lblModel.TabIndex = 8;
            this.m_lblModel.Text = "label2";
            // 
            // m_lblSerial
            // 
            this.m_lblSerial.AutoSize = true;
            this.m_lblSerial.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblSerial.Location = new System.Drawing.Point(18, 152);
            this.m_lblSerial.Name = "m_lblSerial";
            this.m_lblSerial.Size = new System.Drawing.Size(65, 25);
            this.m_lblSerial.TabIndex = 9;
            this.m_lblSerial.Text = "label3";
            // 
            // m_grbDrif
            // 
            this.m_grbDrif.Controls.Add(this.m_dgvDrif);
            this.m_grbDrif.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_grbDrif.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_grbDrif.Location = new System.Drawing.Point(0, 165);
            this.m_grbDrif.Name = "m_grbDrif";
            this.m_grbDrif.Size = new System.Drawing.Size(924, 121);
            this.m_grbDrif.TabIndex = 1;
            this.m_grbDrif.TabStop = false;
            this.m_grbDrif.Text = "Drif";
            this.m_grbDrif.Visible = false;
            // 
            // m_grbAfritun
            // 
            this.m_grbAfritun.Controls.Add(this.m_lblBackupStatus);
            this.m_grbAfritun.Controls.Add(this.m_lblHvadAfrita);
            this.m_grbAfritun.Controls.Add(this.m_comHvarGeymt);
            this.m_grbAfritun.Controls.Add(this.m_comAfritDrif);
            this.m_grbAfritun.Controls.Add(this.m_prgBackup);
            this.m_grbAfritun.Controls.Add(this.m_grbAfritATH);
            this.m_grbAfritun.Controls.Add(this.m_btnTakaAfrit);
            this.m_grbAfritun.Controls.Add(this.label2);
            this.m_grbAfritun.Controls.Add(this.label1);
            this.m_grbAfritun.Controls.Add(this.m_dgvBackup);
            this.m_grbAfritun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbAfritun.Location = new System.Drawing.Point(0, 0);
            this.m_grbAfritun.Name = "m_grbAfritun";
            this.m_grbAfritun.Size = new System.Drawing.Size(924, 445);
            this.m_grbAfritun.TabIndex = 0;
            this.m_grbAfritun.TabStop = false;
            this.m_grbAfritun.Text = "Afritun (backup)";
            this.m_grbAfritun.Visible = false;
            // 
            // m_lblBackupStatus
            // 
            this.m_lblBackupStatus.AutoSize = true;
            this.m_lblBackupStatus.Location = new System.Drawing.Point(786, 148);
            this.m_lblBackupStatus.Name = "m_lblBackupStatus";
            this.m_lblBackupStatus.Size = new System.Drawing.Size(74, 15);
            this.m_lblBackupStatus.TabIndex = 12;
            this.m_lblBackupStatus.Text = "Hvar geymt?";
            // 
            // m_lblHvadAfrita
            // 
            this.m_lblHvadAfrita.AutoSize = true;
            this.m_lblHvadAfrita.Location = new System.Drawing.Point(105, 122);
            this.m_lblHvadAfrita.Name = "m_lblHvadAfrita";
            this.m_lblHvadAfrita.Size = new System.Drawing.Size(67, 15);
            this.m_lblHvadAfrita.TabIndex = 11;
            this.m_lblHvadAfrita.Text = "Hvaða drif?";
            // 
            // m_comHvarGeymt
            // 
            this.m_comHvarGeymt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comHvarGeymt.FormattingEnabled = true;
            this.m_comHvarGeymt.Items.AddRange(new object[] {
            "Veldu geymslustað\t",
            "HKOP",
            "HMOS",
            "HARN"});
            this.m_comHvarGeymt.Location = new System.Drawing.Point(118, 66);
            this.m_comHvarGeymt.Name = "m_comHvarGeymt";
            this.m_comHvarGeymt.Size = new System.Drawing.Size(132, 23);
            this.m_comHvarGeymt.TabIndex = 10;
            // 
            // m_comAfritDrif
            // 
            this.m_comAfritDrif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comAfritDrif.FormattingEnabled = true;
            this.m_comAfritDrif.Location = new System.Drawing.Point(118, 34);
            this.m_comAfritDrif.Name = "m_comAfritDrif";
            this.m_comAfritDrif.Size = new System.Drawing.Size(132, 23);
            this.m_comAfritDrif.TabIndex = 9;
            // 
            // m_prgBackup
            // 
            this.m_prgBackup.Location = new System.Drawing.Point(105, 140);
            this.m_prgBackup.Name = "m_prgBackup";
            this.m_prgBackup.Size = new System.Drawing.Size(666, 23);
            this.m_prgBackup.TabIndex = 8;
            // 
            // m_grbAfritATH
            // 
            this.m_grbAfritATH.Controls.Add(this.m_tboAfritATH);
            this.m_grbAfritATH.Location = new System.Drawing.Point(298, 22);
            this.m_grbAfritATH.Name = "m_grbAfritATH";
            this.m_grbAfritATH.Size = new System.Drawing.Size(473, 100);
            this.m_grbAfritATH.TabIndex = 7;
            this.m_grbAfritATH.TabStop = false;
            this.m_grbAfritATH.Text = "Athugasemdir";
            // 
            // m_tboAfritATH
            // 
            this.m_tboAfritATH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tboAfritATH.Location = new System.Drawing.Point(3, 19);
            this.m_tboAfritATH.Multiline = true;
            this.m_tboAfritATH.Name = "m_tboAfritATH";
            this.m_tboAfritATH.Size = new System.Drawing.Size(467, 78);
            this.m_tboAfritATH.TabIndex = 6;
            // 
            // m_btnTakaAfrit
            // 
            this.m_btnTakaAfrit.Location = new System.Drawing.Point(801, 88);
            this.m_btnTakaAfrit.Name = "m_btnTakaAfrit";
            this.m_btnTakaAfrit.Size = new System.Drawing.Size(75, 23);
            this.m_btnTakaAfrit.TabIndex = 5;
            this.m_btnTakaAfrit.Text = "Taka afrit";
            this.m_btnTakaAfrit.UseVisualStyleBackColor = true;
            this.m_btnTakaAfrit.Click += new System.EventHandler(this.m_btnTakaAfrit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hvaða drif?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hvar geymt?";
            // 
            // m_dgvBackup
            // 
            this.m_dgvBackup.AllowUserToAddRows = false;
            this.m_dgvBackup.AllowUserToDeleteRows = false;
            this.m_dgvBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBackID,
            this.colBackDrifID,
            this.colBackMerking,
            this.colBackSlod,
            this.colBackStaerd,
            this.colBackGeymt,
            this.colbackAthugasemdir,
            this.colBackHver,
            this.colBackDags,
            this.colBackBtnRestore,
            this.colBackBtnOpna});
            this.m_dgvBackup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_dgvBackup.Location = new System.Drawing.Point(3, 169);
            this.m_dgvBackup.Name = "m_dgvBackup";
            this.m_dgvBackup.ReadOnly = true;
            this.m_dgvBackup.RowHeadersVisible = false;
            this.m_dgvBackup.RowTemplate.Height = 25;
            this.m_dgvBackup.Size = new System.Drawing.Size(918, 273);
            this.m_dgvBackup.TabIndex = 0;
            this.m_dgvBackup.DataSourceChanged += new System.EventHandler(this.m_dgvBackup_DataSourceChanged);
            this.m_dgvBackup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvBackup_CellClick);
            // 
            // colBackID
            // 
            this.colBackID.DataPropertyName = "id";
            this.colBackID.HeaderText = "ID";
            this.colBackID.Name = "colBackID";
            this.colBackID.ReadOnly = true;
            // 
            // colBackDrifID
            // 
            this.colBackDrifID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBackDrifID.DataPropertyName = "drifid";
            this.colBackDrifID.HeaderText = "DrifID";
            this.colBackDrifID.Name = "colBackDrifID";
            this.colBackDrifID.ReadOnly = true;
            this.colBackDrifID.Visible = false;
            // 
            // colBackMerking
            // 
            this.colBackMerking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBackMerking.DataPropertyName = "merking";
            this.colBackMerking.HeaderText = "Merking drifs";
            this.colBackMerking.Name = "colBackMerking";
            this.colBackMerking.ReadOnly = true;
            this.colBackMerking.Width = 94;
            // 
            // colBackSlod
            // 
            this.colBackSlod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBackSlod.DataPropertyName = "slodAfrit";
            this.colBackSlod.HeaderText = "Slóð á drifi";
            this.colBackSlod.Name = "colBackSlod";
            this.colBackSlod.ReadOnly = true;
            this.colBackSlod.Width = 62;
            // 
            // colBackStaerd
            // 
            this.colBackStaerd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBackStaerd.DataPropertyName = "steard";
            this.colBackStaerd.HeaderText = "Stærð";
            this.colBackStaerd.Name = "colBackStaerd";
            this.colBackStaerd.ReadOnly = true;
            this.colBackStaerd.Width = 63;
            // 
            // colBackGeymt
            // 
            this.colBackGeymt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBackGeymt.DataPropertyName = "hvar_geymt";
            this.colBackGeymt.HeaderText = "Hvar geymt";
            this.colBackGeymt.Name = "colBackGeymt";
            this.colBackGeymt.ReadOnly = true;
            this.colBackGeymt.Width = 87;
            // 
            // colbackAthugasemdir
            // 
            this.colbackAthugasemdir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colbackAthugasemdir.DataPropertyName = "athugasemdir";
            this.colbackAthugasemdir.HeaderText = "Athugasemdir";
            this.colbackAthugasemdir.Name = "colbackAthugasemdir";
            this.colbackAthugasemdir.ReadOnly = true;
            // 
            // colBackHver
            // 
            this.colBackHver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBackHver.DataPropertyName = "hvar_afritadi";
            this.colBackHver.HeaderText = "Hver tók afrit";
            this.colBackHver.Name = "colBackHver";
            this.colBackHver.ReadOnly = true;
            this.colBackHver.Width = 74;
            // 
            // colBackDags
            // 
            this.colBackDags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBackDags.DataPropertyName = "dagsetning";
            this.colBackDags.HeaderText = "Dagsetning afritunar";
            this.colBackDags.Name = "colBackDags";
            this.colBackDags.ReadOnly = true;
            this.colBackDags.Width = 128;
            // 
            // colBackBtnRestore
            // 
            this.colBackBtnRestore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBackBtnRestore.HeaderText = "Endurheimta (restore)";
            this.colBackBtnRestore.Name = "colBackBtnRestore";
            this.colBackBtnRestore.ReadOnly = true;
            this.colBackBtnRestore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBackBtnRestore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBackBtnRestore.Text = "Endurheimta";
            this.colBackBtnRestore.UseColumnTextForButtonValue = true;
            this.colBackBtnRestore.Width = 134;
            // 
            // colBackBtnOpna
            // 
            this.colBackBtnOpna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBackBtnOpna.HeaderText = "Opna afrit";
            this.colBackBtnOpna.Name = "colBackBtnOpna";
            this.colBackBtnOpna.ReadOnly = true;
            this.colBackBtnOpna.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBackBtnOpna.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBackBtnOpna.Text = "Opna";
            this.colBackBtnOpna.UseColumnTextForButtonValue = true;
            this.colBackBtnOpna.Width = 79;
            // 
            // uscGeymsluMidlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "uscGeymsluMidlar";
            this.Size = new System.Drawing.Size(1397, 743);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrif)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.m_grbTolvur.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.m_grValinVel.ResumeLayout(false);
            this.m_grValinVel.PerformLayout();
            this.m_grbDrif.ResumeLayout(false);
            this.m_grbAfritun.ResumeLayout(false);
            this.m_grbAfritun.PerformLayout();
            this.m_grbAfritATH.ResumeLayout(false);
            this.m_grbAfritATH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvBackup)).EndInit();
            this.ResumeLayout(false);

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
    }
}
