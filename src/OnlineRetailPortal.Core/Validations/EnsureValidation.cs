using FluentValidation;
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class EnsureValidation
    {
        public static void EnsureValidResult<Product>(this IValidator validator, Product product)
        {
            List<ErrorInfo> info = new List<ErrorInfo>();
            var validationResult = validator.Validate(product);

            if (product == null)
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
