namespace MovieApp.ProfileApi.Application.Responses;
public class MovieSummary
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string ImageUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Views { get; set; }
    public IEnumerable<GenreSummary> Genries { get; set; }
}
