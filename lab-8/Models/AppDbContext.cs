﻿using Microsoft.EntityFrameworkCore;

namespace lab_8.Models;

public class AppDbContext: DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public int Counter { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book() {Id= 1, Title = "ASP.NET 6.0.0", ReleaseDate = DateTime.Parse("2022-02-13"), Created = DateTime.Now},
            new Book() {Id= 2, Title = "C# 10.0", ReleaseDate = DateTime.Parse("2022-02-13"), Created = DateTime.Now},
            new Book() {Id= 3, Title = "Java 19", ReleaseDate = DateTime.Parse("2021-12-23"), Created = DateTime.Now},
            new Book() {Id= 4, Title = "JavaScript", ReleaseDate = DateTime.Parse("2022-08-05"), Created = DateTime.Now},
            new Book() {Id= 5, Title = "Node.js", ReleaseDate = DateTime.Parse("2019-10-10"), Created = DateTime.Now}
        );
        modelBuilder.Entity<Author>().HasData(
            new Author(){Id = 1, FirstName = "Robert", LastName = "Martin", PESEL = "no"},
            new Author(){Id = 2, FirstName = "Ewa", LastName = "Kowal", PESEL = "1111111111"},
            new Author(){Id = 3, FirstName = "Karol", LastName = "Matrix", PESEL = "2222222222"}
        );
        modelBuilder.Entity<Book>()
            .HasMany<Author>(b => b.Authors)
            .WithMany(a => a.Books)
            .UsingEntity(join => join.HasData(
                new {BooksId = 1, AuthorsId = 1},
                new {BooksId = 2, AuthorsId = 3},
                new {BooksId = 3, AuthorsId = 2}
                ));
    }
    
    
}