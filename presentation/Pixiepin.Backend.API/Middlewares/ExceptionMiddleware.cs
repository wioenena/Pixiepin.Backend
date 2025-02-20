using Pixiepin.Backend.Application.DTOs;
using Pixiepin.Backend.Application.DTOs.ApiResponse;
using Pixiepin.Backend.Application.Exceptions;
using Pixiepin.Backend.Application.Exceptions.Common;

namespace Pixiepin.Backend.API.Middlewares;

public class ExceptionMiddleware : IMiddleware {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
        try {
            await next(context);
        } catch (Exception e) {
            await this.HandleException(context, e);
        }
    }

    public async Task HandleException(HttpContext context, Exception e) {
        var statusCode = e is BaseException ? StatusCodes.Status400BadRequest : StatusCodes.Status500InternalServerError;
        var errorResponseAsJSON = new ApiResponse<object, ExceptionDTO>(
            null,
            e is BaseException baseException ?
                baseException.ToJSON() :
                new InternalServerException(e.Message).ToJSON()
        );

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(errorResponseAsJSON);
    }
}
