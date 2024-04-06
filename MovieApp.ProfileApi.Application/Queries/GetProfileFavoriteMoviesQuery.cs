using MediatR;
using MovieApp.ProfileApi.Application.Pagination;
using MovieApp.ProfileApi.Application.Responses;

namespace MovieApp.ProfileApi.Application.Queries;
public record GetProfileFavoriteMoviesQuery : IRequest<PagedList<MovieResponse>>
{
    public Guid Id { get; set; }
    public Guid? GenreId { get; set; } = null;
    public string? SearchTerm { get; set; }
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 30;

    
}
