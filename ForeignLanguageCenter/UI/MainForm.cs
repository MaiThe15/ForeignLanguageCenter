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
    public partial class MainForm : Form
    {
        private StudentManager studentManager;


        // Phần phân quyền sẽ được thêm vào đây
        private string currentUserRole; // Biến lưu trữ quyền của người đang đăng nhập
        private string currentUsername;

        // Sửa hàm tạo (Constructor) để nhận biến role
        public MainForm(string username, string role)
        {
            InitializeComponent();
            currentUsername = username;
            currentUserRole = role;
            studentManager = new StudentManager();
        }

        // Hàm xử lý phân quyền
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
        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent fStudent = new frmStudent(currentUserRole);
            fStudent.ShowDialog();
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseManagerment fCourse = new CourseManagerment(currentUsername, currentUserRole);
            fCourse.ShowDialog();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void tranSactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransaction frmTransaction = new frmTransaction(currentUsername, currentUserRole);
            frmTransaction.ShowDialog();
        }

        private void financeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.frmFinance financeForm = new UI.frmFinance();

            // 2. Cấu hình để Form khi bật lên sẽ tự động nằm ở chính giữa màn hình máy tính
            financeForm.StartPosition = FormStartPosition.CenterScreen;

            // 3. Hiển thị Form lên
            financeForm.Show();
        }
    }
}
