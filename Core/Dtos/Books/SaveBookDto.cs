using Microsoft.AspNetCore.Http;

namespace Core.Dtos.Books;
public class SaveBookDto : PrimaryBookDto
{
    public IFormFile Cover { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string Genre { get; set; } = default!;
}
