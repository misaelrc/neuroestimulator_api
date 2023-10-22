using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities;

public class Profile : AuditEntity<Guid>
{
    protected Profile() { }

    public Profile(string name, string code)
    {
        SetId(Guid.NewGuid());
        this.Name = name;
        this.Code = code;
    }

    public string Name { get; private set; }
    public string Code { get; private set; }
}
