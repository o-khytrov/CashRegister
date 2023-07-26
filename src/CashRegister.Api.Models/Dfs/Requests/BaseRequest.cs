namespace CashRegister.Api.Models.Dfs.Requests;

public class BaseRequest
{
    protected BaseRequest(string name)
    {
        Command = name;
    }

    public string Command { get; set; }
}