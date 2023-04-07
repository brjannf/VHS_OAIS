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
            this.m_dgvFiles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvFiles);
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
            // m_dgvFiles
            // 
            this.m_dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvFiles.Location = new System.Drawing.Point(0, 0);
            this.m_dgvFiles.Name = "m_dgvFiles";
            this.m_dgvFiles.RowTemplate.Height = 25;
            this.m_dgvFiles.Size = new System.Drawing.Size(720, 565);
            this.m_dgvFiles.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView m_trwDate;
        private DataGridView m_dgvFiles;
    }
}