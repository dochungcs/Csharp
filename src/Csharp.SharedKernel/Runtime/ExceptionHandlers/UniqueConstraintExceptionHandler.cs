using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Csharp.SharedKernel.Runtime.ExceptionHandlers;

public sealed class UniqueConstraintExceptionHandler(ILogger<UniqueConstraintExceptionHandler> logger) : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
