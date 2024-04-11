using MovieApp.ProfileApi.Domain.Entities.Base;

namespace MovieApp.ProfileApi.Domain.Entities;
public class Profile : Entity
{
    public string UserName { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
    public IList<Movie> MoviesRating { get; set; } = new List<Movie>();
    public IList<Movie> FavoritesMovies { get; set; } = new List<Movie>();
    public IList<Rating> Ratings { get; set; } = new List<Rating>();

}
