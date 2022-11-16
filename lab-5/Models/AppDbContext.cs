using lab_5.Models;
using Microsoft.EntityFrameworkCore;

namespace wsei_asp_net_lab.Models;

public class AppDbContext: DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source = c:\\data\\books.db");
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
    }
    
    
}