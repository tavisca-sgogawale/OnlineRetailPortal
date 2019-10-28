using System;
using FluentValidation.Results;
using FluentValidation;
using System.Linq;

namespace OnlineRetailPortal.Web.Validations
{
    public static class Validator
    {
        public static void EnsureValid<AddProductRequest>(this AbstractValidator<AddProductRequest> validator, AddProductRequest request)
        {
            var validationError = ErrorMessages.NullField("Product");
            var validationResult = validator.Validate(request);
          //  ValidationFailure validationFailure = validationResult.Errors[0];

            if (request == null)
                throw new Exception(validationError);         

            if (validationResult.IsValid == false)
                throw new Exception(validationResult.Errors[0].ToString());
        }
    }
}
