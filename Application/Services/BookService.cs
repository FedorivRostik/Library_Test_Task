using Application.CustomMappers.Interfaces;
using Core.Dtos.Books;
using Core.Dtos.Rates;
using Core.Dtos.Reviews;
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
    private readonly IPictureService _pictureService;
    private readonly IEnumerableDtoMapper<IEnumerable<Book>, IEnumerable<BookBaseDto>> _booksToBaseBooks;
    private readonly IDtoMapper<Book, BookBaseDtoWithReviewBaseDto> _bookToBookBaseDtoWithReviewBaseDto;
    private readonly IDtoMapper<SaveBookDto, Book> _saveBookDtoToBook;
    private readonly IDtoMapper<ReviewSaveDto, Review> _saveReviewDtoToReview;
    private readonly IDtoMapper<RateSaveDto, Rating> _rateSaveDtoToRating;
    public BookService(
         IBookRepository bookRepository,
         IEnumerableDtoMapper<IEnumerable<Book>, IEnumerable<BookBaseDto>> booksToBaseBooks,
        IDtoMapper<Book, BookBaseDtoWithReviewBaseDto> bookToBookBaseDtoWithReviewBaseDto,
        IPictureService pictureService,
        IDtoMapper<SaveBookDto, Book> saveBookDtoToBook,
        IDtoMapper<ReviewSaveDto, Review> saveReviewDtoToReview,
         IDtoMapper<RateSaveDto, Rating> rateSaveDtoToRating)
    {
        _bookRepository = bookRepository;
        _booksToBaseBooks = booksToBaseBooks;
        _bookToBookBaseDtoWithReviewBaseDto = bookToBookBaseDtoWithReviewBaseDto;
        _pictureService = pictureService;
        _saveBookDtoToBook = saveBookDtoToBook;
        _saveReviewDtoToReview = saveReviewDtoToReview;
        _rateSaveDtoToRating = rateSaveDtoToRating;
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
    public async Task<int> SaveBookAsync(SaveBookDto saveBookDto)
    {
        int responseId;
        var Base64 = _pictureService.GetBase64FromFile(saveBookDto.Cover);
        if (string.IsNullOrEmpty(Base64))
        {
            throw new NotFoundException();
        }

        var bookToSave = _saveBookDtoToBook.Map(saveBookDto);
        bookToSave.Cover = Base64;

        var book = await _bookRepository.GetBookAsync(bookToSave.Id);

        if (book is null)
        {
            responseId = await _bookRepository.CreateBookAsync(bookToSave);

            return responseId;
        }
        responseId = await _bookRepository.UpdateBookAsync(bookToSave);
        return responseId;
    }
    public async Task<int> AddReviewToBookAsync(ReviewSaveDto reviewSaveDto, int id)
    {
        var mapped = _saveReviewDtoToReview.Map(reviewSaveDto);
        int responseId = await _bookRepository.AddReviewToBookAsync(mapped, id);
        return responseId;
    }

    public async Task<int> AddRateToBookAsync(RateSaveDto rateSaveDto, int id)
    {
        var mapped = _rateSaveDtoToRating.Map(rateSaveDto);
        int responseId = await _bookRepository.AddRateToBookAsync(mapped, id);
        return responseId;
    }

    private void IsNull<T>(T obj, int id) where T : BaseEntity
    {
        if (obj is null)
        {
            throw new NotFoundException($"No {typeof(T).Name} with id: {id}.");
        }
    }
}
