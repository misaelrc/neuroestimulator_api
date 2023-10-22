using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Factory;
using NeuroEstimulator.Framework.Database.EfCore.Repository;
using NeuroEstimulator.Framework.Interfaces;

namespace NeuroEstimulator.Data.Repositories;

public class SessionSegmentRepository : RepositoryBase<SessionSegment>, ISessionSegmentRepository
{
    public SessionSegmentRepository(IDbFactory dbFactory, IApiContext apiContext)
        : base(dbFactory, apiContext) { }
}
