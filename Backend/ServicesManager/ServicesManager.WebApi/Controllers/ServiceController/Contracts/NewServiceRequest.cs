namespace ServicesManager.WebApi.Controllers;

public record NewServiceRequest(
    Guid CarId,
    Guid CollaboratorId
);