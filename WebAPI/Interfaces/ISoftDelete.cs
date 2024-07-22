namespace WebAPI.Interfaces;

/// <summary>
///     Interface for soft delete
/// </summary>
public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
    public DateTimeOffset? Deleted { get; set; }
    public string? DeletedBy { get; set; }
}