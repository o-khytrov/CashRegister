using CashRegister.Api.Models.Dfs;
using CashRegister.Api.Options;
using CashRegister.Api.Persistence.Entities;
using Microsoft.Extensions.Options;

namespace CashRegister.Api.Services;

public interface IUserService
{
    UserContext Authenticate(string username, string password);
}

public class UserService : IUserService
{
    private readonly KeyStorageOptions _storageOptions;

    public UserService(IOptions<KeyStorageOptions> storageOptions)
    {
        _storageOptions = storageOptions.Value;
    }

    public UserContext Authenticate(string username, string password)
    {
        var keyStoragePath = _storageOptions.StorageDirectory;
        if (keyStoragePath is null)
        {
            throw new ArgumentNullException(nameof(KeyStorageOptions.StorageDirectory));
        }

        var userKeyPath = Path.Combine(keyStoragePath, username);
        if (Directory.Exists(userKeyPath))
        {
            return new UserContext(username, password, userKeyPath);
        }

        throw new NotFoundException($"Key of the user '{username}' not found");
    }
}