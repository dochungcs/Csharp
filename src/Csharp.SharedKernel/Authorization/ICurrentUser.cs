using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Csharp.SharedKernel.Authorization;

public interface ICurrentUser
{
    string TokenId { get; }
    
    ExecutionContext Context { get; }
}


public record ExecutionContext
{
    public ClaimsPrincipal Principal { get; set; } = default!;
    public string? AccessToken { get; set; }
    public string? OwnerId { get; set; }
    public string? Username { get; set; }
    public string? TenantId { get; set; } 
    public string? Permission { get; set; }
    public bool IsAdmin { get; set; }
    public HttpContext? HttpContext { get; set; }
}
