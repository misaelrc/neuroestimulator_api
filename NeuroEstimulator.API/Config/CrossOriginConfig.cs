using Newtonsoft.Json;

namespace NeuroEstimulator.API.Config;

public static class CrossOriginConfig
{
    const string MyAllowSpecificOrigins = "allowOrigins";

    public static void AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        var allowOrigins = JsonConvert.DeserializeObject<string[]>(configuration.GetValue<string>("NeuroEstimulatorService:Cors:AllowOrigins"));

        services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
            {
                builder/*.WithOrigins(allowOrigins)*/
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }

    public static void UseCorsConfig(this IApplicationBuilder app)
    {
        app.UseCors(MyAllowSpecificOrigins);
    }
}
