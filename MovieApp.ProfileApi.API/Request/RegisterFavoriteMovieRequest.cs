using System.ComponentModel.DataAnnotations;

namespace MovieApp.ProfileApi.API.Request;

public class RegisterFavoriteMovieRequest
{
    [Required]
    public Guid MovieId { get; set; }
}
