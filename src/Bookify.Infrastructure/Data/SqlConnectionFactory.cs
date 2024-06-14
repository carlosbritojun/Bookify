using Bookify.Application.Abstractions.Data;
using Npgsql;
using System.Data;

namespace Bookify.Infrastructure.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    private readonly string _connectionString;

    public IDbConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
