namespace OAIS_ADMIN
{
    partial class uscNotandi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_tboNoterndaNafn = new System.Windows.Forms.TextBox();
            this.m_lblNotendaNafn = new System.Windows.Forms.Label();
            this.m_lblLykilOrd = new System.Windows.Forms.Label();
            this.m_tboLykilOrd = new System.Windows.Forms.TextBox();
            this.m_btnInnskra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_tboNoterndaNafn
            // 
            this.m_tboNoterndaNafn.Location = new System.Drawing.Point(453, 334);
            this.m_tboNoterndaNafn.Name = "m_tboNoterndaNafn";
            this.m_tboNoterndaNafn.Size = new System.Drawing.Size(226, 23);
            this.m_tboNoterndaNafn.TabIndex = 0;
            // 
            // m_lblNotendaNafn
            // 
            this.m_lblNotendaNafn.AutoSize = true;
            this.m_lblNotendaNafn.Location = new System.Drawing.Point(356, 337);
            this.m_lblNotendaNafn.Name = "m_lblNotendaNafn";
            this.m_lblNotendaNafn.Size = new System.Drawing.Size(80, 15);
            this.m_lblNotendaNafn.TabIndex = 1;
            this.m_lblNotendaNafn.Text = "Notendanafn:";
            // 
            // m_lblLykilOrd
            // 
            this.m_lblLykilOrd.AutoSize = true;
            this.m_lblLykilOrd.Location = new System.Drawing.Point(385, 387);
            this.m_lblLykilOrd.Name = "m_lblLykilOrd";
            this.m_lblLykilOrd.Size = new System.Drawing.Size(51, 15);
            this.m_lblLykilOrd.TabIndex = 3;
            this.m_lblLykilOrd.Text = "Lykilorð:";
            // 
            // m_tboLykilOrd
            // 
            this.m_tboLykilOrd.Location = new System.Drawing.Point(453, 384);
            this.m_tboLykilOrd.Name = "m_tboLykilOrd";
            this.m_tboLykilOrd.PasswordChar = '*';
            this.m_tboLykilOrd.Size = new System.Drawing.Size(226, 23);
            this.m_tboLykilOrd.TabIndex = 2;
            // 
            // m_btnInnskra
            // 
            this.m_btnInnskra.Location = new System.Drawing.Point(563, 433);
            this.m_btnInnskra.Name = "m_btnInnskra";
            this.m_btnInnskra.Size = new System.Drawing.Size(116, 23);
            this.m_btnInnskra.TabIndex = 4;
            this.m_btnInnskra.Text = "Innskráning";
            this.m_btnInnskra.UseVisualStyleBackColor = true;
            this.m_btnInnskra.Click += new System.EventHandler(this.m_btnInnskra_Click);
            // 
            // uscNotandi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_btnInnskra);
            this.Controls.Add(this.m_lblLykilOrd);
            this.Controls.Add(this.m_tboLykilOrd);
            this.Controls.Add(this.m_lblNotendaNafn);
            this.Controls.Add(this.m_tboNoterndaNafn);
            this.Name = "uscNotandi";
            this.Size = new System.Drawing.Size(1141, 787);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox m_tboNoterndaNafn;
        private Label m_lblNotendaNafn;
        private Label m_lblLykilOrd;
        private TextBox m_tboLykilOrd;
        private Button m_btnInnskra;
    }
}
