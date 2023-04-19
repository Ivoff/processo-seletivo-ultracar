namespace ServicesManager.Infra.Repository;

public class CarDTO
{
    public Guid Id { get; init; } = default!;
    public DateTime CreatedAt { get; init; } = default!;
    public Guid OwnerId { get; init; } = default!;
    public string Model { get; init; } = default!;
    public string Year { get; init; } = default!;
}