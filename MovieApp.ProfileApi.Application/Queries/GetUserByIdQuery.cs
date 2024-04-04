using MediatR;
using MovieApp.ProfileApi.Application.Responses.User;

namespace MovieApp.ProfileApi.Application.Queries;
public class GetUserByIdQuery : IRequest<UserResponse>
{
    public Guid Id { get; set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}
