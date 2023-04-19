namespace ServicesManager.Application.ServiceService;

public interface IServiceAppService
{
    public void CreateService(Guid carId, Guid collaboratorId);
    public void AddPart(Guid serviceId, Guid partId, int quantity);
    public void RemovePart(Guid serviceId, Guid partId);
    public void BeginService(Guid serviceId);
    public void FinishService(Guid serviceId);
}