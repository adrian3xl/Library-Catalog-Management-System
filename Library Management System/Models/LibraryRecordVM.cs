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
       
        [Required]
        public CatalogVM Catalog { get; set; }
        public int CatalogId { get; set; }

        [Required]
        public string CustomerFirstname { get; set; }
        [Required]
        public string CustomerLastname { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public string TaxRegistrationNumber { get; set; }
      
        public string PhoneNumber { get; set; }

        [Required]
        public string IssuedBy { get; set; }
        [Required]
        public string ConditionIssued { get; set; }
        [Required]
        public DateTime DateIssued { get; set; }
        [Required]
        public DateTime DeadlineDate { get; set; }

        [Required]
        public string ConditionRecieved { get; set; }
        [Required]
        public string RecievedBy { get; set; }
        [Required]
        public DateTime DateRecieved { get; set; }

        public string StaffComment { get; set; }


        public IEnumerable<SelectListItem> Catalogs { get; set; }
    }
}
