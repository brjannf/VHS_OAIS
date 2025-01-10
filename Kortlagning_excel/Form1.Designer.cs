namespace Kortlagning_excel
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
            m_btnOpnaExcel = new Button();
            openFileDialog1 = new OpenFileDialog();
            m_dgvExcelSkjal = new DataGridView();
            splitContainer1 = new SplitContainer();
            m_lblPublish = new Label();
            m_prbPublish = new ProgressBar();
            m_btnUppfaeraBirtingu = new Button();
            m_btnAthBreytingar = new Button();
            m_btnVista = new Button();
            m_lblMySQL = new Label();
            m_lblExcell = new Label();
            m_lblUpdate = new Label();
            m_lblHeradsSkjalaSafn = new Label();
            splitContainer2 = new SplitContainer();
            m_dgvMappaSkjol = new DataGridView();
            colTakkar = new DataGridViewButtonColumn();
            colSlod = new DataGridViewTextBoxColumn();
            m_btnOpnaAllt = new Button();
            ((System.ComponentModel.ISupportInitialize)m_dgvExcelSkjal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_dgvMappaSkjol).BeginInit();
            SuspendLayout();
            // 
            // m_btnOpnaExcel
            // 
            m_btnOpnaExcel.Location = new Point(524, 76);
            m_btnOpnaExcel.Name = "m_btnOpnaExcel";
            m_btnOpnaExcel.Size = new Size(75, 23);
            m_btnOpnaExcel.TabIndex = 0;
            m_btnOpnaExcel.Text = "Flytja inn";
            m_btnOpnaExcel.UseVisualStyleBackColor = true;
            m_btnOpnaExcel.Click += m_btnOpnaExcel_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // m_dgvExcelSkjal
            // 
            m_dgvExcelSkjal.AllowUserToAddRows = false;
            m_dgvExcelSkjal.AllowUserToDeleteRows = false;
            m_dgvExcelSkjal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvExcelSkjal.Dock = DockStyle.Fill;
            m_dgvExcelSkjal.Location = new Point(0, 0);
            m_dgvExcelSkjal.Name = "m_dgvExcelSkjal";
            m_dgvExcelSkjal.RowHeadersVisible = false;
            m_dgvExcelSkjal.Size = new Size(976, 392);
            m_dgvExcelSkjal.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(m_btnOpnaAllt);
            splitContainer1.Panel1.Controls.Add(m_lblPublish);
            splitContainer1.Panel1.Controls.Add(m_prbPublish);
            splitContainer1.Panel1.Controls.Add(m_btnUppfaeraBirtingu);
            splitContainer1.Panel1.Controls.Add(m_btnAthBreytingar);
            splitContainer1.Panel1.Controls.Add(m_btnVista);
            splitContainer1.Panel1.Controls.Add(m_lblMySQL);
            splitContainer1.Panel1.Controls.Add(m_lblExcell);
            splitContainer1.Panel1.Controls.Add(m_lblUpdate);
            splitContainer1.Panel1.Controls.Add(m_lblHeradsSkjalaSafn);
            splitContainer1.Panel1.Controls.Add(m_btnOpnaExcel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1284, 535);
            splitContainer1.SplitterDistance = 139;
            splitContainer1.TabIndex = 2;
            // 
            // m_lblPublish
            // 
            m_lblPublish.AutoSize = true;
            m_lblPublish.Location = new Point(785, 109);
            m_lblPublish.Name = "m_lblPublish";
            m_lblPublish.Size = new Size(38, 15);
            m_lblPublish.TabIndex = 9;
            m_lblPublish.Text = "label1";
            // 
            // m_prbPublish
            // 
            m_prbPublish.Location = new Point(632, 105);
            m_prbPublish.Name = "m_prbPublish";
            m_prbPublish.Size = new Size(138, 23);
            m_prbPublish.TabIndex = 8;
            // 
            // m_btnUppfaeraBirtingu
            // 
            m_btnUppfaeraBirtingu.Location = new Point(444, 105);
            m_btnUppfaeraBirtingu.Name = "m_btnUppfaeraBirtingu";
            m_btnUppfaeraBirtingu.Size = new Size(155, 23);
            m_btnUppfaeraBirtingu.TabIndex = 7;
            m_btnUppfaeraBirtingu.Text = "Uppfæra birtingu";
            m_btnUppfaeraBirtingu.UseVisualStyleBackColor = true;
            m_btnUppfaeraBirtingu.Click += m_btnUppfaeraBirtingu_Click;
            // 
            // m_btnAthBreytingar
            // 
            m_btnAthBreytingar.Location = new Point(444, 14);
            m_btnAthBreytingar.Name = "m_btnAthBreytingar";
            m_btnAthBreytingar.Size = new Size(155, 23);
            m_btnAthBreytingar.TabIndex = 6;
            m_btnAthBreytingar.Text = "Athuga með breytingar";
            m_btnAthBreytingar.UseVisualStyleBackColor = true;
            m_btnAthBreytingar.Click += m_btnAthBreytingar_Click;
            // 
            // m_btnVista
            // 
            m_btnVista.Location = new Point(524, 47);
            m_btnVista.Name = "m_btnVista";
            m_btnVista.Size = new Size(75, 23);
            m_btnVista.TabIndex = 5;
            m_btnVista.Text = "Vista";
            m_btnVista.UseVisualStyleBackColor = true;
            m_btnVista.Click += m_btnVista_Click;
            // 
            // m_lblMySQL
            // 
            m_lblMySQL.AutoSize = true;
            m_lblMySQL.Location = new Point(58, 103);
            m_lblMySQL.Name = "m_lblMySQL";
            m_lblMySQL.Size = new Size(38, 15);
            m_lblMySQL.TabIndex = 4;
            m_lblMySQL.Text = "label1";
            // 
            // m_lblExcell
            // 
            m_lblExcell.AutoSize = true;
            m_lblExcell.Location = new Point(58, 76);
            m_lblExcell.Name = "m_lblExcell";
            m_lblExcell.Size = new Size(38, 15);
            m_lblExcell.TabIndex = 3;
            m_lblExcell.Text = "label1";
            // 
            // m_lblUpdate
            // 
            m_lblUpdate.AutoSize = true;
            m_lblUpdate.Location = new Point(58, 45);
            m_lblUpdate.Name = "m_lblUpdate";
            m_lblUpdate.Size = new Size(38, 15);
            m_lblUpdate.TabIndex = 2;
            m_lblUpdate.Text = "label1";
            // 
            // m_lblHeradsSkjalaSafn
            // 
            m_lblHeradsSkjalaSafn.AutoSize = true;
            m_lblHeradsSkjalaSafn.Location = new Point(58, 18);
            m_lblHeradsSkjalaSafn.Name = "m_lblHeradsSkjalaSafn";
            m_lblHeradsSkjalaSafn.Size = new Size(38, 15);
            m_lblHeradsSkjalaSafn.TabIndex = 1;
            m_lblHeradsSkjalaSafn.Text = "label1";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(m_dgvMappaSkjol);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(m_dgvExcelSkjal);
            splitContainer2.Size = new Size(1284, 392);
            splitContainer2.SplitterDistance = 304;
            splitContainer2.TabIndex = 2;
            // 
            // m_dgvMappaSkjol
            // 
            m_dgvMappaSkjol.AllowUserToAddRows = false;
            m_dgvMappaSkjol.AllowUserToDeleteRows = false;
            m_dgvMappaSkjol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvMappaSkjol.Columns.AddRange(new DataGridViewColumn[] { colTakkar, colSlod });
            m_dgvMappaSkjol.Dock = DockStyle.Fill;
            m_dgvMappaSkjol.Location = new Point(0, 0);
            m_dgvMappaSkjol.Name = "m_dgvMappaSkjol";
            m_dgvMappaSkjol.ReadOnly = true;
            m_dgvMappaSkjol.RowHeadersVisible = false;
            m_dgvMappaSkjol.Size = new Size(304, 392);
            m_dgvMappaSkjol.TabIndex = 0;
            m_dgvMappaSkjol.CellClick += m_dgvMappaSkjol_CellClick;
            // 
            // colTakkar
            // 
            colTakkar.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTakkar.DataPropertyName = "ID";
            colTakkar.HeaderText = "Héraðsskjalasöfn";
            colTakkar.Name = "colTakkar";
            colTakkar.ReadOnly = true;
            // 
            // colSlod
            // 
            colSlod.DataPropertyName = "slod";
            colSlod.HeaderText = "colSlod";
            colSlod.Name = "colSlod";
            colSlod.ReadOnly = true;
            colSlod.Visible = false;
            // 
            // m_btnOpnaAllt
            // 
            m_btnOpnaAllt.Location = new Point(287, 105);
            m_btnOpnaAllt.Name = "m_btnOpnaAllt";
            m_btnOpnaAllt.Size = new Size(138, 23);
            m_btnOpnaAllt.TabIndex = 10;
            m_btnOpnaAllt.Text = "Opna birtingu";
            m_btnOpnaAllt.UseVisualStyleBackColor = true;
            m_btnOpnaAllt.Click += m_btnOpnaAllt_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 535);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)m_dgvExcelSkjal).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)m_dgvMappaSkjol).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button m_btnOpnaExcel;
        private OpenFileDialog openFileDialog1;
        private DataGridView m_dgvExcelSkjal;
        private SplitContainer splitContainer1;
        private Label m_lblHeradsSkjalaSafn;
        private Label m_lblMySQL;
        private Label m_lblExcell;
        private Label m_lblUpdate;
        private Button m_btnVista;
        private SplitContainer splitContainer2;
        private DataGridView m_dgvMappaSkjol;
        private DataGridViewButtonColumn colTakkar;
        private DataGridViewTextBoxColumn colSlod;
        private Button m_btnAthBreytingar;
        private Button m_btnUppfaeraBirtingu;
        private Label m_lblPublish;
        private ProgressBar m_prbPublish;
        private Button m_btnOpnaAllt;
    }
}
