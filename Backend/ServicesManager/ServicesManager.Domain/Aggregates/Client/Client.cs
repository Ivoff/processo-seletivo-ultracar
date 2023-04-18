namespace ServicesManager.Domain.Client;

using ServicesManager.Domain.Shared;

public class Client: Entity
{
    public string Name { get; init; }
    public CarsCollection CarsCollection { get; private set; }

    public Client(string name, CarsCollection carsCollection, Guid id, DateTime createdAt): base(id, createdAt)
    {
        Name = name;
        CarsCollection = carsCollection;
    }
}