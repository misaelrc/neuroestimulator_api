using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Interface;

namespace NeuroEstimulator.Data.Interfaces;

public interface IAccountRepository : IRepositoryBase<Account>
{
    Task<Account> GetByLogin(string login);
}
