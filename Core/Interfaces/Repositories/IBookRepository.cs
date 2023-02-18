﻿using Core.Dtos.Books;
using Core.Entites;
using Core.Models;

namespace Core.Interfaces.Repositories;
public interface IBookRepository
{
    public Task<List<Book>> GetAllBooksAsync(QueryParameters queryParameters);
    public Task<List<Book>> GetAllRecomendedBooksAsync(QueryParameters queryParameters);
    public Task<Book> GetBookAsync(int id);
}
