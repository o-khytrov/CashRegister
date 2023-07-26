using CashRegister.Api.Persistence.Entities;
using CashRegister.Models;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Api.Controllers;

public static class ControllerExtensions
{
    public static UserKeyInfo GetKeyInfo(this ControllerBase controller)
    {
        var keyFilePath = controller.User.Claims.First(x => x.Type == nameof(UserContext.KeyStorage)).Value;
        var password = controller.User.Claims.First(x => x.Type == nameof(UserContext.Password)).Value;
        return new UserKeyInfo(keyFilePath, password);
    }
}