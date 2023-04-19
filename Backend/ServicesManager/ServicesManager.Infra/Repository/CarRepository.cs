namespace ServicesManager.Infra.Repository;

using Microsoft.Extensions.Options;
using System.Linq;
using ServicesManager.Domain.Shared;
using ServicesManager.Domain.Service;
using System.Collections.Generic;
using System;
using ServicesManager.Infra.ConnectionStrings;
using ServicesManager.Infra.DbConnection;
using Dapper;

public class CarRepository : IRepository<Domain.Service.Car>
{
    private readonly IOptions<ConnectionStrings> _connectionString;
    private readonly IDbConnection _dbConnection;
    
    public CarRepository(IOptions<ConnectionStrings> connectionString, IDbConnection dbConnection)
    {
        _connectionString = connectionString;
        _dbConnection = dbConnection;
    }

    public IList<Domain.Service.Car> Read(IList<Guid> ids)
    {
        CarDTO? curCar;
        ClientDTO? curClient;
        List<Domain.Service.Car> output = new List<Domain.Service.Car>();
        
        foreach(var id in ids)
        {
            curCar = _dbConnection.Con
                .Query<CarDTO>(@"select * from car where id = @Id", new { Id = id }).FirstOrDefault();
            
            if (curCar == null)
                continue;

            curClient = _dbConnection.Con.Query<ClientDTO>(@"select * from client where id = @Id", new { Id = curCar.OwnerId }).FirstOrDefault();
            
            if (curClient == null)
                continue;
            
            output.Add(new Domain.Service.Car(
                curCar.Model, 
                curCar.Year, 
                new Entity(curClient.Id, curClient.CreatedAt), 
                curCar.Id, 
                curCar.CreatedAt
            ));
        }

        return output;
    }

    public void Write(Car aggregate)
    {
        throw new NotImplementedException();
    }
}