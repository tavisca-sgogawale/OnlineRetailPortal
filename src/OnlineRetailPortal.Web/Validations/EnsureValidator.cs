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
        
        public static void EnsureValid<AddProductRequest>(this AbstractValidator<AddProductRequest> validator, AddProductRequest request)
        {
            List<Tuple<int, string>> info = new List<Tuple<int, string>>();
            var validationResult = validator.Validate(request);

            if (request == null)
                throw new Exception(Error.MissingField("Product"));
                    
            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    info.Add(Tuple.Create(int.Parse(error.ErrorCode), error.ErrorMessage));
                }
                throw new BaseException(404, "Failure Occured", info, HttpStatusCode.OK);
            }
        }
    }
}