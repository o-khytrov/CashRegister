namespace CashRegister.Api.Persistence.Entities;

public class UserContext
{
    public UserContext(string username, string password, string keyStorage)
    {
        Username = username;
        Password = password;
        KeyStorage = keyStorage;
    }

    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string KeyStorage { get; set; }
}