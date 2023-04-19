namespace ServicesManager.WebApi.Controllers;

public record RemovePartRequest(
    Guid partId,
    Guid serviceId
);