using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities;

public class SessionParameters : AuditEntity<Guid>
{
    SessionParameters()
    {
        SetId(Guid.NewGuid());
    }

    public double Amplitude {get; private set; }
    public double Frequency {get; private set; }
    public double PulseWidth {get; private set; }
    public double PulseDuration { get; private set; }
    public double Difficulty { get; private set; }
}
