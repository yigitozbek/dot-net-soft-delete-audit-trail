namespace WebAPI.Base;

public interface IEntity<TKey> : IEntityBase
    where TKey : struct
{
    TKey Id { get; set; }
}