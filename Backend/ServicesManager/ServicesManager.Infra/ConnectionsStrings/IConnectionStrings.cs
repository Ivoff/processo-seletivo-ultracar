namespace ServicesManager.Infra.ConnectionStrings;

public interface IConnectionStrings
{
    public const string Position = "ConnectionStrings";

    public string Postgres { get; set; }
}