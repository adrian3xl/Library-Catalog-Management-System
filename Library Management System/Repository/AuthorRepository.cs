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
         _db.Authors.Add(Entity);
            return Save();
           
        }

        public bool Delete(Author Entity)
        {
           _db.Authors.Remove(Entity);
            return Save(); 
        }

        public ICollection<Author> Findall()
        {
            var Authors=_db.Authors.ToList();
            return Authors;
        }

        public Author FindById(int id)
        {
            var Authors = _db.Authors.Find(id);
            return Authors;
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
            var Changes = _db.SaveChanges();
            return Changes >0;
        }

        public bool Update(Author Entity)
        {
            _db.Authors.Update(Entity);
            return Save();
        }
    }
}
