using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.ProfileApi.Domain.Entities;

namespace MovieApp.Infra.Data.Persistence.Configuration;
public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("tb_genre");
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.HasData(new List<Genre>
        {
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Ação"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Aventura"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Cinema de arte"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Chanchada"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Comédia"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Comédia de ação"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Comédia de terror"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Comédia dramática"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Comédia romântica"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Dança"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Documentário"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Docuficção"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Drama"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Espionagem"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Faroeste"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Fantasia"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Fantasia científica"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Ficção científica"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Filmes com truques"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Guerra"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Mistério"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Musical"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Policial"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Romance"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Terror"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Thriller"
            }

        });
    }
}
