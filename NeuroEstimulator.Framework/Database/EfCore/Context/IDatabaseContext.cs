using Microsoft.EntityFrameworkCore;

namespace NeuroEstimulator.Framework.Database.EfCore.Context;

public interface IDatabaseContext
{
    DbContext GetDbContext();
}
