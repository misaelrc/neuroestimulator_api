using NeuroEstimulator.Framework.Database.EfCore.Model;
using System.ComponentModel;

namespace NeuroEstimulator.Domain.Entities;

public class AccountProfile : AuditEntity<Guid>
{
    public AccountProfile() { }
    public AccountProfile(Account account, Profile profile)
    {
        Account = account;
        Profile = profile;
        Activate();
    }

    public AccountProfile(Guid accountId, Guid profileId)
    {
        AccountId = accountId;
        ProfileId = profileId;
        Activate();
    }

    public Guid AccountId { get; set; }
    public Guid ProfileId { get; set; }

    [Description("ignore")]
    public virtual Account Account { get; set; }

    [Description("ignore")]
    public virtual Profile Profile { get; set; }
}
