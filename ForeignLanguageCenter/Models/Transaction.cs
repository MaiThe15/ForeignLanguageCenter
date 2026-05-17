using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageCenter.Models
{
    internal class Transaction
    {
        public int TransactionID { get; set; }
        public int StudentID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ProcessedBy { get; set; }
        public decimal TotalAmount { get; set; }
        public List<TransactionDetail> Details { get; set; } = new List<TransactionDetail>();
    }
}
