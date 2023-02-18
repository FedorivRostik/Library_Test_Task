namespace Application.CustomMappers.Interfaces;
public interface IEnumerableDtoMapper<TSource, TDestination> : IDtoMapper<TSource, TDestination>
{
    public IEnumerable<TDestination> Map(IEnumerable<TSource> source)
    {
        return source.Select<TSource, TDestination>(item => Map(item));
    }
}

