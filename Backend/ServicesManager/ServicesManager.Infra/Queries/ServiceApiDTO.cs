namespace ServicesManager.Infra.DTOs;

public class ServiceApiDTO
{
    public Guid ServiceId { get; init; }
    public DateTime CreatedAt { get; init; }
    public string CollaboratorName { get; init; }
    public Guid CollaboratorId { get; init; }
    public string CarModel { get; init; }
    public string CarYear { get; init; }
    public string OwnerName { get; init; }
    public Guid OwnerId { get; init; }
    public decimal TotalCost { get; set; }
    public string ElapsedTime { get; set; }
    public string CurrentState { get; set; }
    public DateTime? StartedAt { get; init; }
    public DateTime? FinishedAt { get; init; }
}