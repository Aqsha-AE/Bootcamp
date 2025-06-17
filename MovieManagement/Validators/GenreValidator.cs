using FluentValidation;
using MovieManagement.Models;
namespace MovieManagement.Validators;

public class GenreValidator : AbstractValidator<Genre>
{
    public GenreValidator()
    {
        RuleFor(genre => genre.Name)
            .NotEmpty().WithMessage("Genre name is required.")
            .MaximumLength(50).WithMessage("Genre name cannot exceed 50 characters.");   
    }
}