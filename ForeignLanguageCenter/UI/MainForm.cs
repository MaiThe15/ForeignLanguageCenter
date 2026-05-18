using ForeignLanguageCenter.BLL;
using ForeignLanguageCenter.Models;
using ForeignLanguageCenter.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForeignLanguageCenter
{
    /// <summary>
    /// Form chính của hệ thống.
    /// </summary>
    public partial class MainForm : Form
    {
        private StudentManager studentManager;

        private string currentUserRole;
        private string currentUsername;

        /// <summary>
        /// Khởi tạo form chính và nhận thông tin người dùng đăng nhập.
        /// </summary>
        public MainForm(string username, string role)
        {
            InitializeComponent();

            currentUsername = username;
            currentUserRole = role;

            studentManager = new StudentManager();
        }

        /// <summary>
        /// Phân quyền chức năng theo vai trò người dùng.
        /// </summary>
        private void ApplyAuthorization()
        {
            if (currentUserRole == "User")
            {
                financeToolStripMenuItem.Visible = false;
            }
            else if (currentUserRole == "Admin")
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Mở form quản lý học viên.
        /// </summary>
        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent fStudent = new frmStudent(currentUserRole);
<<<<<<< HEAD

=======
>>>>>>> 137b56307e2e723a7b1b7033a8c35d7543943b0f
            fStudent.ShowDialog();
        }

        /// <summary>
        /// Mở form quản lý khóa học.
        /// </summary>
        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            CourseManagerment fCourse =
                new CourseManagerment(currentUsername, currentUserRole);

=======
            CourseManagerment fCourse = new CourseManagerment(currentUsername, currentUserRole);
>>>>>>> 137b56307e2e723a7b1b7033a8c35d7543943b0f
            fCourse.ShowDialog();
        }

        /// <summary>
        /// Đăng xuất khỏi hệ thống.
        /// </summary>
        private void LogOut_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();

            this.Hide();

            login.ShowDialog();

            this.Close();
        }

        /// <summary>
        /// Mở form quản lý giao dịch.
        /// </summary>
        private void tranSactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            frmTransaction frmTransaction =
                new frmTransaction(currentUsername);

=======
            frmTransaction frmTransaction = new frmTransaction(currentUsername, currentUserRole);
>>>>>>> 137b56307e2e723a7b1b7033a8c35d7543943b0f
            frmTransaction.ShowDialog();
        }

        /// <summary>
        /// Mở form thống kê tài chính.
        /// </summary>
        private void financeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmFinance financeForm = new UI.frmFinance();

            financeForm.StartPosition =
                FormStartPosition.CenterScreen;

            financeForm.Show();
        }
    }
}
