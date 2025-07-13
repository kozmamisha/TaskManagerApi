using System.Net;
using System.Text.Json;
using TaskManager.BusinessLogic.DTO;

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
            catch(KeyNotFoundException ex)
            {
                await HandleExceptionAsync(
                    context, 
                    ex.Message, 
                    HttpStatusCode.NotFound, 
                    "Resource not found");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(
                    context, 
                    ex.Message, 
                    HttpStatusCode.InternalServerError, 
                    "Internal server error");
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
