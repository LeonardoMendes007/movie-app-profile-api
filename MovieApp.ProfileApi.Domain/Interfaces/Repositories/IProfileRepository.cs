using MovieApp.ProfileApi.Domain.Entities;
using System.Linq.Expressions;

namespace MovieApp.Domain.Interfaces.Repository;
public interface IProfileRepository
{
    Task<Profile> FindByIdAsync(Guid id);
    Task<IEnumerable<Movie>> FindFavoritesMovies(Guid id, int skip = 0, int take = 30, Expression<Func<Movie, bool>> filter = null);
    Task<IEnumerable<Rating>> FindRatings(Guid id, int skip = 0, int take = 30);
    Task SaveAsync(Profile Profile);
    Task UpdateAsync(Profile Profile);
    Task RemoveAsync(Guid id);
    Task CommitAsync();
}
