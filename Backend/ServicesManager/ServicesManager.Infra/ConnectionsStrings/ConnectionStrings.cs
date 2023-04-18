namespace ServicesManager.Infra.ConnectionStrings;

public class ConnectionStrings : IConnectionStrings
{
    public const string Position = "ConnectionStrings";
    public string Postgres { get; set; } = String.Empty;
}