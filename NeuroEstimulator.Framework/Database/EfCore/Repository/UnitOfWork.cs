using NeuroEstimulator.Framework.Database.EfCore.Factory;
using NeuroEstimulator.Framework.Database.EfCore.Interface;

namespace NeuroEstimulator.Framework.Database.EfCore.Repository;

public class UnitOfWork : IUnitOfWork
{
    private IDbFactory _dbFactory;

    public UnitOfWork(IDbFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> CommitAsync()
    {
        var success = await _dbFactory.DbContext.SaveChangesAsync() > 0;
        return success;
    }
}
