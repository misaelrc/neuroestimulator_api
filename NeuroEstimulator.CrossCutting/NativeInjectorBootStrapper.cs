using Microsoft.Extensions.DependencyInjection;
using NeuroEstimulator.Data.Context;
using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Data.Repositories;
using NeuroEstimulator.Framework.Database.EfCore.Context;
using NeuroEstimulator.Framework.Database.EfCore.Factory;
using NeuroEstimulator.Framework.Database.EfCore.Interface;
using NeuroEstimulator.Framework.Database.EfCore.Repository;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Service.Interfaces;
using NeuroEstimulator.Service.Services;

namespace NeuroEstimulator.CrossCutting;

public class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        //services.AddTransient<IApiClient, ApiClient>();
        AddServices(services);
        AddDatabase(services);
        AddRepositories(services);
    }

    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IAccountProfileService, AccountProfileService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<ISessionParametersService, SessionParametersService>();
        services.AddScoped<ISessionPhotoService, SessionPhotoService>();
        services.AddScoped<ISessionSegmentService, SessionSegmentService>();
        services.AddScoped<ISessionService, SessionService>();
    }

    public static void AddDatabase(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDatabaseContext, DatabaseContext>();
        services.AddScoped<Func<IDatabaseContext>>((provider) => () => provider.GetService<DatabaseContext>());
        services.AddScoped<IDbFactory, DbFactory>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        services.AddScoped<IAccountProfileRepository, AccountProfileRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<ISessionParametersRepository, SessionParametersRepository>();
        services.AddScoped<ISessionPhotoRepository, SessionPhotoRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<ISessionSegmentRepository, SessionSegmentRepository>();
    }
}
