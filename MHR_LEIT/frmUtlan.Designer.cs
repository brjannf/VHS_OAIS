namespace MHR_LEIT
{
    partial class frmUtlan
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
            this.m_dgvLanListi = new System.Windows.Forms.DataGridView();
            this.colKarfa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMappa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkradi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvLanListi)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvLanListi);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_dgvLanListi
            // 
            this.m_dgvLanListi.AllowUserToAddRows = false;
            this.m_dgvLanListi.AllowUserToDeleteRows = false;
            this.m_dgvLanListi.AllowUserToOrderColumns = true;
            this.m_dgvLanListi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvLanListi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKarfa,
            this.colMappa,
            this.colLanID,
            this.colSkradi,
            this.colDags});
            this.m_dgvLanListi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvLanListi.Location = new System.Drawing.Point(0, 0);
            this.m_dgvLanListi.Name = "m_dgvLanListi";
            this.m_dgvLanListi.ReadOnly = true;
            this.m_dgvLanListi.RowHeadersVisible = false;
            this.m_dgvLanListi.RowTemplate.Height = 25;
            this.m_dgvLanListi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvLanListi.Size = new System.Drawing.Size(530, 450);
            this.m_dgvLanListi.TabIndex = 0;
            this.m_dgvLanListi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvLanListi_CellClick);
            // 
            // colKarfa
            // 
            this.colKarfa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colKarfa.DataPropertyName = "karfa";
            this.colKarfa.HeaderText = "Karfa";
            this.colKarfa.Name = "colKarfa";
            this.colKarfa.ReadOnly = true;
            this.colKarfa.Width = 59;
            // 
            // colMappa
            // 
            this.colMappa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMappa.DataPropertyName = "heiti";
            this.colMappa.HeaderText = "Mappa";
            this.colMappa.Name = "colMappa";
            this.colMappa.ReadOnly = true;
            // 
            // colLanID
            // 
            this.colLanID.DataPropertyName = "lanthegi";
            this.colLanID.HeaderText = "Lán ID";
            this.colLanID.Name = "colLanID";
            this.colLanID.ReadOnly = true;
            this.colLanID.Visible = false;
            // 
            // colSkradi
            // 
            this.colSkradi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSkradi.DataPropertyName = "hver_skradi";
            this.colSkradi.HeaderText = "Afgreitt af";
            this.colSkradi.Name = "colSkradi";
            this.colSkradi.ReadOnly = true;
            this.colSkradi.Width = 79;
            // 
            // colDags
            // 
            this.colDags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDags.DataPropertyName = "dags_skrad";
            this.colDags.HeaderText = "Dagsetning afgreiðslu";
            this.colDags.Name = "colDags";
            this.colDags.ReadOnly = true;
            this.colDags.Width = 134;
            // 
            // frmUtlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmUtlan";
            this.Text = "frmUtlan";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvLanListi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView m_dgvLanListi;
        private DataGridViewTextBoxColumn colKarfa;
        private DataGridViewTextBoxColumn colMappa;
        private DataGridViewTextBoxColumn colLanID;
        private DataGridViewTextBoxColumn colSkradi;
        private DataGridViewTextBoxColumn colDags;
    }
}