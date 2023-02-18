#nullable disable

using Core.Entities;

namespace Core.Entites;

public class Rating: BaseEntity
{
    public int Score { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }
}
