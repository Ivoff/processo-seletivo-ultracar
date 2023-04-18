using Microsoft.AspNetCore.Mvc;

namespace ServicesManager.WebApi.Controllers;

using ServicesManager.Domain.QrCodeService;

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    private readonly IQrCodeService _qrCodeService;

    public ClientController(IQrCodeService qrCodeService)
    {
        _qrCodeService = qrCodeService;
    }
    
    [HttpPost("service")]
    public IActionResult BeginService()
    {
        return Ok("teste");
    }
}