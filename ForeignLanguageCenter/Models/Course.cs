using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageCenter.Models
{
    internal class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public decimal TuitionFee { get; set; }
    }
}
