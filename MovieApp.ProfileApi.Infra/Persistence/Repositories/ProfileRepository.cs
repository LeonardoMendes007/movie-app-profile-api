using Microsoft.EntityFrameworkCore;
using MovieApp.ProfileApi.Domain.Exceptions;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.ProfileApi.Domain.Entities;
using System.Linq.Expressions;

namespace MovieApp.Infra.Data.Persistence.Repositories;
public class ProfileRepository : IProfileRepository
{
    private readonly MovieAppDbContext _movieAppDbContext;
    private readonly DbSet<Profile> _dbSet;
    public ProfileRepository(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
        _dbSet = _movieAppDbContext.Set<Profile>();
    }

    public async Task<Profile> FindByIdAsync(Guid id)
    {
        var Profile = await _dbSet.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        return Profile;
    }

    public async Task SaveAsync(Profile Profile)
    {
        await _dbSet.AddAsync(Profile);
    }

    public async Task UpdateAsync(Profile Profile)
    {
        _dbSet.Update(Profile);
    }
    public async Task RemoveAsync(Guid id)
    {
        var movie = await _dbSet.FindAsync(id);
        if (movie is null)
        {
            throw new ResourceNotFoundException(id);
        }

        _dbSet.Remove(movie);
    }
    public async Task<IEnumerable<Movie>> FindFavoritesMovies(Guid id, int skip = 0, int take = 30, Expression<Func<Movie, bool>> filter = null)
    {
        return await _dbSet.Where(x => x.Id == id).Include(x => x.FavoritesMovies).SelectMany(x => x.FavoritesMovies).Where(filter).Take(take).Skip(skip).AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Rating>> FindRatings(Guid id, int skip = 0, int take = 30)
    {
        return await _dbSet.Where(x => x.Id == id).Include(x => x.Ratings).SelectMany(x => x.Ratings).Include(x => x.Movie).Take(take).Skip(skip).AsNoTracking().ToListAsync();
    }

    public async Task CommitAsync()
    {
        await _movieAppDbContext.SaveChangesAsync();
    }
}
