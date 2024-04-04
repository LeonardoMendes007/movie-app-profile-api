using AutoMapper;

namespace MovieApp.ProfileApi.Application.AutoMapper.AutoMapperConfig;
public static class AutoMapperConfiguration
{
    public static MapperConfiguration RegisterMappings()
        => new(mc =>
        {
            mc.AddProfiles(new List<Profile>() { new CommandToDomain(), new DomainToResponse() });
        });
}
