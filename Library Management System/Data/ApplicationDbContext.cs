using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Library_Management_System.Models;

namespace Library_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<LibraryRecord> LibraryRecords { get; set; }
        public DbSet<LibraryEmployee> LibraryEmployees { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }

        public DbSet<CatalogType> CatalogType { get; set; }
        public DbSet<LibraryDisposal> LibraryDisposals { get; set; }
        public DbSet<Genre> Genres { get; set; }




    }
}
