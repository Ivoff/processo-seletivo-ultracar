namespace ServicesManager.Domain.Service;

using ServicesManager.Domain.Shared;

public class Part: Entity
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }

    public Part(string name, decimal price, int quantity, Guid id, DateTime createdAt): base(id, createdAt)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public Part(string name, decimal price, int quantity, Guid id, DateTime createdAt): base(id, createdAt)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}