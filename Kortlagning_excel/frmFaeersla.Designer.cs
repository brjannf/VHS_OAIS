namespace Kortlagning_excel
{
    partial class frmFaeersla
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
            m_dgvFaersla = new DataGridView();
            colTitill = new DataGridViewTextBoxColumn();
            colGildi = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            m_btnExcelGagn = new Button();
            m_btnEyda = new Button();
            m_btnVista = new Button();
            ((System.ComponentModel.ISupportInitialize)m_dgvFaersla).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // m_dgvFaersla
            // 
            m_dgvFaersla.AllowUserToAddRows = false;
            m_dgvFaersla.AllowUserToDeleteRows = false;
            m_dgvFaersla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvFaersla.Columns.AddRange(new DataGridViewColumn[] { colTitill, colGildi });
            m_dgvFaersla.Dock = DockStyle.Fill;
            m_dgvFaersla.Location = new Point(0, 0);
            m_dgvFaersla.Name = "m_dgvFaersla";
            m_dgvFaersla.RowHeadersVisible = false;
            m_dgvFaersla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            m_dgvFaersla.Size = new Size(661, 571);
            m_dgvFaersla.TabIndex = 0;
            m_dgvFaersla.DataBindingComplete += m_dgvFaersla_DataBindingComplete;
            // 
            // colTitill
            // 
            colTitill.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTitill.DataPropertyName = "Titill";
            colTitill.HeaderText = "Heiti dálks";
            colTitill.Name = "colTitill";
            colTitill.ReadOnly = true;
            colTitill.Width = 87;
            // 
            // colGildi
            // 
            colGildi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGildi.DataPropertyName = "Gildi";
            colGildi.HeaderText = "Gildi dálks";
            colGildi.Name = "colGildi";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(m_btnExcelGagn);
            splitContainer1.Panel1.Controls.Add(m_btnEyda);
            splitContainer1.Panel1.Controls.Add(m_btnVista);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(m_dgvFaersla);
            splitContainer1.Size = new Size(997, 571);
            splitContainer1.SplitterDistance = 332;
            splitContainer1.TabIndex = 1;
            // 
            // m_btnExcelGagn
            // 
            m_btnExcelGagn.Location = new Point(40, 86);
            m_btnExcelGagn.Name = "m_btnExcelGagn";
            m_btnExcelGagn.Size = new Size(230, 123);
            m_btnExcelGagn.TabIndex = 2;
            m_btnExcelGagn.Text = "ExcellGagn";
            m_btnExcelGagn.UseVisualStyleBackColor = true;
            m_btnExcelGagn.Click += m_btnExcelGagn_Click;
            // 
            // m_btnEyda
            // 
            m_btnEyda.Location = new Point(195, 32);
            m_btnEyda.Name = "m_btnEyda";
            m_btnEyda.Size = new Size(75, 23);
            m_btnEyda.TabIndex = 1;
            m_btnEyda.Text = "Eyða";
            m_btnEyda.UseVisualStyleBackColor = true;
            m_btnEyda.Click += m_btnEyda_Click;
            // 
            // m_btnVista
            // 
            m_btnVista.Location = new Point(40, 32);
            m_btnVista.Name = "m_btnVista";
            m_btnVista.Size = new Size(75, 23);
            m_btnVista.TabIndex = 0;
            m_btnVista.Text = "Vista";
            m_btnVista.UseVisualStyleBackColor = true;
            m_btnVista.Click += m_btnVista_Click;
            // 
            // frmFaeersla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 571);
            Controls.Add(splitContainer1);
            Name = "frmFaeersla";
            Text = "frmFaeersla";
            ((System.ComponentModel.ISupportInitialize)m_dgvFaersla).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView m_dgvFaersla;
        private SplitContainer splitContainer1;
        private Button m_btnVista;
        private DataGridViewTextBoxColumn colTitill;
        private DataGridViewTextBoxColumn colGildi;
        private Button m_btnEyda;
        private Button m_btnExcelGagn;
    }
}