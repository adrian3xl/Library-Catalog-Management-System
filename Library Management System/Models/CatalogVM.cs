using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class CatalogVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public AuthorVM Author { get; set; }
        public int AuthorId { get; set; }

        public PublisherVM Publisher { get; set; }
        public int PublisherId { get; set; }

        public string Type { get; set; }

        public string Genre { get; set; }
        public string UniqueCatalogCode { get; set; }

        public string CurrentCondition { get; set; }


        public IEnumerable<SelectListItem> Authors { get; set; }
        public IEnumerable<SelectListItem> Publishers { get; set; }

    }
}
