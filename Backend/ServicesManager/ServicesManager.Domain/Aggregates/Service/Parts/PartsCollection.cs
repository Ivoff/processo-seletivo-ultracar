namespace ServicesManager.Domain.Service;

using System.Linq;

public class PartsCollection
{
    public IList<Part> Parts { get; private set; }

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
        Parts = Parts.Where(x => x.Id != part.Id).ToList();
    }
}