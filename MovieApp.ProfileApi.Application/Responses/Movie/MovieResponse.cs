using MovieApp.ProfileApi.Application.Responses.Genre;

namespace MovieApp.ProfileApi.Application.Responses.Movie;
public class MovieResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string ImageUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Views { get; set; }
    public IEnumerable<GenreResponse> Genries { get; set; }
}
