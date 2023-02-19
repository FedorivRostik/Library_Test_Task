using Application.Services;
using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;
public static class ApplicationServicesConfiguration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IPictureService, PictureService>();
    }
}
