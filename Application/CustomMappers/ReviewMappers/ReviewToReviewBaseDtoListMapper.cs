using Application.CustomMappers.Interfaces;
using Core.Dtos.Reviews;
using Core.Entites;

namespace Application.CustomMappers.ReviewMappers;
public class ReviewToReviewBaseDtoListMapper : IEnumerableDtoMapper<IEnumerable<Review>, IEnumerable<ReviewBaseDto>>
{
    public IEnumerable<ReviewBaseDto> Map(IEnumerable<Review> source)
    {
        var mapped = source.Select(MapFromTo).ToList();
        return mapped;
    }

    private ReviewBaseDto MapFromTo(Review review)
    {
        var mapped = new ReviewBaseDto()
        {
            Id = review.Id,
            Message = review.Message,
            Reviewer = review.Reviewer
        };

        return mapped;
    }
}
