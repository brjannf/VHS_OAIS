namespace MHR_LEIT
{
    partial class frmAtvik
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
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            panel1 = new Panel();
            m_btnHreinsa = new Button();
            m_btnFiltera = new Button();
            m_lbFyrirTæki = new Label();
            m_comDeild = new ComboBox();
            m_comSvid = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            m_trwFlokkar = new TreeView();
            groupBox1 = new GroupBox();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(1237, 628);
            splitContainer1.SplitterDistance = 223;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(panel1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(m_trwFlokkar);
            splitContainer2.Size = new Size(223, 628);
            splitContainer2.SplitterDistance = 147;
            splitContainer2.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(m_btnHreinsa);
            panel1.Controls.Add(m_btnFiltera);
            panel1.Controls.Add(m_lbFyrirTæki);
            panel1.Controls.Add(m_comDeild);
            panel1.Controls.Add(m_comSvid);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(223, 147);
            panel1.TabIndex = 1;
            // 
            // m_btnHreinsa
            // 
            m_btnHreinsa.Location = new Point(141, 94);
            m_btnHreinsa.Name = "m_btnHreinsa";
            m_btnHreinsa.Size = new Size(75, 23);
            m_btnHreinsa.TabIndex = 7;
            m_btnHreinsa.Text = "Hreinsa";
            m_btnHreinsa.UseVisualStyleBackColor = true;
            m_btnHreinsa.Click += m_btnHreinsa_Click;
            // 
            // m_btnFiltera
            // 
            m_btnFiltera.Location = new Point(43, 94);
            m_btnFiltera.Name = "m_btnFiltera";
            m_btnFiltera.Size = new Size(75, 23);
            m_btnFiltera.TabIndex = 6;
            m_btnFiltera.Text = "Filtera";
            m_btnFiltera.UseVisualStyleBackColor = true;
            m_btnFiltera.Click += m_btnFiltera_Click;
            // 
            // m_lbFyrirTæki
            // 
            m_lbFyrirTæki.AutoSize = true;
            m_lbFyrirTæki.Location = new Point(68, 9);
            m_lbFyrirTæki.Name = "m_lbFyrirTæki";
            m_lbFyrirTæki.Size = new Size(59, 15);
            m_lbFyrirTæki.TabIndex = 5;
            m_lbFyrirTæki.Text = "Fyrirtæki: ";
            // 
            // m_comDeild
            // 
            m_comDeild.FormattingEnabled = true;
            m_comDeild.Location = new Point(43, 65);
            m_comDeild.Name = "m_comDeild";
            m_comDeild.Size = new Size(173, 23);
            m_comDeild.TabIndex = 4;
            // 
            // m_comSvid
            // 
            m_comSvid.FormattingEnabled = true;
            m_comSvid.Location = new Point(43, 37);
            m_comSvid.Name = "m_comSvid";
            m_comSvid.Size = new Size(173, 23);
            m_comSvid.TabIndex = 3;
            m_comSvid.SelectedIndexChanged += m_comSvid_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 40);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 2;
            label3.Text = "Svið";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 68);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 1;
            label2.Text = "Deild";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Fyrirtæki: ";
            // 
            // m_trwFlokkar
            // 
            m_trwFlokkar.Dock = DockStyle.Fill;
            m_trwFlokkar.Location = new Point(0, 0);
            m_trwFlokkar.Name = "m_trwFlokkar";
            m_trwFlokkar.Size = new Size(223, 477);
            m_trwFlokkar.TabIndex = 0;
            m_trwFlokkar.AfterSelect += m_trwFlokkar_AfterSelect;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1010, 628);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Atvikið";
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 19);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1004, 606);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // frmAtvik
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 628);
            Controls.Add(splitContainer1);
            Name = "frmAtvik";
            Text = "frmAtvik";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView m_trwFlokkar;
        private RichTextBox richTextBox1;
        private GroupBox groupBox1;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label m_lbFyrirTæki;
        private ComboBox m_comDeild;
        private ComboBox m_comSvid;
        private SplitContainer splitContainer2;
        private Button m_btnFiltera;
        private Button m_btnHreinsa;
    }
}