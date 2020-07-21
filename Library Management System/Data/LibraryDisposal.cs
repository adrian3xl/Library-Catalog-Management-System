using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Data
{
    public class LibraryDisposal
    {
        public string DisposalCode { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
        public string MethodOfDisposal { get; set; }
        public DateTime DateOfDisposal { get; set; }

    }
}
