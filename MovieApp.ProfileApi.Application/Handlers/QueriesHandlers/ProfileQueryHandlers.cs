using AutoMapper;
using MediatR;
using MovieApp.ProfileApi.Application.Pagination;
using MovieApp.ProfileApi.Application.Pagination.Interface;
using MovieApp.ProfileApi.Application.Queries;
using MovieApp.ProfileApi.Application.Responses;
using MovieApp.ProfileApi.Domain.Exceptions;
using MovieApp.ProfileApi.Domain.Interfaces.UnitOfWork;

namespace MovieApp.Application.Handlers.QueriesHandlers;
public class ProfileQueryHandlers : IRequestHandler<GetProfileByIdQuery, ProfileSummary>,
                                 IRequestHandler<GetFavoriteMoviesByProfileQuery, IPagedList<MovieSummary>>,
                                 IRequestHandler<GetRatingsByProfileQuery, IPagedList<RatingSummary>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProfileQueryHandlers(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProfileSummary> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var Profile = await _unitOfWork.ProfileRepository.FindByIdAsync(request.Id);
        
        if (Profile is null)
        {
            throw new ResourceNotFoundException(request.Id);
        }

        return _mapper.Map<ProfileSummary>(Profile);
    }

    public async Task<IPagedList<MovieSummary>> Handle(GetFavoriteMoviesByProfileQuery request, CancellationToken cancellationToken)
    {
        // Get All Favorite Movies By Profile
        var favoriteMoviesQuery = _unitOfWork.ProfileRepository.FindAllFavoriteMoviesById(request.ProfileId);                               

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            favoriteMoviesQuery = favoriteMoviesQuery.Where(x => x.Name.Contains(request.SearchTerm));
        }

        if (request.GenreId is not null)
        {
            favoriteMoviesQuery = favoriteMoviesQuery.Where(x => x.Genries.Any(x => x.Id == request.GenreId));
        }

        var totalCount = favoriteMoviesQuery.Count();
        var items = favoriteMoviesQuery.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

        var favoriteMovies = _mapper.Map<List<MovieSummary>>(items);

        return new PagedList<MovieSummary>(favoriteMovies, request.Page, request.PageSize, totalCount);
    }

    public async Task<IPagedList<RatingSummary>> Handle(GetRatingsByProfileQuery request, CancellationToken cancellationToken)
    {
        // Get All Rating by Porfile
        var ratingQuery = _unitOfWork.ProfileRepository.FindAllRatingById(request.ProfileId);

        var totalCount = ratingQuery.Count();
        var items = ratingQuery.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

        var ratings = _mapper.Map<List<RatingSummary>>(items);

        return new PagedList<RatingSummary>(ratings, request.Page, request.PageSize, totalCount);
    }
}
