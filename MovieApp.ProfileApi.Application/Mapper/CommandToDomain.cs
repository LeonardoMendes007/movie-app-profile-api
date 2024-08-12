using AutoMapper;
using MovieApp.ProfileApi.Application.Commands;

namespace MovieApp.ProfileApi.Application.Mapper;
public class CommandToDomain : Profile
{
    public CommandToDomain()
    {
        #region CreateProfileCommand to Profile

        CreateMap<CreateProfileCommand, MovieApp.Domain.Entities.Profile>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

        #endregion

        #region RegisterMovieRatingCommand to Rating

        CreateMap<RegisterMovieRatingCommand, MovieApp.Domain.Entities.Rating>();

        #endregion

    }
}
