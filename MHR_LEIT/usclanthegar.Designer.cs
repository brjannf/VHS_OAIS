namespace MHR_LEIT
{
    partial class usclanthegar
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
            this.m_btnSkyrlsa = new System.Windows.Forms.Button();
            this.m_btnStofna = new System.Windows.Forms.Button();
            this.m_grbLanthegalisti = new System.Windows.Forms.GroupBox();
            this.m_dgvLanthegar = new System.Windows.Forms.DataGridView();
            this.colLanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanNafn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanKennitala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNafnFyrirtaekis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanKennitalaFyrir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanSimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanNetfang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanDagsSrkad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanSkradAf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanBreyta = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colLanListi = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_grbLanthegalisti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvLanthegar)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.m_btnSkyrlsa);
            this.splitContainer1.Panel1.Controls.Add(this.m_btnStofna);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_grbLanthegalisti);
            this.splitContainer1.Size = new System.Drawing.Size(1434, 677);
            this.splitContainer1.SplitterDistance = 347;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_btnSkyrlsa
            // 
            this.m_btnSkyrlsa.Location = new System.Drawing.Point(90, 108);
            this.m_btnSkyrlsa.Name = "m_btnSkyrlsa";
            this.m_btnSkyrlsa.Size = new System.Drawing.Size(154, 23);
            this.m_btnSkyrlsa.TabIndex = 1;
            this.m_btnSkyrlsa.Text = "Keyra út skýrslu";
            this.m_btnSkyrlsa.UseVisualStyleBackColor = true;
            this.m_btnSkyrlsa.Click += new System.EventHandler(this.m_btnSkyrlsa_Click);
            // 
            // m_btnStofna
            // 
            this.m_btnStofna.Location = new System.Drawing.Point(90, 46);
            this.m_btnStofna.Name = "m_btnStofna";
            this.m_btnStofna.Size = new System.Drawing.Size(154, 23);
            this.m_btnStofna.TabIndex = 0;
            this.m_btnStofna.Text = "Skrá lánþega";
            this.m_btnStofna.UseVisualStyleBackColor = true;
            this.m_btnStofna.Click += new System.EventHandler(this.m_btnStofna_Click);
            // 
            // m_grbLanthegalisti
            // 
            this.m_grbLanthegalisti.Controls.Add(this.m_dgvLanthegar);
            this.m_grbLanthegalisti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbLanthegalisti.Location = new System.Drawing.Point(0, 0);
            this.m_grbLanthegalisti.Name = "m_grbLanthegalisti";
            this.m_grbLanthegalisti.Size = new System.Drawing.Size(1083, 677);
            this.m_grbLanthegalisti.TabIndex = 1;
            this.m_grbLanthegalisti.TabStop = false;
            this.m_grbLanthegalisti.Text = "Lánþegalisti";
            // 
            // m_dgvLanthegar
            // 
            this.m_dgvLanthegar.AllowUserToAddRows = false;
            this.m_dgvLanthegar.AllowUserToDeleteRows = false;
            this.m_dgvLanthegar.AllowUserToOrderColumns = true;
            this.m_dgvLanthegar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvLanthegar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLanID,
            this.colLanNafn,
            this.colLanKennitala,
            this.colNafnFyrirtaekis,
            this.colLanKennitalaFyrir,
            this.colLanSimi,
            this.colLanNetfang,
            this.colLanDagsSrkad,
            this.colLanSkradAf,
            this.colLanBreyta,
            this.colLanListi});
            this.m_dgvLanthegar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvLanthegar.Location = new System.Drawing.Point(3, 19);
            this.m_dgvLanthegar.Name = "m_dgvLanthegar";
            this.m_dgvLanthegar.ReadOnly = true;
            this.m_dgvLanthegar.RowHeadersVisible = false;
            this.m_dgvLanthegar.RowTemplate.Height = 25;
            this.m_dgvLanthegar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvLanthegar.Size = new System.Drawing.Size(1077, 655);
            this.m_dgvLanthegar.TabIndex = 0;
            this.m_dgvLanthegar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvLanthegar_CellClick);
            // 
            // colLanID
            // 
            this.colLanID.DataPropertyName = "id";
            this.colLanID.HeaderText = "ID";
            this.colLanID.Name = "colLanID";
            this.colLanID.ReadOnly = true;
            this.colLanID.Visible = false;
            // 
            // colLanNafn
            // 
            this.colLanNafn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLanNafn.DataPropertyName = "nafn";
            this.colLanNafn.HeaderText = "Nafn";
            this.colLanNafn.Name = "colLanNafn";
            this.colLanNafn.ReadOnly = true;
            // 
            // colLanKennitala
            // 
            this.colLanKennitala.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLanKennitala.DataPropertyName = "kennitala";
            this.colLanKennitala.HeaderText = "Kennitala";
            this.colLanKennitala.Name = "colLanKennitala";
            this.colLanKennitala.ReadOnly = true;
            this.colLanKennitala.Width = 81;
            // 
            // colNafnFyrirtaekis
            // 
            this.colNafnFyrirtaekis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNafnFyrirtaekis.DataPropertyName = "nafn_fyrirtaekis";
            this.colNafnFyrirtaekis.HeaderText = "Nafn fyrirtækis";
            this.colNafnFyrirtaekis.Name = "colNafnFyrirtaekis";
            this.colNafnFyrirtaekis.ReadOnly = true;
            this.colNafnFyrirtaekis.Width = 110;
            // 
            // colLanKennitalaFyrir
            // 
            this.colLanKennitalaFyrir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLanKennitalaFyrir.DataPropertyName = "kennitala_fyrirtaekis";
            this.colLanKennitalaFyrir.HeaderText = "Kennitala Fyrirtækis";
            this.colLanKennitalaFyrir.Name = "colLanKennitalaFyrir";
            this.colLanKennitalaFyrir.ReadOnly = true;
            this.colLanKennitalaFyrir.Width = 124;
            // 
            // colLanSimi
            // 
            this.colLanSimi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLanSimi.DataPropertyName = "simi";
            this.colLanSimi.HeaderText = "Sími";
            this.colLanSimi.Name = "colLanSimi";
            this.colLanSimi.ReadOnly = true;
            this.colLanSimi.Width = 55;
            // 
            // colLanNetfang
            // 
            this.colLanNetfang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLanNetfang.DataPropertyName = "netfang";
            this.colLanNetfang.HeaderText = "Netfang";
            this.colLanNetfang.Name = "colLanNetfang";
            this.colLanNetfang.ReadOnly = true;
            this.colLanNetfang.Width = 75;
            // 
            // colLanDagsSrkad
            // 
            this.colLanDagsSrkad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLanDagsSrkad.DataPropertyName = "dags_skrad";
            this.colLanDagsSrkad.HeaderText = "Dagsetning skráningar";
            this.colLanDagsSrkad.Name = "colLanDagsSrkad";
            this.colLanDagsSrkad.ReadOnly = true;
            this.colLanDagsSrkad.Width = 137;
            // 
            // colLanSkradAf
            // 
            this.colLanSkradAf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLanSkradAf.DataPropertyName = "skrad_af";
            this.colLanSkradAf.HeaderText = "Skráð af";
            this.colLanSkradAf.Name = "colLanSkradAf";
            this.colLanSkradAf.ReadOnly = true;
            this.colLanSkradAf.Width = 69;
            // 
            // colLanBreyta
            // 
            this.colLanBreyta.HeaderText = "Breyta";
            this.colLanBreyta.Name = "colLanBreyta";
            this.colLanBreyta.ReadOnly = true;
            this.colLanBreyta.Text = "Breyta";
            this.colLanBreyta.UseColumnTextForButtonValue = true;
            // 
            // colLanListi
            // 
            this.colLanListi.HeaderText = "Útlánalisti";
            this.colLanListi.Name = "colLanListi";
            this.colLanListi.ReadOnly = true;
            this.colLanListi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLanListi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLanListi.Text = "útlán";
            this.colLanListi.UseColumnTextForButtonValue = true;
            // 
            // usclanthegar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "usclanthegar";
            this.Size = new System.Drawing.Size(1434, 677);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.m_grbLanthegalisti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvLanthegar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Button m_btnStofna;
        private DataGridView m_dgvLanthegar;
        private GroupBox m_grbLanthegalisti;
        private Button m_btnSkyrlsa;
        private DataGridViewTextBoxColumn colLanID;
        private DataGridViewTextBoxColumn colLanNafn;
        private DataGridViewTextBoxColumn colLanKennitala;
        private DataGridViewTextBoxColumn colNafnFyrirtaekis;
        private DataGridViewTextBoxColumn colLanKennitalaFyrir;
        private DataGridViewTextBoxColumn colLanSimi;
        private DataGridViewTextBoxColumn colLanNetfang;
        private DataGridViewTextBoxColumn colLanDagsSrkad;
        private DataGridViewTextBoxColumn colLanSkradAf;
        private DataGridViewButtonColumn colLanBreyta;
        private DataGridViewButtonColumn colLanListi;
    }
}
