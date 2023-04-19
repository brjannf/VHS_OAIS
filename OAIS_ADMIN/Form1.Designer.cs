namespace OAIS_ADMIN
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
            this.m_tacMain = new System.Windows.Forms.TabControl();
            this.m_tapInnsetning = new System.Windows.Forms.TabPage();
            this.m_uscInnsetning = new OAIS_ADMIN.uscInnSetning();
            this.m_tapGagnaUmsjon = new System.Windows.Forms.TabPage();
            this.uscGagnaUmsjon1 = new OAIS_ADMIN.uscGagnaUmsjon();
            this.m_tapGeymsluMiðlar = new System.Windows.Forms.TabPage();
            this.uscGeymsluMidlar1 = new OAIS_ADMIN.uscGeymsluMidlar();
            this.m_tapMiðlun = new System.Windows.Forms.TabPage();
            this.m_tapUmsjon = new System.Windows.Forms.TabPage();
            this.uscUmsjon1 = new OAIS_ADMIN.uscUmsjon();
            this.m_pnlNotandi = new System.Windows.Forms.Panel();
            this.m_btnRecovery = new System.Windows.Forms.Button();
            this.m_lblVillaInnSkraning = new System.Windows.Forms.Label();
            this.m_btnInnskra = new System.Windows.Forms.Button();
            this.m_lblLykilOrd = new System.Windows.Forms.Label();
            this.m_tboLykilOrd = new System.Windows.Forms.TextBox();
            this.m_lblNotendaNafn = new System.Windows.Forms.Label();
            this.m_tboNoterndaNafn = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.m_prgBackup = new System.Windows.Forms.ProgressBar();
            this.m_lblHvadAfrita = new System.Windows.Forms.Label();
            this.m_lblBackupStatus = new System.Windows.Forms.Label();
            this.m_tacMain.SuspendLayout();
            this.m_tapInnsetning.SuspendLayout();
            this.m_tapGagnaUmsjon.SuspendLayout();
            this.m_tapGeymsluMiðlar.SuspendLayout();
            this.m_tapUmsjon.SuspendLayout();
            this.m_pnlNotandi.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tacMain
            // 
            this.m_tacMain.Controls.Add(this.m_tapInnsetning);
            this.m_tacMain.Controls.Add(this.m_tapGagnaUmsjon);
            this.m_tacMain.Controls.Add(this.m_tapGeymsluMiðlar);
            this.m_tacMain.Controls.Add(this.m_tapMiðlun);
            this.m_tacMain.Controls.Add(this.m_tapUmsjon);
            this.m_tacMain.Location = new System.Drawing.Point(12, 63);
            this.m_tacMain.Name = "m_tacMain";
            this.m_tacMain.SelectedIndex = 0;
            this.m_tacMain.Size = new System.Drawing.Size(775, 473);
            this.m_tacMain.TabIndex = 1;
            this.m_tacMain.SelectedIndexChanged += new System.EventHandler(this.m_tapUmsjon_SelectedIndexChanged);
            // 
            // m_tapInnsetning
            // 
            this.m_tapInnsetning.Controls.Add(this.m_uscInnsetning);
            this.m_tapInnsetning.Location = new System.Drawing.Point(4, 24);
            this.m_tapInnsetning.Name = "m_tapInnsetning";
            this.m_tapInnsetning.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapInnsetning.Size = new System.Drawing.Size(767, 445);
            this.m_tapInnsetning.TabIndex = 1;
            this.m_tapInnsetning.Text = "Innsetning (Ingest entity)";
            this.m_tapInnsetning.UseVisualStyleBackColor = true;
            // 
            // m_uscInnsetning
            // 
            this.m_uscInnsetning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_uscInnsetning.Location = new System.Drawing.Point(3, 3);
            this.m_uscInnsetning.Name = "m_uscInnsetning";
            this.m_uscInnsetning.Size = new System.Drawing.Size(761, 439);
            this.m_uscInnsetning.TabIndex = 0;
            // 
            // m_tapGagnaUmsjon
            // 
            this.m_tapGagnaUmsjon.Controls.Add(this.uscGagnaUmsjon1);
            this.m_tapGagnaUmsjon.Location = new System.Drawing.Point(4, 24);
            this.m_tapGagnaUmsjon.Name = "m_tapGagnaUmsjon";
            this.m_tapGagnaUmsjon.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapGagnaUmsjon.Size = new System.Drawing.Size(767, 445);
            this.m_tapGagnaUmsjon.TabIndex = 2;
            this.m_tapGagnaUmsjon.Text = "Gagnaumsjón (Data management)";
            this.m_tapGagnaUmsjon.UseVisualStyleBackColor = true;
            // 
            // uscGagnaUmsjon1
            // 
            this.uscGagnaUmsjon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uscGagnaUmsjon1.Location = new System.Drawing.Point(3, 3);
            this.uscGagnaUmsjon1.Name = "uscGagnaUmsjon1";
            this.uscGagnaUmsjon1.Size = new System.Drawing.Size(761, 439);
            this.uscGagnaUmsjon1.TabIndex = 0;
            // 
            // m_tapGeymsluMiðlar
            // 
            this.m_tapGeymsluMiðlar.Controls.Add(this.uscGeymsluMidlar1);
            this.m_tapGeymsluMiðlar.Location = new System.Drawing.Point(4, 24);
            this.m_tapGeymsluMiðlar.Name = "m_tapGeymsluMiðlar";
            this.m_tapGeymsluMiðlar.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapGeymsluMiðlar.Size = new System.Drawing.Size(767, 445);
            this.m_tapGeymsluMiðlar.TabIndex = 0;
            this.m_tapGeymsluMiðlar.Text = "Geymslumiðlar (Archival storage)";
            this.m_tapGeymsluMiðlar.UseVisualStyleBackColor = true;
            // 
            // uscGeymsluMidlar1
            // 
            this.uscGeymsluMidlar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uscGeymsluMidlar1.Location = new System.Drawing.Point(3, 3);
            this.uscGeymsluMidlar1.Name = "uscGeymsluMidlar1";
            this.uscGeymsluMidlar1.Size = new System.Drawing.Size(761, 439);
            this.uscGeymsluMidlar1.TabIndex = 0;
            // 
            // m_tapMiðlun
            // 
            this.m_tapMiðlun.Location = new System.Drawing.Point(4, 24);
            this.m_tapMiðlun.Name = "m_tapMiðlun";
            this.m_tapMiðlun.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapMiðlun.Size = new System.Drawing.Size(767, 445);
            this.m_tapMiðlun.TabIndex = 3;
            this.m_tapMiðlun.Text = "Miðlun (Access)";
            this.m_tapMiðlun.UseVisualStyleBackColor = true;
            // 
            // m_tapUmsjon
            // 
            this.m_tapUmsjon.Controls.Add(this.uscUmsjon1);
            this.m_tapUmsjon.Location = new System.Drawing.Point(4, 24);
            this.m_tapUmsjon.Name = "m_tapUmsjon";
            this.m_tapUmsjon.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapUmsjon.Size = new System.Drawing.Size(767, 445);
            this.m_tapUmsjon.TabIndex = 4;
            this.m_tapUmsjon.Text = "Umsjón";
            this.m_tapUmsjon.UseVisualStyleBackColor = true;
            // 
            // uscUmsjon1
            // 
            this.uscUmsjon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uscUmsjon1.Location = new System.Drawing.Point(3, 3);
            this.uscUmsjon1.Name = "uscUmsjon1";
            this.uscUmsjon1.Size = new System.Drawing.Size(761, 439);
            this.uscUmsjon1.TabIndex = 0;
            // 
            // m_pnlNotandi
            // 
            this.m_pnlNotandi.Controls.Add(this.m_lblBackupStatus);
            this.m_pnlNotandi.Controls.Add(this.m_lblHvadAfrita);
            this.m_pnlNotandi.Controls.Add(this.m_prgBackup);
            this.m_pnlNotandi.Controls.Add(this.m_btnRecovery);
            this.m_pnlNotandi.Controls.Add(this.m_lblVillaInnSkraning);
            this.m_pnlNotandi.Controls.Add(this.m_btnInnskra);
            this.m_pnlNotandi.Controls.Add(this.m_lblLykilOrd);
            this.m_pnlNotandi.Controls.Add(this.m_tboLykilOrd);
            this.m_pnlNotandi.Controls.Add(this.m_lblNotendaNafn);
            this.m_pnlNotandi.Controls.Add(this.m_tboNoterndaNafn);
            this.m_pnlNotandi.Location = new System.Drawing.Point(824, 252);
            this.m_pnlNotandi.Name = "m_pnlNotandi";
            this.m_pnlNotandi.Size = new System.Drawing.Size(471, 437);
            this.m_pnlNotandi.TabIndex = 2;
            // 
            // m_btnRecovery
            // 
            this.m_btnRecovery.Location = new System.Drawing.Point(13, 16);
            this.m_btnRecovery.Name = "m_btnRecovery";
            this.m_btnRecovery.Size = new System.Drawing.Size(297, 23);
            this.m_btnRecovery.TabIndex = 11;
            this.m_btnRecovery.Text = "Hörmungabæting (disaster recoveery)";
            this.m_btnRecovery.UseVisualStyleBackColor = true;
            this.m_btnRecovery.Click += new System.EventHandler(this.m_btnRecovery_Click);
            // 
            // m_lblVillaInnSkraning
            // 
            this.m_lblVillaInnSkraning.AutoSize = true;
            this.m_lblVillaInnSkraning.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lblVillaInnSkraning.ForeColor = System.Drawing.Color.IndianRed;
            this.m_lblVillaInnSkraning.Location = new System.Drawing.Point(118, 306);
            this.m_lblVillaInnSkraning.Name = "m_lblVillaInnSkraning";
            this.m_lblVillaInnSkraning.Size = new System.Drawing.Size(52, 21);
            this.m_lblVillaInnSkraning.TabIndex = 10;
            this.m_lblVillaInnSkraning.Text = "label1";
            this.m_lblVillaInnSkraning.Visible = false;
            // 
            // m_btnInnskra
            // 
            this.m_btnInnskra.Location = new System.Drawing.Point(295, 249);
            this.m_btnInnskra.Name = "m_btnInnskra";
            this.m_btnInnskra.Size = new System.Drawing.Size(116, 23);
            this.m_btnInnskra.TabIndex = 9;
            this.m_btnInnskra.Text = "Innskráning";
            this.m_btnInnskra.UseVisualStyleBackColor = true;
            this.m_btnInnskra.Click += new System.EventHandler(this.m_btnInnskra_Click);
            // 
            // m_lblLykilOrd
            // 
            this.m_lblLykilOrd.AutoSize = true;
            this.m_lblLykilOrd.Location = new System.Drawing.Point(117, 203);
            this.m_lblLykilOrd.Name = "m_lblLykilOrd";
            this.m_lblLykilOrd.Size = new System.Drawing.Size(51, 15);
            this.m_lblLykilOrd.TabIndex = 8;
            this.m_lblLykilOrd.Text = "Lykilorð:";
            // 
            // m_tboLykilOrd
            // 
            this.m_tboLykilOrd.Location = new System.Drawing.Point(185, 200);
            this.m_tboLykilOrd.Name = "m_tboLykilOrd";
            this.m_tboLykilOrd.PasswordChar = '*';
            this.m_tboLykilOrd.Size = new System.Drawing.Size(226, 23);
            this.m_tboLykilOrd.TabIndex = 7;
            this.m_tboLykilOrd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tboNoterndaNafn_KeyUp);
            // 
            // m_lblNotendaNafn
            // 
            this.m_lblNotendaNafn.AutoSize = true;
            this.m_lblNotendaNafn.Location = new System.Drawing.Point(88, 153);
            this.m_lblNotendaNafn.Name = "m_lblNotendaNafn";
            this.m_lblNotendaNafn.Size = new System.Drawing.Size(80, 15);
            this.m_lblNotendaNafn.TabIndex = 6;
            this.m_lblNotendaNafn.Text = "Notendanafn:";
            // 
            // m_tboNoterndaNafn
            // 
            this.m_tboNoterndaNafn.Location = new System.Drawing.Point(185, 150);
            this.m_tboNoterndaNafn.Name = "m_tboNoterndaNafn";
            this.m_tboNoterndaNafn.Size = new System.Drawing.Size(226, 23);
            this.m_tboNoterndaNafn.TabIndex = 5;
            this.m_tboNoterndaNafn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tboNoterndaNafn_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(1348, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(58, 582);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(45, 19);
            this.toolStripMenuItem1.Text = "Útskrá";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // m_prgBackup
            // 
            this.m_prgBackup.Location = new System.Drawing.Point(13, 63);
            this.m_prgBackup.Name = "m_prgBackup";
            this.m_prgBackup.Size = new System.Drawing.Size(288, 23);
            this.m_prgBackup.TabIndex = 12;
            // 
            // m_lblHvadAfrita
            // 
            this.m_lblHvadAfrita.AutoSize = true;
            this.m_lblHvadAfrita.Location = new System.Drawing.Point(18, 44);
            this.m_lblHvadAfrita.Name = "m_lblHvadAfrita";
            this.m_lblHvadAfrita.Size = new System.Drawing.Size(38, 15);
            this.m_lblHvadAfrita.TabIndex = 13;
            this.m_lblHvadAfrita.Text = "label1";
            // 
            // m_lblBackupStatus
            // 
            this.m_lblBackupStatus.AutoSize = true;
            this.m_lblBackupStatus.Location = new System.Drawing.Point(319, 69);
            this.m_lblBackupStatus.Name = "m_lblBackupStatus";
            this.m_lblBackupStatus.Size = new System.Drawing.Size(38, 15);
            this.m_lblBackupStatus.TabIndex = 14;
            this.m_lblBackupStatus.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 582);
            this.Controls.Add(this.m_pnlNotandi);
            this.Controls.Add(this.m_tacMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.m_tacMain.ResumeLayout(false);
            this.m_tapInnsetning.ResumeLayout(false);
            this.m_tapGagnaUmsjon.ResumeLayout(false);
            this.m_tapGeymsluMiðlar.ResumeLayout(false);
            this.m_tapUmsjon.ResumeLayout(false);
            this.m_pnlNotandi.ResumeLayout(false);
            this.m_pnlNotandi.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TabControl m_tacMain;
        private TabPage m_tapInnsetning;
        private TabPage m_tapGeymsluMiðlar;
        private Panel m_pnlNotandi;
        private Button m_btnInnskra;
        private Label m_lblLykilOrd;
        private TextBox m_tboLykilOrd;
        private Label m_lblNotendaNafn;
        private TextBox m_tboNoterndaNafn;
        private Label m_lblVillaInnSkraning;
        private uscInnSetning m_uscInnsetning;
        private TabPage m_tapGagnaUmsjon;
        private TabPage m_tapMiðlun;
        private TabPage m_tapUmsjon;
        private uscGagnaUmsjon uscGagnaUmsjon1;
        private uscGeymsluMidlar uscGeymsluMidlar1;
        private uscUmsjon uscUmsjon1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private Button m_btnRecovery;
        private FolderBrowserDialog folderBrowserDialog1;
        private ProgressBar m_prgBackup;
        private Label m_lblHvadAfrita;
        private Label m_lblBackupStatus;
    }
}