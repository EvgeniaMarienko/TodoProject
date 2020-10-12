using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TodoBuisness.Exceptions;

namespace ToDoProject.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string message;
            if (exception is TodoException todoException)
            {
                statusCode = todoException.StatusCode;
                message = todoException.Message;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = exception.Message;
            }
            var result = JsonSerializer.Serialize(new { ErrorMessage = message, StatusCode = statusCode });
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
