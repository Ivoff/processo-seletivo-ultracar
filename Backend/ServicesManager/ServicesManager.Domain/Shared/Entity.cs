namespace ServicesManager.Domain.Shared;

class Entity
{
    public Guid Id { get; init; }

    public DateTime CreatedAt { get; init; }

    private Entity(){}

    public Entity(Guid id, DateTime createdAt) 
    {
        Id = id;
        CreatedAt = createdAt;
    }
}