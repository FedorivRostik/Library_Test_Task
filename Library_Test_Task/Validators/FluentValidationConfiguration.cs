using Core.Dtos.Books;
using Core.Dtos.Rates;
using Core.Dtos.Reviews;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Library_Test_Task.Validators;
public static class FluentValidationConfiguration
{
    public static void ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }

    public static void AddCustomValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RateSaveDto>, RateSaveDtoValidator>();
        services.AddScoped<IValidator<ReviewSaveDto>, ReviewSaveDtoValidator>();
        services.AddScoped<IValidator<SaveBookDto>, SaveBookDtoValidator>();
    }
}
