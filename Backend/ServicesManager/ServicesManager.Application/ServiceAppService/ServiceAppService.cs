using ServicesManager.Domain.Service;
using ServicesManager.Domain.Shared;
using Car = ServicesManager.Domain.Service.Car;

namespace ServicesManager.Application.ServiceService;

public class ServiceAppService: IServiceAppService
{
    private readonly IRepository<Service> _serviceRepository;
    private readonly IRepository<Car> _carRepository;
    private readonly IRepository<Collaborator> _collaboratorRepository;
    private readonly IRepository<Part> _partRepository;

    public ServiceAppService(
        IRepository<Service> serviceRepository, 
        IRepository<Car> carRepository, 
        IRepository<Collaborator> collaboratorRepository,
        IRepository<Part> partRepository 
    )
    {
        _serviceRepository = serviceRepository;
        _carRepository = carRepository;
        _collaboratorRepository = collaboratorRepository;
        _partRepository = partRepository;
    }
    
    public void CreateService(Guid carId, Guid collaboratorId)
    {
        Car car = _carRepository.Read(new List<Guid>() { carId }).First();
        Collaborator collaborator = _collaboratorRepository.Read(new List<Guid>() { collaboratorId }).First();

        Service newService = new Service(car, collaborator);
        _serviceRepository.Write(newService);
    }

    public void AddPart(Guid serviceId, Guid partId, int quantity)
    {
        var service = _serviceRepository.Read(new List<Guid>() { serviceId }).First();
        
        var part = _partRepository.Read(new List<Guid>() { partId }).First();
        part.Quantity = quantity;
        
        service.AddPart(part);
        _serviceRepository.Write(service);
    }

    public void RemovePart(Guid serviceId, Guid partId)
    {
        var service = _serviceRepository.Read(new List<Guid>() { serviceId }).First();
        
        var part = _partRepository.Read(new List<Guid>() { partId }).First();

        service.RemovePart(part);
    }

    public void BeginService(Guid serviceId)
    {
        var service = _serviceRepository.Read(new List<Guid>() { serviceId }).First();
        service.Begin();
        _serviceRepository.Write(service);
    }

    public void FinishService(Guid serviceId)
    {
        var service = _serviceRepository.Read(new List<Guid>() { serviceId }).First();
        service.Finish();
        _serviceRepository.Write(service);
    }
}