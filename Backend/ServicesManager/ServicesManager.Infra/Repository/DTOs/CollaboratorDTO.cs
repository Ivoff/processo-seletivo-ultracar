namespace ServicesManager.Infra.Repository;

public class CollaboratorDTO
{
    public Guid Id { get; init; } = default!;
    public DateTime CreatedAt { get; init; } = default!;
    public string Name { get; init; } = default!;
}