﻿#nullable disable

namespace Core.Entites;

public class Rating
{
    public int Id { get; set; }
    public int Score { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }
}
