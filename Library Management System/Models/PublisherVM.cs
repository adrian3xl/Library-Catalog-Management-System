using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class PublisherVM
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string Lastname { get; set; }

        [Display(Name = "Unique Publisher Code")]
        [Required]
        public string UniquePublisherCode { get; set; }
    }
}
