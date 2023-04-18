namespace ServicesManager.Domain.Service;

public class PartsCollection
{
    public IList<Part> Parts { get; init; }

    public PartsCollection(IList<Part> parts)
    {
        Parts = parts;
    }

    public void AddPart(Part part)
    {
        Parts.Add(part);
    }

    public void RemovePart(Part part)
    {
        Parts.Remove(part);
    }
}