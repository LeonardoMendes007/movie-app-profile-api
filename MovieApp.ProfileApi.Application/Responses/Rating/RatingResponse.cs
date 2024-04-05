using MovieApp.ProfileApi.Application.Responses.Movie;

namespace MovieApp.ProfileApi.Application.Responses.Rating;
public class RatingResponse
{
    public Guid ProfileId { get; set; }
    public string UserName { get; set; }
    public MovieResponse Movie { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
