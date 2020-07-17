using Library_Management_System.Contracts;
using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Repository
{
    public class PublisherRepository : IPublisherRepository
    {

        private readonly ApplicationDbContext _db;

        public PublisherRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Publisher Entity)
        {
            _db.Publishers.Add(Entity);
            return Save();
        }

        public bool Delete(Publisher Entity)
        {
            _db.Publishers.Remove(Entity);
            return Save();
        }

        public ICollection<Publisher> FindAll()
        {
            var Publishers = _db.Publishers.ToList();
            return Publishers;
        }

        public Publisher FindById(int id)
        {
            var Publishers = _db.Publishers.Find(id);
            return Publishers;
        }

        public ICollection<Publisher> GetLibraryEmployees(string Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Publisher> GetPublisher(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var Changes = _db.SaveChanges();
            return Changes > 0;
        }

        public bool Update(Publisher Entity)
        {
            _db.Publishers.Update(Entity);
            return Save();
        }
    }
}
