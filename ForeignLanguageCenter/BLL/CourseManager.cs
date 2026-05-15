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
    internal class CourseManager
    {
        DatabaseConnection db = new DatabaseConnection();
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
    }
}
