namespace OAIS_ADMIN
{
    partial class frmFileLoggur
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_trwDate = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_dgvFiles = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEldra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calAðgerð = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLaust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrifID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvFiles)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.m_trwDate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1085, 565);
            this.splitContainer1.SplitterDistance = 361;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_trwDate
            // 
            this.m_trwDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trwDate.Location = new System.Drawing.Point(0, 0);
            this.m_trwDate.Name = "m_trwDate";
            this.m_trwDate.Size = new System.Drawing.Size(361, 565);
            this.m_trwDate.TabIndex = 0;
            this.m_trwDate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trwDate_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_dgvFiles);
            this.splitContainer2.Size = new System.Drawing.Size(720, 565);
            this.splitContainer2.SplitterDistance = 160;
            this.splitContainer2.TabIndex = 1;
            // 
            // m_dgvFiles
            // 
            this.m_dgvFiles.AllowUserToAddRows = false;
            this.m_dgvFiles.AllowUserToDeleteRows = false;
            this.m_dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTitill,
            this.colEldra,
            this.colSlod,
            this.calAðgerð,
            this.colLaust,
            this.colDate,
            this.colVilla,
            this.colDrifID});
            this.m_dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvFiles.Location = new System.Drawing.Point(0, 0);
            this.m_dgvFiles.Name = "m_dgvFiles";
            this.m_dgvFiles.ReadOnly = true;
            this.m_dgvFiles.RowHeadersVisible = false;
            this.m_dgvFiles.RowTemplate.Height = 25;
            this.m_dgvFiles.Size = new System.Drawing.Size(720, 401);
            this.m_dgvFiles.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "id";
            this.colID.HeaderText = "id";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colTitill
            // 
            this.colTitill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTitill.DataPropertyName = "nafn";
            this.colTitill.HeaderText = "Titill";
            this.colTitill.Name = "colTitill";
            this.colTitill.ReadOnly = true;
            this.colTitill.Width = 54;
            // 
            // colEldra
            // 
            this.colEldra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEldra.DataPropertyName = "oldNafn";
            this.colEldra.HeaderText = "Eldri titill";
            this.colEldra.Name = "colEldra";
            this.colEldra.ReadOnly = true;
            this.colEldra.Width = 78;
            // 
            // colSlod
            // 
            this.colSlod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSlod.DataPropertyName = "slod";
            this.colSlod.HeaderText = "Slóð";
            this.colSlod.Name = "colSlod";
            this.colSlod.ReadOnly = true;
            // 
            // calAðgerð
            // 
            this.calAðgerð.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.calAðgerð.DataPropertyName = "adgerd";
            this.calAðgerð.HeaderText = "Aðgerð";
            this.calAðgerð.Name = "calAðgerð";
            this.calAðgerð.ReadOnly = true;
            this.calAðgerð.Width = 71;
            // 
            // colLaust
            // 
            this.colLaust.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLaust.DataPropertyName = "laust";
            this.colLaust.HeaderText = "Laust pláss";
            this.colLaust.Name = "colLaust";
            this.colLaust.ReadOnly = true;
            this.colLaust.Width = 89;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDate.DataPropertyName = "Date";
            this.colDate.HeaderText = "Tímastimpill";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 97;
            // 
            // colVilla
            // 
            this.colVilla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colVilla.DataPropertyName = "villa";
            this.colVilla.HeaderText = "Villa";
            this.colVilla.Name = "colVilla";
            this.colVilla.ReadOnly = true;
            this.colVilla.Width = 54;
            // 
            // colDrifID
            // 
            this.colDrifID.DataPropertyName = "drifID";
            this.colDrifID.HeaderText = "DrifID";
            this.colDrifID.Name = "colDrifID";
            this.colDrifID.ReadOnly = true;
            this.colDrifID.Visible = false;
            // 
            // frmFileLoggur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 565);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmFileLoggur";
            this.Text = "frmFileLoggur";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView m_trwDate;
        private DataGridView m_dgvFiles;
        private SplitContainer splitContainer2;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colTitill;
        private DataGridViewTextBoxColumn colEldra;
        private DataGridViewTextBoxColumn colSlod;
        private DataGridViewTextBoxColumn calAðgerð;
        private DataGridViewTextBoxColumn colLaust;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colVilla;
        private DataGridViewTextBoxColumn colDrifID;
    }
}