using Microsoft.EntityFrameworkCore;
using NeuroEstimulator.Data.Context;

namespace NeuroEstimulator.API.Config;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if(services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        var databaseConnectionString = configuration.GetConnectionString("DB");

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(databaseConnectionString);
        });
    }
}
