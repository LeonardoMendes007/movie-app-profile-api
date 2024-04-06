
using AutoMapper;
using FluentValidation;
using MediatR;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Domain.Entities;
using MovieApp.ProfileApi.Domain.Exceptions;
using MovieApp.ProfileApi.Domain.Interfaces;

namespace MovieApp.ProfileApi.Application.Handlers.CommandHandlers;
public class ProfileCommandHandler : IRequestHandler<CreateProfileCommand, Guid>,
                                     IRequestHandler<RegisterFavoriteMovieCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IValidator<CreateProfileCommand> _validator;

    public ProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateProfileCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new Exceptions.ValidationException(validationResult.ToDictionary());
        }

        var newProfile = _mapper.Map<Domain.Entities.Profile>(request);

        if ((await _unitOfWork.ProfileRepository.FindByIdAsync(newProfile.Id)) is not null)
        {
            throw new ProfileAlreadyExistsException(newProfile.Id);
        }

        await _unitOfWork.ProfileRepository.SaveAsync(newProfile);
        await _unitOfWork.CommitAsync();

        return newProfile.Id;
    }

    public async Task Handle(RegisterFavoriteMovieCommand request, CancellationToken cancellationToken)
    {
        var profile = await _unitOfWork.ProfileRepository.FindByIdAsync(request.ProfileId);

        if (profile is null)
        {
            throw new ResourceNotFoundException(request.ProfileId, $"No Profile found with id = {request.ProfileId}.");
        }

        var movie = await _unitOfWork.MovieRepository.FindByIdAsync(request.MovieId);

        if(movie is null)
        {
            throw new ResourceNotFoundException(request.MovieId, $"No Movie found with id = {request.MovieId}.");
        }

        if (profile.FavoritesMovies.Any(m => m.Id == movie.Id))
        {
            throw new ResourceNotFoundException(request.MovieId, $"No Movie found with id = {request.MovieId}.");
        }

        profile.FavoritesMovies.Add(movie);

        await _unitOfWork.ProfileRepository.UpdateAsync(profile);
        await _unitOfWork.CommitAsync();
    }
}
