namespace ServicesManager.Domain.Service;

using ServicesManager.Domain.Shared;

class Collaborator: Entity
{
    public string Name { get; init; }

    public Collaborator(Guid id, DateTime createdAt, string name): base(id, createdAt)
    {
        Name = name;
    }
}