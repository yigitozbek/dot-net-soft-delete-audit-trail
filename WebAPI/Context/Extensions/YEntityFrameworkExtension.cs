using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;

namespace WebAPI.Context.Extensions;

/// <summary>
///     The entity framework extension.
/// </summary>
public static class YEntityFrameworkExtension
{
    /// <summary>
    ///     This method is used to add all entities to the model builder.
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="assembly"></param>
    public static ModelBuilder OnModelCreatingWithEntity(this ModelBuilder modelBuilder, Assembly assembly)
    {
        var entityTypes = assembly
            .GetTypes()
            .Where(t => typeof(IEntityBase).IsAssignableFrom(t) && t is { IsAbstract: false, IsInterface: false });

        foreach (var entityType in entityTypes)
        {
            modelBuilder.Entity(entityType);
        }

        return modelBuilder;
    }
    
    /// <summary>
    ///     This method is used to set the soft delete filter.
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <returns></returns>
    public static ModelBuilder GetEntityWithoutDeleted(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof (ISoftDelete).IsAssignableFrom(entityType.ClrType))
                modelBuilder.SetSoftDeleteFilter(entityType.ClrType);
        }   

        return modelBuilder;
    }
    


}