using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts.Errors;
namespace OnlineRetailPortal.Web
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            var customException = exception as BaseException;
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Unexpected Error Occured";
  
            if (exception as BaseException != null)
            {
                message = customException.Message;
                statusCode = customException.Code;
            }

            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.BadRequest;

            return response.WriteAsync(JsonConvert.SerializeObject(new CustomErrorResponse
            {
                Code = statusCode,
                Message = message
            }));
        }
    }
}
