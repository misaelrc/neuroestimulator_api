using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Mapping;

namespace NeuroEstimulator.Data.Mapping;

internal class ProfileMap : BaseAuditEntityMap<Profile, Guid>
{
    protected override void CreateModel(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("Profile");

        builder
            .Property(b => b.Name)
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder
            .Property(b => b.Code)
            .HasColumnType("varchar(80)")
            .IsRequired();
    }
}
