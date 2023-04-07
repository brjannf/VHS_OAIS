namespace OAIS_ADMIN
{
    partial class uscGeymsluMidlar
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
            this.m_dgvDrif = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLaust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTegund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFramleitt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVirk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colbtnOpna = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colbtnSkoda = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_grbTolvur = new System.Windows.Forms.GroupBox();
            this.m_trwTolvur = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_lblDate = new System.Windows.Forms.Label();
            this.m_lblID = new System.Windows.Forms.Label();
            this.m_lblSerial = new System.Windows.Forms.Label();
            this.m_lblModel = new System.Windows.Forms.Label();
            this.m_lblHeiti = new System.Windows.Forms.Label();
            this.m_grbDrif = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_grbTolvur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.m_grbDrif.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dgvDrif
            // 
            this.m_dgvDrif.AllowUserToAddRows = false;
            this.m_dgvDrif.AllowUserToDeleteRows = false;
            this.m_dgvDrif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvDrif.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colComID,
            this.colSlod,
            this.colFormat,
            this.colNotad,
            this.colLaust,
            this.colHeild,
            this.colTegund,
            this.colFramleitt,
            this.colVirk,
            this.colbtnOpna,
            this.colbtnSkoda});
            this.m_dgvDrif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDrif.Location = new System.Drawing.Point(3, 25);
            this.m_dgvDrif.Name = "m_dgvDrif";
            this.m_dgvDrif.ReadOnly = true;
            this.m_dgvDrif.RowHeadersVisible = false;
            this.m_dgvDrif.RowTemplate.Height = 25;
            this.m_dgvDrif.Size = new System.Drawing.Size(918, 102);
            this.m_dgvDrif.TabIndex = 0;
            this.m_dgvDrif.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrif_CellClick);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "id";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colComID
            // 
            this.colComID.DataPropertyName = "comId";
            this.colComID.HeaderText = "comID";
            this.colComID.Name = "colComID";
            this.colComID.ReadOnly = true;
            this.colComID.Visible = false;
            // 
            // colSlod
            // 
            this.colSlod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSlod.DataPropertyName = "nafn";
            this.colSlod.HeaderText = "Slóð á vörsluútgáfur";
            this.colSlod.Name = "colSlod";
            this.colSlod.ReadOnly = true;
            // 
            // colFormat
            // 
            this.colFormat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFormat.DataPropertyName = "format";
            this.colFormat.HeaderText = "Format drifs";
            this.colFormat.Name = "colFormat";
            this.colFormat.ReadOnly = true;
            this.colFormat.Width = 114;
            // 
            // colNotad
            // 
            this.colNotad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNotad.DataPropertyName = "notad";
            this.colNotad.HeaderText = "Svæði notað";
            this.colNotad.Name = "colNotad";
            this.colNotad.ReadOnly = true;
            this.colNotad.Width = 114;
            // 
            // colLaust
            // 
            this.colLaust.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLaust.DataPropertyName = "laust";
            this.colLaust.HeaderText = "Laust svæði";
            this.colLaust.Name = "colLaust";
            this.colLaust.ReadOnly = true;
            this.colLaust.Width = 108;
            // 
            // colHeild
            // 
            this.colHeild.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHeild.DataPropertyName = "heild";
            this.colHeild.HeaderText = "Heildarstærð";
            this.colHeild.Name = "colHeild";
            this.colHeild.ReadOnly = true;
            this.colHeild.Width = 129;
            // 
            // colTegund
            // 
            this.colTegund.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTegund.DataPropertyName = "tegund";
            this.colTegund.HeaderText = "Tegund drifs";
            this.colTegund.Name = "colTegund";
            this.colTegund.ReadOnly = true;
            this.colTegund.Width = 115;
            // 
            // colFramleitt
            // 
            this.colFramleitt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFramleitt.DataPropertyName = "framleitt";
            this.colFramleitt.HeaderText = "Framleiðsludagsetning";
            this.colFramleitt.Name = "colFramleitt";
            this.colFramleitt.ReadOnly = true;
            this.colFramleitt.Width = 199;
            // 
            // colVirk
            // 
            this.colVirk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colVirk.DataPropertyName = "virk";
            this.colVirk.HeaderText = "Virkt";
            this.colVirk.Name = "colVirk";
            this.colVirk.ReadOnly = true;
            this.colVirk.Width = 50;
            // 
            // colbtnOpna
            // 
            this.colbtnOpna.HeaderText = "Opna drif";
            this.colbtnOpna.Name = "colbtnOpna";
            this.colbtnOpna.ReadOnly = true;
            this.colbtnOpna.Text = "Opna";
            this.colbtnOpna.UseColumnTextForButtonValue = true;
            // 
            // colbtnSkoda
            // 
            this.colbtnSkoda.HeaderText = "Skoða logg";
            this.colbtnSkoda.Name = "colbtnSkoda";
            this.colbtnSkoda.ReadOnly = true;
            this.colbtnSkoda.Text = "Skoða";
            this.colbtnSkoda.UseColumnTextForButtonValue = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_grbTolvur);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1397, 743);
            this.splitContainer1.SplitterDistance = 465;
            this.splitContainer1.TabIndex = 2;
            // 
            // m_grbTolvur
            // 
            this.m_grbTolvur.Controls.Add(this.m_trwTolvur);
            this.m_grbTolvur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbTolvur.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_grbTolvur.Location = new System.Drawing.Point(0, 0);
            this.m_grbTolvur.Name = "m_grbTolvur";
            this.m_grbTolvur.Size = new System.Drawing.Size(461, 739);
            this.m_grbTolvur.TabIndex = 1;
            this.m_grbTolvur.TabStop = false;
            this.m_grbTolvur.Text = "Tölvubúnaður";
            // 
            // m_trwTolvur
            // 
            this.m_trwTolvur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trwTolvur.Location = new System.Drawing.Point(3, 19);
            this.m_trwTolvur.Name = "m_trwTolvur";
            this.m_trwTolvur.Size = new System.Drawing.Size(455, 717);
            this.m_trwTolvur.TabIndex = 0;
            this.m_trwTolvur.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trwTolvur_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_lblDate);
            this.splitContainer2.Panel1.Controls.Add(this.m_lblID);
            this.splitContainer2.Panel1.Controls.Add(this.m_lblSerial);
            this.splitContainer2.Panel1.Controls.Add(this.m_lblModel);
            this.splitContainer2.Panel1.Controls.Add(this.m_lblHeiti);
            this.splitContainer2.Panel1.Controls.Add(this.m_grbDrif);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button1);
            this.splitContainer2.Size = new System.Drawing.Size(928, 743);
            this.splitContainer2.SplitterDistance = 359;
            this.splitContainer2.TabIndex = 2;
            // 
            // m_lblDate
            // 
            this.m_lblDate.AutoSize = true;
            this.m_lblDate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblDate.Location = new System.Drawing.Point(57, 184);
            this.m_lblDate.Name = "m_lblDate";
            this.m_lblDate.Size = new System.Drawing.Size(65, 25);
            this.m_lblDate.TabIndex = 11;
            this.m_lblDate.Text = "label3";
            // 
            // m_lblID
            // 
            this.m_lblID.AutoSize = true;
            this.m_lblID.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblID.Location = new System.Drawing.Point(57, 225);
            this.m_lblID.Name = "m_lblID";
            this.m_lblID.Size = new System.Drawing.Size(65, 25);
            this.m_lblID.TabIndex = 10;
            this.m_lblID.Text = "label2";
            // 
            // m_lblSerial
            // 
            this.m_lblSerial.AutoSize = true;
            this.m_lblSerial.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblSerial.Location = new System.Drawing.Point(57, 137);
            this.m_lblSerial.Name = "m_lblSerial";
            this.m_lblSerial.Size = new System.Drawing.Size(65, 25);
            this.m_lblSerial.TabIndex = 9;
            this.m_lblSerial.Text = "label3";
            // 
            // m_lblModel
            // 
            this.m_lblModel.AutoSize = true;
            this.m_lblModel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblModel.Location = new System.Drawing.Point(57, 54);
            this.m_lblModel.Name = "m_lblModel";
            this.m_lblModel.Size = new System.Drawing.Size(65, 25);
            this.m_lblModel.TabIndex = 8;
            this.m_lblModel.Text = "label2";
            // 
            // m_lblHeiti
            // 
            this.m_lblHeiti.AutoSize = true;
            this.m_lblHeiti.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblHeiti.Location = new System.Drawing.Point(57, 94);
            this.m_lblHeiti.Name = "m_lblHeiti";
            this.m_lblHeiti.Size = new System.Drawing.Size(65, 25);
            this.m_lblHeiti.TabIndex = 7;
            this.m_lblHeiti.Text = "label1";
            // 
            // m_grbDrif
            // 
            this.m_grbDrif.Controls.Add(this.m_dgvDrif);
            this.m_grbDrif.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_grbDrif.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_grbDrif.Location = new System.Drawing.Point(0, 225);
            this.m_grbDrif.Name = "m_grbDrif";
            this.m_grbDrif.Size = new System.Drawing.Size(924, 130);
            this.m_grbDrif.TabIndex = 1;
            this.m_grbDrif.TabStop = false;
            this.m_grbDrif.Text = "Drif";
            // 
            // uscGeymsluMidlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "uscGeymsluMidlar";
            this.Size = new System.Drawing.Size(1397, 743);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrif)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.m_grbTolvur.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.m_grbDrif.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView m_dgvDrif;
        private Button button1;
        private SplitContainer splitContainer1;
        private TreeView m_trwTolvur;
        private GroupBox m_grbTolvur;
        private SplitContainer splitContainer2;
        private GroupBox m_grbDrif;
        private Label m_lblID;
        private Label m_lblSerial;
        private Label m_lblModel;
        private Label m_lblHeiti;
        private Label m_lblDate;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colComID;
        private DataGridViewTextBoxColumn colSlod;
        private DataGridViewTextBoxColumn colFormat;
        private DataGridViewTextBoxColumn colNotad;
        private DataGridViewTextBoxColumn colLaust;
        private DataGridViewTextBoxColumn colHeild;
        private DataGridViewTextBoxColumn colTegund;
        private DataGridViewTextBoxColumn colFramleitt;
        private DataGridViewCheckBoxColumn colVirk;
        private DataGridViewButtonColumn colbtnOpna;
        private DataGridViewButtonColumn colbtnSkoda;
    }
}
