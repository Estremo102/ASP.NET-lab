using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace lab_8.Models;

public class Book
{
    public Book()
    {
        Authors = new HashSet<Author>();
    }

    [HiddenInput]
    public int Id { get; set; }
   
    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Display(Name = "Data wydania")]
    public DateTime ReleaseDate { get; set; }

    [Display(Name = "Data utworzenia wpisu")]
    public DateTime Created { get; set; }

    [Display(Name = "Autorzy")]
    virtual public ISet<Author> Authors { get; set; }
}