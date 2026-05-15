using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    internal class DatabaseConnection
    {
        private static string connectionString =
     "Server=localhost;Database=QuanLyAnhNgu;Integrated Security=True;TrustServerCertificate=True;";

        // ========= TRƯỜNG HỢP 2: TV1 đã tạo, đổi tên server và database =========
        // private static string connectionString = 
        //     "Server=TEN_SERVER_CUA_TV1;Database=TEN_DATABASE_CUA_TV1;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
