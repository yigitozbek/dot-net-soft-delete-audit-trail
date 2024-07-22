using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;

namespace WebAPI.Context.Extensions;


/// <summary>
///     This class is used to add filter to the entities.
/// </summary>
public static class FilterExtensions
{
    /// <summary>
    ///     This method is used to set the soft delete filter to the entities.
    /// </summary>
    private static readonly MethodInfo SetSoftDeleteFilterMethod = typeof (FilterExtensions).GetMethods(BindingFlags.Static | BindingFlags.Public).Single(t => t is { IsGenericMethod: true, Name: nameof(SetSoftDeleteFilter) });

    public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
    {
        SetSoftDeleteFilterMethod.MakeGenericMethod(entityType).Invoke(null, [
            modelBuilder
        ]);
    }

    public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder) where TEntity : class, ISoftDelete
    {
        modelBuilder.Entity<TEntity>().HasQueryFilter((Expression<Func<TEntity, bool>>) (x => !x.IsDeleted));
    }
}
