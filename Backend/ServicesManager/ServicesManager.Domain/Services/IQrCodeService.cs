namespace ServicesManager.Domain.QrCodeService;

using ServicesManager.Domain.Client;

public interface IQrCodeService
{
    public byte[] GenerateQrCode(Car car, Client client);
}