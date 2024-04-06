using AutoMapper;
using MediatR;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.ProfileApi.Application.Pagination;
using MovieApp.ProfileApi.Application.Queries;
using MovieApp.ProfileApi.Application.Responses;
using MovieApp.ProfileApi.Domain.Entities;
using MovieApp.ProfileApi.Domain.Exceptions;
using MovieApp.ProfileApi.Domain.Interfaces;
using System.Linq.Expressions;

namespace MovieApp.Application.Handlers.QueriesHandlers;
public class ProfileQueryHandlers : IRequestHandler<GetProfileByIdQuery, ProfileResponse>,
                                 IRequestHandler<GetProfileFavoriteMoviesQuery, PagedList<MovieResponse>>,
                                 IRequestHandler<GetProfileRatingsQuery, PagedList<RatingResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProfileQueryHandlers(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProfileResponse> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var Profile = await _unitOfWork.ProfileRepository.FindByIdAsync(request.Id);
        
        if (Profile is null)
        {
            throw new ResourceNotFoundException(request.Id);
        }

        return _mapper.Map<ProfileResponse>(Profile);
    }

    public async Task<PagedList<MovieResponse>> Handle(GetProfileFavoriteMoviesQuery request, CancellationToken cancellationToken)
    {
        // Get All Favorite Movies By Profile
        var favoriteMoviesQuery = _unitOfWork.ProfileRepository.FindAllFavoriteMoviesByIdAsync(request.Id);

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

        var favoriteMovies = _mapper.Map<List<MovieResponse>>(items);

        return new PagedList<MovieResponse>(favoriteMovies, request.Page, request.PageSize, totalCount);
    }

    public async Task<PagedList<RatingResponse>> Handle(GetProfileRatingsQuery request, CancellationToken cancellationToken)
    {
        // Get All Rating by Porfile
        var ratingQuery = _unitOfWork.ProfileRepository.FindAllRatingByIdAsync(request.Id);

        var totalCount = ratingQuery.Count();
        var items = ratingQuery.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

        var ratings = _mapper.Map<List<RatingResponse>>(items);

        return new PagedList<RatingResponse>(ratings, request.Page, request.PageSize, totalCount);
    }
}
