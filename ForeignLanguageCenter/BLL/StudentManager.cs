using ForeignLanguageCenter.DAL;
using System;
using System.Collections.Generic;
using System.Data;
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

        // Tương tự, bạn sẽ viết các hàm AddStudent(Student s), UpdateStudent, DeleteStudent ở đây...
    }
}
