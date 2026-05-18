using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ForeignLanguageCenter.DAL;
using ForeignLanguageCenter.Models;

namespace ForeignLanguageCenter.BLL
{
    /// <summary>
    /// Xử lý các chức năng liên quan đến tài khoản.
    /// </summary>
    internal class AccountManager
    {
        private DatabaseConnection db = new DatabaseConnection();

        /// <summary>
        /// Kiểm tra đăng nhập và trả về thông tin tài khoản nếu hợp lệ.
        /// </summary>
        public Account Login(string username, string password)
        {
            Account loggedInUser = null;

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT Username, Role FROM Accounts WHERE Username = @user AND Password = @pass";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Truyền tham số để tránh SQL Injection
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Nếu tồn tại tài khoản phù hợp
                        if (reader.Read())
                        {
                            loggedInUser = new Account
                            {
                                Username = reader["Username"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Login processing error: " + ex.Message);
            }

            return loggedInUser;
        }
    }
}
