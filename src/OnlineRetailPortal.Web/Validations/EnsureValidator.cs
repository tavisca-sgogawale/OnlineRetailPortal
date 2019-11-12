using System;
using FluentValidation.Results;
using FluentValidation;
using System.Linq;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System.Net;
using System.Collections.Generic;

namespace OnlineRetailPortal.Web
{
    public static class EnsureValidator
    {    
        public static void EnsureValid<AddProductRequest>(this AbstractValidator<AddProductRequest> validator, AddProductRequest request)
        {
            List<ErrorInfo> info = new List<ErrorInfo>();

            if (request == null)
                throw new BaseException(Convert.ToInt32(ErrorCode.NullRequest()), Error.NullRequest(), null, HttpStatusCode.BadRequest);

            var validationResult = validator.Validate(request);
            
            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    info.Add(new ErrorInfo { Code = error.ErrorCode, Message = error.ErrorMessage });
                }
                throw new BaseException(Convert.ToInt32(ErrorCode.InvalidRequest()), Error.InvalidRequest(), info , HttpStatusCode.BadRequest);
            }
        }

        public static void EnsureUpdateRequestValid<UpdateProductEntity>(this AbstractValidator<UpdateProductEntity> validator, UpdateProductEntity request)
        {
            List<ErrorInfo> info = new List<ErrorInfo>();
            var validationResult = validator.Validate(request);

            if (request == null)
                throw new BaseException(Convert.ToInt32(ErrorCode.NullRequest()), Error.NullRequest(), null, HttpStatusCode.BadRequest);

            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    info.Add(new ErrorInfo { Code = error.ErrorCode, Message = error.ErrorMessage });
                }
                throw new BaseException(Convert.ToInt32(ErrorCode.InvalidRequest()), Error.InvalidRequest(), info, HttpStatusCode.BadRequest);
            }
        }
    }
}