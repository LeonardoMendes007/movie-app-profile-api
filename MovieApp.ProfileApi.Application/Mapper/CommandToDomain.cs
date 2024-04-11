using AutoMapper;
using MovieApp.ProfileApi.Application.Commands;

namespace MovieApp.ProfileApi.Application.Mapper;
public class CommandToDomain : Profile
{
    public CommandToDomain()
    {
        #region CreateProfileCommand to Profile

        CreateMap<CreateProfileCommand, Domain.Entities.Profile>();

        #endregion

        #region RegisterMovieRatingCommand to Rating

        CreateMap<RatingDTO, Domain.Entities.Rating>();

        #endregion

    }
}
