namespace ServicesManager.WebApi.Controllers;

using FluentValidation;

public class ServiceIdRequestValidator : AbstractValidator<ServiceIdRequest>
{
    public ServiceIdRequestValidator()
    {
        RuleFor(x => x.ServiceId).NotEmpty();
    }
}