using BancoDeSangue.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BancoDeSangue.API.ExceptionHandler
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            switch (exception)
            {
                case DomainException domainException:
                    
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await httpContext.Response.WriteAsJsonAsync(new
                    {
                        error = domainException.Message
                    }, cancellationToken);
                    return true;
                default:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await httpContext.Response.WriteAsJsonAsync(new
                    {
                        error = "Ocorreu um erro interno. Tente novamente mais tarde."
                    }, cancellationToken);
                    return true;
            }
        }
    }
}
