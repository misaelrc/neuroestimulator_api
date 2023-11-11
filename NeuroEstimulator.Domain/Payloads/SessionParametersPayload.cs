namespace NeuroEstimulator.Domain.Payloads;

public class SessionParametersPayload
{
    public Guid PatientId { get; set; }
    public double Amplitude { get; set; }
    public double Frequency { get; set; }
    public double MaxPulseWidth { get; set; }
    public double MinPulseWidth { get; set; }
    public double StimulationTime { get; set; }
}
