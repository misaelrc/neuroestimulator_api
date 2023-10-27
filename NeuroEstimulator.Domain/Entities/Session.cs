using NeuroEstimulator.Domain.Enumerators;
using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities;

public class Session : AuditEntity<Guid>
{
    public Session()
    {
        SetId(Guid.NewGuid());
    }

    public Guid TherapistId { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid ParametersId { get; private set; }
    

    public virtual Account Therapist { get; private set; }
    public virtual Patient Patient { get; private set; }
    public virtual SessionParameters Parameters { get; private set; }
    public virtual ICollection<SessionSegment> Segments { get; private set; } = new List<SessionSegment>();
    public virtual ICollection<SessionPhoto> Photos { get; private set; } = new List<SessionPhoto>();

}
