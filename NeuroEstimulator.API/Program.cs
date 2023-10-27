using NeuroEstimulator.API.Config;
using NeuroEstimulator.Framework.StartupBase;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

RestStartupBase.ConfigureServices(builder.Services, Assembly.GetExecutingAssembly().GetName());
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddCorsConfiguration(builder.Configuration);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddAutoMapperConfiguration();

builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddMemoryCache();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();  
var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

RestStartupBase.Configure(app, app.Environment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
