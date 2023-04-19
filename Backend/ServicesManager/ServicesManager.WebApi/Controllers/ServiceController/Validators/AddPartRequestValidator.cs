namespace ServicesManager.WebApi.Controllers;

using FluentValidation;

public class AddPartRequestValidator : AbstractValidator<AddPartRequest>
{
    public AddPartRequestValidator()
    {
        RuleFor(x => x.partId).NotEmpty();
        RuleFor(x => x.serviceId).NotEmpty();
        RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
    }
}