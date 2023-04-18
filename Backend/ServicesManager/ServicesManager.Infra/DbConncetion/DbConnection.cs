using Npgsql;

namespace ServicesManager.Infra.DbConnection;

using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using ServicesManager.Infra.ConnectionStrings;
using ServicesManager.Infra.DbConnection;

public class DbConnection : IDbConnection
{
    public NpgsqlConnection Con { get; init; }
    public string ConnectionString { get; init; }

    public DbConnection(IOptions<ConnectionStrings> connectionString)
    {
        ConnectionString = connectionString.Value.Postgres;
        Con = new NpgsqlConnection(ConnectionString);
    }
}