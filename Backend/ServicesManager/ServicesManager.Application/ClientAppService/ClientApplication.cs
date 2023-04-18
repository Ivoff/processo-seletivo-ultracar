using ServicesManager.Domain.QrCodeService;

namespace ServicesManager.Application.ClientService;

using ServicesManager.Domain.Client;
using ServicesManager.Domain.Shared;
using ServicesManager.Domain.Service;

public class ClientAppService : IClientAppService
{
    private readonly IRepository<Client> _clientRepository;
    private readonly IQrCodeService _qrCodeService;

    public ClientAppService(IRepository<Client> clientRepository, IQrCodeService qrCodeService)
    {
        _clientRepository = clientRepository;
        _qrCodeService = qrCodeService;
    }

    public string GenerateQrCode(Guid clientId, Guid carId)
    {
        Client client = _clientRepository.Read(new List<Guid>(){ clientId }).First();
        Domain.Client.Car selectedCar = client.CarsCollection.Cars.Where(x => x.Id == carId).First();
            
        byte[] qrCodeByteArray = _qrCodeService.GenerateQrCode(selectedCar, client);

        return Convert.ToBase64String(qrCodeByteArray);
    }
}