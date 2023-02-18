using Application.CustomMappers.Interfaces;
using Core.Dtos.Books;
using Core.Entites;

namespace Application.CustomMappers.BookMappers;
public class BooksBaseListMapper : IEnumerableDtoMapper<IEnumerable<Book>, IEnumerable<BookBaseDto>>
{
    public IEnumerable<BookBaseDto> Map(IEnumerable<Book> source)
    {
        var bookBaseDtos = source.Select(MapFromTo).ToList();
        return bookBaseDtos;
    }

    private BookBaseDto MapFromTo(Book book)
    {
        var exceptionViewModel = new BookBaseDto()
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Rating = book.Ratings.Any() ? book.Ratings.Average(x => (decimal)x.Score) : 0.0m,
            ReviewNumber = book.Reviews.Any() ? book.Reviews.Count() : 0.0m
        };

        return exceptionViewModel;
    }
}
