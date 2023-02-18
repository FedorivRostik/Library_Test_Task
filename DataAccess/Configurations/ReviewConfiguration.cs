using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;
internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder
           .HasKey(b => b.Id);

        builder
            .HasIndex(b => b.Id);

        builder.Property(b => b.Reviewer)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(b => b.Message)
            .HasMaxLength(1000)
            .IsRequired();


        builder.HasOne(b => b.Book)
            .WithMany(b => b.Reviews)
            .HasForeignKey(b => b.BookId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
