﻿using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Factory;
using NeuroEstimulator.Framework.Database.EfCore.Repository;
using NeuroEstimulator.Framework.Interfaces;

namespace NeuroEstimulator.Data.Repositories;

public class SessionRepository : RepositoryBase<Session>, ISessionRepository
{
    public SessionRepository(IDbFactory dbFactory, IApiContext apiContext) 
        : base(dbFactory, apiContext) { }

    new public async Task<Session?> GetByIdAsync(Guid id)
    {
        var result = await GetAsync(x => x.Id == id, includeProperties: "Parameters,Segments,Photos");
        return result.FirstOrDefault();
    }
}
