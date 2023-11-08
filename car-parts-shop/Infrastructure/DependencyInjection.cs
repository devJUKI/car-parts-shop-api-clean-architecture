using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //var connectionString = configuration.GetConnectionString("AWSConnectionString");
        var connectionString = configuration.GetConnectionString("MySQLConnectionString");

        if (connectionString == null) throw new Exception("Connection string is null");

        services.AddDbContext<CarPartsShopDbContext>(options =>
        {
            options.UseMySQL(connectionString);
        });

        return services;
    }
}
