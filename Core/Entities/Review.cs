#nullable disable

namespace Core.Entites;

public class Review
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Reviewer { get; set; } = string.Empty;

    public int BookId { get; set; }
    public Book Book { get; set; }
}
