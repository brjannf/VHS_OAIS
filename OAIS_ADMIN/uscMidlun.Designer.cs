namespace OAIS_ADMIN
{
    partial class uscMidlun
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
            this.m_dgvUtgafur = new System.Windows.Forms.DataGridView();
            this.m_comID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVorsluutgafu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVorslustofnun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeitiVarsla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkjalamyndari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSkjalmHeiti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStaerd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSlod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInnihald = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimabil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAfhArNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMD5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdgangur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHverSkradi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDagsSkráð = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBtnBirta = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEytt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_dgvFyrirSpurnir = new System.Windows.Forms.DataGridView();
            this.m_lblGognStatus = new System.Windows.Forms.Label();
            this.m_lblToflurStatus = new System.Windows.Forms.Label();
            this.m_prbGogn = new System.Windows.Forms.ProgressBar();
            this.m_prbToflur = new System.Windows.Forms.ProgressBar();
            this.colFyrirNafn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFyrirFyrirspurn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFyrirLýsing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBtnPrófa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colFyrirDatabase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBtnVista = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvUtgafur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvFyrirSpurnir)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgvUtgafur
            // 
            this.m_dgvUtgafur.AllowUserToAddRows = false;
            this.m_dgvUtgafur.AllowUserToDeleteRows = false;
            this.m_dgvUtgafur.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.m_dgvUtgafur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvUtgafur.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_comID,
            this.colVorsluutgafu,
            this.colTitill,
            this.colVorslustofnun,
            this.colHeitiVarsla,
            this.colSkjalamyndari,
            this.colSkjalmHeiti,
            this.colStaerd,
            this.colSlod,
            this.colInnihald,
            this.colTimabil,
            this.colAfhArNR,
            this.colMD5,
            this.colAdgangur,
            this.colHverSkradi,
            this.colDagsSkráð,
            this.colBtnBirta,
            this.colEytt});
            this.m_dgvUtgafur.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_dgvUtgafur.Location = new System.Drawing.Point(0, 0);
            this.m_dgvUtgafur.Name = "m_dgvUtgafur";
            this.m_dgvUtgafur.ReadOnly = true;
            this.m_dgvUtgafur.RowHeadersVisible = false;
            this.m_dgvUtgafur.RowTemplate.Height = 25;
            this.m_dgvUtgafur.Size = new System.Drawing.Size(1540, 288);
            this.m_dgvUtgafur.TabIndex = 1;
            this.m_dgvUtgafur.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvUtgafur_CellClick);
            // 
            // m_comID
            // 
            this.m_comID.DataPropertyName = "id";
            this.m_comID.HeaderText = "ID";
            this.m_comID.Name = "m_comID";
            this.m_comID.ReadOnly = true;
            this.m_comID.Visible = false;
            // 
            // colVorsluutgafu
            // 
            this.colVorsluutgafu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colVorsluutgafu.DataPropertyName = "vorsluutgafa";
            this.colVorsluutgafu.HeaderText = "Vörsluútgáfa";
            this.colVorsluutgafu.Name = "colVorsluutgafu";
            this.colVorsluutgafu.ReadOnly = true;
            this.colVorsluutgafu.Width = 98;
            // 
            // colTitill
            // 
            this.colTitill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitill.DataPropertyName = "utgafa_titill";
            this.colTitill.HeaderText = "Titill vörsluútgáfu";
            this.colTitill.Name = "colTitill";
            this.colTitill.ReadOnly = true;
            // 
            // colVorslustofnun
            // 
            this.colVorslustofnun.DataPropertyName = "vorslustofnun";
            this.colVorslustofnun.HeaderText = "VörslustofnunID";
            this.colVorslustofnun.Name = "colVorslustofnun";
            this.colVorslustofnun.ReadOnly = true;
            this.colVorslustofnun.Visible = false;
            // 
            // colHeitiVarsla
            // 
            this.colHeitiVarsla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHeitiVarsla.DataPropertyName = "varsla_heiti";
            this.colHeitiVarsla.HeaderText = "Vörslustofnun";
            this.colHeitiVarsla.Name = "colHeitiVarsla";
            this.colHeitiVarsla.ReadOnly = true;
            this.colHeitiVarsla.Width = 105;
            // 
            // colSkjalamyndari
            // 
            this.colSkjalamyndari.DataPropertyName = "skjalamyndari";
            this.colSkjalamyndari.HeaderText = "skjalamyndari";
            this.colSkjalamyndari.Name = "colSkjalamyndari";
            this.colSkjalamyndari.ReadOnly = true;
            this.colSkjalamyndari.Visible = false;
            // 
            // colSkjalmHeiti
            // 
            this.colSkjalmHeiti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSkjalmHeiti.DataPropertyName = "skjalm_heiti";
            this.colSkjalmHeiti.HeaderText = "Heiti skjalamyndara";
            this.colSkjalmHeiti.Name = "colSkjalmHeiti";
            this.colSkjalmHeiti.ReadOnly = true;
            this.colSkjalmHeiti.Width = 124;
            // 
            // colStaerd
            // 
            this.colStaerd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colStaerd.DataPropertyName = "staerd";
            this.colStaerd.HeaderText = "Stærð";
            this.colStaerd.Name = "colStaerd";
            this.colStaerd.ReadOnly = true;
            this.colStaerd.Width = 63;
            // 
            // colSlod
            // 
            this.colSlod.DataPropertyName = "slod";
            this.colSlod.HeaderText = "Slóð";
            this.colSlod.Name = "colSlod";
            this.colSlod.ReadOnly = true;
            this.colSlod.Visible = false;
            // 
            // colInnihald
            // 
            this.colInnihald.DataPropertyName = "innihald";
            this.colInnihald.HeaderText = "Innihald";
            this.colInnihald.Name = "colInnihald";
            this.colInnihald.ReadOnly = true;
            this.colInnihald.Visible = false;
            // 
            // colTimabil
            // 
            this.colTimabil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTimabil.DataPropertyName = "timabil";
            this.colTimabil.HeaderText = "Tímabil";
            this.colTimabil.Name = "colTimabil";
            this.colTimabil.ReadOnly = true;
            this.colTimabil.Width = 71;
            // 
            // colAfhArNR
            // 
            this.colAfhArNR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAfhArNR.DataPropertyName = "afharnr";
            this.colAfhArNR.HeaderText = "Afhendingaár / númer";
            this.colAfhArNR.Name = "colAfhArNR";
            this.colAfhArNR.ReadOnly = true;
            this.colAfhArNR.Width = 106;
            // 
            // colMD5
            // 
            this.colMD5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMD5.DataPropertyName = "MD5";
            this.colMD5.HeaderText = "Gátsumma";
            this.colMD5.Name = "colMD5";
            this.colMD5.ReadOnly = true;
            this.colMD5.Visible = false;
            // 
            // colAdgangur
            // 
            this.colAdgangur.DataPropertyName = "adgangstakmarkanir";
            this.colAdgangur.HeaderText = "Aðgengi";
            this.colAdgangur.Name = "colAdgangur";
            this.colAdgangur.ReadOnly = true;
            // 
            // colHverSkradi
            // 
            this.colHverSkradi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHverSkradi.DataPropertyName = "hver_skradi";
            this.colHverSkradi.HeaderText = "Hver skráði";
            this.colHverSkradi.Name = "colHverSkradi";
            this.colHverSkradi.ReadOnly = true;
            this.colHverSkradi.Width = 84;
            // 
            // colDagsSkráð
            // 
            this.colDagsSkráð.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDagsSkráð.DataPropertyName = "dags_skrad";
            this.colDagsSkráð.HeaderText = "Dags. skráð";
            this.colDagsSkráð.Name = "colDagsSkráð";
            this.colDagsSkráð.ReadOnly = true;
            this.colDagsSkráð.Width = 85;
            // 
            // colBtnBirta
            // 
            this.colBtnBirta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBtnBirta.HeaderText = "Setja í miðlun";
            this.colBtnBirta.Name = "colBtnBirta";
            this.colBtnBirta.ReadOnly = true;
            this.colBtnBirta.Text = "miðla";
            this.colBtnBirta.UseColumnTextForButtonValue = true;
            this.colBtnBirta.Width = 77;
            // 
            // colEytt
            // 
            this.colEytt.DataPropertyName = "eytt";
            this.colEytt.HeaderText = "Eytt";
            this.colEytt.Name = "colEytt";
            this.colEytt.ReadOnly = true;
            this.colEytt.Visible = false;
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
            this.splitContainer1.Panel1.Controls.Add(this.m_dgvFyrirSpurnir);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblGognStatus);
            this.splitContainer1.Panel1.Controls.Add(this.m_lblToflurStatus);
            this.splitContainer1.Panel1.Controls.Add(this.m_prbGogn);
            this.splitContainer1.Panel1.Controls.Add(this.m_prbToflur);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvUtgafur);
            this.splitContainer1.Size = new System.Drawing.Size(1540, 626);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 2;
            // 
            // m_dgvFyrirSpurnir
            // 
            this.m_dgvFyrirSpurnir.AllowUserToAddRows = false;
            this.m_dgvFyrirSpurnir.AllowUserToDeleteRows = false;
            this.m_dgvFyrirSpurnir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvFyrirSpurnir.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFyrirNafn,
            this.colFyrirFyrirspurn,
            this.colFyrirLýsing,
            this.colBtnPrófa,
            this.colFyrirDatabase,
            this.colBtnVista});
            this.m_dgvFyrirSpurnir.Location = new System.Drawing.Point(64, 131);
            this.m_dgvFyrirSpurnir.Name = "m_dgvFyrirSpurnir";
            this.m_dgvFyrirSpurnir.RowHeadersVisible = false;
            this.m_dgvFyrirSpurnir.RowTemplate.Height = 25;
            this.m_dgvFyrirSpurnir.Size = new System.Drawing.Size(1389, 92);
            this.m_dgvFyrirSpurnir.TabIndex = 4;
            this.m_dgvFyrirSpurnir.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvFyrirSpurnir_CellClick);
            // 
            // m_lblGognStatus
            // 
            this.m_lblGognStatus.AutoSize = true;
            this.m_lblGognStatus.Location = new System.Drawing.Point(912, 104);
            this.m_lblGognStatus.Name = "m_lblGognStatus";
            this.m_lblGognStatus.Size = new System.Drawing.Size(38, 15);
            this.m_lblGognStatus.TabIndex = 3;
            this.m_lblGognStatus.Text = "label1";
            // 
            // m_lblToflurStatus
            // 
            this.m_lblToflurStatus.AutoSize = true;
            this.m_lblToflurStatus.Location = new System.Drawing.Point(912, 43);
            this.m_lblToflurStatus.Name = "m_lblToflurStatus";
            this.m_lblToflurStatus.Size = new System.Drawing.Size(38, 15);
            this.m_lblToflurStatus.TabIndex = 2;
            this.m_lblToflurStatus.Text = "label1";
            // 
            // m_prbGogn
            // 
            this.m_prbGogn.Location = new System.Drawing.Point(64, 87);
            this.m_prbGogn.Name = "m_prbGogn";
            this.m_prbGogn.Size = new System.Drawing.Size(813, 23);
            this.m_prbGogn.TabIndex = 1;
            // 
            // m_prbToflur
            // 
            this.m_prbToflur.Location = new System.Drawing.Point(64, 35);
            this.m_prbToflur.Name = "m_prbToflur";
            this.m_prbToflur.Size = new System.Drawing.Size(813, 23);
            this.m_prbToflur.TabIndex = 0;
            // 
            // colFyrirNafn
            // 
            this.colFyrirNafn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFyrirNafn.DataPropertyName = "name";
            this.colFyrirNafn.HeaderText = "Heiti fyrirspurnar";
            this.colFyrirNafn.Name = "colFyrirNafn";
            this.colFyrirNafn.Width = 111;
            // 
            // colFyrirFyrirspurn
            // 
            this.colFyrirFyrirspurn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFyrirFyrirspurn.DataPropertyName = "queryOriginal";
            this.colFyrirFyrirspurn.HeaderText = "Fyrirspurn";
            this.colFyrirFyrirspurn.Name = "colFyrirFyrirspurn";
            // 
            // colFyrirLýsing
            // 
            this.colFyrirLýsing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFyrirLýsing.DataPropertyName = "description";
            this.colFyrirLýsing.HeaderText = "Lýsing fyrirspurnar";
            this.colFyrirLýsing.Name = "colFyrirLýsing";
            this.colFyrirLýsing.Width = 118;
            // 
            // colBtnPrófa
            // 
            this.colBtnPrófa.HeaderText = "Prófa";
            this.colBtnPrófa.Name = "colBtnPrófa";
            this.colBtnPrófa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBtnPrófa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBtnPrófa.Text = "Prófa";
            this.colBtnPrófa.UseColumnTextForButtonValue = true;
            // 
            // colFyrirDatabase
            // 
            this.colFyrirDatabase.DataPropertyName = "database";
            this.colFyrirDatabase.HeaderText = "Database";
            this.colFyrirDatabase.Name = "colFyrirDatabase";
            this.colFyrirDatabase.Visible = false;
            // 
            // colBtnVista
            // 
            this.colBtnVista.HeaderText = "Vista";
            this.colBtnVista.Name = "colBtnVista";
            // 
            // uscMidlun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "uscMidlun";
            this.Size = new System.Drawing.Size(1540, 626);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvUtgafur)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvFyrirSpurnir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView m_dgvUtgafur;
        private SplitContainer splitContainer1;
        private DataGridViewTextBoxColumn m_comID;
        private DataGridViewTextBoxColumn colVorsluutgafu;
        private DataGridViewTextBoxColumn colTitill;
        private DataGridViewTextBoxColumn colVorslustofnun;
        private DataGridViewTextBoxColumn colHeitiVarsla;
        private DataGridViewTextBoxColumn colSkjalamyndari;
        private DataGridViewTextBoxColumn colSkjalmHeiti;
        private DataGridViewTextBoxColumn colStaerd;
        private DataGridViewTextBoxColumn colSlod;
        private DataGridViewTextBoxColumn colInnihald;
        private DataGridViewTextBoxColumn colTimabil;
        private DataGridViewTextBoxColumn colAfhArNR;
        private DataGridViewTextBoxColumn colMD5;
        private DataGridViewTextBoxColumn colAdgangur;
        private DataGridViewTextBoxColumn colHverSkradi;
        private DataGridViewTextBoxColumn colDagsSkráð;
        private DataGridViewButtonColumn colBtnBirta;
        private DataGridViewTextBoxColumn colEytt;
        private Label m_lblGognStatus;
        private Label m_lblToflurStatus;
        private ProgressBar m_prbGogn;
        private ProgressBar m_prbToflur;
        private DataGridView m_dgvFyrirSpurnir;
        private DataGridViewTextBoxColumn colFyrirNafn;
        private DataGridViewTextBoxColumn colFyrirFyrirspurn;
        private DataGridViewTextBoxColumn colFyrirLýsing;
        private DataGridViewButtonColumn colBtnPrófa;
        private DataGridViewTextBoxColumn colFyrirDatabase;
        private DataGridViewButtonColumn colBtnVista;
    }
}
