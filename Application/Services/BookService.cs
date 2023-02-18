using Application.CustomMappers.Interfaces;
using Core.Dtos.Books;
using Core.Entites;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

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

    public async Task<List<BookBase>> GetAllBooks(string orderBy)
    {
        var books = await _bookRepository.GetAllBooks(orderBy);
        var baseBooks = _booksToBaseBooks.Map(books).ToList();
        return baseBooks;
    }
}
