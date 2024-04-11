using FluentValidation;
using MovieApp.ProfileApi.Application.Commands;

namespace MovieApp.ProfileApi.Application.Validators;
public class RegisterMovieRatingCommandValidator : AbstractValidator<RatingDTO>
{
    public RegisterMovieRatingCommandValidator()
    {
        RuleFor(x => x.Score).GreaterThanOrEqualTo(0).LessThanOrEqualTo(5);
    }
}
