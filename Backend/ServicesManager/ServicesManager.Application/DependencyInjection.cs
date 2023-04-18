using ServicesManager.Application.ClientService;

namespace ServicesManager.Application.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using ServicesManager.Domain.QrCodeService;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IClientAppService, ClientAppService>();
        return services;
    }
}