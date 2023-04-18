using Microsoft.AspNetCore.Mvc;

namespace ServicesManager.WebApi.Controllers;

[ApiController]
[Route("service")]
public class ServiceController : ControllerBase
{
    public ServiceController() {}
    
    [HttpPost("service")]
    public IActionResult BeginService()
    {
        return Ok("teste");
        // throw new NotImplementedException();
    }
}