namespace QrCodeGenerator.WebApi.Controllers.Generate;

using FluentValidation;

public class GenerateQrCodeRequestValidator : AbstractValidator<GenerateQrCodeRequest>
{
    public GenerateQrCodeRequestValidator()
    {
        RuleFor(x => x.ClientId).NotEmpty();
        RuleFor(x => x.CarId).NotEmpty();
    }
}