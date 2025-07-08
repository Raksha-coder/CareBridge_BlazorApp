using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace CareBridge.Auth
{
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // For server-side, we return an anonymous user by default
            // The actual authentication will be handled by the client-side AuthenticationStateProvider
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            return Task.FromResult(new AuthenticationState(anonymous));
        }
    }
}
