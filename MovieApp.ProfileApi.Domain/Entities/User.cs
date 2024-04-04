using MovieApp.ProfileApi.Domain.Entities.Base;

namespace MovieApp.ProfileApi.Domain.Entities;
public class User : Entity
{
    public string UserName { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
    public IEnumerable<Movie> MoviesRating { get; set; }
    public IEnumerable<Movie> FavoritesMovies { get; set; }
    public IEnumerable<Rating> Ratings { get; set; }

    public User(Guid id, string userName)
    {
        Id = id;
        UserName = userName;
    }
}
