using System;
using FluentValidation.Results;
using FluentValidation;
using System.Linq;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System.Net;
using System.Collections.Generic;

namespace OnlineRetailPortal.Web.Validations
{
    public static class EnsureValidator
    {
        
        public static void EnsureValid<AddProductRequest>(this AbstractValidator<AddProductRequest> validator, AddProductRequest request)
        {
            List<ErrorInfo> info = new List<ErrorInfo>();
            var validationResult = validator.Validate(request);

            if (request == null)
                throw new Exception(Error.MissingField("Product"));
                    
            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    info.Add(new ErrorInfo { Code = int.Parse(error.ErrorCode), Message = error.ErrorMessage });
                }
                throw new BaseException(Convert.ToInt32(ErrorCodes.Invalid()), Error.Invalid(), info , HttpStatusCode.BadRequest);
            }
        }
    }
}