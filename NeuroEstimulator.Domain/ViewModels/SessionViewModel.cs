using NeuroEstimulator.Domain.Entities;

namespace NeuroEstimulator.Domain.ViewModels;

public class SessionViewModel
{
    public Guid Id { get; set; }
    public Guid TherapistId { get; set; }
    public Guid PatientId { get; set; }
    public Guid ParametersId { get; set; }
    public SessionParametersViewModel Parameters { get; set; }
    public ICollection<SessionPhotoViewModel> Photos { get; set; }
    public ICollection<SessionSegment> Segments { get; set; }
    public double? StartWristAmplitudeMeasurement { get; set; }
    public double? FinishWristAmplitudeMeasurement { get; set; }
    public int SessionDuration { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }


    //public virtual Account Therapist { get; set; }
    //public virtual Patient Patient { get; set; }
    //public virtual SessionParameters Parameters { get; set; }
    //public virtual ICollection<SessionSegment> Segments { get; set; }
    //public virtual ICollection<SessionPhoto> Photos { get; set; } 
}
