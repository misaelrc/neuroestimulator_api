using NeuroEstimulator.Domain.Enumerators;
using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities;

public class SessionSegment : AuditEntity<Guid>
{
    public SessionSegment(){}
    public SessionSegment(int difficulty, int intensity, SessionParameters parameters)
    {
        SetId(Guid.NewGuid());
        Difficulty = difficulty;
        Intensity = intensity;
        UsedParameters = parameters;
    }

    public Guid SessionId { get; private set; }
    public Guid UsedParametersId { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public int Intensity { get; private set; }
    public int Difficulty { get; private set; }
    public virtual Session Session { get; private set; }
    public virtual SessionParameters UsedParameters { get; private set; }
}
