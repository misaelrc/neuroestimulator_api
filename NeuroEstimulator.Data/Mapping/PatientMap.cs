using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Mapping;

namespace NeuroEstimulator.Data.Mapping;

public class PatientMap : BaseAuditEntityMap<Patient, Guid>
{
    protected override void CreateModel(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patient");

        builder
            .Property(b => b.AccountId)
            .IsRequired();

        builder
            .Property(b => b.BirthDate)
            .HasColumnType("date")
            .IsRequired();

        builder
            .Property(b => b.SessionAllowed)
            .HasDefaultValue(false);

        builder.HasOne(x => x.Account);
    }
}
