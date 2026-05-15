using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageCenter.Models
{
    internal class Account
    {
        public string Username { get; set; }
        public string Role { get; set; } // "Admin" hoặc "User"
    }
}
