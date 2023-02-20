using Core.Interfaces.Repositories;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;
public static class DataAccessServicesConfiguration
{
    public static void AddDataAccessServicesConfiguration(this IServiceCollection service)
    {
        service.AddScoped<IBookRepository, BookRepository>();
    }
}
