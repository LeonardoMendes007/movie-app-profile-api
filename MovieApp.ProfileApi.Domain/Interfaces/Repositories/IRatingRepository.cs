using MovieApp.ProfileApi.Domain.Entities;

namespace MovieApp.ProfileApi.Domain.Interfaces.Repositories;
public interface IRatingRepository
{
    Task SaveAsync(Rating rating);
}
