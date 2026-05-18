using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageCenter.Models
{
    /// <summary>
    /// Lưu thông tin các giao dịch.
    /// </summary>
    internal class Transaction
    {
        public int TransactionID { get; set; }
        public int courseID { get; set; }
        public int StudentID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ProcessedBy { get; set; }
        public decimal AmountPaid { get; set; }

    }
}
