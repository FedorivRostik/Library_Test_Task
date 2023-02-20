using Application.CustomMappers.Interfaces;
using Core.Dtos.Reviews;
using Core.Entites;

namespace Application.CustomMappers.ReviewMappers;
public class SaveReviewDtoToReview : IDtoMapper<ReviewSaveDto, Review>
{
    public Review Map(ReviewSaveDto source)
    {

        var mapped = new Review()
        {
            Message = source.message,
            Reviewer = source.reviewer
        };
        return mapped;
    }

}