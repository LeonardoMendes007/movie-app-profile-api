
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Data.Persistence;
using MovieApp.Infra.Data.Persistence.Repositories;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Application.Mapper.AutoMapperConfig;
using MovieApp.ProfileApi.Application.Validators;

namespace MovieApp.ProfileApi.CrossCutting.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        #region Banco de dados
        services.AddDbContext<MovieAppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection")));
        #endregion


        #region MediatR
        var assembly = AppDomain.CurrentDomain.Load("MovieApp.ProfileApi.Application");

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        #endregion

        #region AutoMapper
        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        #endregion

        #region Service
        services.AddScoped<IProfileRepository, ProfileRepository>();
        #endregion

        #region Validators
        services.AddTransient<IValidator<CreateProfileCommand>, CreateProfileCommandValidator>();
        #endregion


        return services;
    }
}
