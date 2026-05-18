using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForeignLanguageCenter.DAL;

namespace ForeignLanguageCenter.BLL
{
    /// <summary>
    /// Xử lý các chức năng liên quan đến giao dịch.
    /// </summary>
    internal class TransactionManager
    {
        private DatabaseConnection db;

        public TransactionManager()
        {
            db = new DatabaseConnection();
        }

        /// <summary>
        /// Lấy danh sách tất cả giao dịch.
        /// </summary>
        public DataTable GetAllTransactions()
        {
            string query = @"SELECT TransactionID AS [TransactionID], StudentID AS [StudentID], CourseID AS [CourseID], TransactionDate AS [TransactionDate], ProcessedBy AS [ProcessedBy], AmountPaid AS [AmountPaid] FROM Transactions";

            return db.ExecuteQuery(query);
        }

        /// <summary>
        /// Thêm giao dịch mới.
        /// </summary>
        public int AddTransaction(int studentID, int courseID, string processedBy, decimal amountPaid)
        {
            StudentManager st = new StudentManager();
            CourseManager cm = new CourseManager();

            if (st.IsStudentExist(studentID) == false)
            {
                throw new Exception("Student not found.");
            }

            if (cm.IsCourseExist(courseID) == false)
            {
                throw new Exception("Course not found.");
            }

            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"INSERT INTO Transactions(StudentID, CourseID, TransactionDate, ProcessedBy, AmountPaid) VALUES (@StudentID, @CourseID, GETDATE(), @ProcessedBy, @AmountPaid); SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                cmd.Parameters.AddWithValue("@ProcessedBy", processedBy);
                cmd.Parameters.AddWithValue("@AmountPaid", amountPaid);

                conn.Open();

                int transactionID = Convert.ToInt32(cmd.ExecuteScalar());

                return transactionID;
            }
        }

        /// <summary>
        /// Cập nhật thông tin giao dịch.
        /// </summary>
        public void UpdateTransaction(int transactionID, int studentID, int courseID, decimal amountPaid, string processedBy, DateTime transactionDate)
        {
            StudentManager st = new StudentManager();
            CourseManager cm = new CourseManager();

            if (st.IsStudentExist(studentID) == false)
            {
                throw new Exception("Student not found.");
            }

            if (cm.IsCourseExist(courseID) == false)
            {
                throw new Exception("Course not found.");
            }

            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @" UPDATE Transactions SET StudentID = @StudentID, CourseID = @CourseID, AmountPaid = @AmountPaid, ProcessedBy = @ProcessedBy, TransactionDate = @TransactionDate WHERE TransactionID = @TransactionID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@TransactionID", transactionID);
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                cmd.Parameters.AddWithValue("@AmountPaid", amountPaid);
                cmd.Parameters.AddWithValue("@ProcessedBy", processedBy);
                cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Xóa giao dịch theo mã giao dịch.
        /// </summary>
        public void DeleteTransaction(int transactionID)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = "DELETE FROM Transactions WHERE TransactionID = @ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", transactionID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tìm kiếm giao dịch theo các điều kiện.
        /// </summary>
        public DataTable SearchTransactions( string transactionID, string studentID, string courseID, string processedBy, string amountPaid, DateTime StartDate, DateTime EndDate)
        {
            DataTable dt = GetAllTransactions();

            string filter = "";

            if (!string.IsNullOrEmpty(transactionID)
                && int.TryParse(transactionID, out int transId))
            {
                filter += $"TransactionID = {transId}";
            }

            if (!string.IsNullOrEmpty(studentID)
                && int.TryParse(studentID, out int stuId))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"StudentID = {stuId}";
            }

            if (!string.IsNullOrEmpty(courseID)
                && int.TryParse(courseID, out int couId))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"CourseID = {couId}";
            }

            if (!string.IsNullOrEmpty(processedBy))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"ProcessedBy LIKE '%{processedBy}%'";
            }

            if (!string.IsNullOrEmpty(amountPaid)
                && decimal.TryParse(amountPaid, out decimal amount))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"AmountPaid = {amount}";
            }

            if (filter != "")
                filter += " AND ";

            filter += string.Format( "TransactionDate >= #{0:MM/dd/yyyy}# AND TransactionDate <= #{1:MM/dd/yyyy}#", StartDate, EndDate.AddDays(1));

            DataView dv = dt.DefaultView;

            if (!string.IsNullOrEmpty(filter))
            {
                dv.RowFilter = filter;
            }

            return dv.ToTable();
        }
    }
}
