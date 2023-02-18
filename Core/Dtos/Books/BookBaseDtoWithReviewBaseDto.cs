using Core.Dtos.Reviews;

namespace Core.Dtos.Books;
public class BookBaseDtoWithReviewBaseDto : BookDto
{
    public string Cover { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<ReviewBaseDto> Reviews { get; set; } = new List<ReviewBaseDto>();
}
