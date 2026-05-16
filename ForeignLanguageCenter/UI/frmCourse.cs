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
    public partial class frmCourse : Form
    {
        CourseManager courseBLL = new CourseManager();
        public frmCourse()
        {
            InitializeComponent();
        }

        private void frmCourse_Load(object sender, EventArgs e)
        {
            LoadData();
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
    }
}
