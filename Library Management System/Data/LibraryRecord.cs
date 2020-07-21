using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Data
{
    public class LibraryRecord
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CatalogId")]
        public Catalog Catalog { get; set; }
        public int CatalogId { get; set; }
        public string CustomerFirstname { get; set; }
        public string CustomerLastname { get; set; }
        public string CustomerAddress { get; set; }
        public string TaxRegistrationNumber { get; set; }
        public string PhoneNumber { get; set; }


        public string IssuedBy { get; set; }
        public string ConditionIssued { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DeadlineDate { get; set; }


        public string ConditionRecieved { get; set; }
        public string RecievedBy { get; set; }
        public DateTime DateRecieved { get; set; }

        public string  StaffComment { get; set; }

    }
}
