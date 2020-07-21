using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Data
{
    public class LibraryEmployee : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }

        public string StaffIdentificationCode { get; set; }

    }
}
