using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Factory;
using NeuroEstimulator.Framework.Database.EfCore.Repository;
using NeuroEstimulator.Framework.Interfaces;

namespace NeuroEstimulator.Data.Repositories;

public class AccountProfileRepository : RepositoryBase<AccountProfile>, IAccountProfileRepository
{
    public AccountProfileRepository(IDbFactory dbFactory, IApiContext apiContext)
        : base(dbFactory, apiContext){ }

    public async Task<IList<AccountProfile>> GetAccountProfiles(Guid accountId)
    {
        var result = await GetAsync(x => x.AccountId == accountId, includeProperties: "Profile");
        return result.ToList();
    }

    public async Task<IList<AccountProfile>> GetByProfileId(Guid profileId)
    {
        var result = await GetAsync(x => x.ProfileId == profileId, includeProperties: "Profile");
        return result.ToList();
    }
}
