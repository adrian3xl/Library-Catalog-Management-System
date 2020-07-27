using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class LibraryRecordVM
    {
        public int Id { get; set; }

        
        public CatalogVM Catalog { get; set; }
        [Display(Name = " Catalog Title")]
        [Required]
        public int CatalogId { get; set; }

        [Display(Name = " Customer First Name")]
        [Required]
        public string CustomerFirstname { get; set; }

        [Display(Name = " Customer Last Name")]
        [Required]
        public string CustomerLastname { get; set; }
       
        [Display(Name = " Customer Address")]
        [Required]
        public string CustomerAddress { get; set; }

        [Display(Name = " Tax Registration Number")]
        [Required]
        public string TaxRegistrationNumber { get; set; }

        [Display(Name = " Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = " Issued By")]
        [Required]
        public string IssuedBy { get; set; }
       
        [Display(Name = "Condition of Catalog when issued")]
        [Required]
        public string ConditionIssued { get; set; }

        [Display(Name = "Date and time Issued")]
        [Required]
        public DateTime DateIssued { get; set; }

        [Display(Name = "Deadline Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }

        [Display(Name = "Condition of Catalog when Recieved")]
        [Required]
        public string ConditionRecieved { get; set; }

        [Display(Name = "Recieved By")]
        [Required]
        public string RecievedBy { get; set; }

        [Display(Name = "DateRecieved")]
       // [Required]
        public DateTime DateRecieved { get; set; }

        [Display(Name = "Staff Comment")]
        public string StaffComment { get; set; }


        public IEnumerable<SelectListItem> Catalogs { get; set; }
    }
}
