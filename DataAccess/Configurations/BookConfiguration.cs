using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;
public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .HasKey(b => b.Id);

        builder
            .HasIndex(b => b.Id);

        builder
            .Property(b => b.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(b => b.Content)
            .HasMaxLength(5000)
            .IsRequired();

        builder
            .Property(b => b.Author)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(b => b.Cover);

        builder
            .Property(b => b.Genre)
            .HasMaxLength(20);
    }
}
