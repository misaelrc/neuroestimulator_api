using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Mapping;

namespace NeuroEstimulator.Data.Mapping;

public class SessionParametersMap : BaseAuditEntityMap<SessionParameters, Guid>
{
    protected override void CreateModel(EntityTypeBuilder<SessionParameters> builder)
    {
        builder.ToTable("SessionParameters");

        builder
            .Property(b => b.Amplitude)
            .IsRequired();

        builder
            .Property(b => b.Frequency)
            .IsRequired();
            
    }
}
