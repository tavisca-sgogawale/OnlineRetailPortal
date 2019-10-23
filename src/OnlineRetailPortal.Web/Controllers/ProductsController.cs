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

        [HttpGet("products/{productId}")]
        public async Task<GetProductResponse> GetProductAsync(string productId)
        {
            var response = new Contracts.GetProductResponse() { Product = new Product{ Name = "Sheetal" } };
            // response = await _productService.GetProductAsync(productId);
            return response.ToDataContract();
            //return new GetProductResponse();
        }

        [HttpPost("Add")]
        public async Task<AddProductResponse> AddProductAsync([FromBody] AddProductRequest request)
        {
            AddProductRequestValidator validator = new AddProductRequestValidator();
            validator.Validate(request);
            var response = await _productService.AddProductAsync(request.ToDataContract());
            return response.ToUser();
        }
            
    }
}