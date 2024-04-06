using Microsoft.EntityFrameworkCore;
using MovieApp.Infra.Data.Persistence;
using MovieApp.ProfileApi.Domain.Entities;
using MovieApp.ProfileApi.Domain.Interfaces.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace MovieApp.ProfileApi.Infra.Persistence.Repositories;
public class RatingRepository : IRatingRepository
{
    private readonly MovieAppDbContext _movieAppDbContext;
    private readonly DbSet<Rating> _dbSetRating;

    public RatingRepository(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
        _dbSetRating = _movieAppDbContext.Set<Rating>();
    }

    public async Task SaveAsync(Rating rating)
    {
        await _movieAppDbContext.Ratings.AddAsync(rating);
    }
}
