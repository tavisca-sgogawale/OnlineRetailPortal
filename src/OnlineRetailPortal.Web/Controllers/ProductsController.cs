using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Web
{
    [Route("api/v1.0/onlineretailportal")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }
        [HttpGet("products/{productId}")]
        public async Task<GetProductResponse> GetProductAsync(string productId)
        {
           var request = new Contracts.GetProductServiceRequest();
           request.productId = productId;
           GetProductRequestValidator validationRules = new GetProductRequestValidator();
           validationRules.Validate(request);
           var response = await _productService.GetProductAsync(request);
           return response.ToGetProductContract();
        }
        [HttpGet("products")]
        public async Task<GetProductsResponse> GetProductsAsync(int pageNo,int pageSize)
        {
            var request = new Contracts.GetProductsServiceRequest();
            request.PageNo = pageNo;
            request.PageSize = pageSize;
            GetProductsRequestValidator validationRules = new GetProductsRequestValidator();
            validationRules.Validate(request);
            var response = await _productService.GetProductsAsync(request);
            return response.ToGetProductsContract();
        }
    }
}