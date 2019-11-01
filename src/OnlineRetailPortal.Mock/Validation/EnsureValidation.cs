using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class EnsureValidation
    {
        public static void EnsureValidResult<Product>(this IValidator validator, Product product)
        {
            var validationResult = validator.Validate(product);

            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.Errors[0].ToString());
            }
        }
    }
}
