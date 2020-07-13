using Library_Management_System.Contracts;
using Library_Management_System.Data;
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
            throw new NotImplementedException();
        }

        public bool Delete(LibraryRecord Entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<LibraryRecord> Findall()
        {
            throw new NotImplementedException();
        }

        public LibraryRecord FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<LibraryRecord> GetLibraryRecords(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(LibraryRecord Entity)
        {
            throw new NotImplementedException();
        }
    }
}
