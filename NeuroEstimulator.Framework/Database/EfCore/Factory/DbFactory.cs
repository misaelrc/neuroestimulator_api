using Microsoft.EntityFrameworkCore;
using NeuroEstimulator.Framework.Database.EfCore.Context;

namespace NeuroEstimulator.Framework.Database.EfCore.Factory;

public class DbFactory : IDbFactory
{
    private bool _disposed;
    private Func<IDatabaseContext> _instanceFunc;
    private DbContext _dbContext;

    public DbContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke().GetDbContext());

    public DbFactory(Func<IDatabaseContext> dbContextFactory)
    {
        _instanceFunc = dbContextFactory;
    }

    public void Dispose()
    {
        if (!_disposed && _dbContext != null)
        {
            _disposed = true;
            _dbContext.Dispose();
        }
    }
}
