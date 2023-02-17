using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;
internal class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder
          .HasKey(b => b.Id);

        builder
            .HasIndex(b => b.Id);

        builder.Property(b => b.Score)
            .IsRequired();


        builder.HasOne(b => b.Book)
            .WithMany(b => b.Ratings)
            .HasForeignKey(b => b.Book.Id)
            .OnDelete(DeleteBehavior.Cascade);


    }
}
