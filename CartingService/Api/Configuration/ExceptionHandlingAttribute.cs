using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Api.Configuration;

internal class ExceptionHandlingAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<ExceptionHandlingAttribute> _logger;

    public ExceptionHandlingAttribute(ILogger<ExceptionHandlingAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case EntityNotFoundException _:
                SetErrorResponse(context, StatusCodes.Status404NotFound);
                return;
            case ValidationException _:
                SetErrorResponse(context, StatusCodes.Status400BadRequest);
                return;
            default:
                SetErrorResponse(context, StatusCodes.Status500InternalServerError);
                return;
        }
    }

    private void SetErrorResponse(ExceptionContext context, int statusCode)
    {
        var response = new { context.Exception.Message };
        context.Result = new ObjectResult(response) { StatusCode = statusCode };

        _logger.LogError(context.Exception, context.Exception.Message);
    }
}
