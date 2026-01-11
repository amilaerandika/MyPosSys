namespace MyPosSys
{
    partial class frmProduct
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
            txtProCode = new TextBox();
            txtProName = new TextBox();
            txtProUnitPrice = new TextBox();
            txtProUnitCost = new TextBox();
            txtProStock = new TextBox();
            btnDelete = new Button();
            ckbProIsactive = new CheckBox();
            btnAddProducts = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cmbOrder = new ComboBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(17, 185);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1049, 345);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.RowValidated += dataGridView1_RowValidated;
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
            // 
            // txtProCode
            // 
            txtProCode.Location = new Point(158, 6);
            txtProCode.Name = "txtProCode";
            txtProCode.Size = new Size(220, 27);
            txtProCode.TabIndex = 1;
            // 
            // txtProName
            // 
            txtProName.Location = new Point(158, 39);
            txtProName.Name = "txtProName";
            txtProName.Size = new Size(220, 27);
            txtProName.TabIndex = 2;
            // 
            // txtProUnitPrice
            // 
            txtProUnitPrice.Location = new Point(158, 72);
            txtProUnitPrice.Name = "txtProUnitPrice";
            txtProUnitPrice.Size = new Size(220, 27);
            txtProUnitPrice.TabIndex = 3;
            // 
            // txtProUnitCost
            // 
            txtProUnitCost.Location = new Point(158, 105);
            txtProUnitCost.Name = "txtProUnitCost";
            txtProUnitCost.Size = new Size(220, 27);
            txtProUnitCost.TabIndex = 4;
            // 
            // txtProStock
            // 
            txtProStock.Location = new Point(158, 138);
            txtProStock.Name = "txtProStock";
            txtProStock.Size = new Size(220, 27);
            txtProStock.TabIndex = 5;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 128, 128);
            btnDelete.Location = new Point(865, 126);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(202, 39);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete Product";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += button1_Click;
            // 
            // ckbProIsactive
            // 
            ckbProIsactive.AutoSize = true;
            ckbProIsactive.Location = new Point(546, 5);
            ckbProIsactive.Name = "ckbProIsactive";
            ckbProIsactive.Size = new Size(18, 17);
            ckbProIsactive.TabIndex = 11;
            ckbProIsactive.UseVisualStyleBackColor = true;
            // 
            // btnAddProducts
            // 
            btnAddProducts.Location = new Point(656, 126);
            btnAddProducts.Name = "btnAddProducts";
            btnAddProducts.Size = new Size(203, 39);
            btnAddProducts.TabIndex = 12;
            btnAddProducts.Text = "Add Products";
            btnAddProducts.UseVisualStyleBackColor = true;
            btnAddProducts.Click += btnAddProducts_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 13;
            label1.Text = "Product Code";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 42);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 14;
            label2.Text = "Product Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 79);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 15;
            label3.Text = "Unit Price";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 112);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 16;
            label4.Text = "Cost Price";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 145);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 17;
            label5.Text = "Stock Qty";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(405, 2);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 18;
            label6.Text = "Is Active";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(405, 37);
            label7.Name = "label7";
            label7.Size = new Size(85, 20);
            label7.TabIndex = 20;
            label7.Text = "Importance";
            // 
            // cmbOrder
            // 
            cmbOrder.FormattingEnabled = true;
            cmbOrder.Location = new Point(548, 34);
            cmbOrder.Name = "cmbOrder";
            cmbOrder.Size = new Size(218, 28);
            cmbOrder.TabIndex = 21;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(405, 132);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search";
            textBox1.Size = new Size(217, 27);
            textBox1.TabIndex = 22;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // frmProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 542);
            Controls.Add(textBox1);
            Controls.Add(cmbOrder);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddProducts);
            Controls.Add(ckbProIsactive);
            Controls.Add(btnDelete);
            Controls.Add(txtProStock);
            Controls.Add(txtProUnitCost);
            Controls.Add(txtProUnitPrice);
            Controls.Add(txtProName);
            Controls.Add(txtProCode);
            Controls.Add(dataGridView1);
            Name = "frmProduct";
            Text = "Product";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtProCode;
        private TextBox txtProName;
        private TextBox txtProUnitPrice;
        private TextBox txtProUnitCost;
        private TextBox textBox5;
        private TextBox textBox7;
        private TextBox txtProStock;
        private Button btnDelete;
        private CheckBox ckbProIsactive;
        private Button btnAddProducts;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cmbOrder;
        private TextBox textBox1;
    }
}