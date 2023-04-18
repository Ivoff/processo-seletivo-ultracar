namespace ServicesManager.WebApi.Controllers;

using FluentValidation;

public class CarQrCodeRequestValidator : AbstractValidator<CarQrCodeRequest>
{
    public CarQrCodeRequestValidator()
    {
        RuleFor(x => x.ClientId).NotEmpty();
        RuleFor(x => x.CarId).NotEmpty();
    }
}