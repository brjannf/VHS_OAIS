namespace MHR_LEIT
{
    partial class frmUppsetning
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
            this.m_btnAfrit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_btnVeljaDrif = new System.Windows.Forms.Button();
            this.m_btnKeyra = new System.Windows.Forms.Button();
            this.m_lblEnda = new System.Windows.Forms.Label();
            this.m_lblUpphaf = new System.Windows.Forms.Label();
            this.m_pnlStada = new System.Windows.Forms.Panel();
            this.m_lblUppfæra5 = new System.Windows.Forms.Label();
            this.m_lblAfrita4 = new System.Windows.Forms.Label();
            this.m_lblKEyraGagn3 = new System.Windows.Forms.Label();
            this.m_lblKEyraInn2 = new System.Windows.Forms.Label();
            this.m_lblBuaTil1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.m_pnlStada.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAfrit
            // 
            this.m_btnAfrit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_btnAfrit.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_btnAfrit.Location = new System.Drawing.Point(3, 121);
            this.m_btnAfrit.Name = "m_btnAfrit";
            this.m_btnAfrit.Size = new System.Drawing.Size(582, 112);
            this.m_btnAfrit.TabIndex = 0;
            this.m_btnAfrit.Text = "1. Velja miðlunarpakka";
            this.m_btnAfrit.UseVisualStyleBackColor = true;
            this.m_btnAfrit.Click += new System.EventHandler(this.m_btnAfrit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.m_btnAfrit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_btnVeljaDrif, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.m_btnKeyra, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.m_lblEnda, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.m_lblUpphaf, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_pnlStada, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1177, 517);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // m_btnVeljaDrif
            // 
            this.m_btnVeljaDrif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_btnVeljaDrif.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_btnVeljaDrif.Location = new System.Drawing.Point(3, 239);
            this.m_btnVeljaDrif.Name = "m_btnVeljaDrif";
            this.m_btnVeljaDrif.Size = new System.Drawing.Size(582, 106);
            this.m_btnVeljaDrif.TabIndex = 2;
            this.m_btnVeljaDrif.Text = "2. Velja staðsetningu vörsluútgáfna";
            this.m_btnVeljaDrif.UseVisualStyleBackColor = true;
            this.m_btnVeljaDrif.Click += new System.EventHandler(this.m_btnVeljaDrif_Click);
            // 
            // m_btnKeyra
            // 
            this.m_btnKeyra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_btnKeyra.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.m_btnKeyra.Location = new System.Drawing.Point(3, 351);
            this.m_btnKeyra.Name = "m_btnKeyra";
            this.m_btnKeyra.Size = new System.Drawing.Size(582, 150);
            this.m_btnKeyra.TabIndex = 3;
            this.m_btnKeyra.Text = "3. Keyra inn";
            this.m_btnKeyra.UseVisualStyleBackColor = true;
            this.m_btnKeyra.Click += new System.EventHandler(this.m_btnKeyra_Click);
            // 
            // m_lblEnda
            // 
            this.m_lblEnda.AutoSize = true;
            this.m_lblEnda.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lblEnda.ForeColor = System.Drawing.SystemColors.Highlight;
            this.m_lblEnda.Location = new System.Drawing.Point(591, 236);
            this.m_lblEnda.Name = "m_lblEnda";
            this.m_lblEnda.Size = new System.Drawing.Size(288, 30);
            this.m_lblEnda.TabIndex = 5;
            this.m_lblEnda.Text = "Geymslusvæði vörsluútgáfna";
            this.m_lblEnda.Click += new System.EventHandler(this.m_lblEnda_Click);
            // 
            // m_lblUpphaf
            // 
            this.m_lblUpphaf.AutoSize = true;
            this.m_lblUpphaf.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lblUpphaf.ForeColor = System.Drawing.SystemColors.Highlight;
            this.m_lblUpphaf.Location = new System.Drawing.Point(591, 118);
            this.m_lblUpphaf.Name = "m_lblUpphaf";
            this.m_lblUpphaf.Size = new System.Drawing.Size(149, 30);
            this.m_lblUpphaf.TabIndex = 6;
            this.m_lblUpphaf.Text = "Miðlunarpakki";
            // 
            // m_pnlStada
            // 
            this.m_pnlStada.Controls.Add(this.m_lblUppfæra5);
            this.m_pnlStada.Controls.Add(this.m_lblAfrita4);
            this.m_pnlStada.Controls.Add(this.m_lblKEyraGagn3);
            this.m_pnlStada.Controls.Add(this.m_lblKEyraInn2);
            this.m_pnlStada.Controls.Add(this.m_lblBuaTil1);
            this.m_pnlStada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnlStada.Location = new System.Drawing.Point(591, 351);
            this.m_pnlStada.Name = "m_pnlStada";
            this.m_pnlStada.Size = new System.Drawing.Size(583, 150);
            this.m_pnlStada.TabIndex = 7;
            // 
            // m_lblUppfæra5
            // 
            this.m_lblUppfæra5.AutoSize = true;
            this.m_lblUppfæra5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lblUppfæra5.Location = new System.Drawing.Point(3, 129);
            this.m_lblUppfæra5.Name = "m_lblUppfæra5";
            this.m_lblUppfæra5.Size = new System.Drawing.Size(227, 21);
            this.m_lblUppfæra5.TabIndex = 8;
            this.m_lblUppfæra5.Text = "5. Uppfæra staðsetningu gagna";
            // 
            // m_lblAfrita4
            // 
            this.m_lblAfrita4.AutoSize = true;
            this.m_lblAfrita4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lblAfrita4.Location = new System.Drawing.Point(3, 99);
            this.m_lblAfrita4.Name = "m_lblAfrita4";
            this.m_lblAfrita4.Size = new System.Drawing.Size(162, 21);
            this.m_lblAfrita4.TabIndex = 7;
            this.m_lblAfrita4.Text = "4. Afrita vörsluútgáfur";
            // 
            // m_lblKEyraGagn3
            // 
            this.m_lblKEyraGagn3.AutoSize = true;
            this.m_lblKEyraGagn3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lblKEyraGagn3.Location = new System.Drawing.Point(3, 69);
            this.m_lblKEyraGagn3.Name = "m_lblKEyraGagn3";
            this.m_lblKEyraGagn3.Size = new System.Drawing.Size(188, 21);
            this.m_lblKEyraGagn3.TabIndex = 6;
            this.m_lblKEyraGagn3.Text = "3. Keyra inn gagnagrunna";
            // 
            // m_lblKEyraInn2
            // 
            this.m_lblKEyraInn2.AutoSize = true;
            this.m_lblKEyraInn2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lblKEyraInn2.Location = new System.Drawing.Point(3, 39);
            this.m_lblKEyraInn2.Name = "m_lblKEyraInn2";
            this.m_lblKEyraInn2.Size = new System.Drawing.Size(154, 21);
            this.m_lblKEyraInn2.TabIndex = 5;
            this.m_lblKEyraInn2.Text = "2. Keyra inn lýsigögn";
            // 
            // m_lblBuaTil1
            // 
            this.m_lblBuaTil1.AutoSize = true;
            this.m_lblBuaTil1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_lblBuaTil1.Location = new System.Drawing.Point(0, 9);
            this.m_lblBuaTil1.Name = "m_lblBuaTil1";
            this.m_lblBuaTil1.Size = new System.Drawing.Size(181, 21);
            this.m_lblBuaTil1.TabIndex = 4;
            this.m_lblBuaTil1.Text = "1. Búa til lýsigagnagrunn";
            // 
            // frmUppsetning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 517);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmUppsetning";
            this.Text = "frmUppsetning";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.m_pnlStada.ResumeLayout(false);
            this.m_pnlStada.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button m_btnAfrit;
        private TableLayoutPanel tableLayoutPanel1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button m_btnVeljaDrif;
        private Button m_btnKeyra;
        private Label m_lblEnda;
        private Label m_lblBuaTil1;
        private Label m_lblUpphaf;
        private Panel m_pnlStada;
        private Label m_lblKEyraInn2;
        private Label m_lblKEyraGagn3;
        private Label m_lblUppfæra5;
        private Label m_lblAfrita4;
    }
}