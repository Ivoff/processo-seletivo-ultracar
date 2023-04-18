using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ServicesManager.Application.ClientService;

namespace ServicesManager.WebApi.Controllers;

using ServicesManager.Domain.QrCodeService;

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    private readonly IClientAppService _clientAppService;
    private readonly IValidator<CarQrCodeRequest> _carQrCodeRequest;

    public ClientController(
        IClientAppService clientAppService, 
        IValidator<CarQrCodeRequest> carQrCodeRequest
    )
    {
        _clientAppService = clientAppService;
        _carQrCodeRequest = carQrCodeRequest;
    }
    
    [HttpPost("car/qrcode")]
    public IActionResult CarQrCode(CarQrCodeRequest request)
    {
        var result = _carQrCodeRequest.Validate(request);
        if (result.IsValid == false)
        {
            BadRequest(result.Errors.ToString());
        }

        string base64QrCode = "";
        
        try
        {
            base64QrCode = _clientAppService.GenerateQrCode(request.ClientId, request.CarId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode((int) HttpStatusCode.InternalServerError);
        }
        
        return Ok(new CarQrCodeResponse(base64QrCode));
    }
}