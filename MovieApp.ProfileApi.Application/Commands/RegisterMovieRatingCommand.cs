using MediatR;

namespace MovieApp.ProfileApi.Application.Commands;
public class RegisterMovieRatingCommand : IRequest
{
    public Guid ProfileId { get; set; }
    public Guid MovieId { get; set; }
    public int Score { get; set; } = 0;
    public string Comment { get; set; } = string.Empty;

}
