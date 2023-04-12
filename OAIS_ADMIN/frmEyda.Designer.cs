namespace OAIS_ADMIN
{
    partial class frmEyda
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
            this.m_btnStaðfesta = new System.Windows.Forms.Button();
            this.m_lblEyða = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // m_btnStaðfesta
            // 
            this.m_btnStaðfesta.Location = new System.Drawing.Point(152, 307);
            this.m_btnStaðfesta.Name = "m_btnStaðfesta";
            this.m_btnStaðfesta.Size = new System.Drawing.Size(215, 23);
            this.m_btnStaðfesta.TabIndex = 0;
            this.m_btnStaðfesta.Text = "Staðfesta";
            this.m_btnStaðfesta.UseVisualStyleBackColor = true;
            this.m_btnStaðfesta.Click += new System.EventHandler(this.m_btnStaðfesta_Click);
            // 
            // m_lblEyða
            // 
            this.m_lblEyða.AutoSize = true;
            this.m_lblEyða.Location = new System.Drawing.Point(33, 30);
            this.m_lblEyða.Name = "m_lblEyða";
            this.m_lblEyða.Size = new System.Drawing.Size(38, 15);
            this.m_lblEyða.TabIndex = 1;
            this.m_lblEyða.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(91, 138);
            this.progressBar1.Maximum = 7;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(305, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // frmEyda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 378);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.m_lblEyða);
            this.Controls.Add(this.m_btnStaðfesta);
            this.Name = "frmEyda";
            this.Text = "frmEyda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button m_btnStaðfesta;
        private Label m_lblEyða;
        private ProgressBar progressBar1;
    }
}