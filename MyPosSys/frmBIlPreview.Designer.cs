namespace MyPosSys
{
    partial class frmBIlPreview
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
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblBillTotal = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 32);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(695, 347);
            dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(416, 425);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(306, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(296, 432);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 2;
            label1.Text = "Paid Amount";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(296, 399);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 4;
            label2.Text = "Bill Total";
            // 
            // lblBillTotal
            // 
            lblBillTotal.AutoSize = true;
            lblBillTotal.Location = new Point(416, 399);
            lblBillTotal.Name = "lblBillTotal";
            lblBillTotal.Size = new Size(36, 20);
            lblBillTotal.TabIndex = 5;
            lblBillTotal.Text = "0.00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(416, 467);
            label3.Name = "label3";
            label3.Size = new Size(36, 20);
            label3.TabIndex = 7;
            label3.Text = "0.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(296, 467);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 6;
            label4.Text = "Balance";
            // 
            // BIlPreview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 620);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(lblBillTotal);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "BIlPreview";
            Text = "BIlPreview";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label lblBillTotal;
        private Label label3;
        private Label label4;
    }
}