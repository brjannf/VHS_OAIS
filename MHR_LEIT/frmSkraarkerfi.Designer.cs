namespace MHR_LEIT
{
    partial class frmSkraarkerfi
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            m_dgvValdarSkrar = new DataGridView();
            colAudkenniSkjals = new DataGridViewTextBoxColumn();
            colTitillSkjals = new DataGridViewTextBoxColumn();
            colSkraHeitiVarsla = new DataGridViewTextBoxColumn();
            colSkraOpna = new DataGridViewButtonColumn();
            colSkraEyda = new DataGridViewButtonColumn();
            colSkraVarslaID = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            m_tacStrukturLeit = new TabControl();
            m_tapMoppuStruct = new TabPage();
            m_trwFileSystem = new TreeView();
            m_tapLeitNiðutstöður = new TabPage();
            m_trwLeit = new TreeView();
            splitContainer2 = new SplitContainer();
            label5 = new Label();
            m_comExternsion = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            m_dtEnd = new DateTimePicker();
            m_dtpStart = new DateTimePicker();
            m_btnLeita = new Button();
            m_lblLeitarNidurstodur = new Label();
            m_tobLeitarord = new TextBox();
            splitContainer3 = new SplitContainer();
            m_btnMD5Stadfesta = new Button();
            m_grbMeta = new GroupBox();
            m_btnSkjalamyndari = new Button();
            m_btnSkjalaskrá = new Button();
            m_btnVorslustofnun = new Button();
            m_lblMD5 = new Label();
            m_lilSlod = new LinkLabel();
            m_tboMD5 = new TextBox();
            m_lblDagsetning = new Label();
            m_btnAfgreida = new Button();
            m_lblSlodFile = new Label();
            m_lblSidaValinn = new Label();
            label1 = new Label();
            m_btnAfrit = new Button();
            m_numUpDown = new NumericUpDown();
            m_btnFrumRit = new Button();
            splitContainer4 = new SplitContainer();
            m_pibSkjal = new PictureBox();
            m_grbValdinnSkjol = new GroupBox();
            m_tacPantanir = new TabControl();
            m_tapSkraarkerfi = new TabPage();
            m_tapMalakerfi = new TabPage();
            m_dgvMalakerfi = new DataGridView();
            colMalSkraID = new DataGridViewTextBoxColumn();
            colMalTitill = new DataGridViewTextBoxColumn();
            colMalMalTitill = new DataGridViewTextBoxColumn();
            colMalHeitiVorslu = new DataGridViewTextBoxColumn();
            colMalOpna = new DataGridViewButtonColumn();
            colMalDelete = new DataGridViewButtonColumn();
            colMalSlod = new DataGridViewTextBoxColumn();
            colMalGagnagrunnur = new DataGridViewTextBoxColumn();
            m_tapGagnagrunnar = new TabPage();
            m_dgvGagnaGrunnar = new DataGridView();
            colGagnHeiti = new DataGridViewTextBoxColumn();
            colGagnLeidarskilyrdi = new DataGridViewTextBoxColumn();
            colGagnHeitiVorslu = new DataGridViewTextBoxColumn();
            colGagnOpna = new DataGridViewButtonColumn();
            colGagnDelete = new DataGridViewButtonColumn();
            colGagnSQL = new DataGridViewTextBoxColumn();
            m_btnLoka = new Button();
            ((System.ComponentModel.ISupportInitialize)m_dgvValdarSkrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            m_tacStrukturLeit.SuspendLayout();
            m_tapMoppuStruct.SuspendLayout();
            m_tapLeitNiðutstöður.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            m_grbMeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_numUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_pibSkjal).BeginInit();
            m_grbValdinnSkjol.SuspendLayout();
            m_tacPantanir.SuspendLayout();
            m_tapSkraarkerfi.SuspendLayout();
            m_tapMalakerfi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvMalakerfi).BeginInit();
            m_tapGagnagrunnar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvGagnaGrunnar).BeginInit();
            SuspendLayout();
            // 
            // m_dgvValdarSkrar
            // 
            m_dgvValdarSkrar.AllowUserToAddRows = false;
            m_dgvValdarSkrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvValdarSkrar.Columns.AddRange(new DataGridViewColumn[] { colAudkenniSkjals, colTitillSkjals, colSkraHeitiVarsla, colSkraOpna, colSkraEyda, colSkraVarslaID });
            m_dgvValdarSkrar.Dock = DockStyle.Fill;
            m_dgvValdarSkrar.Location = new Point(3, 3);
            m_dgvValdarSkrar.Name = "m_dgvValdarSkrar";
            m_dgvValdarSkrar.ReadOnly = true;
            m_dgvValdarSkrar.RowHeadersVisible = false;
            m_dgvValdarSkrar.RowTemplate.Height = 25;
            m_dgvValdarSkrar.Size = new Size(748, 589);
            m_dgvValdarSkrar.TabIndex = 0;
            m_dgvValdarSkrar.CellClick += m_dgvValdarSkrar_CellClick;
            // 
            // colAudkenniSkjals
            // 
            colAudkenniSkjals.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colAudkenniSkjals.DataPropertyName = "skjalID";
            colAudkenniSkjals.HeaderText = "Auðkenni skjals";
            colAudkenniSkjals.Name = "colAudkenniSkjals";
            colAudkenniSkjals.ReadOnly = true;
            colAudkenniSkjals.Width = 105;
            // 
            // colTitillSkjals
            // 
            colTitillSkjals.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTitillSkjals.DataPropertyName = "titill";
            colTitillSkjals.HeaderText = "Titill skjals";
            colTitillSkjals.Name = "colTitillSkjals";
            colTitillSkjals.ReadOnly = true;
            // 
            // colSkraHeitiVarsla
            // 
            colSkraHeitiVarsla.DataPropertyName = "heitivorslu";
            colSkraHeitiVarsla.HeaderText = "Heiti vörsluútgáfu";
            colSkraHeitiVarsla.Name = "colSkraHeitiVarsla";
            colSkraHeitiVarsla.ReadOnly = true;
            // 
            // colSkraOpna
            // 
            colSkraOpna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colSkraOpna.HeaderText = "Opna";
            colSkraOpna.Name = "colSkraOpna";
            colSkraOpna.ReadOnly = true;
            colSkraOpna.Resizable = DataGridViewTriState.True;
            colSkraOpna.SortMode = DataGridViewColumnSortMode.Automatic;
            colSkraOpna.Text = "Opna";
            colSkraOpna.ToolTipText = "Opna skrá";
            colSkraOpna.UseColumnTextForButtonValue = true;
            colSkraOpna.Width = 61;
            // 
            // colSkraEyda
            // 
            colSkraEyda.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colSkraEyda.HeaderText = "Fjarlægja";
            colSkraEyda.Name = "colSkraEyda";
            colSkraEyda.ReadOnly = true;
            colSkraEyda.Text = "Fjarlægja";
            colSkraEyda.UseColumnTextForButtonValue = true;
            colSkraEyda.Width = 61;
            // 
            // colSkraVarslaID
            // 
            colSkraVarslaID.DataPropertyName = "vorsluutgafa";
            colSkraVarslaID.HeaderText = "vorsluaudkenni";
            colSkraVarslaID.Name = "colSkraVarslaID";
            colSkraVarslaID.ReadOnly = true;
            colSkraVarslaID.Visible = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(m_tacStrukturLeit);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1822, 931);
            splitContainer1.SplitterDistance = 324;
            splitContainer1.TabIndex = 0;
            // 
            // m_tacStrukturLeit
            // 
            m_tacStrukturLeit.Controls.Add(m_tapMoppuStruct);
            m_tacStrukturLeit.Controls.Add(m_tapLeitNiðutstöður);
            m_tacStrukturLeit.Dock = DockStyle.Fill;
            m_tacStrukturLeit.Location = new Point(0, 0);
            m_tacStrukturLeit.Name = "m_tacStrukturLeit";
            m_tacStrukturLeit.SelectedIndex = 0;
            m_tacStrukturLeit.Size = new Size(324, 931);
            m_tacStrukturLeit.TabIndex = 1;
            // 
            // m_tapMoppuStruct
            // 
            m_tapMoppuStruct.Controls.Add(m_trwFileSystem);
            m_tapMoppuStruct.Location = new Point(4, 24);
            m_tapMoppuStruct.Name = "m_tapMoppuStruct";
            m_tapMoppuStruct.Padding = new Padding(3);
            m_tapMoppuStruct.Size = new Size(316, 903);
            m_tapMoppuStruct.TabIndex = 0;
            m_tapMoppuStruct.Text = "Möppur/skrár";
            m_tapMoppuStruct.UseVisualStyleBackColor = true;
            // 
            // m_trwFileSystem
            // 
            m_trwFileSystem.CheckBoxes = true;
            m_trwFileSystem.Dock = DockStyle.Fill;
            m_trwFileSystem.Location = new Point(3, 3);
            m_trwFileSystem.Name = "m_trwFileSystem";
            m_trwFileSystem.Size = new Size(310, 897);
            m_trwFileSystem.TabIndex = 0;
            m_trwFileSystem.AfterCheck += m_trwFileSystem_AfterCheck;
            m_trwFileSystem.AfterSelect += m_trwFileSystem_AfterSelect;
            // 
            // m_tapLeitNiðutstöður
            // 
            m_tapLeitNiðutstöður.Controls.Add(m_trwLeit);
            m_tapLeitNiðutstöður.Location = new Point(4, 24);
            m_tapLeitNiðutstöður.Name = "m_tapLeitNiðutstöður";
            m_tapLeitNiðutstöður.Padding = new Padding(3);
            m_tapLeitNiðutstöður.Size = new Size(316, 903);
            m_tapLeitNiðutstöður.TabIndex = 1;
            m_tapLeitNiðutstöður.Text = "Leitarniðurstöður";
            m_tapLeitNiðutstöður.UseVisualStyleBackColor = true;
            // 
            // m_trwLeit
            // 
            m_trwLeit.CheckBoxes = true;
            m_trwLeit.Dock = DockStyle.Fill;
            m_trwLeit.Location = new Point(3, 3);
            m_trwLeit.Name = "m_trwLeit";
            m_trwLeit.Size = new Size(310, 897);
            m_trwLeit.TabIndex = 0;
            m_trwLeit.AfterCheck += m_trwLeit_AfterCheck;
            m_trwLeit.AfterSelect += m_trwLeit_AfterSelect;
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
            splitContainer2.Panel1.Controls.Add(m_btnLoka);
            splitContainer2.Panel1.Controls.Add(label5);
            splitContainer2.Panel1.Controls.Add(m_comExternsion);
            splitContainer2.Panel1.Controls.Add(label4);
            splitContainer2.Panel1.Controls.Add(label3);
            splitContainer2.Panel1.Controls.Add(m_dtEnd);
            splitContainer2.Panel1.Controls.Add(m_dtpStart);
            splitContainer2.Panel1.Controls.Add(m_btnLeita);
            splitContainer2.Panel1.Controls.Add(m_lblLeitarNidurstodur);
            splitContainer2.Panel1.Controls.Add(m_tobLeitarord);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Size = new Size(1494, 931);
            splitContainer2.SplitterDistance = 164;
            splitContainer2.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(448, 90);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 20;
            label5.Text = "Skráaending";
            // 
            // m_comExternsion
            // 
            m_comExternsion.FormattingEnabled = true;
            m_comExternsion.Location = new Point(564, 84);
            m_comExternsion.Name = "m_comExternsion";
            m_comExternsion.Size = new Size(121, 23);
            m_comExternsion.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 126);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 18;
            label4.Text = "Endadagsetning";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 92);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 17;
            label3.Text = "Upphafsdagsetning";
            label3.Click += label3_Click;
            // 
            // m_dtEnd
            // 
            m_dtEnd.Checked = false;
            m_dtEnd.Location = new Point(195, 126);
            m_dtEnd.Name = "m_dtEnd";
            m_dtEnd.ShowCheckBox = true;
            m_dtEnd.Size = new Size(172, 23);
            m_dtEnd.TabIndex = 14;
            // 
            // m_dtpStart
            // 
            m_dtpStart.Checked = false;
            m_dtpStart.Location = new Point(195, 84);
            m_dtpStart.Name = "m_dtpStart";
            m_dtpStart.ShowCheckBox = true;
            m_dtpStart.Size = new Size(172, 23);
            m_dtpStart.TabIndex = 13;
            m_dtpStart.ValueChanged += m_dtpStart_ValueChanged;
            // 
            // m_btnLeita
            // 
            m_btnLeita.Location = new Point(1122, 30);
            m_btnLeita.Name = "m_btnLeita";
            m_btnLeita.Size = new Size(89, 23);
            m_btnLeita.TabIndex = 4;
            m_btnLeita.Text = "Leita";
            m_btnLeita.UseVisualStyleBackColor = true;
            m_btnLeita.Click += m_btnLeita_Click;
            // 
            // m_lblLeitarNidurstodur
            // 
            m_lblLeitarNidurstodur.AutoSize = true;
            m_lblLeitarNidurstodur.Location = new Point(39, 65);
            m_lblLeitarNidurstodur.Name = "m_lblLeitarNidurstodur";
            m_lblLeitarNidurstodur.Size = new Size(38, 15);
            m_lblLeitarNidurstodur.TabIndex = 3;
            m_lblLeitarNidurstodur.Text = "label1";
            m_lblLeitarNidurstodur.Click += m_lblLeitarNidurstodur_Click;
            // 
            // m_tobLeitarord
            // 
            m_tobLeitarord.Location = new Point(39, 30);
            m_tobLeitarord.Name = "m_tobLeitarord";
            m_tobLeitarord.Size = new Size(1044, 23);
            m_tobLeitarord.TabIndex = 2;
            m_tobLeitarord.KeyUp += m_tobLeitarord_KeyUp;
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
            splitContainer3.Panel1.Controls.Add(m_btnMD5Stadfesta);
            splitContainer3.Panel1.Controls.Add(m_grbMeta);
            splitContainer3.Panel1.Controls.Add(m_lblMD5);
            splitContainer3.Panel1.Controls.Add(m_lilSlod);
            splitContainer3.Panel1.Controls.Add(m_tboMD5);
            splitContainer3.Panel1.Controls.Add(m_lblDagsetning);
            splitContainer3.Panel1.Controls.Add(m_btnAfgreida);
            splitContainer3.Panel1.Controls.Add(m_lblSlodFile);
            splitContainer3.Panel1.Controls.Add(m_lblSidaValinn);
            splitContainer3.Panel1.Controls.Add(label1);
            splitContainer3.Panel1.Controls.Add(m_btnAfrit);
            splitContainer3.Panel1.Controls.Add(m_numUpDown);
            splitContainer3.Panel1.Controls.Add(m_btnFrumRit);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(splitContainer4);
            splitContainer3.Size = new Size(1494, 763);
            splitContainer3.SplitterDistance = 114;
            splitContainer3.TabIndex = 1;
            // 
            // m_btnMD5Stadfesta
            // 
            m_btnMD5Stadfesta.Location = new Point(417, 82);
            m_btnMD5Stadfesta.Name = "m_btnMD5Stadfesta";
            m_btnMD5Stadfesta.Size = new Size(72, 23);
            m_btnMD5Stadfesta.TabIndex = 10;
            m_btnMD5Stadfesta.Text = "Staðfesta";
            m_btnMD5Stadfesta.UseVisualStyleBackColor = true;
            m_btnMD5Stadfesta.Visible = false;
            m_btnMD5Stadfesta.Click += m_btnMD5Stadfesta_Click;
            // 
            // m_grbMeta
            // 
            m_grbMeta.Controls.Add(m_btnSkjalamyndari);
            m_grbMeta.Controls.Add(m_btnSkjalaskrá);
            m_grbMeta.Controls.Add(m_btnVorslustofnun);
            m_grbMeta.Location = new Point(1122, 10);
            m_grbMeta.Name = "m_grbMeta";
            m_grbMeta.Size = new Size(239, 101);
            m_grbMeta.TabIndex = 9;
            m_grbMeta.TabStop = false;
            m_grbMeta.Text = "Lýsigögn";
            // 
            // m_btnSkjalamyndari
            // 
            m_btnSkjalamyndari.Location = new Point(33, 63);
            m_btnSkjalamyndari.Name = "m_btnSkjalamyndari";
            m_btnSkjalamyndari.Size = new Size(90, 23);
            m_btnSkjalamyndari.TabIndex = 2;
            m_btnSkjalamyndari.Text = "Skjalamyndari";
            m_btnSkjalamyndari.UseVisualStyleBackColor = true;
            m_btnSkjalamyndari.Click += m_btnSkjalamyndari_Click;
            // 
            // m_btnSkjalaskrá
            // 
            m_btnSkjalaskrá.Location = new Point(138, 22);
            m_btnSkjalaskrá.Name = "m_btnSkjalaskrá";
            m_btnSkjalaskrá.Size = new Size(75, 23);
            m_btnSkjalaskrá.TabIndex = 1;
            m_btnSkjalaskrá.Text = "Skjalaskrá";
            m_btnSkjalaskrá.UseVisualStyleBackColor = true;
            m_btnSkjalaskrá.Click += m_btnSkjalaskrá_Click;
            // 
            // m_btnVorslustofnun
            // 
            m_btnVorslustofnun.Location = new Point(33, 22);
            m_btnVorslustofnun.Name = "m_btnVorslustofnun";
            m_btnVorslustofnun.Size = new Size(90, 23);
            m_btnVorslustofnun.TabIndex = 0;
            m_btnVorslustofnun.Text = "Vörslustofnun";
            m_btnVorslustofnun.UseVisualStyleBackColor = true;
            m_btnVorslustofnun.Click += m_btnVorslustofnun_Click;
            // 
            // m_lblMD5
            // 
            m_lblMD5.AutoSize = true;
            m_lblMD5.Location = new Point(56, 87);
            m_lblMD5.Name = "m_lblMD5";
            m_lblMD5.Size = new Size(38, 15);
            m_lblMD5.TabIndex = 9;
            m_lblMD5.Text = "label1";
            m_lblMD5.Visible = false;
            // 
            // m_lilSlod
            // 
            m_lilSlod.AutoSize = true;
            m_lilSlod.Location = new Point(19, 29);
            m_lilSlod.Name = "m_lilSlod";
            m_lilSlod.Size = new Size(55, 15);
            m_lilSlod.TabIndex = 8;
            m_lilSlod.TabStop = true;
            m_lilSlod.Text = "m_lilSlod";
            m_lilSlod.LinkClicked += m_lilSlod_LinkClicked;
            // 
            // m_tboMD5
            // 
            m_tboMD5.Location = new Point(149, 84);
            m_tboMD5.Name = "m_tboMD5";
            m_tboMD5.ReadOnly = true;
            m_tboMD5.Size = new Size(262, 23);
            m_tboMD5.TabIndex = 8;
            m_tboMD5.Text = "asfdasfasfdasf";
            m_tboMD5.Visible = false;
            m_tboMD5.WordWrap = false;
            // 
            // m_lblDagsetning
            // 
            m_lblDagsetning.AutoSize = true;
            m_lblDagsetning.Location = new Point(19, 10);
            m_lblDagsetning.Name = "m_lblDagsetning";
            m_lblDagsetning.Size = new Size(96, 15);
            m_lblDagsetning.TabIndex = 7;
            m_lblDagsetning.Text = "m_lblDagsetning";
            // 
            // m_btnAfgreida
            // 
            m_btnAfgreida.Enabled = false;
            m_btnAfgreida.Location = new Point(933, 84);
            m_btnAfgreida.Name = "m_btnAfgreida";
            m_btnAfgreida.Size = new Size(150, 23);
            m_btnAfgreida.TabIndex = 6;
            m_btnAfgreida.Text = "Ljúka pöntun";
            m_btnAfgreida.UseVisualStyleBackColor = true;
            m_btnAfgreida.Click += m_btnAfgreida_Click;
            // 
            // m_lblSlodFile
            // 
            m_lblSlodFile.AutoSize = true;
            m_lblSlodFile.Location = new Point(19, 47);
            m_lblSlodFile.Name = "m_lblSlodFile";
            m_lblSlodFile.Size = new Size(38, 15);
            m_lblSlodFile.TabIndex = 5;
            m_lblSlodFile.Text = "label2";
            // 
            // m_lblSidaValinn
            // 
            m_lblSidaValinn.AutoSize = true;
            m_lblSidaValinn.Location = new Point(678, 88);
            m_lblSidaValinn.Name = "m_lblSidaValinn";
            m_lblSidaValinn.Size = new Size(29, 15);
            m_lblSidaValinn.TabIndex = 3;
            m_lblSidaValinn.Text = "Siða";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(554, 88);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 2;
            label1.Text = "Siða";
            // 
            // m_btnAfrit
            // 
            m_btnAfrit.Location = new Point(933, 47);
            m_btnAfrit.Name = "m_btnAfrit";
            m_btnAfrit.Size = new Size(150, 23);
            m_btnAfrit.TabIndex = 1;
            m_btnAfrit.Text = "Opna afrit";
            m_btnAfrit.UseVisualStyleBackColor = true;
            m_btnAfrit.Click += m_btnAfrit_Click;
            // 
            // m_numUpDown
            // 
            m_numUpDown.Location = new Point(613, 84);
            m_numUpDown.Name = "m_numUpDown";
            m_numUpDown.RightToLeft = RightToLeft.No;
            m_numUpDown.Size = new Size(40, 23);
            m_numUpDown.TabIndex = 1;
            m_numUpDown.ValueChanged += m_numUpDown_ValueChanged;
            // 
            // m_btnFrumRit
            // 
            m_btnFrumRit.Location = new Point(933, 10);
            m_btnFrumRit.Name = "m_btnFrumRit";
            m_btnFrumRit.Size = new Size(150, 23);
            m_btnFrumRit.TabIndex = 0;
            m_btnFrumRit.Text = "Opna frumrit";
            m_btnFrumRit.UseVisualStyleBackColor = true;
            m_btnFrumRit.Click += m_btnFrumRit_Click;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(0, 0);
            splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(m_pibSkjal);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(m_grbValdinnSkjol);
            splitContainer4.Size = new Size(1494, 645);
            splitContainer4.SplitterDistance = 722;
            splitContainer4.TabIndex = 1;
            // 
            // m_pibSkjal
            // 
            m_pibSkjal.Dock = DockStyle.Fill;
            m_pibSkjal.Location = new Point(0, 0);
            m_pibSkjal.Name = "m_pibSkjal";
            m_pibSkjal.Size = new Size(722, 645);
            m_pibSkjal.TabIndex = 0;
            m_pibSkjal.TabStop = false;
            m_pibSkjal.DoubleClick += m_pibSkjal_DoubleClick;
            // 
            // m_grbValdinnSkjol
            // 
            m_grbValdinnSkjol.Controls.Add(m_tacPantanir);
            m_grbValdinnSkjol.Dock = DockStyle.Fill;
            m_grbValdinnSkjol.Location = new Point(0, 0);
            m_grbValdinnSkjol.Name = "m_grbValdinnSkjol";
            m_grbValdinnSkjol.Size = new Size(768, 645);
            m_grbValdinnSkjol.TabIndex = 1;
            m_grbValdinnSkjol.TabStop = false;
            m_grbValdinnSkjol.Text = "Skjöl valinn";
            // 
            // m_tacPantanir
            // 
            m_tacPantanir.Controls.Add(m_tapSkraarkerfi);
            m_tacPantanir.Controls.Add(m_tapMalakerfi);
            m_tacPantanir.Controls.Add(m_tapGagnagrunnar);
            m_tacPantanir.Dock = DockStyle.Fill;
            m_tacPantanir.Location = new Point(3, 19);
            m_tacPantanir.Name = "m_tacPantanir";
            m_tacPantanir.SelectedIndex = 0;
            m_tacPantanir.Size = new Size(762, 623);
            m_tacPantanir.TabIndex = 1;
            // 
            // m_tapSkraarkerfi
            // 
            m_tapSkraarkerfi.Controls.Add(m_dgvValdarSkrar);
            m_tapSkraarkerfi.Location = new Point(4, 24);
            m_tapSkraarkerfi.Name = "m_tapSkraarkerfi";
            m_tapSkraarkerfi.Padding = new Padding(3);
            m_tapSkraarkerfi.Size = new Size(754, 595);
            m_tapSkraarkerfi.TabIndex = 0;
            m_tapSkraarkerfi.Text = "Skráarkerfi";
            m_tapSkraarkerfi.UseVisualStyleBackColor = true;
            // 
            // m_tapMalakerfi
            // 
            m_tapMalakerfi.Controls.Add(m_dgvMalakerfi);
            m_tapMalakerfi.Location = new Point(4, 24);
            m_tapMalakerfi.Name = "m_tapMalakerfi";
            m_tapMalakerfi.Padding = new Padding(3);
            m_tapMalakerfi.Size = new Size(754, 595);
            m_tapMalakerfi.TabIndex = 1;
            m_tapMalakerfi.Text = "Málakerfi";
            m_tapMalakerfi.UseVisualStyleBackColor = true;
            // 
            // m_dgvMalakerfi
            // 
            m_dgvMalakerfi.AllowUserToAddRows = false;
            m_dgvMalakerfi.AllowUserToDeleteRows = false;
            m_dgvMalakerfi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvMalakerfi.Columns.AddRange(new DataGridViewColumn[] { colMalSkraID, colMalTitill, colMalMalTitill, colMalHeitiVorslu, colMalOpna, colMalDelete, colMalSlod, colMalGagnagrunnur });
            m_dgvMalakerfi.Dock = DockStyle.Fill;
            m_dgvMalakerfi.Location = new Point(3, 3);
            m_dgvMalakerfi.Name = "m_dgvMalakerfi";
            m_dgvMalakerfi.ReadOnly = true;
            m_dgvMalakerfi.RowHeadersVisible = false;
            m_dgvMalakerfi.RowTemplate.Height = 25;
            m_dgvMalakerfi.Size = new Size(748, 589);
            m_dgvMalakerfi.TabIndex = 0;
            m_dgvMalakerfi.CellClick += m_dgvValdarSkrar_CellClick;
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
            // colMalTitill
            // 
            colMalTitill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMalTitill.DataPropertyName = "titill";
            colMalTitill.HeaderText = "Titill skjals";
            colMalTitill.Name = "colMalTitill";
            colMalTitill.ReadOnly = true;
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
            // colMalHeitiVorslu
            // 
            colMalHeitiVorslu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalHeitiVorslu.DataPropertyName = "heitivorslu";
            colMalHeitiVorslu.HeaderText = "Heiti vörsluútgáfu";
            colMalHeitiVorslu.Name = "colMalHeitiVorslu";
            colMalHeitiVorslu.ReadOnly = true;
            colMalHeitiVorslu.Width = 116;
            // 
            // colMalOpna
            // 
            colMalOpna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalOpna.HeaderText = "Opna";
            colMalOpna.Name = "colMalOpna";
            colMalOpna.ReadOnly = true;
            colMalOpna.Resizable = DataGridViewTriState.True;
            colMalOpna.SortMode = DataGridViewColumnSortMode.Automatic;
            colMalOpna.Text = "Opna";
            colMalOpna.ToolTipText = "Opna skrá";
            colMalOpna.UseColumnTextForButtonValue = true;
            colMalOpna.Width = 61;
            // 
            // colMalDelete
            // 
            colMalDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalDelete.HeaderText = "Fjarlægja";
            colMalDelete.Name = "colMalDelete";
            colMalDelete.ReadOnly = true;
            colMalDelete.Resizable = DataGridViewTriState.True;
            colMalDelete.SortMode = DataGridViewColumnSortMode.Automatic;
            colMalDelete.Text = "Fjarlægja";
            colMalDelete.ToolTipText = "Fjarlægja úr pöntun";
            colMalDelete.UseColumnTextForButtonValue = true;
            colMalDelete.Width = 80;
            // 
            // colMalSlod
            // 
            colMalSlod.DataPropertyName = "slod";
            colMalSlod.HeaderText = "Slóð skjals";
            colMalSlod.Name = "colMalSlod";
            colMalSlod.ReadOnly = true;
            colMalSlod.Visible = false;
            // 
            // colMalGagnagrunnur
            // 
            colMalGagnagrunnur.DataPropertyName = "gagnagrunnur";
            colMalGagnagrunnur.HeaderText = "Gagnagrunnur";
            colMalGagnagrunnur.Name = "colMalGagnagrunnur";
            colMalGagnagrunnur.ReadOnly = true;
            // 
            // m_tapGagnagrunnar
            // 
            m_tapGagnagrunnar.Controls.Add(m_dgvGagnaGrunnar);
            m_tapGagnagrunnar.Location = new Point(4, 24);
            m_tapGagnagrunnar.Name = "m_tapGagnagrunnar";
            m_tapGagnagrunnar.Padding = new Padding(3);
            m_tapGagnagrunnar.Size = new Size(754, 595);
            m_tapGagnagrunnar.TabIndex = 2;
            m_tapGagnagrunnar.Text = "Gagnagrunnar";
            m_tapGagnagrunnar.UseVisualStyleBackColor = true;
            // 
            // m_dgvGagnaGrunnar
            // 
            m_dgvGagnaGrunnar.AllowUserToAddRows = false;
            m_dgvGagnaGrunnar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvGagnaGrunnar.Columns.AddRange(new DataGridViewColumn[] { colGagnHeiti, colGagnLeidarskilyrdi, colGagnHeitiVorslu, colGagnOpna, colGagnDelete, colGagnSQL });
            m_dgvGagnaGrunnar.Dock = DockStyle.Fill;
            m_dgvGagnaGrunnar.Location = new Point(3, 3);
            m_dgvGagnaGrunnar.Name = "m_dgvGagnaGrunnar";
            m_dgvGagnaGrunnar.ReadOnly = true;
            m_dgvGagnaGrunnar.RowHeadersVisible = false;
            m_dgvGagnaGrunnar.RowTemplate.Height = 25;
            m_dgvGagnaGrunnar.Size = new Size(748, 589);
            m_dgvGagnaGrunnar.TabIndex = 0;
            m_dgvGagnaGrunnar.CellClick += m_dgvValdarSkrar_CellClick;
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
            // colGagnLeidarskilyrdi
            // 
            colGagnLeidarskilyrdi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGagnLeidarskilyrdi.DataPropertyName = "leitarskilyrdi";
            colGagnLeidarskilyrdi.HeaderText = "Leitarskilyrði";
            colGagnLeidarskilyrdi.Name = "colGagnLeidarskilyrdi";
            colGagnLeidarskilyrdi.ReadOnly = true;
            // 
            // colGagnHeitiVorslu
            // 
            colGagnHeitiVorslu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGagnHeitiVorslu.DataPropertyName = "heitivorslu";
            colGagnHeitiVorslu.HeaderText = "Heiti vörsluútgáfu";
            colGagnHeitiVorslu.Name = "colGagnHeitiVorslu";
            colGagnHeitiVorslu.ReadOnly = true;
            colGagnHeitiVorslu.Width = 116;
            // 
            // colGagnOpna
            // 
            colGagnOpna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGagnOpna.HeaderText = "Opna";
            colGagnOpna.Name = "colGagnOpna";
            colGagnOpna.ReadOnly = true;
            colGagnOpna.Resizable = DataGridViewTriState.True;
            colGagnOpna.SortMode = DataGridViewColumnSortMode.Automatic;
            colGagnOpna.Text = "Opna";
            colGagnOpna.ToolTipText = "Opna skrá";
            colGagnOpna.UseColumnTextForButtonValue = true;
            colGagnOpna.Width = 61;
            // 
            // colGagnDelete
            // 
            colGagnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGagnDelete.HeaderText = "Fjarlægja";
            colGagnDelete.Name = "colGagnDelete";
            colGagnDelete.ReadOnly = true;
            colGagnDelete.Text = "Fjarlægja";
            colGagnDelete.ToolTipText = "Fjarlægja úr pöntun";
            colGagnDelete.UseColumnTextForButtonValue = true;
            colGagnDelete.Width = 61;
            // 
            // colGagnSQL
            // 
            colGagnSQL.DataPropertyName = "sql";
            colGagnSQL.HeaderText = "Skrá sql";
            colGagnSQL.Name = "colGagnSQL";
            colGagnSQL.ReadOnly = true;
            colGagnSQL.Visible = false;
            // 
            // m_btnLoka
            // 
            m_btnLoka.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            m_btnLoka.Location = new Point(1402, 3);
            m_btnLoka.Name = "m_btnLoka";
            m_btnLoka.Size = new Size(89, 23);
            m_btnLoka.TabIndex = 21;
            m_btnLoka.Text = "Loka";
            m_btnLoka.UseVisualStyleBackColor = true;
            m_btnLoka.Click += m_btnLoka_Click;
            // 
            // frmSkraarkerfi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1822, 931);
            Controls.Add(splitContainer1);
            Name = "frmSkraarkerfi";
            Text = "frmSkraarkerfi";
            ((System.ComponentModel.ISupportInitialize)m_dgvValdarSkrar).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            m_tacStrukturLeit.ResumeLayout(false);
            m_tapMoppuStruct.ResumeLayout(false);
            m_tapLeitNiðutstöður.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            m_grbMeta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_numUpDown).EndInit();
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_pibSkjal).EndInit();
            m_grbValdinnSkjol.ResumeLayout(false);
            m_tacPantanir.ResumeLayout(false);
            m_tapSkraarkerfi.ResumeLayout(false);
            m_tapMalakerfi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvMalakerfi).EndInit();
            m_tapGagnagrunnar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvGagnaGrunnar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView m_trwFileSystem;
        private SplitContainer splitContainer2;
        private PictureBox m_pibSkjal;
        private Button m_btnFrumRit;
        private Button m_btnAfrit;
        private TextBox m_tobLeitarord;
        private Button m_btnLeita;
        private Label m_lblLeitarNidurstodur;
        private SplitContainer splitContainer3;
        private NumericUpDown m_numUpDown;
        private Label m_lblSidaValinn;
        private Label label1;
        private Label m_lblSlodFile;
        private Label label4;
        private Label label3;
        private DateTimePicker m_dtEnd;
        private DateTimePicker m_dtpStart;
        private SplitContainer splitContainer4;
        private DataGridView m_dgvValdarSkrar;
        private GroupBox m_grbValdinnSkjol;
        private TabControl m_tacPantanir;
        private TabPage m_tapSkraarkerfi;
        private TabPage m_tapMalakerfi;
        private DataGridView m_dgvMalakerfi;
        private TabPage m_tapGagnagrunnar;
        private DataGridView m_dgvGagnaGrunnar;
        private Button m_btnAfgreida;
        private TabControl m_tacStrukturLeit;
        private TabPage m_tapMoppuStruct;
        private TabPage m_tapLeitNiðutstöður;
        private TreeView m_trwLeit;
        private Label label5;
        private ComboBox m_comExternsion;
        private Label m_lblDagsetning;
        private DataGridViewTextBoxColumn colMD5;
        private DataGridViewTextBoxColumn colSlod;
        private LinkLabel m_lilSlod;
        private GroupBox m_grbMeta;
        private Button m_btnSkjalamyndari;
        private Button m_btnSkjalaskrá;
        private Button m_btnVorslustofnun;
        private DataGridViewTextBoxColumn colAudkenniSkjals;
        private DataGridViewTextBoxColumn colTitillSkjals;
        private DataGridViewTextBoxColumn colSkraHeitiVarsla;
        private DataGridViewButtonColumn colSkraOpna;
        private DataGridViewButtonColumn colSkraEyda;
        private DataGridViewTextBoxColumn colSkraVarslaID;
        private DataGridViewTextBoxColumn colGagnHeiti;
        private DataGridViewTextBoxColumn colGagnLeidarskilyrdi;
        private DataGridViewTextBoxColumn colGagnHeitiVorslu;
        private DataGridViewButtonColumn colGagnOpna;
        private DataGridViewButtonColumn colGagnDelete;
        private DataGridViewTextBoxColumn colGagnSQL;
        private DataGridViewTextBoxColumn colMalSkraID;
        private DataGridViewTextBoxColumn colMalTitill;
        private DataGridViewTextBoxColumn colMalMalTitill;
        private DataGridViewTextBoxColumn colMalHeitiVorslu;
        private DataGridViewButtonColumn colMalOpna;
        private DataGridViewButtonColumn colMalDelete;
        private DataGridViewTextBoxColumn colMalSlod;
        private DataGridViewTextBoxColumn colMalGagnagrunnur;
        private Button m_btnMD5Stadfesta;
        private Label m_lblMD5;
        private TextBox m_tboMD5;
        private Button m_btnLoka;
    }
}