using Library_Management_System.Contracts;
using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Repository
{
    public class LibraryEmployeeRepository : ILibraryEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public LibraryEmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LibraryEmployee Entity)
        {
            _db.LibraryEmployees.Add(Entity);
            return Save();
        }

        public bool Delete(LibraryEmployee Entity)
        {
            _db.LibraryEmployees.Remove(Entity);
            return Save();
        }

        public ICollection<LibraryEmployee> FindAll()
        {
            var LibraryEmployees = _db.LibraryEmployees.ToList();
            return LibraryEmployees;
        }

        public LibraryEmployee FindById(int id)
        {
            var LibraryEmployees = _db.LibraryEmployees.Find(id);
            return LibraryEmployees;
        }

        public ICollection<LibraryEmployee> GetLibraryEmployees(string Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var Changes = _db.SaveChanges();
            return Changes > 0;
        }

        public bool Update(LibraryEmployee Entity)
        {
            _db.LibraryEmployees.Update(Entity);
            return Save();
        }
    }
}
