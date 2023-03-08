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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_pnlNotandi = new System.Windows.Forms.Panel();
            this.m_lblVillaInnSkraning = new System.Windows.Forms.Label();
            this.m_btnInnskra = new System.Windows.Forms.Button();
            this.m_lblLykilOrd = new System.Windows.Forms.Label();
            this.m_tboLykilOrd = new System.Windows.Forms.TextBox();
            this.m_lblNotendaNafn = new System.Windows.Forms.Label();
            this.m_tboNoterndaNafn = new System.Windows.Forms.TextBox();
            this.m_tacMain.SuspendLayout();
            this.m_tapInnsetning.SuspendLayout();
            this.m_pnlNotandi.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tacMain
            // 
            this.m_tacMain.Controls.Add(this.m_tapInnsetning);
            this.m_tacMain.Controls.Add(this.tabPage1);
            this.m_tacMain.Location = new System.Drawing.Point(12, 136);
            this.m_tacMain.Name = "m_tacMain";
            this.m_tacMain.SelectedIndex = 0;
            this.m_tacMain.Size = new System.Drawing.Size(562, 461);
            this.m_tacMain.TabIndex = 1;
            // 
            // m_tapInnsetning
            // 
            this.m_tapInnsetning.Controls.Add(this.m_uscInnsetning);
            this.m_tapInnsetning.Location = new System.Drawing.Point(4, 24);
            this.m_tapInnsetning.Name = "m_tapInnsetning";
            this.m_tapInnsetning.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapInnsetning.Size = new System.Drawing.Size(554, 433);
            this.m_tapInnsetning.TabIndex = 1;
            this.m_tapInnsetning.Text = "Innsetning";
            this.m_tapInnsetning.UseVisualStyleBackColor = true;
            // 
            // m_uscInnsetning
            // 
            this.m_uscInnsetning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_uscInnsetning.Location = new System.Drawing.Point(3, 3);
            this.m_uscInnsetning.Name = "m_uscInnsetning";
            this.m_uscInnsetning.Size = new System.Drawing.Size(548, 427);
            this.m_uscInnsetning.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(554, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // m_pnlNotandi
            // 
            this.m_pnlNotandi.Controls.Add(this.m_lblVillaInnSkraning);
            this.m_pnlNotandi.Controls.Add(this.m_btnInnskra);
            this.m_pnlNotandi.Controls.Add(this.m_lblLykilOrd);
            this.m_pnlNotandi.Controls.Add(this.m_tboLykilOrd);
            this.m_pnlNotandi.Controls.Add(this.m_lblNotendaNafn);
            this.m_pnlNotandi.Controls.Add(this.m_tboNoterndaNafn);
            this.m_pnlNotandi.Location = new System.Drawing.Point(615, 160);
            this.m_pnlNotandi.Name = "m_pnlNotandi";
            this.m_pnlNotandi.Size = new System.Drawing.Size(471, 437);
            this.m_pnlNotandi.TabIndex = 2;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 701);
            this.Controls.Add(this.m_pnlNotandi);
            this.Controls.Add(this.m_tacMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.m_tacMain.ResumeLayout(false);
            this.m_tapInnsetning.ResumeLayout(false);
            this.m_pnlNotandi.ResumeLayout(false);
            this.m_pnlNotandi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl m_tacMain;
        private TabPage m_tapInnsetning;
        private TabPage tabPage1;
        private Panel m_pnlNotandi;
        private Button m_btnInnskra;
        private Label m_lblLykilOrd;
        private TextBox m_tboLykilOrd;
        private Label m_lblNotendaNafn;
        private TextBox m_tboNoterndaNafn;
        private Label m_lblVillaInnSkraning;
        private uscInnSetning m_uscInnsetning;
    }
}