using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using MovieApp.Infra.Data;
using MovieApp.ProfileApi.Domain.Interfaces.Repositories;

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
