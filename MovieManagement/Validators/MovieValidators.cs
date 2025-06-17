using FluentValidation;
using MovieManagement.Models;
namespace MovieManagement.Validators;
public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(movie => movie.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(movie => movie.ReleaseYear)
            .InclusiveBetween(1888, DateTime.Now.Year).WithMessage("Year of publish must be between 1888 and the current year.")
            .LessThanOrEqualTo(4).WithMessage("Year of publish must be a 4-digit number.");

        RuleFor(movie => movie.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");
    }
}