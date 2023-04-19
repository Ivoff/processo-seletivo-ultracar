namespace ServicesManager.Infra.Queries;

using ServicesManager.Domain.Service;
using ServicesManager.Domain.Shared;
using ServicesManager.Infra.DbConnection;
using ServicesManager.Infra.DTOs;
using Dapper;

public class AllServicesQuery: IAllServiceQuery
{
    private readonly IRepository<Service> _serviceRepository;
    private readonly IDbConnection _dbConn;
    public AllServicesQuery(IRepository<Service> serviceRepository, IDbConnection dbConn)
    {
        _serviceRepository = serviceRepository;
        _dbConn = dbConn;
    }
    
    public List<ServiceApiDTO> Read()
    {
        List<ServiceApiDTO> services = _dbConn.Con.Query<ServiceApiDTO>(@"
        select 
            service.id as ServiceId,
            service.createdat as CreatedAt,
            collaborator.name as CollaboratorName,
            collaborator.id as CollaboratorId,
            car.model as CarModel,
            car.year as CarYear,
            client.name as OwnerName,
            client.id as OwnerId,
            service.startedat as StartedAt,
            service.finishedat as FinishedAt
        from service
            inner join car on
                service.carid = car.id
            inner join collaborator on
                service.collaboratorid = collaborator.id
            inner join client on
                client.id = car.ownerid
        ").ToList();

        return services.Select((x) =>
        {
            decimal total = _dbConn.Con.ExecuteScalar<decimal>(@"
            select total 
            from (
                select 
                    service_parts.serviceid as ServiceId,
                    sum(part.price * service_parts.quantity) as Total
                from
                    service_parts inner join part on service_parts.partid = part.id
                where 
                    service_parts.serviceid = @Id
                group by service_parts.serviceid
            ) subquery   
            ", new { Id = x.ServiceId });

            x.TotalCost = total;

            if (x.StartedAt == null)
                x.CurrentState = "On Hold";
            else if (x.FinishedAt == null)
            {
                x.CurrentState = "In Progress";
                x.ElapsedTime = GetFriendlyTimeSpanText(x.StartedAt.Value, DateTime.Now);
            }
            else
            {
                x.CurrentState = "Finished";
                x.ElapsedTime = GetFriendlyTimeSpanText(x.StartedAt.Value, x.FinishedAt.Value);
            }

            return x;
        }).ToList();
    }
    
    private string GetFriendlyTimeSpanText(DateTime lower, DateTime upper)
    {
        string returnString = string.Empty;
        TimeSpan timeSpan = upper - lower;
        if (timeSpan.Days >= 1)
        {
            returnString = lower.ToShortDateString();
        }
        else
        {
            if (timeSpan.Hours == 0 && timeSpan.Minutes == 0)
            {
                returnString = "less than 1 minute";
            }
            else
            {
                if (timeSpan.Hours > 0) returnString = timeSpan.Hours.ToString() + " hours, ";
                returnString += timeSpan.Minutes.ToString() + " minutes ago";
            }
        }
        return returnString;
    }
}