using Library_Management_System.Contracts;
using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Repository
{
    public class CatalogRepository : ICatalogRepository
    {

        private readonly ApplicationDbContext _db;

        public CatalogRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Catalog Entity)
        {
            _db.Catalogs.Add(Entity);
            return Save();
        }

        public bool Delete(Catalog Entity)
        {
            _db.Catalogs.Remove(Entity);
            return Save();
        }

        public ICollection<Catalog> Findall()
        {
            var Catalogs = _db.Catalogs.ToList();
            return Catalogs;
        }

        public Catalog FindById(int id)
        {
            var Catalogs = _db.Catalogs.Find(id);
            return Catalogs;
        }

        public ICollection<Catalog> GetCatalog(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var Changes = _db.SaveChanges();
            return Changes > 0;
        }

        public bool Update(Catalog Entity)
        {
            _db.Catalogs.Update(Entity);
            return Save();
        }
    }
}
