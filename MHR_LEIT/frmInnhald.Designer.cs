namespace MHR_LEIT
{
    partial class frmInnhald
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
            this.m_tboInnhald = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_lblVorsluutgafa = new System.Windows.Forms.Label();
            this.m_lblSkjalamyndari = new System.Windows.Forms.Label();
            this.m_lblVorslustofnun = new System.Windows.Forms.Label();
            this.m_lblTitill = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tboInnhald
            // 
            this.m_tboInnhald.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tboInnhald.Location = new System.Drawing.Point(0, 0);
            this.m_tboInnhald.Multiline = true;
            this.m_tboInnhald.Name = "m_tboInnhald";
            this.m_tboInnhald.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_tboInnhald.Size = new System.Drawing.Size(1262, 450);
            this.m_tboInnhald.TabIndex = 0;
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
            this.splitContainer1.Panel1.Controls.Add(this.m_lblVorsluutgafa);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblSkjalamyndari);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblVorslustofnun);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblTitill);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_tboInnhald);
            this.splitContainer1.Size = new System.Drawing.Size(1262, 616);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 1;
            // 
            // m_lblVorsluutgafa
            // 
            this.m_lblVorsluutgafa.AutoSize = true;
            this.m_lblVorsluutgafa.Location = new System.Drawing.Point(69, 121);
            this.m_lblVorsluutgafa.Name = "m_lblVorsluutgafa";
            this.m_lblVorsluutgafa.Size = new System.Drawing.Size(38, 15);
            this.m_lblVorsluutgafa.TabIndex = 3;
            this.m_lblVorsluutgafa.Text = "label1";
            // 
            // m_lblSkjalamyndari
            // 
            this.m_lblSkjalamyndari.AutoSize = true;
            this.m_lblSkjalamyndari.Location = new System.Drawing.Point(69, 88);
            this.m_lblSkjalamyndari.Name = "m_lblSkjalamyndari";
            this.m_lblSkjalamyndari.Size = new System.Drawing.Size(38, 15);
            this.m_lblSkjalamyndari.TabIndex = 2;
            this.m_lblSkjalamyndari.Text = "label1";
            // 
            // m_lblVorslustofnun
            // 
            this.m_lblVorslustofnun.AutoSize = true;
            this.m_lblVorslustofnun.Location = new System.Drawing.Point(69, 62);
            this.m_lblVorslustofnun.Name = "m_lblVorslustofnun";
            this.m_lblVorslustofnun.Size = new System.Drawing.Size(38, 15);
            this.m_lblVorslustofnun.TabIndex = 1;
            this.m_lblVorslustofnun.Text = "label1";
            // 
            // m_lblTitill
            // 
            this.m_lblTitill.AutoSize = true;
            this.m_lblTitill.Location = new System.Drawing.Point(69, 29);
            this.m_lblTitill.Name = "m_lblTitill";
            this.m_lblTitill.Size = new System.Drawing.Size(38, 15);
            this.m_lblTitill.TabIndex = 0;
            this.m_lblTitill.Text = "label1";
            // 
            // frmInnhald
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 616);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmInnhald";
            this.Text = "frmInnhald";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox m_tboInnhald;
        private SplitContainer splitContainer1;
        private Label m_lblVorsluutgafa;
        private Label m_lblSkjalamyndari;
        private Label m_lblVorslustofnun;
        private Label m_lblTitill;
    }
}