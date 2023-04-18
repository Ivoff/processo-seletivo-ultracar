namespace ServicesManager.Domain.QrCodeService;

using ServicesManager.Domain.Client;

public interface IQrCodeService
{
    public void GenerateQrCode(Car car, Client client);
}