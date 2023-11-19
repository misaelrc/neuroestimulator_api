using NeuroEstimulator.Domain.Enumerators;
using NeuroEstimulator.Domain.Payloads;
using NeuroEstimulator.Framework.Database.EfCore.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuroEstimulator.Domain.Entities;

public class Session : AuditEntity<Guid>
{
    public Session()
    {
        
    }

    public Session(Guid therapistId, Guid patientId, SessionParameters parameters, int? sessionDuraton = null, int? repetitions = null)
    { 
        SetId(Guid.NewGuid());
        TherapistId = therapistId;
        PatientId = patientId;
        SessionDuration = sessionDuraton;
        Parameters = parameters;
        //Repetitions = repetitions;
        Status = SessionStatusEnum.NotStarted;
    }

    public Guid TherapistId { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid ParametersId { get; private set; }
    public double? StartWristAmplitudeMeasurement { get; private set; }
    public double? FinishWristAmplitudeMeasurement { get; private set; }
    public int? SessionDuration { get; private set; }
    //public int? Repetitions { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public SessionStatusEnum Status { get; private set; }

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
        Status = SessionStatusEnum.OnGoing;
    }
    public void Finish(double wristAmplitude)
    {
        FinishedAt = DateTime.Now;
        FinishWristAmplitudeMeasurement = wristAmplitude;
        Status = SessionStatusEnum.Finished;
    }

    public void Interrupt()
    {
        FinishedAt = DateTime.Now;
        Status = SessionStatusEnum.Interrupted;
    }

    public void AddPhoto(SessionPhoto photo) => Photos.Add(photo);
    public void AddStartWristAmplitudeMeasurement(double wristAmplitude) => StartWristAmplitudeMeasurement = wristAmplitude;

    [NotMapped]
    public int Repetitions
    {
        get { return Segments.Count; }
    }
}
