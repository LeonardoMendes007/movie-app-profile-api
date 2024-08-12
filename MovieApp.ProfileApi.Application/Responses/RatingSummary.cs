namespace MovieApp.ProfileApi.Application.Responses;
public class RatingSummary
{
    public Guid ProfileId { get; set; }
    public MovieSummary Movie { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
