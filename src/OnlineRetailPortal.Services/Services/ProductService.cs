using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using OnlineRetailPortal.Services.Translators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    class ProductService : IProductService
    {
        IProductStoreFactory productStoreFactory;
        IProductStore productStore;
        CoreService core;
        public ProductService()
        {
            this.productStore = productStoreFactory.GetStoreType("Mock");
            core = new CoreService(this.productStore);
        }
        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            Core.CorePostResponse response = await core.AddProduct(addProductRequest.ToCore());
            return response.ToWeb(); 
        }

        public Task<GetProductResponse> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
