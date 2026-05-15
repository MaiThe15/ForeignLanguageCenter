using ForeignLanguageCenter.BLL;
using ForeignLanguageCenter.Models;
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
       
        private void LoadStudentData()
        {
            // Giao diện (UI) chỉ gọi tầng Logic (BLL), không dính dáng đến câu lệnh SQL
            dgvHocVien.DataSource = studentManager.GetAllStudents();
        }

        // Phần phân quyền sẽ được thêm vào đây
        private string currentUserRole; // Biến lưu trữ quyền của người đang đăng nhập

        // Sửa hàm tạo (Constructor) để nhận biến role
        public MainForm(string role)
        {
            InitializeComponent();
            currentUserRole = role;
            studentManager = new StudentManager();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyAuthorization(); // Gọi hàm phân quyền khi form vừa load lên
            LoadStudentData();
        }

        // Hàm xử lý phân quyền
        private void ApplyAuthorization()
        {
            if (currentUserRole == "User")
            {
                // Giả sử bạn có các control này trên form (thay bằng tên thật của bạn)
                // Nhân viên (User) sẽ KHÔNG ĐƯỢC XÓA dữ liệu và KHÔNG ĐƯỢC XEM THỐNG KÊ

                // Vô hiệu hóa nút Xóa (Nút mờ đi)
                // btnXoaHocVien.Enabled = false; 
                // btnXoaKhoaHoc.Enabled = false;

                // Hoặc ẩn hẳn Menu Thống kê
                // menuThongKe.Visible = false; 
            }
            else if (currentUserRole == "Admin")
            {
                // Admin thì có toàn quyền, không cần ẩn/khóa gì cả
            }
        }

        private void dgvHocVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnCourse_Click(object sender, EventArgs e)
        {

        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            frmStudent fStudent = new frmStudent();
            this.Hide();
            fStudent.Show();
        }
    }
    }
}
