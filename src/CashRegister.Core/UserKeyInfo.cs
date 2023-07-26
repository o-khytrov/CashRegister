namespace CashRegister.Models;

public class UserKeyInfo
{
    public UserKeyInfo(string keyDirectory, string password)
    {
        KeyDirectory = keyDirectory;
        Password = password;
    }

    public string KeyDirectory { get; set; }

    public string Password { get; set; }
}