namespace ServicesManager.Application.ClientService;

public interface IClientAppService
{
    public byte[] GenerateQrCode(Guid clientId);
}