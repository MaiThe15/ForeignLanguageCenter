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
    /// Xử lý các chức năng liên quan đến học viên.
    /// </summary>
    internal class StudentManager
    {
        private DatabaseConnection db;

        public StudentManager()
        {
            db = new DatabaseConnection();
        }

        /// <summary>
        /// Lấy danh sách tất cả học viên.
        /// </summary>
        public DataTable GetAllStudents()
        {
            string query = "SELECT StudentID AS [StudentID], FullName AS [FullName], PhoneNumber AS [PhoneNumber], Status AS [Status] FROM Students";

            return db.ExecuteQuery(query);
        }

        /// <summary>
        /// Thêm học viên mới.
        /// </summary>
        public void AddStudent(string name, string phone, string status)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string query = "INSERT INTO Students (FullName, PhoneNumber, Status) VALUES (@Name, @Phone, @Status)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Status", status);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Xóa học viên theo mã học viên.
        /// </summary>
        public void DeleteStudent(int id)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "DELETE FROM Students WHERE StudentID=@ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Cập nhật thông tin học viên.
        /// </summary>
        public void UpdateStudent(int id, string name, string phone, string status)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "UPDATE Students SET FullName=@Name, PhoneNumber=@Phone, Status=@Status WHERE StudentID=@ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Status", status);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tìm kiếm học viên theo thông tin nhập vào.
        /// </summary>
        public DataTable SearchStudents(string id, string name, string phone, string status)
        {
            DataTable dt = GetAllStudents();

            string filter = "";

            if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int studentId))
            {
                filter += $"StudentID = {studentId}";
            }

            if (!string.IsNullOrEmpty(name))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"FullName LIKE '%{name}%'";
            }

            if (!string.IsNullOrEmpty(phone))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"PhoneNumber LIKE '%{phone}%'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"Status = '{status}'";
            }

            DataView dv = dt.DefaultView;

            if (!string.IsNullOrEmpty(filter))
            {
                dv.RowFilter = filter;
            }

            return dv.ToTable();
        }

        /// <summary>
        /// Kiểm tra học viên có tồn tại hay không.
        /// </summary>
        public bool IsStudentExist(int studentID)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Students WHERE StudentID = @ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", studentID);

                conn.Open();

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
    }
}
