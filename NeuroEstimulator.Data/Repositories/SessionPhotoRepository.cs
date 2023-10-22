using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Factory;
using NeuroEstimulator.Framework.Database.EfCore.Repository;
using NeuroEstimulator.Framework.Interfaces;

namespace NeuroEstimulator.Data.Repositories;

public class SessionPhotoRepository : RepositoryBase<SessionPhoto>, ISessionPhotoRepository
{
    public SessionPhotoRepository(IDbFactory dbFactory, IApiContext apiContext)
        : base(dbFactory, apiContext) { }

}
