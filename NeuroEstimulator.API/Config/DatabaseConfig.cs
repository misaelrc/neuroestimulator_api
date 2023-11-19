using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
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

        //var keyVaultEndpoint = new Uri(configuration["VaultKey"]);
        //var secretClient = new SecretClient(keyVaultEndpoint, new DefaultAzureCredential());
        var databaseConnectionString = configuration.GetConnectionString("DB");

        //KeyVaultSecret kvs = secretClient.GetSecret("NeuroEstimulatorConnDbString");

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(databaseConnectionString);
            //options.UseNpgsql(configuration.GetConnectionString("PG"), b => b.MigrationsAssembly("NeuroEstimulator.PostgresMigrations"));
        });
    }
}
