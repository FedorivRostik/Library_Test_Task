using Microsoft.EntityFrameworkCore;

namespace DataAccess;
public class LibraryContext : DbContext
{
	public LibraryContext(DbContextOptions<LibraryContext> options) :base(options)
	{

	}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        builder.Books();
        builder.Ratings();
        builder.Reviews();

    }
}
