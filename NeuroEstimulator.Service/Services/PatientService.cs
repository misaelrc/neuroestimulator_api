using AutoMapper;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.Service.Services;

public class PatientService : ServiceBase, IPatientService
{
    private readonly IMapper _mapper;
    public PatientService(
        IApiContext apiContext,
        IMapper mapper) 
        : base(apiContext)
    {
        _mapper = mapper;
    }
}
