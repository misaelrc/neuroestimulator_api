namespace NeuroEstimulator.Domain.Payloads;

public class WristAmplitudePayload
{
    public Guid SessionId { get; set; }
    public double WristAmplitudeMeasurement { get; set; }
}
