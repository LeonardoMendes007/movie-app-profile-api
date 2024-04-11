using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.ProfileApi.Domain.Entities;

namespace MovieApp.Infra.Data.Persistence.Configuration;
public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("tb_profile");
        builder.Property(x => x.Id).HasColumnName("id").HasMaxLength(36);
        builder.Property(x => x.UserName).HasColumnName("username").HasMaxLength(50).IsRequired();
        builder.Property(x => x.ImageUrl).HasColumnName("imageUrl").HasMaxLength(300);
        builder.Property(x => x.CreatedDate).HasColumnName("dt_created").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("dt_update");

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.UserName);

        builder.HasMany(e => e.MoviesRating)
        .WithMany(e => e.ProfileRating)
        .UsingEntity<Rating>();

        builder.HasMany(e => e.FavoritesMovies)
            .WithMany(e => e.FavoritesProfiles)
            .UsingEntity("tb_favorites_movies");
    }
}
