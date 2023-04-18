using ServicesManager.Domain.Client;
using ServicesManager.Domain.Shared;
using ServicesManager.Infra.Repository;

namespace ServicesManager.Infra.DependencyInjection;

using ServicesManager.Infra.DbConnection;
using Microsoft.Extensions.DependencyInjection;
using ServicesManager.Infra.ConnectionStrings;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IConnectionStrings, ConnectionStrings>();
        services.AddScoped<IDbConnection, DbConnection>();
        services.AddScoped<IRepository<Client>, ClientRepository>();
        return services;
    }
}