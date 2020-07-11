using Library_Management_System.Contracts;
using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Repository
{
   

    public class AuthorRepository : IAuthorRepository
    {

        private readonly ApplicationDbContext _db;

        public AuthorRepository(ApplicationDbContext db)
        {
            _db= db;
        }
            public bool Create(Author Entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Author Entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Author> Findall()
        {
            throw new NotImplementedException();
        }

        public Author FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Author> GetAuther(int Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<LibraryEmployee> GetLibraryEmployees(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Author Entity)
        {
            throw new NotImplementedException();
        }
    }
}
