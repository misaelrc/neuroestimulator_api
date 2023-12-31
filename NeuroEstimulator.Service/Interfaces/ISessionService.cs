﻿using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.Interfaces;

public interface ISessionService 
{
    SessionViewModel GetSessionById(Guid sessionId);
    SessionViewModel PatientCreateSession(PatientCreateSessionPayload payload);
    SessionViewModel TherapistCreateSession(TherapistCreateSessionPayload payload);
    void SetParameters(Guid sessionId, SessionParametersPayload parameters);
    SessionParameters GetParameters(Guid sessionId);
    bool Start(WristAmplitudePayload payload);
    bool Finish(WristAmplitudePayload payload);
    bool AddPhoto(SessionPhotoPayload payload);
    IList<SessionViewModel> GetSessionsByPatient(Guid patientId);
    IList<SessionPhotoViewModel> GetPhotos(Guid sessionId);

    IList<ListSessionViewModel> GetSessionsByPatientId(Guid patientId);
    SessionSegmentViewModel AddSegment(SessionSegmentPayload payload);
}
