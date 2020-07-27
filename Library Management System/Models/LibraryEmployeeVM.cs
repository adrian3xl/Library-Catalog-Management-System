using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class LibraryEmployeeVM:IdentityUser
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Position { get; set; }
       
       
        [Display(Name = "Staff Identification Code")]
        [Required]
        public string StaffIdentificationCode { get; set; }

    }
}
