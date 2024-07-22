using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebAPI.Interfaces;

namespace WebAPI.Context.Interceptors;


/// <summary>
///     This class is used to intercept the save changes and apply the audit trail to the entities.
/// </summary>
public class AuditingSaveChangesInterceptor : SaveChangesInterceptor
{
    /// <summary>
    ///     This method is used to apply audit trail to the entities.
    /// </summary>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context != null) ApplyAuditTrail(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    /// <summary>
    ///     This method is used to apply audit trail to the entities.
    /// </summary>
    /// <param name="eventData"></param>
    /// <param name="result"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context != null) ApplyAuditTrail(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    /// <summary>
    ///     This method is used to apply audit trail to the entities.
    /// </summary>
    /// <param name="context"></param>
    private static void ApplyAuditTrail(DbContext context)
    {
        var entries = context.ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Deleted:
                    if (entry.Entity is IFullyAuditedEntity delete)
                    {
                        entry.State = EntityState.Modified;
                        delete.IsDeleted = true;
                        delete.Deleted = DateTimeOffset.UtcNow;
                    }

                    break;
                case EntityState.Added:
                    if (entry.Entity is IFullyAuditedEntity add)
                    {
                        add.Created = DateTimeOffset.UtcNow;
                    }
                    break;
                
                case EntityState.Modified:
                    if (entry.Entity is IFullyAuditedEntity modified)
                    {
                        modified.Updated = DateTimeOffset.UtcNow;
                    }
                    break;
            }
        }
    }
}