using AutoMapper;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Application.Responses.Movie;
using MovieApp.ProfileApi.Application.Responses.Profile;
using MovieApp.ProfileApi.Application.Responses.Rating;

namespace MovieApp.ProfileApi.Application.Mapper;
public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        #region Profile to ProfileReponse

        CreateMap<Domain.Entities.Profile, ProfileResponse>();

        #endregion

        #region Movie to MovieReponse

        CreateMap<Domain.Entities.Movie, MovieResponse>();

        #endregion

        #region Rating to RatingReponse

        CreateMap<Domain.Entities.Rating, RatingResponse>();

        #endregion
    }
}
