﻿using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using OnlineRetailPortal.Mock;
using System;
using System.Collections.Generic;
using System.Net;

using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductStoreFactory _productStoreFactory; // factory or logic to resolve the product store will be handled later 
        private IProductStore _productStore = null;
        public ProductService(IProductStoreFactory productStoreFactory)
        {
            _productStoreFactory = productStoreFactory;
            _productStore = _productStoreFactory.GetProductStore();
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            var config = new ProductConfiguration()
            {
                ExpiryInDays = 30
            };

            Core.Product product = addProductRequest.ToEntity();
            Core.Product response = await product.SaveAsync(_productStore, config);
            return response.ToModel();
        }

        public async Task<GetProductServiceResponse> GetProductAsync(string productId)
        {
            var response = await Core.Product.GetAsync(productId, _productStore);
            response.EnsureValid(productId);
            return GetProductServiceResponseTranslator.ToModel(response);
        }

        public async Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request)
        {
            var response = await Core.Product.GetProductsAsync(request, _productStore);
            return response.ToModel();
        }

        public async Task<GetProductServiceResponse> UpdateProductAsync(ProductEntity updateProductEntity)
        {
            Core.Product updateProduct = updateProductEntity.ToEntity();
            var response = await updateProduct.UpdateAsync(_productStore);
            response.EnsureValid(updateProductEntity);
            return GetProductServiceResponseTranslator.ToModel(response);
        }
    }
}
