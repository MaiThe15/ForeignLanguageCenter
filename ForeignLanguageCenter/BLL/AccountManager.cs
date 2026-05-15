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
    internal class AccountManager
    {
        private DatabaseConnection db = new DatabaseConnection();

        public Account Login(string username, string password)
        {
            Account loggedInUser = null;
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    // Dùng tham số hóa để chống SQL Injection
                    string query = "SELECT Username, Role FROM Accounts WHERE Username = @user AND Password = @pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Nếu có dữ liệu trả về tức là đúng User/Pass
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
