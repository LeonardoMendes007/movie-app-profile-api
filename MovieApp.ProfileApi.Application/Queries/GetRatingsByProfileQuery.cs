using MediatR;
using MovieApp.ProfileApi.Application.Pagination;
using MovieApp.ProfileApi.Application.Pagination.Interface;
using MovieApp.ProfileApi.Application.Responses;

namespace MovieApp.ProfileApi.Application.Queries;
public class GetRatingsByProfileQuery : IRequest<IPagedList<RatingSummary>>
{
    public Guid ProfileId { get;  set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 30;

}
