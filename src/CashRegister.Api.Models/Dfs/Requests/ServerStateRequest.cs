namespace CashRegister.Api.Models.Dfs.Requests;

/// <summary>
///     Запит стану серверу.
/// </summary>
public class ServerStateRequest : BaseRequest
{
    public ServerStateRequest()
        : base("ServerState")
    {
    }
}