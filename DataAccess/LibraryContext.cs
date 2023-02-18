using Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;
public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.Books();
        modelBuilder.Ratings();
        modelBuilder.Reviews();

    }
}
