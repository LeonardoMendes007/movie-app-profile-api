

namespace MovieApp.ProfileApi.Domain.Entities;

public class Rating
{
    public Guid ProfileId { get; set; }
    public Profile Profile { get; set; }
    public Guid MovieId { get; set; }
    public Movie Movie { get; set; }
    public int Score { get; set; } = 0;
    public string Comment { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
}