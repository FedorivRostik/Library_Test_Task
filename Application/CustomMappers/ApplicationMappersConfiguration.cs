using Application.CustomMappers.BookMappers;
using Application.CustomMappers.Interfaces;
using Core.Dtos.Books;
using Core.Entites;
using Microsoft.Extensions.DependencyInjection;

namespace Application.CustomMappers;
public static class ApplicationMappersConfiguration
{
    public static void AddApplicationMappers(this IServiceCollection services)
    {
        services.AddScoped<IEnumerableDtoMapper<IEnumerable<Book>, IEnumerable<BookBase>>, BooksBaseMapper>();
    }
}
