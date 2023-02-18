using Application.CustomMappers.Interfaces;
using Core.Dtos.Books;
using Core.Entites;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;

namespace Application.Services;
public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IEnumerableDtoMapper<IEnumerable<Book>, IEnumerable<BookBase>> _booksToBaseBooks;

    public BookService(
        IBookRepository bookRepository,
        IEnumerableDtoMapper<IEnumerable<Book>, IEnumerable<BookBase>> booksToBaseBooks)
    {
        _bookRepository = bookRepository;
        _booksToBaseBooks = booksToBaseBooks;
    }

    public async Task<List<BookBase>> GetAllBooksAsync(QueryParameters queryParameters)
    {
        var books = await _bookRepository.GetAllBooksAsync(queryParameters);

        var baseBooks = _booksToBaseBooks
            .Map(books)
            .ToList();

        return baseBooks;
    }

    public async Task<List<BookBase>> GetAllRecomendedBooksAsync(QueryParameters queryParameters)
    {
        var books = await _bookRepository.GetAllRecomendedBooksAsync(queryParameters);

        var baseBooks = _booksToBaseBooks
            .Map(books)
            .Where(x=>x.ReviewNumber>=10)
            .OrderBy(x=>x.Rating)
            .Take(10)
            .ToList();

        return baseBooks;
    }
}
