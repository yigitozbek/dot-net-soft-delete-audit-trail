using Microsoft.EntityFrameworkCore;
using WebAPI.Context.Extensions;
using WebAPI.Context.Interceptors;

namespace WebAPI.Context;

/// <summary>
///     Application Database Context
/// </summary>
public class ApplicationDbContext : DbContext
{
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditingSaveChangesInterceptor());

        base.OnConfiguring(optionsBuilder);
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.GetEntityWithoutDeleted();
    }
}