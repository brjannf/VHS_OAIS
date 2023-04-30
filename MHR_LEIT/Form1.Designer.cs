namespace MHR_LEIT
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtEnd = new System.Windows.Forms.DateTimePicker();
            this.m_dtpStart = new System.Windows.Forms.DateTimePicker();
            this.m_comSkjalamyndari = new System.Windows.Forms.ComboBox();
            this.m_comVorslustofnun = new System.Windows.Forms.ComboBox();
            this.m_lblLeitarnidurstodur = new System.Windows.Forms.Label();
            this.m_btnLeita = new System.Windows.Forms.Button();
            this.m_tboLeitOrd = new System.Windows.Forms.TextBox();
            this.m_dgvLeit = new System.Windows.Forms.DataGridView();
            this.coltitillvorsluUtgafu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocTitel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastWriten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInnhaldSkjals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkjalamyndari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVorslustsofnun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGagnaGrunnur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_btnHreinsa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvLeit)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_btnHreinsa);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.m_dtEnd);
            this.splitContainer1.Panel1.Controls.Add(this.m_dtpStart);
            this.splitContainer1.Panel1.Controls.Add(this.m_comSkjalamyndari);
            this.splitContainer1.Panel1.Controls.Add(this.m_comVorslustofnun);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblLeitarnidurstodur);
            this.splitContainer1.Panel1.Controls.Add(this.m_btnLeita);
            this.splitContainer1.Panel1.Controls.Add(this.m_tboLeitOrd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvLeit);
            this.splitContainer1.Size = new System.Drawing.Size(1319, 629);
            this.splitContainer1.SplitterDistance = 125;
            this.splitContainer1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Endadagsetning";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Upphafsdagsetning";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(747, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Skjalamyndari";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(747, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vörslustofnun";
            // 
            // m_dtEnd
            // 
            this.m_dtEnd.Checked = false;
            this.m_dtEnd.Location = new System.Drawing.Point(546, 87);
            this.m_dtEnd.Name = "m_dtEnd";
            this.m_dtEnd.ShowCheckBox = true;
            this.m_dtEnd.Size = new System.Drawing.Size(172, 23);
            this.m_dtEnd.TabIndex = 6;
            // 
            // m_dtpStart
            // 
            this.m_dtpStart.Checked = false;
            this.m_dtpStart.Location = new System.Drawing.Point(180, 84);
            this.m_dtpStart.Name = "m_dtpStart";
            this.m_dtpStart.ShowCheckBox = true;
            this.m_dtpStart.Size = new System.Drawing.Size(172, 23);
            this.m_dtpStart.TabIndex = 5;
            // 
            // m_comSkjalamyndari
            // 
            this.m_comSkjalamyndari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comSkjalamyndari.FormattingEnabled = true;
            this.m_comSkjalamyndari.Location = new System.Drawing.Point(847, 87);
            this.m_comSkjalamyndari.Name = "m_comSkjalamyndari";
            this.m_comSkjalamyndari.Size = new System.Drawing.Size(295, 23);
            this.m_comSkjalamyndari.TabIndex = 4;
            // 
            // m_comVorslustofnun
            // 
            this.m_comVorslustofnun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comVorslustofnun.FormattingEnabled = true;
            this.m_comVorslustofnun.Location = new System.Drawing.Point(847, 58);
            this.m_comVorslustofnun.Name = "m_comVorslustofnun";
            this.m_comVorslustofnun.Size = new System.Drawing.Size(295, 23);
            this.m_comVorslustofnun.TabIndex = 3;
            // 
            // m_lblLeitarnidurstodur
            // 
            this.m_lblLeitarnidurstodur.AutoSize = true;
            this.m_lblLeitarnidurstodur.Location = new System.Drawing.Point(53, 58);
            this.m_lblLeitarnidurstodur.Name = "m_lblLeitarnidurstodur";
            this.m_lblLeitarnidurstodur.Size = new System.Drawing.Size(38, 15);
            this.m_lblLeitarnidurstodur.TabIndex = 2;
            this.m_lblLeitarnidurstodur.Text = "label1";
            this.m_lblLeitarnidurstodur.Visible = false;
            // 
            // m_btnLeita
            // 
            this.m_btnLeita.Location = new System.Drawing.Point(1148, 22);
            this.m_btnLeita.Name = "m_btnLeita";
            this.m_btnLeita.Size = new System.Drawing.Size(75, 23);
            this.m_btnLeita.TabIndex = 1;
            this.m_btnLeita.Text = "Leita";
            this.m_btnLeita.UseVisualStyleBackColor = true;
            this.m_btnLeita.Click += new System.EventHandler(this.m_btnLeita_Click);
            // 
            // m_tboLeitOrd
            // 
            this.m_tboLeitOrd.Location = new System.Drawing.Point(53, 22);
            this.m_tboLeitOrd.Name = "m_tboLeitOrd";
            this.m_tboLeitOrd.Size = new System.Drawing.Size(1089, 23);
            this.m_tboLeitOrd.TabIndex = 0;
            this.m_tboLeitOrd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tboLeitOrd_KeyDown);
            // 
            // m_dgvLeit
            // 
            this.m_dgvLeit.AllowUserToAddRows = false;
            this.m_dgvLeit.AllowUserToDeleteRows = false;
            this.m_dgvLeit.AllowUserToOrderColumns = true;
            this.m_dgvLeit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvLeit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coltitillvorsluUtgafu,
            this.colDocTitel,
            this.colLastWriten,
            this.colMal,
            this.colInnhaldSkjals,
            this.colSkjalamyndari,
            this.colVorslustsofnun,
            this.colGagnaGrunnur,
            this.colDocID});
            this.m_dgvLeit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvLeit.Location = new System.Drawing.Point(0, 0);
            this.m_dgvLeit.Name = "m_dgvLeit";
            this.m_dgvLeit.ReadOnly = true;
            this.m_dgvLeit.RowHeadersVisible = false;
            this.m_dgvLeit.RowTemplate.Height = 25;
            this.m_dgvLeit.Size = new System.Drawing.Size(1319, 500);
            this.m_dgvLeit.TabIndex = 0;
            this.m_dgvLeit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvLeit_CellClick);
            // 
            // coltitillvorsluUtgafu
            // 
            this.coltitillvorsluUtgafu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.coltitillvorsluUtgafu.DataPropertyName = "titill_vorsluutgafu";
            this.coltitillvorsluUtgafu.HeaderText = "Titill vörsluútgáfu";
            this.coltitillvorsluUtgafu.Name = "coltitillvorsluUtgafu";
            this.coltitillvorsluUtgafu.ReadOnly = true;
            this.coltitillvorsluUtgafu.Width = 114;
            // 
            // colDocTitel
            // 
            this.colDocTitel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDocTitel.DataPropertyName = "doctitill";
            this.colDocTitel.HeaderText = "Titill skjals";
            this.colDocTitel.Name = "colDocTitel";
            this.colDocTitel.ReadOnly = true;
            this.colDocTitel.Width = 79;
            // 
            // colLastWriten
            // 
            this.colLastWriten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLastWriten.DataPropertyName = "docLastWriten";
            this.colLastWriten.HeaderText = "Síðast breytt";
            this.colLastWriten.Name = "colLastWriten";
            this.colLastWriten.ReadOnly = true;
            this.colLastWriten.Width = 89;
            // 
            // colMal
            // 
            this.colMal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMal.DataPropertyName = "maltitill";
            this.colMal.HeaderText = "Málalykill";
            this.colMal.Name = "colMal";
            this.colMal.ReadOnly = true;
            this.colMal.Width = 82;
            // 
            // colInnhaldSkjals
            // 
            this.colInnhaldSkjals.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInnhaldSkjals.DataPropertyName = "docInnihald";
            this.colInnhaldSkjals.HeaderText = "Innihald skjals";
            this.colInnhaldSkjals.Name = "colInnhaldSkjals";
            this.colInnhaldSkjals.ReadOnly = true;
            // 
            // colSkjalamyndari
            // 
            this.colSkjalamyndari.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSkjalamyndari.DataPropertyName = "skjalamyndari_heiti";
            this.colSkjalamyndari.HeaderText = "Skjalamyndari";
            this.colSkjalamyndari.Name = "colSkjalamyndari";
            this.colSkjalamyndari.ReadOnly = true;
            this.colSkjalamyndari.Width = 106;
            // 
            // colVorslustsofnun
            // 
            this.colVorslustsofnun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colVorslustsofnun.DataPropertyName = "vorslustofnun_heiti";
            this.colVorslustsofnun.HeaderText = "Vörslustofnun";
            this.colVorslustsofnun.Name = "colVorslustsofnun";
            this.colVorslustsofnun.ReadOnly = true;
            this.colVorslustsofnun.Width = 105;
            // 
            // colGagnaGrunnur
            // 
            this.colGagnaGrunnur.DataPropertyName = "heiti_gagangrunns";
            this.colGagnaGrunnur.HeaderText = "Gagnagrunnur";
            this.colGagnaGrunnur.Name = "colGagnaGrunnur";
            this.colGagnaGrunnur.ReadOnly = true;
            this.colGagnaGrunnur.Visible = false;
            // 
            // colDocID
            // 
            this.colDocID.DataPropertyName = "documentid";
            this.colDocID.HeaderText = "Auðkenni skjals";
            this.colDocID.Name = "colDocID";
            this.colDocID.ReadOnly = true;
            this.colDocID.Visible = false;
            // 
            // m_btnHreinsa
            // 
            this.m_btnHreinsa.Location = new System.Drawing.Point(1229, 22);
            this.m_btnHreinsa.Name = "m_btnHreinsa";
            this.m_btnHreinsa.Size = new System.Drawing.Size(75, 23);
            this.m_btnHreinsa.TabIndex = 11;
            this.m_btnHreinsa.Text = "Hreinsa";
            this.m_btnHreinsa.UseVisualStyleBackColor = true;
            this.m_btnHreinsa.Click += new System.EventHandler(this.m_btnHreinsa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 629);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvLeit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Button m_btnLeita;
        private TextBox m_tboLeitOrd;
        private DataGridView m_dgvLeit;
        private Label m_lblLeitarnidurstodur;
        private DataGridViewTextBoxColumn coltitillvorsluUtgafu;
        private DataGridViewTextBoxColumn colDocTitel;
        private DataGridViewTextBoxColumn colLastWriten;
        private DataGridViewTextBoxColumn colMal;
        private DataGridViewTextBoxColumn colInnhaldSkjals;
        private DataGridViewTextBoxColumn colSkjalamyndari;
        private DataGridViewTextBoxColumn colVorslustsofnun;
        private DataGridViewTextBoxColumn colGagnaGrunnur;
        private DataGridViewTextBoxColumn colDocID;
        private DateTimePicker m_dtEnd;
        private DateTimePicker m_dtpStart;
        private ComboBox m_comSkjalamyndari;
        private ComboBox m_comVorslustofnun;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button m_btnHreinsa;
    }
}