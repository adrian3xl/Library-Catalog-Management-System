using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Contracts
{
    interface IGenreRepository: IRepositoryBase<Genre>
    {
        ICollection<Genre> GetGenre(int Id);
    }
}
