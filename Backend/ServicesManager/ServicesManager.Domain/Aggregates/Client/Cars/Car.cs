namespace ServicesManager.Domain.Client;

using ServicesManager.Domain.Shared;

public class Car: Entity
{
    public string Model { get; init; }
    public string Year { get; init; }
    public string Color{ get; init; }

    public Car(string model, string year, string color, Guid id, DateTime createdAt): base(id, createdAt)
    {
        Model = model;
        Year = year;
        Color = color;
    }
}