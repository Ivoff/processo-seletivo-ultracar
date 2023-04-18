namespace ServicesManager.Domain.Service;

class Part
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }

    public Part(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}