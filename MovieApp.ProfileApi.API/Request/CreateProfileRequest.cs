using System.ComponentModel.DataAnnotations;

namespace MovieApp.ProfileApi.API.Request;

public class CreateProfileRequest
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string UserName { get; set; }
    public string ImageUrl { get; set; }
}
