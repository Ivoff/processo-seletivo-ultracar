namespace ServicesManager.Infra.Repository;

using ServicesManager.Domain.Shared;
using ServicesManager.Domain.Service;
using System.Collections.Generic;
using System;

public class ServiceRepository : IRepository<Service>
{
    public IList<Service> Read(IList<Guid> ids)
    {
        throw new NotImplementedException();
    }

    public void Write(Service aggregate)
    {
        throw new NotImplementedException();
    }
}