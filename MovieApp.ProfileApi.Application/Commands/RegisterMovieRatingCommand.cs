using MediatR;
using MovieApp.ProfileApi.Domain.Entities;

namespace MovieApp.ProfileApi.Application.Commands;
public class RatingDTO : IRequest
{
    public Guid ProfileId { get; set; }
    public Guid MovieId { get; set; }
    public int Score { get; set; } = 0;
    public string Comment { get; set; } = string.Empty;

}
