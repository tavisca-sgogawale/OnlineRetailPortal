using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductStoreFactory _productStoreFactory;

        public ProductService(IProductStoreFactory productStoreFactory)
        {
            this._productStoreFactory = productStoreFactory;
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
