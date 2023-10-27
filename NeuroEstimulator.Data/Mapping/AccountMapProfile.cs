using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Mapping;

namespace NeuroEstimulator.Data.Mapping;

public class AccountMapProfile : BaseAuditEntityMap<AccountProfile, Guid>
{
    protected override void CreateModel(EntityTypeBuilder<AccountProfile> builder)
    {
        builder.ToTable("AccountProfile");

        builder
            .Property(b => b.AccountId)
            .IsRequired();

        builder
            .Property(b => b.ProfileId)
            .IsRequired();

        builder.HasOne(x => x.Account);
        builder.HasOne(x => x.Profile);
    }
}
