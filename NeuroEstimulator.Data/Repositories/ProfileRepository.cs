using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Factory;
using NeuroEstimulator.Framework.Database.EfCore.Repository;
using NeuroEstimulator.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroEstimulator.Data.Repositories;

public class ProfileRepository : RepositoryBase<Profile>, IProfileRepository
{
    public ProfileRepository(IDbFactory dbFactory, IApiContext apiContext) 
        : base(dbFactory, apiContext) { }

    public async Task<IList<Profile>> GetProfilesByRoleCode(string code)
    {
        var result = await GetAsync(x => x.Code == code);
        return result.ToList();
    }
}
