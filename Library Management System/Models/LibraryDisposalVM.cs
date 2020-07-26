using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class LibraryDisposalVM
    {
        public int Id { get; set; }


        public LibraryEmployee LibraryEmployee { get; set; }
        [Display(Name = " Library Employee / System user")]
       
         public string LibraryEmployeeId { get; set; }



        [Display(Name = "Disposal Code")]
        [Required]
        public string DisposalCode { get; set; }

        [Required]
       
        public string Name { get; set; }
        [Required]
        
        public string Reason { get; set; }
      
        
        [Display(Name = "Method Of Disposal")]
        [Required]
        public string MethodOfDisposal { get; set; }

        [Display(Name = " Date Of Disposal")]
        [Required]

        [DataType(DataType.Date)]
        
        public DateTime DateOfDisposal { get; set; }
    }
}
