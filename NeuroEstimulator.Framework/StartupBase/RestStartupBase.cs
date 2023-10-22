using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Context;
using NeuroEstimulator.Framework.Security;
using NeuroEstimulator.Framework.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace NeuroEstimulator.Framework.StartupBase;

public static class RestStartupBase
{
    public static void ConfigureServices(IServiceCollection services, AssemblyName app)
    {
        //var app = PlatformServices.Default.Application;

        services.AddScoped(typeof(IApiContext), typeof(ApiContext));
        services.AddScoped(typeof(IJwtUtil), typeof(JwtUtil));

        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = app.Name, //app.ApplicationName,
                Version = app.Version.ToString()//app.ApplicationVersion
            });

            swagger.OperationFilter<SwaggerParameterAttributeFilter>();

            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
            });

            swagger.OperationFilter<SwaggerSecurityRequirementsOperationFilter>();
            

            foreach (var xmlFile in GetXmlCommentsFiles())
            {
                swagger.IncludeXmlComments(xmlFile);
            }
        });
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //var DefaultApp = PlatformServices.Default.Application;

        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", Assembly.GetExecutingAssembly().GetName().Name + " - " + env.EnvironmentName);
            c.DisplayRequestDuration();
            c.DefaultModelsExpandDepth(0);
        });

        var option = new RewriteOptions();
        option.AddRedirect("^$", "swagger");
        app.UseRewriter(option);
    }

    private static List<string> GetXmlCommentsFiles()
    {
        List<string> files = new List<string>();
        try
        {
            var baseDirectory = AppContext.BaseDirectory;
            foreach (var file in Directory.EnumerateFiles(baseDirectory, "*.xml"))
            {
                files.Add(file);
            }

            return files;
        }
        catch
        {
            return files;
        }
    }
}
