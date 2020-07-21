using Library_Management_System.Contracts;
using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _db;

        public GenreRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Genre Entity)
        {
            _db.Genres.Add(Entity);
            return Save();
        }

        public bool Delete(Genre Entity)
        {
            _db.Genres.Remove(Entity);
            return Save();
        }

        public ICollection<Genre> FindAll()
        {
            var Genres = _db.Genres.ToList();
            return Genres;
        }

        public Genre FindById(int id)
        {
            var Genres = _db.Genres.Find(id);
            return Genres;
        }

        public ICollection<Genre> GetAuther(int Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Genre> GetGenre(int Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int id)
        {
            var exist = _db.Genres.Any(q => q.Id == id);
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

        public bool Update(Genre Entity)
        {
            _db.Genres.Update(Entity);
            return Save();
        }
    }
}
