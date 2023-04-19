namespace ServicesManager.WebApi.Controllers;

using FluentValidation;

public class RemovePartRequestValidator : AbstractValidator<RemovePartRequest>
{
    public RemovePartRequestValidator()
    {
        RuleFor(x => x.partId).NotEmpty();
        RuleFor(x => x.serviceId).NotEmpty();
    }
}