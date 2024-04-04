using Microsoft.EntityFrameworkCore;
using MovieApp.ProfileApi.Domain.Exceptions;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.ProfileApi.Domain.Entities;
using System.Linq.Expressions;

namespace MovieApp.Infra.Data.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly MovieAppDbContext _movieAppDbContext;
    private readonly DbSet<User> _dbSet;
    public UserRepository(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
        _dbSet = _movieAppDbContext.Set<User>();
    }

    public async Task<User> FindByIdAsync(Guid id)
    {
        var user = await _dbSet.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        return user;
    }

    public async Task SaveAsync(User user)
    {
        await _dbSet.AddAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        _dbSet.Update(user);
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
