
namespace Core.Entites;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }=string.Empty;
    public string Cover { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
    public IEnumerable<Rating> Ratings { get; set; } = new List<Rating>();
}
