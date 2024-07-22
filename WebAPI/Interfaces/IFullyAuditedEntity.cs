namespace WebAPI.Interfaces;

/// <summary>
///     Interface for fully audited entity
/// </summary>
public interface IFullyAuditedEntity : 
    IEntityBase,
    ISoftDelete
{
    public DateTimeOffset Created { get; set; }
    public string? CreatedBy { get; set; }

    public DateTimeOffset? Updated { get; set; }
    public string? UpdatedBy { get; set; }
}