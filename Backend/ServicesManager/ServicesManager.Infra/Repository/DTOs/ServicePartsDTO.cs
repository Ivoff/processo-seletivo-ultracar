namespace ServicesManager.Infra.Repository;

public class ServicePartDTO
{
    public Guid Id { get; init; } = default!;
    public DateTime CreatedAt { get; init; } = default!;
    public string Name { get; init; } = default!;
    public decimal Price { get; init; } = default!;
    public int Quantity { get; init; } = default!;
}