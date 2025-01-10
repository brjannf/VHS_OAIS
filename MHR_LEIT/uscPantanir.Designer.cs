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
            splitContainer1 = new SplitContainer();
            m_trwDIP = new TreeView();
            splitContainer2 = new SplitContainer();
            m_btnPantAthUpp = new Button();
            m_grbAthugasemdir = new GroupBox();
            m_tboPontunAth = new TextBox();
            m_lblPontunstatus = new Label();
            m_pgbPontun = new ProgressBar();
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
            colSkraRemove = new DataGridViewButtonColumn();
            colSkraVarslaID = new DataGridViewTextBoxColumn();
            m_tapPontunMalakerfi = new TabPage();
            m_dgvDIPmal = new DataGridView();
            colMalSkraID = new DataGridViewTextBoxColumn();
            colMalTitillSkjals = new DataGridViewTextBoxColumn();
            colMalMalTitill = new DataGridViewTextBoxColumn();
            colMalHeitiVarsla = new DataGridViewTextBoxColumn();
            colMalOpna = new DataGridViewButtonColumn();
            colMalRemove = new DataGridViewButtonColumn();
            colMalSlod = new DataGridViewTextBoxColumn();
            colMalGagnagrunnur = new DataGridViewTextBoxColumn();
            m_tapPontunGagnagrunnar = new TabPage();
            m_dgvDIPGagnagrunnar = new DataGridView();
            colGagnHeiti = new DataGridViewTextBoxColumn();
            colGagnLeitSkilyrdi = new DataGridViewTextBoxColumn();
            colGagnHeitivorslu = new DataGridViewTextBoxColumn();
            colGagnOpna = new DataGridViewButtonColumn();
            colGagnRemove = new DataGridViewButtonColumn();
            colGagnSQL = new DataGridViewTextBoxColumn();
            m_lblKarfaNr = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            m_grbAthugasemdir.SuspendLayout();
            m_grbDIP.SuspendLayout();
            m_tacPontun.SuspendLayout();
            m_tapPontunSkra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvDIPList).BeginInit();
            m_tapPontunMalakerfi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvDIPmal).BeginInit();
            m_tapPontunGagnagrunnar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvDIPGagnagrunnar).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(m_trwDIP);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1461, 542);
            splitContainer1.SplitterDistance = 328;
            splitContainer1.TabIndex = 19;
            // 
            // m_trwDIP
            // 
            m_trwDIP.Dock = DockStyle.Fill;
            m_trwDIP.Location = new Point(0, 0);
            m_trwDIP.Name = "m_trwDIP";
            m_trwDIP.Size = new Size(328, 542);
            m_trwDIP.TabIndex = 1;
            m_trwDIP.AfterSelect += m_trwDIP_AfterSelect;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(m_lblKarfaNr);
            splitContainer2.Panel1.Controls.Add(m_btnPantAthUpp);
            splitContainer2.Panel1.Controls.Add(m_grbAthugasemdir);
            splitContainer2.Panel1.Controls.Add(m_lblPontunstatus);
            splitContainer2.Panel1.Controls.Add(m_pgbPontun);
            splitContainer2.Panel1.Controls.Add(m_btnTæma);
            splitContainer2.Panel1.Controls.Add(m_lblLanthegi);
            splitContainer2.Panel1.Controls.Add(m_btnOpna);
            splitContainer2.Panel1.Controls.Add(m_btnKlaraPontun);
            splitContainer2.Panel1.Controls.Add(label5);
            splitContainer2.Panel1.Controls.Add(m_comLanthegar);
            splitContainer2.Panel1.Controls.Add(m_btnNyrLanthegi);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(m_grbDIP);
            splitContainer2.Size = new Size(1129, 542);
            splitContainer2.SplitterDistance = 266;
            splitContainer2.TabIndex = 0;
            // 
            // m_btnPantAthUpp
            // 
            m_btnPantAthUpp.Location = new Point(834, 221);
            m_btnPantAthUpp.Name = "m_btnPantAthUpp";
            m_btnPantAthUpp.Size = new Size(194, 23);
            m_btnPantAthUpp.TabIndex = 19;
            m_btnPantAthUpp.Text = "Uppfæra athugasemdir";
            m_btnPantAthUpp.UseVisualStyleBackColor = true;
            m_btnPantAthUpp.Click += m_btnPantAthUpp_Click;
            // 
            // m_grbAthugasemdir
            // 
            m_grbAthugasemdir.Controls.Add(m_tboPontunAth);
            m_grbAthugasemdir.Location = new Point(831, 69);
            m_grbAthugasemdir.Name = "m_grbAthugasemdir";
            m_grbAthugasemdir.Size = new Size(334, 146);
            m_grbAthugasemdir.TabIndex = 18;
            m_grbAthugasemdir.TabStop = false;
            m_grbAthugasemdir.Text = "Athugasemdir pöntunar";
            // 
            // m_tboPontunAth
            // 
            m_tboPontunAth.Dock = DockStyle.Fill;
            m_tboPontunAth.Location = new Point(3, 19);
            m_tboPontunAth.Multiline = true;
            m_tboPontunAth.Name = "m_tboPontunAth";
            m_tboPontunAth.Size = new Size(328, 124);
            m_tboPontunAth.TabIndex = 9;
            // 
            // m_lblPontunstatus
            // 
            m_lblPontunstatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            m_lblPontunstatus.AutoSize = true;
            m_lblPontunstatus.Location = new Point(588, 236);
            m_lblPontunstatus.Name = "m_lblPontunstatus";
            m_lblPontunstatus.Size = new Size(38, 15);
            m_lblPontunstatus.TabIndex = 17;
            m_lblPontunstatus.Text = "label7";
            m_lblPontunstatus.Visible = false;
            // 
            // m_pgbPontun
            // 
            m_pgbPontun.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            m_pgbPontun.Location = new Point(137, 229);
            m_pgbPontun.Name = "m_pgbPontun";
            m_pgbPontun.Size = new Size(417, 23);
            m_pgbPontun.TabIndex = 16;
            m_pgbPontun.Visible = false;
            // 
            // m_btnTæma
            // 
            m_btnTæma.Location = new Point(679, 175);
            m_btnTæma.Name = "m_btnTæma";
            m_btnTæma.Size = new Size(125, 23);
            m_btnTæma.TabIndex = 15;
            m_btnTæma.Text = "Tæma lista";
            m_btnTæma.UseVisualStyleBackColor = true;
            m_btnTæma.Click += m_btnTæma_Click;
            // 
            // m_lblLanthegi
            // 
            m_lblLanthegi.AutoSize = true;
            m_lblLanthegi.Location = new Point(137, 117);
            m_lblLanthegi.Name = "m_lblLanthegi";
            m_lblLanthegi.Size = new Size(38, 15);
            m_lblLanthegi.TabIndex = 14;
            m_lblLanthegi.Text = "label6";
            m_lblLanthegi.Visible = false;
            // 
            // m_btnOpna
            // 
            m_btnOpna.Location = new Point(679, 146);
            m_btnOpna.Name = "m_btnOpna";
            m_btnOpna.Size = new Size(125, 23);
            m_btnOpna.TabIndex = 13;
            m_btnOpna.Text = "Opna pakka";
            m_btnOpna.UseVisualStyleBackColor = true;
            m_btnOpna.Click += m_btnOpna_Click;
            // 
            // m_btnKlaraPontun
            // 
            m_btnKlaraPontun.Location = new Point(679, 109);
            m_btnKlaraPontun.Name = "m_btnKlaraPontun";
            m_btnKlaraPontun.Size = new Size(125, 23);
            m_btnKlaraPontun.TabIndex = 12;
            m_btnKlaraPontun.Text = "Klára pöntun";
            m_btnKlaraPontun.UseVisualStyleBackColor = true;
            m_btnKlaraPontun.Click += m_btnKlaraPontun_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(137, 73);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 11;
            label5.Text = "Veldu lánþega";
            // 
            // m_comLanthegar
            // 
            m_comLanthegar.FormattingEnabled = true;
            m_comLanthegar.Location = new Point(268, 69);
            m_comLanthegar.Name = "m_comLanthegar";
            m_comLanthegar.Size = new Size(352, 23);
            m_comLanthegar.TabIndex = 10;
            m_comLanthegar.SelectedIndexChanged += m_comLanthegar_SelectedIndexChanged;
            // 
            // m_btnNyrLanthegi
            // 
            m_btnNyrLanthegi.Location = new Point(679, 69);
            m_btnNyrLanthegi.Name = "m_btnNyrLanthegi";
            m_btnNyrLanthegi.Size = new Size(125, 23);
            m_btnNyrLanthegi.TabIndex = 9;
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
            m_grbDIP.Size = new Size(1129, 272);
            m_grbDIP.TabIndex = 4;
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
            m_tacPontun.Size = new Size(1123, 250);
            m_tacPontun.TabIndex = 3;
            // 
            // m_tapPontunSkra
            // 
            m_tapPontunSkra.Controls.Add(m_dgvDIPList);
            m_tapPontunSkra.Location = new Point(4, 24);
            m_tapPontunSkra.Name = "m_tapPontunSkra";
            m_tapPontunSkra.Padding = new Padding(3);
            m_tapPontunSkra.Size = new Size(1115, 222);
            m_tapPontunSkra.TabIndex = 0;
            m_tapPontunSkra.Text = "Skráarkerfi";
            m_tapPontunSkra.UseVisualStyleBackColor = true;
            // 
            // m_dgvDIPList
            // 
            m_dgvDIPList.AllowUserToAddRows = false;
            m_dgvDIPList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvDIPList.Columns.AddRange(new DataGridViewColumn[] { colID, colTitill, colHeitiUtgáfu, colSkraOpna, colSkraRemove, colSkraVarslaID });
            m_dgvDIPList.Dock = DockStyle.Fill;
            m_dgvDIPList.Location = new Point(3, 3);
            m_dgvDIPList.Name = "m_dgvDIPList";
            m_dgvDIPList.ReadOnly = true;
            m_dgvDIPList.RowHeadersVisible = false;
            m_dgvDIPList.RowTemplate.Height = 25;
            m_dgvDIPList.Size = new Size(1109, 216);
            m_dgvDIPList.TabIndex = 3;
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
            colSkraOpna.ToolTipText = "Opna skrá";
            colSkraOpna.UseColumnTextForButtonValue = true;
            colSkraOpna.Width = 42;
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
            colSkraVarslaID.HeaderText = "vörsluútgáfuauðkenni";
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
            m_tapPontunMalakerfi.Size = new Size(1115, 222);
            m_tapPontunMalakerfi.TabIndex = 1;
            m_tapPontunMalakerfi.Text = "Málakerfi";
            m_tapPontunMalakerfi.UseVisualStyleBackColor = true;
            // 
            // m_dgvDIPmal
            // 
            m_dgvDIPmal.AllowUserToAddRows = false;
            m_dgvDIPmal.AllowUserToDeleteRows = false;
            m_dgvDIPmal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvDIPmal.Columns.AddRange(new DataGridViewColumn[] { colMalSkraID, colMalTitillSkjals, colMalMalTitill, colMalHeitiVarsla, colMalOpna, colMalRemove, colMalSlod, colMalGagnagrunnur });
            m_dgvDIPmal.Dock = DockStyle.Fill;
            m_dgvDIPmal.Location = new Point(3, 3);
            m_dgvDIPmal.Name = "m_dgvDIPmal";
            m_dgvDIPmal.ReadOnly = true;
            m_dgvDIPmal.RowHeadersVisible = false;
            m_dgvDIPmal.RowTemplate.Height = 25;
            m_dgvDIPmal.Size = new Size(1109, 216);
            m_dgvDIPmal.TabIndex = 0;
            m_dgvDIPmal.CellClick += m_dgvDIPList_CellClick;
            // 
            // colMalSkraID
            // 
            colMalSkraID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalSkraID.DataPropertyName = "documentid";
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
            // colMalMalTitill
            // 
            colMalMalTitill.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalMalTitill.DataPropertyName = "maltitill";
            colMalMalTitill.HeaderText = "Titill máls";
            colMalMalTitill.Name = "colMalMalTitill";
            colMalMalTitill.ReadOnly = true;
            colMalMalTitill.Width = 76;
            // 
            // colMalHeitiVarsla
            // 
            colMalHeitiVarsla.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalHeitiVarsla.DataPropertyName = "heitivorslu";
            colMalHeitiVarsla.HeaderText = "Heiti vörsluútgáfu";
            colMalHeitiVarsla.Name = "colMalHeitiVarsla";
            colMalHeitiVarsla.ReadOnly = true;
            colMalHeitiVarsla.Width = 116;
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
            // colMalRemove
            // 
            colMalRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalRemove.HeaderText = "Fjarlægja";
            colMalRemove.Name = "colMalRemove";
            colMalRemove.ReadOnly = true;
            colMalRemove.Text = "Fjarlægja";
            colMalRemove.ToolTipText = "Fjarlægja úr pöntun";
            colMalRemove.UseColumnTextForButtonValue = true;
            colMalRemove.Width = 61;
            // 
            // colMalSlod
            // 
            colMalSlod.DataPropertyName = "slod";
            colMalSlod.HeaderText = "slóð vörsluútgáfur";
            colMalSlod.Name = "colMalSlod";
            colMalSlod.ReadOnly = true;
            colMalSlod.Visible = false;
            // 
            // colMalGagnagrunnur
            // 
            colMalGagnagrunnur.DataPropertyName = "gagnagrunnur";
            colMalGagnagrunnur.HeaderText = "gagnagrunnur";
            colMalGagnagrunnur.Name = "colMalGagnagrunnur";
            colMalGagnagrunnur.ReadOnly = true;
            colMalGagnagrunnur.Visible = false;
            // 
            // m_tapPontunGagnagrunnar
            // 
            m_tapPontunGagnagrunnar.Controls.Add(m_dgvDIPGagnagrunnar);
            m_tapPontunGagnagrunnar.Location = new Point(4, 24);
            m_tapPontunGagnagrunnar.Name = "m_tapPontunGagnagrunnar";
            m_tapPontunGagnagrunnar.Padding = new Padding(3);
            m_tapPontunGagnagrunnar.Size = new Size(1115, 222);
            m_tapPontunGagnagrunnar.TabIndex = 2;
            m_tapPontunGagnagrunnar.Text = "Gagnagrunnar";
            m_tapPontunGagnagrunnar.UseVisualStyleBackColor = true;
            // 
            // m_dgvDIPGagnagrunnar
            // 
            m_dgvDIPGagnagrunnar.AllowUserToAddRows = false;
            m_dgvDIPGagnagrunnar.AllowUserToDeleteRows = false;
            m_dgvDIPGagnagrunnar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvDIPGagnagrunnar.Columns.AddRange(new DataGridViewColumn[] { colGagnHeiti, colGagnLeitSkilyrdi, colGagnHeitivorslu, colGagnOpna, colGagnRemove, colGagnSQL });
            m_dgvDIPGagnagrunnar.Dock = DockStyle.Fill;
            m_dgvDIPGagnagrunnar.Location = new Point(3, 3);
            m_dgvDIPGagnagrunnar.Name = "m_dgvDIPGagnagrunnar";
            m_dgvDIPGagnagrunnar.ReadOnly = true;
            m_dgvDIPGagnagrunnar.RowHeadersVisible = false;
            m_dgvDIPGagnagrunnar.RowTemplate.Height = 25;
            m_dgvDIPGagnagrunnar.Size = new Size(1109, 216);
            m_dgvDIPGagnagrunnar.TabIndex = 0;
            m_dgvDIPGagnagrunnar.CellClick += m_dgvDIPList_CellClick;
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
            // colGagnLeitSkilyrdi
            // 
            colGagnLeitSkilyrdi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGagnLeitSkilyrdi.DataPropertyName = "leitarskilyrdi";
            colGagnLeitSkilyrdi.HeaderText = "Leitarskílyrði";
            colGagnLeitSkilyrdi.Name = "colGagnLeitSkilyrdi";
            colGagnLeitSkilyrdi.ReadOnly = true;
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
            colGagnRemove.ToolTipText = "Fjarlægja úr pöntun";
            colGagnRemove.UseColumnTextForButtonValue = true;
            colGagnRemove.Width = 61;
            // 
            // colGagnSQL
            // 
            colGagnSQL.DataPropertyName = "sql";
            colGagnSQL.HeaderText = "sql";
            colGagnSQL.Name = "colGagnSQL";
            colGagnSQL.ReadOnly = true;
            colGagnSQL.Visible = false;
            // 
            // m_lblKarfaNr
            // 
            m_lblKarfaNr.AutoSize = true;
            m_lblKarfaNr.Location = new Point(139, 96);
            m_lblKarfaNr.Name = "m_lblKarfaNr";
            m_lblKarfaNr.Size = new Size(38, 15);
            m_lblKarfaNr.TabIndex = 20;
            m_lblKarfaNr.Text = "label1";
            // 
            // uscPantanir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "uscPantanir";
            Size = new Size(1461, 542);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
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
            ResumeLayout(false);
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
        private DataGridViewButtonColumn colSkraOpna;
        private DataGridViewButtonColumn colSkraRemove;
        private DataGridViewTextBoxColumn colSkraVarslaID;
        private DataGridViewTextBoxColumn colGagnHeiti;
        private DataGridViewTextBoxColumn colGagnLeitSkilyrdi;
        private DataGridViewTextBoxColumn colGagnHeitivorslu;
        private DataGridViewButtonColumn colGagnOpna;
        private DataGridViewButtonColumn colGagnRemove;
        private DataGridViewTextBoxColumn colGagnSQL;
        private DataGridViewTextBoxColumn colMalSkraID;
        private DataGridViewTextBoxColumn colMalTitillSkjals;
        private DataGridViewTextBoxColumn colMalMalTitill;
        private DataGridViewTextBoxColumn colMalHeitiVarsla;
        private DataGridViewButtonColumn colMalOpna;
        private DataGridViewButtonColumn colMalRemove;
        private DataGridViewTextBoxColumn colMalSlod;
        private DataGridViewTextBoxColumn colMalGagnagrunnur;
        private GroupBox m_grbAthugasemdir;
        private TextBox m_tboPontunAth;
        private Button m_btnPantAthUpp;
        private Label m_lblKarfaNr;
    }
}
