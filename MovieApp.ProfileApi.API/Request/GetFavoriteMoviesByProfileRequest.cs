namespace MovieApp.ProfileApi.API.Request;

public class GetFavoriteMoviesByProfileRequest
{
    public Guid? GenreId { get; set; } = null;
    public string? SearchTerm { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 30;
}
