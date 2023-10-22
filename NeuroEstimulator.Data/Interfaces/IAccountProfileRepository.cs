using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Interface;

namespace NeuroEstimulator.Data.Interfaces; 
public interface IAccountProfileRepository : IRepositoryBase<AccountProfile>
{
    Task<IList<AccountProfile>> GetAccountProfiles(Guid accountId);
    Task<IList<AccountProfile>> GetByProfileId(Guid profileId);
}
