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

public class CollaboratorRepository : IRepository<Collaborator>
{
    private readonly IOptions<ConnectionStrings> _connectionString;
    private readonly IDbConnection _dbConnection;
    
    public CollaboratorRepository(IOptions<ConnectionStrings> connectionString, IDbConnection dbConnection)
    {
        _connectionString = connectionString;
        _dbConnection = dbConnection;
    }

    public IList<Collaborator> Read(IList<Guid> ids)
    {
        List<Collaborator> output = new List<Collaborator>();
        CollaboratorDTO? curCollaborator;
        
        foreach (var id in ids)
        {
            curCollaborator = _dbConnection.Con
                .Query<CollaboratorDTO>(@"select * from collaborator where id = @Id", new { Id = id }).FirstOrDefault();

            if (curCollaborator == null)
                continue;
            
            output.Add(new Collaborator(curCollaborator.Id, curCollaborator.CreatedAt, curCollaborator.Name));
        }

        return output;
    }

    public void Write(Collaborator aggregate)
    {
        throw new NotImplementedException();
    }
}