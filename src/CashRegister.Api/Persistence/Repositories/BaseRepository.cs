using System.Data.Common;
using CashRegister.Models.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace CashRegister.Api.Persistence.Repositories;

public abstract class BaseRepository
{
    private readonly ConnectionStrings _connectionString;

    protected BaseRepository(IOptions<ConnectionStrings> connectionStrings)
    {
        _connectionString = connectionStrings.Value;
    }

    protected DbConnection NewConnection => GetConnection<SqlConnection>(_connectionString.CashRegisterDb);

    protected virtual TConnection GetConnection<TConnection>(string? connectionString)
        where TConnection : DbConnection, new()
    {
        var conn = new TConnection();
        conn.ConnectionString = connectionString;
        return conn;
    }
}