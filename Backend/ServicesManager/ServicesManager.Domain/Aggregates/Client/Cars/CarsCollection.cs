namespace ServicesManager.Domain.Client;


public class CarsCollection
{
    public IList<Car> Cars { get; init; }

    public CarsCollection(IList<Car> cars)
    {
        Cars = cars;
    }

    public void AddPart(Car car)
    {
        Cars.Add(car);
    }

    public void RemovePart(Car car)
    {
        Cars.Remove(car);
    }
}