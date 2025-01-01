using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Csharp.SharedKernel.Authorization;

public class CurrentUser : ICurrentUser
{
    #region Properties

    private readonly IHttpContextAccessor _accessor;
    
    private ExecutionContext? _context { get; set; }
    
    public string TokenId => Guid.NewGuid().ToString();
    
    #endregion Properties

    public ExecutionContext Context
    {
        get
        {
            if (_context == null)
            {
                _context = GetContext(GetAccessToken());
            }
            return _context;
        }
        set { _context = value; }
        
    }
    
    
    public CurrentUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
    #region Privates

    private string GetAccessToken()
    {
        var bearerToken = _accessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString();
        if (string.IsNullOrEmpty(bearerToken) || bearerToken.Equals("Bearer"))
        {
            return "";
        }
        return bearerToken.Substring(7);
    }

    private ExecutionContext GetContext(string accessToken)
    {
        var httpContext = _accessor.HttpContext;
        if (string.IsNullOrEmpty(accessToken))
        {
            return new ExecutionContext { HttpContext = httpContext };
        }
        
        return new ExecutionContext
        {
            AccessToken = accessToken,
            HttpContext = httpContext
        };
    }
    
    #endregion
    
}
