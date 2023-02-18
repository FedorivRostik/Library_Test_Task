using Application.CustomMappers.Interfaces;
using Core.Dtos.Books;
using Core.Entites;

namespace Application.CustomMappers.BookMappers;
public class BooksBaseMapper : IEnumerableDtoMapper<IEnumerable<Book>, IEnumerable<BookBase>>
{
    public IEnumerable<BookBase> Map(IEnumerable<Book> source)
    {
        var bookBaseDtos = source.Select(GetExceptionEntityReadViewModel).ToList();
        return bookBaseDtos;
    }

    private BookBase GetExceptionEntityReadViewModel(Book book)
    {
        var exceptionViewModel = new BookBase()
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
