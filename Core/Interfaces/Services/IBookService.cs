using Core.Dtos.Books;
using Core.Entites;
using Core.Models;

namespace Core.Interfaces.Services;
public interface IBookService
{
    public Task<List<BookBase>> GetAllBooksAsync(QueryParameters queryParameters);
    public Task<List<BookBase>> GetAllRecomendedBooksAsync(QueryParameters queryParameters);
}
