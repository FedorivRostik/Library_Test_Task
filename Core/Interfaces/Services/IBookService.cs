using Core.Dtos.Books;
using Core.Dtos.Rates;
using Core.Dtos.Reviews;
using Core.Models;

namespace Core.Interfaces.Services;
public interface IBookService
{
    public Task<List<BookBaseDto>> GetAllBooksAsync(QueryParameters queryParameters);
    public Task<List<BookBaseDto>> GetAllRecomendedBooksAsync(QueryParameters queryParameters);
    public Task<BookBaseDtoWithReviewBaseDto> GetBookAsync(int id);
    public Task<int> DeleteBookAsync(int id);
    public Task<int> SaveBookAsync(SaveBookDto saveBookDto);
    public Task<int> AddReviewToBookAsync(ReviewSaveDto reviewSaveDto, int id);
    public Task<int> AddRateToBookAsync(RateSaveDto rateSaveDto, int id);
}
