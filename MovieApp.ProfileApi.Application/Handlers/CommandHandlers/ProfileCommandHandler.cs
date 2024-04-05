
using AutoMapper;
using FluentValidation;
using MediatR;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Domain.Exceptions;

namespace MovieApp.ProfileApi.Application.Handlers.CommandHandlers;
public class ProfileCommandHandler : IRequestHandler<CreateProfileCommand, Guid>
{
    private readonly IProfileRepository _ProfileRepository;
    private readonly IMapper _mapper;

    private readonly IValidator<CreateProfileCommand> _validator;

    public ProfileCommandHandler(IProfileRepository ProfileRepository, IMapper mapper, IValidator<CreateProfileCommand> validator)
    {
        _ProfileRepository = ProfileRepository;
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

        if ((await _ProfileRepository.FindByIdAsync(newProfile.Id)) is not null)
        {
            throw new ProfileAlreadyExistsException(newProfile.Id);
        }

        await _ProfileRepository.SaveAsync(newProfile);
        await _ProfileRepository.CommitAsync();

        return newProfile.Id;
    }
}
