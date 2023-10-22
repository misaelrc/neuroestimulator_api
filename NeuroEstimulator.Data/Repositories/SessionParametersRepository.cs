using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Factory;
using NeuroEstimulator.Framework.Database.EfCore.Repository;
using NeuroEstimulator.Framework.Interfaces;

namespace NeuroEstimulator.Data.Repositories;

public class SessionParametersRepository : RepositoryBase<SessionParameters>, ISessionParametersRepository
{
    public SessionParametersRepository(IDbFactory dbFactory, IApiContext apiContext)
        : base(dbFactory, apiContext) { }

}
