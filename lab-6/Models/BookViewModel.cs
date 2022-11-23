using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab_6.Models
{
    public class BookViewModel : Book
    {
        [ValidateNever]
        public List<SelectListItem> AllAuthors { get; set; }
        public List<string> AuthorsId { get; set; }
    }
}
