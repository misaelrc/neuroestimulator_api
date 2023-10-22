using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities;

public class SessionSegment : AuditEntity<Guid>
{
    public SessionSegment()
    {
        SetId(Guid.NewGuid());
    }
    public Guid SessionId { get; private set; }
    public Guid ParametersId { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime FinishedAt { get; private set; }
    public double WristAmplitudeMeasurement { get; private set; }
    public virtual Session Session { get; private set; }
    public virtual SessionParameters UsedParameters { get; private set; }
}
