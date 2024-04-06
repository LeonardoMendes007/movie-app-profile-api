using MediatR;
using MovieApp.ProfileApi.Application.Pagination;
using MovieApp.ProfileApi.Application.Responses;

namespace MovieApp.ProfileApi.Application.Queries;
public class GetRatingsByProfileQuery : IRequest<PagedList<RatingResponse>>
{
    public Guid ProfileId { get;  set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 30;

}
