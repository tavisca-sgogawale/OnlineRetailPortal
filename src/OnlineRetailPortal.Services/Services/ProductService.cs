using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
   public class ProductService : IProductService
    {
        private readonly IProductStore _productStore; // factory or logic to resolve the product store will be handled later 
        //public ProductService(IProductStore productStore)
        //{
        //    _productStore = productStore;
        //}
        public async Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request)
        {
            var response = await Core.Product.GetProductsAsync(request,_productStore );
            //get list based on paging info 
            return await Task.FromResult(response.ToGetProductsContract());
        }

        public async Task<GetProductServiceResponse>  GetProductAsync(string productId)
        {
            var response = await Core.Product.GetProductAsync(productId, _productStore);
            return response.ToGetProductContract();
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            var store =_productStoreFactory.GetProductStore("Mock");
            Core.Product product = addProductRequest.ToEntity();
            Core.Product response = await product.SaveAsync(store);
            return response.ToModel();
        }

    }
}
