using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.Interfaces;

public interface ISessionService 
{
    Session GetSessionById(Guid sessionId);
    SessionViewModel CreateSession(CreateSessionPayload payload); 
    bool AddSessionSegment(SessionSegmentPayload payload);
    void SetParameters(Guid sessionId, SessionParametersPayload parameters);
    SessionParameters GetParameters(Guid sessionId);
    bool Start(WristAmplitudePayload payload);
    bool Finish(WristAmplitudePayload payload);
    bool AddPhoto(SessionPhotoPayload payload);
    IList<SessionViewModel> GetSessionsByPatient(Guid patientId);
    IList<SessionPhotoViewModel> GetPhotos(Guid sessionId);

    IList<ListSessionViewModel> GetSessionsByPatientId(Guid patientId);
}
