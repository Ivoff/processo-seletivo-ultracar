namespace ServicesManager.Application.ClientService;

public interface IClientAppService
{
    public string GenerateQrCode(Guid clientId, Guid carId);
}