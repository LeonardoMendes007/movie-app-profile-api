using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MovieApp.ProfileApi.API.Queries;

public class GetFavoriteMoviesByProfileQuery : PagedListQuery
{
    public Guid? GenreId { get; set; } = null;
    public string SearchTerm { get; set; } = string.Empty;
}
