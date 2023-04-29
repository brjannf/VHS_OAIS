namespace MHR_LEIT
{
    partial class frmSkraarkerfi
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
            this.m_trwFileSystem = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_btnLeita = new System.Windows.Forms.Button();
            this.m_lblLeitarNidurstodur = new System.Windows.Forms.Label();
            this.m_tobLeitarord = new System.Windows.Forms.TextBox();
            this.m_btnAfrit = new System.Windows.Forms.Button();
            this.m_btnFrumRit = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.m_pibSkjal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pibSkjal)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.m_trwFileSystem);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1423, 604);
            this.splitContainer1.SplitterDistance = 453;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_trwFileSystem
            // 
            this.m_trwFileSystem.CheckBoxes = true;
            this.m_trwFileSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trwFileSystem.Location = new System.Drawing.Point(0, 0);
            this.m_trwFileSystem.Name = "m_trwFileSystem";
            this.m_trwFileSystem.Size = new System.Drawing.Size(453, 604);
            this.m_trwFileSystem.TabIndex = 0;
            this.m_trwFileSystem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trwFileSystem_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_btnLeita);
            this.splitContainer2.Panel1.Controls.Add(this.m_lblLeitarNidurstodur);
            this.splitContainer2.Panel1.Controls.Add(this.m_tobLeitarord);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnAfrit);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnFrumRit);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(966, 604);
            this.splitContainer2.SplitterDistance = 107;
            this.splitContainer2.TabIndex = 0;
            // 
            // m_btnLeita
            // 
            this.m_btnLeita.Location = new System.Drawing.Point(623, 30);
            this.m_btnLeita.Name = "m_btnLeita";
            this.m_btnLeita.Size = new System.Drawing.Size(89, 23);
            this.m_btnLeita.TabIndex = 4;
            this.m_btnLeita.Text = "Leita";
            this.m_btnLeita.UseVisualStyleBackColor = true;
            this.m_btnLeita.Click += new System.EventHandler(this.m_btnLeita_Click);
            // 
            // m_lblLeitarNidurstodur
            // 
            this.m_lblLeitarNidurstodur.AutoSize = true;
            this.m_lblLeitarNidurstodur.Location = new System.Drawing.Point(39, 70);
            this.m_lblLeitarNidurstodur.Name = "m_lblLeitarNidurstodur";
            this.m_lblLeitarNidurstodur.Size = new System.Drawing.Size(38, 15);
            this.m_lblLeitarNidurstodur.TabIndex = 3;
            this.m_lblLeitarNidurstodur.Text = "label1";
            // 
            // m_tobLeitarord
            // 
            this.m_tobLeitarord.Location = new System.Drawing.Point(39, 30);
            this.m_tobLeitarord.Name = "m_tobLeitarord";
            this.m_tobLeitarord.Size = new System.Drawing.Size(541, 23);
            this.m_tobLeitarord.TabIndex = 2;
            this.m_tobLeitarord.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tobLeitarord_KeyUp);
            // 
            // m_btnAfrit
            // 
            this.m_btnAfrit.Location = new System.Drawing.Point(795, 66);
            this.m_btnAfrit.Name = "m_btnAfrit";
            this.m_btnAfrit.Size = new System.Drawing.Size(150, 23);
            this.m_btnAfrit.TabIndex = 1;
            this.m_btnAfrit.Text = "Opna afrit";
            this.m_btnAfrit.UseVisualStyleBackColor = true;
            this.m_btnAfrit.Click += new System.EventHandler(this.m_btnAfrit_Click);
            // 
            // m_btnFrumRit
            // 
            this.m_btnFrumRit.Location = new System.Drawing.Point(623, 66);
            this.m_btnFrumRit.Name = "m_btnFrumRit";
            this.m_btnFrumRit.Size = new System.Drawing.Size(150, 23);
            this.m_btnFrumRit.TabIndex = 0;
            this.m_btnFrumRit.Text = "Opna frumrit";
            this.m_btnFrumRit.UseVisualStyleBackColor = true;
            this.m_btnFrumRit.Click += new System.EventHandler(this.m_btnFrumRit_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.m_pibSkjal);
            this.splitContainer3.Size = new System.Drawing.Size(966, 493);
            this.splitContainer3.SplitterDistance = 29;
            this.splitContainer3.TabIndex = 1;
            // 
            // m_pibSkjal
            // 
            this.m_pibSkjal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pibSkjal.Location = new System.Drawing.Point(0, 0);
            this.m_pibSkjal.Name = "m_pibSkjal";
            this.m_pibSkjal.Size = new System.Drawing.Size(966, 460);
            this.m_pibSkjal.TabIndex = 0;
            this.m_pibSkjal.TabStop = false;
            this.m_pibSkjal.DoubleClick += new System.EventHandler(this.m_pibSkjal_DoubleClick);
            // 
            // frmSkraarkerfi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 604);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmSkraarkerfi";
            this.Text = "frmSkraarkerfi";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pibSkjal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView m_trwFileSystem;
        private SplitContainer splitContainer2;
        private PictureBox m_pibSkjal;
        private Button m_btnFrumRit;
        private Button m_btnAfrit;
        private TextBox m_tobLeitarord;
        private Button m_btnLeita;
        private Label m_lblLeitarNidurstodur;
        private SplitContainer splitContainer3;
    }
}