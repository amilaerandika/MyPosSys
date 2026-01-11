using Microsoft.Data.SqlClient;
using MyPosSys.Data;
using System.Security.Cryptography;
using System.Text;

namespace MyPosSys
{
    public partial class frmLogin : Form
    {
        private string _userName;
        private string _password;

        frmLogin loginForm;

        public frmLogin()
        {
            InitializeComponent();
            _userName = string.Empty;
            _password = string.Empty;
            loginForm = this;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _userName = string.Empty;
            _password = string.Empty;

            string uName = "amila"; //txtUserName.Text.Trim();
            string pwd = "12345"; //txtPassword.Text.Trim();
            Login_User(uName, pwd);
        }

        private void Login_User(string userName, string password)
        {
            _userName = userName;
            _password = password;

            if (string.IsNullOrEmpty(_userName) && string.IsNullOrEmpty(_password))
            {
                MessageBox.Show("Please enter username and password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string connectionString = "Data Source=192.168.8.191\\SQLEXPRESS,1433;Initial Catalog=MyPosSys;User ID=sa;pwd=12345;Encrypt=False;Trust Server Certificate=True";

                using SqlConnection conn = new SqlConnection(connectionString);

                string query = "SELECT COUNT(1) FROM PosUser WHERE UserName=@UserName AND PasswordHash=@Password";
                using SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserName", _userName);
                cmd.Parameters.AddWithValue("@Password", HashPassword(_password));

                frmMainWindow mainWindow = new frmMainWindow(connectionString);
                mainWindow.Show();
                loginForm.Hide();

                //using (cmd)
                //{
                //    conn.Open();

                //    using (SqlDataReader r = cmd.ExecuteReader())
                //    {
                //        while (r.Read())
                //        {
                //            int count = r.FieldCount;

                //            if (count == 1)
                //            {
                //                frmMainWindow mainWindow = new frmMainWindow(connectionString);
                //                mainWindow.Show();
                //                loginForm.Hide();
                //            }
                //            else
                //            {
                //                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            }
                //        }
                //    }
                //}
            }
        }

        public static string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _userName = string.Empty;
            _password = string.Empty;

            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
    }
}
