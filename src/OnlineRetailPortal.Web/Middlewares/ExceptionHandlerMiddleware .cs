using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;
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
            var customException = exception as BaseException;
            var statusCode = (int)HttpStatusCode.InternalServerError;
            CustomErrorResponse customErrorResponse = new CustomErrorResponse()
            {
                Code = statusCode,
                Message = "Unexpected Error Occured"
            }; 

            if (customException != null)
            {
                customErrorResponse.Code = customException.Code;
                customErrorResponse.Message = customException.Message;
                customErrorResponse.Info = customException.Info;
                statusCode = (int)customException.HttpStatusCode;
            }

            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.BadRequest;

            return response.WriteAsync(JsonConvert.SerializeObject(customErrorResponse, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}
