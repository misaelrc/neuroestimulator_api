using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Mapping;

namespace NeuroEstimulator.Data.Mapping;

public class SessionSegmentMap : BaseAuditEntityMap<SessionSegment, Guid>
{
    protected override void CreateModel(EntityTypeBuilder<SessionSegment> builder)
    {
        builder.ToTable("SessionSegment");

        builder
            .Property(b => b.SessionId)
            .IsRequired();

        builder
            .Property(b => b.UsedParametersId)
            .IsRequired();

        builder
            .Property(b => b.StartedAt)
            .IsRequired();

        builder
            .Property(b => b.FinishedAt)
            .IsRequired(false);

        builder
             .Property(b => b.Status)
             .IsRequired();

        builder
            .Property(b => b.WristAmplitudeMeasurement)
            .IsRequired(false);

        builder.HasOne(x => x.UsedParameters);
        builder.HasOne(x => x.Session);
    }
}
