namespace ServicesManager.Domain.QrCodeService;

using ServicesManager.Domain.Client;
using Microsoft.Extensions.Options;
using RestSharp;

class QrCodeService: IQrCodeService
{
    private readonly IOptions<QrCodeApiOptions> _qrCodeApiOptions;

    QrCodeService(IOptions<QrCodeApiOptions> qrCodeApiOptions)
    {
        _qrCodeApiOptions = qrCodeApiOptions;
    }

    public async void GenerateQrCode(Car car, Client client)
    {
        var api = new RestClient(new RestClientOptions(_qrCodeApiOptions.Value.Address));
        var request = new RestRequest(_qrCodeApiOptions.Value.Path);
        var response = await api.PostAsync(request);
        Console.WriteLine(response.Content);
    }
}