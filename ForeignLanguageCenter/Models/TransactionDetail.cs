using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageCenter.Models
{
    internal class TransactionDetail
    {
        public int TransactionDetailID { get; set; }
        public int TransactionID { get; set; }
        public int CourseID { get; set; }
        public decimal Price { get; set; }
    }
}
