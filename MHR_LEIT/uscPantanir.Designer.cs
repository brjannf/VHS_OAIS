namespace MHR_LEIT
{
    partial class uscPantanir
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_trwDIP = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_lblPontunstatus = new System.Windows.Forms.Label();
            this.m_pgbPontun = new System.Windows.Forms.ProgressBar();
            this.m_btnTæma = new System.Windows.Forms.Button();
            this.m_lblLanthegi = new System.Windows.Forms.Label();
            this.m_btnOpna = new System.Windows.Forms.Button();
            this.m_btnKlaraPontun = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.m_comLanthegar = new System.Windows.Forms.ComboBox();
            this.m_btnNyrLanthegi = new System.Windows.Forms.Button();
            this.m_grbDIP = new System.Windows.Forms.GroupBox();
            this.m_tacPontun = new System.Windows.Forms.TabControl();
            this.m_tapPontunSkra = new System.Windows.Forms.TabPage();
            this.m_dgvDIPList = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeitiUtgáfu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkraRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.m_tapPontunMalakerfi = new System.Windows.Forms.TabPage();
            this.m_dgvDIPmal = new System.Windows.Forms.DataGridView();
            this.colMalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMalTitillSkjals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMalMalTitill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMalHeitiVarsla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_tapPontunGagnagrunnar = new System.Windows.Forms.TabPage();
            this.m_dgvDIPGagnagrunnar = new System.Windows.Forms.DataGridView();
            this.colGagnHeiti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGagnLeitSkilyrdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGagnHeitivorslu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.m_grbDIP.SuspendLayout();
            this.m_tacPontun.SuspendLayout();
            this.m_tapPontunSkra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDIPList)).BeginInit();
            this.m_tapPontunMalakerfi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDIPmal)).BeginInit();
            this.m_tapPontunGagnagrunnar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDIPGagnagrunnar)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_trwDIP);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1218, 542);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 19;
            // 
            // m_trwDIP
            // 
            this.m_trwDIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trwDIP.Location = new System.Drawing.Point(0, 0);
            this.m_trwDIP.Name = "m_trwDIP";
            this.m_trwDIP.Size = new System.Drawing.Size(274, 542);
            this.m_trwDIP.TabIndex = 1;
            this.m_trwDIP.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trwDIP_AfterSelect);
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
            this.splitContainer2.Panel1.Controls.Add(this.m_lblPontunstatus);
            this.splitContainer2.Panel1.Controls.Add(this.m_pgbPontun);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnTæma);
            this.splitContainer2.Panel1.Controls.Add(this.m_lblLanthegi);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnOpna);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnKlaraPontun);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.m_comLanthegar);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnNyrLanthegi);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_grbDIP);
            this.splitContainer2.Size = new System.Drawing.Size(940, 542);
            this.splitContainer2.SplitterDistance = 266;
            this.splitContainer2.TabIndex = 0;
            // 
            // m_lblPontunstatus
            // 
            this.m_lblPontunstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblPontunstatus.AutoSize = true;
            this.m_lblPontunstatus.Location = new System.Drawing.Point(588, 169);
            this.m_lblPontunstatus.Name = "m_lblPontunstatus";
            this.m_lblPontunstatus.Size = new System.Drawing.Size(38, 15);
            this.m_lblPontunstatus.TabIndex = 17;
            this.m_lblPontunstatus.Text = "label7";
            this.m_lblPontunstatus.Visible = false;
            // 
            // m_pgbPontun
            // 
            this.m_pgbPontun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_pgbPontun.Location = new System.Drawing.Point(137, 162);
            this.m_pgbPontun.Name = "m_pgbPontun";
            this.m_pgbPontun.Size = new System.Drawing.Size(417, 23);
            this.m_pgbPontun.TabIndex = 16;
            this.m_pgbPontun.Visible = false;
            // 
            // m_btnTæma
            // 
            this.m_btnTæma.Location = new System.Drawing.Point(679, 175);
            this.m_btnTæma.Name = "m_btnTæma";
            this.m_btnTæma.Size = new System.Drawing.Size(125, 23);
            this.m_btnTæma.TabIndex = 15;
            this.m_btnTæma.Text = "Tæma lista";
            this.m_btnTæma.UseVisualStyleBackColor = true;
            this.m_btnTæma.Click += new System.EventHandler(this.m_btnTæma_Click);
            // 
            // m_lblLanthegi
            // 
            this.m_lblLanthegi.AutoSize = true;
            this.m_lblLanthegi.Location = new System.Drawing.Point(137, 117);
            this.m_lblLanthegi.Name = "m_lblLanthegi";
            this.m_lblLanthegi.Size = new System.Drawing.Size(38, 15);
            this.m_lblLanthegi.TabIndex = 14;
            this.m_lblLanthegi.Text = "label6";
            this.m_lblLanthegi.Visible = false;
            // 
            // m_btnOpna
            // 
            this.m_btnOpna.Location = new System.Drawing.Point(679, 146);
            this.m_btnOpna.Name = "m_btnOpna";
            this.m_btnOpna.Size = new System.Drawing.Size(125, 23);
            this.m_btnOpna.TabIndex = 13;
            this.m_btnOpna.Text = "Opna pakka";
            this.m_btnOpna.UseVisualStyleBackColor = true;
            this.m_btnOpna.Click += new System.EventHandler(this.m_btnOpna_Click);
            // 
            // m_btnKlaraPontun
            // 
            this.m_btnKlaraPontun.Location = new System.Drawing.Point(679, 113);
            this.m_btnKlaraPontun.Name = "m_btnKlaraPontun";
            this.m_btnKlaraPontun.Size = new System.Drawing.Size(125, 23);
            this.m_btnKlaraPontun.TabIndex = 12;
            this.m_btnKlaraPontun.Text = "Klára pöntun";
            this.m_btnKlaraPontun.UseVisualStyleBackColor = true;
            this.m_btnKlaraPontun.Click += new System.EventHandler(this.m_btnKlaraPontun_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Veldu lánþega";
            // 
            // m_comLanthegar
            // 
            this.m_comLanthegar.FormattingEnabled = true;
            this.m_comLanthegar.Location = new System.Drawing.Point(268, 69);
            this.m_comLanthegar.Name = "m_comLanthegar";
            this.m_comLanthegar.Size = new System.Drawing.Size(352, 23);
            this.m_comLanthegar.TabIndex = 10;
            this.m_comLanthegar.SelectedIndexChanged += new System.EventHandler(this.m_comLanthegar_SelectedIndexChanged);
            // 
            // m_btnNyrLanthegi
            // 
            this.m_btnNyrLanthegi.Location = new System.Drawing.Point(679, 69);
            this.m_btnNyrLanthegi.Name = "m_btnNyrLanthegi";
            this.m_btnNyrLanthegi.Size = new System.Drawing.Size(125, 23);
            this.m_btnNyrLanthegi.TabIndex = 9;
            this.m_btnNyrLanthegi.Text = "Nýr lánþegi";
            this.m_btnNyrLanthegi.UseVisualStyleBackColor = true;
            this.m_btnNyrLanthegi.Click += new System.EventHandler(this.m_btnNyrLanthegi_Click);
            // 
            // m_grbDIP
            // 
            this.m_grbDIP.Controls.Add(this.m_tacPontun);
            this.m_grbDIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbDIP.Location = new System.Drawing.Point(0, 0);
            this.m_grbDIP.Name = "m_grbDIP";
            this.m_grbDIP.Size = new System.Drawing.Size(940, 272);
            this.m_grbDIP.TabIndex = 4;
            this.m_grbDIP.TabStop = false;
            this.m_grbDIP.Text = "Gögn í pöntun";
            // 
            // m_tacPontun
            // 
            this.m_tacPontun.Controls.Add(this.m_tapPontunSkra);
            this.m_tacPontun.Controls.Add(this.m_tapPontunMalakerfi);
            this.m_tacPontun.Controls.Add(this.m_tapPontunGagnagrunnar);
            this.m_tacPontun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tacPontun.Location = new System.Drawing.Point(3, 19);
            this.m_tacPontun.Name = "m_tacPontun";
            this.m_tacPontun.SelectedIndex = 0;
            this.m_tacPontun.Size = new System.Drawing.Size(934, 250);
            this.m_tacPontun.TabIndex = 3;
            // 
            // m_tapPontunSkra
            // 
            this.m_tapPontunSkra.Controls.Add(this.m_dgvDIPList);
            this.m_tapPontunSkra.Location = new System.Drawing.Point(4, 24);
            this.m_tapPontunSkra.Name = "m_tapPontunSkra";
            this.m_tapPontunSkra.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapPontunSkra.Size = new System.Drawing.Size(926, 222);
            this.m_tapPontunSkra.TabIndex = 0;
            this.m_tapPontunSkra.Text = "Skráarkerfi";
            this.m_tapPontunSkra.UseVisualStyleBackColor = true;
            // 
            // m_dgvDIPList
            // 
            this.m_dgvDIPList.AllowUserToAddRows = false;
            this.m_dgvDIPList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvDIPList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTitill,
            this.colHeitiUtgáfu,
            this.colSkraRemove});
            this.m_dgvDIPList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDIPList.Location = new System.Drawing.Point(3, 3);
            this.m_dgvDIPList.Name = "m_dgvDIPList";
            this.m_dgvDIPList.ReadOnly = true;
            this.m_dgvDIPList.RowHeadersVisible = false;
            this.m_dgvDIPList.RowTemplate.Height = 25;
            this.m_dgvDIPList.Size = new System.Drawing.Size(920, 216);
            this.m_dgvDIPList.TabIndex = 3;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colID.DataPropertyName = "skjalID";
            this.colID.HeaderText = "Auðkenni skjals";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 114;
            // 
            // colTitill
            // 
            this.colTitill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitill.DataPropertyName = "titill";
            this.colTitill.HeaderText = "Titill skjals";
            this.colTitill.Name = "colTitill";
            this.colTitill.ReadOnly = true;
            // 
            // colHeitiUtgáfu
            // 
            this.colHeitiUtgáfu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHeitiUtgáfu.DataPropertyName = "heitiVorslu";
            this.colHeitiUtgáfu.HeaderText = "Vörsluútgáfa";
            this.colHeitiUtgáfu.Name = "colHeitiUtgáfu";
            this.colHeitiUtgáfu.ReadOnly = true;
            this.colHeitiUtgáfu.Width = 98;
            // 
            // colSkraRemove
            // 
            this.colSkraRemove.HeaderText = "Fjarlægja";
            this.colSkraRemove.Name = "colSkraRemove";
            this.colSkraRemove.ReadOnly = true;
            this.colSkraRemove.Text = "Fjarlægja";
            this.colSkraRemove.UseColumnTextForButtonValue = true;
            // 
            // m_tapPontunMalakerfi
            // 
            this.m_tapPontunMalakerfi.Controls.Add(this.m_dgvDIPmal);
            this.m_tapPontunMalakerfi.Location = new System.Drawing.Point(4, 24);
            this.m_tapPontunMalakerfi.Name = "m_tapPontunMalakerfi";
            this.m_tapPontunMalakerfi.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapPontunMalakerfi.Size = new System.Drawing.Size(926, 222);
            this.m_tapPontunMalakerfi.TabIndex = 1;
            this.m_tapPontunMalakerfi.Text = "Málakerfi";
            this.m_tapPontunMalakerfi.UseVisualStyleBackColor = true;
            // 
            // m_dgvDIPmal
            // 
            this.m_dgvDIPmal.AllowUserToAddRows = false;
            this.m_dgvDIPmal.AllowUserToDeleteRows = false;
            this.m_dgvDIPmal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvDIPmal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMalID,
            this.colMalTitillSkjals,
            this.colMalMalTitill,
            this.colMalHeitiVarsla});
            this.m_dgvDIPmal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDIPmal.Location = new System.Drawing.Point(3, 3);
            this.m_dgvDIPmal.Name = "m_dgvDIPmal";
            this.m_dgvDIPmal.ReadOnly = true;
            this.m_dgvDIPmal.RowHeadersVisible = false;
            this.m_dgvDIPmal.RowTemplate.Height = 25;
            this.m_dgvDIPmal.Size = new System.Drawing.Size(920, 216);
            this.m_dgvDIPmal.TabIndex = 0;
            // 
            // colMalID
            // 
            this.colMalID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMalID.DataPropertyName = "documentid";
            this.colMalID.HeaderText = "Auðkenni skjals";
            this.colMalID.Name = "colMalID";
            this.colMalID.ReadOnly = true;
            this.colMalID.Width = 105;
            // 
            // colMalTitillSkjals
            // 
            this.colMalTitillSkjals.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMalTitillSkjals.DataPropertyName = "titill";
            this.colMalTitillSkjals.HeaderText = "Titill skjals";
            this.colMalTitillSkjals.Name = "colMalTitillSkjals";
            this.colMalTitillSkjals.ReadOnly = true;
            // 
            // colMalMalTitill
            // 
            this.colMalMalTitill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMalMalTitill.DataPropertyName = "maltitill";
            this.colMalMalTitill.HeaderText = "Titill máls";
            this.colMalMalTitill.Name = "colMalMalTitill";
            this.colMalMalTitill.ReadOnly = true;
            this.colMalMalTitill.Width = 76;
            // 
            // colMalHeitiVarsla
            // 
            this.colMalHeitiVarsla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMalHeitiVarsla.DataPropertyName = "heitivorslu";
            this.colMalHeitiVarsla.HeaderText = "Heiti vörsluútgáfu";
            this.colMalHeitiVarsla.Name = "colMalHeitiVarsla";
            this.colMalHeitiVarsla.ReadOnly = true;
            this.colMalHeitiVarsla.Width = 116;
            // 
            // m_tapPontunGagnagrunnar
            // 
            this.m_tapPontunGagnagrunnar.Controls.Add(this.m_dgvDIPGagnagrunnar);
            this.m_tapPontunGagnagrunnar.Location = new System.Drawing.Point(4, 24);
            this.m_tapPontunGagnagrunnar.Name = "m_tapPontunGagnagrunnar";
            this.m_tapPontunGagnagrunnar.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapPontunGagnagrunnar.Size = new System.Drawing.Size(926, 222);
            this.m_tapPontunGagnagrunnar.TabIndex = 2;
            this.m_tapPontunGagnagrunnar.Text = "Gagnagrunnar";
            this.m_tapPontunGagnagrunnar.UseVisualStyleBackColor = true;
            // 
            // m_dgvDIPGagnagrunnar
            // 
            this.m_dgvDIPGagnagrunnar.AllowUserToAddRows = false;
            this.m_dgvDIPGagnagrunnar.AllowUserToDeleteRows = false;
            this.m_dgvDIPGagnagrunnar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvDIPGagnagrunnar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGagnHeiti,
            this.colGagnLeitSkilyrdi,
            this.colGagnHeitivorslu});
            this.m_dgvDIPGagnagrunnar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDIPGagnagrunnar.Location = new System.Drawing.Point(3, 3);
            this.m_dgvDIPGagnagrunnar.Name = "m_dgvDIPGagnagrunnar";
            this.m_dgvDIPGagnagrunnar.ReadOnly = true;
            this.m_dgvDIPGagnagrunnar.RowHeadersVisible = false;
            this.m_dgvDIPGagnagrunnar.RowTemplate.Height = 25;
            this.m_dgvDIPGagnagrunnar.Size = new System.Drawing.Size(920, 216);
            this.m_dgvDIPGagnagrunnar.TabIndex = 0;
            // 
            // colGagnHeiti
            // 
            this.colGagnHeiti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGagnHeiti.DataPropertyName = "heiti";
            this.colGagnHeiti.HeaderText = "Heiti gagnagrunns";
            this.colGagnHeiti.Name = "colGagnHeiti";
            this.colGagnHeiti.ReadOnly = true;
            this.colGagnHeiti.Width = 119;
            // 
            // colGagnLeitSkilyrdi
            // 
            this.colGagnLeitSkilyrdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGagnLeitSkilyrdi.DataPropertyName = "leitarskilyrdi";
            this.colGagnLeitSkilyrdi.HeaderText = "Leitarskílyrði";
            this.colGagnLeitSkilyrdi.Name = "colGagnLeitSkilyrdi";
            this.colGagnLeitSkilyrdi.ReadOnly = true;
            // 
            // colGagnHeitivorslu
            // 
            this.colGagnHeitivorslu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGagnHeitivorslu.DataPropertyName = "heitivorslu";
            this.colGagnHeitivorslu.HeaderText = "Heiti vörsluútgáfu";
            this.colGagnHeitivorslu.Name = "colGagnHeitivorslu";
            this.colGagnHeitivorslu.ReadOnly = true;
            this.colGagnHeitivorslu.Width = 116;
            // 
            // uscPantanir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "uscPantanir";
            this.Size = new System.Drawing.Size(1218, 542);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.m_grbDIP.ResumeLayout(false);
            this.m_tacPontun.ResumeLayout(false);
            this.m_tapPontunSkra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDIPList)).EndInit();
            this.m_tapPontunMalakerfi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDIPmal)).EndInit();
            this.m_tapPontunGagnagrunnar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDIPGagnagrunnar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Label m_lblPontunstatus;
        private ProgressBar m_pgbPontun;
        private Button m_btnTæma;
        private Label m_lblLanthegi;
        private Button m_btnOpna;
        private Button m_btnKlaraPontun;
        private Label label5;
        private ComboBox m_comLanthegar;
        private Button m_btnNyrLanthegi;
        private GroupBox m_grbDIP;
        private TabControl m_tacPontun;
        private TabPage m_tapPontunSkra;
        private TabPage m_tapPontunMalakerfi;
        private DataGridView m_dgvDIPmal;
        private TabPage m_tapPontunGagnagrunnar;
        private DataGridView m_dgvDIPGagnagrunnar;
        private TreeView m_trwDIP;
        private DataGridView m_dgvDIPList;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colTitill;
        private DataGridViewTextBoxColumn colHeitiUtgáfu;
        private DataGridViewButtonColumn colSkraRemove;
        private DataGridViewTextBoxColumn colMalID;
        private DataGridViewTextBoxColumn colMalTitillSkjals;
        private DataGridViewTextBoxColumn colMalMalTitill;
        private DataGridViewTextBoxColumn colMalHeitiVarsla;
        private DataGridViewTextBoxColumn colGagnHeiti;
        private DataGridViewTextBoxColumn colGagnLeitSkilyrdi;
        private DataGridViewTextBoxColumn colGagnHeitivorslu;
    }
}
