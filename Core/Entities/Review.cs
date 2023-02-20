#nullable disable

using Core.Entities;

namespace Core.Entites;

public class Review : BaseEntity
{
    public string Message { get; set; } = string.Empty;
    public string Reviewer { get; set; } = string.Empty;

    public int BookId { get; set; }
    public Book Book { get; set; }
}
