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
    internal class TransactionManager
    {
        private DatabaseConnection db;

        public TransactionManager()
        {
            db = new DatabaseConnection();
        }

        public DataTable GetAllTransactions()
        {
            string query = @"
                SELECT TransactionID AS [TransactionID], StudentID AS [StudentID], TransactionDate AS [TransactionDate], ProcessedBy AS [ProcessedBy], TotalAmount AS [TotalAmount] FROM Transactions
            ";

            return db.ExecuteQuery(query);
        }

        public int AddTransaction(int studentID, string processedBy, decimal totalAmount)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"
                    INSERT INTO Transactions
                    (StudentID, TransactionDate, ProcessedBy, TotalAmount)
                    VALUES
                    (@StudentID, GETDATE(), @ProcessedBy, @TotalAmount);

                    SELECT SCOPE_IDENTITY();
                ";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@ProcessedBy", processedBy);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                conn.Open();

                int transactionID =
                    Convert.ToInt32(cmd.ExecuteScalar());

                return transactionID;
            }
        }

        public void AddTransactionDetail(int transactionID, int courseID, decimal price)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"
                    INSERT INTO TransactionDetails
                    (TransactionID, CourseID, Price)
                    VALUES
                    (@TransactionID, @CourseID, @Price)
                ";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@TransactionID", transactionID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                cmd.Parameters.AddWithValue("@Price", price);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable SearchTransactions(string transactionID, string studentID, string processedBy, string totalAmount, DateTime fromDate, DateTime toDate)
        {
            DataTable dt = GetAllTransactions();

            string filter = "";

            // TransactionID
            if (!string.IsNullOrEmpty(transactionID)
                && int.TryParse(transactionID, out int transId))
            {
                filter += $"TransactionID = {transId}";
            }

            // StudentID
            if (!string.IsNullOrEmpty(studentID)
                && int.TryParse(studentID, out int stuId))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"StudentID = {stuId}";
            }

            // ProcessedBy
            if (!string.IsNullOrEmpty(processedBy))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"ProcessedBy LIKE '%{processedBy}%'";
            }

            // TotalAmount
            if (!string.IsNullOrEmpty(totalAmount)
                && decimal.TryParse(totalAmount, out decimal amount))
            {
                if (filter != "")
                    filter += " AND ";

                filter += $"TotalAmount = {amount}";
            }

            // FromDate -> ToDate
            if (filter != "")
                filter += " AND ";

            filter += string.Format(
                "TransactionDate >= #{0:MM/dd/yyyy}# AND TransactionDate <= #{1:MM/dd/yyyy}#",fromDate, toDate);

            DataView dv = dt.DefaultView;

            if (!string.IsNullOrEmpty(filter))
            {
                dv.RowFilter = filter;
            }

            return dv.ToTable();
        }

        public string GetTransactionDetails(int transactionID)
        {
            string query = @" SELECT c.CourseName, td.Price FROM TransactionDetails td JOIN Courses c ON td.CourseID = c.CourseID WHERE td.TransactionID = " + transactionID;

            DataTable dt = db.ExecuteQuery(query);

            string detail = "Danh sách khóa học:\n\n";

            foreach (DataRow row in dt.Rows)
            {
                detail += "- " + row["CourseName"].ToString()
                       + " | Price: "
                       + Convert.ToDecimal(row["Price"]).ToString("N0")
                       + " VNĐ\n";
            }

            return detail;
        }
    }
}
