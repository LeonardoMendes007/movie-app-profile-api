using MediatR;
using MovieApp.ProfileApi.Application.Responses.Movie;
using MovieApp.ProfileApi.Application.Responses.Rating;

namespace MovieApp.ProfileApi.Application.Queries;
public class GetProfileRatingsQuery : IRequest<IEnumerable<RatingResponse>>
{
    public Guid Id { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
}
