using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace lab_5.Models
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            AuthorsId = new List<string>();
        }
        [ValidateNever]
        public List<SelectListItem> Authors { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Data wydania")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Autorzy")]
        public List<string> AuthorsId { get; set; }
    }
}
