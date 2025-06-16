using FluentValidation;
using BookManagementSystem.Models;

namespace BookManagementSystem.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be blank")
            .Length(1, 100).WithMessage("Title must be between 1 and 100 characters")
            .Matches(@"^[a-zA-Z0-9\s]+$").WithMessage("Title can only contain letters, numbers, and spaces");

        RuleFor(x => x.Description)
        .NotEmpty().WithMessage("Description cannot be blank")
        .Length(3, 800).WithMessage("Description must be between 3 and 800 characters")
        .Matches(@"^[a-zA-Z0-9\s,.!?]+$").WithMessage("Description can only contain letters, numbers, spaces, and punctuation (.,!?).");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author cannot be blank")
            .Length(1, 100).WithMessage("Author must be between 1 and 100 characters")
            .Matches(@"^[a-zA-Z\s]+$").WithMessage("Author can only contain letters and spaces");

        RuleFor(x => x.PublishedDate)
            .NotEmpty().WithMessage("Published Date cannot be blank")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Published Date cannot be in the future");

        RuleFor(x => x.BookGenres)
        .NotEmpty().WithMessage("At least one genre must be selected")
        .Must(genres => genres != null && genres.Count >= 1 && genres.Count <= 5)
            .WithMessage("You can select up to 5 genres");
    }
}
