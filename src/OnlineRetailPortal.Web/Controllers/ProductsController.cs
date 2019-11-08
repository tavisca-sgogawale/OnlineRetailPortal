﻿using System;
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
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<GetProductsResponse> GetProductsAsync(int pageNo, int pageSize)
        {
            var request = GetProductsServiceRequestTranslator.ToServiceRequest(pageNo, pageSize);//pageSize and pageNumber is will  be set in app setings
            var response = await _productService.GetProductsAsync(request);
            return response.ToGetProductsContract();
        }
        [HttpGet("products/{productId}")]
        public async Task<GetProductResponse> GetProductAsync(string productId)
        {
            GetProductRequestValidator validator = new GetProductRequestValidator();
            validator.EnsureValid(productId);
            var response = await _productService.GetProductAsync(productId);
            return response.ToEntity();
        }
        [HttpPost("products/add")]
        public async Task<AddProductResponse> AddProductAsync([FromBody] AddProductRequest request)
        {
            AddProductRequestValidator validator = new AddProductRequestValidator();
            validator.EnsureValid(request);
            var response = await _productService.AddProductAsync(request.ToEntity());
            return response.ToModel();
        }

    }
}