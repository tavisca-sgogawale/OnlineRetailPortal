using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Web.Validations;
using FluentValidation.Results;
using OnlineRetailPortal.Web;
using FluentValidation;

namespace OnlineRetailPortal.Web
{
    [Route("api/v1.0/onlineretailportal")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpPost("product/add")]
        public async Task<AddProductResponse> AddProductAsync([FromBody] AddProductRequest request)
        {
            AddProductRequestValidator validator = new AddProductRequestValidator();
            validator.EnsureValid(request);
            var response = await _productService.AddProductAsync(request.ToEntity());
            return response.ToModel();
        }    
    }
}   