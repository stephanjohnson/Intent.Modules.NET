using System.Security.Claims;
using System.Threading.Tasks;
using CleanArchitecture.TestApplication.Application.Common.Interfaces;
using IdentityModel;
using Intent.RoslynWeaver.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Security.JWT.CurrentUserService", Version = "1.0")]

namespace CleanArchitecture.TestApplication.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        private readonly IAuthorizationService _authorizationService;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService)
        {
            _claimsPrincipal = httpContextAccessor?.HttpContext?.User;
            _authorizationService = authorizationService;
        }

        public string UserId => _claimsPrincipal?.FindFirst(JwtClaimTypes.Subject)?.Value;

        public string UserName => _claimsPrincipal?.FindFirst(JwtClaimTypes.Name)?.Value;

        public async Task<bool> AuthorizeAsync(string policy)
        {
            return (await _authorizationService.AuthorizeAsync(_claimsPrincipal, policy)).Succeeded;
        }

        public async Task<bool> IsInRoleAsync(string role)
        {
            return await Task.FromResult(_claimsPrincipal?.IsInRole(role) ?? false);
        }
    }
}