using MovieApp.Domain.Interfaces.Repository;
using MovieApp.ProfileApi.Domain.Interfaces.Repositories;

namespace MovieApp.ProfileApi.Domain.Interfaces;
public interface IUnitOfWork
{
    IMovieRepository MovieRepository { get; }
    IProfileRepository ProfileRepository { get; }
    Task CommitAsync();
}
