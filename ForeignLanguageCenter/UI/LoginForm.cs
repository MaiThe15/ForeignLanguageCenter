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
    /// <summary>
    /// Form đăng nhập hệ thống.
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Xử lý đăng nhập người dùng.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) ||
                string.IsNullOrEmpty(pass))
            {
                MessageBox.Show(
                    "Please fill Username and Password!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            AccountManager accManager = new AccountManager();

            Account acc = accManager.Login(user, pass);

            if (acc != null)
            {
                MessageBox.Show(
                    $"Login success! Welcome {acc.Username} ({acc.Role})",
                    "Announcement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MainForm main = new MainForm(
                    acc.Username,
                    acc.Role);

                this.Hide();

                main.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Incorrect email or password!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
