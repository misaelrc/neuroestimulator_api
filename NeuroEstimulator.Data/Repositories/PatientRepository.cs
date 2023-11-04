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

public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
{
    public PatientRepository(IDbFactory dbFactory, IApiContext apiContext) 
        : base(dbFactory, apiContext) { }
}
