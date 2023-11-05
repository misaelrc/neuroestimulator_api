using NeuroEstimulator.Domain.Enumerators;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities;

public class Session : AuditEntity<Guid>
{
    public Session()
    {
        
    }

    public Session(Guid therapistId, Guid patientId, int sessionDuraton, SessionParameters parameters)
    { 
        SetId(Guid.NewGuid());
        TherapistId = therapistId;
        PatientId = patientId;
        SessionDuration = sessionDuraton;
        Parameters = parameters;
    }

    public Guid TherapistId { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid ParametersId { get; private set; }
    public double? StartWristAmplitudeMeasurement { get; private set; }
    public double? FinishWristAmplitudeMeasurement { get; private set; }
    public int SessionDuration { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }


    public virtual Account Therapist { get; private set; }
    public virtual Patient Patient { get; private set; }
    public virtual SessionParameters Parameters { get; private set; }
    public virtual ICollection<SessionSegment> Segments { get; private set; } = new List<SessionSegment>();
    public virtual ICollection<SessionPhoto> Photos { get; private set; } = new List<SessionPhoto>();

    

    public void SetParameters(SessionParameters parameters) => Parameters = parameters;
    public void Start(double wristAmplitude)
    {
        StartedAt = DateTime.Now;
        StartWristAmplitudeMeasurement = wristAmplitude;
    }
    public void Finish(double wristAmplitude)
    {
        FinishedAt = DateTime.Now;
        FinishWristAmplitudeMeasurement = wristAmplitude;
    }
    public void AddPhoto(SessionPhoto photo) => Photos.Add(photo);
}
