using FluentValidation;
using MovieApp.ProfileApi.Application.Commands;

namespace MovieApp.ProfileApi.Application.Validators;
public class CreateProfileCommandValidator : AbstractValidator<CreateProfileCommand>
{
    public CreateProfileCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
    }
}
