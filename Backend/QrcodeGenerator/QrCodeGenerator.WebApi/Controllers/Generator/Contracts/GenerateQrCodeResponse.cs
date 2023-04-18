namespace QrCodeGenerator.WebApi.Controllers.Generate;

using System;

public record GenerateQrCodeResponse(
    byte[] qrcode
);