namespace QrCodeGenerator.WebApi.Controllers.Generate;

using System;

public record GenerateQrCodeRequest(
    Guid ClientId,
    Guid CarId
);