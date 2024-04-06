using MovieApp.ProfileApi.Domain.Entities;

namespace MovieApp.ProfileApi.Domain.Interfaces.Repositories;
public interface IMovieRepository
{
    Task<Movie> FindByIdAsync(Guid id);
}
