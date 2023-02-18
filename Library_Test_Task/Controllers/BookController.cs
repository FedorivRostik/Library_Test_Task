using Core.Dtos.Books;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_Test_Task.Controllers;
[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet]
    public async Task<ActionResult<List<BookBase>>> GetBooksAsync([FromQuery] string? orderBy = "")
    {
        var books = await _bookService.GetAllBooks(orderBy!);
        return Ok(books);
    }
}
