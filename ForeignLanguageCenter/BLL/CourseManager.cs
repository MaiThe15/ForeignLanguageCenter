using ForeignLanguageCenter.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageCenter.BLL
{
    /// <summary>
    /// Xử lý các chức năng liên quan đến khóa học.
    /// </summary>
    internal class CourseManager
    {
        DatabaseConnection db = new DatabaseConnection();

        /// <summary>
        /// Lấy danh sách tất cả khóa học.
        /// </summary>
        public DataTable GetAllCourses()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM Courses";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        /// <summary>
        /// Thêm khóa học mới.
        /// </summary>
        public void AddCourse(string name, decimal fee)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "INSERT INTO Courses (CourseName, TuitionFee) VALUES (@Name, @Fee)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Fee", fee);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Cập nhật thông tin khóa học.
        /// </summary>
        public void UpdateCourse(int id, string name, decimal fee)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "UPDATE Courses SET CourseName=@Name, TuitionFee=@Fee WHERE CourseID=@ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Fee", fee);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Xóa khóa học theo mã khóa học.
        /// </summary>
        public void DeleteCourse(int id)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "DELETE FROM Courses WHERE CourseID=@ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tìm kiếm khóa học theo ID, tên hoặc học phí.
        /// </summary>
        public DataTable SearchCourses(string id, string name, string fee)
        {
            DataTable dt = GetAllCourses();

            string filter = "";

            if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int CourseID))
            {
                filter += $"CourseID = {CourseID}";
            }

            if (!string.IsNullOrEmpty(name))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"CourseName LIKE '%{name}%'";
            }

            if (!string.IsNullOrEmpty(fee) && decimal.TryParse(fee, out decimal tuitionFee))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"TuitionFee = {tuitionFee}";
            }

            DataView dv = dt.DefaultView;

            if (!string.IsNullOrEmpty(filter))
            {
                dv.RowFilter = filter;
            }

            return dv.ToTable();
        }

        /// <summary>
        /// Kiểm tra khóa học có tồn tại hay không.
        /// </summary>
        public bool IsCourseExist(int courseID)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Courses WHERE CourseID = @ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", courseID);

                conn.Open();

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
    }
}
