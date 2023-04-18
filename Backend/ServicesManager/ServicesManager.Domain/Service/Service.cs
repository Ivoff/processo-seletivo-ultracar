namespace ServicesManager.Domain.Service;

using ServicesManager.Domain.Shared;
using System.Linq;

class Service: Entity
{
    public Car Car { get; init; }
    public Collaborator Collaborator { get; init; }
    public EServiceState CurrentState { get; init; }
    public DateTime? StartedAt { get; private set; } = null;
    public DateTime? FinishedAt { get; private set; } = null;
    public DateTime? CancelledAt { get; private set; } = null;
    public PartsCollection PartsCollection { get; init; }
    
    public Service(Car car, Collaborator collaborator, Guid id, DateTime createdAt): base(id, createdAt)
    {
        Car = car;
        Collaborator = collaborator;
        CurrentState = EServiceState.OnHold;
    }

    public void Begin()
    {
        StartedAt = DateTime.Now();
        CurrentState = EServiceState.InProgress;
    }

    public void Cancel()
    {
        CancelledAt = DateTime.Now();
        CurrentState = EServiceState.Cancelled;
    }

    public void Finish()
    {
        FinishedAt = DateTime.Now();
        CurrentState = EServiceState.Finished;
    }

    public static Service(
        Car car, 
        Collaborator collaborator, 
        EServiceState currentState, 
        DateTime? startedAt, 
        DateTime? finishedAt, 
        DateTime? cancelledAt, 
        PartsCollection partsCollection, 
        Guid serviceId, 
        DateTime createdAt
    )
    {
        return new Service(car, collaborator, serviceId, createdAt) 
        {
            CurrentState = currentState,
            StartedAt = startedAt,
            FinishedAt = finishedAt,
            CancelledAt = cancelledAt,
            PartsCollection = partsCollection
        };
    }
}