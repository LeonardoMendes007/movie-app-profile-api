using MediatR;

namespace MovieApp.ProfileApi.Application.Commands;
public class CreateUserCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
}
