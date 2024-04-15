namespace OAIS_ADMIN
{
    partial class uscInnSetning
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            m_grbSkyrsla = new GroupBox();
            m_btnKvittun = new Button();
            m_grbFlytjaSIP = new GroupBox();
            m_grbFRUM = new GroupBox();
            m_lblStatusFRUM = new Label();
            m_prbFRUM = new ProgressBar();
            m_lblFileFRUM = new Label();
            m_grbAvid = new GroupBox();
            m_prbAVID = new ProgressBar();
            m_lblStatusAPI = new Label();
            m_lblFilesAPI = new Label();
            m_btnFlytjaSIP = new Button();
            m_grbTekksuma = new GroupBox();
            m_dgvMD5Villur = new DataGridView();
            colMD5skjal = new DataGridViewTextBoxColumn();
            colMD5Var = new DataGridViewTextBoxColumn();
            colMD5Er = new DataGridViewTextBoxColumn();
            m_lblTekkSuma = new Label();
            m_pgbTekksuma = new ProgressBar();
            m_pnlSIP = new Panel();
            m_lblDragDrop = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            m_grbISAAR = new GroupBox();
            m_tboISAAR_auðkenni = new TextBox();
            m_lblISAAR_auðkenni = new Label();
            m_btnSkjalamyndariStadfesta = new Button();
            m_comISAAR_gerð = new ComboBox();
            m_lblISAAR_gerð = new Label();
            m_comISAAR_nafn = new ComboBox();
            m_lblISAAR_nafn_5_1_2 = new Label();
            m_grbISASG = new GroupBox();
            m_tboISADG_AFHNR = new TextBox();
            m_lblISADG_AFHNR = new Label();
            m_tboISADG_timabil = new TextBox();
            label1 = new Label();
            m_btnSkraningStaðfesta = new Button();
            m_comISADG_aðgengi = new ComboBox();
            m_lblISADG_aðgengi = new Label();
            m_grbISADG_innihald = new GroupBox();
            m_tboISADG_innihald = new TextBox();
            m_tboISADG_titill = new TextBox();
            m_lblISAAR_titill = new Label();
            m_tboISADG_auðkenni = new TextBox();
            m_lblISADG_Auðkenni = new Label();
            m_grbISDIAH = new GroupBox();
            m_lblISDIAH_klasi = new Label();
            m_comISDIAH_klasi = new ComboBox();
            m_lblHeitVarslaVantar = new Label();
            m_btnVörslustofnunStaðfesta = new Button();
            m_tboISDIAH_obinbert_heiti = new TextBox();
            m_lblISDIAH_Obinbert_heiti = new Label();
            m_tboISDIAH_auðkenni = new TextBox();
            m_lblISDIAH_auðkenni = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            m_grbSkyrsla.SuspendLayout();
            m_grbFlytjaSIP.SuspendLayout();
            m_grbFRUM.SuspendLayout();
            m_grbAvid.SuspendLayout();
            m_grbTekksuma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvMD5Villur).BeginInit();
            m_pnlSIP.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            m_grbISAAR.SuspendLayout();
            m_grbISASG.SuspendLayout();
            m_grbISADG_innihald.SuspendLayout();
            m_grbISDIAH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(m_grbSkyrsla);
            splitContainer1.Panel1.Controls.Add(m_grbFlytjaSIP);
            splitContainer1.Panel1.Controls.Add(m_grbTekksuma);
            splitContainer1.Panel1.Controls.Add(m_pnlSIP);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(1757, 1129);
            splitContainer1.SplitterDistance = 947;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // m_grbSkyrsla
            // 
            m_grbSkyrsla.Controls.Add(m_btnKvittun);
            m_grbSkyrsla.Dock = DockStyle.Top;
            m_grbSkyrsla.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            m_grbSkyrsla.Location = new Point(0, 836);
            m_grbSkyrsla.Margin = new Padding(3, 4, 3, 4);
            m_grbSkyrsla.Name = "m_grbSkyrsla";
            m_grbSkyrsla.Padding = new Padding(3, 4, 3, 4);
            m_grbSkyrsla.Size = new Size(943, 133);
            m_grbSkyrsla.TabIndex = 5;
            m_grbSkyrsla.TabStop = false;
            m_grbSkyrsla.Text = "C. búa til kvittun";
            // 
            // m_btnKvittun
            // 
            m_btnKvittun.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            m_btnKvittun.Enabled = false;
            m_btnKvittun.Location = new Point(275, 52);
            m_btnKvittun.Margin = new Padding(3, 4, 3, 4);
            m_btnKvittun.Name = "m_btnKvittun";
            m_btnKvittun.Size = new Size(253, 31);
            m_btnKvittun.TabIndex = 1;
            m_btnKvittun.Text = "Búa til kvittun";
            m_btnKvittun.UseVisualStyleBackColor = true;
            m_btnKvittun.Click += m_btnKvittun_Click;
            // 
            // m_grbFlytjaSIP
            // 
            m_grbFlytjaSIP.Controls.Add(m_grbFRUM);
            m_grbFlytjaSIP.Controls.Add(m_grbAvid);
            m_grbFlytjaSIP.Controls.Add(m_btnFlytjaSIP);
            m_grbFlytjaSIP.Dock = DockStyle.Top;
            m_grbFlytjaSIP.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            m_grbFlytjaSIP.Location = new Point(0, 460);
            m_grbFlytjaSIP.Margin = new Padding(3, 4, 3, 4);
            m_grbFlytjaSIP.Name = "m_grbFlytjaSIP";
            m_grbFlytjaSIP.Padding = new Padding(3, 4, 3, 4);
            m_grbFlytjaSIP.Size = new Size(943, 376);
            m_grbFlytjaSIP.TabIndex = 4;
            m_grbFlytjaSIP.TabStop = false;
            m_grbFlytjaSIP.Text = "B. Færa afhendingarútgáfu inn í kerfið (AIP)";
            // 
            // m_grbFRUM
            // 
            m_grbFRUM.Controls.Add(m_lblStatusFRUM);
            m_grbFRUM.Controls.Add(m_prbFRUM);
            m_grbFRUM.Controls.Add(m_lblFileFRUM);
            m_grbFRUM.Dock = DockStyle.Top;
            m_grbFRUM.Location = new Point(3, 153);
            m_grbFRUM.Margin = new Padding(3, 4, 3, 4);
            m_grbFRUM.Name = "m_grbFRUM";
            m_grbFRUM.Padding = new Padding(3, 4, 3, 4);
            m_grbFRUM.Size = new Size(937, 153);
            m_grbFRUM.TabIndex = 8;
            m_grbFRUM.TabStop = false;
            m_grbFRUM.Text = "FRUM";
            m_grbFRUM.Visible = false;
            // 
            // m_lblStatusFRUM
            // 
            m_lblStatusFRUM.AutoSize = true;
            m_lblStatusFRUM.Location = new Point(734, 56);
            m_lblStatusFRUM.Name = "m_lblStatusFRUM";
            m_lblStatusFRUM.Size = new Size(40, 15);
            m_lblStatusFRUM.TabIndex = 6;
            m_lblStatusFRUM.Text = "label2";
            // 
            // m_prbFRUM
            // 
            m_prbFRUM.Location = new Point(29, 56);
            m_prbFRUM.Margin = new Padding(3, 4, 3, 4);
            m_prbFRUM.Name = "m_prbFRUM";
            m_prbFRUM.Size = new Size(599, 31);
            m_prbFRUM.TabIndex = 4;
            // 
            // m_lblFileFRUM
            // 
            m_lblFileFRUM.AutoSize = true;
            m_lblFileFRUM.Location = new Point(29, 103);
            m_lblFileFRUM.Name = "m_lblFileFRUM";
            m_lblFileFRUM.Size = new Size(40, 15);
            m_lblFileFRUM.TabIndex = 5;
            m_lblFileFRUM.Text = "label2";
            // 
            // m_grbAvid
            // 
            m_grbAvid.Controls.Add(m_prbAVID);
            m_grbAvid.Controls.Add(m_lblStatusAPI);
            m_grbAvid.Controls.Add(m_lblFilesAPI);
            m_grbAvid.Dock = DockStyle.Top;
            m_grbAvid.Location = new Point(3, 20);
            m_grbAvid.Margin = new Padding(3, 4, 3, 4);
            m_grbAvid.Name = "m_grbAvid";
            m_grbAvid.Padding = new Padding(3, 4, 3, 4);
            m_grbAvid.Size = new Size(937, 133);
            m_grbAvid.TabIndex = 7;
            m_grbAvid.TabStop = false;
            m_grbAvid.Text = "AVID";
            m_grbAvid.Visible = false;
            // 
            // m_prbAVID
            // 
            m_prbAVID.Location = new Point(29, 48);
            m_prbAVID.Margin = new Padding(3, 4, 3, 4);
            m_prbAVID.Name = "m_prbAVID";
            m_prbAVID.Size = new Size(599, 31);
            m_prbAVID.TabIndex = 1;
            // 
            // m_lblStatusAPI
            // 
            m_lblStatusAPI.AutoSize = true;
            m_lblStatusAPI.Location = new Point(734, 64);
            m_lblStatusAPI.Name = "m_lblStatusAPI";
            m_lblStatusAPI.Size = new Size(40, 15);
            m_lblStatusAPI.TabIndex = 3;
            m_lblStatusAPI.Text = "label2";
            // 
            // m_lblFilesAPI
            // 
            m_lblFilesAPI.AutoSize = true;
            m_lblFilesAPI.Location = new Point(29, 96);
            m_lblFilesAPI.Name = "m_lblFilesAPI";
            m_lblFilesAPI.Size = new Size(40, 15);
            m_lblFilesAPI.TabIndex = 2;
            m_lblFilesAPI.Text = "label2";
            // 
            // m_btnFlytjaSIP
            // 
            m_btnFlytjaSIP.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            m_btnFlytjaSIP.Enabled = false;
            m_btnFlytjaSIP.Location = new Point(787, 320);
            m_btnFlytjaSIP.Margin = new Padding(3, 4, 3, 4);
            m_btnFlytjaSIP.Name = "m_btnFlytjaSIP";
            m_btnFlytjaSIP.Size = new Size(149, 31);
            m_btnFlytjaSIP.TabIndex = 0;
            m_btnFlytjaSIP.Text = "Flytja inn";
            m_btnFlytjaSIP.UseVisualStyleBackColor = true;
            m_btnFlytjaSIP.Click += m_btnFlytjaSIP_Click;
            // 
            // m_grbTekksuma
            // 
            m_grbTekksuma.Controls.Add(m_dgvMD5Villur);
            m_grbTekksuma.Controls.Add(m_lblTekkSuma);
            m_grbTekksuma.Controls.Add(m_pgbTekksuma);
            m_grbTekksuma.Dock = DockStyle.Top;
            m_grbTekksuma.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            m_grbTekksuma.Location = new Point(0, 263);
            m_grbTekksuma.Margin = new Padding(3, 4, 3, 4);
            m_grbTekksuma.Name = "m_grbTekksuma";
            m_grbTekksuma.Padding = new Padding(3, 4, 3, 4);
            m_grbTekksuma.Size = new Size(943, 197);
            m_grbTekksuma.TabIndex = 3;
            m_grbTekksuma.TabStop = false;
            m_grbTekksuma.Text = "A. Gátsummupróf";
            // 
            // m_dgvMD5Villur
            // 
            m_dgvMD5Villur.AllowUserToAddRows = false;
            m_dgvMD5Villur.AllowUserToDeleteRows = false;
            m_dgvMD5Villur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvMD5Villur.Columns.AddRange(new DataGridViewColumn[] { colMD5skjal, colMD5Var, colMD5Er });
            m_dgvMD5Villur.Dock = DockStyle.Bottom;
            m_dgvMD5Villur.Location = new Point(3, 105);
            m_dgvMD5Villur.Margin = new Padding(3, 4, 3, 4);
            m_dgvMD5Villur.Name = "m_dgvMD5Villur";
            m_dgvMD5Villur.ReadOnly = true;
            m_dgvMD5Villur.RowHeadersVisible = false;
            m_dgvMD5Villur.RowTemplate.Height = 25;
            m_dgvMD5Villur.Size = new Size(937, 88);
            m_dgvMD5Villur.TabIndex = 3;
            m_dgvMD5Villur.Visible = false;
            // 
            // colMD5skjal
            // 
            colMD5skjal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMD5skjal.DataPropertyName = "Skjal";
            colMD5skjal.HeaderText = "Skjal";
            colMD5skjal.Name = "colMD5skjal";
            colMD5skjal.ReadOnly = true;
            // 
            // colMD5Var
            // 
            colMD5Var.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMD5Var.DataPropertyName = "skrad";
            colMD5Var.HeaderText = "Gátsumma skráð";
            colMD5Var.Name = "colMD5Var";
            colMD5Var.ReadOnly = true;
            colMD5Var.Width = 115;
            // 
            // colMD5Er
            // 
            colMD5Er.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            colMD5Er.DataPropertyName = "er";
            colMD5Er.HeaderText = "Gátsuma er";
            colMD5Er.Name = "colMD5Er";
            colMD5Er.ReadOnly = true;
            colMD5Er.Width = 5;
            // 
            // m_lblTekkSuma
            // 
            m_lblTekkSuma.AutoSize = true;
            m_lblTekkSuma.Location = new Point(587, 40);
            m_lblTekkSuma.Name = "m_lblTekkSuma";
            m_lblTekkSuma.Size = new Size(40, 15);
            m_lblTekkSuma.TabIndex = 2;
            m_lblTekkSuma.Text = "label4";
            m_lblTekkSuma.Visible = false;
            // 
            // m_pgbTekksuma
            // 
            m_pgbTekksuma.Location = new Point(17, 29);
            m_pgbTekksuma.Margin = new Padding(3, 4, 3, 4);
            m_pgbTekksuma.Name = "m_pgbTekksuma";
            m_pgbTekksuma.Size = new Size(563, 31);
            m_pgbTekksuma.TabIndex = 1;
            m_pgbTekksuma.Visible = false;
            // 
            // m_pnlSIP
            // 
            m_pnlSIP.AllowDrop = true;
            m_pnlSIP.BackColor = Color.LightCyan;
            m_pnlSIP.BorderStyle = BorderStyle.FixedSingle;
            m_pnlSIP.Controls.Add(m_lblDragDrop);
            m_pnlSIP.Cursor = Cursors.Hand;
            m_pnlSIP.Dock = DockStyle.Top;
            m_pnlSIP.Location = new Point(0, 0);
            m_pnlSIP.Margin = new Padding(3, 4, 3, 4);
            m_pnlSIP.Name = "m_pnlSIP";
            m_pnlSIP.Size = new Size(943, 263);
            m_pnlSIP.TabIndex = 0;
            m_pnlSIP.DragEnter += m_pnlSIP_DragEnter;
            // 
            // m_lblDragDrop
            // 
            m_lblDragDrop.AutoSize = true;
            m_lblDragDrop.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            m_lblDragDrop.ForeColor = Color.ForestGreen;
            m_lblDragDrop.Location = new Point(37, 93);
            m_lblDragDrop.Name = "m_lblDragDrop";
            m_lblDragDrop.Size = new Size(485, 21);
            m_lblDragDrop.TabIndex = 0;
            m_lblDragDrop.Text = "Dragðu afhendingarútgáfu hingað eða ýttu hér til að fletta henni upp";
            m_lblDragDrop.Click += m_lblDragDrop_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.10574F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.89426F));
            tableLayoutPanel1.Controls.Add(m_grbISAAR, 1, 1);
            tableLayoutPanel1.Controls.Add(m_grbISASG, 1, 2);
            tableLayoutPanel1.Controls.Add(m_grbISDIAH, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 21.65493F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.68662F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 57.65845F));
            tableLayoutPanel1.Size = new Size(801, 1125);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // m_grbISAAR
            // 
            m_grbISAAR.Controls.Add(m_tboISAAR_auðkenni);
            m_grbISAAR.Controls.Add(m_lblISAAR_auðkenni);
            m_grbISAAR.Controls.Add(m_btnSkjalamyndariStadfesta);
            m_grbISAAR.Controls.Add(m_comISAAR_gerð);
            m_grbISAAR.Controls.Add(m_lblISAAR_gerð);
            m_grbISAAR.Controls.Add(m_comISAAR_nafn);
            m_grbISAAR.Controls.Add(m_lblISAAR_nafn_5_1_2);
            m_grbISAAR.Dock = DockStyle.Fill;
            m_grbISAAR.Enabled = false;
            m_grbISAAR.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            m_grbISAAR.Location = new Point(123, 247);
            m_grbISAAR.Margin = new Padding(3, 4, 3, 4);
            m_grbISAAR.Name = "m_grbISAAR";
            m_grbISAAR.Padding = new Padding(3, 4, 3, 4);
            m_grbISAAR.Size = new Size(675, 224);
            m_grbISAAR.TabIndex = 2;
            m_grbISAAR.TabStop = false;
            m_grbISAAR.Text = "2. Skjalamyndari";
            // 
            // m_tboISAAR_auðkenni
            // 
            m_tboISAAR_auðkenni.Enabled = false;
            m_tboISAAR_auðkenni.Location = new Point(168, 47);
            m_tboISAAR_auðkenni.Margin = new Padding(3, 4, 3, 4);
            m_tboISAAR_auðkenni.Name = "m_tboISAAR_auðkenni";
            m_tboISAAR_auðkenni.Size = new Size(230, 23);
            m_tboISAAR_auðkenni.TabIndex = 6;
            // 
            // m_lblISAAR_auðkenni
            // 
            m_lblISAAR_auðkenni.AutoSize = true;
            m_lblISAAR_auðkenni.Location = new Point(13, 51);
            m_lblISAAR_auðkenni.Name = "m_lblISAAR_auðkenni";
            m_lblISAAR_auðkenni.Size = new Size(93, 15);
            m_lblISAAR_auðkenni.TabIndex = 5;
            m_lblISAAR_auðkenni.Text = "Auðkenni 5.1.6.";
            // 
            // m_btnSkjalamyndariStadfesta
            // 
            m_btnSkjalamyndariStadfesta.Enabled = false;
            m_btnSkjalamyndariStadfesta.Location = new Point(521, 164);
            m_btnSkjalamyndariStadfesta.Margin = new Padding(3, 4, 3, 4);
            m_btnSkjalamyndariStadfesta.Name = "m_btnSkjalamyndariStadfesta";
            m_btnSkjalamyndariStadfesta.Size = new Size(86, 31);
            m_btnSkjalamyndariStadfesta.TabIndex = 4;
            m_btnSkjalamyndariStadfesta.Text = "Staðfesta";
            m_btnSkjalamyndariStadfesta.UseVisualStyleBackColor = true;
            m_btnSkjalamyndariStadfesta.Click += m_btnStadfesta_Click;
            // 
            // m_comISAAR_gerð
            // 
            m_comISAAR_gerð.FormattingEnabled = true;
            m_comISAAR_gerð.Location = new Point(168, 87);
            m_comISAAR_gerð.Margin = new Padding(3, 4, 3, 4);
            m_comISAAR_gerð.Name = "m_comISAAR_gerð";
            m_comISAAR_gerð.Size = new Size(334, 23);
            m_comISAAR_gerð.TabIndex = 3;
            m_comISAAR_gerð.SelectedIndexChanged += m_comISAAR_gerð_SelectedIndexChanged;
            // 
            // m_lblISAAR_gerð
            // 
            m_lblISAAR_gerð.AutoSize = true;
            m_lblISAAR_gerð.Location = new Point(10, 95);
            m_lblISAAR_gerð.Name = "m_lblISAAR_gerð";
            m_lblISAAR_gerð.Size = new Size(68, 15);
            m_lblISAAR_gerð.TabIndex = 2;
            m_lblISAAR_gerð.Text = "Gerð 5.1.1.";
            // 
            // m_comISAAR_nafn
            // 
            m_comISAAR_nafn.FormattingEnabled = true;
            m_comISAAR_nafn.Location = new Point(168, 132);
            m_comISAAR_nafn.Margin = new Padding(3, 4, 3, 4);
            m_comISAAR_nafn.Name = "m_comISAAR_nafn";
            m_comISAAR_nafn.Size = new Size(334, 23);
            m_comISAAR_nafn.TabIndex = 1;
            m_comISAAR_nafn.SelectedIndexChanged += m_comISAAR_nafn_SelectedIndexChanged;
            // 
            // m_lblISAAR_nafn_5_1_2
            // 
            m_lblISAAR_nafn_5_1_2.AutoSize = true;
            m_lblISAAR_nafn_5_1_2.Location = new Point(13, 140);
            m_lblISAAR_nafn_5_1_2.Name = "m_lblISAAR_nafn_5_1_2";
            m_lblISAAR_nafn_5_1_2.Size = new Size(118, 15);
            m_lblISAAR_nafn_5_1_2.TabIndex = 0;
            m_lblISAAR_nafn_5_1_2.Text = "Opinbert heiti 5.1.2.";
            // 
            // m_grbISASG
            // 
            m_grbISASG.Controls.Add(m_tboISADG_AFHNR);
            m_grbISASG.Controls.Add(m_lblISADG_AFHNR);
            m_grbISASG.Controls.Add(m_tboISADG_timabil);
            m_grbISASG.Controls.Add(label1);
            m_grbISASG.Controls.Add(m_btnSkraningStaðfesta);
            m_grbISASG.Controls.Add(m_comISADG_aðgengi);
            m_grbISASG.Controls.Add(m_lblISADG_aðgengi);
            m_grbISASG.Controls.Add(m_grbISADG_innihald);
            m_grbISASG.Controls.Add(m_tboISADG_titill);
            m_grbISASG.Controls.Add(m_lblISAAR_titill);
            m_grbISASG.Controls.Add(m_tboISADG_auðkenni);
            m_grbISASG.Controls.Add(m_lblISADG_Auðkenni);
            m_grbISASG.Dock = DockStyle.Fill;
            m_grbISASG.Enabled = false;
            m_grbISASG.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            m_grbISASG.Location = new Point(123, 479);
            m_grbISASG.Margin = new Padding(3, 4, 3, 4);
            m_grbISASG.Name = "m_grbISASG";
            m_grbISASG.Padding = new Padding(3, 4, 3, 4);
            m_grbISASG.Size = new Size(675, 642);
            m_grbISASG.TabIndex = 0;
            m_grbISASG.TabStop = false;
            m_grbISASG.Text = "3. Skjalaskrá";
            // 
            // m_tboISADG_AFHNR
            // 
            m_tboISADG_AFHNR.Location = new Point(183, 221);
            m_tboISADG_AFHNR.Margin = new Padding(3, 4, 3, 4);
            m_tboISADG_AFHNR.Name = "m_tboISADG_AFHNR";
            m_tboISADG_AFHNR.Size = new Size(229, 23);
            m_tboISADG_AFHNR.TabIndex = 11;
            // 
            // m_lblISADG_AFHNR
            // 
            m_lblISADG_AFHNR.AutoSize = true;
            m_lblISADG_AFHNR.Location = new Point(27, 225);
            m_lblISADG_AFHNR.Name = "m_lblISADG_AFHNR";
            m_lblISADG_AFHNR.Size = new Size(129, 15);
            m_lblISADG_AFHNR.TabIndex = 10;
            m_lblISADG_AFHNR.Text = "Afhendingaár/nr 3.2.4";
            // 
            // m_tboISADG_timabil
            // 
            m_tboISADG_timabil.Location = new Point(178, 31);
            m_tboISADG_timabil.Margin = new Padding(3, 4, 3, 4);
            m_tboISADG_timabil.Name = "m_tboISADG_timabil";
            m_tboISADG_timabil.Size = new Size(286, 23);
            m_tboISADG_timabil.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 35);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 8;
            label1.Text = "Tímabil 3.1.3";
            // 
            // m_btnSkraningStaðfesta
            // 
            m_btnSkraningStaðfesta.Enabled = false;
            m_btnSkraningStaðfesta.Location = new Point(560, 459);
            m_btnSkraningStaðfesta.Margin = new Padding(3, 4, 3, 4);
            m_btnSkraningStaðfesta.Name = "m_btnSkraningStaðfesta";
            m_btnSkraningStaðfesta.Size = new Size(86, 31);
            m_btnSkraningStaðfesta.TabIndex = 7;
            m_btnSkraningStaðfesta.Text = "Staðfesta";
            m_btnSkraningStaðfesta.UseVisualStyleBackColor = true;
            m_btnSkraningStaðfesta.Click += m_btnSkraningStaðfesta_Click;
            // 
            // m_comISADG_aðgengi
            // 
            m_comISADG_aðgengi.FormattingEnabled = true;
            m_comISADG_aðgengi.Location = new Point(182, 76);
            m_comISADG_aðgengi.Margin = new Padding(3, 4, 3, 4);
            m_comISADG_aðgengi.Name = "m_comISADG_aðgengi";
            m_comISADG_aðgengi.Size = new Size(230, 23);
            m_comISADG_aðgengi.TabIndex = 6;
            m_comISADG_aðgengi.SelectedIndexChanged += m_comISADG_aðgengi_SelectedIndexChanged;
            // 
            // m_lblISADG_aðgengi
            // 
            m_lblISADG_aðgengi.AutoSize = true;
            m_lblISADG_aðgengi.Location = new Point(21, 80);
            m_lblISADG_aðgengi.Name = "m_lblISADG_aðgengi";
            m_lblISADG_aðgengi.Size = new Size(128, 15);
            m_lblISADG_aðgengi.TabIndex = 5;
            m_lblISADG_aðgengi.Text = "Skilyrði aðgengi 3.4.1.";
            // 
            // m_grbISADG_innihald
            // 
            m_grbISADG_innihald.Controls.Add(m_tboISADG_innihald);
            m_grbISADG_innihald.Location = new Point(7, 260);
            m_grbISADG_innihald.Margin = new Padding(3, 4, 3, 4);
            m_grbISADG_innihald.Name = "m_grbISADG_innihald";
            m_grbISADG_innihald.Padding = new Padding(3, 4, 3, 4);
            m_grbISADG_innihald.Size = new Size(642, 190);
            m_grbISADG_innihald.TabIndex = 6;
            m_grbISADG_innihald.TabStop = false;
            m_grbISADG_innihald.Text = "Yfirlit/innhald 3.3.1.";
            // 
            // m_tboISADG_innihald
            // 
            m_tboISADG_innihald.Dock = DockStyle.Fill;
            m_tboISADG_innihald.Location = new Point(3, 20);
            m_tboISADG_innihald.Margin = new Padding(3, 4, 3, 4);
            m_tboISADG_innihald.Multiline = true;
            m_tboISADG_innihald.Name = "m_tboISADG_innihald";
            m_tboISADG_innihald.Size = new Size(636, 166);
            m_tboISADG_innihald.TabIndex = 4;
            // 
            // m_tboISADG_titill
            // 
            m_tboISADG_titill.Location = new Point(182, 163);
            m_tboISADG_titill.Margin = new Padding(3, 4, 3, 4);
            m_tboISADG_titill.Name = "m_tboISADG_titill";
            m_tboISADG_titill.Size = new Size(444, 23);
            m_tboISADG_titill.TabIndex = 3;
            // 
            // m_lblISAAR_titill
            // 
            m_lblISAAR_titill.AutoSize = true;
            m_lblISAAR_titill.Location = new Point(26, 167);
            m_lblISAAR_titill.Name = "m_lblISAAR_titill";
            m_lblISAAR_titill.Size = new Size(64, 15);
            m_lblISAAR_titill.TabIndex = 2;
            m_lblISAAR_titill.Text = "Titill 3.1.2.";
            // 
            // m_tboISADG_auðkenni
            // 
            m_tboISADG_auðkenni.Enabled = false;
            m_tboISADG_auðkenni.Location = new Point(182, 115);
            m_tboISADG_auðkenni.Margin = new Padding(3, 4, 3, 4);
            m_tboISADG_auðkenni.Name = "m_tboISADG_auðkenni";
            m_tboISADG_auðkenni.Size = new Size(230, 23);
            m_tboISADG_auðkenni.TabIndex = 1;
            // 
            // m_lblISADG_Auðkenni
            // 
            m_lblISADG_Auðkenni.AutoSize = true;
            m_lblISADG_Auðkenni.Location = new Point(26, 119);
            m_lblISADG_Auðkenni.Name = "m_lblISADG_Auðkenni";
            m_lblISADG_Auðkenni.Size = new Size(93, 15);
            m_lblISADG_Auðkenni.TabIndex = 0;
            m_lblISADG_Auðkenni.Text = "Auðkenni 3.1.1.";
            // 
            // m_grbISDIAH
            // 
            m_grbISDIAH.Controls.Add(m_lblISDIAH_klasi);
            m_grbISDIAH.Controls.Add(m_comISDIAH_klasi);
            m_grbISDIAH.Controls.Add(m_lblHeitVarslaVantar);
            m_grbISDIAH.Controls.Add(m_btnVörslustofnunStaðfesta);
            m_grbISDIAH.Controls.Add(m_tboISDIAH_obinbert_heiti);
            m_grbISDIAH.Controls.Add(m_lblISDIAH_Obinbert_heiti);
            m_grbISDIAH.Controls.Add(m_tboISDIAH_auðkenni);
            m_grbISDIAH.Controls.Add(m_lblISDIAH_auðkenni);
            m_grbISDIAH.Dock = DockStyle.Fill;
            m_grbISDIAH.Enabled = false;
            m_grbISDIAH.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            m_grbISDIAH.Location = new Point(123, 4);
            m_grbISDIAH.Margin = new Padding(3, 4, 3, 4);
            m_grbISDIAH.Name = "m_grbISDIAH";
            m_grbISDIAH.Padding = new Padding(3, 4, 3, 4);
            m_grbISDIAH.Size = new Size(675, 235);
            m_grbISDIAH.TabIndex = 1;
            m_grbISDIAH.TabStop = false;
            m_grbISDIAH.Text = "1. Vörslustofnun";
            // 
            // m_lblISDIAH_klasi
            // 
            m_lblISDIAH_klasi.AutoSize = true;
            m_lblISDIAH_klasi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblISDIAH_klasi.Location = new Point(26, 40);
            m_lblISDIAH_klasi.Name = "m_lblISDIAH_klasi";
            m_lblISDIAH_klasi.Size = new Size(100, 15);
            m_lblISDIAH_klasi.TabIndex = 11;
            m_lblISDIAH_klasi.Text = "Landsvæði (klasi)";
            // 
            // m_comISDIAH_klasi
            // 
            m_comISDIAH_klasi.FormattingEnabled = true;
            m_comISDIAH_klasi.Location = new Point(165, 36);
            m_comISDIAH_klasi.Margin = new Padding(3, 4, 3, 4);
            m_comISDIAH_klasi.Name = "m_comISDIAH_klasi";
            m_comISDIAH_klasi.Size = new Size(338, 23);
            m_comISDIAH_klasi.TabIndex = 10;
            m_comISDIAH_klasi.SelectedIndexChanged += m_comISDIAH_klasi_SelectedIndexChanged;
            // 
            // m_lblHeitVarslaVantar
            // 
            m_lblHeitVarslaVantar.AutoSize = true;
            m_lblHeitVarslaVantar.ForeColor = Color.IndianRed;
            m_lblHeitVarslaVantar.Location = new Point(178, 166);
            m_lblHeitVarslaVantar.Name = "m_lblHeitVarslaVantar";
            m_lblHeitVarslaVantar.Size = new Size(244, 15);
            m_lblHeitVarslaVantar.TabIndex = 9;
            m_lblHeitVarslaVantar.Text = "Vinsamlegast skráðu heiti  vörslustofnunar.";
            m_lblHeitVarslaVantar.Visible = false;
            // 
            // m_btnVörslustofnunStaðfesta
            // 
            m_btnVörslustofnunStaðfesta.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            m_btnVörslustofnunStaðfesta.Location = new Point(508, 150);
            m_btnVörslustofnunStaðfesta.Margin = new Padding(3, 4, 3, 4);
            m_btnVörslustofnunStaðfesta.Name = "m_btnVörslustofnunStaðfesta";
            m_btnVörslustofnunStaðfesta.Size = new Size(86, 31);
            m_btnVörslustofnunStaðfesta.TabIndex = 8;
            m_btnVörslustofnunStaðfesta.Text = "Staðfesta";
            m_btnVörslustofnunStaðfesta.UseVisualStyleBackColor = true;
            m_btnVörslustofnunStaðfesta.Click += m_btnVörslustofnunStaðfesta_Click;
            // 
            // m_tboISDIAH_obinbert_heiti
            // 
            m_tboISDIAH_obinbert_heiti.Location = new Point(165, 108);
            m_tboISDIAH_obinbert_heiti.Margin = new Padding(3, 4, 3, 4);
            m_tboISDIAH_obinbert_heiti.Name = "m_tboISDIAH_obinbert_heiti";
            m_tboISDIAH_obinbert_heiti.Size = new Size(334, 23);
            m_tboISDIAH_obinbert_heiti.TabIndex = 3;
            m_tboISDIAH_obinbert_heiti.TextChanged += m_tboISDIAH_obinbert_heiti_TextChanged;
            // 
            // m_lblISDIAH_Obinbert_heiti
            // 
            m_lblISDIAH_Obinbert_heiti.AutoSize = true;
            m_lblISDIAH_Obinbert_heiti.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblISDIAH_Obinbert_heiti.Location = new Point(26, 116);
            m_lblISDIAH_Obinbert_heiti.Name = "m_lblISDIAH_Obinbert_heiti";
            m_lblISDIAH_Obinbert_heiti.Size = new Size(118, 15);
            m_lblISDIAH_Obinbert_heiti.TabIndex = 2;
            m_lblISDIAH_Obinbert_heiti.Text = "Opinbert heiti 5.1.2.";
            // 
            // m_tboISDIAH_auðkenni
            // 
            m_tboISDIAH_auðkenni.Enabled = false;
            m_tboISDIAH_auðkenni.Location = new Point(165, 67);
            m_tboISDIAH_auðkenni.Margin = new Padding(3, 4, 3, 4);
            m_tboISDIAH_auðkenni.Name = "m_tboISDIAH_auðkenni";
            m_tboISDIAH_auðkenni.Size = new Size(334, 23);
            m_tboISDIAH_auðkenni.TabIndex = 1;
            // 
            // m_lblISDIAH_auðkenni
            // 
            m_lblISDIAH_auðkenni.AutoSize = true;
            m_lblISDIAH_auðkenni.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblISDIAH_auðkenni.Location = new Point(27, 75);
            m_lblISDIAH_auðkenni.Name = "m_lblISDIAH_auðkenni";
            m_lblISDIAH_auðkenni.Size = new Size(93, 15);
            m_lblISDIAH_auðkenni.TabIndex = 0;
            m_lblISDIAH_auðkenni.Text = "Auðkenni 5.1.1.";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // uscInnSetning
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uscInnSetning";
            Size = new Size(1757, 1129);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            m_grbSkyrsla.ResumeLayout(false);
            m_grbFlytjaSIP.ResumeLayout(false);
            m_grbFRUM.ResumeLayout(false);
            m_grbFRUM.PerformLayout();
            m_grbAvid.ResumeLayout(false);
            m_grbAvid.PerformLayout();
            m_grbTekksuma.ResumeLayout(false);
            m_grbTekksuma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvMD5Villur).EndInit();
            m_pnlSIP.ResumeLayout(false);
            m_pnlSIP.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            m_grbISAAR.ResumeLayout(false);
            m_grbISAAR.PerformLayout();
            m_grbISASG.ResumeLayout(false);
            m_grbISASG.PerformLayout();
            m_grbISADG_innihald.ResumeLayout(false);
            m_grbISADG_innihald.PerformLayout();
            m_grbISDIAH.ResumeLayout(false);
            m_grbISDIAH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel m_pnlSIP;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox m_grbISASG;
        private TextBox m_tboISADG_auðkenni;
        private Label m_lblISADG_Auðkenni;
        private GroupBox m_grbISAAR;
        private Label m_lblISAAR_nafn_5_1_2;
        private GroupBox m_grbISDIAH;
        private TextBox m_tboISDIAH_auðkenni;
        private Label m_lblISDIAH_auðkenni;
        private Label m_lblDragDrop;
        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox m_grbTekksuma;
        private Label m_lblTekkSuma;
        private ProgressBar m_pgbTekksuma;
        private ComboBox m_comISAAR_nafn;
        private TextBox m_tboISADG_titill;
        private Label m_lblISAAR_titill;
        private GroupBox m_grbISADG_innihald;
        private TextBox m_tboISADG_innihald;
        private ComboBox m_comISAAR_gerð;
        private Label m_lblISAAR_gerð;
        private TextBox m_tboISDIAH_obinbert_heiti;
        private Label m_lblISDIAH_Obinbert_heiti;
        private Button m_btnSkjalamyndariStadfesta;
        private TextBox m_tboISAAR_auðkenni;
        private Label m_lblISAAR_auðkenni;
        private ComboBox m_comISADG_aðgengi;
        private Label m_lblISADG_aðgengi;
        private Button m_btnSkraningStaðfesta;
        private Button m_btnVörslustofnunStaðfesta;
        private Label m_lblHeitVarslaVantar;
        private DataGridView m_dgvMD5Villur;
        private DataGridViewTextBoxColumn colMD5skjal;
        private DataGridViewTextBoxColumn colMD5Var;
        private DataGridViewTextBoxColumn colMD5Er;
        private ErrorProvider errorProvider1;
        private TextBox m_tboISADG_timabil;
        private Label label1;
        private GroupBox m_grbFlytjaSIP;
        private Button m_btnFlytjaSIP;
        private GroupBox m_grbSkyrsla;
        private Button m_btnKvittun;
        private TextBox m_tboISADG_AFHNR;
        private Label m_lblISADG_AFHNR;
        private ProgressBar m_prbAVID;
        private Label m_lblFilesAPI;
        private Label m_lblStatusAPI;
        private Label m_lblStatusFRUM;
        private Label m_lblFileFRUM;
        private ProgressBar m_prbFRUM;
        private GroupBox m_grbAvid;
        private GroupBox m_grbFRUM;
        private Label m_lblISDIAH_klasi;
        private ComboBox m_comISDIAH_klasi;
    }
}
