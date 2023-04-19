using ServicesManager.Domain.Client;
using ServicesManager.Domain.Service;
using ServicesManager.Domain.Shared;
using ServicesManager.Infra.Repository;
using Car = ServicesManager.Domain.Service.Car;

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
        services.AddScoped<IRepository<Service>, ServiceRepository>();
        services.AddScoped<IRepository<Car>, CarRepository>();
        services.AddScoped<IRepository<Collaborator>, CollaboratorRepository>();
        services.AddScoped<IRepository<Part>, PartRepository>();
        return services;
    }
}