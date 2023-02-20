using Application.CustomMappers.Interfaces;
using Core.Dtos.Rates;
using Core.Entites;

namespace Application.CustomMappers.RatesMappers;
public class SaveRateDtoToRating : IDtoMapper<RateSaveDto, Rating>
{
    public Rating Map(RateSaveDto source)
    {
        var mapped = new Rating()
        {
            Score = source.score
        };
        return mapped;
    }
}