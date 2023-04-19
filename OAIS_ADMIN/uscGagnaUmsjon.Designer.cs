namespace OAIS_ADMIN
{
    partial class uscGagnaUmsjon
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
            this.m_dgvUtgafur = new System.Windows.Forms.DataGridView();
            this.m_lblSkjalm = new System.Windows.Forms.Label();
            this.m_lblVarsla = new System.Windows.Forms.Label();
            this.m_comSkjalamyndarar = new System.Windows.Forms.ComboBox();
            this.m_comVörslustofnanir = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.m_btnLeita = new System.Windows.Forms.Button();
            this.m_grbAdgerdir = new System.Windows.Forms.GroupBox();
            this.m_btnArskyrsla = new System.Windows.Forms.Button();
            this.m_btnHreinsa = new System.Windows.Forms.Button();
            this.m_comID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVorsluutgafu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVorslustofnun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeitiVarsla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkjalamyndari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkjalmHeiti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStaerd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInnihald = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimabil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAfhArNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMD5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdgangur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHverSkradi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDagsSkráð = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelEyda = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEditVaral = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEditSkjalamyndari = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEditSkrá = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colOpna = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEditKvittun = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colRepSkjalm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colRepVarsla = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEytt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvUtgafur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.m_grbAdgerdir.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dgvUtgafur
            // 
            this.m_dgvUtgafur.AllowUserToAddRows = false;
            this.m_dgvUtgafur.AllowUserToDeleteRows = false;
            this.m_dgvUtgafur.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.m_dgvUtgafur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvUtgafur.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_comID,
            this.colVorsluutgafu,
            this.colTitill,
            this.colVorslustofnun,
            this.colHeitiVarsla,
            this.colSkjalamyndari,
            this.colSkjalmHeiti,
            this.colStaerd,
            this.colSlod,
            this.colInnihald,
            this.colTimabil,
            this.colAfhArNR,
            this.colMD5,
            this.colAdgangur,
            this.colHverSkradi,
            this.colDagsSkráð,
            this.colDelEyda,
            this.colEditVaral,
            this.colEditSkjalamyndari,
            this.colEditSkrá,
            this.colOpna,
            this.colEditKvittun,
            this.colRepSkjalm,
            this.colRepVarsla,
            this.colEytt});
            this.m_dgvUtgafur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvUtgafur.Location = new System.Drawing.Point(0, 0);
            this.m_dgvUtgafur.Name = "m_dgvUtgafur";
            this.m_dgvUtgafur.ReadOnly = true;
            this.m_dgvUtgafur.RowHeadersVisible = false;
            this.m_dgvUtgafur.RowTemplate.Height = 25;
            this.m_dgvUtgafur.Size = new System.Drawing.Size(1467, 630);
            this.m_dgvUtgafur.TabIndex = 0;
            this.m_dgvUtgafur.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvAllt_CellClick);
            // 
            // m_lblSkjalm
            // 
            this.m_lblSkjalm.AutoSize = true;
            this.m_lblSkjalm.Location = new System.Drawing.Point(141, 49);
            this.m_lblSkjalm.Name = "m_lblSkjalm";
            this.m_lblSkjalm.Size = new System.Drawing.Size(88, 15);
            this.m_lblSkjalm.TabIndex = 5;
            this.m_lblSkjalm.Text = "Skjalamyndarar";
            // 
            // m_lblVarsla
            // 
            this.m_lblVarsla.AutoSize = true;
            this.m_lblVarsla.Location = new System.Drawing.Point(143, 20);
            this.m_lblVarsla.Name = "m_lblVarsla";
            this.m_lblVarsla.Size = new System.Drawing.Size(86, 15);
            this.m_lblVarsla.TabIndex = 4;
            this.m_lblVarsla.Text = "Vörslustofnanir";
            // 
            // m_comSkjalamyndarar
            // 
            this.m_comSkjalamyndarar.FormattingEnabled = true;
            this.m_comSkjalamyndarar.Location = new System.Drawing.Point(244, 41);
            this.m_comSkjalamyndarar.Name = "m_comSkjalamyndarar";
            this.m_comSkjalamyndarar.Size = new System.Drawing.Size(500, 23);
            this.m_comSkjalamyndarar.TabIndex = 1;
            this.m_comSkjalamyndarar.SelectedIndexChanged += new System.EventHandler(this.m_comSkjalamyndarar_SelectedIndexChanged);
            // 
            // m_comVörslustofnanir
            // 
            this.m_comVörslustofnanir.FormattingEnabled = true;
            this.m_comVörslustofnanir.Location = new System.Drawing.Point(244, 12);
            this.m_comVörslustofnanir.Name = "m_comVörslustofnanir";
            this.m_comVörslustofnanir.Size = new System.Drawing.Size(500, 23);
            this.m_comVörslustofnanir.TabIndex = 0;
            this.m_comVörslustofnanir.SelectedIndexChanged += new System.EventHandler(this.m_comVörslustofnanir_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimePicker3);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimePicker4);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimePicker2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnLeita);
            this.splitContainer2.Panel1.Controls.Add(this.m_grbAdgerdir);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnHreinsa);
            this.splitContainer2.Panel1.Controls.Add(this.m_comSkjalamyndarar);
            this.splitContainer2.Panel1.Controls.Add(this.m_lblVarsla);
            this.splitContainer2.Panel1.Controls.Add(this.m_lblSkjalm);
            this.splitContainer2.Panel1.Controls.Add(this.m_comVörslustofnanir);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_dgvUtgafur);
            this.splitContainer2.Size = new System.Drawing.Size(1467, 812);
            this.splitContainer2.SplitterDistance = 178;
            this.splitContainer2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tekið við frá";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(544, 99);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker3.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tekið við til";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Location = new System.Drawing.Point(244, 99);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker4.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tímabil frá";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(544, 70);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tímabil til";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(244, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // m_btnLeita
            // 
            this.m_btnLeita.Location = new System.Drawing.Point(558, 141);
            this.m_btnLeita.Name = "m_btnLeita";
            this.m_btnLeita.Size = new System.Drawing.Size(75, 23);
            this.m_btnLeita.TabIndex = 1;
            this.m_btnLeita.Text = "Leita";
            this.m_btnLeita.UseVisualStyleBackColor = true;
            this.m_btnLeita.Click += new System.EventHandler(this.m_btnLeita_Click);
            // 
            // m_grbAdgerdir
            // 
            this.m_grbAdgerdir.Controls.Add(this.m_btnArskyrsla);
            this.m_grbAdgerdir.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_grbAdgerdir.Location = new System.Drawing.Point(1129, 0);
            this.m_grbAdgerdir.Name = "m_grbAdgerdir";
            this.m_grbAdgerdir.Size = new System.Drawing.Size(338, 178);
            this.m_grbAdgerdir.TabIndex = 7;
            this.m_grbAdgerdir.TabStop = false;
            this.m_grbAdgerdir.Text = "Aðgerðir";
            // 
            // m_btnArskyrsla
            // 
            this.m_btnArskyrsla.Location = new System.Drawing.Point(54, 45);
            this.m_btnArskyrsla.Name = "m_btnArskyrsla";
            this.m_btnArskyrsla.Size = new System.Drawing.Size(75, 23);
            this.m_btnArskyrsla.TabIndex = 0;
            this.m_btnArskyrsla.Text = "Árskýrsla";
            this.m_btnArskyrsla.UseVisualStyleBackColor = true;
            this.m_btnArskyrsla.Click += new System.EventHandler(this.m_btnArskyrsla_Click);
            // 
            // m_btnHreinsa
            // 
            this.m_btnHreinsa.Location = new System.Drawing.Point(669, 141);
            this.m_btnHreinsa.Name = "m_btnHreinsa";
            this.m_btnHreinsa.Size = new System.Drawing.Size(75, 23);
            this.m_btnHreinsa.TabIndex = 6;
            this.m_btnHreinsa.Text = "Hreinsa";
            this.m_btnHreinsa.UseVisualStyleBackColor = true;
            this.m_btnHreinsa.Click += new System.EventHandler(this.m_btnHreinsa_Click);
            // 
            // m_comID
            // 
            this.m_comID.DataPropertyName = "id";
            this.m_comID.HeaderText = "ID";
            this.m_comID.Name = "m_comID";
            this.m_comID.ReadOnly = true;
            this.m_comID.Visible = false;
            // 
            // colVorsluutgafu
            // 
            this.colVorsluutgafu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colVorsluutgafu.DataPropertyName = "vorsluutgafa";
            this.colVorsluutgafu.HeaderText = "Vörsluútgáfa";
            this.colVorsluutgafu.Name = "colVorsluutgafu";
            this.colVorsluutgafu.ReadOnly = true;
            this.colVorsluutgafu.Width = 98;
            // 
            // colTitill
            // 
            this.colTitill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitill.DataPropertyName = "utgafa_titill";
            this.colTitill.HeaderText = "Titill vörsluútgáfu";
            this.colTitill.Name = "colTitill";
            this.colTitill.ReadOnly = true;
            // 
            // colVorslustofnun
            // 
            this.colVorslustofnun.DataPropertyName = "vorslustofnun";
            this.colVorslustofnun.HeaderText = "VörslustofnunID";
            this.colVorslustofnun.Name = "colVorslustofnun";
            this.colVorslustofnun.ReadOnly = true;
            this.colVorslustofnun.Visible = false;
            // 
            // colHeitiVarsla
            // 
            this.colHeitiVarsla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHeitiVarsla.DataPropertyName = "varsla_heiti";
            this.colHeitiVarsla.HeaderText = "Vörslustofnun";
            this.colHeitiVarsla.Name = "colHeitiVarsla";
            this.colHeitiVarsla.ReadOnly = true;
            this.colHeitiVarsla.Width = 105;
            // 
            // colSkjalamyndari
            // 
            this.colSkjalamyndari.DataPropertyName = "skjalamyndari";
            this.colSkjalamyndari.HeaderText = "skjalamyndari";
            this.colSkjalamyndari.Name = "colSkjalamyndari";
            this.colSkjalamyndari.ReadOnly = true;
            this.colSkjalamyndari.Visible = false;
            // 
            // colSkjalmHeiti
            // 
            this.colSkjalmHeiti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSkjalmHeiti.DataPropertyName = "skjalm_heiti";
            this.colSkjalmHeiti.HeaderText = "Heiti skjalamyndara";
            this.colSkjalmHeiti.Name = "colSkjalmHeiti";
            this.colSkjalmHeiti.ReadOnly = true;
            this.colSkjalmHeiti.Width = 124;
            // 
            // colStaerd
            // 
            this.colStaerd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colStaerd.DataPropertyName = "staerd";
            this.colStaerd.HeaderText = "Stærð";
            this.colStaerd.Name = "colStaerd";
            this.colStaerd.ReadOnly = true;
            this.colStaerd.Width = 63;
            // 
            // colSlod
            // 
            this.colSlod.DataPropertyName = "slod";
            this.colSlod.HeaderText = "Slóð";
            this.colSlod.Name = "colSlod";
            this.colSlod.ReadOnly = true;
            this.colSlod.Visible = false;
            // 
            // colInnihald
            // 
            this.colInnihald.DataPropertyName = "innihald";
            this.colInnihald.HeaderText = "Innihald";
            this.colInnihald.Name = "colInnihald";
            this.colInnihald.ReadOnly = true;
            this.colInnihald.Visible = false;
            // 
            // colTimabil
            // 
            this.colTimabil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTimabil.DataPropertyName = "timabil";
            this.colTimabil.HeaderText = "Tímabil";
            this.colTimabil.Name = "colTimabil";
            this.colTimabil.ReadOnly = true;
            this.colTimabil.Width = 71;
            // 
            // colAfhArNR
            // 
            this.colAfhArNR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAfhArNR.DataPropertyName = "afharnr";
            this.colAfhArNR.HeaderText = "Afhendingaár / númer";
            this.colAfhArNR.Name = "colAfhArNR";
            this.colAfhArNR.ReadOnly = true;
            this.colAfhArNR.Width = 106;
            // 
            // colMD5
            // 
            this.colMD5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMD5.DataPropertyName = "MD5";
            this.colMD5.HeaderText = "Gátsumma";
            this.colMD5.Name = "colMD5";
            this.colMD5.ReadOnly = true;
            this.colMD5.Visible = false;
            this.colMD5.Width = 90;
            // 
            // colAdgangur
            // 
            this.colAdgangur.DataPropertyName = "adgangstakmarkanir";
            this.colAdgangur.HeaderText = "Aðgengi";
            this.colAdgangur.Name = "colAdgangur";
            this.colAdgangur.ReadOnly = true;
            // 
            // colHverSkradi
            // 
            this.colHverSkradi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHverSkradi.DataPropertyName = "hver_skradi";
            this.colHverSkradi.HeaderText = "Hver skráði";
            this.colHverSkradi.Name = "colHverSkradi";
            this.colHverSkradi.ReadOnly = true;
            this.colHverSkradi.Width = 84;
            // 
            // colDagsSkráð
            // 
            this.colDagsSkráð.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDagsSkráð.DataPropertyName = "dags_skrad";
            this.colDagsSkráð.HeaderText = "Dags. skráð";
            this.colDagsSkráð.Name = "colDagsSkráð";
            this.colDagsSkráð.ReadOnly = true;
            this.colDagsSkráð.Width = 85;
            // 
            // colDelEyda
            // 
            this.colDelEyda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDelEyda.HeaderText = "Eyða";
            this.colDelEyda.Name = "colDelEyda";
            this.colDelEyda.ReadOnly = true;
            this.colDelEyda.Text = "Eyða";
            this.colDelEyda.UseColumnTextForButtonValue = true;
            this.colDelEyda.Width = 38;
            // 
            // colEditVaral
            // 
            this.colEditVaral.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEditVaral.HeaderText = "Vörslustofnun";
            this.colEditVaral.Name = "colEditVaral";
            this.colEditVaral.ReadOnly = true;
            this.colEditVaral.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditVaral.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEditVaral.Text = "Fullskrá";
            this.colEditVaral.UseColumnTextForButtonValue = true;
            this.colEditVaral.Width = 105;
            // 
            // colEditSkjalamyndari
            // 
            this.colEditSkjalamyndari.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEditSkjalamyndari.HeaderText = "Skjalamyndari";
            this.colEditSkjalamyndari.Name = "colEditSkjalamyndari";
            this.colEditSkjalamyndari.ReadOnly = true;
            this.colEditSkjalamyndari.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditSkjalamyndari.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEditSkjalamyndari.Text = "Fullskrá";
            this.colEditSkjalamyndari.UseColumnTextForButtonValue = true;
            this.colEditSkjalamyndari.Width = 106;
            // 
            // colEditSkrá
            // 
            this.colEditSkrá.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEditSkrá.HeaderText = "Skráning";
            this.colEditSkrá.Name = "colEditSkrá";
            this.colEditSkrá.ReadOnly = true;
            this.colEditSkrá.Text = "Fullskrá";
            this.colEditSkrá.UseColumnTextForButtonValue = true;
            this.colEditSkrá.Width = 59;
            // 
            // colOpna
            // 
            this.colOpna.HeaderText = "Vörsluútgáfa";
            this.colOpna.Name = "colOpna";
            this.colOpna.ReadOnly = true;
            this.colOpna.Text = "Opna";
            this.colOpna.UseColumnTextForButtonValue = true;
            // 
            // colEditKvittun
            // 
            this.colEditKvittun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEditKvittun.HeaderText = "Kvittun";
            this.colEditKvittun.Name = "colEditKvittun";
            this.colEditKvittun.ReadOnly = true;
            this.colEditKvittun.Text = "kvittun";
            this.colEditKvittun.UseColumnTextForButtonValue = true;
            this.colEditKvittun.Width = 51;
            // 
            // colRepSkjalm
            // 
            this.colRepSkjalm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colRepSkjalm.HeaderText = "Skýrsla skjalamyndara";
            this.colRepSkjalm.Name = "colRepSkjalm";
            this.colRepSkjalm.ReadOnly = true;
            this.colRepSkjalm.Text = "Skýrsla skjalam.";
            this.colRepSkjalm.UseColumnTextForButtonValue = true;
            this.colRepSkjalm.Width = 115;
            // 
            // colRepVarsla
            // 
            this.colRepVarsla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colRepVarsla.HeaderText = "Skýrsla vörslustofnunar";
            this.colRepVarsla.Name = "colRepVarsla";
            this.colRepVarsla.ReadOnly = true;
            this.colRepVarsla.Text = "Skýrsla vörslus.";
            this.colRepVarsla.UseColumnTextForButtonValue = true;
            this.colRepVarsla.Width = 122;
            // 
            // colEytt
            // 
            this.colEytt.DataPropertyName = "eytt";
            this.colEytt.HeaderText = "Eytt";
            this.colEytt.Name = "colEytt";
            this.colEytt.ReadOnly = true;
            this.colEytt.Visible = false;
            // 
            // uscGagnaUmsjon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "uscGagnaUmsjon";
            this.Size = new System.Drawing.Size(1467, 812);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvUtgafur)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.m_grbAdgerdir.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView m_dgvUtgafur;
        private SplitContainer splitContainer2;
        private ComboBox m_comSkjalamyndarar;
        private ComboBox m_comVörslustofnanir;
        private Label m_lblSkjalm;
        private Label m_lblVarsla;
        private Button m_btnHreinsa;
        private GroupBox m_grbAdgerdir;
        private Label label3;
        private DateTimePicker dateTimePicker3;
        private Label label4;
        private DateTimePicker dateTimePicker4;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Button m_btnLeita;
        private Button m_btnArskyrsla;
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
        private DataGridViewButtonColumn colDelEyda;
        private DataGridViewButtonColumn colEditVaral;
        private DataGridViewButtonColumn colEditSkjalamyndari;
        private DataGridViewButtonColumn colEditSkrá;
        private DataGridViewButtonColumn colOpna;
        private DataGridViewButtonColumn colEditKvittun;
        private DataGridViewButtonColumn colRepSkjalm;
        private DataGridViewButtonColumn colRepVarsla;
        private DataGridViewTextBoxColumn colEytt;
    }
}
