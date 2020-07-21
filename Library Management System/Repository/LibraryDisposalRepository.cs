using Library_Management_System.Contracts;
using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Repository
{
    public class LibraryDisposalRepository : ILibraryDisposalRepository
    {

        private readonly ApplicationDbContext _db;

        public LibraryDisposalRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LibraryDisposal Entity)
        {
            _db.LibraryDisposals.Add(Entity);
            return Save();
        }

        public bool Delete(LibraryDisposal Entity)
        {
            _db.LibraryDisposals.Remove(Entity);
            return Save();
        }

        public ICollection<LibraryDisposal> FindAll()
        {
            var LibraryDisposals = _db.LibraryDisposals.ToList();
            return LibraryDisposals;
        }

        public LibraryDisposal FindById(int id)
        {
            var LibraryDisposals = _db.LibraryDisposals.Find(id);
            return LibraryDisposals;
        }

        public ICollection<LibraryDisposal> GetLibraryDisposal(int Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int id)
        {
            var exist = _db.LibraryDisposals.Any(q => q.Id == id);
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

        public bool Update(LibraryDisposal Entity)
        {
            _db.LibraryDisposals.Update(Entity);
            return Save();
        }
    }
}
