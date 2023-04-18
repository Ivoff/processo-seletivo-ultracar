using System.Data.SqlClient;
using Npgsql;

namespace ServicesManager.Infra.DbConnection;

public interface IDbConnection
{
    public NpgsqlConnection Con { get; init; }
    public string ConnectionString { get; init; }
}