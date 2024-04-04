using Microsoft.EntityFrameworkCore;
using MovieApp.ProfileApi.Domain.Entities;

namespace MovieApp.Infra.Data.Persistence;
public sealed class MovieAppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;

    public DbSet<Movie> Movies { get; set; } = default!;

    public DbSet<Rating> Ratings { get; set; } = default!;

    public DbSet<Genre> Genres { get; set; } = default!;

    public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options)
    : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(MovieAppDbContext)
            .Assembly);
    }
}
