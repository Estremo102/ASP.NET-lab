﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace lab_6.Models;

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
    
    public DateTime ReleaseDate { get; set; }
    
    public DateTime Created { get; set; }
    
    public ISet<Author> Authors { get; set; }
}