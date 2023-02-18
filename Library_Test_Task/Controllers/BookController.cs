using Core.Dtos.Books;
using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Test_Task.Controllers;
[Route("api/")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("books/")]
    public async Task<ActionResult<List<BookBase>>> GetBooksAsync([FromQuery] QueryParameters queryParameters)
    {
        var books = await _bookService.GetAllBooksAsync(queryParameters!);
        return Ok(books);
    }
    [HttpGet("recommended/")]
    public async Task<ActionResult<List<BookBase>>> GetRecomendedAsync([FromQuery] QueryParameters queryParameters)
    {
        var books = await _bookService.GetAllRecomendedBooksAsync(queryParameters!);
        return Ok(books);
    }
}
