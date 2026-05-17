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

namespace ForeignLanguageCenter.UI
{
    public partial class frmTransaction : Form
    {
        private TransactionManager transactionManager = new TransactionManager();
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            dgvTransactions.DataSource = transactionManager.GetAllTransactions();
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
            dgvTransactions.DataSource = transactionManager.SearchTransactions(txtTransactionID.Text, txtStudentID.Text, txtCourseID.Text, txtProcessedBy.Text, txtAmountPaid.Text, dtstartDate.Value.Date, dtEndDate.Value.Date);
        }

    }
}
