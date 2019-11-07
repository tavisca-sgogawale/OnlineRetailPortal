using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IIS;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Web.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace OnlineRetailPortal.Web.Validations
{
    public static class ImageRequestValidator
    {
        /// <summary>
        /// Checks if the incoming request is valid and throws an appropriate BaseException if the request is invalid.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static void Validate(this AbstractValidator<HttpRequest> validator, HttpRequest request)
        {
            if (request.ContentLength == 0)
                throw new BaseException(StatusCodes.Status400BadRequest, "No file was recieved or file was sent with an invalid form key", null, System.Net.HttpStatusCode.BadRequest);

        var validationResult = validator.Validate(request);

            if (validationResult.IsValid == false)
            {
                var error = validationResult.Errors[0];                
                throw new BaseException(Convert.ToInt32(error.ErrorCode),error.ErrorMessage,null, HttpStatusCode.BadRequest);
                
            }
        }


        public static void ValidateDeleteRequest(this AbstractValidator<string> validator, string id)
        {
            var validationResult = validator.Validate(id);
            if (validationResult.IsValid == false)
            {
                var error = validationResult.Errors[0];
                throw new BaseException(Convert.ToInt32(error.ErrorCode), error.ErrorMessage, null, HttpStatusCode.BadRequest);
            }
           
        }

    }
}
