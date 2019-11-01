using System;
using FluentValidation.Results;
using FluentValidation;
using System.Linq;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;

namespace OnlineRetailPortal.Web.Validations
{
    public static class EnsureValidator
    {
        public static void EnsureValid<AddProductRequest>(this AbstractValidator<AddProductRequest> validator, AddProductRequest request)
        {

            var validationResult = validator.Validate(request);

            if (request == null)
                throw new Exception(Error.MissingField("Product"));
                    
            if (validationResult.IsValid == false)
            {
                var validationError = UserExceptions.InvalidRequest(validationResult.Errors[0].ErrorMessage,validationResult.Errors[0].ErrorCode);     
                throw validationError;
            }
        }
    }
}
