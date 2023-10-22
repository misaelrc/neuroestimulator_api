using NeuroEstimulator.Framework.Database.EfCore.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NeuroEstimulator.Framework.Database.EfCore.Model;

public abstract class AuditEntity<TKey> : ActiveEntity<TKey>, IAuditEntity<TKey>
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreationDate { get; private set; } = DateTime.Now;

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }
}
