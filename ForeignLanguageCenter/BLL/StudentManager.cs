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
            string query = "SELECT MaHV AS [Mã HV], TenHV AS [Họ và Tên], SoDienThoai AS [SĐT], TrangThai AS [Trạng Thái] FROM HocVien";
            return db.ExecuteQuery(query);
        }

        // Tương tự, bạn sẽ viết các hàm AddStudent(Student s), UpdateStudent, DeleteStudent ở đây...
    }
}
