namespace ServicesManager.Domain.Service;

using ServicesManager.Domain.Shared;

public class Car: Entity
{
    public string Model { get; init; }
    public string Year { get; init; }
    public Entity Owner { get; init; }

    public Car(string model, string year, Entity owner, Guid id, DateTime createdAt): base(id, createdAt)
    {
        Model = model;
        Year = year;
        Owner  = owner;
    }
}