using AutoMapper;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.Service.Services;

public class SessionPhotoService : ServiceBase, ISessionPhotoService
{
    private readonly IMapper _mapper;

    public SessionPhotoService(
        IApiContext apiContext,
        IMapper mapper)
        : base(apiContext)
    {
        _mapper = mapper;
    }
}
