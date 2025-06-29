using ProductFlow.Core.Application.Exceptions;
using ProductFlow.Core.Application.Model;
using ProductFlow.Core.Domain.Exceptions;

namespace ProductFlow.Core.Infra.Api.Middleware
{
    public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocorreu uma exceção não tratada.");
                await HandlerExceptionAsync(context, ex);
            }
        }

        private static async Task HandlerExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 500;

            var response = new DefaulResult(
                message: ex.Message,
                success: false
            );

            if (ex is BaseException baseException)
            {
                httpContext.Response.StatusCode = (int)baseException.StatusCode;

                response = new DefaulResult(
                    success: false,
                    erros: [ex.Message]
                );
            }

            if (ex is ApiException apiException)
            {
                httpContext.Response.StatusCode = (int)apiException.StatusCode;

                response = new DefaulResult(
                    success: false,
                    erros: apiException.Errors
                );
            }

            await httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
