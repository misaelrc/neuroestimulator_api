using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeuroEstimulator.Framework.Database.EfCore.Model;

namespace NeuroEstimulator.Framework.Database.EfCore.Mapping;

public abstract class BaseEntityMap<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey>
{
    protected abstract void CreateModel(EntityTypeBuilder<TEntity> builder);

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(b => b.Id)
            .IsRequired();

        CreateModel(builder);
    }
}
