using AutoMapper;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Domain.Entities;

namespace MovieApp.ProfileApi.Application.AutoMapper;
public class CommandToDomain : Profile
{
    public CommandToDomain()
    {
        #region CreateUserCommand to User

        CreateMap<CreateUserCommand, User>();

        #endregion

    }
}
