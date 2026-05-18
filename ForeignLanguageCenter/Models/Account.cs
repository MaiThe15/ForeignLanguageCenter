using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignLanguageCenter.Models
{
    /// <summary>
    /// Lưu thông tin tài khoản người dùng.
    /// </summary>
    internal class Account
    {
        public string Username { get; set; }

        public string Role { get; set; }
    }
}
