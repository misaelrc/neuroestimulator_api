using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Interface;

namespace NeuroEstimulator.Data.Interfaces;

public interface IProfileRepository : IRepositoryBase<Profile>
{
    Task<IList<Profile>> GetProfilesByRoleCode(string code);
}
