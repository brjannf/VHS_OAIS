namespace OAIS_ADMIN
{
    partial class uscGagnaUmsjon
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
            this.m_dgvAllt = new System.Windows.Forms.DataGridView();
            this.m_lblSkjalm = new System.Windows.Forms.Label();
            this.m_lblVarsla = new System.Windows.Forms.Label();
            this.m_comSkjalamyndarar = new System.Windows.Forms.ComboBox();
            this.m_comVörslustofnanir = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.m_btnHreinsa = new System.Windows.Forms.Button();
            this.m_btnSkyrsla = new System.Windows.Forms.Button();
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
            this.colEditVaral = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEditSkjalamyndari = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEditSkrá = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colOpna = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEditKvittun = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colRepSkjalm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colRepVarsla = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAllt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dgvAllt
            // 
            this.m_dgvAllt.AllowUserToAddRows = false;
            this.m_dgvAllt.AllowUserToDeleteRows = false;
            this.m_dgvAllt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvAllt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.colEditVaral,
            this.colEditSkjalamyndari,
            this.colEditSkrá,
            this.colOpna,
            this.colEditKvittun,
            this.colRepSkjalm,
            this.colRepVarsla});
            this.m_dgvAllt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvAllt.Location = new System.Drawing.Point(0, 0);
            this.m_dgvAllt.Name = "m_dgvAllt";
            this.m_dgvAllt.ReadOnly = true;
            this.m_dgvAllt.RowHeadersVisible = false;
            this.m_dgvAllt.RowTemplate.Height = 25;
            this.m_dgvAllt.Size = new System.Drawing.Size(1467, 278);
            this.m_dgvAllt.TabIndex = 0;
            this.m_dgvAllt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvAllt_CellClick);
            // 
            // m_lblSkjalm
            // 
            this.m_lblSkjalm.AutoSize = true;
            this.m_lblSkjalm.Location = new System.Drawing.Point(154, 115);
            this.m_lblSkjalm.Name = "m_lblSkjalm";
            this.m_lblSkjalm.Size = new System.Drawing.Size(88, 15);
            this.m_lblSkjalm.TabIndex = 5;
            this.m_lblSkjalm.Text = "Skjalamyndarar";
            // 
            // m_lblVarsla
            // 
            this.m_lblVarsla.AutoSize = true;
            this.m_lblVarsla.Location = new System.Drawing.Point(154, 53);
            this.m_lblVarsla.Name = "m_lblVarsla";
            this.m_lblVarsla.Size = new System.Drawing.Size(86, 15);
            this.m_lblVarsla.TabIndex = 4;
            this.m_lblVarsla.Text = "Vörslustofnanir";
            // 
            // m_comSkjalamyndarar
            // 
            this.m_comSkjalamyndarar.FormattingEnabled = true;
            this.m_comSkjalamyndarar.Location = new System.Drawing.Point(257, 107);
            this.m_comSkjalamyndarar.Name = "m_comSkjalamyndarar";
            this.m_comSkjalamyndarar.Size = new System.Drawing.Size(331, 23);
            this.m_comSkjalamyndarar.TabIndex = 1;
            this.m_comSkjalamyndarar.SelectedIndexChanged += new System.EventHandler(this.m_comSkjalamyndarar_SelectedIndexChanged);
            // 
            // m_comVörslustofnanir
            // 
            this.m_comVörslustofnanir.FormattingEnabled = true;
            this.m_comVörslustofnanir.Location = new System.Drawing.Point(257, 50);
            this.m_comVörslustofnanir.Name = "m_comVörslustofnanir";
            this.m_comVörslustofnanir.Size = new System.Drawing.Size(331, 23);
            this.m_comVörslustofnanir.TabIndex = 0;
            this.m_comVörslustofnanir.SelectedIndexChanged += new System.EventHandler(this.m_comVörslustofnanir_SelectedIndexChanged);
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_btnSkyrsla);
            this.splitContainer2.Size = new System.Drawing.Size(1467, 812);
            this.splitContainer2.SplitterDistance = 564;
            this.splitContainer2.TabIndex = 1;
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
            this.splitContainer3.Panel1.Controls.Add(this.m_btnHreinsa);
            this.splitContainer3.Panel1.Controls.Add(this.m_comSkjalamyndarar);
            this.splitContainer3.Panel1.Controls.Add(this.m_lblSkjalm);
            this.splitContainer3.Panel1.Controls.Add(this.m_comVörslustofnanir);
            this.splitContainer3.Panel1.Controls.Add(this.m_lblVarsla);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.m_dgvAllt);
            this.splitContainer3.Size = new System.Drawing.Size(1467, 564);
            this.splitContainer3.SplitterDistance = 282;
            this.splitContainer3.TabIndex = 1;
            // 
            // m_btnHreinsa
            // 
            this.m_btnHreinsa.Location = new System.Drawing.Point(513, 184);
            this.m_btnHreinsa.Name = "m_btnHreinsa";
            this.m_btnHreinsa.Size = new System.Drawing.Size(75, 23);
            this.m_btnHreinsa.TabIndex = 6;
            this.m_btnHreinsa.Text = "Hreinsa";
            this.m_btnHreinsa.UseVisualStyleBackColor = true;
            this.m_btnHreinsa.Click += new System.EventHandler(this.m_btnHreinsa_Click);
            // 
            // m_btnSkyrsla
            // 
            this.m_btnSkyrsla.Location = new System.Drawing.Point(100, 42);
            this.m_btnSkyrsla.Name = "m_btnSkyrsla";
            this.m_btnSkyrsla.Size = new System.Drawing.Size(295, 23);
            this.m_btnSkyrsla.TabIndex = 0;
            this.m_btnSkyrsla.Text = "Búa til skýrslu eða skýrslur eða eitthvað";
            this.m_btnSkyrsla.UseVisualStyleBackColor = true;
            this.m_btnSkyrsla.Click += new System.EventHandler(this.m_btnSkyrsla_Click);
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
            this.colMD5.Width = 90;
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
            // colEditVaral
            // 
            this.colEditVaral.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEditVaral.HeaderText = "Vörslustofnun";
            this.colEditVaral.Name = "colEditVaral";
            this.colEditVaral.ReadOnly = true;
            this.colEditVaral.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditVaral.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEditVaral.Text = "Fullskrá";
            this.colEditVaral.UseColumnTextForButtonValue = true;
            this.colEditVaral.Width = 105;
            // 
            // colEditSkjalamyndari
            // 
            this.colEditSkjalamyndari.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEditSkjalamyndari.HeaderText = "Skjalamyndari";
            this.colEditSkjalamyndari.Name = "colEditSkjalamyndari";
            this.colEditSkjalamyndari.ReadOnly = true;
            this.colEditSkjalamyndari.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditSkjalamyndari.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEditSkjalamyndari.Text = "Fullskrá";
            this.colEditSkjalamyndari.UseColumnTextForButtonValue = true;
            this.colEditSkjalamyndari.Width = 106;
            // 
            // colEditSkrá
            // 
            this.colEditSkrá.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEditSkrá.HeaderText = "Skráning";
            this.colEditSkrá.Name = "colEditSkrá";
            this.colEditSkrá.ReadOnly = true;
            this.colEditSkrá.Text = "Fullskrá";
            this.colEditSkrá.UseColumnTextForButtonValue = true;
            this.colEditSkrá.Width = 59;
            // 
            // colOpna
            // 
            this.colOpna.HeaderText = "Vörsluútgáfa";
            this.colOpna.Name = "colOpna";
            this.colOpna.ReadOnly = true;
            this.colOpna.Text = "Opna";
            this.colOpna.UseColumnTextForButtonValue = true;
            // 
            // colEditKvittun
            // 
            this.colEditKvittun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colEditKvittun.HeaderText = "Kvittun";
            this.colEditKvittun.Name = "colEditKvittun";
            this.colEditKvittun.ReadOnly = true;
            this.colEditKvittun.Text = "kvittun";
            this.colEditKvittun.UseColumnTextForButtonValue = true;
            this.colEditKvittun.Width = 51;
            // 
            // colRepSkjalm
            // 
            this.colRepSkjalm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colRepSkjalm.HeaderText = "Skýrsla skjalamyndara";
            this.colRepSkjalm.Name = "colRepSkjalm";
            this.colRepSkjalm.ReadOnly = true;
            this.colRepSkjalm.Text = "Skýrsla skjallamyndara";
            this.colRepSkjalm.UseColumnTextForButtonValue = true;
            this.colRepSkjalm.Width = 115;
            // 
            // colRepVarsla
            // 
            this.colRepVarsla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colRepVarsla.HeaderText = "Skýrsla vörslustofnunar";
            this.colRepVarsla.Name = "colRepVarsla";
            this.colRepVarsla.ReadOnly = true;
            this.colRepVarsla.Text = "Skýrsla vörslustofnuna";
            this.colRepVarsla.UseColumnTextForButtonValue = true;
            this.colRepVarsla.Width = 122;
            // 
            // uscGagnaUmsjon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "uscGagnaUmsjon";
            this.Size = new System.Drawing.Size(1467, 812);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvAllt)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView m_dgvAllt;
        private SplitContainer splitContainer2;
        private ComboBox m_comSkjalamyndarar;
        private ComboBox m_comVörslustofnanir;
        private Button m_btnSkyrsla;
        private Label m_lblSkjalm;
        private Label m_lblVarsla;
        private SplitContainer splitContainer3;
        private Button m_btnHreinsa;
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
        private DataGridViewButtonColumn colEditVaral;
        private DataGridViewButtonColumn colEditSkjalamyndari;
        private DataGridViewButtonColumn colEditSkrá;
        private DataGridViewButtonColumn colOpna;
        private DataGridViewButtonColumn colEditKvittun;
        private DataGridViewButtonColumn colRepSkjalm;
        private DataGridViewButtonColumn colRepVarsla;
    }
}
