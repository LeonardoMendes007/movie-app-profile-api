using AutoMapper;
using MediatR;
using MovieApp.ProfileApi.Application.Queries;
using MovieApp.ProfileApi.Application.Responses.Movie;
using MovieApp.ProfileApi.Application.Responses.Rating;
using MovieApp.ProfileApi.Application.Responses.User;
using MovieApp.ProfileApi.Domain.Exceptions;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.ProfileApi.Domain.Entities;
using System.Linq.Expressions;

namespace MovieApp.Application.Handlers.QueriesHandlers;
public class UserQueryHandlers : IRequestHandler<GetUserByIdQuery, UserResponse>,
                                 IRequestHandler<GetUserFavoriteMoviesQuery, IEnumerable<MovieResponse>>,
                                 IRequestHandler<GetUserRatingsQuery, IEnumerable<RatingResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserQueryHandlers(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id);
        
        if (user is null)
        {
            throw new ResourceNotFoundException(request.Id);
        }

        return _mapper.Map<UserResponse>(user);
    }

    public async Task<IEnumerable<MovieResponse>> Handle(GetUserFavoriteMoviesQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Movie, bool>> filter = x => x.Name.Contains(request.SearchTerm);

        var favoriteMovies = _mapper.Map<List<MovieResponse>>(await _userRepository.FindFavoritesMovies(request.Id, request.Skip, request.Take, filter));

        return favoriteMovies;
    }

    public async Task<IEnumerable<RatingResponse>> Handle(GetUserRatingsQuery request, CancellationToken cancellationToken)
    {
        var ratings = _mapper.Map<List<RatingResponse>>(await _userRepository.FindRatings(request.Id, request.Skip, request.Take));

        return ratings;
    }
}
