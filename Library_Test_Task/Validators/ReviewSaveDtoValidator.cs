using Core.Dtos.Reviews;
using FluentValidation;

namespace Library_Test_Task.Validators;
internal class ReviewSaveDtoValidator : AbstractValidator<ReviewSaveDto>
{
    public ReviewSaveDtoValidator()
    {
        RuleFor(email => email.message)
                .NotEmpty()
                .WithMessage("message is required")
                .MinimumLength(4)
                .WithMessage("Lenght must be at least 4 and less 1000")
                .MaximumLength(1000);

        RuleFor(email => email.reviewer)
               .NotEmpty()
               .WithMessage("reviewer is required")
               .MinimumLength(4)
                .WithMessage("Lenght must be at least 4 and less 50")
               .MaximumLength(50);

    }
}