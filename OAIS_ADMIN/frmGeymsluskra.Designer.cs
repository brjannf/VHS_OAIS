namespace OAIS_ADMIN
{
    partial class frmGeymsluskra
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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.m_grbGogn = new System.Windows.Forms.GroupBox();
            this.m_trwGogn = new System.Windows.Forms.TreeView();
            this.m_grbGeymsluSkrá = new System.Windows.Forms.GroupBox();
            this.m_trwGeymsluskrá = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_btnEyda = new System.Windows.Forms.Button();
            this.m_btnVista = new System.Windows.Forms.Button();
            this.m_btnBuaTil = new System.Windows.Forms.Button();
            this.m_lblAthSkjalaVard = new System.Windows.Forms.Label();
            this.m_tboAthSkjal = new System.Windows.Forms.TextBox();
            this.m_btnDUStadfesta = new System.Windows.Forms.Button();
            this.m_lblUpplysingastig = new System.Windows.Forms.Label();
            this.m_tboUpplýsingastig = new System.Windows.Forms.TextBox();
            this.m_grbYfirlitInnihald = new System.Windows.Forms.GroupBox();
            this.m_tboYfirilInnihald = new System.Windows.Forms.TextBox();
            this.m_lblAfharNr = new System.Windows.Forms.Label();
            this.m_tboAfhendingaarNr = new System.Windows.Forms.TextBox();
            this.m_lblAðgengi = new System.Windows.Forms.Label();
            this.m_tboSkilyrðiAðgengi = new System.Windows.Forms.TextBox();
            this.m_lblAuðkenni = new System.Windows.Forms.Label();
            this.m_tboAuðkenni = new System.Windows.Forms.TextBox();
            this.m_lblTimabil = new System.Windows.Forms.Label();
            this.m_tboTimablil = new System.Windows.Forms.TextBox();
            this.m_lblTitilill = new System.Windows.Forms.Label();
            this.m_tboTitill = new System.Windows.Forms.TextBox();
            this.m_btnAddSubSerites = new System.Windows.Forms.Button();
            this.m_btnAddFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.m_grbGogn.SuspendLayout();
            this.m_grbGeymsluSkrá.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.m_grbYfirlitInnihald.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1478, 753);
            this.splitContainer1.SplitterDistance = 707;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.m_grbGogn);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.m_grbGeymsluSkrá);
            this.splitContainer3.Size = new System.Drawing.Size(707, 753);
            this.splitContainer3.SplitterDistance = 329;
            this.splitContainer3.TabIndex = 1;
            // 
            // m_grbGogn
            // 
            this.m_grbGogn.Controls.Add(this.m_trwGogn);
            this.m_grbGogn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbGogn.Location = new System.Drawing.Point(0, 0);
            this.m_grbGogn.Name = "m_grbGogn";
            this.m_grbGogn.Size = new System.Drawing.Size(329, 753);
            this.m_grbGogn.TabIndex = 0;
            this.m_grbGogn.TabStop = false;
            this.m_grbGogn.Text = "Skáarsafn";
            // 
            // m_trwGogn
            // 
            this.m_trwGogn.CheckBoxes = true;
            this.m_trwGogn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trwGogn.Location = new System.Drawing.Point(3, 19);
            this.m_trwGogn.Name = "m_trwGogn";
            this.m_trwGogn.Size = new System.Drawing.Size(323, 731);
            this.m_trwGogn.TabIndex = 0;
            this.m_trwGogn.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_trwGogn_AfterCheck);
            this.m_trwGogn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_trwGogn_MouseDown);
            // 
            // m_grbGeymsluSkrá
            // 
            this.m_grbGeymsluSkrá.Controls.Add(this.m_trwGeymsluskrá);
            this.m_grbGeymsluSkrá.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbGeymsluSkrá.Location = new System.Drawing.Point(0, 0);
            this.m_grbGeymsluSkrá.Name = "m_grbGeymsluSkrá";
            this.m_grbGeymsluSkrá.Size = new System.Drawing.Size(374, 753);
            this.m_grbGeymsluSkrá.TabIndex = 0;
            this.m_grbGeymsluSkrá.TabStop = false;
            this.m_grbGeymsluSkrá.Text = "Geymsluskrá";
            // 
            // m_trwGeymsluskrá
            // 
            this.m_trwGeymsluskrá.CheckBoxes = true;
            this.m_trwGeymsluskrá.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trwGeymsluskrá.Location = new System.Drawing.Point(3, 19);
            this.m_trwGeymsluskrá.Name = "m_trwGeymsluskrá";
            this.m_trwGeymsluskrá.Size = new System.Drawing.Size(368, 731);
            this.m_trwGeymsluskrá.TabIndex = 0;
            this.m_trwGeymsluskrá.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_trwGeymsluskrá_AfterCheck);
            this.m_trwGeymsluskrá.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trwGeymsluskrá_AfterSelect);
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
            this.splitContainer2.Panel1.Controls.Add(this.m_btnEyda);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnVista);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnBuaTil);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_btnAddFile);
            this.splitContainer2.Panel2.Controls.Add(this.m_btnAddSubSerites);
            this.splitContainer2.Panel2.Controls.Add(this.m_lblAthSkjalaVard);
            this.splitContainer2.Panel2.Controls.Add(this.m_tboAthSkjal);
            this.splitContainer2.Panel2.Controls.Add(this.m_btnDUStadfesta);
            this.splitContainer2.Panel2.Controls.Add(this.m_lblUpplysingastig);
            this.splitContainer2.Panel2.Controls.Add(this.m_tboUpplýsingastig);
            this.splitContainer2.Panel2.Controls.Add(this.m_grbYfirlitInnihald);
            this.splitContainer2.Panel2.Controls.Add(this.m_lblAfharNr);
            this.splitContainer2.Panel2.Controls.Add(this.m_tboAfhendingaarNr);
            this.splitContainer2.Panel2.Controls.Add(this.m_lblAðgengi);
            this.splitContainer2.Panel2.Controls.Add(this.m_tboSkilyrðiAðgengi);
            this.splitContainer2.Panel2.Controls.Add(this.m_lblAuðkenni);
            this.splitContainer2.Panel2.Controls.Add(this.m_tboAuðkenni);
            this.splitContainer2.Panel2.Controls.Add(this.m_lblTimabil);
            this.splitContainer2.Panel2.Controls.Add(this.m_tboTimablil);
            this.splitContainer2.Panel2.Controls.Add(this.m_lblTitilill);
            this.splitContainer2.Panel2.Controls.Add(this.m_tboTitill);
            this.splitContainer2.Size = new System.Drawing.Size(767, 753);
            this.splitContainer2.SplitterDistance = 188;
            this.splitContainer2.TabIndex = 0;
            // 
            // m_btnEyda
            // 
            this.m_btnEyda.Location = new System.Drawing.Point(597, 88);
            this.m_btnEyda.Name = "m_btnEyda";
            this.m_btnEyda.Size = new System.Drawing.Size(75, 23);
            this.m_btnEyda.TabIndex = 2;
            this.m_btnEyda.Text = "Eyða";
            this.m_btnEyda.UseVisualStyleBackColor = true;
            this.m_btnEyda.Click += new System.EventHandler(this.m_btnEyda_Click);
            // 
            // m_btnVista
            // 
            this.m_btnVista.Location = new System.Drawing.Point(597, 41);
            this.m_btnVista.Name = "m_btnVista";
            this.m_btnVista.Size = new System.Drawing.Size(75, 23);
            this.m_btnVista.TabIndex = 1;
            this.m_btnVista.Text = "Vista";
            this.m_btnVista.UseVisualStyleBackColor = true;
            this.m_btnVista.Click += new System.EventHandler(this.m_btnVista_Click);
            // 
            // m_btnBuaTil
            // 
            this.m_btnBuaTil.Location = new System.Drawing.Point(63, 41);
            this.m_btnBuaTil.Name = "m_btnBuaTil";
            this.m_btnBuaTil.Size = new System.Drawing.Size(161, 23);
            this.m_btnBuaTil.TabIndex = 0;
            this.m_btnBuaTil.Text = "Búa til geymsluskrá";
            this.m_btnBuaTil.UseVisualStyleBackColor = true;
            this.m_btnBuaTil.Click += new System.EventHandler(this.m_btnBuaTil_Click);
            // 
            // m_lblAthSkjalaVard
            // 
            this.m_lblAthSkjalaVard.AutoSize = true;
            this.m_lblAthSkjalaVard.Location = new System.Drawing.Point(131, 499);
            this.m_lblAthSkjalaVard.Name = "m_lblAthSkjalaVard";
            this.m_lblAthSkjalaVard.Size = new System.Drawing.Size(169, 15);
            this.m_lblAthSkjalaVard.TabIndex = 15;
            this.m_lblAthSkjalaVard.Text = "Athugasemd skajalavarða 3.7.1";
            // 
            // m_tboAthSkjal
            // 
            this.m_tboAthSkjal.Location = new System.Drawing.Point(318, 491);
            this.m_tboAthSkjal.Name = "m_tboAthSkjal";
            this.m_tboAthSkjal.Size = new System.Drawing.Size(298, 23);
            this.m_tboAthSkjal.TabIndex = 14;
            // 
            // m_btnDUStadfesta
            // 
            this.m_btnDUStadfesta.Location = new System.Drawing.Point(647, 17);
            this.m_btnDUStadfesta.Name = "m_btnDUStadfesta";
            this.m_btnDUStadfesta.Size = new System.Drawing.Size(75, 23);
            this.m_btnDUStadfesta.TabIndex = 13;
            this.m_btnDUStadfesta.Text = "Staðfesta";
            this.m_btnDUStadfesta.UseVisualStyleBackColor = true;
            this.m_btnDUStadfesta.Click += new System.EventHandler(this.m_btnDUStadfesta_Click);
            // 
            // m_lblUpplysingastig
            // 
            this.m_lblUpplysingastig.AutoSize = true;
            this.m_lblUpplysingastig.Location = new System.Drawing.Point(134, 25);
            this.m_lblUpplysingastig.Name = "m_lblUpplysingastig";
            this.m_lblUpplysingastig.Size = new System.Drawing.Size(112, 15);
            this.m_lblUpplysingastig.TabIndex = 12;
            this.m_lblUpplysingastig.Text = "Upplýsingastig 3.1.4";
            // 
            // m_tboUpplýsingastig
            // 
            this.m_tboUpplýsingastig.Enabled = false;
            this.m_tboUpplýsingastig.Location = new System.Drawing.Point(280, 17);
            this.m_tboUpplýsingastig.Name = "m_tboUpplýsingastig";
            this.m_tboUpplýsingastig.Size = new System.Drawing.Size(333, 23);
            this.m_tboUpplýsingastig.TabIndex = 11;
            // 
            // m_grbYfirlitInnihald
            // 
            this.m_grbYfirlitInnihald.Controls.Add(this.m_tboYfirilInnihald);
            this.m_grbYfirlitInnihald.Location = new System.Drawing.Point(134, 290);
            this.m_grbYfirlitInnihald.Name = "m_grbYfirlitInnihald";
            this.m_grbYfirlitInnihald.Size = new System.Drawing.Size(479, 165);
            this.m_grbYfirlitInnihald.TabIndex = 10;
            this.m_grbYfirlitInnihald.TabStop = false;
            this.m_grbYfirlitInnihald.Text = "Yfrilit/innihald  3.3.1";
            // 
            // m_tboYfirilInnihald
            // 
            this.m_tboYfirilInnihald.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tboYfirilInnihald.Location = new System.Drawing.Point(3, 19);
            this.m_tboYfirilInnihald.Multiline = true;
            this.m_tboYfirilInnihald.Name = "m_tboYfirilInnihald";
            this.m_tboYfirilInnihald.Size = new System.Drawing.Size(473, 143);
            this.m_tboYfirilInnihald.TabIndex = 0;
            // 
            // m_lblAfharNr
            // 
            this.m_lblAfharNr.AutoSize = true;
            this.m_lblAfharNr.Location = new System.Drawing.Point(137, 235);
            this.m_lblAfharNr.Name = "m_lblAfharNr";
            this.m_lblAfharNr.Size = new System.Drawing.Size(122, 15);
            this.m_lblAfharNr.TabIndex = 9;
            this.m_lblAfharNr.Text = "Afhendingaár/nr 3.2.4";
            // 
            // m_tboAfhendingaarNr
            // 
            this.m_tboAfhendingaarNr.Location = new System.Drawing.Point(283, 232);
            this.m_tboAfhendingaarNr.Name = "m_tboAfhendingaarNr";
            this.m_tboAfhendingaarNr.Size = new System.Drawing.Size(333, 23);
            this.m_tboAfhendingaarNr.TabIndex = 8;
            // 
            // m_lblAðgengi
            // 
            this.m_lblAðgengi.AutoSize = true;
            this.m_lblAðgengi.Location = new System.Drawing.Point(137, 201);
            this.m_lblAðgengi.Name = "m_lblAðgengi";
            this.m_lblAðgengi.Size = new System.Drawing.Size(118, 15);
            this.m_lblAðgengi.TabIndex = 7;
            this.m_lblAðgengi.Text = "Skilyrði aðgengi 3.4.1";
            this.m_lblAðgengi.Click += new System.EventHandler(this.m_lblAðgengi_Click);
            // 
            // m_tboSkilyrðiAðgengi
            // 
            this.m_tboSkilyrðiAðgengi.Location = new System.Drawing.Point(283, 198);
            this.m_tboSkilyrðiAðgengi.Name = "m_tboSkilyrðiAðgengi";
            this.m_tboSkilyrðiAðgengi.Size = new System.Drawing.Size(333, 23);
            this.m_tboSkilyrðiAðgengi.TabIndex = 6;
            // 
            // m_lblAuðkenni
            // 
            this.m_lblAuðkenni.AutoSize = true;
            this.m_lblAuðkenni.Location = new System.Drawing.Point(137, 68);
            this.m_lblAuðkenni.Name = "m_lblAuðkenni";
            this.m_lblAuðkenni.Size = new System.Drawing.Size(85, 15);
            this.m_lblAuðkenni.TabIndex = 5;
            this.m_lblAuðkenni.Text = "Auðkenni 3.1.1";
            this.m_lblAuðkenni.Click += new System.EventHandler(this.m_lblAuðkenni_Click);
            // 
            // m_tboAuðkenni
            // 
            this.m_tboAuðkenni.Enabled = false;
            this.m_tboAuðkenni.Location = new System.Drawing.Point(283, 60);
            this.m_tboAuðkenni.Name = "m_tboAuðkenni";
            this.m_tboAuðkenni.Size = new System.Drawing.Size(333, 23);
            this.m_tboAuðkenni.TabIndex = 4;
            // 
            // m_lblTimabil
            // 
            this.m_lblTimabil.AutoSize = true;
            this.m_lblTimabil.Location = new System.Drawing.Point(137, 163);
            this.m_lblTimabil.Name = "m_lblTimabil";
            this.m_lblTimabil.Size = new System.Drawing.Size(73, 15);
            this.m_lblTimabil.TabIndex = 3;
            this.m_lblTimabil.Text = "Timabil 3.1.3";
            this.m_lblTimabil.Click += new System.EventHandler(this.m_lblTimabil_Click);
            // 
            // m_tboTimablil
            // 
            this.m_tboTimablil.Location = new System.Drawing.Point(283, 155);
            this.m_tboTimablil.Name = "m_tboTimablil";
            this.m_tboTimablil.Size = new System.Drawing.Size(333, 23);
            this.m_tboTimablil.TabIndex = 2;
            // 
            // m_lblTitilill
            // 
            this.m_lblTitilill.AutoSize = true;
            this.m_lblTitilill.Location = new System.Drawing.Point(137, 111);
            this.m_lblTitilill.Name = "m_lblTitilill";
            this.m_lblTitilill.Size = new System.Drawing.Size(56, 15);
            this.m_lblTitilill.TabIndex = 1;
            this.m_lblTitilill.Text = "Titill 3.1.2";
            this.m_lblTitilill.Click += new System.EventHandler(this.m_lblTitilill_Click);
            // 
            // m_tboTitill
            // 
            this.m_tboTitill.Location = new System.Drawing.Point(283, 108);
            this.m_tboTitill.Name = "m_tboTitill";
            this.m_tboTitill.Size = new System.Drawing.Size(333, 23);
            this.m_tboTitill.TabIndex = 0;
            // 
            // m_btnAddSubSerites
            // 
            this.m_btnAddSubSerites.Location = new System.Drawing.Point(647, 64);
            this.m_btnAddSubSerites.Name = "m_btnAddSubSerites";
            this.m_btnAddSubSerites.Size = new System.Drawing.Size(108, 23);
            this.m_btnAddSubSerites.TabIndex = 16;
            this.m_btnAddSubSerites.Text = "+Skjalaflokkur";
            this.m_btnAddSubSerites.UseVisualStyleBackColor = true;
            // 
            // m_btnAddFile
            // 
            this.m_btnAddFile.Location = new System.Drawing.Point(647, 108);
            this.m_btnAddFile.Name = "m_btnAddFile";
            this.m_btnAddFile.Size = new System.Drawing.Size(108, 23);
            this.m_btnAddFile.TabIndex = 17;
            this.m_btnAddFile.Text = "+Örk";
            this.m_btnAddFile.UseVisualStyleBackColor = true;
            // 
            // frmGeymsluskra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 753);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmGeymsluskra";
            this.Text = "frmGeymsluskra";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.m_grbGogn.ResumeLayout(false);
            this.m_grbGeymsluSkrá.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.m_grbYfirlitInnihald.ResumeLayout(false);
            this.m_grbYfirlitInnihald.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox m_grbGeymsluSkrá;
        private TreeView m_trwGeymsluskrá;
        private SplitContainer splitContainer2;
        private Button m_btnBuaTil;
        private SplitContainer splitContainer3;
        private GroupBox m_grbGogn;
        private TreeView m_trwGogn;
        private Label m_lblTitilill;
        private TextBox m_tboTitill;
        private Label m_lblAðgengi;
        private TextBox m_tboSkilyrðiAðgengi;
        private Label m_lblAuðkenni;
        private TextBox m_tboAuðkenni;
        private Label m_lblTimabil;
        private TextBox m_tboTimablil;
        private GroupBox m_grbYfirlitInnihald;
        private TextBox m_tboYfirilInnihald;
        private Label m_lblAfharNr;
        private TextBox m_tboAfhendingaarNr;
        private Label m_lblUpplysingastig;
        private TextBox m_tboUpplýsingastig;
        private Button m_btnDUStadfesta;
        private Label m_lblAthSkjalaVard;
        private TextBox m_tboAthSkjal;
        private Button m_btnVista;
        private Button m_btnEyda;
        private Button m_btnAddFile;
        private Button m_btnAddSubSerites;
    }
}