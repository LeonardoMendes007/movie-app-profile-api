using AutoMapper;
using FluentValidation;
using MediatR;
using MovieApp.ProfileApi.Application.Commands;
using MovieApp.ProfileApi.Application.Exceptions;
using MovieApp.ProfileApi.Domain.Exceptions;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.ProfileApi.Domain.Entities;

namespace MovieApp.ProfileApi.Application.Handlers.CommandHandlers;
public class UserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    private readonly IValidator<CreateUserCommand> _validator;

    public UserCommandHandler(IUserRepository userRepository, IMapper mapper, IValidator<CreateUserCommand> validator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new Exceptions.ValidationException(validationResult.ToDictionary());
        }

        var newUser = _mapper.Map<User>(request);

        if ((await _userRepository.FindByIdAsync(newUser.Id)) is not null)
        {
            throw new UserAlreadyExistsException(newUser.Id);
        }

        await _userRepository.SaveAsync(newUser);
        await _userRepository.CommitAsync();

        return newUser.Id;
    }
}
