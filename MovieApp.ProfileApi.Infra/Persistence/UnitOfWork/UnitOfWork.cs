using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Data.Persistence;
using MovieApp.ProfileApi.Domain.Interfaces;
using MovieApp.ProfileApi.Domain.Interfaces.Repositories;
using MovieApp.ProfileApi.Infra.Persistence.Repositories;

namespace MovieApp.ProfileApi.Infra.Persistence.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private IMovieRepository _movieRepository;
    private IProfileRepository _profileRepository;

    private readonly MovieAppDbContext _movieAppDbContext;

    public UnitOfWork(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
    }

    public IMovieRepository MovieRepository
    {
        get
        {
            return _movieRepository = _movieRepository ?? new MovieRepository(_movieAppDbContext);
        }
    }

    public IProfileRepository ProfileRepository
    {
        get
        {
            return _profileRepository = _profileRepository ?? new ProfileRepository(_movieAppDbContext);
        }
    }

    public async Task CommitAsync()
    {
        await _movieAppDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _movieAppDbContext.Dispose();
    }
}
