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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dtEnd = new System.Windows.Forms.DateTimePicker();
            this.m_dtpStart = new System.Windows.Forms.DateTimePicker();
            this.m_btnLeita = new System.Windows.Forms.Button();
            this.m_lblLeitarNidurstodur = new System.Windows.Forms.Label();
            this.m_tobLeitarord = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblSidaValinn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnAfrit = new System.Windows.Forms.Button();
            this.m_numUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_btnFrumRit = new System.Windows.Forms.Button();
            this.m_lblDagsetning = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.m_pibSkjal = new System.Windows.Forms.PictureBox();
            this.m_grbValdinnSkjol = new System.Windows.Forms.GroupBox();
            this.m_dgvValdarSkrar = new System.Windows.Forms.DataGridView();
            this.colAudkenniSkjals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitillSkjals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVorsluutgafa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pibSkjal)).BeginInit();
            this.m_grbValdinnSkjol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvValdarSkrar)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(1822, 931);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_trwFileSystem
            // 
            this.m_trwFileSystem.CheckBoxes = true;
            this.m_trwFileSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_trwFileSystem.Location = new System.Drawing.Point(0, 0);
            this.m_trwFileSystem.Name = "m_trwFileSystem";
            this.m_trwFileSystem.Size = new System.Drawing.Size(324, 931);
            this.m_trwFileSystem.TabIndex = 0;
            this.m_trwFileSystem.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_trwFileSystem_AfterCheck);
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
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.m_dtEnd);
            this.splitContainer2.Panel1.Controls.Add(this.m_dtpStart);
            this.splitContainer2.Panel1.Controls.Add(this.m_btnLeita);
            this.splitContainer2.Panel1.Controls.Add(this.m_lblLeitarNidurstodur);
            this.splitContainer2.Panel1.Controls.Add(this.m_tobLeitarord);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1494, 931);
            this.splitContainer2.SplitterDistance = 164;
            this.splitContainer2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Endadagsetning";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Upphafsdagsetning";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // m_dtEnd
            // 
            this.m_dtEnd.Checked = false;
            this.m_dtEnd.Location = new System.Drawing.Point(683, 79);
            this.m_dtEnd.Name = "m_dtEnd";
            this.m_dtEnd.ShowCheckBox = true;
            this.m_dtEnd.Size = new System.Drawing.Size(172, 23);
            this.m_dtEnd.TabIndex = 14;
            // 
            // m_dtpStart
            // 
            this.m_dtpStart.Checked = false;
            this.m_dtpStart.Location = new System.Drawing.Point(195, 84);
            this.m_dtpStart.Name = "m_dtpStart";
            this.m_dtpStart.ShowCheckBox = true;
            this.m_dtpStart.Size = new System.Drawing.Size(172, 23);
            this.m_dtpStart.TabIndex = 13;
            this.m_dtpStart.ValueChanged += new System.EventHandler(this.m_dtpStart_ValueChanged);
            // 
            // m_btnLeita
            // 
            this.m_btnLeita.Location = new System.Drawing.Point(881, 29);
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
            this.m_lblLeitarNidurstodur.Location = new System.Drawing.Point(39, 65);
            this.m_lblLeitarNidurstodur.Name = "m_lblLeitarNidurstodur";
            this.m_lblLeitarNidurstodur.Size = new System.Drawing.Size(38, 15);
            this.m_lblLeitarNidurstodur.TabIndex = 3;
            this.m_lblLeitarNidurstodur.Text = "label1";
            this.m_lblLeitarNidurstodur.Click += new System.EventHandler(this.m_lblLeitarNidurstodur_Click);
            // 
            // m_tobLeitarord
            // 
            this.m_tobLeitarord.Location = new System.Drawing.Point(39, 30);
            this.m_tobLeitarord.Name = "m_tobLeitarord";
            this.m_tobLeitarord.Size = new System.Drawing.Size(816, 23);
            this.m_tobLeitarord.TabIndex = 2;
            this.m_tobLeitarord.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_tobLeitarord_KeyUp);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.m_lblSidaValinn);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.m_btnAfrit);
            this.splitContainer3.Panel1.Controls.Add(this.m_numUpDown);
            this.splitContainer3.Panel1.Controls.Add(this.m_btnFrumRit);
            this.splitContainer3.Panel1.Controls.Add(this.m_lblDagsetning);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1494, 763);
            this.splitContainer3.SplitterDistance = 83;
            this.splitContainer3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(958, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // m_lblSidaValinn
            // 
            this.m_lblSidaValinn.AutoSize = true;
            this.m_lblSidaValinn.Location = new System.Drawing.Point(234, 30);
            this.m_lblSidaValinn.Name = "m_lblSidaValinn";
            this.m_lblSidaValinn.Size = new System.Drawing.Size(29, 15);
            this.m_lblSidaValinn.TabIndex = 3;
            this.m_lblSidaValinn.Text = "Siða";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Siða";
            // 
            // m_btnAfrit
            // 
            this.m_btnAfrit.Location = new System.Drawing.Point(518, 22);
            this.m_btnAfrit.Name = "m_btnAfrit";
            this.m_btnAfrit.Size = new System.Drawing.Size(150, 23);
            this.m_btnAfrit.TabIndex = 1;
            this.m_btnAfrit.Text = "Opna afrit";
            this.m_btnAfrit.UseVisualStyleBackColor = true;
            this.m_btnAfrit.Click += new System.EventHandler(this.m_btnAfrit_Click);
            // 
            // m_numUpDown
            // 
            this.m_numUpDown.Location = new System.Drawing.Point(170, 28);
            this.m_numUpDown.Name = "m_numUpDown";
            this.m_numUpDown.Size = new System.Drawing.Size(40, 23);
            this.m_numUpDown.TabIndex = 1;
            this.m_numUpDown.ValueChanged += new System.EventHandler(this.m_numUpDown_ValueChanged);
            // 
            // m_btnFrumRit
            // 
            this.m_btnFrumRit.Location = new System.Drawing.Point(318, 22);
            this.m_btnFrumRit.Name = "m_btnFrumRit";
            this.m_btnFrumRit.Size = new System.Drawing.Size(150, 23);
            this.m_btnFrumRit.TabIndex = 0;
            this.m_btnFrumRit.Text = "Opna frumrit";
            this.m_btnFrumRit.UseVisualStyleBackColor = true;
            this.m_btnFrumRit.Click += new System.EventHandler(this.m_btnFrumRit_Click);
            // 
            // m_lblDagsetning
            // 
            this.m_lblDagsetning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDagsetning.AutoSize = true;
            this.m_lblDagsetning.Location = new System.Drawing.Point(1229, 16);
            this.m_lblDagsetning.Name = "m_lblDagsetning";
            this.m_lblDagsetning.Size = new System.Drawing.Size(38, 15);
            this.m_lblDagsetning.TabIndex = 0;
            this.m_lblDagsetning.Text = "label1";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.m_pibSkjal);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.m_grbValdinnSkjol);
            this.splitContainer4.Size = new System.Drawing.Size(1494, 676);
            this.splitContainer4.SplitterDistance = 722;
            this.splitContainer4.TabIndex = 1;
            // 
            // m_pibSkjal
            // 
            this.m_pibSkjal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pibSkjal.Location = new System.Drawing.Point(0, 0);
            this.m_pibSkjal.Name = "m_pibSkjal";
            this.m_pibSkjal.Size = new System.Drawing.Size(722, 676);
            this.m_pibSkjal.TabIndex = 0;
            this.m_pibSkjal.TabStop = false;
            this.m_pibSkjal.DoubleClick += new System.EventHandler(this.m_pibSkjal_DoubleClick);
            // 
            // m_grbValdinnSkjol
            // 
            this.m_grbValdinnSkjol.Controls.Add(this.m_dgvValdarSkrar);
            this.m_grbValdinnSkjol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbValdinnSkjol.Location = new System.Drawing.Point(0, 0);
            this.m_grbValdinnSkjol.Name = "m_grbValdinnSkjol";
            this.m_grbValdinnSkjol.Size = new System.Drawing.Size(768, 676);
            this.m_grbValdinnSkjol.TabIndex = 1;
            this.m_grbValdinnSkjol.TabStop = false;
            this.m_grbValdinnSkjol.Text = "Skjöl valinn";
            // 
            // m_dgvValdarSkrar
            // 
            this.m_dgvValdarSkrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvValdarSkrar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAudkenniSkjals,
            this.colTitillSkjals,
            this.colVorsluutgafa});
            this.m_dgvValdarSkrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvValdarSkrar.Location = new System.Drawing.Point(3, 19);
            this.m_dgvValdarSkrar.Name = "m_dgvValdarSkrar";
            this.m_dgvValdarSkrar.RowHeadersVisible = false;
            this.m_dgvValdarSkrar.RowTemplate.Height = 25;
            this.m_dgvValdarSkrar.Size = new System.Drawing.Size(762, 654);
            this.m_dgvValdarSkrar.TabIndex = 0;
            // 
            // colAudkenniSkjals
            // 
            this.colAudkenniSkjals.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAudkenniSkjals.DataPropertyName = "skjalID";
            this.colAudkenniSkjals.HeaderText = "Auðkenni skjals";
            this.colAudkenniSkjals.Name = "colAudkenniSkjals";
            this.colAudkenniSkjals.Width = 114;
            // 
            // colTitillSkjals
            // 
            this.colTitillSkjals.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitillSkjals.DataPropertyName = "titill";
            this.colTitillSkjals.HeaderText = "Titill skjals";
            this.colTitillSkjals.Name = "colTitillSkjals";
            // 
            // colVorsluutgafa
            // 
            this.colVorsluutgafa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colVorsluutgafa.DataPropertyName = "vorsluutgafa";
            this.colVorsluutgafa.HeaderText = "Vörsluútgafa";
            this.colVorsluutgafa.Name = "colVorsluutgafa";
            this.colVorsluutgafa.Width = 98;
            // 
            // frmSkraarkerfi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1822, 931);
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
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDown)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pibSkjal)).EndInit();
            this.m_grbValdinnSkjol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvValdarSkrar)).EndInit();
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
        private Label m_lblDagsetning;
        private NumericUpDown m_numUpDown;
        private Label m_lblSidaValinn;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private DateTimePicker m_dtEnd;
        private DateTimePicker m_dtpStart;
        private SplitContainer splitContainer4;
        private DataGridView m_dgvValdarSkrar;
        private GroupBox m_grbValdinnSkjol;
        private DataGridViewTextBoxColumn colAudkenniSkjals;
        private DataGridViewTextBoxColumn colTitillSkjals;
        private DataGridViewTextBoxColumn colVorsluutgafa;
    }
}