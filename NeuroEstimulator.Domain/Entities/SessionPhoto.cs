using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Domain.Entities
{
    public class SessionPhoto : AuditEntity<Guid>
    {
        public SessionPhoto() {
            SetId(Guid.NewGuid());
        }

        public Guid SessionId { get; private set; }
        public string Path { get; private set; }

        public virtual Session Session { get; private set; }
    }
}
