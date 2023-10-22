using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Framework.Database.EfCore.Mapping;

public abstract class BaseActiveEntityMap<TEntity, TKey> : BaseEntityMap<TEntity, TKey> where TEntity : ActiveEntity<TKey>
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder
            .Property(b => b.Active)
            .IsRequired();

        CreateModel(builder);
    }
}
