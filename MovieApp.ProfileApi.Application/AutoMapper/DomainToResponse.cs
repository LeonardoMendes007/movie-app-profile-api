using AutoMapper;
using MovieApp.ProfileApi.Application.Responses.Movie;
using MovieApp.ProfileApi.Application.Responses.User;
using MovieApp.ProfileApi.Domain.Entities;

namespace MovieApp.ProfileApi.Application.AutoMapper;
public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        #region User to UserReponse

        CreateMap<User, UserResponse>();

        #endregion

        #region Movie to MovieReponse

        CreateMap<Movie, MovieResponse>();

        #endregion
    }
}
