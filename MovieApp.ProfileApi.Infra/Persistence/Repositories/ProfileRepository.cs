﻿using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Data;
using MovieApp.ProfileApi.Domain.Exceptions;

namespace MovieApp.ProfileApi.Infra.Persistence.Repositories;
public class ProfileRepository : IProfileRepository
{
    private readonly MovieAppDbContext _movieAppDbContext;
    private readonly DbSet<Profile> _profiles;
    public ProfileRepository(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
        _profiles = _movieAppDbContext.Set<Profile>();
    }

    public async Task<Profile> FindByIdAsync(Guid id)
    {
        return await _profiles.Where(x => x.Id == id).Include(x => x.Ratings).Include(x => x.FavoritesMovies).AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<Profile> FindByUserNameAsync(string userName)
    {
        return await _profiles.Where(x => x.UserName == userName).AsNoTracking().FirstOrDefaultAsync();
    }

    public IQueryable<Movie> FindAllFavoriteMoviesById(Guid id)
    {
        return _profiles.SelectMany(x => x.FavoritesMovies).Include(x => x.Genries).AsNoTracking().AsQueryable();
    }

    public IQueryable<Rating> FindAllRatingById(Guid id)
    {
        return _profiles.SelectMany(x => x.Ratings).Include(x => x.Movie).Include(x => x.Movie.Genries).AsNoTracking().AsQueryable();
    }

    public async Task SaveAsync(Profile Profile)
    {
        await _profiles.AddAsync(Profile);
    }

    public async Task UpdateAsync(Profile Profile)
    {
        _profiles.Update(Profile);
    }
    public async Task RemoveAsync(Guid id)
    {
        var movie = await _profiles.FindAsync(id);
        if (movie is null)
        {
            throw new ResourceNotFoundException(id);
        }

        _profiles.Remove(movie);
    }
}
