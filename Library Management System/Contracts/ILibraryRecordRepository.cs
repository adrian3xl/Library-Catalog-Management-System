using Library_Management_System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Contracts
{
    interface ILibraryRecordRepository: IRepositoryBase<LibraryRecord>
    {
        ICollection<LibraryRecord> GetLibraryRecords(int Id);
    }
}
