using System.Data;
using System.Diagnostics;
using Npgsql.Replication.PgOutput.Messages;

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
    private readonly IRepository<Collaborator> _collaboratorRepository;
    private readonly IRepository<Domain.Service.Car> _carRepository;
    private readonly IRepository<Part> _partRepository;

    public ServiceRepository(
        IOptions<ConnectionStrings> connectionString, 
        IDbConnection dbConnection ,
        IRepository<Collaborator> collaboratorRepository,
        IRepository<Domain.Service.Car> carRepository,
        IRepository<Part> partRepository
    )
    {
        _connectionString = connectionString;
        _dbConnection = dbConnection;
        _collaboratorRepository = collaboratorRepository;
        _carRepository = carRepository;
        _partRepository = partRepository;
    }

    public IList<Service> Read(IList<Guid> ids)
    {
        ServiceDTO? serviceDto;
        Domain.Service.Car? curCar;
        Collaborator? curCollaborator;
        List<ServicePartDTO>? curParts;
        List<Service> output = new List<Service>();
        
        foreach (var id in ids)
        {
            serviceDto = _dbConnection.Con.
                Query<ServiceDTO>(@"select * from service where id = @Id", new { Id = id }).FirstOrDefault();
            
            if (serviceDto == null)
                continue;

            curCar = _carRepository.Read(new List<Guid>() { serviceDto.CarId }).FirstOrDefault();
            
            if (curCar == null)
                continue;

            curCollaborator = _collaboratorRepository.Read(new List<Guid>() { serviceDto.CollaboratorId }).FirstOrDefault();
            
            if (curCollaborator == null)
                continue;

            curParts = _dbConnection.Con
                .Query<ServicePartDTO>(@"
                select part.id, part.createdat, part.name, part.price, service_parts.quantity
                from service_parts 
                inner join part
                    on service_parts.serviceid = @ServiceId and
                    part.id = service_parts.partid
                where service_parts.serviceid = @Id", new { ServiceId = serviceDto.Id, Id = serviceDto.Id }).ToList();
            
            output.Add(Service.Create(
                curCar, curCollaborator, serviceDto.StartedAt, serviceDto.FinishedAt,
                new PartsCollection(curParts.Select(x => new Part(x.Name, x.Price, x.Quantity, x.Id, x.CreatedAt)).ToList()),
                serviceDto.Id, serviceDto.CreatedAt
            ));
        }

        return output;
    }

    public void Write(Service aggregate)
    {
        if (_dbConnection.Con.ExecuteScalar<int>(@"select count(*) from service where id = @Id", new {Id = aggregate.Id}) == 0)
            Insert(aggregate);
        else
        {
            const string serviceSql = @"update service 
            set startedat = @StartedAt, finishedAt = @FinishedAt
            where id = @Id";

            var anonymousService = new
            {
                StartedAt = aggregate.StartedAt,
                FinishedAt = aggregate.FinishedAt,
                Id = aggregate.Id
            };

            const string servicePartsSql =
                @"insert into service_parts (partid, serviceid, quantity) values (@PartId, @ServiceId, @Quantity)";
            
            var service = Read(new List<Guid>() { aggregate.Id }).First();
            List<Part> addList = new List<Part>();
            foreach (var part in aggregate.PartsCollection.Parts)
            {
                if (service.PartsCollection.Parts.Where(x => x.Id == part.Id).ToList().Count == 0)
                    addList.Add(part);
            }

            using (var connection = _dbConnection.Con)
            {
                connection.Open();
                using (var transaction = _dbConnection.Con.BeginTransaction())
                {
                    _dbConnection.Con.Execute(serviceSql, anonymousService);

                    foreach (var part in addList)
                    {
                        var anonymousServiceParts = new
                        {
                            PartId = part.Id,
                            ServiceId = aggregate.Id,
                            Quantity = part.Quantity
                        };

                        _dbConnection.Con.Execute(servicePartsSql, anonymousServiceParts);
                    }    
            
                    transaction.Commit();
                }   
            }
        }
    }

    private void Insert(Service aggregate)
    {
        const string serviceSql = @"INSERT INTO 
        service (id, createdat, collaboratorid, carid, startedat, finishedat) 
        VALUES (@ServiceId, @CreatedAt, @CollaboratorId, @CarId, @StartedAt, @FinishedAt)";

        var anonymousService = new
        {
            ServiceId = aggregate.Id,
            CreatedAt = aggregate.CreatedAt,
            CollaboratorId = aggregate.Collaborator.Id,
            CarId = aggregate.Car.Id,
            StartedAt = aggregate.StartedAt,
            FinishedAt = aggregate.FinishedAt
        };

        const string servicePartsSql =
            @"insert into service_parts (partid, serviceid, quantity) values (@PartId, @ServiceId, @QuantityId)";

        using (var connection = _dbConnection.Con)
        {
            connection.Open();
            using (var transaction = _dbConnection.Con.BeginTransaction())
            {
                _dbConnection.Con.Execute(serviceSql, anonymousService);
            
                foreach (var part in aggregate.PartsCollection.Parts)
                {
                    var anonymousServiceParts = new
                    {
                        PartId = part.Id,
                        ServiceId = aggregate.Id,
                        Quantity = part.Quantity
                    };

                    _dbConnection.Con.Execute(servicePartsSql, anonymousServiceParts);
                }    
            
                transaction.Commit();
            }   
        }
    }
}