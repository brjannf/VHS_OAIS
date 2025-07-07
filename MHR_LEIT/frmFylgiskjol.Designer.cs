namespace MHR_LEIT
{
    partial class frmFylgiskjol
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
            m_dgvFylgiskjol = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colTitill = new DataGridViewTextBoxColumn();
            colLysing = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colbtnOpna = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)m_dgvFylgiskjol).BeginInit();
            SuspendLayout();
            // 
            // m_dgvFylgiskjol
            // 
            m_dgvFylgiskjol.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_dgvFylgiskjol.Columns.AddRange(new DataGridViewColumn[] { colID, colTitill, colLysing, colDate, colbtnOpna });
            m_dgvFylgiskjol.Dock = DockStyle.Fill;
            m_dgvFylgiskjol.Location = new Point(0, 0);
            m_dgvFylgiskjol.Name = "m_dgvFylgiskjol";
            m_dgvFylgiskjol.RowHeadersVisible = false;
            m_dgvFylgiskjol.RowTemplate.Height = 25;
            m_dgvFylgiskjol.Size = new Size(1011, 566);
            m_dgvFylgiskjol.TabIndex = 0;
            m_dgvFylgiskjol.CellClick += m_dgvFylgiskjol_CellClick;
            // 
            // colID
            // 
            colID.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colID.DataPropertyName = "documentID";
            colID.HeaderText = "ID";
            colID.Name = "colID";
            colID.Width = 43;
            // 
            // colTitill
            // 
            colTitill.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTitill.DataPropertyName = "documentTitle";
            colTitill.HeaderText = "Titill skjals";
            colTitill.Name = "colTitill";
            colTitill.Width = 79;
            // 
            // colLysing
            // 
            colLysing.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLysing.DataPropertyName = "documentDescription";
            colLysing.HeaderText = "Lýsing skjals";
            colLysing.Name = "colLysing";
            // 
            // colDate
            // 
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDate.DataPropertyName = "documentDate";
            colDate.HeaderText = "Dagsetning skjals";
            colDate.Name = "colDate";
            colDate.Width = 113;
            // 
            // colbtnOpna
            // 
            colbtnOpna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colbtnOpna.HeaderText = "Opna skjal";
            colbtnOpna.Name = "colbtnOpna";
            colbtnOpna.Resizable = DataGridViewTriState.True;
            colbtnOpna.SortMode = DataGridViewColumnSortMode.Automatic;
            colbtnOpna.Text = "opna";
            colbtnOpna.UseColumnTextForButtonValue = true;
            colbtnOpna.Width = 80;
            // 
            // frmFylgiskjol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 566);
            Controls.Add(m_dgvFylgiskjol);
            Name = "frmFylgiskjol";
            Text = "frmFylgiskjol";
            ((System.ComponentModel.ISupportInitialize)m_dgvFylgiskjol).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView m_dgvFylgiskjol;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colTitill;
        private DataGridViewTextBoxColumn colLysing;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewButtonColumn colbtnOpna;
    }
}