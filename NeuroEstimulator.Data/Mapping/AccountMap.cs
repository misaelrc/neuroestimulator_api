using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Mapping;

namespace NeuroEstimulator.Data.Mapping;

public class AccountMap : BaseAuditEntityMap<Account, Guid>
{
    protected override void CreateModel(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account");

        builder
             .Property(b => b.Login)
             .HasColumnType("varchar(500)")
             .IsRequired();

        builder
             .Property(b => b.Name)
             .HasColumnType("varchar(150)")
             .IsRequired();
    }
}
