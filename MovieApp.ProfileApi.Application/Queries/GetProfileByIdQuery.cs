using MediatR;
using MovieApp.ProfileApi.Application.Responses;

namespace MovieApp.ProfileApi.Application.Queries;
public class GetProfileByIdQuery : IRequest<ProfileSummary>
{
    public Guid Id { get; set; }
}
