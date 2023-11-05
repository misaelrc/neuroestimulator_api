using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities;

public class SessionParameters : AuditEntity<Guid>
{
    SessionParameters() { }

    public SessionParameters(double amplitude, double frequency, double pulseWidth, double pulseDuration, double difficulty)
    {
        SetId(Guid.NewGuid());
        Amplitude = amplitude;
        Frequency = frequency;
        PulseWidth = pulseWidth;
        PulseDuration = pulseDuration;
        Difficulty = difficulty;
    }

    public double Amplitude {get; private set; }
    public double Frequency {get; private set; }
    public double PulseWidth {get; private set; }
    public double PulseDuration { get; private set; }
    public double Difficulty { get; private set; }
}
