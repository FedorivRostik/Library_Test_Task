using Core.Dtos.Books;

namespace Core.Interfaces.Services;
public interface IBookService
{
    public Task<List<BookBase>> GetAllBooks(string orderBy);
}
