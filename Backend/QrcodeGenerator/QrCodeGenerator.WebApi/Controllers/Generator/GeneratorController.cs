using SkiaSharp;
using SkiaSharp.QrCode.Image;

namespace QrCodeGenerator.WebApi.Controllers.Generate;

using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using SkiaSharp.QrCode;

[ApiController]
[Route("qrcode/generate")]
public class GeneratorController: ControllerBase
{
    private readonly IValidator<GenerateQrCodeRequest> _generateValidator;

    public GeneratorController(IValidator<GenerateQrCodeRequest> generateValidator)
    {
        _generateValidator = generateValidator;
    }

    [HttpPost()]
    public IActionResult Generate(GenerateQrCodeRequest generateRequest)
    {
        var validationResult = _generateValidator.Validate(generateRequest);
        
        if (validationResult.IsValid == false)
            return BadRequest(validationResult.ToString());
        
        string content = $"clientId:{generateRequest.ClientId.ToString()},carId:{generateRequest.CarId.ToString()}";
        MemoryStream byteStream = new MemoryStream();
        var qrCode = new QrCode(content, new Vector2Slim(512, 512), SKEncodedImageFormat.Png);
        qrCode.GenerateImage(byteStream);

        return Ok(new GenerateQrCodeResponse(byteStream.ToArray()));
    }
}