using Application.CustomMappers.Interfaces;
using Core.Dtos.Books;
using Core.Entites;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;

namespace Application.Services;
public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IEnumerableDtoMapper<IEnumerable<Book>, IEnumerable<BookBaseDto>> _booksToBaseBooks;
    private readonly IDtoMapper<Book, BookBaseDtoWithReviewBaseDto> _bookToBookBaseDtoWithReviewBaseDto;

    public BookService(
         IBookRepository bookRepository,
         IEnumerableDtoMapper<IEnumerable<Book>, IEnumerable<BookBaseDto>> booksToBaseBooks,
        IDtoMapper<Book, BookBaseDtoWithReviewBaseDto> bookToBookBaseDtoWithReviewBaseDto)
    {
        _bookRepository = bookRepository;
        _booksToBaseBooks = booksToBaseBooks;
        _bookToBookBaseDtoWithReviewBaseDto = bookToBookBaseDtoWithReviewBaseDto;
    }

    public async Task<List<BookBaseDto>> GetAllBooksAsync(QueryParameters queryParameters)
    {
        var books = await _bookRepository.GetAllBooksAsync(queryParameters);

        var baseBooks = _booksToBaseBooks
            .Map(books)
            .ToList();

        return baseBooks;
    }

    public async Task<List<BookBaseDto>> GetAllRecomendedBooksAsync(QueryParameters queryParameters)
    {
        var books = await _bookRepository.GetAllRecomendedBooksAsync(queryParameters);

        var baseBooks = _booksToBaseBooks
            .Map(books)
            .Where(x => x.ReviewNumber >= 10)
            .OrderByDescending(x => x.Rating)
            .Take(10)
            .ToList();

        return baseBooks;
    }

    public async Task<BookBaseDtoWithReviewBaseDto> GetBookAsync(int id)
    {
        var book = await _bookRepository.GetBookAsync(id);

        IsNull<Book>(book, id);

        var bookBaseDtoWithReviewBaseDto = _bookToBookBaseDtoWithReviewBaseDto.Map(book);
        return bookBaseDtoWithReviewBaseDto;
    }

    public async Task<int> DeleteBookAsync(int id)
    {
        var book = await _bookRepository.GetBookAsync(id);

        IsNull<Book>(book, id);

        var deletedId = await _bookRepository.DeleteBookAsync(book);

        return deletedId;
    }

    private void IsNull<T>(T obj, int id) where T : BaseEntity
    {
        if (obj is null)
        {
            throw new NotFoundException($"No {typeof(T).Name} with id: {id}.");
        }
    }
}
