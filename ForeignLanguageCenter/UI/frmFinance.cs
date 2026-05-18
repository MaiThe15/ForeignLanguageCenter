using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ForeignLanguageCenter; // Khớp với lớp ExcelExporter trong dự án của bạn

namespace ForeignLanguageCenter.UI
{
    /// <summary>
    /// Form thống kê số lượng học viên theo khóa học.
    /// </summary>
    public partial class frmFinance : Form
    {
        private string connectionString =
            "Data Source=.;Initial Catalog=ForeignLanguageCenterDB;Integrated Security=True";

        public frmFinance()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.frmFinance_Load);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
        }

        /// <summary>
        /// Tải dữ liệu khi form mở.
        /// </summary>
        private void frmFinance_Load(object sender, EventArgs e)
        {
            LoadCourseStatistics();
        }

        /// <summary>
        /// Hiển thị thống kê khóa học lên DataGridView và Chart.
        /// </summary>
        private void LoadCourseStatistics()
        {
            DataTable dt = new DataTable();

            string query = @" SELECT c.CourseName AS [Course Name], COUNT(t.TransactionID) AS [Total Students]
                FROM Courses c
                LEFT JOIN Transactions t
                    ON c.CourseID = t.CourseID
                GROUP BY c.CourseName";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                dgvFinance.DataSource = dt;

                chartFinance.Series.Clear();
                chartFinance.Titles.Clear();

                chartFinance.Titles.Add(
                    "STUDENT COUNT BY COURSE STATISTICS");

                Series series = new Series("Students")
                {
                    XValueMember = "Course Name",
                    YValueMembers = "Total Students",
                    ChartType = SeriesChartType.Column
                };

                chartFinance.Series.Add(series);

                chartFinance.DataSource = dt;
                chartFinance.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Database connection error: " + ex.Message, "QA System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xuất dữ liệu thống kê ra file Excel.
        /// </summary>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportDataGridViewToExcel( dgvFinance, "Course_Registration_Statistics_Report");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmFinance_Load_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Đóng form hiện tại.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
