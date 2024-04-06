using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Data.Persistence;
using MovieApp.ProfileApi.Domain.Entities;
using MovieApp.ProfileApi.Domain.Exceptions;

namespace MovieApp.ProfileApi.Infra.Persistence.Repositories;
public class ProfileRepository : IProfileRepository
{
    private readonly MovieAppDbContext _movieAppDbContext;
    private readonly DbSet<Profile> _profiles;
    public ProfileRepository(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
        _profiles = _movieAppDbContext.Set<Profile>();
    }

    public async Task<Profile> FindByIdAsync(Guid id)
    {
        return await _profiles.Where(x => x.Id == id).Include(x => x.Ratings).Include(x => x.FavoritesMovies).AsNoTracking().FirstOrDefaultAsync();
    }

    public IQueryable<Movie> FindAllFavoriteMoviesByIdAsync(Guid id)
    {
        return _profiles.SelectMany(x => x.FavoritesMovies).Include(x => x.Genries).AsNoTracking().AsQueryable();
    }

    public IQueryable<Rating> FindAllRatingByIdAsync(Guid id)
    {
        return _profiles.SelectMany(x => x.Ratings).Include(x => x.Movie).Include(x => x.Movie.Genries).AsNoTracking().AsQueryable();
    }

    public async Task SaveAsync(Profile Profile)
    {
        await _profiles.AddAsync(Profile);
    }

    public async Task UpdateAsync(Profile Profile)
    {
        _profiles.Update(Profile);
    }
    public async Task RemoveAsync(Guid id)
    {
        var movie = await _profiles.FindAsync(id);
        if (movie is null)
        {
            throw new ResourceNotFoundException(id);
        }

        _profiles.Remove(movie);
    }
}
