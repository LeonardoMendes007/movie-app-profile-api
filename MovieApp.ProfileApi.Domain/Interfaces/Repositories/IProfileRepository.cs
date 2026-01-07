using MovieApp.Domain.Entities;

namespace MovieApp.Domain.Interfaces.Repository;
public interface IProfileRepository
{
    Task<Profile> FindByIdAsync(Guid id);
    Task<Profile> FindByIdAsyncTracking(Guid id);
    Task<Profile> FindByUserNameAsync(string userName);
    IQueryable<Movie> FindAllFavoriteMoviesById(Guid id);
    IQueryable<Rating> FindAllRatingById(Guid id);
    Task SaveAsync(Profile Profile);
    Task UpdateAsync(Profile Profile);
    Task RemoveAsync(Guid id);
}
