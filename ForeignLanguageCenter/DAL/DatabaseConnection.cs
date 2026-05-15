using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForeignLanguageCenter.DAL
{
    internal class DatabaseConnection
    {
        // Lấy chuỗi kết nối từ App.config tự động
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Hàm hỗ trợ thực thi câu lệnh SELECT trả về DataTable
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return data;
        }
    }
}
