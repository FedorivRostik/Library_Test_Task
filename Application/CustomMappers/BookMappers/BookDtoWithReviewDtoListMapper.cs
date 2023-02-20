using Application.CustomMappers.Interfaces;
using Core.Dtos.Books;
using Core.Dtos.Reviews;
using Core.Entites;

namespace Application.CustomMappers.BookMappers;
public class BookDtoWithReviewDtoListMapper : IDtoMapper<Book, BookBaseDtoWithReviewBaseDto>
{
    private readonly IEnumerableDtoMapper<IEnumerable<Review>, IEnumerable<ReviewBaseDto>> _reviewsToReviewsList;

    public BookDtoWithReviewDtoListMapper(IEnumerableDtoMapper<IEnumerable<Review>, IEnumerable<ReviewBaseDto>> reviewsToReviewsList)
    {
        _reviewsToReviewsList = reviewsToReviewsList;
    }

    public BookBaseDtoWithReviewBaseDto Map(Book source)
    {
        var mapped = new BookBaseDtoWithReviewBaseDto()
        {
            Id = source.Id,
            Title = source.Title,
            Author = source.Author,
            Cover= source.Cover,
            Content= source.Content,
            Rating = source.Ratings.Any() ? source.Ratings.Average(x => (decimal)x.Score) : 0.0m,
            Reviews = _reviewsToReviewsList.Map(source.Reviews).ToList()
        };

        return mapped;
    }
}
