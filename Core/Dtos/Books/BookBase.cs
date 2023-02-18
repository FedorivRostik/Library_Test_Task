namespace Core.Dtos.Books;
public class BookBase
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public decimal Rating { get; set; }
    public decimal ReviewNumber { get; set; }
}
