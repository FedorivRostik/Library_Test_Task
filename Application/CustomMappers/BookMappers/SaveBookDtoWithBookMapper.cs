using Application.CustomMappers.Interfaces;
using Core.Dtos.Books;
using Core.Entites;

namespace Application.CustomMappers.BookMappers;
public class SaveBookDtoWithBookMapper : IDtoMapper<SaveBookDto, Book>
{
    public Book Map(SaveBookDto source)
    {

        var exceptionViewModel = new Book()
        {
            Id = source.Id,
            Title = source.Title,
            Author = source.Author,
            Content = source.Content,
            Genre = source.Genre,
        };

        return exceptionViewModel;

    }
}
