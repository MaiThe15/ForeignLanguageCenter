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
    /// <summary>
    /// Quản lý kết nối và thao tác với cơ sở dữ liệu.
    /// </summary>
    internal class DatabaseConnection
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        /// <summary>
        /// Tạo kết nối đến SQL Server.
        /// </summary>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Thực thi câu lệnh SELECT và trả về DataTable.
        /// </summary>
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
