using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Data
{
    public class Catalog
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }

        public CatalogType CatalogType { get; set; }
        public string CatalogTypeId { get; set; }

        public Genre Genre { get; set; }
        public string GenreId { get; set; }

        public string UniqueCatalogCode { get; set; }
        public DateTime PublishedDate  { get; set; }
        public string CurrentCondition { get; set; }

        
    }
}
