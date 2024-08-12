using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using MovieApp.Infra.Data;
using MovieApp.ProfileApi.Domain.Interfaces.Repositories;

namespace MovieApp.ProfileApi.Infra.Persistence.Repositories;
public class MovieRepository : IMovieRepository
{
    private readonly MovieAppDbContext _movieAppDbContext;
    private readonly DbSet<Movie> _dbSetMovie;

    public MovieRepository(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
        _dbSetMovie = _movieAppDbContext.Set<Movie>();
    }

    public async Task<Movie> FindByIdAsync(Guid id)
    { 
        return await _dbSetMovie.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
    }
}
