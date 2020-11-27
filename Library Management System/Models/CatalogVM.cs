using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class CatalogVM
    {
        public int Id { get; set; }

        
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }


       
        public AuthorVM Author { get; set; }
        [Display(Name = "Author")]
        public int AuthorId { get; set; }

       
        public PublisherVM Publisher { get; set; }
        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }

     
        public CatalogTypeVM CatalogType { get; set; }
        [Display(Name = "Catalog Type")]
        public string CatalogTypeId { get; set; }

       // [Display(Name = "Genre")]
        public GenreVM Genre { get; set; }
        [Display(Name = "Genre")]
        public string GenreId { get; set; }
      
        [Required]

        [Display(Name = "Unique Catalog Code")]

        public string UniqueCatalogCode { get; set; }

        [Display(Name = "Published Date")]
        [Required]

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Current Condition")]
        public string CurrentCondition { get; set; }


        public IEnumerable<SelectListItem> Authors { get; set; }
        public IEnumerable<SelectListItem> Publishers { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> CatalogTypes{ get; set; }

    }
}
