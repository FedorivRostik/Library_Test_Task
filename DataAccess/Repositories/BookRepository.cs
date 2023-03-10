using Core.Entites;
using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace DataAccess.Repositories;
public class BookRepository : IBookRepository
{
    private readonly LibraryContext _libraryContext;

    public BookRepository(LibraryContext libraryContext)
    {
        _libraryContext = libraryContext;
    }

    public async Task<List<Book>> GetAllBooksAsync(QueryParameters queryParameters)
    {
        var books = _libraryContext.Books.AsQueryable();

        ApplySort(ref books, queryParameters.order!);

        return await books
            .Include(b => b.Reviews)
            .Include(b => b.Ratings)
            .ToListAsync();
    }

    public async Task<List<Book>> GetAllRecomendedBooksAsync(QueryParameters queryParameters)
    {
        var books = _libraryContext.Books.AsQueryable();

        ApplyFilter(ref books, queryParameters.genre!);
        ApplySort(ref books, queryParameters.order!.Split(" ")[0]);

        return await books
            .Include(b => b.Reviews)
            .Include(b => b.Ratings)
            .ToListAsync();
    }

    public async Task<Book> GetBookAsync(int id)
    {
        var book = await _libraryContext.Books
            .Include(b => b.Reviews)
            .Include(b => b.Ratings)
            .FirstOrDefaultAsync(b => b.Id == id);

        return book!;
    }

    public async Task<int> DeleteBookAsync(Book book)
    {
        _libraryContext.Remove(book);

        await _libraryContext.SaveChangesAsync();

        return book.Id;

    }

    public async Task<int> CreateBookAsync(Book book)
    {
        await _libraryContext.AddAsync(book);
        await _libraryContext.SaveChangesAsync();

        return book.Id;
    }

    public async Task<int> UpdateBookAsync(Book book)
    {
        var dbBook = await _libraryContext.Books.FirstOrDefaultAsync(x => x.Id == book.Id)!;

        _libraryContext.Books.Entry(dbBook!).State = EntityState.Detached;
        _libraryContext.Books.Entry(book).State = EntityState.Modified;
        await _libraryContext.SaveChangesAsync();

        return book.Id;
    }

    public async Task<int> AddReviewToBookAsync(Review review, int id)
    {
        review.BookId = id;
        await _libraryContext.AddAsync(review);
        await _libraryContext.SaveChangesAsync();

        return review.Id;
    }

    public async Task<int> AddRateToBookAsync(Rating rating, int id)
    {
        rating.BookId = id;
        await _libraryContext.AddAsync(rating);
        await _libraryContext.SaveChangesAsync();

        return rating.Id;
    }

    private void ApplySort(ref IQueryable<Book> books, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
        {
            books = books.OrderBy(x => x.Author);
            return;
        }
        var orderParams = orderByQueryString.Trim().Split(',');

        var propertyInfos = typeof(Book).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var orderQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;
            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
            if (objectProperty == null)
                continue;
            var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        if (string.IsNullOrWhiteSpace(orderQuery))
        {
            books = books.OrderBy(x => x.Author);
            return;
        }
        books = books.OrderBy(orderQuery);
    }

    private void ApplyFilter(ref IQueryable<Book> books, string filterQueryString)
    {
        if (string.IsNullOrWhiteSpace(filterQueryString))
        {
            return;
        }
        var filter = filterQueryString.Split(" ")[0];
        books = books.Where(x => x.Genre.Equals(filter, StringComparison.InvariantCultureIgnoreCase));
    }
}
