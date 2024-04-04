

namespace MovieApp.ProfileApi.Domain.Entities;

public class Rating
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}