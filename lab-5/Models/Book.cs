using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace lab_5.Models;

public class Book
{
    [HiddenInput]
    public int Id { get; set; }
    [Required]
    [Display(Name = "Tytuł")]
    public string Title { get; set; }
    [Required]
    [Display(Name = "Data wydania")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public DateTime Created { get; set; }
}