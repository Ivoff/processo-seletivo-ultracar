namespace ServicesManager.WebApi.Controllers;

using FluentValidation;

public class NewServiceRequestValidator : AbstractValidator<NewServiceRequest>
{
    public NewServiceRequestValidator()
    {
        RuleFor(x => x.CollaboratorId).NotEmpty();
        RuleFor(x => x.CarId).NotEmpty();
    }
}