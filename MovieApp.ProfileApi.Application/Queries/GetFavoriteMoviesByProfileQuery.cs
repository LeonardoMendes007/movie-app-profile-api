using MediatR;
using MovieApp.ProfileApi.Application.Pagination.Interface;
using MovieApp.ProfileApi.Application.Responses;

namespace MovieApp.ProfileApi.Application.Queries;
public record GetFavoriteMoviesByProfileQuery : IRequest<IPagedList<MovieResponse>>
{
    public Guid ProfileId { get; set; }
    public Guid? GenreId { get; set; }
    public string SearchTerm { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 30;

}
