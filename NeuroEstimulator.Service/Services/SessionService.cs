using AutoMapper;
using Microsoft.AspNetCore.Builder;
using NeuroEstimulator.Data.Interfaces;
using NeuroEstimulator.Data.Repositories;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Domain.Enumerators;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;
using NeuroEstimulator.Framework.Database.EfCore.Interface;
using NeuroEstimulator.Framework.Exceptions;
using NeuroEstimulator.Framework.Interfaces;
using NeuroEstimulator.Framework.Services;
using NeuroEstimulator.Service.Interfaces;
using System.Reflection.Metadata;

namespace NeuroEstimulator.Service.Services;

public class SessionService : ServiceBase, ISessionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISessionRepository _sessionRepository;
    private readonly ISessionSegmentRepository _sessionSegmentRepository;
    private readonly ISessionPhotoRepository _sessionPhotoRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly FileService _fileService;

    public SessionService(
        IApiContext apiContext,
        IUnitOfWork unitOfWork,
        ISessionRepository sessionRepository,
        ISessionSegmentRepository sessionSegmentRepository,
        ISessionPhotoRepository sessionPhotoRepository,
        IPatientRepository patientRepository,
        IMapper mapper,
        FileService fileService)
        : base(apiContext)
    {
        _mapper = mapper;
        _sessionRepository = sessionRepository;
        _sessionSegmentRepository = sessionSegmentRepository;
        _sessionPhotoRepository = sessionPhotoRepository;
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }
    
    public SessionViewModel PatientCreateSession(PatientCreateSessionPayload payload)
    {
        var patient = Task.Run(() => _patientRepository.GetByIdAsync(payload.PatientId)).Result;
        if (patient is null) throw new BadRequestException(PatientErrors.PatientNotFound);

        var referenceParameters = patient.Parameters;
        if (referenceParameters is null) throw new BadRequestException(PatientErrors.PatientWithoutParameters);
        var parameters = new SessionParameters(
            referenceParameters.Amplitude,
            referenceParameters.Frequency,
            referenceParameters.StimulationTime,
            referenceParameters.MinPulseWidth,
            referenceParameters.MaxPulseWidth,
            referenceParameters.PulseWidth);

        var session = new Session(patient.TherapistId, payload.PatientId, parameters);

        // adicionar fotos
        var uris = Task.Run(() => _fileService.UploadFilesAsync(payload.Files)).Result;

        // salvar caminhos no 
        foreach ( var uri in uris )
        {
            session.AddPhoto(new SessionPhoto(uri));
        }

        _sessionRepository.Add(session);
        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        if (result)
        {
            var model = _mapper.Map<SessionViewModel>(session);
            return model;
        }
        else
        {
            throw new InternalException(SessionErrors.ErrorOnCreateSession);
        }
    }

    public SessionViewModel TherapistCreateSession(TherapistCreateSessionPayload payload)
    {
        var patient = Task.Run(() => _patientRepository.GetByIdAsync(payload.PatientId)).Result;
        if (patient is null) throw new BadRequestException(PatientErrors.PatientNotFound);

        var referenceParameters = patient.Parameters;
        if (referenceParameters is null) throw new BadRequestException(PatientErrors.PatientWithoutParameters);
        var parameters = new SessionParameters(
            referenceParameters.Amplitude,
            referenceParameters.Frequency,
            referenceParameters.StimulationTime,
            referenceParameters.MinPulseWidth,
            referenceParameters.MaxPulseWidth,
            referenceParameters.PulseWidth);

        var session = new Session(patient.TherapistId, payload.PatientId, parameters);

        session.Start(payload.WristAmplitudeMeasurement);


        _sessionRepository.Add(session);
        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        if (result)
        {
            var model = _mapper.Map<SessionViewModel>(session);
            return model;
        }
        else
        {
            throw new InternalException(SessionErrors.ErrorOnCreateSession);
        }
    }

    public void SetParameters(Guid sessionId, SessionParametersPayload payload)
    {
        var session = Task.Run(() => _sessionRepository.GetAsync(s => s.Id == sessionId, includeProperties: "Parameters")).Result.FirstOrDefault();
        var parameters = new SessionParameters(payload.Amplitude, payload.Frequency, payload.StimulationTime, payload.MaxPulseWidth, payload.MinPulseWidth);
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

    public bool AddPhoto(SessionPhotoPayload payload)
    {
        //adicionar a foto no store
        var blob = Task.Run(() =>
            _fileService.UploadAsync(payload.File, payload.SessionId.ToString() + $"{DateTime.Now:yyyyMMddTHHmmss}")
        ).Result;

        //_sessionPhotoRepository.Add(new SessionPhoto(payload.SessionId, blob.Item1));
     
        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        return result;
    }

    public SessionViewModel GetSessionById(Guid sessionId) {
        var result = Task.Run(() => _sessionRepository.GetByIdAsync(sessionId)).Result;

        if (result != null)
        {
            var model = _mapper.Map<SessionViewModel>(result);
            return model;
        }
        else
        {
            throw new InternalException();//TODO - Arrumar o erro
        }
    }
    public IList<SessionViewModel> GetSessionsByPatient(Guid patientId)
    {
        var result = Task.Run(() => _sessionRepository.GetAsync(s => s.PatientId == patientId, includeProperties: "Parameters")).Result;
        var model = _mapper.Map<List<SessionViewModel>>(result);
        return model;
    }

    public IList<SessionPhotoViewModel> GetPhotos(Guid sessionId)
    {
        var result = Task.Run(() => _sessionPhotoRepository.GetAsync(x => x.SessionId == sessionId)).Result;

        var model = _mapper.Map<List<SessionPhotoViewModel>>(result);
        return model;
    }

    public IList<ListSessionViewModel> GetSessionsByPatientId(Guid patientId)
    {
        var result = Task.Run(() => _sessionRepository.GetAsync(x => x.PatientId == patientId, orderBy: x => x.OrderBy(s => s.CreationDate))).Result;

        var model = _mapper.Map<List<ListSessionViewModel>>(result);
        return model;
    }

    public SessionSegmentViewModel AddSegment(SessionSegmentPayload payload)
    {
        var session = Task.Run(() => _sessionRepository.GetByIdAsync(payload.SessionId)).Result;
        if (session is null) throw new BadRequestException(SessionErrors.SessionNotFound);

        var segment = new SessionSegment(payload.Difficulty, payload.Intensity);
        
        session.AddSegment(segment);

        _sessionRepository.Update(session);

        var result = Task.Run(() => _unitOfWork.CommitAsync()).Result;
        if (result)
        {
            var model = _mapper.Map<SessionSegmentViewModel>(session);
            return model;
        }
        else
        {
            throw new InternalException(SessionErrors.ErrorOnAddSegment);
        }
    }
}
