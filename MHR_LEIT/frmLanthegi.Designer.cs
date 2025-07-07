namespace MHR_LEIT
{
    partial class frmLanthegi
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            m_tboNafn = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            m_tboKennitala = new MaskedTextBox();
            m_tboHeit_fyrirtaekis = new TextBox();
            label7 = new Label();
            m_tboNetfang = new TextBox();
            label8 = new Label();
            m_tboSimi = new TextBox();
            m_tboKennitalFyrirtaekis = new MaskedTextBox();
            m_chbKenniVantar = new CheckBox();
            m_chbKenniFyrirVantar = new CheckBox();
            m_btnVista = new Button();
            errorProvider1 = new ErrorProvider(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(m_tboNafn, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(m_tboKennitala, 1, 1);
            tableLayoutPanel1.Controls.Add(m_tboHeit_fyrirtaekis, 1, 2);
            tableLayoutPanel1.Controls.Add(label7, 0, 5);
            tableLayoutPanel1.Controls.Add(m_tboNetfang, 1, 5);
            tableLayoutPanel1.Controls.Add(label8, 0, 4);
            tableLayoutPanel1.Controls.Add(m_tboSimi, 1, 4);
            tableLayoutPanel1.Controls.Add(m_tboKennitalFyrirtaekis, 1, 3);
            tableLayoutPanel1.Controls.Add(m_chbKenniVantar, 2, 1);
            tableLayoutPanel1.Controls.Add(m_chbKenniFyrirVantar, 2, 3);
            tableLayoutPanel1.Location = new Point(51, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1090, 183);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(212, 30);
            label1.TabIndex = 0;
            label1.Text = "Nafn";
            // 
            // m_tboNafn
            // 
            m_tboNafn.Dock = DockStyle.Fill;
            m_tboNafn.Location = new Point(221, 3);
            m_tboNafn.Name = "m_tboNafn";
            m_tboNafn.Size = new Size(757, 23);
            m_tboNafn.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(212, 30);
            label2.TabIndex = 2;
            label2.Text = "Kennitala";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 60);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 3;
            label3.Text = "Heiti stofnunar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 90);
            label4.Name = "label4";
            label4.Size = new Size(113, 15);
            label4.TabIndex = 4;
            label4.Text = "Kennitala  stofnunar";
            // 
            // m_tboKennitala
            // 
            m_tboKennitala.Dock = DockStyle.Fill;
            m_tboKennitala.Location = new Point(221, 33);
            m_tboKennitala.Mask = "000000-0000";
            m_tboKennitala.Name = "m_tboKennitala";
            m_tboKennitala.Size = new Size(757, 23);
            m_tboKennitala.TabIndex = 23;
            // 
            // m_tboHeit_fyrirtaekis
            // 
            m_tboHeit_fyrirtaekis.Dock = DockStyle.Fill;
            m_tboHeit_fyrirtaekis.Location = new Point(221, 63);
            m_tboHeit_fyrirtaekis.Name = "m_tboHeit_fyrirtaekis";
            m_tboHeit_fyrirtaekis.Size = new Size(757, 23);
            m_tboHeit_fyrirtaekis.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 150);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 7;
            label7.Text = "Netfang";
            // 
            // m_tboNetfang
            // 
            m_tboNetfang.Dock = DockStyle.Fill;
            m_tboNetfang.Location = new Point(221, 153);
            m_tboNetfang.Name = "m_tboNetfang";
            m_tboNetfang.Size = new Size(757, 23);
            m_tboNetfang.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 120);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 8;
            label8.Text = "Sími/gsm";
            // 
            // m_tboSimi
            // 
            m_tboSimi.Dock = DockStyle.Fill;
            m_tboSimi.Location = new Point(221, 123);
            m_tboSimi.Name = "m_tboSimi";
            m_tboSimi.Size = new Size(757, 23);
            m_tboSimi.TabIndex = 16;
            // 
            // m_tboKennitalFyrirtaekis
            // 
            m_tboKennitalFyrirtaekis.Dock = DockStyle.Fill;
            m_tboKennitalFyrirtaekis.Location = new Point(221, 93);
            m_tboKennitalFyrirtaekis.Mask = "000000-0000";
            m_tboKennitalFyrirtaekis.Name = "m_tboKennitalFyrirtaekis";
            m_tboKennitalFyrirtaekis.Size = new Size(757, 23);
            m_tboKennitalFyrirtaekis.TabIndex = 25;
            // 
            // m_chbKenniVantar
            // 
            m_chbKenniVantar.AutoSize = true;
            m_chbKenniVantar.Location = new Point(984, 33);
            m_chbKenniVantar.Name = "m_chbKenniVantar";
            m_chbKenniVantar.Size = new Size(59, 19);
            m_chbKenniVantar.TabIndex = 26;
            m_chbKenniVantar.Text = "Vantar";
            m_chbKenniVantar.UseVisualStyleBackColor = true;
            m_chbKenniVantar.CheckedChanged += m_chbKenniVantar_CheckedChanged;
            // 
            // m_chbKenniFyrirVantar
            // 
            m_chbKenniFyrirVantar.AutoSize = true;
            m_chbKenniFyrirVantar.Location = new Point(984, 93);
            m_chbKenniFyrirVantar.Name = "m_chbKenniFyrirVantar";
            m_chbKenniFyrirVantar.Size = new Size(59, 19);
            m_chbKenniFyrirVantar.TabIndex = 27;
            m_chbKenniFyrirVantar.Text = "Vantar";
            m_chbKenniFyrirVantar.UseVisualStyleBackColor = true;
            m_chbKenniFyrirVantar.CheckedChanged += m_chbKenniFyrirVantar_CheckedChanged;
            // 
            // m_btnVista
            // 
            m_btnVista.Location = new Point(1050, 232);
            m_btnVista.Name = "m_btnVista";
            m_btnVista.Size = new Size(75, 23);
            m_btnVista.TabIndex = 2;
            m_btnVista.Text = "vista";
            m_btnVista.UseVisualStyleBackColor = true;
            m_btnVista.Click += m_btnVista_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmLanthegi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1171, 512);
            Controls.Add(m_btnVista);
            Controls.Add(tableLayoutPanel1);
            Name = "frmLanthegi";
            Text = "frmLanthegi";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox m_tboNafn;
        private Label label2;
        private Label label3;
        private Label label4;
        private MaskedTextBox m_tboKennitala;
        private TextBox m_tboHeit_fyrirtaekis;
        private Label label7;
        private TextBox m_tboNetfang;
        private Label label8;
        private TextBox m_tboSimi;
        private MaskedTextBox m_tboKennitalFyrirtaekis;
        private Button m_btnVista;
        private ErrorProvider errorProvider1;
        private CheckBox m_chbKenniVantar;
        private CheckBox m_chbKenniFyrirVantar;
    }
}