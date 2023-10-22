using Microsoft.EntityFrameworkCore;

namespace NeuroEstimulator.Framework.Database.EfCore.Factory;

public interface IDbFactory : IDisposable
{
    public DbContext DbContext { get; }
}
