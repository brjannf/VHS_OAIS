namespace Disaster_recovery
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_lblBackupStatus = new System.Windows.Forms.Label();
            this.m_lblHvadAfrita = new System.Windows.Forms.Label();
            this.m_prgBackup = new System.Windows.Forms.ProgressBar();
            this.m_btnRecovery = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // m_lblBackupStatus
            // 
            this.m_lblBackupStatus.AutoSize = true;
            this.m_lblBackupStatus.Location = new System.Drawing.Point(427, 141);
            this.m_lblBackupStatus.Name = "m_lblBackupStatus";
            this.m_lblBackupStatus.Size = new System.Drawing.Size(38, 15);
            this.m_lblBackupStatus.TabIndex = 18;
            this.m_lblBackupStatus.Text = "label1";
            // 
            // m_lblHvadAfrita
            // 
            this.m_lblHvadAfrita.AutoSize = true;
            this.m_lblHvadAfrita.Location = new System.Drawing.Point(126, 116);
            this.m_lblHvadAfrita.Name = "m_lblHvadAfrita";
            this.m_lblHvadAfrita.Size = new System.Drawing.Size(38, 15);
            this.m_lblHvadAfrita.TabIndex = 17;
            this.m_lblHvadAfrita.Text = "label1";
            // 
            // m_prgBackup
            // 
            this.m_prgBackup.Location = new System.Drawing.Point(121, 135);
            this.m_prgBackup.Name = "m_prgBackup";
            this.m_prgBackup.Size = new System.Drawing.Size(288, 23);
            this.m_prgBackup.TabIndex = 16;
            // 
            // m_btnRecovery
            // 
            this.m_btnRecovery.Location = new System.Drawing.Point(121, 282);
            this.m_btnRecovery.Name = "m_btnRecovery";
            this.m_btnRecovery.Size = new System.Drawing.Size(297, 23);
            this.m_btnRecovery.TabIndex = 15;
            this.m_btnRecovery.Text = "Hörmungabæting (disaster recoveery)";
            this.m_btnRecovery.UseVisualStyleBackColor = true;
            this.m_btnRecovery.Click += new System.EventHandler(this.m_btnRecovery_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 475);
            this.Controls.Add(this.m_lblBackupStatus);
            this.Controls.Add(this.m_lblHvadAfrita);
            this.Controls.Add(this.m_prgBackup);
            this.Controls.Add(this.m_btnRecovery);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label m_lblBackupStatus;
        private Label m_lblHvadAfrita;
        private ProgressBar m_prgBackup;
        private Button m_btnRecovery;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}