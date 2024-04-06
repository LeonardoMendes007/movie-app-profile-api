using Microsoft.EntityFrameworkCore;
using MovieApp.Infra.Data.Persistence;
using MovieApp.ProfileApi.Domain.Entities;
using MovieApp.ProfileApi.Domain.Interfaces.Repositories;
using System.Linq;
using System.Linq.Expressions;

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
        var movie = await _dbSetMovie.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        return movie;
    }
}
