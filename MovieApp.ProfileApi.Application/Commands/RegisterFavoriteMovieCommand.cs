using MediatR;

namespace MovieApp.ProfileApi.Application.Commands;
public class RegisterFavoriteMovieCommand : IRequest
{
    public Guid ProfileId { get; private set; }
    public Guid MovieId { get; set; }

    public void SetProfileId(Guid profileId)
    {
        ProfileId = profileId;
    }
}
