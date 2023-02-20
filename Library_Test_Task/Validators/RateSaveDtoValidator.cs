using Core.Dtos.Rates;
using Core.Dtos.Reviews;
using FluentValidation;

namespace Library_Test_Task.Validators;
public class RateSaveDtoValidator : AbstractValidator<RateSaveDto>
{
    public RateSaveDtoValidator()
    {
        RuleFor(email => email.score)
                 .LessThanOrEqualTo(5)
                 .GreaterThanOrEqualTo(1)
                .WithMessage("score must be from 1 to 5");
    }

}