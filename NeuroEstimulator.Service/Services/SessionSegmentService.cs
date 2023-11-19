using AutoMapper;
using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Domain.Enumerators;
using NeuroEstimulator.Domain.ViewModels;
using NeuroEstimulator.Framework.Database.EfCore.Interface;
using NeuroEstimulator.Framework.Exceptions;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.Service.Services;

public class SessionSegmentService : ServiceBase, ISessionSegmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ISessionSegmentRepository _sessionSegmentRepository;

    public SessionSegmentService(
        IApiContext apiContext,
        IUnitOfWork unitOfWork,
        ISessionSegmentRepository sessionSegmentRepository,
        IMapper mapper)
        : base(apiContext)
    {
        _mapper = mapper;
        _sessionSegmentRepository = sessionSegmentRepository;
        _unitOfWork = unitOfWork;
    }

    public SessionSegmentViewModel SetSmgDetected(Guid id)
    {
        var segment = Task.Run(() => _sessionSegmentRepository.GetAsync(s => s.Id == id, includeProperties: "UsedParameters")).Result.FirstOrDefault();

        if (segment is null) throw new BadRequestException(SegmentErrors.SegmentNotFound);
        segment.SetSmgDetected(true);

        _sessionSegmentRepository.Update(segment);

        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        if (result)
        {
            var model = _mapper.Map<SessionSegmentViewModel>(segment);
            return model;
        }
        else
        {
            throw new InternalException(SegmentErrors.ErrorOnSetSmgDetected);
        }
    }

    public SessionSegmentViewModel SetEmergency(Guid id)
    {
        var segment = Task.Run(() => _sessionSegmentRepository.GetAsync(s => s.Id == id, includeProperties: "UsedParameters")).Result.FirstOrDefault();

        if (segment is null) throw new BadRequestException(SegmentErrors.SegmentNotFound);
        segment.SetEmergency(true);

        _sessionSegmentRepository.Update(segment);

        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        if (result)
        {
            var model = _mapper.Map<SessionSegmentViewModel>(segment);
            return model;
        }
        else
        {
            throw new InternalException(SegmentErrors.ErrorOnSetSmgDetected);
        }
    }
}
