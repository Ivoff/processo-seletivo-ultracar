namespace ServicesManager.Domain.QrCodeService;

using ServicesManager.Domain.Client;
using Microsoft.Extensions.Options;
using RestSharp;

class QrCodeService: IQrCodeService
{
    private readonly IOptions<QrCodeApiOptions> _qrCodeApiOptions;

    public QrCodeService(IOptions<QrCodeApiOptions> qrCodeApiOptions)
    {
        _qrCodeApiOptions = qrCodeApiOptions;
    }

    public byte[] GenerateQrCode(Car car, Client client)
    {
        var api = new RestClient(new RestClientOptions(_qrCodeApiOptions.Value.Address));
        var request = new RestRequest(_qrCodeApiOptions.Value.Path);
        request.AddJsonBody(new
        {
            ClientId = client.Id,
            CarId = car.Id
        });

        var response = api.ExecutePost<QrCodeDTO>(request);
        
        if (response.Data == null)
            return new byte[] { };

        return response.Data.qrCode;
    }
}