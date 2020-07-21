using Library_Management_System.Contracts;
using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Repository
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CatalogTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(CatalogType Entity)
        {
            _db.CatalogTypes.Add(Entity);
            return Save();
        }

        public bool Delete(CatalogType Entity)
        {
            _db.CatalogTypes.Remove(Entity);
            return Save();
        }

        public ICollection<CatalogType> FindAll()
        {
            var CatalogTypes = _db.CatalogTypes.ToList();
            return CatalogTypes;
        }

        public CatalogType FindById(int id)
        {
            var CatalogTypes = _db.CatalogTypes.Find(id);
            return CatalogTypes;
        }

        public ICollection<CatalogType> GetCatalogType(int Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int id)
        {
            var exist = _db.CatalogTypes.Any(q => q.Id == id);
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

        public bool Update(CatalogType Entity)
        {
            _db.CatalogTypes.Update(Entity);
            return Save();
        }
    }
}
