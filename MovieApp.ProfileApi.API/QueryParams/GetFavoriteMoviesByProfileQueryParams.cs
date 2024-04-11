using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MovieApp.ProfileApi.API.QueryParams;

public class GetFavoriteMoviesByProfileQueryParams : PagedListQueryParams
{
    public Guid? GenreId { get; set; } = null;
    public string SearchTerm { get; set; } = string.Empty;
}
