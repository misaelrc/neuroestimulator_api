using AutoMapper;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.Service.Services;

public class SessionService : ServiceBase, ISessionService
{
    private readonly IMapper _mapper;

    public SessionService(
        IApiContext apiContext,
        IMapper mapper)
        : base(apiContext)
    {
        _mapper = mapper;
    }
}
