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
namespace ForeignLanguageCenter.Models
{
    public partial class CourseManagerment : Form
    {
        CourseManager courseBLL = new CourseManager();
        public CourseManagerment()
        {
            InitializeComponent();
        }

        private void frmCourse_Load(object sender, EventArgs e)
        {
            LoadData();

            dgvCourseCart.Columns.Add("CourseID", "Course ID");
            dgvCourseCart.Columns.Add("CourseName", "Course Name");
            dgvCourseCart.Columns.Add("TuitionFee", "Tuition Fee");
        }
        private void LoadData()
        {
            dgvCourse.DataSource = courseBLL.GetAllCourses();
        }

        private void txtCourseID_Click(object sender, EventArgs e)
        {

        }
        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Course Name cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra Tuition Fee có phải là số không
            if (!decimal.TryParse(txtTuitionFee.Text, out decimal fee))
            {
                MessageBox.Show("Tuition Fee must be a valid number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            try
            {
                courseBLL.AddCourse(txtCourseName.Text, decimal.Parse(txtTuitionFee.Text));
                MessageBox.Show("Course added successfully!", "Success");
                LoadData();
                btnClear_Click(sender, e);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            try
            {
                if (dgvCourse.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dgvCourse.CurrentRow.Cells["CourseID"].Value);
                    courseBLL.UpdateCourse(id, txtCourseName.Text, decimal.Parse(txtTuitionFee.Text));
                    MessageBox.Show("Course updated successfully!", "Success");
                    LoadData();
                    btnClear_Click(sender, e);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCourse.CurrentRow != null)
                {
                    DialogResult result = MessageBox.Show("Delete this course?", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvCourse.CurrentRow.Cells["CourseID"].Value);
                        courseBLL.DeleteCourse(id);
                        LoadData();
                        btnClear_Click(sender, e);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCourseID.Clear();
            txtCourseName.Clear();
            txtTuitionFee.Clear();
            txtCourseName.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void Search_Course_Click(object sender, EventArgs e)
        {
            dgvCourse.DataSource = courseBLL.SearchCourses(txtCourseID.Text, txtCourseName.Text, txtTuitionFee.Text);
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourse.CurrentRow == null)
            {
                MessageBox.Show("Please select a course!");
                return;
            }

            int courseID = Convert.ToInt32(dgvCourse.CurrentRow.Cells["CourseID"].Value);
            string courseName = dgvCourse.CurrentRow.Cells["CourseName"].Value.ToString();
            decimal tuitionFee = Convert.ToDecimal(dgvCourse.CurrentRow.Cells["TuitionFee"].Value);

            foreach (DataGridViewRow row in dgvCourseCart.Rows)
            {
                if (row.Cells["CourseID"].Value != null &&
                    Convert.ToInt32(row.Cells["CourseID"].Value) == courseID)
                {
                    MessageBox.Show("Course already added!");
                    return;
                }
            }

            dgvCourseCart.Rows.Add(courseID, courseName, tuitionFee);
        }

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
                MessageBox.Show("Chọn khóa học cần xóa");
            }

}
        private void Payment_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvCourseCart.Rows)
            {
                total += Convert.ToDecimal(row.Cells["TuitionFee"].Value);
            }

            DialogResult result = MessageBox.Show(
                "Total payment: " + total.ToString("N0") + " VND\n\nDo you want to continue?",
                "Payment Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    "Payment successful!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                dgvCourseCart.Rows.Clear();
            }

        }
    }
}
