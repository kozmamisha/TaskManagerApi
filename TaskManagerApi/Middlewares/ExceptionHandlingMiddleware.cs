using System.Net;
using System.Text.Json;
using TaskManager.BusinessLogic.DTO;
using TaskManager.BusinessLogic.Exceptions;

namespace TaskManagerApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        // function for handling HTTP request
        private readonly RequestDelegate _next;
        // for logging errors
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // this method will be called in the pipeline
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var (statusCode, message) = ex switch
                {
                    BadRequestException => (HttpStatusCode.BadRequest, ex.Message),
                    NotFoundException => (HttpStatusCode.NotFound, ex.Message),
                    UnauthorizedAccessException => (HttpStatusCode.Unauthorized, ex.Message),
                    _ => (HttpStatusCode.InternalServerError, "Internal server error")
                };

                await HandleExceptionAsync(context, ex.Message, statusCode, message);
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context, 
            string exceptionMessage, 
            HttpStatusCode httpStatusCode, 
            string message)
        {
            _logger.LogError(exceptionMessage);

            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDto errorDto = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            string result = JsonSerializer.Serialize(errorDto);

            await response.WriteAsJsonAsync(result);
        }
    }
}
