using AutoMapper;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.Service.Services;

public class SessionSegmentService : ServiceBase, ISessionSegmentService
{
    private readonly IMapper _mapper;

    public SessionSegmentService(
        IApiContext apiContext,
        IMapper mapper)
        : base(apiContext)
    {
        _mapper = mapper;
    }
}
