using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Rack> Racks { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
    public LibraryDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=LibraryDatabase.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasOne(b => b.Rack).WithMany(b => b.Books).HasForeignKey(b => b.RackId);
        });

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rack>().HasData(
            new Rack { Id = 1, Name = "Programming" },
            new Rack { Id = 2, Name = "Self-Improvement" },
            new Rack { Id = 3, Name = "Fiction" }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book("Advanced C#") { Id = 1, RackId = 1 },
            new Book("Intermediate C#") { Id = 2, RackId = 1 },
            new Book("Beginner C#") { Id = 3, RackId = 1 }
        );        
    }
}