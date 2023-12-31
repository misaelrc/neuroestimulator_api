﻿using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Interface;

namespace NeuroEstimulator.Data.Interfaces;

public interface IPatientRepository : IRepositoryBase<Patient>
{
    Task<Patient?> GetByIdAsync(Guid id);
}
