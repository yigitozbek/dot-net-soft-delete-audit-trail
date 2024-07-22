using WebAPI.Interfaces;

namespace WebAPI.Base;

public class FullyAuditedEntity<TKey> : Entity<TKey>, 
    IFullyAuditedEntity, 
    IEntity<TKey>, 
    IEntityBase,
    ISoftDelete
    where TKey : struct
{
    public FullyAuditedEntity(TKey id) : base(id)
    {
    }

    protected FullyAuditedEntity()
    {
    }

    public DateTimeOffset Created { get; set; }
    public string? CreatedBy { get; set; }

    public DateTimeOffset? Updated { get; set; }
    public string? UpdatedBy { get; set; }

    public DateTimeOffset? Deleted { get; set; }
    public string? DeletedBy { get; set; }

    public bool IsDeleted { get; set; } = false;
}