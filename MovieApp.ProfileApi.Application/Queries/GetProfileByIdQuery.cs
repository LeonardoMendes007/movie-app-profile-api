using MediatR;
using MovieApp.ProfileApi.Application.Responses.Profile;

namespace MovieApp.ProfileApi.Application.Queries;
public class GetProfileByIdQuery : IRequest<ProfileResponse>
{
    public Guid Id { get; set; }

    public GetProfileByIdQuery(Guid id)
    {
        Id = id;
    }
}
