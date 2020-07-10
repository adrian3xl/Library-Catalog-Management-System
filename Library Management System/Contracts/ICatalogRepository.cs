using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Contracts
{
    interface ICatalogRepository: IRepositoryBase<Catalog>
    {
        ICollection<Catalog> GetCatalog(int Id);
    }
}
