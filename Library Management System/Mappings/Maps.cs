using AutoMapper;
using Library_Management_System.Data;
using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Author, AuthorVM>().ReverseMap();
            CreateMap<Publisher, PublisherVM>().ReverseMap();
            CreateMap<LibraryRecord, LibraryRecordVM>().ReverseMap();
            CreateMap<LibraryEmployee, LibraryEmployeeVM>().ReverseMap();
            CreateMap<Catalog, CatalogVM>().ReverseMap();
        }
    }
}
