using MediatR;

namespace MovieApp.ProfileApi.Application.Commands;
public class RegisterFavoriteMovieCommand : IRequest
{
    public Guid ProfileId { get; set; }
    public Guid MovieId { get; set; }
}
