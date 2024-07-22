using WebAPI.Interfaces;

namespace WebAPI.Base;

public class SoftDelete : ISoftDelete
{
    public DateTimeOffset? Deleted { get; set; }
    public string? DeletedBy { get; set; }

    public bool IsDeleted { get; set; } = false;
}