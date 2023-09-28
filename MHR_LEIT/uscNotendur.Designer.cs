namespace MHR_LEIT
{
    partial class uscNotendur
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
            this.m_pnlNotendur = new System.Windows.Forms.Panel();
            this.m_btnStofnaNotanda = new System.Windows.Forms.Button();
            this.m_dgvNotendur = new System.Windows.Forms.DataGridView();
            this.colNotandiNafn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandiKennitala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandiNotendanNafn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandiVorslustofnun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandiHlutverk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandLykilord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandiaAhugasemdir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandiHverBreytti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandiHeimili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandiSimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandiVirkur = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNotandiSidastInn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotandiStofnadAf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotBreyta = new System.Windows.Forms.DataGridViewButtonColumn();
            this.m_pnlNotendur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvNotendur)).BeginInit();
            this.SuspendLayout();
            // 
            // m_pnlNotendur
            // 
            this.m_pnlNotendur.Controls.Add(this.m_btnStofnaNotanda);
            this.m_pnlNotendur.Controls.Add(this.m_dgvNotendur);
            this.m_pnlNotendur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnlNotendur.Location = new System.Drawing.Point(0, 0);
            this.m_pnlNotendur.Name = "m_pnlNotendur";
            this.m_pnlNotendur.Size = new System.Drawing.Size(1244, 594);
            this.m_pnlNotendur.TabIndex = 1;
            // 
            // m_btnStofnaNotanda
            // 
            this.m_btnStofnaNotanda.Location = new System.Drawing.Point(557, 517);
            this.m_btnStofnaNotanda.Name = "m_btnStofnaNotanda";
            this.m_btnStofnaNotanda.Size = new System.Drawing.Size(140, 23);
            this.m_btnStofnaNotanda.TabIndex = 1;
            this.m_btnStofnaNotanda.Text = "Stofna notanda";
            this.m_btnStofnaNotanda.UseVisualStyleBackColor = true;
            this.m_btnStofnaNotanda.Click += new System.EventHandler(this.m_btnStofnaNotanda_Click);
            // 
            // m_dgvNotendur
            // 
            this.m_dgvNotendur.AllowUserToAddRows = false;
            this.m_dgvNotendur.AllowUserToDeleteRows = false;
            this.m_dgvNotendur.AllowUserToOrderColumns = true;
            this.m_dgvNotendur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvNotendur.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNotandiNafn,
            this.colNotandiKennitala,
            this.colNotandiNotendanNafn,
            this.colNotandiVorslustofnun,
            this.colNotandiHlutverk,
            this.colNotandLykilord,
            this.colNotandiaAhugasemdir,
            this.colNotandiHverBreytti,
            this.colEmill,
            this.colNotandiHeimili,
            this.colNotandiSimi,
            this.colNotandiVirkur,
            this.colNotandiSidastInn,
            this.colNotandi,
            this.colNotandiStofnadAf,
            this.colNotBreyta});
            this.m_dgvNotendur.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_dgvNotendur.Location = new System.Drawing.Point(0, 0);
            this.m_dgvNotendur.MultiSelect = false;
            this.m_dgvNotendur.Name = "m_dgvNotendur";
            this.m_dgvNotendur.ReadOnly = true;
            this.m_dgvNotendur.RowHeadersVisible = false;
            this.m_dgvNotendur.RowTemplate.Height = 25;
            this.m_dgvNotendur.Size = new System.Drawing.Size(1244, 431);
            this.m_dgvNotendur.TabIndex = 0;
            this.m_dgvNotendur.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgvNotendur_CellClick);
            // 
            // colNotandiNafn
            // 
            this.colNotandiNafn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNotandiNafn.DataPropertyName = "nafn";
            this.colNotandiNafn.HeaderText = "Nafn";
            this.colNotandiNafn.Name = "colNotandiNafn";
            this.colNotandiNafn.ReadOnly = true;
            // 
            // colNotandiKennitala
            // 
            this.colNotandiKennitala.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNotandiKennitala.DataPropertyName = "kennitala";
            this.colNotandiKennitala.HeaderText = "Kennitala";
            this.colNotandiKennitala.Name = "colNotandiKennitala";
            this.colNotandiKennitala.ReadOnly = true;
            this.colNotandiKennitala.Width = 81;
            // 
            // colNotandiNotendanNafn
            // 
            this.colNotandiNotendanNafn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNotandiNotendanNafn.DataPropertyName = "notendanafn";
            this.colNotandiNotendanNafn.HeaderText = "Notendanafn";
            this.colNotandiNotendanNafn.Name = "colNotandiNotendanNafn";
            this.colNotandiNotendanNafn.ReadOnly = true;
            this.colNotandiNotendanNafn.Width = 102;
            // 
            // colNotandiVorslustofnun
            // 
            this.colNotandiVorslustofnun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNotandiVorslustofnun.DataPropertyName = "vörslustofnun";
            this.colNotandiVorslustofnun.HeaderText = "Vörslustofnun";
            this.colNotandiVorslustofnun.Name = "colNotandiVorslustofnun";
            this.colNotandiVorslustofnun.ReadOnly = true;
            this.colNotandiVorslustofnun.Width = 105;
            // 
            // colNotandiHlutverk
            // 
            this.colNotandiHlutverk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNotandiHlutverk.DataPropertyName = "hlutverk";
            this.colNotandiHlutverk.HeaderText = "Hlutverk";
            this.colNotandiHlutverk.Name = "colNotandiHlutverk";
            this.colNotandiHlutverk.ReadOnly = true;
            this.colNotandiHlutverk.Width = 77;
            // 
            // colNotandLykilord
            // 
            this.colNotandLykilord.DataPropertyName = "lykilorð";
            this.colNotandLykilord.HeaderText = "Lykilorð";
            this.colNotandLykilord.Name = "colNotandLykilord";
            this.colNotandLykilord.ReadOnly = true;
            this.colNotandLykilord.Visible = false;
            // 
            // colNotandiaAhugasemdir
            // 
            this.colNotandiaAhugasemdir.DataPropertyName = "athugasemdir";
            this.colNotandiaAhugasemdir.HeaderText = "Athugasemdir";
            this.colNotandiaAhugasemdir.Name = "colNotandiaAhugasemdir";
            this.colNotandiaAhugasemdir.ReadOnly = true;
            this.colNotandiaAhugasemdir.Visible = false;
            // 
            // colNotandiHverBreytti
            // 
            this.colNotandiHverBreytti.DataPropertyName = "hver_breytti";
            this.colNotandiHverBreytti.HeaderText = "HverBreytti";
            this.colNotandiHverBreytti.Name = "colNotandiHverBreytti";
            this.colNotandiHverBreytti.ReadOnly = true;
            this.colNotandiHverBreytti.Visible = false;
            // 
            // colEmill
            // 
            this.colEmill.DataPropertyName = " email";
            this.colEmill.HeaderText = "Email";
            this.colEmill.Name = "colEmill";
            this.colEmill.ReadOnly = true;
            this.colEmill.Visible = false;
            // 
            // colNotandiHeimili
            // 
            this.colNotandiHeimili.DataPropertyName = " heimilisfang";
            this.colNotandiHeimili.HeaderText = "Heimilisfang";
            this.colNotandiHeimili.Name = "colNotandiHeimili";
            this.colNotandiHeimili.ReadOnly = true;
            this.colNotandiHeimili.Visible = false;
            // 
            // colNotandiSimi
            // 
            this.colNotandiSimi.DataPropertyName = "simi";
            this.colNotandiSimi.HeaderText = "Simi";
            this.colNotandiSimi.Name = "colNotandiSimi";
            this.colNotandiSimi.ReadOnly = true;
            this.colNotandiSimi.Visible = false;
            // 
            // colNotandiVirkur
            // 
            this.colNotandiVirkur.DataPropertyName = "virkur";
            this.colNotandiVirkur.HeaderText = "Virkur";
            this.colNotandiVirkur.Name = "colNotandiVirkur";
            this.colNotandiVirkur.ReadOnly = true;
            this.colNotandiVirkur.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colNotandiVirkur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colNotandiSidastInn
            // 
            this.colNotandiSidastInn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNotandiSidastInn.DataPropertyName = "síðasta_innskráning";
            this.colNotandiSidastInn.HeaderText = "Síðast innskráður";
            this.colNotandiSidastInn.Name = "colNotandiSidastInn";
            this.colNotandiSidastInn.ReadOnly = true;
            this.colNotandiSidastInn.Width = 112;
            // 
            // colNotandi
            // 
            this.colNotandi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNotandi.DataPropertyName = "dags_skráð";
            this.colNotandi.HeaderText = "Dags.stofnaður";
            this.colNotandi.Name = "colNotandi";
            this.colNotandi.ReadOnly = true;
            this.colNotandi.Width = 112;
            // 
            // colNotandiStofnadAf
            // 
            this.colNotandiStofnadAf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNotandiStofnadAf.DataPropertyName = "hver_skradi";
            this.colNotandiStofnadAf.HeaderText = "Stofnað af";
            this.colNotandiStofnadAf.Name = "colNotandiStofnadAf";
            this.colNotandiStofnadAf.ReadOnly = true;
            this.colNotandiStofnadAf.Width = 79;
            // 
            // colNotBreyta
            // 
            this.colNotBreyta.HeaderText = "Breyta";
            this.colNotBreyta.Name = "colNotBreyta";
            this.colNotBreyta.ReadOnly = true;
            this.colNotBreyta.Text = "Breyta";
            this.colNotBreyta.UseColumnTextForButtonValue = true;
            // 
            // uscNotendur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_pnlNotendur);
            this.Name = "uscNotendur";
            this.Size = new System.Drawing.Size(1244, 594);
            this.m_pnlNotendur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvNotendur)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel m_pnlNotendur;
        private Button m_btnStofnaNotanda;
        private DataGridView m_dgvNotendur;
        private DataGridViewTextBoxColumn colNotandiNafn;
        private DataGridViewTextBoxColumn colNotandiKennitala;
        private DataGridViewTextBoxColumn colNotandiNotendanNafn;
        private DataGridViewTextBoxColumn colNotandiVorslustofnun;
        private DataGridViewTextBoxColumn colNotandiHlutverk;
        private DataGridViewTextBoxColumn colNotandLykilord;
        private DataGridViewTextBoxColumn colNotandiaAhugasemdir;
        private DataGridViewTextBoxColumn colNotandiHverBreytti;
        private DataGridViewTextBoxColumn colEmill;
        private DataGridViewTextBoxColumn colNotandiHeimili;
        private DataGridViewTextBoxColumn colNotandiSimi;
        private DataGridViewCheckBoxColumn colNotandiVirkur;
        private DataGridViewTextBoxColumn colNotandiSidastInn;
        private DataGridViewTextBoxColumn colNotandi;
        private DataGridViewTextBoxColumn colNotandiStofnadAf;
        private DataGridViewButtonColumn colNotBreyta;
    }
}
