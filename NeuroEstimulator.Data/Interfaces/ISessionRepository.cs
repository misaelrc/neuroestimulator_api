using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Interface;

namespace NeuroEstimulator.Data.Interfaces;

public interface ISessionRepository : IRepositoryBase<Session>
{
    Task<Session?> GetByIdAsync(Guid id);
}
