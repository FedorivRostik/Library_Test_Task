using Core.Dtos.Books;
using Core.Dtos.Rates;
using Core.Dtos.Reviews;
using Core.Interfaces.Services;
using Core.Models;
using Library_Test_Task.FilterAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace Library_Test_Task.Controllers;
[Route("api/")]
[ApiController]
public class ApiController : ControllerBase
{
    private readonly IBookService _bookService;
    public ApiController(IBookService bookService, IConfiguration configuration)
    {
        _bookService = bookService;
    }

    [HttpGet("books/")]
    public async Task<ActionResult<List<BookBaseDto>>> GetBooksAsync([FromQuery] QueryParameters queryParameters)
    {
        var books = await _bookService.GetAllBooksAsync(queryParameters!);
        return Ok(books);
    }

    [HttpGet("recommended/")]
    public async Task<ActionResult<List<BookBaseDto>>> GetRecomendedAsync([FromQuery] QueryParameters queryParameters)
    {
        var books = await _bookService.GetAllRecomendedBooksAsync(queryParameters!);
        return Ok(books);
    }

    [HttpGet("books/{id:int:min(1)}")]
    public async Task<ActionResult<BookBaseDtoWithReviewBaseDto>> GetRecomendedAsync([FromRoute] int id)
    {
        var books = await _bookService.GetBookAsync(id);
        return Ok(books);
    }

    [HttpDelete("books/{id:int:min(1)}")]
    [CheckSecretKey]
    public async Task<ActionResult<string>> Delete([FromRoute] int id, [BindRequired, FromQuery] string secret)
    {
        var deletedId = await _bookService.DeleteBookAsync(id);

        var responseString = new JProperty("id", deletedId).ToString();

        return Ok(responseString);
    }
    [HttpPost("books/save")]
    public async Task<ActionResult<string>> CreateBookAsync([FromForm] SaveBookDto saveBookDto)
    {
        var responseId = await _bookService.SaveBookAsync(saveBookDto);

        var responseString = new JProperty("id", responseId).ToString();

        return Ok(responseString);
    }
    [HttpPut("books/{id:int:min(1)}/review")]
    public async Task<ActionResult<string>> AddReviewToBookAsync([FromRoute] int id, [FromForm] ReviewSaveDto reviewSaveDto)
    {
        var responseId = await _bookService.AddReviewToBookAsync(reviewSaveDto, id);

        var responseString = new JProperty("id", responseId).ToString();

        return Ok(responseString);
    }

    [HttpPut("books/{id:int:min(1)}/rate")]
    public async Task<ActionResult<string>> AddReviewToBookAsync([FromRoute] int id, [FromForm] RateSaveDto rateSaveDto)
    {
        var responseId = await _bookService.AddRateToBookAsync(rateSaveDto, id);

        var responseString = new JProperty("id", responseId).ToString();

        return Ok(responseString);
    }
}
