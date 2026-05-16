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
    internal class StudentManager
    {
        private DatabaseConnection db;

        public StudentManager()
        {
            db = new DatabaseConnection();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách học viên
        /// </summary>
        public DataTable GetAllStudents()
        {
            string query = "SELECT StudentID AS [StudentID], FullName AS [FullName], PhoneNumber AS [PhoneNumber], Status AS [Status] FROM Students";
            return db.ExecuteQuery(query);
        }

        // File: BLL/StudentManager.cs
        public void AddStudent(string name, string phone, string status)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                // StudentID không cần thêm vì là IDENTITY tự tăng trong SQL
                string query = "INSERT INTO Students (FullName, PhoneNumber, Status) VALUES (@Name, @Phone, @Status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Status", status);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
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
        }// Tương tự, bạn sẽ viết các hàm AddStudent(Student s), UpdateStudent, DeleteStudent ở đây...
         // 3. Nghiệp vụ Sửa (Update)
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

        public DataTable SearchStudents(string id, string name, string phone, string status)
        {
            DataTable dt = GetAllStudents();

            string filter = "";

            // Tìm theo StudentID
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

            // Tìm theo PhoneNumber
            if (!string.IsNullOrEmpty(phone))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"PhoneNumber LIKE '%{phone}%'";
            }

            // Tìm theo Status
            if (!string.IsNullOrEmpty(status))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"Status = {status}";
            }

            DataView dv = dt.DefaultView;


            if (!string.IsNullOrEmpty(filter))
            {
                dv.RowFilter = filter;
            }

            return dv.ToTable();
        }

    }
}
