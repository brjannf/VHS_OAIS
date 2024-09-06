namespace MHR_LEIT
{
    partial class frmNotendur
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
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            m_tboNafn = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label9 = new Label();
            m_tboNotendaNafn = new TextBox();
            m_tboLykilord = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label8 = new Label();
            m_tboNetfang = new TextBox();
            m_tboHeimilsfang = new TextBox();
            m_tboSimi = new TextBox();
            m_comVörslustofnun = new ComboBox();
            m_comHlutverk = new ComboBox();
            label10 = new Label();
            m_chbVirkur = new CheckBox();
            label11 = new Label();
            m_tboAthugasemdir = new TextBox();
            m_tboKennitala = new MaskedTextBox();
            m_btnVista = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(201, 30);
            label1.TabIndex = 0;
            label1.Text = "Nafn";
            // 
            // m_tboNafn
            // 
            m_tboNafn.Dock = DockStyle.Fill;
            m_tboNafn.Location = new Point(210, 3);
            m_tboNafn.Name = "m_tboNafn";
            m_tboNafn.Size = new Size(719, 23);
            m_tboNafn.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 30);
            label2.Name = "label2";
            label2.Size = new Size(201, 30);
            label2.TabIndex = 2;
            label2.Text = "Kennitala";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 60);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 4;
            label3.Text = "Vörslustofnun";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 90);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 6;
            label4.Text = "Notendanafn";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 120);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 8;
            label5.Text = "Lykilorð";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 150);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 10;
            label9.Text = "Hlutverk";
            // 
            // m_tboNotendaNafn
            // 
            m_tboNotendaNafn.Location = new Point(210, 93);
            m_tboNotendaNafn.Name = "m_tboNotendaNafn";
            m_tboNotendaNafn.Size = new Size(580, 23);
            m_tboNotendaNafn.TabIndex = 4;
            // 
            // m_tboLykilord
            // 
            m_tboLykilord.Location = new Point(210, 123);
            m_tboLykilord.Name = "m_tboLykilord";
            m_tboLykilord.PasswordChar = '*';
            m_tboLykilord.Size = new Size(580, 23);
            m_tboLykilord.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 180);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 12;
            label7.Text = "Netfang";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 210);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 14;
            label6.Text = "Heimilisfang";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 240);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 16;
            label8.Text = "Sími/gsm";
            // 
            // m_tboNetfang
            // 
            m_tboNetfang.Location = new Point(210, 183);
            m_tboNetfang.Name = "m_tboNetfang";
            m_tboNetfang.Size = new Size(580, 23);
            m_tboNetfang.TabIndex = 7;
            // 
            // m_tboHeimilsfang
            // 
            m_tboHeimilsfang.Location = new Point(210, 213);
            m_tboHeimilsfang.Name = "m_tboHeimilsfang";
            m_tboHeimilsfang.Size = new Size(580, 23);
            m_tboHeimilsfang.TabIndex = 8;
            // 
            // m_tboSimi
            // 
            m_tboSimi.Location = new Point(210, 243);
            m_tboSimi.Name = "m_tboSimi";
            m_tboSimi.Size = new Size(580, 23);
            m_tboSimi.TabIndex = 9;
            // 
            // m_comVörslustofnun
            // 
            m_comVörslustofnun.DropDownStyle = ComboBoxStyle.DropDownList;
            m_comVörslustofnun.FormattingEnabled = true;
            m_comVörslustofnun.Items.AddRange(new object[] { "Veldu vörslustofnun", "MHR", "HKOP", "HMOS", "HARN" });
            m_comVörslustofnun.Location = new Point(210, 63);
            m_comVörslustofnun.Name = "m_comVörslustofnun";
            m_comVörslustofnun.Size = new Size(580, 23);
            m_comVörslustofnun.TabIndex = 3;
            // 
            // m_comHlutverk
            // 
            m_comHlutverk.DropDownStyle = ComboBoxStyle.DropDownList;
            m_comHlutverk.FormattingEnabled = true;
            m_comHlutverk.Items.AddRange(new object[] { "Veldu hlutverk", "Umsjónarmaður", "Skjalavörður" });
            m_comHlutverk.Location = new Point(210, 153);
            m_comHlutverk.Name = "m_comHlutverk";
            m_comHlutverk.Size = new Size(580, 23);
            m_comHlutverk.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 300);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 20;
            label10.Text = "Virkur";
            // 
            // m_chbVirkur
            // 
            m_chbVirkur.AutoSize = true;
            m_chbVirkur.Location = new Point(210, 303);
            m_chbVirkur.Name = "m_chbVirkur";
            m_chbVirkur.Size = new Size(15, 14);
            m_chbVirkur.TabIndex = 21;
            m_chbVirkur.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(3, 270);
            label11.Name = "label11";
            label11.Size = new Size(82, 15);
            label11.TabIndex = 18;
            label11.Text = "Athugasemdir";
            // 
            // m_tboAthugasemdir
            // 
            m_tboAthugasemdir.Dock = DockStyle.Fill;
            m_tboAthugasemdir.Location = new Point(210, 273);
            m_tboAthugasemdir.Multiline = true;
            m_tboAthugasemdir.Name = "m_tboAthugasemdir";
            m_tboAthugasemdir.Size = new Size(719, 24);
            m_tboAthugasemdir.TabIndex = 10;
            // 
            // m_tboKennitala
            // 
            m_tboKennitala.Dock = DockStyle.Fill;
            m_tboKennitala.Location = new Point(210, 33);
            m_tboKennitala.Mask = "000000-0000";
            m_tboKennitala.Name = "m_tboKennitala";
            m_tboKennitala.Size = new Size(719, 23);
            m_tboKennitala.TabIndex = 2;
            // 
            // m_btnVista
            // 
            m_btnVista.Location = new Point(500, 635);
            m_btnVista.Name = "m_btnVista";
            m_btnVista.Size = new Size(75, 23);
            m_btnVista.TabIndex = 11;
            m_btnVista.Text = "vista";
            m_btnVista.UseVisualStyleBackColor = true;
            m_btnVista.Click += m_btnVista_Click;
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
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label9, 0, 5);
            tableLayoutPanel1.Controls.Add(m_tboNotendaNafn, 1, 3);
            tableLayoutPanel1.Controls.Add(m_tboLykilord, 1, 4);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(label6, 0, 7);
            tableLayoutPanel1.Controls.Add(label8, 0, 8);
            tableLayoutPanel1.Controls.Add(m_tboNetfang, 1, 6);
            tableLayoutPanel1.Controls.Add(m_tboHeimilsfang, 1, 7);
            tableLayoutPanel1.Controls.Add(m_tboSimi, 1, 8);
            tableLayoutPanel1.Controls.Add(m_comVörslustofnun, 1, 2);
            tableLayoutPanel1.Controls.Add(m_comHlutverk, 1, 5);
            tableLayoutPanel1.Controls.Add(label10, 0, 10);
            tableLayoutPanel1.Controls.Add(m_chbVirkur, 1, 10);
            tableLayoutPanel1.Controls.Add(label11, 0, 9);
            tableLayoutPanel1.Controls.Add(m_tboAthugasemdir, 1, 9);
            tableLayoutPanel1.Controls.Add(m_tboKennitala, 1, 1);
            tableLayoutPanel1.Location = new Point(34, 86);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 16;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1036, 497);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // frmNotendur
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 783);
            Controls.Add(m_btnVista);
            Controls.Add(tableLayoutPanel1);
            Name = "frmNotendur";
            Text = "2";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ErrorProvider errorProvider1;
        private Button m_btnVista;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox m_tboNafn;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label9;
        private TextBox m_tboNotendaNafn;
        private TextBox m_tboLykilord;
        private Label label7;
        private Label label6;
        private Label label8;
        private TextBox m_tboNetfang;
        private TextBox m_tboHeimilsfang;
        private TextBox m_tboSimi;
        private ComboBox m_comVörslustofnun;
        private ComboBox m_comHlutverk;
        private Label label10;
        private CheckBox m_chbVirkur;
        private Label label11;
        private TextBox m_tboAthugasemdir;
        private MaskedTextBox m_tboKennitala;
    }
}