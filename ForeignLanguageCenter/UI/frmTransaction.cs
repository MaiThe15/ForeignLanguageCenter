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
    public partial class frmTransaction : Form
    {
        private TransactionManager transactionManager = new TransactionManager();
        TransactionManager tm = new TransactionManager();
        private string currentUsername;

        public frmTransaction(string username)
        {
            InitializeComponent();
            currentUsername = username;
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            dgvTransactions.DataSource = transactionManager.GetAllTransactions();
        }
        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                MessageBox.Show("Student ID cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentID.Focus();
                return false;
            }

            if (!int.TryParse(txtStudentID.Text, out int studentID))
            {
                MessageBox.Show( "Student ID must be a number!", "Validation Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCourseID.Text))
            { MessageBox.Show( "Course ID cannot be empty!",  "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                txtCourseID.Focus();
                return false;
            }

            if (!int.TryParse(txtCourseID.Text, out int courseID))
            {
                MessageBox.Show( "Course ID must be a number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCourseID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAmountPaid.Text))
            {
                MessageBox.Show( "Amount Paid cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                txtAmountPaid.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAmountPaid.Text, out decimal amount))
            {
                MessageBox.Show( "Amount Paid must be a valid number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                txtAmountPaid.Focus();
                return false;
            }

            return true;
        }

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
        private void LoadData()
        {
            dgvTransactions.DataSource = transactionManager.GetAllTransactions();
        }
        private void AddTransaction_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            try
            {
                transactionManager.AddTransaction(int.Parse(txtStudentID.Text), int.Parse(txtCourseID.Text), currentUsername, decimal.Parse(txtAmountPaid.Text));
                MessageBox.Show("Transaction added successfully!", "Success");
                LoadData();
                btnClearTransaction_Click(sender, e);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void btnUpdateTransaction_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            try
            {
                if (dgvTransactions.CurrentRow != null)
                {;
                    int id = Convert.ToInt32(dgvTransactions.CurrentRow.Cells["TransactionID"].Value);

                    int studentID = int.Parse(txtStudentID.Text);
                    int courseID = int.Parse(txtCourseID.Text);
                    decimal amountPaid = decimal.Parse(txtAmountPaid.Text);
                    DateTime transactionDate = dtTransactionDate.Value;

                    

                    tm.UpdateTransaction(
                        id,
                        studentID,
                        courseID,
                        amountPaid,
                        currentUsername,
                        transactionDate
                    );

                    MessageBox.Show("Transaction updated successfully!", "Success");

                    LoadData();
                    btnClearTransaction_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

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
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["MainForm"]; // "MainForm" là tên Name của Form chính

            if (mainForm != null)
            {
                mainForm.Show(); // Hiện lại form chính
                this.Close();    // Đóng (giải phóng) form Student hiện tại
            }
        }
        private void btnSearch_Transaction_Click(object sender, EventArgs e)
        {
            dgvTransactions.DataSource = transactionManager.SearchTransactions(txtTransactionID.Text, txtStudentID.Text, txtCourseID.Text, txtProcessedBy.Text, txtAmountPaid.Text, dtTransactionDate.Value.Date);
        }


    }
}
