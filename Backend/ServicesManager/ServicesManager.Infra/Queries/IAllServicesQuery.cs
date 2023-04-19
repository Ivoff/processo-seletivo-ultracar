using ServicesManager.Infra.DTOs;

namespace ServicesManager.Infra.Queries;

public interface IAllServiceQuery
{
    public List<ServiceApiDTO> Read();
}