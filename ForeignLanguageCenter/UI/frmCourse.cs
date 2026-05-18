using ForeignLanguageCenter.BLL;
using ForeignLanguageCenter.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ForeignLanguageCenter.Models
{
    /// <summary>
    /// Form quản lý khóa học và thanh toán.
    /// </summary>
    public partial class CourseManagerment : Form
    {
        CourseManager courseBLL = new CourseManager();

        private string currentUserRole;
        private string currentUsername;

        public CourseManagerment(string username, string role)
        {
            InitializeComponent();

            currentUsername = username;
            currentUserRole = role;
        }

        /// <summary>
        /// Phân quyền chức năng theo vai trò người dùng.
        /// </summary>
        private void ApplyAuthorization()
        {
            if (currentUserRole == "User")
            {
                btnDelete.Visible = false;
            }
        }

        /// <summary>
        /// Tải dữ liệu khi form mở.
        /// </summary>
        private void frmCourse_Load(object sender, EventArgs e)
        {
            LoadData();

            dgvCourseCart.Columns.Add("CourseID", "Course ID");
            dgvCourseCart.Columns.Add("CourseName", "Course Name");
            dgvCourseCart.Columns.Add("TuitionFee", "Tuition Fee");

            ApplyAuthorization();
        }

        /// <summary>
        /// Hiển thị danh sách khóa học.
        /// </summary>
        private void LoadData()
        {
            dgvCourse.DataSource = courseBLL.GetAllCourses();
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập hợp lệ.
        /// </summary>
        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Course Name cannot be empty!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!decimal.TryParse(txtTuitionFee.Text, out decimal fee))
            {
                MessageBox.Show("Tuition Fee must be a valid number!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm khóa học mới.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            try
            {
                courseBLL.AddCourse( txtCourseName.Text, decimal.Parse(txtTuitionFee.Text));

                MessageBox.Show("Course added successfully!", "Success");

                LoadData();

                btnClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật khóa học.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            try
            {
                if (dgvCourse.CurrentRow != null)
                {
                    int id = Convert.ToInt32( dgvCourse.CurrentRow.Cells["CourseID"].Value);

                    courseBLL.UpdateCourse( id, txtCourseName.Text, decimal.Parse(txtTuitionFee.Text));

                    MessageBox.Show("Course updated successfully!", "Success");

                    LoadData();

                    btnClear_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa khóa học.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCourse.CurrentRow != null)
                {
                    DialogResult result = MessageBox.Show( "Delete this course?", "Confirm", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32( dgvCourse.CurrentRow.Cells["CourseID"].Value);
                        courseBLL.DeleteCourse(id);
                        LoadData();

                        btnClear_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa dữ liệu trên form.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCourseID.Clear();
            txtCourseName.Clear();
            txtTuitionFee.Clear();
            txtCourseName.Focus();
        }

        /// <summary>
        /// Đóng form hiện tại.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Hiển thị dữ liệu khóa học lên textbox khi chọn dòng.
        /// </summary>
        private void dgvCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCourse.Rows[e.RowIndex];

                txtCourseID.Text = row.Cells["CourseID"].Value.ToString();
                txtCourseName.Text = row.Cells["CourseName"].Value.ToString();
                txtTuitionFee.Text = row.Cells["TuitionFee"].Value.ToString();
            }
        }

        /// <summary>
        /// Tải dữ liệu khóa học vào ComboBox.
        /// </summary>
        public void LoadComboBox(ComboBox cbo)
        {
            try
            {
                var courses = courseBLL.GetAllCourses();

                cbo.DataSource = courses;
                cbo.DisplayMember = "CourseName";
                cbo.ValueMember = "CourseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        /// <summary>
        /// Tìm kiếm khóa học.
        /// </summary>
        private void Search_Course_Click(object sender, EventArgs e)
        {
            dgvCourse.DataSource = courseBLL.SearchCourses( txtCourseID.Text, txtCourseName.Text, txtTuitionFee.Text);
        }

        /// <summary>
        /// Thêm khóa học vào giỏ khóa học.
        /// </summary>
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourse.CurrentRow == null)
            {
                MessageBox.Show("Please select a course!");
                return;
            }

            int courseID = Convert.ToInt32(dgvCourse.CurrentRow.Cells["CourseID"].Value);

            string courseName = dgvCourse.CurrentRow.Cells["CourseName"].Value.ToString();

            decimal tuitionFee = Convert.ToDecimal( dgvCourse.CurrentRow.Cells["TuitionFee"].Value);

            foreach (DataGridViewRow row in dgvCourseCart.Rows)
            {
                if (row.Cells["CourseID"].Value != null && Convert.ToInt32(row.Cells["CourseID"].Value) == courseID)
                {
                    MessageBox.Show("Course already added!");
                    return;
                }
            }

            dgvCourseCart.Rows.Add(courseID, courseName, tuitionFee);
        }

        /// <summary>
        /// Xóa khóa học khỏi giỏ khóa học.
        /// </summary>
        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCourseCart.CurrentRow != null)
                {
                    dgvCourseCart.Rows.Remove(dgvCourseCart.CurrentRow);
                }
            }
            catch
            {
                MessageBox.Show("Select the course you want to delete.");
            }
        }

        /// <summary>
        /// Thực hiện thanh toán khóa học.
        /// </summary>
        private void Payment_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvCourseCart.Rows)
            {
                if (row.Cells["TuitionFee"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["TuitionFee"].Value);
                }
            }

            string input = Interaction.InputBox("Enter Student ID:", "Student Information", "");

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show( "Student ID is required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(input, out int studentID))
            {
                MessageBox.Show( "Student ID must be a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            StudentManager st = new StudentManager();

            if (!st.IsStudentExist(studentID))
            {
                MessageBox.Show("Student not found!", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            DialogResult result = MessageBox.Show( "Total payment: " + total.ToString("N0") + " VND\n\nDo you want to continue?", "Payment Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    TransactionManager tm = new TransactionManager();

                    string processedBy = currentUsername;

                    foreach (DataGridViewRow row in dgvCourseCart.Rows)
                    {
                        if (row.Cells["CourseID"].Value != null)
                        {
                            int courseID = Convert.ToInt32(row.Cells["CourseID"].Value);
                            decimal amountPaid = Convert.ToDecimal(row.Cells["TuitionFee"].Value);

                            tm.AddTransaction( studentID, courseID, processedBy, amountPaid);
                        }
                    }

                    MessageBox.Show( "Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvCourseCart.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
