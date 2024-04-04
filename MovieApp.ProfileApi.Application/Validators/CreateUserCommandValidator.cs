using FluentValidation;
using MovieApp.ProfileApi.Application.Commands;

namespace MovieApp.ProfileApi.Application.Validators;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
    }
}
