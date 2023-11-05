namespace NeuroEstimulator.Domain.Payloads;

public class SessionParametersPayload
{
    public double Amplitude { get; set; }
    public double Frequency { get; set; }
    public double PulseWidth { get; set; }
    public double PulseDuration { get; set; }
    public double Difficulty { get; set; }
}
