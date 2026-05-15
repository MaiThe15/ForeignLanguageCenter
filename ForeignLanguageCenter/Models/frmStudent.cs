using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForeignLanguageCenter.Models
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtStatus.Text = "Active"; // Mặc định là Active
            txtStudentID.Focus();
        }

    }
}
