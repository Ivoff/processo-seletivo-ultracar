namespace ServicesManager.Domain.Service;

class PartsCollection
{
    public IList<Part> PartsCollection { get; init; }

    public PartsCollection(IList<Part> partsCollection)
    {
        PartsCollection = partsCollection;
    }

    public void AddPart(Part part)
    {
        PartsCollection.Add(part);
    }

    public void RemovePart(Part part)
    {
        PartsCollection.Remove(part);
    }
}