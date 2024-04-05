using AutoMapper;
using MediatR;
using MovieApp.ProfileApi.Application.Queries;
using MovieApp.ProfileApi.Application.Responses.Movie;
using MovieApp.ProfileApi.Application.Responses.Rating;
using MovieApp.ProfileApi.Application.Responses.Profile;
using MovieApp.ProfileApi.Domain.Exceptions;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.ProfileApi.Domain.Entities;
using System.Linq.Expressions;

namespace MovieApp.Application.Handlers.QueriesHandlers;
public class ProfileQueryHandlers : IRequestHandler<GetProfileByIdQuery, ProfileResponse>,
                                 IRequestHandler<GetProfileFavoriteMoviesQuery, IEnumerable<MovieResponse>>,
                                 IRequestHandler<GetProfileRatingsQuery, IEnumerable<RatingResponse>>
{
    private readonly IProfileRepository _ProfileRepository;
    private readonly IMapper _mapper;

    public ProfileQueryHandlers(IProfileRepository ProfileRepository, IMapper mapper)
    {
        _ProfileRepository = ProfileRepository;
        _mapper = mapper;
    }

    public async Task<ProfileResponse> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var Profile = await _ProfileRepository.FindByIdAsync(request.Id);
        
        if (Profile is null)
        {
            throw new ResourceNotFoundException(request.Id);
        }

        return _mapper.Map<ProfileResponse>(Profile);
    }

    public async Task<IEnumerable<MovieResponse>> Handle(GetProfileFavoriteMoviesQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Movie, bool>> filter = x => x.Name.Contains(request.SearchTerm);

        var favoriteMovies = _mapper.Map<List<MovieResponse>>(await _ProfileRepository.FindFavoritesMovies(request.Id, request.Skip, request.Take, filter));

        return favoriteMovies;
    }

    public async Task<IEnumerable<RatingResponse>> Handle(GetProfileRatingsQuery request, CancellationToken cancellationToken)
    {
        var ratings = _mapper.Map<List<RatingResponse>>(await _ProfileRepository.FindRatings(request.Id, request.Skip, request.Take));

        return ratings;
    }
}
