using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
    /// Form quản lý giao dịch.
    /// </summary>
    public partial class frmTransaction : Form
    {
        private TransactionManager transactionManager = new TransactionManager();
        private TransactionManager tm = new TransactionManager();

        private string currentUsername;
        private string currentUserRole;

        public frmTransaction(string username, string role)
        {
            InitializeComponent();
            currentUsername = username;
            currentUserRole = role;
        }
        private void ApplyAuthorization()
        {
            if (currentUserRole == "User")
            {
                btnDeleteTransaction.Visible = false;
            }
        }

        /// <summary>
        /// Tải dữ liệu giao dịch khi form mở.
        /// </summary>
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            dgvTransactions.DataSource =
                transactionManager.GetAllTransactions();
            dgvTransactions.DataSource = transactionManager.GetAllTransactions();
            ApplyAuthorization();
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập hợp lệ.
        /// </summary>
        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                MessageBox.Show(
                    "Student ID cannot be empty!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStudentID.Focus();

                return false;
            }

            if (!int.TryParse(txtStudentID.Text, out int studentID))
            {
                MessageBox.Show(
                    "Student ID must be a number!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStudentID.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCourseID.Text))
            {
                MessageBox.Show(
                    "Course ID cannot be empty!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCourseID.Focus();

                return false;
            }

            if (!int.TryParse(txtCourseID.Text, out int courseID))
            {
                MessageBox.Show(
                    "Course ID must be a number!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCourseID.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAmountPaid.Text))
            {
                MessageBox.Show(
                    "Amount Paid cannot be empty!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAmountPaid.Focus();

                return false;
            }

            if (!decimal.TryParse(txtAmountPaid.Text, out decimal amount))
            {
                MessageBox.Show(
                    "Amount Paid must be a valid number!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAmountPaid.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Xóa dữ liệu trên form.
        /// </summary>
        private void btnClearTransaction_Click(object sender, EventArgs e)
        {
            txtTransactionID.Clear();
            txtStudentID.Clear();
            txtCourseID.Clear();
            txtAmountPaid.Clear();
            txtProcessedBy.Clear();

            dtTransactionDate.Value = DateTime.Now;

            txtTransactionID.Focus();
        }

        /// <summary>
        /// Hiển thị danh sách giao dịch.
        /// </summary>
        private void LoadData()
        {
            dgvTransactions.DataSource =
                transactionManager.GetAllTransactions();
        }

        /// <summary>
        /// Thêm giao dịch mới.
        /// </summary>
        private void AddTransaction_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            try
            {
                transactionManager.AddTransaction(
                    int.Parse(txtStudentID.Text),
                    int.Parse(txtCourseID.Text),
                    currentUsername,
                    decimal.Parse(txtAmountPaid.Text));

                MessageBox.Show(
                    "Transaction added successfully!",
                    "Success");

                LoadData();

                btnClearTransaction_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật giao dịch.
        /// </summary>
        private void btnUpdateTransaction_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            try
            {
                if (dgvTransactions.CurrentRow != null)
                {
                    int id = Convert.ToInt32(
                        dgvTransactions.CurrentRow.Cells["TransactionID"].Value);

                    int studentID = int.Parse(txtStudentID.Text);

                    int courseID = int.Parse(txtCourseID.Text);

                    decimal amountPaid =
                        decimal.Parse(txtAmountPaid.Text);

                    DateTime transactionDate =
                        dtTransactionDate.Value;

                    tm.UpdateTransaction(
                        id,
                        studentID,
                        courseID,
                        amountPaid,
                        currentUsername,
                        transactionDate
                    );

                    MessageBox.Show(
                        "Transaction updated successfully!",
                        "Success");

                    LoadData();

                    btnClearTransaction_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa giao dịch.
        /// </summary>
        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransactions.CurrentRow != null)
                {
                    DialogResult result = MessageBox.Show(
                        "Delete this transaction?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(
                            dgvTransactions.CurrentRow.Cells["TransactionID"].Value
                        );

                        tm.DeleteTransaction(id);

                        LoadData();

                        btnClearTransaction_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Quay lại form chính.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["MainForm"];

            if (mainForm != null)
            {
                mainForm.Show();

                this.Close();
            }
        }

        /// <summary>
        /// Tìm kiếm giao dịch.
        /// </summary>
        private void btnSearch_Transaction_Click(object sender, EventArgs e)
        {
            dgvTransactions.DataSource =
                transactionManager.SearchTransactions(
                    txtTransactionID.Text,
                    txtStudentID.Text,
                    txtCourseID.Text,
                    txtProcessedBy.Text,
                    txtAmountPaid.Text,
                    dtTransactionDate.Value.Date);
        }
    }
}
