using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using OnlineRetailPortal.MongoDBStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductStoreFactory _productStoreFactory;
        private readonly IProductStore _productStore ;
        public ProductService(IProductStoreFactory productStoreFactory)
        {
            this._productStoreFactory = productStoreFactory;
            _productStore = _productStoreFactory.GetProductStore();
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            var config = new ProductConfiguration() 
            {
                ExpiryInDays=30
            };
            Core.Product product = addProductRequest.ToEntity();
            Core.Product response = await product.SaveAsync(_productStore, config);
            return response.ToModel();
        }

        public Task<GetProductServiceResponse> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
