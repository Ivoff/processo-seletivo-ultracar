namespace ServicesManager.Infra.Repository;

public class ServiceDTO
{
    public Guid Id { get; init; } = default!;
    public DateTime CreatedAt { get; init; } = default!;
    public Guid CollaboratorId { get; init; } = default!;
    public Guid CarId { get; init; } = default!;
    public DateTime? StartedAt { get; init; } = default!;
    public DateTime? FinishedAt { get; init; } = default!;
}