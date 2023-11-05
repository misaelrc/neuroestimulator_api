using NeuroEstimulator.Domain.Entities;

namespace NeuroEstimulator.Domain.Payloads;

public class CreateSessionPayload
{
    public Guid TherapistId { get; set; }
    public Guid PatientId { get; set; }

    public double Amplitude { get; set; }
    public double Frequency { get; set; }
    public double PulseWidth { get; set; }
    public double PulseDuration { get; set; }
    public double Difficulty { get; set; }

    public int SessionDuration { get; set; }
}
