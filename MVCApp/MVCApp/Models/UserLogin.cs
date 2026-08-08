using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.Models
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserRegistration
    {
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}