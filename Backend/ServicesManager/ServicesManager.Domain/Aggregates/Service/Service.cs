namespace ServicesManager.Domain.Service;

using ServicesManager.Domain.Shared;
using System.Linq;

public class Service: Entity
{
    public Car Car { get; private set; } = default!;
    public Collaborator Collaborator { get; private set; } = default!;
    public DateTime? StartedAt { get; private set; } = null;
    public DateTime? FinishedAt { get; private set; } = null;    
    public PartsCollection PartsCollection { get; private set; } = default!;
    
    private Service(Guid serviceId, DateTime createdAt): base(serviceId, createdAt) {}

    public Service(Car car, Collaborator collaborator): base()
    {
        Car = car;
        Collaborator = collaborator;
        PartsCollection = new PartsCollection(new List<Part>());
    }

    public void Begin()
    {
        if (StartedAt != null)
            throw new Exception("A service can only be initialized once.");
        
        StartedAt = DateTime.Now;
    }

    public void Finish()
    {
        if (FinishedAt != null)
            throw new Exception("A service can only be finished once.");
        
        FinishedAt = DateTime.Now;
    }

    public void AddPart(Part part)
    {
        if (FinishedAt != null)
            throw new Exception("Can't add parts after finishing a service.");
        
        if (StartedAt != null)
            throw new Exception("Can't add parts after starting a service.");
        
        PartsCollection.AddPart(part);
    }

    public void RemovePart(Part part)
    {
        if (FinishedAt != null)
            throw new Exception("Can't remove parts after finishing a service.");
        
        if (StartedAt != null)
            throw new Exception("Can't remove parts after starting a service.");
        
        PartsCollection.RemovePart(part);
    }
    
    public static Service Create(
        Car car, 
        Collaborator collaborator,
        DateTime? startedAt, 
        DateTime? finishedAt, 
        PartsCollection partsCollection, 
        Guid serviceId, 
        DateTime createdAt
    )
    {
        return new Service(serviceId, createdAt) 
        {
            Car = car,
            Collaborator = collaborator,
            StartedAt = startedAt,
            FinishedAt = finishedAt,
            PartsCollection = partsCollection
        };
    }
}