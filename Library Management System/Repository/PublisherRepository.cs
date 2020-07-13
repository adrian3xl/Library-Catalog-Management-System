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
            throw new NotImplementedException();
        }

        public bool Delete(Publisher Entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Publisher> Findall()
        {
            throw new NotImplementedException();
        }

        public Publisher FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Publisher> GetLibraryEmployees(string Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Publisher> GetPublisher(string Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Publisher> GetPublisher(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Publisher Entity)
        {
            throw new NotImplementedException();
        }
    }
}
