using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Data
{
    public class LibraryDisposal
    {
        [Key]
        public int Id { get; set; }

        public string DisposalCode { get; set; }
        public string Name { get; set; }

        public string Reason { get; set; }
        public string MethodOfDisposal { get; set; }
        public DateTime DateOfDisposal { get; set; }

        [ForeignKey("LibraryEmployeeId")]
        public LibraryEmployee LibraryEmployee { get; set; }
        public string LibraryEmployeeId { get; set; }

    }
}
