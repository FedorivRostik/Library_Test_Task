using Application.CustomMappers.BookMappers;
using Application.CustomMappers.Interfaces;
using Application.CustomMappers.ReviewMappers;
using Core.Dtos.Books;
using Core.Dtos.Reviews;
using Core.Entites;
using Microsoft.Extensions.DependencyInjection;

namespace Application.CustomMappers;
public static class ApplicationMappersConfiguration
{
    public static void AddApplicationMappers(this IServiceCollection services)
    {
        services.AddScoped<IEnumerableDtoMapper<IEnumerable<Book>, IEnumerable<BookBaseDto>>, BooksBaseListMapper>();
        services.AddScoped<IEnumerableDtoMapper<IEnumerable<Review>, IEnumerable<ReviewBaseDto>>, ReviewToReviewBaseDtoListMapper>();
        services.AddScoped<IDtoMapper<Book, BookBaseDtoWithReviewBaseDto>, BookDtoWithReviewDtoListMapper>();
        services.AddScoped<IDtoMapper<SaveBookDto, Book>, SaveBookDtoWithBookMapper>();
    }
}
