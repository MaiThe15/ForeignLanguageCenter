using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageCenter.Models
{
    internal class TransactionDetail
    {
        public int TransactionID { get; set; }
        public string Makh { get; set; } // Mã khóa học / Mã lớp học
        public decimal UnitPrice { get; set; } // Học phí tại thời điểm đăng ký
    }
}
