using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using CashRegister.Api.Persistence.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace CashRegister.Api.Services;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthOptions>
{
    private readonly IUserService _userService;

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IUserService userService)
        : base(options, logger, encoder, clock)
    {
        _userService = userService;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var endpoint = Context.GetEndpoint();
        if (endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null)
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));
        }

        UserContext userContext;
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            if (string.IsNullOrWhiteSpace(authHeader.Parameter))
            {
                return Task.FromResult(AuthenticateResult.Fail("Key password is empty"));
            }

            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] {':'}, 2);
            var username = credentials[0];
            var password = credentials[1];
            userContext = _userService.Authenticate(username, password);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "failed to authenticate");

            return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userContext.Id.ToString()),
            new Claim(ClaimTypes.Name, userContext.Username),
            new Claim(nameof(userContext.KeyStorage), userContext.KeyStorage),
            new Claim(nameof(UserContext.Password), userContext.Password)
        };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}