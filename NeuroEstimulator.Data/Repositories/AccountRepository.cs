using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Factory;
using NeuroEstimulator.Framework.Database.EfCore.Repository;
using NeuroEstimulator.Framework.Interfaces;

namespace NeuroEstimulator.Data.Repositories;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(IDbFactory dbFactory, IApiContext apiContext)
        : base(dbFactory, apiContext) { }

    public async Task<Account> GetByLogin(string login)
    {
        var result = await GetAsync(x => x.Login == login, includeProperties: "");

        return result.FirstOrDefault();
    }
}
