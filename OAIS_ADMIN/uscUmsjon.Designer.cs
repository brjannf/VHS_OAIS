namespace OAIS_ADMIN
{
    partial class uscUmsjon
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_btnUmhverfi = new System.Windows.Forms.Button();
            this.m_btnNotendur = new System.Windows.Forms.Button();
            this.m_pnlStillingar = new System.Windows.Forms.Panel();
            this.m_btnStillingarVista = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.m_tboVerd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lblCurrComputer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblSQLversion = new System.Windows.Forms.Label();
            this.m_tboSQLpass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tboSQLuser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.m_lblSkrad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_pnlStillingar.SuspendLayout();
            this.m_pnlNotendur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvNotendur)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.m_btnUmhverfi);
            this.splitContainer1.Panel1.Controls.Add(this.m_btnNotendur);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_pnlStillingar);
            this.splitContainer1.Panel2.Controls.Add(this.m_pnlNotendur);
            this.splitContainer1.Size = new System.Drawing.Size(1211, 666);
            this.splitContainer1.SplitterDistance = 403;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_btnUmhverfi
            // 
            this.m_btnUmhverfi.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnUmhverfi.Location = new System.Drawing.Point(0, 81);
            this.m_btnUmhverfi.Name = "m_btnUmhverfi";
            this.m_btnUmhverfi.Size = new System.Drawing.Size(403, 81);
            this.m_btnUmhverfi.TabIndex = 1;
            this.m_btnUmhverfi.Text = "Stillingar og verðskrá";
            this.m_btnUmhverfi.UseVisualStyleBackColor = true;
            this.m_btnUmhverfi.Click += new System.EventHandler(this.m_btnNotendur_Click);
            // 
            // m_btnNotendur
            // 
            this.m_btnNotendur.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnNotendur.Location = new System.Drawing.Point(0, 0);
            this.m_btnNotendur.Name = "m_btnNotendur";
            this.m_btnNotendur.Size = new System.Drawing.Size(403, 81);
            this.m_btnNotendur.TabIndex = 0;
            this.m_btnNotendur.Text = "Notendur";
            this.m_btnNotendur.UseVisualStyleBackColor = true;
            this.m_btnNotendur.Click += new System.EventHandler(this.m_btnNotendur_Click);
            // 
            // m_pnlStillingar
            // 
            this.m_pnlStillingar.Controls.Add(this.m_lblSkrad);
            this.m_pnlStillingar.Controls.Add(this.m_btnStillingarVista);
            this.m_pnlStillingar.Controls.Add(this.label6);
            this.m_pnlStillingar.Controls.Add(this.m_tboVerd);
            this.m_pnlStillingar.Controls.Add(this.label5);
            this.m_pnlStillingar.Controls.Add(this.m_lblCurrComputer);
            this.m_pnlStillingar.Controls.Add(this.label4);
            this.m_pnlStillingar.Controls.Add(this.m_lblSQLversion);
            this.m_pnlStillingar.Controls.Add(this.m_tboSQLpass);
            this.m_pnlStillingar.Controls.Add(this.label3);
            this.m_pnlStillingar.Controls.Add(this.m_tboSQLuser);
            this.m_pnlStillingar.Controls.Add(this.label2);
            this.m_pnlStillingar.Controls.Add(this.label1);
            this.m_pnlStillingar.Location = new System.Drawing.Point(20, 288);
            this.m_pnlStillingar.Name = "m_pnlStillingar";
            this.m_pnlStillingar.Size = new System.Drawing.Size(700, 246);
            this.m_pnlStillingar.TabIndex = 1;
            // 
            // m_btnStillingarVista
            // 
            this.m_btnStillingarVista.Location = new System.Drawing.Point(557, 199);
            this.m_btnStillingarVista.Name = "m_btnStillingarVista";
            this.m_btnStillingarVista.Size = new System.Drawing.Size(75, 23);
            this.m_btnStillingarVista.TabIndex = 12;
            this.m_btnStillingarVista.Text = "Vista";
            this.m_btnStillingarVista.UseVisualStyleBackColor = true;
            this.m_btnStillingarVista.Click += new System.EventHandler(this.m_btnStillingarVista_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "kr. pr. GB";
            // 
            // m_tboVerd
            // 
            this.m_tboVerd.Location = new System.Drawing.Point(165, 157);
            this.m_tboVerd.Name = "m_tboVerd";
            this.m_tboVerd.Size = new System.Drawing.Size(61, 23);
            this.m_tboVerd.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Verð";
            // 
            // m_lblCurrComputer
            // 
            this.m_lblCurrComputer.AutoSize = true;
            this.m_lblCurrComputer.Location = new System.Drawing.Point(165, 24);
            this.m_lblCurrComputer.Name = "m_lblCurrComputer";
            this.m_lblCurrComputer.Size = new System.Drawing.Size(38, 15);
            this.m_lblCurrComputer.TabIndex = 8;
            this.m_lblCurrComputer.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tölva núna";
            // 
            // m_lblSQLversion
            // 
            this.m_lblSQLversion.AutoSize = true;
            this.m_lblSQLversion.Location = new System.Drawing.Point(165, 59);
            this.m_lblSQLversion.Name = "m_lblSQLversion";
            this.m_lblSQLversion.Size = new System.Drawing.Size(38, 15);
            this.m_lblSQLversion.TabIndex = 6;
            this.m_lblSQLversion.Text = "label4";
            // 
            // m_tboSQLpass
            // 
            this.m_tboSQLpass.Location = new System.Drawing.Point(165, 118);
            this.m_tboSQLpass.Name = "m_tboSQLpass";
            this.m_tboSQLpass.Size = new System.Drawing.Size(230, 23);
            this.m_tboSQLpass.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "SQL user";
            // 
            // m_tboSQLuser
            // 
            this.m_tboSQLuser.Location = new System.Drawing.Point(165, 87);
            this.m_tboSQLuser.Name = "m_tboSQLuser";
            this.m_tboSQLuser.Size = new System.Drawing.Size(230, 23);
            this.m_tboSQLuser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQL pass";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "SQL version";
            // 
            // m_pnlNotendur
            // 
            this.m_pnlNotendur.Controls.Add(this.m_btnStofnaNotanda);
            this.m_pnlNotendur.Controls.Add(this.m_dgvNotendur);
            this.m_pnlNotendur.Location = new System.Drawing.Point(20, 13);
            this.m_pnlNotendur.Name = "m_pnlNotendur";
            this.m_pnlNotendur.Size = new System.Drawing.Size(700, 254);
            this.m_pnlNotendur.TabIndex = 0;
            // 
            // m_btnStofnaNotanda
            // 
            this.m_btnStofnaNotanda.Location = new System.Drawing.Point(557, 195);
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
            this.m_dgvNotendur.Size = new System.Drawing.Size(700, 169);
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
            // m_lblSkrad
            // 
            this.m_lblSkrad.AutoSize = true;
            this.m_lblSkrad.Location = new System.Drawing.Point(82, 203);
            this.m_lblSkrad.Name = "m_lblSkrad";
            this.m_lblSkrad.Size = new System.Drawing.Size(38, 15);
            this.m_lblSkrad.TabIndex = 13;
            this.m_lblSkrad.Text = "label7";
            // 
            // uscUmsjon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "uscUmsjon";
            this.Size = new System.Drawing.Size(1211, 666);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.m_pnlStillingar.ResumeLayout(false);
            this.m_pnlStillingar.PerformLayout();
            this.m_pnlNotendur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvNotendur)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Button m_btnNotendur;
        private Button m_btnUmhverfi;
        private Panel m_pnlNotendur;
        private DataGridView m_dgvNotendur;
        private Button m_btnStofnaNotanda;
        private Panel m_pnlStillingar;
        private Label label1;
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
        private Button m_btnStillingarVista;
        private Label label6;
        private TextBox m_tboVerd;
        private Label label5;
        private Label m_lblCurrComputer;
        private Label label4;
        private Label m_lblSQLversion;
        private TextBox m_tboSQLpass;
        private Label label3;
        private TextBox m_tboSQLuser;
        private Label label2;
        private Label m_lblSkrad;
    }
}
