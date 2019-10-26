using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Web.Validations;
using FluentValidation.Results;
using OnlineRetailPortal.Web.Translators;
using FluentValidation;

namespace OnlineRetailPortal.Web
{
    [Route("api/v1.0/onlineretailportal")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService=null)
        {
            this._productService = productService;
        }

        
        [HttpPost("product")]
        public async Task<AddProductRequest> AddProductAsync([FromBody] AddProductRequest request)
        {
              AddProductRequestValidator validator = new AddProductRequestValidator();
              validator.EnsureValid(request);
            // var response = await _productService.AddProductAsync(request.ToDataContract());
            // return response.ToUser();
            return request;
        }

        
    }
    public static class Validator
    {
        public static void EnsureValid<T>(this AbstractValidator<T> validator, T request)
        {
            var validationResult = validator.Validate(request);
            //ValidationFailure validationFailure = validationResult.Errors[0];
            if (validationResult.IsValid == false)
            {
                Console.WriteLine("***********************************");
                throw new Exception();
            }
            else if (validationResult.Errors.Count != 0)
                Console.WriteLine(validationResult.Errors[0]);           
        }
    }
}   