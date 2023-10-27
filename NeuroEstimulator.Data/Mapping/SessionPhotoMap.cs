using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroEstimulator.Domain.Entities;
using NeuroEstimulator.Framework.Database.EfCore.Mapping;

namespace NeuroEstimulator.Data.Mapping;

public class SessionPhotoMap : BaseAuditEntityMap<SessionPhoto, Guid>
{
    protected override void CreateModel(EntityTypeBuilder<SessionPhoto> builder)
    {
        builder.ToTable("SessionPhoto");

        builder
            .Property(b => b.SessionId)
            .IsRequired();

        builder
            .Property(b => b.Path)
            .HasColumnType("varchar(300)")
            .IsRequired();

       
        builder.HasOne(x => x.Session);
    }
}
