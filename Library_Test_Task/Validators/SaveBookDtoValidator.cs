using Core.Dtos.Books;
using FluentValidation;

namespace Library_Test_Task.Validators;
public class SaveBookDtoValidator : AbstractValidator<SaveBookDto>
{
    public SaveBookDtoValidator()
    {
        RuleFor(email => email.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MinimumLength(4)
                .WithMessage("Lenght must be at least 4 and less 100")
                .MaximumLength(100);

        RuleFor(email => email.Content)
               .NotEmpty()
               .WithMessage("Content is required")
               .MinimumLength(4)
                .WithMessage("Lenght must be at least 4 and less 50000")
               .MaximumLength(5000);

        RuleFor(email => email.Author)
               .NotEmpty()
               .WithMessage("Author is required")
               .MinimumLength(4)
               .WithMessage("Lenght must be at least 4 and less 50")
               .MaximumLength(50);

        RuleFor(email => email.Genre)
               .NotEmpty()
               .WithMessage("Title is required")
               .MinimumLength(4)
              .WithMessage("Genre must be at least 4 and less 20")
               .MaximumLength(20);
    }
}
