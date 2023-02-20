namespace Application.CustomMappers.Interfaces;
public interface IDtoMapper<in TSource, out TDestination>
{
    TDestination Map(TSource source);
}
