using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public string DBPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DBPath = System.IO.Path.Join(path, "games.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DBPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Game>().HasData(
                new Game() { Id = 1, GameName = "Lorem Ipsum", Studio="Yacoper", Publisher = "ZSHT", RegularPrice=0M},
                new Game() { Id = 2, GameName = "The Variant", Studio="Yacoper", Publisher = "Yacoper", RegularPrice=71.99M }
                );
    }
}
