namespace MyPosSys
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLogin = new Label();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnClear = new Button();
            lblUserName = new Label();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // txtLogin
            // 
            txtLogin.AutoSize = true;
            txtLogin.Font = new Font("Segoe UI", 15F);
            txtLogin.Location = new Point(181, 67);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(77, 35);
            txtLogin.TabIndex = 0;
            txtLogin.Text = "Login";
            txtLogin.Click += label1_Click;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(247, 144);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(184, 27);
            txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(247, 177);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(184, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Location = new Point(247, 235);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(184, 41);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(57, 235);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(184, 41);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(83, 147);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(82, 20);
            lblUserName.TabIndex = 5;
            lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(83, 176);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 381);
            Controls.Add(lblPassword);
            Controls.Add(lblUserName);
            Controls.Add(btnClear);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(txtLogin);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtLogin;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnClear;
        private Label lblUserName;
        private Label lblPassword;
    }
}
