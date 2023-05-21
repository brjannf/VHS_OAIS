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
            this.m_dgvFyrirspurnir = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNafn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLysing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFyrirspurn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGagnagrunnur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_dgvNidurstodur = new System.Windows.Forms.DataGridView();
            this.m_grbNidurstodur = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvFyrirspurnir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvNidurstodur)).BeginInit();
            this.m_grbNidurstodur.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dgvFyrirspurnir
            // 
            this.m_dgvFyrirspurnir.AllowUserToAddRows = false;
            this.m_dgvFyrirspurnir.AllowUserToDeleteRows = false;
            this.m_dgvFyrirspurnir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvFyrirspurnir.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colNafn,
            this.colLysing,
            this.colFyrirspurn,
            this.colGagnagrunnur});
            this.m_dgvFyrirspurnir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvFyrirspurnir.Location = new System.Drawing.Point(0, 0);
            this.m_dgvFyrirspurnir.Name = "m_dgvFyrirspurnir";
            this.m_dgvFyrirspurnir.RowHeadersVisible = false;
            this.m_dgvFyrirspurnir.RowTemplate.Height = 25;
            this.m_dgvFyrirspurnir.Size = new System.Drawing.Size(1528, 288);
            this.m_dgvFyrirspurnir.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "id";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colNafn
            // 
            this.colNafn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNafn.DataPropertyName = "nafn";
            this.colNafn.HeaderText = "Titill fyrirspurnar";
            this.colNafn.Name = "colNafn";
            this.colNafn.Width = 108;
            // 
            // colLysing
            // 
            this.colLysing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLysing.DataPropertyName = "lysing";
            this.colLysing.HeaderText = "Lýsing fyrirspurnar";
            this.colLysing.Name = "colLysing";
            // 
            // colFyrirspurn
            // 
            this.colFyrirspurn.DataPropertyName = "fyrirspurn";
            this.colFyrirspurn.HeaderText = "Fyrirspurn";
            this.colFyrirspurn.Name = "colFyrirspurn";
            this.colFyrirspurn.Visible = false;
            // 
            // colGagnagrunnur
            // 
            this.colGagnagrunnur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGagnagrunnur.DataPropertyName = "gagnagrunnur";
            this.colGagnagrunnur.HeaderText = "Gagnagrunnur";
            this.colGagnagrunnur.Name = "colGagnagrunnur";
            this.colGagnagrunnur.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_dgvFyrirspurnir);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_grbNidurstodur);
            this.splitContainer1.Size = new System.Drawing.Size(1528, 577);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 1;
            // 
            // m_dgvNidurstodur
            // 
            this.m_dgvNidurstodur.AllowUserToAddRows = false;
            this.m_dgvNidurstodur.AllowUserToDeleteRows = false;
            this.m_dgvNidurstodur.AllowUserToOrderColumns = true;
            this.m_dgvNidurstodur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvNidurstodur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvNidurstodur.Location = new System.Drawing.Point(3, 19);
            this.m_dgvNidurstodur.Name = "m_dgvNidurstodur";
            this.m_dgvNidurstodur.ReadOnly = true;
            this.m_dgvNidurstodur.RowHeadersVisible = false;
            this.m_dgvNidurstodur.RowTemplate.Height = 25;
            this.m_dgvNidurstodur.Size = new System.Drawing.Size(1522, 263);
            this.m_dgvNidurstodur.TabIndex = 0;
            // 
            // m_grbNidurstodur
            // 
            this.m_grbNidurstodur.Controls.Add(this.m_dgvNidurstodur);
            this.m_grbNidurstodur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbNidurstodur.Location = new System.Drawing.Point(0, 0);
            this.m_grbNidurstodur.Name = "m_grbNidurstodur";
            this.m_grbNidurstodur.Size = new System.Drawing.Size(1528, 285);
            this.m_grbNidurstodur.TabIndex = 1;
            this.m_grbNidurstodur.TabStop = false;
            this.m_grbNidurstodur.Text = "Niðurstöður";
            // 
            // frmGagnagrunnur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 577);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmGagnagrunnur";
            this.Text = "frmGagnagrunnur";
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvFyrirspurnir)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvNidurstodur)).EndInit();
            this.m_grbNidurstodur.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}