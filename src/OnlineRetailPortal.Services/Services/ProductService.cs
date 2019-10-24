
﻿using OnlineRetailPortal.Contracts;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
   public class ProductService : IProductService
    {
        public async Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request)
        {
            List<Core.Product> product = Core.Product.GetProducts(request.PageNo,request.PageSize);
            return await Task.FromResult<GetProductsServiceResponse>(product.ToGetProductsContract());
        }

        public async Task<GetProductServiceResponse>  GetProductAsync(GetProductServiceRequest request)
        {
            Core.Product product = Core.Product.GetProduct(request.productId);
            return await Task.FromResult<GetProductServiceResponse>(product.ToGetProductContract());
        }
    }
}