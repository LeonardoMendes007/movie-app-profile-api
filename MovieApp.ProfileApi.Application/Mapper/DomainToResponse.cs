using AutoMapper;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Application.Responses;

namespace MovieApp.ProfileApi.Application.Mapper;
public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        #region Profile to ProfileReponse

        CreateMap<MovieApp.Domain.Entities.Profile, ProfileSummary>();

        #endregion

        #region Movie to MovieReponse

        CreateMap<MovieApp.Domain.Entities.Movie, MovieSummary>();

        #endregion

        #region Rating to RatingReponse

        CreateMap<MovieApp.Domain.Entities.Rating, RatingSummary>();

        #endregion

        #region Genre to GenreResponse

        CreateMap<MovieApp.Domain.Entities.Genre, GenreSummary>();

        #endregion
    }
}
