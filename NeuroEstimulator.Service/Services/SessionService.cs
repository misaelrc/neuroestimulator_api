using AutoMapper;
using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Data.Repositories;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;
using NeuroEstimulator.Framework.Database.EfCore.Interface;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;

namespace NeuroEstimulator.Service.Services;

public class SessionService : ServiceBase, ISessionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISessionRepository _sessionRepository;
    private readonly IMapper _mapper;

    public SessionService(
        IApiContext apiContext,
        IUnitOfWork unitOfWork,
        ISessionRepository sessionRepository,
        IMapper mapper)
        : base(apiContext)
    {
        _mapper = mapper;
        _sessionRepository = sessionRepository;
        _unitOfWork = unitOfWork;
    }
    
    public bool CreateSession(CreateSessionPayload payload)
    {
        var parameters = new SessionParameters(payload.Amplitude, payload.Frequency, payload.PulseWidth, payload.PulseDuration, payload.Difficulty);
        var session = new Session(payload.TherapistId, payload.PatientId, payload.SessionDuration, parameters);

        _sessionRepository.Add(session);

        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        return result;
    }

    public void SetParameters(Guid sessionId, SessionParametersPayload payload)
    {
        var session = Task.Run(() => _sessionRepository.GetAsync(s => s.Id == sessionId, includeProperties: "Parameters")).Result.FirstOrDefault();
        var parameters = new SessionParameters(payload.Amplitude, payload.Frequency, payload.PulseWidth, payload.PulseDuration, payload.Difficulty);
        session.SetParameters(parameters);

        Task.Run(() => _unitOfWork.CommitAsync());
    }

    public SessionParameters GetParameters(Guid sessionId)
    {
        var result = Task.Run(() => _sessionRepository.GetAsync(s => s.Id == sessionId, includeProperties: "Parameters")).Result.FirstOrDefault();
        return result.Parameters;
    }

    public bool Start(WristAmplitudePayload payload)
    {
        var session = Task.Run(() => _sessionRepository.GetByIdAsync(payload.SessionId)).Result;
        session.Start(payload.WristAmplitudeMeasurement);

        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        return result;
    }

    public bool Finish(WristAmplitudePayload payload)
    {
        var session = Task.Run(() => _sessionRepository.GetByIdAsync(payload.SessionId)).Result;
        session.Finish(payload.WristAmplitudeMeasurement);

        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        return result;
    }

    public void AddPhoto(Guid sessionId, SessionPhoto photo)
    {
        throw new NotImplementedException();
    }

    public Session GetSessionById(Guid sessionId) {
        var result = Task.Run(() => _sessionRepository.GetByIdAsync(sessionId, x => x.Parameters, x => x.Patient)).Result;
        return result;
    }
    public IList<SessionViewModel> GetSessionsByPatient(Guid patientId)
    {
        var result = Task.Run(() => _sessionRepository.GetAsync(s => s.PatientId == patientId, includeProperties: "Parameters")).Result;
        var model = _mapper.Map<List<SessionViewModel>>(result);
        return model;
    }

    public SessionSegment GetCurrentSessionSegment(Guid sessionId)
    {
        throw new NotImplementedException();
    }

    public IList<SessionPhoto> GetPhotos(Guid sessionId)
    {
        throw new NotImplementedException();
    }



    

    
}
