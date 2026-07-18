using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DomainLayer.Models
{
    public class Employes
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public IFormFile? ProfileImagePath { get; set; }
        public string? ExistingProfileImagePath { get; set; }
    }
}
