using System.Data;
using System.Diagnostics;

namespace ServicesManager.Infra.Repository;

using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Linq;
using ServicesManager.Domain.Shared;
using ServicesManager.Domain.Service;
using System.Collections.Generic;
using System;
using ServicesManager.Infra.ConnectionStrings;
using ServicesManager.Infra.DbConnection;
using Dapper;

public class ServiceRepository : IRepository<Service>
{
    private readonly IOptions<ConnectionStrings> _connectionString;
    private readonly IDbConnection _dbConnection;
    public ServiceRepository(IOptions<ConnectionStrings> connectionString, IDbConnection dbConnection)
    {
        _connectionString = connectionString;
        _dbConnection = dbConnection;
    }

    public IList<Service> Read(IList<Guid> ids)
    {
        throw new NotImplementedException();
    }

    public void Write(Service aggregate)
    {
        const string sql = @"INSERT INTO 
        services (id, created_at, collaborator_id, car_id, started_at, finished_at) 
        VALUES (@ServiceId, @CreatedAt, @CollaboratorId, @CarId, @StartedAt, @FinishedAt)";

        var anonymousService = new
        {
            ServiceId = aggregate.Id,
            CreatedAt = aggregate.CreatedAt,
            Collaborator = aggregate.Collaborator.Id,
            CarId = aggregate.Car.Id,
            StartedAt = aggregate.StartedAt,
            FinishedAt = aggregate.FinishedAt
        };

        if (_dbConnection.Con.Execute(sql, anonymousService) < 1)
        {
            throw new DataException((new StackTrace()).ToString());
        }
    }
}