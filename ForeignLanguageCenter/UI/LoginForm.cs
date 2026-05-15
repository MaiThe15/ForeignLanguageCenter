using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForeignLanguageCenter.BLL;
using ForeignLanguageCenter.Models;

namespace ForeignLanguageCenter.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        { 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // Kiểm tra dữ liệu đầu vào (yêu cầu bắt buộc của đề bài)
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please fill Username and Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AccountManager accManager = new AccountManager();
            Account acc = accManager.Login(user, pass);

            if (acc != null)
            {
                MessageBox.Show($"Login success! Welcome {acc.Username} ({acc.Role})", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Truyền quyền (Role) sang MainForm
                MainForm main = new MainForm(acc.Role);
                this.Hide(); // Ẩn form đăng nhập
                main.ShowDialog(); // Hiển thị form chính
                this.Close(); // Đóng hẳn ứng dụng khi form chính đóng
            }
            else
            {
                MessageBox.Show("Incorrect email or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
