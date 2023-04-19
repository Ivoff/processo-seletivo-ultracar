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

public class PartRepository : IRepository<Part>
{
    private readonly IOptions<ConnectionStrings> _connectionString;
    private readonly IDbConnection _dbConnection;
    
    public PartRepository(IOptions<ConnectionStrings> connectionString, IDbConnection dbConnection)
    {
        _connectionString = connectionString;
        _dbConnection = dbConnection;
    }

    public IList<Part> Read(IList<Guid> ids)
    {
        List<Part> output = new List<Part>();
        PartDTO? curPart;
        
        foreach (var id in ids)
        {
            curPart = _dbConnection.Con
                .Query<PartDTO>(@"select * from part where id = @Id", new { Id = id }).FirstOrDefault();
            
            if (curPart == null)
                continue;
            
            output.Add(new Part(curPart.Name, curPart.Price, 0, curPart.Id, curPart.CreatedAt));
        }

        return output;
    }

    public void Write(Part aggregate)
    {
        throw new NotImplementedException();
    }
}