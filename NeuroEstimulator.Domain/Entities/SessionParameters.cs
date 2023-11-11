using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities;

public class SessionParameters : AuditEntity<Guid>
{
    SessionParameters() { }

    public SessionParameters(double amplitude, double frequency, double stimulationTime, double? minPulseWidth = null, double? maxPulseWidth = null, double? pulseWidth = null)
    {
        SetId(Guid.NewGuid());
        Amplitude = amplitude;
        Frequency = frequency;
        PulseWidth = pulseWidth;
        MaxPulseWidth = maxPulseWidth;
        MinPulseWidth = minPulseWidth;
        StimulationTime = stimulationTime;
    }

    public double Amplitude {get; private set; }
    public double Frequency {get; private set; }
    public double? PulseWidth {get; private set; }
    public double? MaxPulseWidth {get; private set; }
    public double? MinPulseWidth {get; private set; }
    public double StimulationTime { get; private set; }//StimulationTime

    public void SetAmplitude(double amplitude) => Amplitude = amplitude;
    public void SetFrequency(double frequency) => Frequency = frequency;
    public void SetMaxPulseWidth(double? maxPulseWidth) => MaxPulseWidth = maxPulseWidth;
    public void SetMinPulseWidth(double? minPulseWidth) => MinPulseWidth = minPulseWidth;
    public void SetStimulationTime(double stimulationTime) => StimulationTime = stimulationTime;

}
