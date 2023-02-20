using Core.Entites;
using Core.Models;

namespace Core.Interfaces.Repositories;
public interface IBookRepository
{
    public Task<List<Book>> GetAllBooksAsync(QueryParameters queryParameters);
    public Task<List<Book>> GetAllRecomendedBooksAsync(QueryParameters queryParameters);
    public Task<Book> GetBookAsync(int id);
    public Task<int> DeleteBookAsync(Book book);
    public Task<int> CreateBookAsync(Book book);
    public Task<int> UpdateBookAsync(Book book);
    public Task<int> AddReviewToBookAsync(Review review, int id);
    public Task<int> AddRateToBookAsync(Rating rating, int id);
}
