namespace ServicesManager.WebApi.Controllers;

public record AddPartRequest(
    Guid partId,
    Guid serviceId,
    int Quantity
);