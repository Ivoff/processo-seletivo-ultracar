namespace ServicesManager.Domain.Shared;

using System;

public class Entity
{
    public Guid Id { get; init; }

    public DateTime CreatedAt { get; init; }

    public  Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

    public Entity(Guid id, DateTime createdAt) 
    {
        Id = id;
        CreatedAt = createdAt;
    }
}