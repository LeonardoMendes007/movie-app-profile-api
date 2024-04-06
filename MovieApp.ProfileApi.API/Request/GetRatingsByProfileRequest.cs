namespace MovieApp.ProfileApi.API.Request;

public class GetRatingsByProfileRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 30;
}
