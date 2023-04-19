namespace ServicesManager.Infra.Repository;

using System;
using System.Collections.Generic;
using ServicesManager.Domain.Client;
using ServicesManager.Domain.Shared;
using Microsoft.Extensions.Options;
using System.Linq;
using ServicesManager.Infra.ConnectionStrings;
using ServicesManager.Infra.DbConnection;
using Dapper;

public class ClientRepository : IRepository<Client>
{
    private readonly IOptions<ConnectionStrings> _connectionString;
    private readonly IDbConnection _dbConnection;
    
    public ClientRepository(IOptions<ConnectionStrings> connectionString, IDbConnection dbConnection)
    {
        _connectionString = connectionString;
        _dbConnection = dbConnection;
    }
    
    public IList<Client> Read(IList<Guid> ids)
    {
        ClientDTO? curClient;
        IList<CarDTO> curClientCars;
        IList<Client> output = new List<Client>();
        
        foreach (var id in ids)
        {
            curClient = _dbConnection.Con
                .Query<ClientDTO>(@"select * from client where id = @Id", new { Id = id }).FirstOrDefault();

            if (curClient == null)
                continue;
            
            curClientCars = _dbConnection.Con
                .Query<CarDTO>(@"select * from car where ownerid = @Id", new { Id = id }).ToList();

            var carsList = curClientCars.Select((x) => new Car(x.Model, x.Year, x.Id, x.CreatedAt)).ToList();
            
            output.Add(new Client(
                curClient.Name,
                new CarsCollection(carsList),
                curClient.Id,
                curClient.CreatedAt
            ));
        }

        return output;
    }

    public void Write(Client aggregate)
    {
        throw new NotImplementedException();
    }
}