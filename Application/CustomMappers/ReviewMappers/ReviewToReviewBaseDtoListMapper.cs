using Application.CustomMappers.Interfaces;
using Core.Dtos.Reviews;
using Core.Entites;

namespace Application.CustomMappers.ReviewMappers;
public class ReviewToReviewBaseDtoListMapper : IEnumerableDtoMapper<IEnumerable<Review>, IEnumerable<ReviewBaseDto>>
{
    public IEnumerable<ReviewBaseDto> Map(IEnumerable<Review> source)
    {
        var bookBaseDtos = source.Select(MapFromTo).ToList();
        return bookBaseDtos;
    }

    private ReviewBaseDto MapFromTo(Review review)
    {
        var exceptionViewModel = new ReviewBaseDto()
        {
            Id = review.Id,
            Message = review.Message,
            Reviewer = review.Reviewer
        };

        return exceptionViewModel;
    }
}
