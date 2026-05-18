using ForeignLanguageCenter.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForeignLanguageCenter.BLL;
namespace ForeignLanguageCenter.Models
{
    public partial class frmStudent : Form

    {
        StudentManager studentBLL = new StudentManager();
        private string currentUserRole;
        public frmStudent(string role)
        {
            InitializeComponent();
            currentUserRole = role;
        }

        private void ApplyAuthorization()
        {
            if (currentUserRole == "User")
            {
                btnDelete.Visible = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["MainForm"]; // "MainForm" là tên Name của Form chính

            if (mainForm != null)
            {
                mainForm.Show(); // Hiện lại form chính
                this.Close();    // Đóng (giải phóng) form Student hiện tại
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            try
            {
                dgvStudent.DataSource = studentBLL.GetAllStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmStudent_Load(object sender, EventArgs e)
        {
            LoadData();
            ApplyAuthorization();
        }
        private bool IsValidInput()
        {
            // 1. Kiểm tra để trống
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Full Name and Phone Number cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Kiểm tra định dạng số điện thoại (Chỉ lấy số và đúng 10 chữ số)
            // Biểu thức chính quy: Kiểm tra chuỗi có đúng 10 chữ số từ 0-9
            if (!Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Phone Number must be exactly 10 digits!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            return true;
        } 

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtStatus.Text = "Active"; // Mặc định là Active
            txtStudentID.Focus();
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudent.Rows[e.RowIndex];
                txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtPhone.Text = row.Cells["PhoneNumber"].Value.ToString();
                txtStatus.Text = row.Cells["Status"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return; // Nếu dữ liệu sai thì dừng lại

            try
            {
                studentBLL.AddStudent(txtFullName.Text, txtPhone.Text, txtStatus.Text);
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding student: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            try
            {
                if (dgvStudent.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dgvStudent.CurrentRow.Cells["StudentID"].Value);
                    studentBLL.UpdateStudent(id, txtFullName.Text, txtPhone.Text, txtStatus.Text);

                    MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnClear_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Please select a student from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStudent.CurrentRow != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvStudent.CurrentRow.Cells["StudentID"].Value);
                        studentBLL.DeleteStudent(id);

                        MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        btnClear_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a student to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting student: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search_Student_Click(object sender, EventArgs e)
        {
            dgvStudent.DataSource = studentBLL.SearchStudents(txtStudentID.Text, txtFullName.Text, txtPhone.Text, txtStatus.Text);
        }
    }
}
