using NeuroEstimulator.Domain.Entities;

namespace NeuroEstimulator.Domain.Payloads;

public class CreateSessionPayload
{
    public Guid PatientId { get; set; }

    public int? SessionDuration { get; set; }
    public int? Repetitions { get; set; }
}
