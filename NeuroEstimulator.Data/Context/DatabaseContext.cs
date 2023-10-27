using Microsoft.EntityFrameworkCore;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Context;
using NeuroEstimulator.Framework.Database.EfCore.Model;
using System.Diagnostics;
using System.Reflection;

namespace NeuroEstimulator.Data.Context;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    public DbContext GetDbContext() => this;

    public DbSet<AccountProfile> AccountProfile { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<Profile> Profile { get; set; }
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Session> Session { get; set; }
    public DbSet<SessionParameters> SessionParameters { get; set; }
    public DbSet<SessionPhoto> SessionPhoto { get; set; }
    public DbSet<SessionSegment> SessionSegment { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            foreach (var entity in ChangeTracker
                .Entries()
                .Where(x => x.Entity is AuditEntity<Guid> && x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .Cast<AuditEntity<Guid>>())
            {
                entity.UpdateDate = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException updateConcurrencyException)
        {
            Debug.Print("DbUpdateConcurrencyException");
            Debug.Print(updateConcurrencyException.InnerException.Message);
            throw updateConcurrencyException;
        }
        catch (DbUpdateException updateException)
        {
            Debug.Print("DbUpdateException");
            Debug.Print(updateException.InnerException.Message);
            throw updateException;
        }
    }
}
