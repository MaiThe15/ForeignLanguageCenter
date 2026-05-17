using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ForeignLanguageCenter; // Khớp với lớp ExcelExporter trong dự án của bạn

namespace ForeignLanguageCenter.UI
{
    public partial class frmFinance : Form
    {
        // ĐÃ SỬA: Cập nhật chuẩn tên Database thực tế của bạn (ForeignLanguageCenterDB)
        private string connectionString = "Data Source=.;Initial Catalog=ForeignLanguageCenterDB;Integrated Security=True";

        public frmFinance()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmFinance_Load);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
        }

        private void frmFinance_Load(object sender, EventArgs e)
        {
            LoadCourseStatistics();
        }

        private void LoadCourseStatistics()
        {
            DataTable dt = new DataTable();

            // ĐÃ SỬA: Truy vấn CHUẨN 100% theo các bảng [Courses] và [Transactions] từ file SQL của bạn
            // Sử dụng LEFT JOIN để khóa học nào chưa có học viên đăng ký vẫn hiển thị số lượng = 0
            string query = @"
                SELECT c.CourseName AS [Course Name], COUNT(t.TransactionID) AS [Total Students]
                FROM Courses c
                LEFT JOIN Transactions t ON c.CourseID = t.CourseID
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

                // 1. Đổ dữ liệu lên bảng DataGridView công khai bằng Tiếng Anh
                dgvFinance.DataSource = dt;

                // 2. Cấu hình vẽ Chart Control (Biểu đồ cột) bằng Tiếng Anh
                chartFinance.Series.Clear();
                chartFinance.Titles.Clear();
                chartFinance.Titles.Add("STUDENT COUNT BY COURSE STATISTICS");

                Series series = new Series("Students")
                {
                    XValueMember = "Course Name",     // Khớp với tên alias cột SQL ở trên
                    YValueMembers = "Total Students",  // Khớp với tên alias cột SQL ở trên
                    ChartType = SeriesChartType.Column
                };

                chartFinance.Series.Add(series);
                chartFinance.DataSource = dt;
                chartFinance.DataBind();
            }
            catch (Exception ex)
            {
                // Thông báo lỗi bằng tiếng Anh chuyên nghiệp nếu kết nối DB thất bại
                MessageBox.Show("Database connection error: " + ex.Message, "QA System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện click nút xuất Excel báo cáo bằng tiếng Anh
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportDataGridViewToExcel(dgvFinance, "Course_Registration_Statistics_Report");
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
