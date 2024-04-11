using System.ComponentModel.DataAnnotations;

namespace MovieApp.ProfileApi.API.Request;

public class RegisterMovieRatingRequest
{
    [Required]
    public Guid MovieId { get; set; }
    public int Score { get; set; } = 0;
    public string Comment { get; set; } = string.Empty;
}
