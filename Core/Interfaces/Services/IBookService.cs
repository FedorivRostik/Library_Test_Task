using Core.Dtos.Books;
using Core.Entites;
using Core.Models;

namespace Core.Interfaces.Services;
public interface IBookService
{
    public Task<List<BookBaseDto>> GetAllBooksAsync(QueryParameters queryParameters);
    public Task<List<BookBaseDto>> GetAllRecomendedBooksAsync(QueryParameters queryParameters);
    public Task<BookBaseDtoWithReviewBaseDto> GetBookAsync(int id);
}
