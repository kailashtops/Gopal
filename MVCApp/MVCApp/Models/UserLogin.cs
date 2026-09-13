using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [StringLength(20)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; }
       // [Required]
        [StringLength(10,ErrorMessage ="len should be 10")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$",ErrorMessage ="must be alphanumeric")]
        public string Password { get; set; }
    }
}