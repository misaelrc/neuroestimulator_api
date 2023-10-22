using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities;

public class Patient : AuditEntity<Guid>
{
    public Patient() { 
        SetId(Guid.NewGuid());
    }
    public Guid AccountId { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool SessionAllowed { get; private set; }

    public virtual Account Account { get; private set; }
}
