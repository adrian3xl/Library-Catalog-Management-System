using Library_Management_System.Contracts;
using Library_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Repository
{
    public class LibraryRecordRepository : ILibraryRecordRepository
    {
        private readonly ApplicationDbContext _db;

        public LibraryRecordRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LibraryRecord Entity)
        {
            _db.LibraryRecords.Add(Entity);
            return Save();
        }

        public bool Delete(LibraryRecord Entity)
        {
            _db.LibraryRecords.Remove(Entity);
            return Save();
        }

        public ICollection<LibraryRecord> FindAll()
        {
            var LibraryRecords = _db.LibraryRecords
                .Include(q => q.Catalog)
                 .Include(q => q.LibraryEmployee)
                .ToList();
            return LibraryRecords;
        }
        
        public LibraryRecord FindById(int id)
        {
            var LibraryRecords = _db.LibraryRecords
                .Include(q => q.Catalog)
                .Include(q => q.LibraryEmployee)
                .FirstOrDefault( q=> q.Id == id);
            return LibraryRecords;
        }

        public ICollection<LibraryRecord> GetLibraryRecords(int Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int id)
        {
            var exist = _db.LibraryRecords.Any(q =>q.Id == id);
            return exist;
        }

        public bool IsExist(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var Changes = _db.SaveChanges();
            return Changes > 0;
        }

        public bool Update(LibraryRecord Entity)
        {
            _db.LibraryRecords.Update(Entity);
            return Save();
        }
    }
}
