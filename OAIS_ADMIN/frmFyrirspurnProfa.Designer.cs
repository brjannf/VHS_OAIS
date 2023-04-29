namespace OAIS_ADMIN
{
    partial class frmFyrirspurnProfa
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
            this.m_tboFyrirspurn = new System.Windows.Forms.TextBox();
            this.m_btnTesta = new System.Windows.Forms.Button();
            this.m_dgvTest = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // m_tboFyrirspurn
            // 
            this.m_tboFyrirspurn.Location = new System.Drawing.Point(86, 30);
            this.m_tboFyrirspurn.Name = "m_tboFyrirspurn";
            this.m_tboFyrirspurn.Size = new System.Drawing.Size(659, 23);
            this.m_tboFyrirspurn.TabIndex = 0;
            // 
            // m_btnTesta
            // 
            this.m_btnTesta.Location = new System.Drawing.Point(764, 30);
            this.m_btnTesta.Name = "m_btnTesta";
            this.m_btnTesta.Size = new System.Drawing.Size(75, 23);
            this.m_btnTesta.TabIndex = 1;
            this.m_btnTesta.Text = "Prófa";
            this.m_btnTesta.UseVisualStyleBackColor = true;
            this.m_btnTesta.Click += new System.EventHandler(this.m_btnTesta_Click);
            // 
            // m_dgvTest
            // 
            this.m_dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvTest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_dgvTest.Location = new System.Drawing.Point(0, 96);
            this.m_dgvTest.Name = "m_dgvTest";
            this.m_dgvTest.RowTemplate.Height = 25;
            this.m_dgvTest.Size = new System.Drawing.Size(1012, 426);
            this.m_dgvTest.TabIndex = 2;
            // 
            // frmFyrirspurnProfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 522);
            this.Controls.Add(this.m_dgvTest);
            this.Controls.Add(this.m_btnTesta);
            this.Controls.Add(this.m_tboFyrirspurn);
            this.Name = "frmFyrirspurnProfa";
            this.Text = "frmFyrirspurnProfa";
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox m_tboFyrirspurn;
        private Button m_btnTesta;
        private DataGridView m_dgvTest;
    }
}