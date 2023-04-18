using Microsoft.AspNetCore.Mvc;

namespace ServicesManager.WebApi.Controllers;

using ServicesManager.Domain.QrCodeService;

[ApiController]
[Route("service")]
public class ServiceController : ControllerBase
{
    private readonly IQrCodeService _qrCodeService;

    public ServiceController(IQrCodeService qrCodeService)
    {
        _qrCodeService = qrCodeService;
    }
    
    [HttpPost("service")]
    public IActionResult BeginService()
    {
        return Ok("teste");
    }
}