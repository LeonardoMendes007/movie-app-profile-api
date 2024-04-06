using MediatR;
using MovieApp.ProfileApi.Application.Pagination;
using MovieApp.ProfileApi.Application.Responses;

namespace MovieApp.ProfileApi.Application.Queries;
public class GetProfileRatingsQuery : IRequest<PagedList<RatingResponse>>
{
    public Guid Id { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
