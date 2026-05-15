using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForeignLanguageCenter.BLL;

namespace ForeignLanguageCenter
{
    public partial class MainForm : Form
    {
        private StudentManager studentManager;
        public MainForm()
        {
            InitializeComponent();
            studentManager = new StudentManager();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            // Giao diện (UI) chỉ gọi tầng Logic (BLL), không dính dáng đến câu lệnh SQL
            dgvHocVien.DataSource = studentManager.GetAllStudents();
        }
    }
}
