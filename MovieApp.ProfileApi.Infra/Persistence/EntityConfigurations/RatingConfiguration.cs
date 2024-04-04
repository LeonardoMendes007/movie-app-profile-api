using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.ProfileApi.Domain.Entities;

namespace MovieApp.Infra.Data.Persistence.Configuration;
public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("tb_rating");
        builder.Property(x => x.Comment).HasColumnName("comment").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Score).HasColumnName("score").HasMaxLength(1).IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("dt_created").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("dt_update");

        builder.HasKey(x => new {x.UserId, x.MovieId});

        builder.HasOne(r => r.Movie)
            .WithMany(m => m.Ratings)
            .HasForeignKey(r => r.MovieId);

        builder.HasOne(r => r.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(r => r.UserId);
        }
}
