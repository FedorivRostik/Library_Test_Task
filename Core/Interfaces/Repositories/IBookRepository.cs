using Core.Entites;

namespace Core.Interfaces.Repositories;
public interface IBookRepository
{
    public Task<List<Book>> GetAllBooks(string orderBy);
}
