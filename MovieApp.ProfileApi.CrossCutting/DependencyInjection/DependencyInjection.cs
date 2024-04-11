
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Data.Persistence;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Application.Mapper.AutoMapperConfig;
using MovieApp.ProfileApi.Application.Pagination.Interface;
using MovieApp.ProfileApi.Application.Validators;
using MovieApp.ProfileApi.Domain.Interfaces.Repositories;
using MovieApp.ProfileApi.Domain.Interfaces.UnitOfWork;
using MovieApp.ProfileApi.Infra.Persistence.Repositories;
using MovieApp.ProfileApi.Infra.Persistence.UnitOfWork;

namespace MovieApp.ProfileApi.CrossCutting.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        

        #region Banco de dados
        services.AddDbContext<MovieAppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection"));
            options.UseLoggerFactory(LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information);
            }));
        });
        #endregion


        #region MediatR
        var assembly = AppDomain.CurrentDomain.Load("MovieApp.ProfileApi.Application");

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        #endregion

        #region AutoMapper
        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        #endregion

        #region Repositories
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IRatingRepository, RatingRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        #region Validators
        services.AddTransient<IValidator<CreateProfileCommand>, CreateProfileCommandValidator>();
        services.AddTransient<IValidator<RegisterMovieRatingCommand>, RegisterMovieRatingCommandValidator>();
        #endregion

        


        return services;
    }
}
