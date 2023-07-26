using System.Data;
using CashRegister.Api.Persistence.Entities;
using CashRegister.Models.Options;
using Dapper;
using Microsoft.Extensions.Options;

namespace CashRegister.Api.Persistence.Repositories;

public interface IUserRepository
{
    Task<UserContext> FindUser(string username, string passwordHash);
}

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IOptions<ConnectionStrings> connectionStrings)
        : base(connectionStrings)
    {
    }

    public async Task<UserContext> FindUser(string username, string passwordHash)
    {
        await using var conn = NewConnection;
        var @params = new DynamicParameters();
        @params.Add("@username", username, DbType.String);
        @params.Add("@password_hash", passwordHash, DbType.String);
        return await conn.QueryFirstOrDefaultAsync<UserContext>("dbo.sp_user_find", @params,
            commandType: CommandType.StoredProcedure);
    }
}