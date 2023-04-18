namespace ServicesManager.WebApi.Controllers;

public record CarQrCodeRequest(
    Guid ClientId,
    Guid CarId
);