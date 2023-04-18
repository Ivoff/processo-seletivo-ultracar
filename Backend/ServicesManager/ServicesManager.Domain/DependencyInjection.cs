namespace ServicesManager.Domain.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using ServicesManager.Domain.QrCodeService;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IQrCodeService, QrCodeService>();
        return services;
    }
}