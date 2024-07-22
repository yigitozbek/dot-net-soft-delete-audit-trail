using System.ComponentModel.DataAnnotations;

namespace WebAPI.Base;

public class Entity<TKey> : IEntity<TKey>
    where TKey : struct
{
    protected Entity(TKey id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    [Key] 
    public TKey Id { get; set; }
}