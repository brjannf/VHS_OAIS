namespace MHR_LEIT
{
    partial class frmGagnagrunnSkoda
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
            splitContainer1 = new SplitContainer();
            m_lblOrginal = new Label();
            m_lblLeit = new Label();
            m_grbResults = new GroupBox();
            m_dgvResult = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            m_grbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvResult).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(m_lblOrginal);
            splitContainer1.Panel1.Controls.Add(m_lblLeit);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(m_grbResults);
            splitContainer1.Size = new Size(1097, 524);
            splitContainer1.SplitterDistance = 365;
            splitContainer1.TabIndex = 0;
            // 
            // m_lblOrginal
            // 
            m_lblOrginal.AutoSize = true;
            m_lblOrginal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblOrginal.Location = new Point(15, 24);
            m_lblOrginal.Name = "m_lblOrginal";
            m_lblOrginal.Size = new Size(57, 21);
            m_lblOrginal.TabIndex = 1;
            m_lblOrginal.Text = "label2";
            // 
            // m_lblLeit
            // 
            m_lblLeit.AutoSize = true;
            m_lblLeit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            m_lblLeit.Location = new Point(15, 68);
            m_lblLeit.Name = "m_lblLeit";
            m_lblLeit.Size = new Size(57, 21);
            m_lblLeit.TabIndex = 0;
            m_lblLeit.Text = "label1";
            // 
            // m_grbResults
            // 
            m_grbResults.Controls.Add(m_dgvResult);
            m_grbResults.Dock = DockStyle.Fill;
            m_grbResults.Location = new Point(0, 0);
            m_grbResults.Name = "m_grbResults";
            m_grbResults.Size = new Size(728, 524);
            m_grbResults.TabIndex = 1;
            m_grbResults.TabStop = false;
            m_grbResults.Text = "m_grbResults";
            // 
            // m_dgvResult
            // 
            m_dgvResult.AllowUserToAddRows = false;
            m_dgvResult.AllowUserToOrderColumns = true;
            m_dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvResult.Dock = DockStyle.Fill;
            m_dgvResult.Location = new Point(3, 19);
            m_dgvResult.Name = "m_dgvResult";
            m_dgvResult.ReadOnly = true;
            m_dgvResult.RowHeadersVisible = false;
            m_dgvResult.RowTemplate.Height = 25;
            m_dgvResult.Size = new Size(722, 502);
            m_dgvResult.TabIndex = 0;
            // 
            // frmGagnagrunnSkoda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 524);
            Controls.Add(splitContainer1);
            Name = "frmGagnagrunnSkoda";
            Text = "frmGagnagrunnSkoda";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            m_grbResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvResult).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView m_dgvResult;
        private Label m_lblOrginal;
        private Label m_lblLeit;
        private GroupBox m_grbResults;
    }
}