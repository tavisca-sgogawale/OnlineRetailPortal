using System;
using FluentValidation.Results;
using FluentValidation;
using System.Linq;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System.Net;
using OnlineRetailPortal.Contracts.Errors;
using System.Collections.Generic;

namespace OnlineRetailPortal.Web.Validations
{
    public static class EnsureValidator
    {
        private static BaseException validationError;

        public static void EnsureValid<AddProductRequest>(this AbstractValidator<AddProductRequest> validator, AddProductRequest request)
        {
            var validationResult = validator.Validate(request);

            if (request == null)
                throw new Exception(Error.MissingField("Product"));
                    
            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    validationError = UserExceptions.InvalidRequest(error.ErrorMessage, error.ErrorCode, HttpStatusCode.BadRequest);
                }
                throw validationError;
            }
        }
    }
}