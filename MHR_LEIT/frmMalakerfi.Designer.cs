namespace MHR_LEIT
{
    partial class frmMalakerfi
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
            this.m_trwMalalykill = new System.Windows.Forms.TreeView();
            this.m_numUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_pibSkjal = new System.Windows.Forms.PictureBox();
            this.m_dgvMal = new System.Windows.Forms.DataGridView();
            this.m_dgvSkjol = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pibSkjal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvSkjol)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.m_trwMalalykill);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_numUpDown);
            this.splitContainer1.Panel2.Controls.Add(this.m_pibSkjal);
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvMal);
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvSkjol);
            this.splitContainer1.Size = new System.Drawing.Size(1503, 681);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_trwMalalykill
            // 
            this.m_trwMalalykill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trwMalalykill.Location = new System.Drawing.Point(0, 0);
            this.m_trwMalalykill.Name = "m_trwMalalykill";
            this.m_trwMalalykill.Size = new System.Drawing.Size(308, 681);
            this.m_trwMalalykill.TabIndex = 0;
            this.m_trwMalalykill.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_trwMalalykill_BeforeSelect);
            this.m_trwMalalykill.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trwMalalykill_AfterSelect);
            // 
            // m_numUpDown
            // 
            this.m_numUpDown.Location = new System.Drawing.Point(900, 144);
            this.m_numUpDown.Name = "m_numUpDown";
            this.m_numUpDown.Size = new System.Drawing.Size(40, 23);
            this.m_numUpDown.TabIndex = 3;
            // 
            // m_pibSkjal
            // 
            this.m_pibSkjal.Location = new System.Drawing.Point(800, 195);
            this.m_pibSkjal.Name = "m_pibSkjal";
            this.m_pibSkjal.Size = new System.Drawing.Size(281, 226);
            this.m_pibSkjal.TabIndex = 2;
            this.m_pibSkjal.TabStop = false;
            this.m_pibSkjal.DoubleClick += new System.EventHandler(this.m_pibSkjal_DoubleClick);
            // 
            // m_dgvMal
            // 
            this.m_dgvMal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvMal.Location = new System.Drawing.Point(49, 37);
            this.m_dgvMal.Name = "m_dgvMal";
            this.m_dgvMal.RowTemplate.Height = 25;
            this.m_dgvMal.Size = new System.Drawing.Size(713, 150);
            this.m_dgvMal.TabIndex = 1;
            // 
            // m_dgvSkjol
            // 
            this.m_dgvSkjol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvSkjol.Location = new System.Drawing.Point(66, 430);
            this.m_dgvSkjol.Name = "m_dgvSkjol";
            this.m_dgvSkjol.RowTemplate.Height = 25;
            this.m_dgvSkjol.Size = new System.Drawing.Size(713, 150);
            this.m_dgvSkjol.TabIndex = 0;
            this.m_dgvSkjol.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvSkjol_CellContentClick);
            // 
            // frmMalakerfi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 681);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMalakerfi";
            this.Text = "frmMalakerfi";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pibSkjal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvMal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvSkjol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView m_trwMalalykill;
        private DataGridView m_dgvMal;
        private DataGridView m_dgvSkjol;
        private PictureBox m_pibSkjal;
        private NumericUpDown m_numUpDown;
    }
}