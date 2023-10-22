using AutoMapper;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.Service.Services;

public class SessionParametersService : ServiceBase, ISessionParametersService
{
    private readonly IMapper _mapper;

    public SessionParametersService(
        IApiContext apiContext,
        IMapper mapper)
        : base(apiContext)
    {
        _mapper = mapper;
    }
}
