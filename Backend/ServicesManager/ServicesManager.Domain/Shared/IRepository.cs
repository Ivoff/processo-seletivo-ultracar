namespace ServicesManager.Domain.Shared;

public interface IRepository<T>
{
    public IList<T> Read(IList<Guid> ids);
    public void Write(T aggregate);
}