using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TodoBusiness.Exceptions;
using TodoWeb.Models;

namespace TodoWeb.Middlewares
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
            var responseModel = new ErrorResponseModel { ErrorMessage = message, StatusCode = statusCode };
            var result = JsonSerializer.Serialize(TodoResponseModel<ErrorResponseModel>.Fail(responseModel));
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
