using MovieApp.Domain.Interfaces.Repository;
using MovieApp.ProfileApi.Domain.Interfaces.Repositories;

namespace MovieApp.ProfileApi.Domain.Interfaces.UnitOfWork;
public interface IUnitOfWork
{
    IMovieRepository MovieRepository { get; }
    IProfileRepository ProfileRepository { get; }
    IRatingRepository RatingRepository { get; }
    Task CommitAsync();
}
