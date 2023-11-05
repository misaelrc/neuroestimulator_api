using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.Interfaces;

public interface ISessionService 
{
    Session GetSessionById(Guid sessionId);
    bool CreateSession(CreateSessionPayload payload);
    void SetParameters(Guid sessionId, SessionParametersPayload parameters);
    SessionParameters GetParameters(Guid sessionId);
    bool Start(WristAmplitudePayload payload);
    bool Finish(WristAmplitudePayload payload);
    void AddPhoto(Guid sessionId, SessionPhoto photo);
    IList<SessionViewModel> GetSessionsByPatient(Guid patientId);
    SessionSegment GetCurrentSessionSegment(Guid sessionId);
    IList<SessionPhoto> GetPhotos(Guid sessionId);
}
