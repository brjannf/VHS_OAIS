namespace MHR_LEIT
{
    partial class frmGagnagrunnur
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            m_dgvFyrirspurnir = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colNafn = new DataGridViewTextBoxColumn();
            colLysing = new DataGridViewTextBoxColumn();
            colFyrirspurn = new DataGridViewTextBoxColumn();
            colGagnagrunnur = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            m_btnLjukaPontun = new Button();
            m_btnSetjaIkorfu = new Button();
            m_grbPontun = new GroupBox();
            m_tacPantanir = new TabControl();
            m_tapGagnagrunnar = new TabPage();
            m_dgvPantGagnagrunnar = new DataGridView();
            colGagnHeit = new DataGridViewTextBoxColumn();
            colLeitSkilyrdi = new DataGridViewTextBoxColumn();
            colHeitiVarsla = new DataGridViewTextBoxColumn();
            colGagnOpna = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colGagnSQL = new DataGridViewTextBoxColumn();
            m_tapSkráarkerfi = new TabPage();
            m_dgvPantSkraarkerfi = new DataGridView();
            colSkraID = new DataGridViewTextBoxColumn();
            colSkraTitill = new DataGridViewTextBoxColumn();
            colSkraheitiVorslu = new DataGridViewTextBoxColumn();
            colSkraOpna = new DataGridViewButtonColumn();
            colSkraDelete = new DataGridViewButtonColumn();
            colSkraVarslaID = new DataGridViewTextBoxColumn();
            m_tapMalakrefi = new TabPage();
            m_dgvPantMalaKerfi = new DataGridView();
            m_grbNidurstodur = new GroupBox();
            m_dgvNidurstodur = new DataGridView();
            colMalSkraID = new DataGridViewTextBoxColumn();
            colMalTitillSkjals = new DataGridViewTextBoxColumn();
            colMalTitillMals = new DataGridViewTextBoxColumn();
            colMalHeitiVorslu = new DataGridViewTextBoxColumn();
            colMalOpna = new DataGridViewButtonColumn();
            colMalDelete = new DataGridViewButtonColumn();
            colMalSlod = new DataGridViewTextBoxColumn();
            colMalGagnagrunnur = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)m_dgvFyrirspurnir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            m_grbPontun.SuspendLayout();
            m_tacPantanir.SuspendLayout();
            m_tapGagnagrunnar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvPantGagnagrunnar).BeginInit();
            m_tapSkráarkerfi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvPantSkraarkerfi).BeginInit();
            m_tapMalakrefi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvPantMalaKerfi).BeginInit();
            m_grbNidurstodur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvNidurstodur).BeginInit();
            SuspendLayout();
            // 
            // m_dgvFyrirspurnir
            // 
            m_dgvFyrirspurnir.AllowUserToAddRows = false;
            m_dgvFyrirspurnir.AllowUserToDeleteRows = false;
            m_dgvFyrirspurnir.AllowUserToOrderColumns = true;
            m_dgvFyrirspurnir.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvFyrirspurnir.Columns.AddRange(new DataGridViewColumn[] { colID, colNafn, colLysing, colFyrirspurn, colGagnagrunnur });
            m_dgvFyrirspurnir.Dock = DockStyle.Fill;
            m_dgvFyrirspurnir.Location = new Point(0, 0);
            m_dgvFyrirspurnir.Name = "m_dgvFyrirspurnir";
            m_dgvFyrirspurnir.RowHeadersVisible = false;
            m_dgvFyrirspurnir.RowTemplate.Height = 25;
            m_dgvFyrirspurnir.Size = new Size(924, 184);
            m_dgvFyrirspurnir.TabIndex = 0;
            // 
            // colID
            // 
            colID.DataPropertyName = "id";
            colID.HeaderText = "ID";
            colID.Name = "colID";
            colID.Visible = false;
            // 
            // colNafn
            // 
            colNafn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colNafn.DataPropertyName = "nafn";
            colNafn.HeaderText = "Titill fyrirspurnar";
            colNafn.Name = "colNafn";
            colNafn.Width = 108;
            // 
            // colLysing
            // 
            colLysing.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLysing.DataPropertyName = "lysing";
            colLysing.HeaderText = "Lýsing fyrirspurnar";
            colLysing.Name = "colLysing";
            // 
            // colFyrirspurn
            // 
            colFyrirspurn.DataPropertyName = "fyrirspurn";
            colFyrirspurn.HeaderText = "Fyrirspurn";
            colFyrirspurn.Name = "colFyrirspurn";
            colFyrirspurn.Visible = false;
            // 
            // colGagnagrunnur
            // 
            colGagnagrunnur.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGagnagrunnur.DataPropertyName = "gagnagrunnur";
            colGagnagrunnur.HeaderText = "Gagnagrunnur";
            colGagnagrunnur.Name = "colGagnagrunnur";
            colGagnagrunnur.Visible = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.Controls.Add(m_grbNidurstodur);
            splitContainer1.Size = new Size(1364, 577);
            splitContainer1.SplitterDistance = 287;
            splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(m_grbPontun);
            splitContainer2.Size = new Size(1364, 287);
            splitContainer2.SplitterDistance = 924;
            splitContainer2.TabIndex = 1;
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
            splitContainer3.Panel1.Controls.Add(m_dgvFyrirspurnir);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(m_btnLjukaPontun);
            splitContainer3.Panel2.Controls.Add(m_btnSetjaIkorfu);
            splitContainer3.Size = new Size(924, 287);
            splitContainer3.SplitterDistance = 184;
            splitContainer3.TabIndex = 1;
            // 
            // m_btnLjukaPontun
            // 
            m_btnLjukaPontun.Location = new Point(724, 53);
            m_btnLjukaPontun.Name = "m_btnLjukaPontun";
            m_btnLjukaPontun.Size = new Size(147, 23);
            m_btnLjukaPontun.TabIndex = 1;
            m_btnLjukaPontun.Text = "Ljúka pöntun";
            m_btnLjukaPontun.UseVisualStyleBackColor = true;
            m_btnLjukaPontun.Visible = false;
            m_btnLjukaPontun.Click += m_btnLjukaPontun_Click;
            // 
            // m_btnSetjaIkorfu
            // 
            m_btnSetjaIkorfu.Location = new Point(724, 13);
            m_btnSetjaIkorfu.Name = "m_btnSetjaIkorfu";
            m_btnSetjaIkorfu.Size = new Size(147, 23);
            m_btnSetjaIkorfu.TabIndex = 0;
            m_btnSetjaIkorfu.Text = "Setja í körfu";
            m_btnSetjaIkorfu.UseVisualStyleBackColor = true;
            m_btnSetjaIkorfu.Click += m_btnSetjaIkorfu_Click;
            // 
            // m_grbPontun
            // 
            m_grbPontun.Controls.Add(m_tacPantanir);
            m_grbPontun.Dock = DockStyle.Fill;
            m_grbPontun.Location = new Point(0, 0);
            m_grbPontun.Name = "m_grbPontun";
            m_grbPontun.Size = new Size(436, 287);
            m_grbPontun.TabIndex = 2;
            m_grbPontun.TabStop = false;
            m_grbPontun.Text = "Gögn óafgreitt";
            // 
            // m_tacPantanir
            // 
            m_tacPantanir.Controls.Add(m_tapGagnagrunnar);
            m_tacPantanir.Controls.Add(m_tapSkráarkerfi);
            m_tacPantanir.Controls.Add(m_tapMalakrefi);
            m_tacPantanir.Dock = DockStyle.Fill;
            m_tacPantanir.Location = new Point(3, 19);
            m_tacPantanir.Name = "m_tacPantanir";
            m_tacPantanir.SelectedIndex = 0;
            m_tacPantanir.Size = new Size(430, 265);
            m_tacPantanir.TabIndex = 1;
            // 
            // m_tapGagnagrunnar
            // 
            m_tapGagnagrunnar.Controls.Add(m_dgvPantGagnagrunnar);
            m_tapGagnagrunnar.Location = new Point(4, 24);
            m_tapGagnagrunnar.Name = "m_tapGagnagrunnar";
            m_tapGagnagrunnar.Padding = new Padding(3);
            m_tapGagnagrunnar.Size = new Size(422, 237);
            m_tapGagnagrunnar.TabIndex = 0;
            m_tapGagnagrunnar.Text = "Gagnagrunnar";
            m_tapGagnagrunnar.UseVisualStyleBackColor = true;
            // 
            // m_dgvPantGagnagrunnar
            // 
            m_dgvPantGagnagrunnar.AllowUserToAddRows = false;
            m_dgvPantGagnagrunnar.AllowUserToDeleteRows = false;
            m_dgvPantGagnagrunnar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvPantGagnagrunnar.Columns.AddRange(new DataGridViewColumn[] { colGagnHeit, colLeitSkilyrdi, colHeitiVarsla, colGagnOpna, colDelete, colGagnSQL });
            m_dgvPantGagnagrunnar.Dock = DockStyle.Fill;
            m_dgvPantGagnagrunnar.Location = new Point(3, 3);
            m_dgvPantGagnagrunnar.Name = "m_dgvPantGagnagrunnar";
            m_dgvPantGagnagrunnar.ReadOnly = true;
            m_dgvPantGagnagrunnar.RowHeadersVisible = false;
            m_dgvPantGagnagrunnar.RowTemplate.Height = 25;
            m_dgvPantGagnagrunnar.Size = new Size(416, 231);
            m_dgvPantGagnagrunnar.TabIndex = 0;
            m_dgvPantGagnagrunnar.CellClick += m_dgvPantGagnagrunnar_CellClick;
            // 
            // colGagnHeit
            // 
            colGagnHeit.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGagnHeit.DataPropertyName = "heiti";
            colGagnHeit.HeaderText = "Heiti gagnagrunns";
            colGagnHeit.Name = "colGagnHeit";
            colGagnHeit.ReadOnly = true;
            colGagnHeit.Width = 119;
            // 
            // colLeitSkilyrdi
            // 
            colLeitSkilyrdi.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colLeitSkilyrdi.DataPropertyName = "leitarskilyrdi";
            colLeitSkilyrdi.HeaderText = "Leitarskilyrði";
            colLeitSkilyrdi.Name = "colLeitSkilyrdi";
            colLeitSkilyrdi.ReadOnly = true;
            colLeitSkilyrdi.Visible = false;
            // 
            // colHeitiVarsla
            // 
            colHeitiVarsla.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHeitiVarsla.DataPropertyName = "heitivorslu";
            colHeitiVarsla.HeaderText = "Heiti vörsluúgáfu";
            colHeitiVarsla.Name = "colHeitiVarsla";
            colHeitiVarsla.ReadOnly = true;
            // 
            // colGagnOpna
            // 
            colGagnOpna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colGagnOpna.HeaderText = "Opna";
            colGagnOpna.Name = "colGagnOpna";
            colGagnOpna.ReadOnly = true;
            colGagnOpna.Text = "Opna";
            colGagnOpna.ToolTipText = "Opna skrá";
            colGagnOpna.UseColumnTextForButtonValue = true;
            colGagnOpna.Width = 42;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Fjarlægja";
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Resizable = DataGridViewTriState.True;
            colDelete.SortMode = DataGridViewColumnSortMode.Automatic;
            colDelete.Text = "Fjarlægja";
            colDelete.ToolTipText = "Fjarlægja færslu úr pöntun";
            colDelete.UseColumnTextForButtonValue = true;
            // 
            // colGagnSQL
            // 
            colGagnSQL.DataPropertyName = "sql";
            colGagnSQL.HeaderText = "sql";
            colGagnSQL.Name = "colGagnSQL";
            colGagnSQL.ReadOnly = true;
            colGagnSQL.Visible = false;
            // 
            // m_tapSkráarkerfi
            // 
            m_tapSkráarkerfi.Controls.Add(m_dgvPantSkraarkerfi);
            m_tapSkráarkerfi.Location = new Point(4, 24);
            m_tapSkráarkerfi.Name = "m_tapSkráarkerfi";
            m_tapSkráarkerfi.Padding = new Padding(3);
            m_tapSkráarkerfi.Size = new Size(422, 237);
            m_tapSkráarkerfi.TabIndex = 1;
            m_tapSkráarkerfi.Text = "Skráarkerfi";
            m_tapSkráarkerfi.UseVisualStyleBackColor = true;
            // 
            // m_dgvPantSkraarkerfi
            // 
            m_dgvPantSkraarkerfi.AllowUserToAddRows = false;
            m_dgvPantSkraarkerfi.AllowUserToDeleteRows = false;
            m_dgvPantSkraarkerfi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvPantSkraarkerfi.Columns.AddRange(new DataGridViewColumn[] { colSkraID, colSkraTitill, colSkraheitiVorslu, colSkraOpna, colSkraDelete, colSkraVarslaID });
            m_dgvPantSkraarkerfi.Dock = DockStyle.Fill;
            m_dgvPantSkraarkerfi.Location = new Point(3, 3);
            m_dgvPantSkraarkerfi.Name = "m_dgvPantSkraarkerfi";
            m_dgvPantSkraarkerfi.ReadOnly = true;
            m_dgvPantSkraarkerfi.RowHeadersVisible = false;
            m_dgvPantSkraarkerfi.RowTemplate.Height = 25;
            m_dgvPantSkraarkerfi.Size = new Size(416, 231);
            m_dgvPantSkraarkerfi.TabIndex = 0;
            m_dgvPantSkraarkerfi.CellClick += m_dgvPantGagnagrunnar_CellClick;
            // 
            // colSkraID
            // 
            colSkraID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colSkraID.DataPropertyName = "skjalID";
            colSkraID.HeaderText = "Auðkenni skjals";
            colSkraID.Name = "colSkraID";
            colSkraID.ReadOnly = true;
            colSkraID.Width = 105;
            // 
            // colSkraTitill
            // 
            colSkraTitill.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSkraTitill.DataPropertyName = "titill";
            colSkraTitill.HeaderText = "Titill skjals";
            colSkraTitill.Name = "colSkraTitill";
            colSkraTitill.ReadOnly = true;
            // 
            // colSkraheitiVorslu
            // 
            colSkraheitiVorslu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colSkraheitiVorslu.DataPropertyName = "heitiVorslu";
            colSkraheitiVorslu.HeaderText = "Heiti vörsluútgáfu";
            colSkraheitiVorslu.Name = "colSkraheitiVorslu";
            colSkraheitiVorslu.ReadOnly = true;
            colSkraheitiVorslu.Width = 116;
            // 
            // colSkraOpna
            // 
            colSkraOpna.HeaderText = "Opna";
            colSkraOpna.Name = "colSkraOpna";
            colSkraOpna.ReadOnly = true;
            colSkraOpna.Text = "Opna";
            colSkraOpna.ToolTipText = "Opna skrá";
            colSkraOpna.UseColumnTextForButtonValue = true;
            // 
            // colSkraDelete
            // 
            colSkraDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colSkraDelete.HeaderText = "Fjarlægja";
            colSkraDelete.Name = "colSkraDelete";
            colSkraDelete.ReadOnly = true;
            colSkraDelete.Text = "Fjarlægja";
            colSkraDelete.ToolTipText = "Fjarlægja pöntun";
            colSkraDelete.UseColumnTextForButtonValue = true;
            colSkraDelete.Width = 61;
            // 
            // colSkraVarslaID
            // 
            colSkraVarslaID.DataPropertyName = "vorsluutgafa";
            colSkraVarslaID.HeaderText = "vörsluauðkenni";
            colSkraVarslaID.Name = "colSkraVarslaID";
            colSkraVarslaID.ReadOnly = true;
            colSkraVarslaID.Visible = false;
            // 
            // m_tapMalakrefi
            // 
            m_tapMalakrefi.Controls.Add(m_dgvPantMalaKerfi);
            m_tapMalakrefi.Location = new Point(4, 24);
            m_tapMalakrefi.Name = "m_tapMalakrefi";
            m_tapMalakrefi.Padding = new Padding(3);
            m_tapMalakrefi.Size = new Size(422, 237);
            m_tapMalakrefi.TabIndex = 2;
            m_tapMalakrefi.Text = "Málakerfi";
            m_tapMalakrefi.UseVisualStyleBackColor = true;
            // 
            // m_dgvPantMalaKerfi
            // 
            m_dgvPantMalaKerfi.AllowUserToAddRows = false;
            m_dgvPantMalaKerfi.AllowUserToDeleteRows = false;
            m_dgvPantMalaKerfi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvPantMalaKerfi.Columns.AddRange(new DataGridViewColumn[] { colMalSkraID, colMalTitillSkjals, colMalTitillMals, colMalHeitiVorslu, colMalOpna, colMalDelete, colMalSlod, colMalGagnagrunnur });
            m_dgvPantMalaKerfi.Dock = DockStyle.Fill;
            m_dgvPantMalaKerfi.Location = new Point(3, 3);
            m_dgvPantMalaKerfi.Name = "m_dgvPantMalaKerfi";
            m_dgvPantMalaKerfi.ReadOnly = true;
            m_dgvPantMalaKerfi.RowHeadersVisible = false;
            m_dgvPantMalaKerfi.RowTemplate.Height = 25;
            m_dgvPantMalaKerfi.Size = new Size(416, 231);
            m_dgvPantMalaKerfi.TabIndex = 0;
            m_dgvPantMalaKerfi.CellClick += m_dgvPantGagnagrunnar_CellClick;
            // 
            // m_grbNidurstodur
            // 
            m_grbNidurstodur.Controls.Add(m_dgvNidurstodur);
            m_grbNidurstodur.Dock = DockStyle.Fill;
            m_grbNidurstodur.Location = new Point(0, 0);
            m_grbNidurstodur.Name = "m_grbNidurstodur";
            m_grbNidurstodur.Size = new Size(1364, 286);
            m_grbNidurstodur.TabIndex = 1;
            m_grbNidurstodur.TabStop = false;
            m_grbNidurstodur.Text = "Niðurstöður";
            // 
            // m_dgvNidurstodur
            // 
            m_dgvNidurstodur.AllowUserToAddRows = false;
            m_dgvNidurstodur.AllowUserToDeleteRows = false;
            m_dgvNidurstodur.AllowUserToOrderColumns = true;
            m_dgvNidurstodur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvNidurstodur.Dock = DockStyle.Fill;
            m_dgvNidurstodur.Location = new Point(3, 19);
            m_dgvNidurstodur.Name = "m_dgvNidurstodur";
            m_dgvNidurstodur.ReadOnly = true;
            m_dgvNidurstodur.RowHeadersVisible = false;
            m_dgvNidurstodur.RowTemplate.Height = 25;
            m_dgvNidurstodur.Size = new Size(1358, 264);
            m_dgvNidurstodur.TabIndex = 0;
            m_dgvNidurstodur.CellContentClick += keyrafyrirspurn_CellClick;
            // 
            // colMalSkraID
            // 
            colMalSkraID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalSkraID.DataPropertyName = "documentid";
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            colMalSkraID.DefaultCellStyle = dataGridViewCellStyle1;
            colMalSkraID.HeaderText = "Auðkenni skjals";
            colMalSkraID.Name = "colMalSkraID";
            colMalSkraID.ReadOnly = true;
            colMalSkraID.Width = 114;
            // 
            // colMalTitillSkjals
            // 
            colMalTitillSkjals.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMalTitillSkjals.DataPropertyName = "titill";
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            colMalTitillSkjals.DefaultCellStyle = dataGridViewCellStyle2;
            colMalTitillSkjals.HeaderText = "Titill skjals";
            colMalTitillSkjals.Name = "colMalTitillSkjals";
            colMalTitillSkjals.ReadOnly = true;
            // 
            // colMalTitillMals
            // 
            colMalTitillMals.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalTitillMals.DataPropertyName = "maltitill";
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            colMalTitillMals.DefaultCellStyle = dataGridViewCellStyle3;
            colMalTitillMals.HeaderText = "Titill máls";
            colMalTitillMals.Name = "colMalTitillMals";
            colMalTitillMals.ReadOnly = true;
            colMalTitillMals.Width = 82;
            // 
            // colMalHeitiVorslu
            // 
            colMalHeitiVorslu.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalHeitiVorslu.DataPropertyName = "heitivorslu";
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            colMalHeitiVorslu.DefaultCellStyle = dataGridViewCellStyle4;
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
            colMalOpna.Text = "Opna";
            colMalOpna.ToolTipText = "Opna skrá";
            colMalOpna.UseColumnTextForButtonValue = true;
            colMalOpna.Width = 42;
            // 
            // colMalDelete
            // 
            colMalDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colMalDelete.HeaderText = "Fjarlægja";
            colMalDelete.Name = "colMalDelete";
            colMalDelete.ReadOnly = true;
            colMalDelete.Text = "Fjarlægja";
            colMalDelete.ToolTipText = "Fjarlægja pöntun";
            colMalDelete.UseColumnTextForButtonValue = true;
            colMalDelete.Width = 61;
            // 
            // colMalSlod
            // 
            colMalSlod.DataPropertyName = "slod";
            colMalSlod.HeaderText = "Sláð á skrá";
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
            // frmGagnagrunnur
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1364, 577);
            Controls.Add(splitContainer1);
            Name = "frmGagnagrunnur";
            Text = "frmGagnagrunnur";
            ((System.ComponentModel.ISupportInitialize)m_dgvFyrirspurnir).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            m_grbPontun.ResumeLayout(false);
            m_tacPantanir.ResumeLayout(false);
            m_tapGagnagrunnar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvPantGagnagrunnar).EndInit();
            m_tapSkráarkerfi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvPantSkraarkerfi).EndInit();
            m_tapMalakrefi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvPantMalaKerfi).EndInit();
            m_grbNidurstodur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvNidurstodur).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView m_dgvFyrirspurnir;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colNafn;
        private DataGridViewTextBoxColumn colLysing;
        private DataGridViewTextBoxColumn colFyrirspurn;
        private DataGridViewTextBoxColumn colGagnagrunnur;
        private SplitContainer splitContainer1;
        private DataGridView m_dgvNidurstodur;
        private GroupBox m_grbNidurstodur;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Button m_btnSetjaIkorfu;
        private GroupBox m_grbPontun;
        private TabControl m_tacPantanir;
        private TabPage m_tapGagnagrunnar;
        private DataGridView m_dgvPantGagnagrunnar;
        private TabPage m_tapSkráarkerfi;
        private TabPage m_tapMalakrefi;
        private DataGridView m_dgvPantSkraarkerfi;
        private DataGridView m_dgvPantMalaKerfi;
        private Button m_btnLjukaPontun;
        private DataGridViewTextBoxColumn colSkraID;
        private DataGridViewTextBoxColumn colSkraTitill;
        private DataGridViewTextBoxColumn colSkraheitiVorslu;
        private DataGridViewButtonColumn colSkraOpna;
        private DataGridViewButtonColumn colSkraDelete;
        private DataGridViewTextBoxColumn colSkraVarslaID;
        private DataGridViewTextBoxColumn colGagnHeit;
        private DataGridViewTextBoxColumn colLeitSkilyrdi;
        private DataGridViewTextBoxColumn colHeitiVarsla;
        private DataGridViewButtonColumn colGagnOpna;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colGagnSQL;
        private DataGridViewTextBoxColumn colMalSkraID;
        private DataGridViewTextBoxColumn colMalTitillSkjals;
        private DataGridViewTextBoxColumn colMalTitillMals;
        private DataGridViewTextBoxColumn colMalHeitiVorslu;
        private DataGridViewButtonColumn colMalOpna;
        private DataGridViewButtonColumn colMalDelete;
        private DataGridViewTextBoxColumn colMalSlod;
        private DataGridViewTextBoxColumn colMalGagnagrunnur;
    }
}