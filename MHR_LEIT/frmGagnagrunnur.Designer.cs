namespace MHR_LEIT
{
    partial class frmGagnagrunnur
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
            this.m_dgvFyrirspurnir = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNafn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLysing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFyrirspurn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGagnagrunnur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.m_btnSetjaIkorfu = new System.Windows.Forms.Button();
            this.m_grbPontun = new System.Windows.Forms.GroupBox();
            this.m_tacPantanir = new System.Windows.Forms.TabControl();
            this.m_tapGagnagrunnar = new System.Windows.Forms.TabPage();
            this.m_dgvPantGagnagrunnar = new System.Windows.Forms.DataGridView();
            this.m_tapSkráarkerfi = new System.Windows.Forms.TabPage();
            this.m_dgvPantSkraarkerfi = new System.Windows.Forms.DataGridView();
            this.m_tapMalakrefi = new System.Windows.Forms.TabPage();
            this.m_dgvPantMalaKerfi = new System.Windows.Forms.DataGridView();
            this.m_grbNidurstodur = new System.Windows.Forms.GroupBox();
            this.m_dgvNidurstodur = new System.Windows.Forms.DataGridView();
            this.m_btnLjukaPontun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvFyrirspurnir)).BeginInit();
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
            this.m_grbPontun.SuspendLayout();
            this.m_tacPantanir.SuspendLayout();
            this.m_tapGagnagrunnar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvPantGagnagrunnar)).BeginInit();
            this.m_tapSkráarkerfi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvPantSkraarkerfi)).BeginInit();
            this.m_tapMalakrefi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvPantMalaKerfi)).BeginInit();
            this.m_grbNidurstodur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvNidurstodur)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgvFyrirspurnir
            // 
            this.m_dgvFyrirspurnir.AllowUserToAddRows = false;
            this.m_dgvFyrirspurnir.AllowUserToDeleteRows = false;
            this.m_dgvFyrirspurnir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvFyrirspurnir.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colNafn,
            this.colLysing,
            this.colFyrirspurn,
            this.colGagnagrunnur});
            this.m_dgvFyrirspurnir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvFyrirspurnir.Location = new System.Drawing.Point(0, 0);
            this.m_dgvFyrirspurnir.Name = "m_dgvFyrirspurnir";
            this.m_dgvFyrirspurnir.RowHeadersVisible = false;
            this.m_dgvFyrirspurnir.RowTemplate.Height = 25;
            this.m_dgvFyrirspurnir.Size = new System.Drawing.Size(1094, 185);
            this.m_dgvFyrirspurnir.TabIndex = 0;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "id";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colNafn
            // 
            this.colNafn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNafn.DataPropertyName = "nafn";
            this.colNafn.HeaderText = "Titill fyrirspurnar";
            this.colNafn.Name = "colNafn";
            this.colNafn.Width = 108;
            // 
            // colLysing
            // 
            this.colLysing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLysing.DataPropertyName = "lysing";
            this.colLysing.HeaderText = "Lýsing fyrirspurnar";
            this.colLysing.Name = "colLysing";
            // 
            // colFyrirspurn
            // 
            this.colFyrirspurn.DataPropertyName = "fyrirspurn";
            this.colFyrirspurn.HeaderText = "Fyrirspurn";
            this.colFyrirspurn.Name = "colFyrirspurn";
            this.colFyrirspurn.Visible = false;
            // 
            // colGagnagrunnur
            // 
            this.colGagnagrunnur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGagnagrunnur.DataPropertyName = "gagnagrunnur";
            this.colGagnagrunnur.HeaderText = "Gagnagrunnur";
            this.colGagnagrunnur.Name = "colGagnagrunnur";
            this.colGagnagrunnur.Visible = false;
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_grbNidurstodur);
            this.splitContainer1.Size = new System.Drawing.Size(1528, 577);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_grbPontun);
            this.splitContainer2.Size = new System.Drawing.Size(1528, 288);
            this.splitContainer2.SplitterDistance = 1094;
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
            this.splitContainer3.Panel1.Controls.Add(this.m_dgvFyrirspurnir);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.m_btnLjukaPontun);
            this.splitContainer3.Panel2.Controls.Add(this.m_btnSetjaIkorfu);
            this.splitContainer3.Size = new System.Drawing.Size(1094, 288);
            this.splitContainer3.SplitterDistance = 185;
            this.splitContainer3.TabIndex = 1;
            // 
            // m_btnSetjaIkorfu
            // 
            this.m_btnSetjaIkorfu.Location = new System.Drawing.Point(691, 31);
            this.m_btnSetjaIkorfu.Name = "m_btnSetjaIkorfu";
            this.m_btnSetjaIkorfu.Size = new System.Drawing.Size(147, 23);
            this.m_btnSetjaIkorfu.TabIndex = 0;
            this.m_btnSetjaIkorfu.Text = "Setja í körfu";
            this.m_btnSetjaIkorfu.UseVisualStyleBackColor = true;
            this.m_btnSetjaIkorfu.Click += new System.EventHandler(this.m_btnSetjaIkorfu_Click);
            // 
            // m_grbPontun
            // 
            this.m_grbPontun.Controls.Add(this.m_tacPantanir);
            this.m_grbPontun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbPontun.Location = new System.Drawing.Point(0, 0);
            this.m_grbPontun.Name = "m_grbPontun";
            this.m_grbPontun.Size = new System.Drawing.Size(430, 288);
            this.m_grbPontun.TabIndex = 2;
            this.m_grbPontun.TabStop = false;
            this.m_grbPontun.Text = "Gögn óafgreitt";
            // 
            // m_tacPantanir
            // 
            this.m_tacPantanir.Controls.Add(this.m_tapGagnagrunnar);
            this.m_tacPantanir.Controls.Add(this.m_tapSkráarkerfi);
            this.m_tacPantanir.Controls.Add(this.m_tapMalakrefi);
            this.m_tacPantanir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tacPantanir.Location = new System.Drawing.Point(3, 19);
            this.m_tacPantanir.Name = "m_tacPantanir";
            this.m_tacPantanir.SelectedIndex = 0;
            this.m_tacPantanir.Size = new System.Drawing.Size(424, 266);
            this.m_tacPantanir.TabIndex = 1;
            // 
            // m_tapGagnagrunnar
            // 
            this.m_tapGagnagrunnar.Controls.Add(this.m_dgvPantGagnagrunnar);
            this.m_tapGagnagrunnar.Location = new System.Drawing.Point(4, 24);
            this.m_tapGagnagrunnar.Name = "m_tapGagnagrunnar";
            this.m_tapGagnagrunnar.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapGagnagrunnar.Size = new System.Drawing.Size(416, 238);
            this.m_tapGagnagrunnar.TabIndex = 0;
            this.m_tapGagnagrunnar.Text = "Gagangrunnar";
            this.m_tapGagnagrunnar.UseVisualStyleBackColor = true;
            // 
            // m_dgvPantGagnagrunnar
            // 
            this.m_dgvPantGagnagrunnar.AllowUserToAddRows = false;
            this.m_dgvPantGagnagrunnar.AllowUserToDeleteRows = false;
            this.m_dgvPantGagnagrunnar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvPantGagnagrunnar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvPantGagnagrunnar.Location = new System.Drawing.Point(3, 3);
            this.m_dgvPantGagnagrunnar.Name = "m_dgvPantGagnagrunnar";
            this.m_dgvPantGagnagrunnar.ReadOnly = true;
            this.m_dgvPantGagnagrunnar.RowHeadersVisible = false;
            this.m_dgvPantGagnagrunnar.RowTemplate.Height = 25;
            this.m_dgvPantGagnagrunnar.Size = new System.Drawing.Size(410, 232);
            this.m_dgvPantGagnagrunnar.TabIndex = 0;
            // 
            // m_tapSkráarkerfi
            // 
            this.m_tapSkráarkerfi.Controls.Add(this.m_dgvPantSkraarkerfi);
            this.m_tapSkráarkerfi.Location = new System.Drawing.Point(4, 24);
            this.m_tapSkráarkerfi.Name = "m_tapSkráarkerfi";
            this.m_tapSkráarkerfi.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapSkráarkerfi.Size = new System.Drawing.Size(416, 238);
            this.m_tapSkráarkerfi.TabIndex = 1;
            this.m_tapSkráarkerfi.Text = "Skráarkerfi";
            this.m_tapSkráarkerfi.UseVisualStyleBackColor = true;
            // 
            // m_dgvPantSkraarkerfi
            // 
            this.m_dgvPantSkraarkerfi.AllowUserToAddRows = false;
            this.m_dgvPantSkraarkerfi.AllowUserToDeleteRows = false;
            this.m_dgvPantSkraarkerfi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvPantSkraarkerfi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvPantSkraarkerfi.Location = new System.Drawing.Point(3, 3);
            this.m_dgvPantSkraarkerfi.Name = "m_dgvPantSkraarkerfi";
            this.m_dgvPantSkraarkerfi.ReadOnly = true;
            this.m_dgvPantSkraarkerfi.RowHeadersVisible = false;
            this.m_dgvPantSkraarkerfi.RowTemplate.Height = 25;
            this.m_dgvPantSkraarkerfi.Size = new System.Drawing.Size(410, 232);
            this.m_dgvPantSkraarkerfi.TabIndex = 0;
            // 
            // m_tapMalakrefi
            // 
            this.m_tapMalakrefi.Controls.Add(this.m_dgvPantMalaKerfi);
            this.m_tapMalakrefi.Location = new System.Drawing.Point(4, 24);
            this.m_tapMalakrefi.Name = "m_tapMalakrefi";
            this.m_tapMalakrefi.Padding = new System.Windows.Forms.Padding(3);
            this.m_tapMalakrefi.Size = new System.Drawing.Size(416, 238);
            this.m_tapMalakrefi.TabIndex = 2;
            this.m_tapMalakrefi.Text = "Málakerfi";
            this.m_tapMalakrefi.UseVisualStyleBackColor = true;
            // 
            // m_dgvPantMalaKerfi
            // 
            this.m_dgvPantMalaKerfi.AllowUserToAddRows = false;
            this.m_dgvPantMalaKerfi.AllowUserToDeleteRows = false;
            this.m_dgvPantMalaKerfi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvPantMalaKerfi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvPantMalaKerfi.Location = new System.Drawing.Point(3, 3);
            this.m_dgvPantMalaKerfi.Name = "m_dgvPantMalaKerfi";
            this.m_dgvPantMalaKerfi.ReadOnly = true;
            this.m_dgvPantMalaKerfi.RowHeadersVisible = false;
            this.m_dgvPantMalaKerfi.RowTemplate.Height = 25;
            this.m_dgvPantMalaKerfi.Size = new System.Drawing.Size(410, 232);
            this.m_dgvPantMalaKerfi.TabIndex = 0;
            // 
            // m_grbNidurstodur
            // 
            this.m_grbNidurstodur.Controls.Add(this.m_dgvNidurstodur);
            this.m_grbNidurstodur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grbNidurstodur.Location = new System.Drawing.Point(0, 0);
            this.m_grbNidurstodur.Name = "m_grbNidurstodur";
            this.m_grbNidurstodur.Size = new System.Drawing.Size(1528, 285);
            this.m_grbNidurstodur.TabIndex = 1;
            this.m_grbNidurstodur.TabStop = false;
            this.m_grbNidurstodur.Text = "Niðurstöður";
            // 
            // m_dgvNidurstodur
            // 
            this.m_dgvNidurstodur.AllowUserToAddRows = false;
            this.m_dgvNidurstodur.AllowUserToDeleteRows = false;
            this.m_dgvNidurstodur.AllowUserToOrderColumns = true;
            this.m_dgvNidurstodur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvNidurstodur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvNidurstodur.Location = new System.Drawing.Point(3, 19);
            this.m_dgvNidurstodur.Name = "m_dgvNidurstodur";
            this.m_dgvNidurstodur.ReadOnly = true;
            this.m_dgvNidurstodur.RowHeadersVisible = false;
            this.m_dgvNidurstodur.RowTemplate.Height = 25;
            this.m_dgvNidurstodur.Size = new System.Drawing.Size(1522, 263);
            this.m_dgvNidurstodur.TabIndex = 0;
            this.m_dgvNidurstodur.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.keyrafyrirspurn_CellClick);
            // 
            // m_btnLjukaPontun
            // 
            this.m_btnLjukaPontun.Location = new System.Drawing.Point(923, 31);
            this.m_btnLjukaPontun.Name = "m_btnLjukaPontun";
            this.m_btnLjukaPontun.Size = new System.Drawing.Size(147, 23);
            this.m_btnLjukaPontun.TabIndex = 1;
            this.m_btnLjukaPontun.Text = "Ljúka pöntun";
            this.m_btnLjukaPontun.UseVisualStyleBackColor = true;
            this.m_btnLjukaPontun.Click += new System.EventHandler(this.m_btnLjukaPontun_Click);
            // 
            // frmGagnagrunnur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 577);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmGagnagrunnur";
            this.Text = "frmGagnagrunnur";
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvFyrirspurnir)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.m_grbPontun.ResumeLayout(false);
            this.m_tacPantanir.ResumeLayout(false);
            this.m_tapGagnagrunnar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvPantGagnagrunnar)).EndInit();
            this.m_tapSkráarkerfi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvPantSkraarkerfi)).EndInit();
            this.m_tapMalakrefi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvPantMalaKerfi)).EndInit();
            this.m_grbNidurstodur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvNidurstodur)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView m_dgvFyrirspurnir;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colNafn;
        private DataGridViewTextBoxColumn colLysing;
        private DataGridViewTextBoxColumn colFyrirspurn;
        private DataGridViewTextBoxColumn colGagnagrunnur;
        private SplitContainer splitContainer1;
        private DataGridView m_dgvNidurstodur;
        private GroupBox m_grbNidurstodur;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private Button m_btnSetjaIkorfu;
        private GroupBox m_grbPontun;
        private TabControl m_tacPantanir;
        private TabPage m_tapGagnagrunnar;
        private DataGridView m_dgvPantGagnagrunnar;
        private TabPage m_tapSkráarkerfi;
        private TabPage m_tapMalakrefi;
        private DataGridView m_dgvPantSkraarkerfi;
        private DataGridView m_dgvPantMalaKerfi;
        private Button m_btnLjukaPontun;
    }
}