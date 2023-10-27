using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Mapping;

namespace NeuroEstimulator.Data.Mapping;

public class SessionMap : BaseAuditEntityMap<Session, Guid>
{
    protected override void CreateModel(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Session");

        builder
            .Property(b => b.TherapistId)
            .IsRequired();

        builder
            .Property(b => b.PatientId)
            .IsRequired();

        builder
            .Property(b => b.ParametersId)
            .IsRequired();

        builder.HasOne(x => x.Therapist);
        builder.HasOne(x => x.Patient);
        builder.HasOne(x => x.Parameters);

        builder
            .HasMany(x => x.Segments)
            .WithOne(x => x.Session)
            .HasForeignKey(x => x.SessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(x => x.Photos)
            .WithOne(x => x.Session)
            .HasForeignKey(x => x.SessionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
