namespace Core.Dtos.Reviews;
public class ReviewDto
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Reviewer { get; set; } = string.Empty;
}
