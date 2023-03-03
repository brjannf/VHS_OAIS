namespace VHS_OAIS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_lblHeiti = new System.Windows.Forms.Label();
            this.m_lblModel = new System.Windows.Forms.Label();
            this.m_lblSerial = new System.Windows.Forms.Label();
            this.m_dgvDrives = new System.Windows.Forms.DataGridView();
            this.colDrifID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrifcomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrifNafn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cColDrifFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrifLaust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrifHeild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrifTegund = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrifFramleitt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrifVelja = new System.Windows.Forms.DataGridViewButtonColumn();
            this.m_grbDrif = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.button1 = new System.Windows.Forms.Button();
            this.m_grbOvirkDrif = new System.Windows.Forms.GroupBox();
            this.m_dgvDrifOvirk = new System.Windows.Forms.DataGridView();
            this.colVelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrivOvirktID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_lblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrives)).BeginInit();
            this.m_grbDrif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.m_grbOvirkDrif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrifOvirk)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // m_lblHeiti
            // 
            this.m_lblHeiti.AutoSize = true;
            this.m_lblHeiti.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblHeiti.Location = new System.Drawing.Point(102, 63);
            this.m_lblHeiti.Name = "m_lblHeiti";
            this.m_lblHeiti.Size = new System.Drawing.Size(65, 25);
            this.m_lblHeiti.TabIndex = 0;
            this.m_lblHeiti.Text = "label1";
            // 
            // m_lblModel
            // 
            this.m_lblModel.AutoSize = true;
            this.m_lblModel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblModel.Location = new System.Drawing.Point(102, 23);
            this.m_lblModel.Name = "m_lblModel";
            this.m_lblModel.Size = new System.Drawing.Size(65, 25);
            this.m_lblModel.TabIndex = 1;
            this.m_lblModel.Text = "label2";
            // 
            // m_lblSerial
            // 
            this.m_lblSerial.AutoSize = true;
            this.m_lblSerial.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblSerial.Location = new System.Drawing.Point(102, 106);
            this.m_lblSerial.Name = "m_lblSerial";
            this.m_lblSerial.Size = new System.Drawing.Size(65, 25);
            this.m_lblSerial.TabIndex = 2;
            this.m_lblSerial.Text = "label3";
            // 
            // m_dgvDrives
            // 
            this.m_dgvDrives.AllowUserToAddRows = false;
            this.m_dgvDrives.AllowUserToDeleteRows = false;
            this.m_dgvDrives.AllowUserToOrderColumns = true;
            this.m_dgvDrives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvDrives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDrifID,
            this.colDrifcomID,
            this.colDrifNafn,
            this.cColDrifFormat,
            this.colDrifLaust,
            this.colDrifHeild,
            this.colDrifTegund,
            this.colDrifFramleitt,
            this.colDrifVelja});
            this.m_dgvDrives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDrives.Location = new System.Drawing.Point(3, 19);
            this.m_dgvDrives.MultiSelect = false;
            this.m_dgvDrives.Name = "m_dgvDrives";
            this.m_dgvDrives.ReadOnly = true;
            this.m_dgvDrives.RowHeadersVisible = false;
            this.m_dgvDrives.RowTemplate.Height = 25;
            this.m_dgvDrives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvDrives.Size = new System.Drawing.Size(1030, 149);
            this.m_dgvDrives.TabIndex = 3;
            this.m_dgvDrives.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvDrives_CellDoubleClick);
            this.m_dgvDrives.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.m_dgvDrives_CellFormatting);
            this.m_dgvDrives.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_dgvDrives_KeyUp);
            // 
            // colDrifID
            // 
            this.colDrifID.DataPropertyName = "id";
            this.colDrifID.HeaderText = "ID drif";
            this.colDrifID.Name = "colDrifID";
            this.colDrifID.ReadOnly = true;
            this.colDrifID.Visible = false;
            // 
            // colDrifcomID
            // 
            this.colDrifcomID.HeaderText = "Auðkenni vélar";
            this.colDrifcomID.Name = "colDrifcomID";
            this.colDrifcomID.ReadOnly = true;
            // 
            // colDrifNafn
            // 
            this.colDrifNafn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDrifNafn.DataPropertyName = "nafn";
            this.colDrifNafn.HeaderText = "Rótarmappa";
            this.colDrifNafn.Name = "colDrifNafn";
            this.colDrifNafn.ReadOnly = true;
            // 
            // cColDrifFormat
            // 
            this.cColDrifFormat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cColDrifFormat.DataPropertyName = "format";
            this.cColDrifFormat.HeaderText = "Format";
            this.cColDrifFormat.Name = "cColDrifFormat";
            this.cColDrifFormat.ReadOnly = true;
            this.cColDrifFormat.Width = 70;
            // 
            // colDrifLaust
            // 
            this.colDrifLaust.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDrifLaust.DataPropertyName = "laust";
            this.colDrifLaust.HeaderText = "Laust pláss";
            this.colDrifLaust.Name = "colDrifLaust";
            this.colDrifLaust.ReadOnly = true;
            this.colDrifLaust.Width = 82;
            // 
            // colDrifHeild
            // 
            this.colDrifHeild.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDrifHeild.DataPropertyName = "heild";
            this.colDrifHeild.HeaderText = "Heildarstærð";
            this.colDrifHeild.Name = "colDrifHeild";
            this.colDrifHeild.ReadOnly = true;
            // 
            // colDrifTegund
            // 
            this.colDrifTegund.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDrifTegund.DataPropertyName = "tegund";
            this.colDrifTegund.HeaderText = "Hlutverk drifs";
            this.colDrifTegund.Name = "colDrifTegund";
            this.colDrifTegund.ReadOnly = true;
            this.colDrifTegund.Width = 95;
            // 
            // colDrifFramleitt
            // 
            this.colDrifFramleitt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDrifFramleitt.DataPropertyName = "framleitt";
            this.colDrifFramleitt.HeaderText = "Framleiðsludagsetning";
            this.colDrifFramleitt.Name = "colDrifFramleitt";
            this.colDrifFramleitt.ReadOnly = true;
            this.colDrifFramleitt.Width = 152;
            // 
            // colDrifVelja
            // 
            this.colDrifVelja.HeaderText = "Velja rótarmöppu";
            this.colDrifVelja.Name = "colDrifVelja";
            this.colDrifVelja.ReadOnly = true;
            this.colDrifVelja.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // m_grbDrif
            // 
            this.m_grbDrif.Controls.Add(this.m_dgvDrives);
            this.m_grbDrif.Location = new System.Drawing.Point(88, 175);
            this.m_grbDrif.Name = "m_grbDrif";
            this.m_grbDrif.Size = new System.Drawing.Size(1036, 171);
            this.m_grbDrif.TabIndex = 4;
            this.m_grbDrif.TabStop = false;
            this.m_grbDrif.Text = "Virk drif";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Deleted);
            this.fileSystemWatcher1.Error += new System.IO.ErrorEventHandler(this.fileSystemWatcher1_Error);
            this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.IncludeSubdirectories = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            this.fileSystemWatcher2.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher2.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            this.fileSystemWatcher2.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Deleted);
            this.fileSystemWatcher2.Error += new System.IO.ErrorEventHandler(this.fileSystemWatcher1_Error);
            this.fileSystemWatcher2.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1173, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_grbOvirkDrif
            // 
            this.m_grbOvirkDrif.Controls.Add(this.m_dgvDrifOvirk);
            this.m_grbOvirkDrif.Location = new System.Drawing.Point(88, 379);
            this.m_grbOvirkDrif.Name = "m_grbOvirkDrif";
            this.m_grbOvirkDrif.Size = new System.Drawing.Size(1036, 171);
            this.m_grbOvirkDrif.TabIndex = 5;
            this.m_grbOvirkDrif.TabStop = false;
            this.m_grbOvirkDrif.Text = "Óvirk drif";
            this.m_grbOvirkDrif.Visible = false;
            // 
            // m_dgvDrifOvirk
            // 
            this.m_dgvDrifOvirk.AllowUserToAddRows = false;
            this.m_dgvDrifOvirk.AllowUserToDeleteRows = false;
            this.m_dgvDrifOvirk.AllowUserToOrderColumns = true;
            this.m_dgvDrifOvirk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvDrifOvirk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVelID,
            this.colDrivOvirktID,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.m_dgvDrifOvirk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvDrifOvirk.Location = new System.Drawing.Point(3, 19);
            this.m_dgvDrifOvirk.Name = "m_dgvDrifOvirk";
            this.m_dgvDrifOvirk.ReadOnly = true;
            this.m_dgvDrifOvirk.RowHeadersVisible = false;
            this.m_dgvDrifOvirk.RowTemplate.Height = 25;
            this.m_dgvDrifOvirk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvDrifOvirk.Size = new System.Drawing.Size(1030, 149);
            this.m_dgvDrifOvirk.TabIndex = 3;
            this.m_dgvDrifOvirk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_dgvDrifOvirk_KeyUp);
            // 
            // colVelID
            // 
            this.colVelID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colVelID.DataPropertyName = "comID";
            this.colVelID.HeaderText = "Auðkenni vélar";
            this.colVelID.Name = "colVelID";
            this.colVelID.ReadOnly = true;
            this.colVelID.Width = 111;
            // 
            // colDrivOvirktID
            // 
            this.colDrivOvirktID.DataPropertyName = "id";
            this.colDrivOvirktID.HeaderText = "ID drif";
            this.colDrivOvirktID.Name = "colDrivOvirktID";
            this.colDrivOvirktID.ReadOnly = true;
            this.colDrivOvirktID.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "nafn";
            this.dataGridViewTextBoxColumn1.HeaderText = "Rótarmappa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "format";
            this.dataGridViewTextBoxColumn2.HeaderText = "Format";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "laust";
            this.dataGridViewTextBoxColumn3.HeaderText = "Laust pláss";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 82;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "heild";
            this.dataGridViewTextBoxColumn4.HeaderText = "Heildarstærð";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "tegund";
            this.dataGridViewTextBoxColumn5.HeaderText = "Hlutverk drifs";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 95;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "framleitt";
            this.dataGridViewTextBoxColumn6.HeaderText = "Framleiðsludagsetning";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 152;
            // 
            // m_lblID
            // 
            this.m_lblID.AutoSize = true;
            this.m_lblID.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_lblID.Location = new System.Drawing.Point(102, 147);
            this.m_lblID.Name = "m_lblID";
            this.m_lblID.Size = new System.Drawing.Size(65, 25);
            this.m_lblID.TabIndex = 6;
            this.m_lblID.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 736);
            this.Controls.Add(this.m_lblID);
            this.Controls.Add(this.m_grbOvirkDrif);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_grbDrif);
            this.Controls.Add(this.m_lblSerial);
            this.Controls.Add(this.m_lblModel);
            this.Controls.Add(this.m_lblHeiti);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrives)).EndInit();
            this.m_grbDrif.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            this.m_grbOvirkDrif.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvDrifOvirk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon notifyIcon1;
        private Label m_lblHeiti;
        private Label m_lblModel;
        private Label m_lblSerial;
        private DataGridView m_dgvDrives;
        private GroupBox m_grbDrif;
        private FolderBrowserDialog folderBrowserDialog1;
        private FileSystemWatcher fileSystemWatcher1;
        private FileSystemWatcher fileSystemWatcher2;
        private Button button1;
        private GroupBox m_grbOvirkDrif;
        private DataGridView m_dgvDrifOvirk;
        private DataGridViewTextBoxColumn colDrifID;
        private DataGridViewTextBoxColumn colDrifcomID;
        private DataGridViewTextBoxColumn colDrifNafn;
        private DataGridViewTextBoxColumn cColDrifFormat;
        private DataGridViewTextBoxColumn colDrifLaust;
        private DataGridViewTextBoxColumn colDrifHeild;
        private DataGridViewTextBoxColumn colDrifTegund;
        private DataGridViewTextBoxColumn colDrifFramleitt;
        private DataGridViewButtonColumn colDrifVelja;
        private DataGridViewTextBoxColumn colVelID;
        private DataGridViewTextBoxColumn colDrivOvirktID;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private Label m_lblID;
    }
}