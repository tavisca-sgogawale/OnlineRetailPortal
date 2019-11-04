using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts.Errors;
using System.Collections.Generic;

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
            ExceptionErrorInfo customExceptiono = new ExceptionErrorInfo((int)HttpStatusCode.InternalServerError, "Unexpected Error Occured", HttpStatusCode.BadRequest); 

            if (exception is BaseException ex)
            {
                customExceptiono = GetErrorInfo(ex);
            }

            response.ContentType = "application/json";
            return response.WriteAsync(JsonConvert.SerializeObject(customExceptiono));
        }

        public static ExceptionErrorInfo GetErrorInfo(BaseException exception)
        {
            ExceptionErrorInfo error = new ExceptionErrorInfo(exception.Code, exception.Message, exception.HttpStatusCode);

         //   if (exception.Data.Keys.Count == 0)
           //     return error;

            Dictionary<int, string> errorData = new Dictionary<int, string>();

            foreach (var key in exception.Info)
            {
                errorData.Add(key.Key,key.Value);
            }

            error.data = errorData;
            return error;
        }
    }
}

