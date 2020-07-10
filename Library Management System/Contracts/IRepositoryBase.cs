using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Contracts
{
   public interface IRepositoryBase<T> where T:class
    {
        ICollection<T> Findall();
        T FindById(int id);

        bool Create(T Entity);
        bool Delete(T Entity);
        bool Update(T Entity);
        bool Save();
    }
}
